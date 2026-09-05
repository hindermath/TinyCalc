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
const seriesReceiptId = "81b13f03-e73b-4ebf-a8fe-88aa0795ca8d";
const seriesOperationId = "e8b26612-01d1-4dfb-94b3-f9f9b5231ec3";
const reviewId = "c00e3d93-58fe-4d36-b1a4-94090cca1137";
const createdAt = "2026-07-26T21:00:00Z";
const seriesUpdatedAt = "2026-09-05T18:58:08Z";
const reviewedAt = "2026-09-01T07:48:26Z";
const reviewHead = "4f1b612f54690e49ba3cb02269d469ec2b309f2c";
const seriesArchiveRoot = "requirements/intakes/series-archive/tinycalc-delivery/20260905T185700Z";
const reviewArchiveRoot = "requirements/intakes/series-archive/tinycalc-delivery/20260905T185700Z-review";
const seriesAuthorityEvidence = "Thorsten explicitly approved the Feature 004 plan and DeliveryMode MergeAndSync with formal-only Admin-Bypass. The causal closeout is limited to the branch-qualified RL-SE Lastenheft rename, one tinycalc-delivery series update, lifecycle evidence, and one evidence-only closeout pull request. GSDB is made eligible but is not started.";

// Der optionale Vorgängername hält die historische Quelle stabil, wenn der aktive Intake nach der Lieferung branchgestempelt wird.
// The optional predecessor name keeps the historical source stable when delivery adds the branch stamp to the active intake.
const members = [
  ["constitution-change", "Lastenheft_Constitution_Change.002-constitution-change.md", "Completed", "b00956e5-e42b-48c4-b63d-ee748cad27f3", "4936d97b-6206-433e-b76c-a570c1842695"],
  ["terminalgui-migration", "Lastenheft_TerminalGui_Migration.003-terminalgui-migration.md", "Completed", "098464e1-cbf6-4812-8b42-c88a55d3c192", "9d791f78-d8ad-4076-aab6-acd550bcc331", "Lastenheft_TerminalGui_Migration.md"],
  ["tui-funktionsabnahme-und-regressionsvertrag", "Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md", "Pending", "fa3e818c-350d-497c-8216-31230ae57c67", "d4d23f7a-37a6-435c-be84-e6397fa37c48"],
  ["a11y-tui", "Lastenheft_A11Y_TUI.md", "Blocked", "d8b0496b-b2f4-4c34-bece-bd08bc420604", "e7b56721-0a8a-4a3c-870d-7dbe36039a04"],
  ["rename-microcalc-tinycalc", "Lastenheft_Rename_MicroCalc_TinyCalc.md", "Blocked", "cbb11a6e-0b5c-4b47-a49c-37648ba16cb6", "85e5cd04-bf99-47b1-bad9-04a6469873dc"],
  ["didactic-inline-code-comment-hardening", "Lastenheft_Didactic-Inline-Code-Comment-Hardening.md", "Blocked", "fb3cd161-2086-4cb0-8a8e-a72d1db26500", "a6780a05-df3a-401a-ad1f-796cd3656f1a"],
  ["secure-development-hardening", "Lastenheft_Secure-Development-Hardening.md", "Blocked", "fc7fc58f-180b-43f5-86e6-94d5feb93377", "ad3da51c-6f14-4617-8472-3a13b4b19673"],
  ["pl0-zellfunktionen-v1", "Lastenheft_PL0-Zellfunktionen_V1.md", "Blocked", "e89021a2-d681-42b5-916c-d604fef2a369", "2b606397-f1d6-4d89-90dd-5e7a69f4b050"],
  ["legacy-kompatibilitaet-v1", "Lastenheft_Legacy-Kompatibilitaet_V1.md", "Blocked", "dc355aa6-c523-414c-a472-542967ba62ed", "97c7ee77-1286-4642-92fc-c64982ac18a5"],
  ["formelkopie-und-tabellenoperationen-v1", "Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md", "Blocked", "8d8ca7c4-b610-4aab-9f6c-b9a738961a87", "32428ec7-e89a-4ceb-aa70-8749e49f6595"],
  ["sandbox-gestuetzte-secure-development-haertung", "Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md", "Pending", "dcbee93b-bb9f-49f5-b363-fbe082f7dc1e", "aeb455e1-e871-475f-9c6e-29f8b201c9fd"],
  ["rl-se-checklist-selbstpruefung", "Lastenheft_RL-SE-Checklist-Selbstpruefung.004-rl-se-self-assessment.md", "Completed", "2093b09a-e0bf-4b03-9df9-b81594d23d2d", "999ece6f-b454-4150-afeb-ce544b76c29d", "Lastenheft_RL-SE-Checklist-Selbstpruefung.md"],
  ["gsdb-spec-kit-intensivpruefung", "Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md", "Eligible", "704cea09-a869-49a5-baf9-70f24aa8d67b", "9352f182-123b-43b1-8959-aea8e8da9612"],
].map(([slug, fileName, status, receiptId, operationId, priorFileName], index) => ({
  slug,
  fileName,
  status,
  receiptId,
  operationId,
  order: index + 1,
  role: index === 0 ? "Primary" : "OrderedMember",
  path: `requirements/intakes/active/${fileName}`,
  priorTarget: `requirements/intakes/history/pre-intake-split-20260726/${
    slug === "constitution-change" ? "Lastenheft_Constitution_Change.md" : (priorFileName ?? fileName)
  }`,
  priorReceipt: `specs/intake-authoring-receipts/history/${slug}.schema-1.1.json`,
  customReceipt: new Set([
    "tui-funktionsabnahme-und-regressionsvertrag",
    "a11y-tui",
    "rename-microcalc-tinycalc",
    "pl0-zellfunktionen-v1",
    "legacy-kompatibilitaet-v1",
    "formelkopie-und-tabellenoperationen-v1",
  ]).has(slug),
}));

const targets = members.map((member) => member.path);
const dependencyPairs = [
  [0, 1],
  [1, 2],
  [2, 3],
  [3, 4],
  [4, 5],
  [5, 6],
  [6, 7],
  [7, 8],
  [8, 9],
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
    authorityEvidence: seriesAuthorityEvidence,
  },
  status: "Ready",
  manifest: {path: manifestPath, normalizedSha256: manifestHash},
  supersedes: {
    receiptPath: `${seriesArchiveRoot}/receipt.json`,
    receiptNormalizedSha256: "d19e2b4835d47afa6f9e1235da07e7a8f609b31370f80152a400777ed160f98c",
    manifestArchivePath: `${seriesArchiveRoot}/manifest.json`,
    manifestArchiveSha256: "b665aeae32117eaaf66a4dd1577631023d0e5cdc37d76e131f842e9a369b6136",
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
  authorityEvidence: seriesAuthorityEvidence,
  proposalNormalizedSha256: manifestHash,
  preparedPaths: [
    manifestPath,
    `${seriesRoot}/receipt.json`,
    `${seriesRoot}/operation.json`,
    `${seriesRoot}/order.md`,
    "Lastenheft_Abarbeitungsreihenfolge.md",
    `${seriesArchiveRoot}/manifest.json`,
    `${seriesArchiveRoot}/receipt.json`,
    `${reviewArchiveRoot}/intake-review-request.json`,
    `${reviewArchiveRoot}/intake-review-result.json`,
    `${reviewArchiveRoot}/intake-review-report.md`,
    `${reviewArchiveRoot}/superseded-review.json`,
  ],
  validation: {bash: "Pass", powerShell: "Pass"},
  publication: {
    status: "Published",
    publishedPaths: [
      manifestPath,
      `${seriesRoot}/receipt.json`,
      `${seriesRoot}/operation.json`,
      `${seriesRoot}/order.md`,
      "Lastenheft_Abarbeitungsreihenfolge.md",
      `${seriesArchiveRoot}/manifest.json`,
      `${seriesArchiveRoot}/receipt.json`,
      `${reviewArchiveRoot}/intake-review-request.json`,
      `${reviewArchiveRoot}/intake-review-result.json`,
      `${reviewArchiveRoot}/intake-review-report.md`,
      `${reviewArchiveRoot}/superseded-review.json`,
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
      "Thirteen current target hashes, lifecycle states, four roots, and nine binding product-chain gates",
      "Complete current-product contract before accessibility acceptance and rename release-closeout",
      "Version-neutral repository-pin preflight without automatic dependency upgrades",
      "PL/0 followed by evidenced MCS legacy compatibility and separate structural spreadsheet extensions",
      "NIST SSDF and CWE Top 25 always; STRIDE/CAPEC, SBOM/VEX/SLSA, WCAG 2.2 AA, and explicit N/A dispositions as applicable",
      "Byte-identical predecessor targets, receipts, series evidence, and superseded review evidence retained",
    ],
    workers: [],
  },
  summary: {critical: 0, high: 0, medium: 0, low: 0},
  supersedes: "2c338c63-9f64-47c1-ba50-a95c7ea3fce1",
  requestEvidence: {path: requestPath, normalizedSha256: digest(json(request))},
};
const report = `# Intake-Review: TinyCalc Delivery Series

## Identität / Identity

- Review-ID: \`c00e3d93-58fe-4d36-b1a4-94090cca1137\`
- Modus: \`Series\`
- Policy: \`tinycalc-delivery-v1\`
- Ergebnis: \`Ready\`
- Umfang: 13 Ziele, 4 Wurzeln und 9 verbindliche interne Abhängigkeiten
- Worker: keine
- Vorgängerreview: \`2c338c63-9f64-47c1-ba50-a95c7ea3fce1\`

*The complete re-review covers all thirteen current targets, four roots, and
nine binding internal dependencies. It explicitly supersedes the stale
ten-target review.*

## Ergebnis / Result

Die Intake-Serie ist für die nachgelagerte Spec-Kit-Bearbeitung bereit. Alle
13 Zielpfade und Hashes, die vier Wurzeln, die neun harten Kanten, die
Lebenszykluszustände und die Authority-Grenzen sind konsistent. Die Kette
lautet jetzt verbindlich:

\`Terminal.Gui-Migration -> vollständige Funktionsabnahme -> A11Y -> Rename ->
didaktische Kommentare -> Secure Development -> PL/0 -> Legacy-Kompatibilität
-> Formelkopie und Tabellenoperationen\`.

Die drei unabhängigen Governance-Wurzeln für Sandbox-Härtung, RL-SE-Prüfung
und GSDB-Prüfung bleiben ohne erfundene Produktabhängigkeiten erhalten.

*The series is ready for downstream Spec Kit processing. Target identities,
hashes, roots, hard gates, lifecycle states, and authority boundaries agree.
The independent governance roots remain independent.*

## Vollständiger Produktvertrag / Complete Product Contract

Der neue Funktionsvertrag erfasst alle heute über TUI, README und migrierte
Hilfe angebotenen Bedienwege mit stabilen, additiv erweiterbaren IDs. Seine
Quellen- und Konfliktregel unterscheidet echte Angebote von eindeutigen
Dokumentationsdefekten. Eine verbindliche Impact-Matrix ordnet Änderungen den
erforderlichen Funktions-, A11Y-, PTY-/VoiceOver-, DocFX/axe/lynx- und
Linux-/Windows-Nachweisen zu. Größere, unklare, dependency-bezogene,
Rename- und Release-Änderungen erhalten die vollständige Matrix.

*The new functional contract covers every capability currently offered by the
TUI, README, and migrated help. Stable additive IDs and the impact matrix let
future PL/0, legacy, and other features extend the contract without weakening
regression coverage.*

## Erweiterungen und Reihenfolge / Extensions And Order

- PL/0 bleibt hinter Secure Development und ergänzt den Produktvertrag, ohne
  bestehende IDs zu ersetzen. Der Dependency-Preflight löst die dann aktuell
  freigegebenen Repository-Pins auf und führt kein automatisches Upgrade aus.
- Legacy-Kompatibilität folgt PL/0. Version 1 umfasst belegte Standard- und
  8087-MCS-Dialekte mit compiler-authentischen Fixtures; BCD bleibt auf Basis
  der historischen Quellen ein ausdrücklich belegtes Nicht-Ziel.
- Formelkopie sowie Einfügen und Löschen von Zeilen oder Spalten folgen als
  eigenes Lastenheft. Überlappende Kopien verwenden einen unveränderlichen
  Quell-Snapshot; strukturelle Operationen verschieben vollständige Zellrecords
  atomar und machen ungültige Ziele als \`#REF!\` sichtbar.

*PL/0, evidenced MCS compatibility, and structural spreadsheet features are
separate ordered contracts. This separation keeps future additions traceable
and lets the regression baseline grow before implementation begins.*

## Sicherheit, A11Y und Authority / Security, A11Y And Authority

NIST SSDF und CWE Top 25 gelten für die Level-2-Arbeit. STRIDE/CAPEC werden
für Import- und Interpretergrenzen verwendet. SBOM und SLSA gelten für
verteilbare Artefakte; VEX wird bei bekannten Schwachstellen benötigt. ASVS,
Zero Trust und AI-SBOM sind für die lokale, nicht KI-basierte TUI jeweils mit
Begründung \`N/A\`. WCAG 2.2 Level AA, deutsch-zuerst/englisch-danach und
CEFR-B2 bleiben verbindlich.

Das Ergebnis \`Ready\` bestätigt ausschließlich Qualität und Konsistenz der
Intake-Artefakte. Es bestätigt keine fertige Produktimplementierung, keine
bestandene TUI-Funktions- oder A11Y-Abnahme und erteilt keine Commit-, Push-,
PR-, Merge-, Provider-, Paketveröffentlichungs- oder Bypass-Berechtigung.

*NIST SSDF, CWE Top 25, applicable threat and supply-chain evidence, and WCAG
2.2 AA are explicit. \`Ready\` applies only to intake quality; it is not product
acceptance and grants no remote or delivery authority.*

## Findings und nächste Aktion / Findings And Next Action

- Critical: 0
- High: 0
- Medium: 0
- Low: 0
- Akzeptierte Risiken: keine
- Offene Fragen: keine
- Nächste Aktion: \`$speckit-intake-series-next tinycalc-delivery\`

*No finding, accepted risk, or open question remains. The next read-only step
is to determine the currently eligible target from the validated series.*
`;
const rootOrderPath = "Lastenheft_Abarbeitungsreihenfolge.md";
const orderDependencies = [
  "keine",
  "Constitution abgeschlossen",
  "Terminal.Gui-Migration abgeschlossen; Feldtest ausstehend",
  "vollständige Funktionsabnahme",
  "A11Y-Abnahme",
  "Rename",
  "Kommentarhärtung",
  "Security und TinyCalc-Preflight",
  "PL/0-Erweiterung",
  "Legacy-Kompatibilität",
  "unabhängige Wurzel",
  "unabhängige Wurzel",
  "unabhängige Wurzel",
];
// Beide Reihenfolgenansichten entstehen aus denselben Mitgliedern wie das Manifest, damit Pfad und Lifecycle nicht auseinanderlaufen.
// Both order views come from the same members as the manifest so their paths and lifecycle states cannot drift apart.
const orderRows = members.map((member, index) =>
  `| ${member.order} | \`${member.path}\` | \`${member.status}\` | ${orderDependencies[index]} |`
).join("\n");
const order = `# TinyCalc Intake-Reihenfolge / Intake Order

Diese Ansicht wird aus der kanonischen Intake-Serie abgeleitet. Verbindliche
Maschinendaten stehen in
\`requirements/intakes/series/tinycalc-delivery/manifest.json\`.

*This view is derived from the canonical intake series. Binding machine data
lives in the series manifest.*

| Rang | Intake | Zustand | Abhängigkeit |
|---:|---|---|---|
${orderRows}

Nur der explizite Zustand \`Eligible\` bezeichnet die bevorzugte nächste
Ausführung. \`Pending\` erteilt keine automatische Ausführungsberechtigung.

*Only the explicit \`Eligible\` state identifies the preferred next execution.
\`Pending\` does not grant automatic execution authority.*
`;
const outputs = [
  [manifestPath, json(manifest)],
  [`${seriesRoot}/receipt.json`, json(seriesReceipt)],
  [`${seriesRoot}/operation.json`, json(operation)],
  [rootOrderPath, order],
  [`${seriesRoot}/order.md`, order],
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

// Nach einem Hashwechsel ist entweder kein aktiver Review vorhanden oder der getrennte Review-Schritt hat den vollstaendigen Dreiersatz neu erzeugt.
// After a hash change, either no active review exists or the separate review step has recreated the complete three-file set.
const activeReviewPaths = [
  requestPath,
  `${seriesRoot}/intake-review-result.json`,
  `${seriesRoot}/intake-review-report.md`,
];
const activeReviewCount = activeReviewPaths.filter((relativePath) =>
  fs.existsSync(path.join(root, relativePath))
).length;
if (activeReviewCount !== 0 && activeReviewCount !== activeReviewPaths.length) {
  console.error("incomplete active intake-review evidence");
  process.exit(1);
}

const configuredCountMismatch =
  config.schemaVersion === "1.0" && members.length !== config.activeIntakeCount;
if (configuredCountMismatch || targets.length !== new Set(targets).size) {
  throw new Error("configured active intake cardinality differs from generated members");
}
console.log(`TinyCalc intake governance PASS (${members.length} active targets, ${dependencies.length} binding edges)`);
