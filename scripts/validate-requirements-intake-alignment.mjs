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
  const config = parse("requirements/intake-governance-config.json");
  const manifestPath = options.manifestPath ??
    config.collections?.seriesManifest ?? config.seriesManifest;
  const coveragePath = options.coveragePath ??
    "specs/requirements-reconciliation-20260726/requirements-coverage.json";
  const errors = [];
  const manifest = parse(manifestPath);
  const coverage = parse(coveragePath);
  const expectedActiveCount = config.schemaVersion === "1.0"
    ? config.activeIntakeCount
    : (manifest.orderedTargets ?? []).length;
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
  if (requirementIds.length !== expectedActiveCount ||
      new Set(requirementIds).size !== requirementIds.length) {
    errors.push(`coverage must contain exactly ${expectedActiveCount} unique requirement IDs`);
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
  if (archived.length !== expectedArchiveCount) {
    errors.push(`expected ${expectedArchiveCount} archived intakes, found ${archived.length}`);
  }
  if (rootLastenhefte.join(",") !== "Lastenheft_Abarbeitungsreihenfolge.md") {
    errors.push("only the generated processing-order view may remain as root Lastenheft");
  }

  const targets = manifest.orderedTargets ?? [];
  const targetPaths = targets.map((target) => target.path);
  if (targetPaths.length !== expectedActiveCount ||
      new Set(targetPaths).size !== targetPaths.length) {
    errors.push(`series must contain exactly ${expectedActiveCount} unique active targets`);
  }
  const expectedActive = active.map((name) => `${activeCollection}/${name}`).sort();
  if (JSON.stringify([...targetPaths].sort()) !== JSON.stringify(expectedActive)) {
    errors.push("active intake directory and series targets differ");
  }
  if (targetPaths.some((target) => target.includes("/archive/") || target.includes("/backlog/"))) {
    errors.push("archive or backlog target appears in executable series");
  }
  for (const target of targets) {
    if (!target.path || !fs.existsSync(resolve(target.path))) {
      errors.push(`series target is missing: ${target.path ?? "N/A"}`);
    } else if (digest(read(target.path)) !== target.normalizedSha256) {
      errors.push(`series target hash drift: ${target.path}`);
    }
  }

  const eligible = targets.filter((target) => target.status === "Eligible");
  // Schema 2 führt den Lifecycle im kanonischen Manifest; nur Schema 1 besitzt noch einen separaten bevorzugten Pfad.
  // Schema 2 keeps lifecycle state in the canonical manifest; only schema 1 still has a separate preferred path.
  if (eligible.length !== 1 || (preferredNext && eligible[0].path !== preferredNext)) {
    errors.push("configured preferred intake must be the single explicitly Eligible target");
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
  if (activeReceipts.length !== expectedActiveCount) {
    errors.push(`expected ${expectedActiveCount} active receipts, found ${activeReceipts.length}`);
  }
  const receiptTargets = activeReceipts.map((name) =>
    parse(`specs/intake-authoring-receipts/${name}`).target?.path).sort();
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
