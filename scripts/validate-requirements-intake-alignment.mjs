#!/usr/bin/env node

import crypto from "node:crypto";
import fs from "node:fs";
import path from "node:path";
import process from "node:process";
import {fileURLToPath} from "node:url";

const normalize = (value) => value.replace(/^\uFEFF/, "").replace(/\r\n?/g, "\n");
const digest = (value) => crypto.createHash("sha256").update(normalize(value)).digest("hex");

export function validate(options = {}) {
  const root = options.root ?? process.cwd();
  const resolve = (candidate) => path.isAbsolute(candidate) ? candidate : path.join(root, candidate);
  const read = (relativePath) => fs.readFileSync(resolve(relativePath), "utf8");
  const parse = (relativePath) => JSON.parse(read(relativePath));
  const config = parse(options.configPath ?? "requirements/intake-governance-config.json");
  const manifestPath = options.manifestPath ??
    config.collections?.seriesManifest ?? config.seriesManifest;
  const coveragePath = options.coveragePath ??
    "specs/requirements-reconciliation-20260726/requirements-coverage.json";
  const errors = [];
  const manifest = parse(manifestPath);
  const coverage = parse(coveragePath);
  const targets = manifest.orderedTargets ?? [];
  const seriesTargetCount = targets.length;
  const expectedActiveCount = config.schemaVersion === "1.0"
    ? config.activeIntakeCount
    : targets.filter((target) => target.status !== "Completed").length;
  const expectedArchiveCount = config.schemaVersion === "1.0"
    ? config.archiveIntakeCount
    : 0;
  const activeCollection = config.collections?.active ?? "requirements/intakes/active";
  const archiveCollection = config.collections?.archive ?? "requirements/intakes/archive";
  const canonicalIndex = config.artifactNaming?.canonicalIndex ?? config.canonicalIndex;
  const preferredNext = config.schemaVersion === "1.0"
    ? config.preferredNext
    : null;
  const baselinePath =
    "requirements/baseline/PLAN_MICROCALC_CSHARP_DOTNET10.pre-intake-split.2026-07-26.md";
  const recordedBaseline = coverage.sources?.find((source) => source.sourceId === "TC-BASELINE");

  if (!recordedBaseline || digest(read(baselinePath)) !== recordedBaseline.normalizedSha256) {
    errors.push("baseline plan hash differs from reconciliation evidence");
  }

  const requirements = coverage.requirements ?? [];
  const requirementIds = requirements.map((item) => item.requirementId);
  if (requirementIds.length !== seriesTargetCount ||
      new Set(requirementIds).size !== requirementIds.length) {
    errors.push(`coverage must contain exactly ${seriesTargetCount} unique requirement IDs`);
  }
  for (const item of requirements) {
    if (["Open", "PartiallySatisfied"].includes(item.status) &&
        (!item.proposedOwnerGroup || item.proposedOwnerGroup === "N/A")) {
      errors.push(`open requirement lacks owner: ${item.requirementId}`);
    }
  }

  const listMarkdown = (relativePath) => fs.existsSync(resolve(relativePath))
    ? fs.readdirSync(resolve(relativePath)).filter((name) => name.endsWith(".md")).sort()
    : [];
  const active = listMarkdown(activeCollection);
  const archived = listMarkdown(archiveCollection);
  const rootLastenhefte = fs.readdirSync(root).filter((name) => /^Lastenheft.*\.md$/.test(name));
  if (active.length !== expectedActiveCount) {
    errors.push(`expected ${expectedActiveCount} active intakes, found ${active.length}`);
  }
  if (config.schemaVersion === "1.0" && archived.length !== expectedArchiveCount) {
    errors.push(`expected ${expectedArchiveCount} archived intakes, found ${archived.length}`);
  }
  if (rootLastenhefte.join(",") !== "Lastenheft_Abarbeitungsreihenfolge.md") {
    errors.push("only the generated processing-order view may remain as root Lastenheft");
  }

  const targetPaths = targets.map((target) => target.path);
  if (new Set(targetPaths).size !== targetPaths.length) {
    errors.push("series must contain unique active targets and archived predecessors");
  }
  const expectedActive = active.map((name) => `${activeCollection}/${name}`).sort();
  const activeTargetPaths = targets.filter((target) => target.status !== "Completed")
    .map((target) => target.path).sort();
  if (JSON.stringify(activeTargetPaths) !== JSON.stringify(expectedActive)) {
    errors.push("active intake directory and series targets differ");
  }
  // Archivierte Vorgaenger bleiben Teil der Serie; physische Pfade muessen zum Lifecycle passen.
  // Archived predecessors remain in the series; physical paths must match lifecycle state.
  const inCollection = (candidate, collection) => {
    const portable = typeof candidate === "string" && !candidate.includes("\\") &&
      !path.isAbsolute(candidate) && candidate.split("/").every((part) => part && part !== "." && part !== "..");
    if (!portable || !candidate.startsWith(`${collection}/`) || !fs.existsSync(resolve(candidate))) return false;
    const relative = path.relative(fs.realpathSync(resolve(collection)), fs.realpathSync(resolve(candidate)));
    return relative !== "" && relative !== ".." && !relative.startsWith(`..${path.sep}`) &&
      !path.isAbsolute(relative) && fs.statSync(resolve(candidate)).isFile();
  };
  for (const target of targets) {
    if (!["Pending", "Blocked", "Eligible", "Active", "Completed", "Withdrawn"].includes(target.status)) {
      errors.push(`unknown lifecycle status: ${target.status}`);
    }
    if (!inCollection(target.path, target.status === "Completed" ? archiveCollection : activeCollection)) {
      errors.push(`lifecycle collection mismatch (archive or backlog cannot be executable): ${target.path}`);
    }
    if (!target.path || !fs.existsSync(resolve(target.path))) {
      errors.push(`series target is missing: ${target.path ?? "N/A"}`);
    } else if (digest(read(target.path)) !== target.normalizedSha256) {
      errors.push(`series target hash drift: ${target.path}`);
    }
  }

  const eligible = targets.filter((target) => target.status === "Eligible");
  // Schema 2 führt den Lifecycle im kanonischen Manifest; nur Schema 1 besitzt noch einen separaten bevorzugten Pfad.
  // Schema 2 keeps lifecycle state in the canonical manifest; only schema 1 still has a separate preferred path.
  if (eligible.length > 1) {
    errors.push("at most one explicitly Eligible target may be configured");
  }
  if (config.schemaVersion === "2.0" && manifest.status !== "Completed" && eligible.length !== 1) {
    errors.push("active series requires exactly one explicitly Eligible target");
  }
  if (manifest.status === "Completed" && (eligible.length || targets.some((target) => target.status !== "Completed"))) {
    errors.push("completed series requires only completed archived targets and no Eligible target");
  }
  if (preferredNext && eligible.length !== 1) {
    errors.push("schema 1 preferredNext requires exactly one explicitly Eligible target");
  } else if (preferredNext && eligible[0].path !== preferredNext) {
    errors.push("schema 1 preferredNext must match the explicitly Eligible target");
  }

  const dependencies = manifest.dependencies ?? [];
  const indegree = new Map(targetPaths.map((target) => [target, 0]));
  const adjacency = new Map(targetPaths.map((target) => [target, []]));
  for (const edge of dependencies) {
    if (!indegree.has(edge.from) || !indegree.has(edge.to) || edge.from === edge.to ||
        edge.kind !== "HardCompletionGate" || edge.binding !== true) {
      errors.push(`invalid dependency reference: ${edge.from} -> ${edge.to}`);
      continue;
    }
    indegree.set(edge.to, indegree.get(edge.to) + 1);
    adjacency.get(edge.from).push(edge.to);
  }
  const roots = [...indegree].filter(([, value]) => value === 0).map(([key]) => key);
  if (JSON.stringify([...roots].sort()) !== JSON.stringify([...(manifest.roots ?? [])].sort())) {
    errors.push("manifest roots differ from dependency graph");
  }
  const queue = [...roots];
  const remaining = new Map(indegree);
  let visited = 0;
  while (queue.length > 0) {
    const current = queue.shift();
    visited++;
    for (const successor of adjacency.get(current) ?? []) {
      remaining.set(successor, remaining.get(successor) - 1);
      if (remaining.get(successor) === 0) queue.push(successor);
    }
  }
  if (visited !== targetPaths.length) errors.push("series dependencies contain a cycle");

  const order = read("Lastenheft_Abarbeitungsreihenfolge.md");
  const index = read(canonicalIndex);
  for (const target of targetPaths) {
    if (!order.includes(target)) errors.push(`processing order omits active target: ${target}`);
  }
  if (!index.includes(manifestPath)) errors.push("Pflichtenheft index omits canonical manifest");
  if (/\[[ xX-]\]/.test(index)) errors.push("slim Pflichtenheft must not contain progress checkboxes");
  if ((config.featureMustRemainAbsent ?? true) && fs.existsSync(resolve(".specify/feature.json"))) {
    errors.push("requirements migration must not start a Spec Kit feature");
  }

  const activeReceipts = fs.readdirSync(resolve("specs/intake-authoring-receipts"))
    .filter((name) => name.endsWith(".json"));
  if (activeReceipts.length !== seriesTargetCount) {
    errors.push(`expected ${seriesTargetCount} series receipts, found ${activeReceipts.length}`);
  }
  const receiptTargets = activeReceipts.map((name) => {
    const receipt = parse(`specs/intake-authoring-receipts/${name}`);
    const original = receipt.target?.path;
    if (typeof original !== "string" || fs.existsSync(resolve(original))) return original;
    const binding = receipt.series ?? {};
    const bound = binding.seriesId === manifest.seriesId && binding.manifestPath === manifestPath;
    const standalone = ["seriesId", "manifestPath", "order", "role"].every((key) => binding[key] === "N/A") &&
      Array.isArray(binding.supersedesIntakeIds) && binding.supersedesIntakeIds.length === 0;
    // Alte Receipts bleiben unveraendert; nur ein eindeutiger Name-/Hash-Nachfolger ist erlaubt.
    // Preserve old receipts; only a unique name/hash archive successor may resolve a missing target.
    if ((!bound && !standalone) || !original.startsWith(`${activeCollection}/`) ||
        original.includes("\\") || original.split("/").some((part) => !part || part === "." || part === "..")) return original;
    const oldName = path.basename(original);
    const oldStem = path.basename(original, path.extname(original));
    const matches = targets.filter((target) => target.status === "Completed" &&
      inCollection(target.path, archiveCollection) &&
      (path.basename(target.path) === oldName ||
        (path.basename(target.path).startsWith(`${oldStem}.`) && path.extname(target.path) === path.extname(original))) &&
      target.normalizedSha256 === receipt.target.normalizedSha256 &&
      digest(read(target.path)) === receipt.target.normalizedSha256);
    return matches.length === 1 ? matches[0].path : original;
  }).sort();
  if (JSON.stringify(receiptTargets) !== JSON.stringify([...targetPaths].sort())) {
    errors.push("active receipts and series targets differ");
  }

  return errors;
}

const isMain = process.argv[1] &&
  path.resolve(process.argv[1]) === path.resolve(fileURLToPath(import.meta.url));
if (isMain) {
  const errors = validate();
  if (errors.length > 0) {
    errors.forEach((error) => console.error(`ERROR: ${error}`));
    process.exit(2);
  }
  console.log("requirements/intake alignment PASS");
}
