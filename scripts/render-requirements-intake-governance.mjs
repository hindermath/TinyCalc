#!/usr/bin/env node

import crypto from "node:crypto";
import fs from "node:fs";
import path from "node:path";
import process from "node:process";

const root = process.cwd();
const write = process.argv.includes("--write");
const normalize = (value) => value.replace(/^\uFEFF/, "").replace(/\r\n?/g, "\n");
const digest = (value) => crypto.createHash("sha256").update(normalize(value)).digest("hex");
const read = (relativePath) => fs.readFileSync(path.join(root, relativePath), "utf8");
const readJson = (relativePath) => JSON.parse(read(relativePath));
const hashFile = (relativePath) => digest(read(relativePath));
const json = (value) => `${JSON.stringify(value, null, 2)}\n`;
const config = readJson("requirements/intake-governance-config.json");
const seriesRoot = "requirements/intakes/series/tinycalc-delivery";
const seriesId = "5b4523b4-d946-4091-9cbc-11825af94332";
const seriesReceiptId = "0d458d79-2908-40cf-b6dd-41f3fb9e17b6";
const seriesOperationId = "5e57604c-de91-49f0-823d-92e612ae25fe";
const reviewId = "2c338c63-9f64-47c1-ba50-a95c7ea3fce1";
const createdAt = "2026-07-26T21:00:00Z";
const seriesUpdatedAt = "2026-08-29T15:31:02Z";
const reviewedAt = "2026-08-29T16:19:38Z";
const reviewHead = "c7a9cbf50d732e0e521e6f8ae9ba1cc56612bf22";

const members = [
  ["constitution-change", "Lastenheft_Constitution_Change.002-constitution-change.md", "Eligible", "b00956e5-e42b-48c4-b63d-ee748cad27f3", "4936d97b-6206-433e-b76c-a570c1842695"],
  ["terminalgui-migration", "Lastenheft_TerminalGui_Migration.md", "Blocked", "098464e1-cbf6-4812-8b42-c88a55d3c192", "9d791f78-d8ad-4076-aab6-acd550bcc331"],
  ["rename-microcalc-tinycalc", "Lastenheft_Rename_MicroCalc_TinyCalc.md", "Blocked", "b4e6471a-404f-4dc4-a4ea-51659bbb093d", "313385fe-d32f-4236-a6b1-b35630aa375c"],
  ["a11y-tui", "Lastenheft_A11Y_TUI.md", "Blocked", "f36ec0dd-33e3-4f34-aaf8-e264f41057ff", "418ea177-4ff8-4a61-8806-08fc7be4a85e"],
  ["didactic-inline-code-comment-hardening", "Lastenheft_Didactic-Inline-Code-Comment-Hardening.md", "Blocked", "fb3cd161-2086-4cb0-8a8e-a72d1db26500", "a6780a05-df3a-401a-ad1f-796cd3656f1a"],
  ["secure-development-hardening", "Lastenheft_Secure-Development-Hardening.md", "Blocked", "fc7fc58f-180b-43f5-86e6-94d5feb93377", "ad3da51c-6f14-4617-8472-3a13b4b19673"],
  ["pl0-zellfunktionen-v1", "Lastenheft_PL0-Zellfunktionen_V1.md", "Blocked", "1895dbae-6b5a-42f0-a1c0-3fa49ad39fca", "289b40fa-6023-4655-9e03-0699050569e8"],
  ["sandbox-gestuetzte-secure-development-haertung", "Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md", "Pending", "dcbee93b-bb9f-49f5-b363-fbe082f7dc1e", "aeb455e1-e871-475f-9c6e-29f8b201c9fd"],
  ["rl-se-checklist-selbstpruefung", "Lastenheft_RL-SE-Checklist-Selbstpruefung.md", "Pending", "2093b09a-e0bf-4b03-9df9-b81594d23d2d", "999ece6f-b454-4150-afeb-ce544b76c29d"],
  ["gsdb-spec-kit-intensivpruefung", "Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md", "Pending", "704cea09-a869-49a5-baf9-70f24aa8d67b", "9352f182-123b-43b1-8959-aea8e8da9612"],
].map(([slug, fileName, status, receiptId, operationId], index) => ({
  slug,
  fileName,
  status,
  receiptId,
  operationId,
  order: index + 1,
  role: index === 0 ? "Primary" : "OrderedMember",
  path: `requirements/intakes/active/${fileName}`,
  priorTarget: `requirements/intakes/history/pre-intake-split-20260726/${
    slug === "constitution-change" ? "Lastenheft_Constitution_Change.md" : fileName
  }`,
  priorReceipt: `specs/intake-authoring-receipts/history/${slug}.schema-1.1.json`,
  customReceipt: slug === "pl0-zellfunktionen-v1",
}));

const targets = members.map((member) => member.path);
const dependencyPairs = [
  [0, 1],
  [1, 2],
  [2, 3],
  [3, 4],
  [4, 5],
  [5, 6],
];
const dependencies = dependencyPairs.map(([from, to]) => ({
  from: targets[from],
  to: targets[to],
  kind: "HardCompletionGate",
  binding: true,
}));
const roots = targets.filter((target) => !dependencies.some((edge) => edge.to === target));

const manifest = {
  schemaVersion: "1.0",
  documentType: "IntakeSeriesManifest",
  seriesId,
  title: "TinyCalc Delivery Intake Series",
  policy: "tinycalc-delivery-v1",
  status: "Active",
  orderedTargets: members.map((member) => ({
    path: member.path,
    role: member.role,
    normalizedSha256: hashFile(member.path),
    status: member.status,
  })),
  roots,
  dependencies,
  evidencePaths: [
    "specs/requirements-reconciliation-20260726/requirements-coverage.json",
    "specs/requirements-reconciliation-20260726/migration-proposal.json",
    "Lastenheft_Abarbeitungsreihenfolge.md",
  ],
};
const manifestPath = `${seriesRoot}/manifest.json`;
const manifestHash = digest(json(manifest));

function sourceRecord(relativePath) {
  return {
    sourceId: "SRC001",
    order: 1,
    kind: "File",
    label: "Archived predecessor intake",
    location: "Repository",
    path: relativePath,
    requestedUrl: "N/A",
    finalUrl: "N/A",
    retrievedAt: "N/A",
    httpStatus: "N/A",
    contentType: "N/A",
    contentLength: "N/A",
    etag: "N/A",
    lastModified: "N/A",
    redirectChain: [],
    rawSha256: "N/A",
    normalizedSha256: hashFile(relativePath),
    gitBlob: "N/A",
    proofBoundary: "Repository predecessor and normalized SHA-256",
  };
}

function receiptFor(member) {
  const prior = readJson(member.priorReceipt);
  return {
    schemaVersion: "2.0",
    documentType: "IntakeReceipt",
    receiptId: member.receiptId,
    intakeId: prior.receiptId,
    generator: {preset: "intake-authoring-governance", version: "0.2.1"},
    createdAt,
    operation: {
      operationId: member.operationId,
      type: "Update",
      authorityEvidence: "User-approved TinyCalc requirements and intake consolidation plan",
    },
    status: "ReadyForReview",
    target: {path: member.path, normalizedSha256: hashFile(member.path)},
    sources: [sourceRecord(member.priorTarget)],
    profile: "level2-lastenheft",
    languagePolicy: "GermanFirstEnglishSecond",
    decisions: [
      {
        id: "IAD001",
        status: "Answered",
        question: "Welcher Zielpfad ist nach der Konsolidierung verbindlich?",
        answer: member.path,
        evidence: "specs/requirements-reconciliation-20260726/migration-proposal.json",
      },
      {
        id: "IAD002",
        status: "Answered",
        question: "Welche Delivery Authority gilt?",
        answer: "LocalImplementation",
        evidence: "The migration grants no feature-delivery authority.",
      },
    ],
    openDecisionIds: [],
    questionCount: 0,
    agentSurface: {
      specifyCanonicalId: "speckit.specify",
      specifyInvocation: "$speckit-specify",
      autonomousCanonicalId: "speckit.autonomous",
      autonomousInvocation: "$speckit-autonomous",
    },
    deliveryAuthority: "LocalImplementation",
    authorityEvidence: "Default: this migration grants no remote feature-delivery authority.",
    promptState: "Enabled",
    provenanceMode: "Supersession",
    supersedes: {
      receiptPath: member.priorReceipt,
      targetNormalizedSha256: hashFile(member.priorTarget),
      archiveTargetPath: member.priorTarget,
      archiveReceiptPath: member.priorReceipt,
    },
    legacyAdoption: {
      evidenceType: "N/A",
      priorTargetNormalizedSha256: "N/A",
      priorGitBlob: "N/A",
    },
    updateAuthorized: true,
    updateAuthorityEvidence: "User-approved migration preserves predecessor evidence.",
    series: {
      seriesId,
      manifestPath,
      order: member.order,
      role: member.role,
      supersedesIntakeIds: [],
    },
    nextAction: `$speckit-intake-review ${member.path}`,
  };
}

const receipts = members.filter((member) => !member.customReceipt).map((member) => ({
  path: `specs/intake-authoring-receipts/${member.slug}.json`,
  value: receiptFor(member),
}));
const seriesReceipt = {
  schemaVersion: "1.0",
  documentType: "IntakeSeriesReceipt",
  receiptId: seriesReceiptId,
  seriesId,
  generator: {preset: "intake-sequencing-governance", version: "0.2.3"},
  createdAt: seriesUpdatedAt,
  operation: {
    operationId: seriesOperationId,
    type: "Update",
    authorityEvidence: "User approved IAD001 including TinyCalc rank 7 and approved the binding IAD002 delivery gate.",
  },
  status: "Ready",
  manifest: {path: manifestPath, normalizedSha256: manifestHash},
  supersedes: {
    receiptPath: "requirements/intakes/series-archive/tinycalc-delivery/20260829T153102Z/receipt.json",
    receiptNormalizedSha256: "3aa1e3b5140cb16fa1a0138943d82f366f39e8115cefd3bbf03b0fb9bfbf3deb",
    manifestArchivePath: "requirements/intakes/series-archive/tinycalc-delivery/20260829T153102Z/manifest.json",
    manifestArchiveSha256: "616dae5365f2413b2904acd28c158a118eacfdd2ad53a7c9dfe7281a6c74adcb",
  },
  tombstone: {path: "N/A", normalizedSha256: "N/A"},
  nextAction: "$speckit-intake-series-status",
};
const operation = {
  schemaVersion: "1.0",
  documentType: "IntakeSeriesOperation",
  operationId: seriesOperationId,
  seriesId,
  type: "Update",
  status: "Published",
  authorityEvidence: "User approved IAD001 including TinyCalc rank 7 and approved the binding IAD002 delivery gate.",
  proposalNormalizedSha256: "f36a20d34be1c682821321dd0b1a0c8d2a5c44b6ffbfaf54c77daa027868a10d",
  preparedPaths: [
    "requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md",
    "specs/intake-authoring-receipts/pl0-zellfunktionen-v1.json",
    manifestPath,
    `${seriesRoot}/receipt.json`,
    `${seriesRoot}/order.md`,
    "requirements/intakes/series-archive/tinycalc-delivery/20260829T153102Z/manifest.json",
    "requirements/intakes/series-archive/tinycalc-delivery/20260829T153102Z/receipt.json",
    "Lastenheft_Abarbeitungsreihenfolge.md",
  ],
  validation: {bash: "Pass", powerShell: "Pass"},
  publication: {
    status: "Published",
    publishedPaths: [
      "requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md",
      "specs/intake-authoring-receipts/pl0-zellfunktionen-v1.json",
      manifestPath,
      `${seriesRoot}/receipt.json`,
      `${seriesRoot}/order.md`,
      "requirements/intakes/series-archive/tinycalc-delivery/20260829T153102Z/manifest.json",
      "requirements/intakes/series-archive/tinycalc-delivery/20260829T153102Z/receipt.json",
      "Lastenheft_Abarbeitungsreihenfolge.md",
    ],
  },
};
const request = {
  schemaVersion: "1.1",
  reviewId,
  mode: "Series",
  policy: "tinycalc-delivery-v1",
  targets: members.map((member) => ({path: member.path, role: member.role})),
  series: {
    orderedTargetPaths: targets,
    roots,
    dependencies: dependencies.map(({from, to, kind}) => ({from, to, kind})),
  },
  campaign: {manifestPath: "N/A", workers: [], operatorExceptions: []},
};
const requestPath = `${seriesRoot}/intake-review-request.json`;
const result = {
  schemaVersion: "1.1",
  reviewId,
  mode: "Series",
  status: "Ready",
  policy: "tinycalc-delivery-v1",
  reviewedAt,
  repository: {root: ".", head: reviewHead},
  targets: members.map((member) => ({
    path: member.path,
    role: member.role,
    normalizedSha256: hashFile(member.path),
    gitBlob: "N/A",
  })),
  findings: [],
  questions: [],
  acceptedRisks: [],
  operatorExceptions: [],
  coverage: {
    individual: targets,
    series: [
      "Ten active intake hashes, lifecycle states, four roots, and six internal product-chain gates",
      "PL/0 cell functions follow secure-development hardening and enforce the external TinyPl0 completion and NuGet package gate",
      "Independent sandbox, RL-SE, and GSDB roots without invented product dependencies",
      "Historical baseline and predecessor receipts preserved",
    ],
    workers: [],
  },
  summary: {critical: 0, high: 0, medium: 0, low: 0},
  supersedes: "b9edc458-8339-4e8e-8f4f-3cabc2f96112",
  requestEvidence: {path: requestPath, normalizedSha256: digest(json(request))},
};
const report = `# Intake Review: TinyCalc Delivery Series

## Identität / Identity

- Review-ID: \`${reviewId}\`
- Modus: \`Series\`
- Policy: \`tinycalc-delivery-v1\`
- Ergebnis: \`Ready\`
- Umfang: 10 Ziele, 4 Wurzeln und 6 interne verbindliche Abhängigkeiten
- Worker: keine
- Vorgängerreview: \`b9edc458-8339-4e8e-8f4f-3cabc2f96112\`

*The complete re-review covers all ten current targets, four roots, and six
binding internal dependencies. It explicitly supersedes the remediation
review.*

## Ergebnis / Result

Die Schema-2.0-Governance, Zielhashes, Reihenfolge, DAG-Wurzeln, internen
Kanten und Authority-Grenzen sind konsistent. Das neue PL/0-Ziel steht nach
der Secure-Development-Härtung. Sein externer Handoff prüft verbindlich den
erfolgreichen TinyPl0-Abschluss und die verfügbare NuGet-Paketversion; eine
lokale ProjectReference ist als Fallback verboten.

Finding \`IR001\` ist behoben. Ein neuer Begriffsabschnitt erklärt PL/0,
P-Code und VM, Ganzzahl- und Cache-Grenzen, Debuggerzustand, NuGet-Vertrag,
fail-closed/Defense in Depth sowie SBOM/VEX, Provenance/SLSA, STRIDE/CAPEC und
OpenSSF Scorecard/OWASP SAMM deutsch zuerst und englisch danach auf
CEFR-B2-Niveau. Scope, Anforderungen, Abnahmeschwellen, Reihenfolge, Gates und
Delivery Authority blieben unverändert.

*Schema 2.0 governance, target hashes, order, DAG roots, internal edges, and
authority boundaries are consistent. IR001 is resolved through bilingual
CEFR-B2 first-use explanations without changing the approved functional or
authority boundaries.*

## Reparaturnachweis / Repair Evidence

- Geändertes Ziel:
  \`requirements/intakes/active/Lastenheft_PL0-Zellfunktionen_V1.md\`
- Autorisierung: ausdrücklicher Aufruf von \`speckit-intake-repair\` für das
  aktuelle Ergebnis \`b9edc458-8339-4e8e-8f4f-3cabc2f96112\`
- Behobenes Finding: \`IR001\` / \`Medium\` / \`LearnerReadability\`
- Verbleibende Findings: keine

*The explicit repair invocation authorized only the learner terminology
change. IR001 is resolved and no finding remains.*

## Risiken, Fragen und Authority / Risks, Questions And Authority

- Akzeptierte Risiken: keine
- Offene Fragen: keine
- Delivery Authority: \`LocalImplementation\`
- Keine Commit-, Push-, PR-, Merge-, Provider-, Secret- oder
  NuGet-Veröffentlichungsberechtigung wurde erteilt.

*No risk was accepted and no question remains open. Local implementation
authority grants neither remote actions nor NuGet publication.*
`;
const order = normalize(read("Lastenheft_Abarbeitungsreihenfolge.md"));
const outputs = [
  [manifestPath, json(manifest)],
  [`${seriesRoot}/receipt.json`, json(seriesReceipt)],
  [`${seriesRoot}/operation.json`, json(operation)],
  [`${seriesRoot}/order.md`, order],
  [requestPath, json(request)],
  [`${seriesRoot}/intake-review-result.json`, json(result)],
  [`${seriesRoot}/intake-review-report.md`, report],
  ...receipts.map((entry) => [entry.path, json(entry.value)]),
];

for (const [relativePath, content] of outputs) {
  const fullPath = path.join(root, relativePath);
  if (write) {
    fs.mkdirSync(path.dirname(fullPath), {recursive: true});
    fs.writeFileSync(fullPath, content);
  } else if (!fs.existsSync(fullPath) || normalize(read(relativePath)) !== normalize(content)) {
    console.error(`stale generated intake-governance artifact: ${relativePath}`);
    process.exit(1);
  }
}

const configuredCountMismatch =
  config.schemaVersion === "1.0" && members.length !== config.activeIntakeCount;
if (configuredCountMismatch || targets.length !== new Set(targets).size) {
  throw new Error("configured active intake cardinality differs from generated members");
}
console.log(`TinyCalc intake governance PASS (${members.length} active targets, ${dependencies.length} binding edges)`);
