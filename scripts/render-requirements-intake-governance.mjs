#!/usr/bin/env node

import crypto from "node:crypto";
import fs from "node:fs";
import path from "node:path";
import process from "node:process";
import {fileURLToPath} from "node:url";

class LinkedIntakeError extends Error {
  constructor(code, message) {
    super(`${code}: ${message}`);
    this.name = "LinkedIntakeError";
    this.code = code;
  }
}

const lieFail = (code, message) => {
  throw new LinkedIntakeError(code, message);
};
const lieNormalize = (value) => value.replace(/^\uFEFF/, "").replace(/\r\n?/g, "\n");
const lieDigest = (value) =>
  crypto.createHash("sha256").update(lieNormalize(value)).digest("hex");
const lieStrictDecoder = new TextDecoder("utf-8", {fatal: true});

function lieReadText(absolutePath, subject) {
  let text;
  try {
    text = lieStrictDecoder.decode(fs.readFileSync(absolutePath));
  } catch {
    lieFail("LIE001", `input is not valid UTF-8: ${subject}`);
  }
  if (text.includes("\0")) lieFail("LIE001", `input contains NUL: ${subject}`);
  return lieNormalize(text);
}

function lieReadJson(absolutePath, subject) {
  try {
    return JSON.parse(lieReadText(absolutePath, subject));
  } catch (error) {
    if (error instanceof LinkedIntakeError) throw error;
    lieFail("LIE002", `JSON is invalid or incomplete: ${subject}`);
  }
}

function lieSafeRelative(relativePath, code = "LIE003") {
  if (typeof relativePath !== "string" || relativePath.length === 0 ||
      /[\u0000-\u001f\u007f]/u.test(relativePath) ||
      relativePath.includes("\\") || relativePath.startsWith("/") ||
      /^\/?[A-Za-z]:\//.test(relativePath) || relativePath.startsWith("//")) {
    lieFail(code, "path is not safely repository-relative");
  }
  const parts = relativePath.split("/");
  if (parts.some((part) => part === "" || part === "." || part === ".." ||
      part.startsWith("-"))) {
    lieFail(code, "path is not safely repository-relative");
  }
  const normalized = path.posix.normalize(relativePath);
  if (normalized !== relativePath) lieFail(code, "path normalization changed the input");
  return normalized;
}

function lieInsideRoot(rootPath, candidatePath, code) {
  const relative = path.relative(rootPath, candidatePath);
  if (relative === "" || (!relative.startsWith(`..${path.sep}`) && relative !== ".." &&
      !path.isAbsolute(relative))) {
    return;
  }
  lieFail(code, "resolved path leaves the repository");
}

function lieResolveExisting(rootPath, relativePath) {
  const safe = lieSafeRelative(relativePath);
  const absolute = path.join(rootPath, ...safe.split("/"));
  if (!fs.existsSync(absolute) || !fs.statSync(absolute).isFile()) {
    lieFail("LIE004", `target is missing or is not a regular file: ${safe}`);
  }
  let resolved;
  try {
    resolved = fs.realpathSync(absolute);
  } catch {
    lieFail("LIE004", `target cannot be resolved: ${safe}`);
  }
  lieInsideRoot(rootPath, resolved, "LIE005");
  return {safe, absolute, resolved};
}

function lieResolveOutput(rootPath, relativePath) {
  const safe = lieSafeRelative(relativePath);
  const absolute = path.join(rootPath, ...safe.split("/"));
  if (fs.existsSync(absolute)) {
    const entry = fs.lstatSync(absolute);
    if (entry.isSymbolicLink() || !entry.isFile()) {
      lieFail("LIE005", `output is a symlink or not a regular file: ${safe}`);
    }
    lieInsideRoot(rootPath, fs.realpathSync(absolute), "LIE005");
  }
  let ancestor = path.dirname(absolute);
  while (!fs.existsSync(ancestor) && ancestor !== path.dirname(ancestor)) {
    ancestor = path.dirname(ancestor);
  }
  lieInsideRoot(rootPath, fs.realpathSync(ancestor), "LIE005");
  return {safe, absolute};
}

function lieEscapeLabel(value) {
  if (/[\u0000-\u001f\u007f]/u.test(value)) {
    lieFail("LIE002", "display value contains control characters");
  }
  return value
    .replaceAll("\\", "\\\\")
    .replaceAll("|", "\\|")
    .replaceAll("[", "\\[")
    .replaceAll("]", "\\]");
}

function lieEncodeDestination(value, directory = false) {
  const encoded = value.split("/").map((part) =>
    part === "." || part === ".." ? part : encodeURIComponent(part)).join("/");
  return directory && !encoded.endsWith("/") ? `${encoded}/` : encoded;
}

function lieRelativeDestination(outputPath, targetPath, directory = false) {
  const outputDirectory = path.posix.dirname(outputPath);
  const relative = path.posix.relative(outputDirectory, targetPath) || ".";
  return lieEncodeDestination(relative, directory);
}

function lieValidateManifest(rootPath, manifestPath, manifestOverride) {
  const manifestRecord = lieResolveExisting(rootPath, manifestPath);
  const manifest = manifestOverride === undefined
    ? lieReadJson(manifestRecord.absolute, manifestRecord.safe)
    : manifestOverride;
  if (!manifest || typeof manifest !== "object" || Array.isArray(manifest) ||
      manifest.schemaVersion !== "1.0" || !Array.isArray(manifest.orderedTargets) ||
      !Array.isArray(manifest.dependencies) || !Array.isArray(manifest.roots)) {
    lieFail("LIE002", "series manifest is unsupported or incomplete");
  }

  const positions = new Set();
  const targets = manifest.orderedTargets.map((target, index) => {
    if (!target || typeof target !== "object" || typeof target.path !== "string" ||
        typeof target.role !== "string" || typeof target.status !== "string" ||
        typeof target.normalizedSha256 !== "string" ||
        !/^[0-9a-f]{64}$/.test(target.normalizedSha256)) {
      lieFail("LIE002", "target fields must use the documented string types");
    }
    const targetRecord = lieResolveExisting(rootPath, target.path);
    const content = lieReadText(targetRecord.absolute, targetRecord.safe);
    if (lieDigest(content) !== target.normalizedSha256) {
      lieFail("LIE009", `target hash differs from the manifest: ${targetRecord.safe}`);
    }
    const displayPosition = target.displayPosition ?? index + 1;
    if (!Number.isInteger(displayPosition) || displayPosition < 1) {
      lieFail("LIE002", "visible position must be a positive integer");
    }
    if (positions.has(displayPosition)) lieFail("LIE006", "visible position is duplicated");
    positions.add(displayPosition);
    return {...target, path: targetRecord.safe, displayPosition};
  });

  const paths = targets.map((target) => target.path);
  if (new Set(paths).size !== paths.length) lieFail("LIE006", "intake identity is duplicated");
  const targetByPath = new Map(targets.map((target) => [target.path, target]));
  const indegree = new Map(paths.map((targetPath) => [targetPath, 0]));
  const adjacency = new Map(paths.map((targetPath) => [targetPath, []]));
  const allowedBindings = new Map([
    ["HardCompletionGate", true],
    ["CommentSurfaceBaseline", true],
    ["DocumentationSurfaceBaseline", true],
    ["PreferredSerialOrder", false],
  ]);
  for (const edge of manifest.dependencies) {
    if (!edge || typeof edge !== "object" || typeof edge.from !== "string" ||
        typeof edge.to !== "string" || typeof edge.kind !== "string" ||
        typeof edge.binding !== "boolean" || !targetByPath.has(edge.from) ||
        !targetByPath.has(edge.to) || edge.from === edge.to ||
        allowedBindings.get(edge.kind) !== edge.binding ||
        targetByPath.get(edge.from).displayPosition >= targetByPath.get(edge.to).displayPosition) {
      lieFail("LIE007", "dependency edge contains an unknown endpoint or invalid values");
    }
    indegree.set(edge.to, indegree.get(edge.to) + 1);
    adjacency.get(edge.from).push(edge.to);
  }
  const calculatedRoots = [...indegree]
    .filter(([, value]) => value === 0)
    .map(([targetPath]) => targetPath)
    .sort();
  if (manifest.roots.some((rootEntry) => typeof rootEntry !== "string") ||
      JSON.stringify([...manifest.roots].sort()) !== JSON.stringify(calculatedRoots)) {
    lieFail("LIE007", "manifest roots differ from the dependency graph");
  }
  const remaining = new Map(indegree);
  const queue = calculatedRoots.slice();
  let visited = 0;
  while (queue.length > 0) {
    const current = queue.shift();
    visited++;
    for (const successor of adjacency.get(current)) {
      remaining.set(successor, remaining.get(successor) - 1);
      if (remaining.get(successor) === 0) queue.push(successor);
    }
  }
  if (visited !== targets.length) lieFail("LIE007", "series dependencies contain a cycle");
  return {manifest, manifestPath: manifestRecord.safe, targets, targetByPath};
}

function lieFeatureProofs(rootPath, target) {
  const acceptedPaths = new Set([target.path]);
  if (target.archivedFrom !== undefined) {
    // Ein Archivumzug darf die historische Feature-Bindung nur bei gleichem Inhalt erhalten.
    // Archive relocation may preserve a historical feature binding only for identical content.
    const prior = target.archivedFrom;
    const configRecord = lieResolveExisting(rootPath, "requirements/intake-governance-config.json");
    const config = lieReadJson(configRecord.absolute, configRecord.safe);
    if (!prior || target.status !== "Completed" ||
        !target.path.startsWith(`${config.collections?.archive}/`) ||
        typeof prior.path !== "string" || !prior.path.startsWith(`${config.collections?.active}/`)) {
      lieFail("LIE008", "archive feature lineage has invalid lifecycle or collection");
    }
    lieSafeRelative(prior.path, "LIE008");
    lieInsideRoot(fs.realpathSync(path.join(rootPath, config.collections.archive)),
      fs.realpathSync(path.join(rootPath, target.path)), "LIE008");
    const predecessor = lieResolveExisting(rootPath, prior.manifestPath);
    const text = lieReadText(predecessor.absolute, predecessor.safe);
    if (lieDigest(text) !== prior.manifestNormalizedSha256) {
      lieFail("LIE008", "archive feature lineage manifest hash differs");
    }
    const old = lieReadJson(predecessor.absolute, predecessor.safe);
    const currentRecord = lieResolveExisting(rootPath, config.collections.seriesManifest);
    const current = lieReadJson(currentRecord.absolute, currentRecord.safe);
    const matches = (old.orderedTargets ?? []).filter((entry) => entry.path === prior.path &&
      entry.status === "Completed" && entry.normalizedSha256 === target.normalizedSha256);
    if (old.seriesId !== current.seriesId || matches.length !== 1 ||
        path.posix.basename(prior.path) !== path.posix.basename(target.path)) {
      lieFail("LIE008", "archive feature lineage is ambiguous or content differs");
    }
    acceptedPaths.add(prior.path);
  }
  const specsPath = path.join(rootPath, "specs");
  if (!fs.existsSync(specsPath)) return [];
  const proofs = new Set();
  for (const directory of fs.readdirSync(specsPath, {withFileTypes: true})
    .filter((entry) => entry.isDirectory())
    .sort((left, right) => left.name.localeCompare(right.name, "en"))) {
    const expectedFeature = `specs/${directory.name}`;
    const stateRelative = `specs/${directory.name}/autonomous-run-state.json`;
    const stateAbsolute = path.join(rootPath, ...stateRelative.split("/"));
    if (fs.existsSync(stateAbsolute)) {
      const stateRecord = lieResolveExisting(rootPath, stateRelative);
      const state = lieReadJson(stateRecord.absolute, stateRecord.safe);
      if (!state || typeof state !== "object" || Array.isArray(state)) {
        lieFail("LIE008", `feature evidence is invalid: ${stateRelative}`);
      }
      const accepted = Array.isArray(state.acceptedArtifacts)
        ? state.acceptedArtifacts.filter((artifact) => acceptedPaths.has(artifact?.path))
        : [];
      if (accepted.length > 0) {
        const closeout = state.closeout ?? {};
        const featurePath = state.featurePath;
        if (accepted.length !== 1 || accepted[0].sha256 !== target.normalizedSha256 ||
            state.status !== "Completed" || typeof featurePath !== "string" ||
            !["mergeOrPublication", "defaultBranchSync", "postMergeActions", "finalValidation"]
              .every((field) => closeout[field] === "Completed")) {
          lieFail("LIE008", `feature evidence is invalid for ${target.path}`);
        }
        const safeFeature = lieSafeRelative(featurePath, "LIE008");
        if (safeFeature !== expectedFeature) {
          lieFail("LIE008", `feature path differs from its state location: ${stateRelative}`);
        }
        proofs.add(safeFeature);
      }
    }

    const portableRelative = `${expectedFeature}/evidence/postmerge.json`;
    const portableAbsolute = path.join(rootPath, ...portableRelative.split("/"));
    if (!fs.existsSync(portableAbsolute)) continue;
    const bindingPaths = [
      `${expectedFeature}/tasks.md`,
      `${expectedFeature}/plan.md`,
      `${expectedFeature}/autonomous-run-evidence.md`,
      `${expectedFeature}/evidence/delivery.md`,
    ];
    const explicitlyBound = bindingPaths.some((bindingPath) => {
      const bindingAbsolute = path.join(rootPath, ...bindingPath.split("/"));
      if (!fs.existsSync(bindingAbsolute)) return false;
      const bindingRecord = lieResolveExisting(rootPath, bindingPath);
      const text = lieReadText(bindingRecord.absolute, bindingRecord.safe);
      return [...acceptedPaths].some((acceptedPath) => text.includes(acceptedPath));
    });
    if (!explicitlyBound) continue;

    const portableRecord = lieResolveExisting(rootPath, portableRelative);
    const portable = lieReadJson(portableRecord.absolute, portableRecord.safe);
    const acceptedPath = portable?.acceptedPreMergePath;
    if (!portable || typeof portable !== "object" || Array.isArray(portable) ||
        portable.snapshotType !== "PostMerge" ||
        !/^[0-9a-f]{40}$/.test(portable.reviewedHead ?? "") ||
        !/^[0-9a-f]{40}$/.test(portable.mergeCommit ?? "") ||
        typeof acceptedPath !== "string" ||
        !/^[0-9a-f]{64}$/.test(portable.acceptedPreMergeSha256 ?? "") ||
        !Array.isArray(portable.entries) || portable.entries.length === 0 ||
        portable.entries.some((entry) => !entry || entry.headSha !== portable.reviewedHead ||
          !["Pass", "N/A"].includes(entry.result))) {
      lieFail("LIE008", `portable feature evidence is invalid for ${target.path}`);
    }
    const acceptedRecord = lieResolveExisting(rootPath, acceptedPath);
    const acceptedContent = lieReadText(acceptedRecord.absolute, acceptedRecord.safe);
    if (lieDigest(acceptedContent) !== portable.acceptedPreMergeSha256 ||
        !portable.entries.some((entry) =>
          typeof entry.evidenceReference === "string" &&
          entry.evidenceReference.includes(`:${expectedFeature}/`))) {
      lieFail("LIE008", `portable feature evidence binding is invalid for ${target.path}`);
    }
    proofs.add(expectedFeature);
  }
  for (const safeFeature of proofs) {
    const featureAbsolute = path.join(rootPath, ...safeFeature.split("/"));
    if (!fs.existsSync(featureAbsolute) || !fs.statSync(featureAbsolute).isDirectory()) {
      lieFail("LIE008", `feature target is missing for ${target.path}`);
    }
    lieInsideRoot(rootPath, fs.realpathSync(featureAbsolute), "LIE008");
  }
  if (proofs.size > 1) lieFail("LIE008", `feature evidence is ambiguous for ${target.path}`);
  return [...proofs];
}

function lieTable(rootPath, manifestData, outputPath) {
  const lines = [
    "| Position | Status | Lastenheft/Intake | Abhängigkeiten / Dependencies | Spec-Kit-Feature |",
    "|---:|---|---|---|---|",
  ];
  for (const target of manifestData.targets) {
    const intakeLabel = lieEscapeLabel(path.posix.basename(target.path));
    const intakeDestination = lieRelativeDestination(outputPath, target.path);
    const incoming = manifestData.manifest.dependencies.filter((edge) => edge.to === target.path);
    const dependencyCell = incoming.length === 0
      ? "— (Root / keine direkte Abhängigkeit)"
      : incoming.map((edge) => {
        const label = lieEscapeLabel(path.posix.basename(edge.from));
        const destination = lieRelativeDestination(outputPath, edge.from);
        return `[${label}](${destination}) → current (\`${edge.kind}\`, binding: ${edge.binding})`;
      }).join("<br>");
    const proofs = lieFeatureProofs(rootPath, target);
    const featureCell = proofs.length === 0
      ? "— (kein Spec-Kit-Feature / no Spec Kit feature)"
      : `[${lieEscapeLabel(path.posix.basename(proofs[0]))}](${lieRelativeDestination(
        outputPath,
        proofs[0],
        true,
      )})`;
    lines.push(
      `| ${target.displayPosition} | ${lieEscapeLabel(target.status)} | [${intakeLabel}](${intakeDestination}) | ${dependencyCell} | ${featureCell} |`,
    );
  }
  return `${lines.join("\n")}\n`;
}

function lieSemanticRows(view) {
  const rows = lieNormalize(view.content).split("\n")
    .filter((line) => line.startsWith("|") && line.endsWith("|"))
    .slice(2);
  return rows.map((line) => {
    const cells = line.slice(2, -2).split(" | ");
    if (cells.length !== 5) lieFail("LIE011", "linked view does not contain exactly five fields");
    return cells.map((cell) => cell.replace(/\[([^\]]+)\]\(([^)]+)\)/g, (_match, label, destination) => {
      let decoded;
      try {
        decoded = destination.split("/").map((part) => decodeURIComponent(part)).join("/");
      } catch {
        lieFail("LIE011", "linked view contains an invalid escaped destination");
      }
      const resolved = path.posix.normalize(
        path.posix.join(path.posix.dirname(view.outputPath), decoded),
      );
      return `[${label}](${resolved})`;
    }));
  });
}

export function assertLinkedIntakeViewParity(views) {
  if (!Array.isArray(views) || views.length < 2) {
    lieFail("LIE011", "at least two linked views are required for parity");
  }
  const reference = JSON.stringify(lieSemanticRows(views[0]));
  if (views.slice(1).some((view) => JSON.stringify(lieSemanticRows(view)) !== reference)) {
    lieFail("LIE011", "root and series views do not agree semantically");
  }
  return true;
}

function lieRestoreOutputs(backups) {
  for (const backup of backups) {
    if (backup.existed) {
      fs.mkdirSync(path.dirname(backup.absolute), {recursive: true});
      fs.writeFileSync(backup.absolute, backup.content);
    } else {
      fs.rmSync(backup.absolute, {force: true});
    }
  }
}

function liePrepareLinkedIntakeViews(options = {}) {
  const rootPath = fs.realpathSync(path.resolve(options.root ?? process.cwd()));
  const manifestPath = lieSafeRelative(options.manifestPath);
  const outputPaths = options.outputPaths;
  if (!Array.isArray(outputPaths) || outputPaths.length !== 2) {
    lieFail("LIE002", "exactly two linked intake outputs are required");
  }
  const manifestData = lieValidateManifest(rootPath, manifestPath, options.manifest);
  const outputs = outputPaths.map((outputPath) => lieResolveOutput(rootPath, outputPath));
  if (new Set(outputs.map((output) => output.safe)).size !== outputs.length ||
      outputs.some((output) => output.safe === manifestData.manifestPath ||
        manifestData.targetByPath.has(output.safe))) {
    lieFail("LIE006", "output overlaps a canonical input or another output");
  }
  const tables = outputs.map((output) => ({
    ...output,
    content: lieTable(rootPath, manifestData, output.safe),
  }));
  assertLinkedIntakeViewParity(tables.map(({safe, content}) => ({
    outputPath: safe,
    content,
  })));
  const generationSha256 = lieDigest(JSON.stringify(lieSemanticRows({
    outputPath: tables[0].safe,
    content: tables[0].content,
  })));
  const views = tables.map((output) => {
    const content = typeof options.decorateOutput === "function"
      ? options.decorateOutput({
        outputPath: output.safe,
        manifestPath: manifestData.manifestPath,
        table: output.content,
        generationSha256,
      })
      : output.content;
    if (typeof content !== "string" || content.includes("\0") ||
        /[ \t]+$/m.test(content) || content.includes(rootPath)) {
      lieFail("LIE002", "generated output violates the text contract");
    }
    return {...output, content: lieNormalize(content)};
  });
  assertLinkedIntakeViewParity(views.map(({safe, content}) => ({
    outputPath: safe,
    content,
  })));
  return {rootPath, views, generationSha256};
}

function liePublishOutputs(rootPath, views, options = {}) {
  if (new Set(views.map((view) => view.safe)).size !== views.length) {
    lieFail("LIE006", "publication contains duplicate outputs");
  }

  const changed = views.filter((view) =>
    !fs.existsSync(view.absolute) ||
    lieReadText(view.absolute, view.safe) !== view.content);
  if (!options.write) {
    if (changed.length > 0) {
      lieFail("LIE009", `generated output is stale: ${changed[0].safe}`);
    }
    return {status: "Current", writes: 0, outputs: views.map((view) => view.safe)};
  }
  if (changed.length === 0) {
    return {status: "Current", writes: 0, outputs: views.map((view) => view.safe)};
  }

  const backups = changed.map((view) => ({
    absolute: view.absolute,
    existed: fs.existsSync(view.absolute),
    content: fs.existsSync(view.absolute) ? fs.readFileSync(view.absolute) : Buffer.alloc(0),
  }));
  const temporary = [];
  try {
    for (const view of changed) {
      fs.mkdirSync(path.dirname(view.absolute), {recursive: true});
      const temporaryPath = `${view.absolute}.tmp-${process.pid}-${temporary.length}`;
      fs.writeFileSync(temporaryPath, view.content, {encoding: "utf8", flag: "wx"});
      temporary.push({temporaryPath, view});
    }
    if (typeof options.beforeCommit === "function") options.beforeCommit();
    for (const item of temporary) fs.renameSync(item.temporaryPath, item.view.absolute);
    for (const view of changed) {
      if (lieReadText(view.absolute, view.safe) !== view.content) {
        throw new Error("post-write verification failed");
      }
    }
  } catch {
    for (const item of temporary) fs.rmSync(item.temporaryPath, {force: true});
    lieRestoreOutputs(backups);
    lieFail("LIE010", "publication failed; the previous outputs were restored");
  }
  return {
    status: "Updated",
    writes: changed.length,
    outputs: views.map((view) => view.safe),
  };
}

export function renderLinkedIntakeViews(options = {}) {
  const prepared = liePrepareLinkedIntakeViews(options);
  return liePublishOutputs(prepared.rootPath, prepared.views, options);
}

function tinyCalcOrderDocument({outputPath, manifestPath, table, generationSha256}) {
  const manifestDestination = lieRelativeDestination(outputPath, manifestPath);
  return `# TinyCalc Intake-Reihenfolge / Intake Order

<!-- linked-intake-generation: ${generationSha256} -->

Diese Ansicht wird aus der kanonischen Intake-Serie abgeleitet. Verbindliche
Maschinendaten stehen im [Serienmanifest](${manifestDestination}).

*This view is derived from the canonical intake series. The linked series
manifest contains the binding machine-readable data.*

${table}
Nur \`Eligible\` bezeichnet die bevorzugte nächste Ausführung. \`Pending\` oder
\`Blocked\` erteilen keine automatische Ausführungsberechtigung.

*Only \`Eligible\` identifies the preferred next execution. \`Pending\` and
\`Blocked\` grant no automatic execution authority.*
`;
}

function runCli() {
const root = process.cwd();
const write = process.argv.includes("--write");
if (process.argv.includes("--help") || process.argv.includes("-h")) {
  console.log(`Verwendung / Usage: node scripts/render-requirements-intake-governance.mjs [--write]

Ohne Option werden beide abgeleiteten Reihenfolgeansichten schreibgeschützt
geprüft. Manifest, Receipts und Reviews bleiben unverändert. --write
veröffentlicht eine vorab validierte Generation; erkannte
Fehler werden zurückgerollt und ein gemeinsamer Marker bindet beide Ansichten.

Without an option, both derived order views are checked without writes.
Manifest, receipts and reviews remain unchanged. --write publishes one prevalidated generation, rolls back
detected failures, and binds both views with a shared marker.`);
  process.exit(0);
}
// Das Manifest ist die kanonische Quelle; Rendering darf keine Receipts oder Lifecycle-Werte erneuern.
// The manifest is canonical; rendering must never recreate receipts or lifecycle values.
const config = lieReadJson(path.join(root, "requirements/intake-governance-config.json"), "intake configuration");
const manifestPath = config.collections?.seriesManifest ?? config.seriesManifest;
renderLinkedIntakeViews({root, manifestPath, write,
  outputPaths: ["Lastenheft_Abarbeitungsreihenfolge.md", "requirements/intakes/series/tinycalc-delivery/order.md"],
  decorateOutput: tinyCalcOrderDocument,
});
console.log("TinyCalc linked intake views PASS; canonical artifacts preserved");
}
const invokedAsCli = Boolean(process.argv[1]) &&
  path.resolve(process.argv[1]) === fileURLToPath(import.meta.url);
if (invokedAsCli) runCli();
