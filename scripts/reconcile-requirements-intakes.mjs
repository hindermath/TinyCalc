#!/usr/bin/env node

import crypto from "node:crypto";
import fs from "node:fs";
import path from "node:path";
import process from "node:process";

const root = process.cwd();
const outputRoot = "specs/requirements-reconciliation-20260726";
const normalize = (value) => value.replace(/^\uFEFF/, "").replace(/\r\n?/g, "\n");
const hash = (value) => crypto.createHash("sha256").update(normalize(value)).digest("hex");
const hashFile = (relativePath) => hash(fs.readFileSync(path.join(root, relativePath), "utf8"));
const json = (value) => `${JSON.stringify(value, null, 2)}\n`;

const intakes = [
  {
    id: "TC-CONSTITUTION",
    path: "Lastenheft_Constitution_Change.md",
    status: "PartiallySatisfied",
    owner: "Governance",
    evidence: ["constitution.md", ".specify/memory/constitution.md", "AGENTS.md"],
    rationale: "Bilingual, documentation, TDD, and learner guidance exists, but the intake has not received a dedicated closure decision.",
  },
  {
    id: "TC-TERMINALGUI",
    path: "Lastenheft_TerminalGui_Migration.md",
    status: "Open",
    owner: "TUI",
    evidence: ["src/MicroCalc.Tui/MicroCalc.Tui.csproj", "tests/MicroCalc.Tui.Tests"],
    rationale: "The product still references Terminal.Gui 1.19.0, so the 2.x migration is not complete.",
  },
  {
    id: "TC-RENAME",
    path: "Lastenheft_Rename_MicroCalc_TinyCalc.md",
    status: "Open",
    owner: "Product",
    evidence: ["MicroCalc.sln", "src/MicroCalc.Core", "src/MicroCalc.Tui"],
    rationale: "Repository branding is TinyCalc, while solution, projects, namespaces, and active code still use MicroCalc.",
  },
  {
    id: "TC-A11Y",
    path: "Lastenheft_A11Y_TUI.md",
    status: "PartiallySatisfied",
    owner: "A11Y",
    evidence: ["src/MicroCalc.Tui", "tests/MicroCalc.Tui.Tests", "tests/web-a11y"],
    rationale: "A11Y foundations and tests exist, but the intake depends partly on the open Terminal.Gui migration and retains unclosed TUI criteria.",
  },
  {
    id: "TC-COMMENTS",
    path: "Lastenheft_Didactic-Inline-Code-Comment-Hardening.md",
    status: "Open",
    owner: "Maintainability",
    evidence: ["src", "tests", "AGENTS.md"],
    rationale: "The standing rule exists, but the selective repository-wide review run has not been completed.",
  },
  {
    id: "TC-SECURITY",
    path: "Lastenheft_Secure-Development-Hardening.md",
    status: "Open",
    owner: "Security",
    evidence: ["docs/security", ".github/workflows"],
    rationale: "Security governance exists, but the requested project-wide closure run remains open.",
  },
  {
    id: "TC-SANDBOX",
    path: "Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md",
    status: "Open",
    owner: "Security",
    evidence: ["docs/security", ".specify/presets"],
    rationale: "No completed TinyCalc sandbox field evidence or closure record exists.",
  },
  {
    id: "TC-RLSE",
    path: "Lastenheft_RL-SE-Checklist-Selbstpruefung.md",
    status: "Open",
    owner: "Governance",
    evidence: ["docs/security/gsdb-self-assessment.md", ".specify/templates"],
    rationale: "The self-review intake exists, but no dedicated result closes it.",
  },
  {
    id: "TC-GSDB",
    path: "Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md",
    status: "Open",
    owner: "Governance",
    evidence: ["docs/security/gsdb-self-assessment.md", ".specify/templates"],
    rationale: "The intensive review is explicitly documented as a later manual run.",
  },
];

const requirements = intakes.map((intake, index) => ({
  requirementId: `TC-RQ-${String(index + 1).padStart(3, "0")}`,
  sourceId: intake.id,
  sourcePath: intake.path,
  sourceNormalizedSha256: hashFile(intake.path),
  statement: intake.rationale,
  status: intake.status,
  evidencePaths: intake.evidence,
  proposedOwnerGroup: intake.owner,
  residualRisk: intake.status === "Open"
    ? "The accepted product or governance outcome remains unverified."
    : "Existing evidence may not cover every acceptance criterion in the intake.",
  reevaluationTrigger: `Before executing or archiving ${intake.path}`,
}));

const sources = [
  ...intakes.map((intake) => ({
    sourceId: intake.id,
    path: intake.path,
    normalizedSha256: hashFile(intake.path),
    role: "ActiveIntakeCandidate",
  })),
  {
    sourceId: "TC-BASELINE",
    path: "PLAN_MICROCALC_CSHARP_DOTNET10.md",
    normalizedSha256: hashFile("PLAN_MICROCALC_CSHARP_DOTNET10.md"),
    role: "HistoricalProductBaseline",
  },
  {
    sourceId: "TC-ORDER-CURATED",
    path: "docs/Lastenheft_Abarbeitungsreihenfolge.md",
    normalizedSha256: hashFile("docs/Lastenheft_Abarbeitungsreihenfolge.md"),
    role: "CuratedOrder",
  },
  {
    sourceId: "TC-ORDER-GENERATED",
    path: "Lastenheft_Abarbeitungsreihenfolge.md",
    normalizedSha256: hashFile("Lastenheft_Abarbeitungsreihenfolge.md"),
    role: "GeneratedOrder",
  },
];

const coverage = {
  schemaVersion: "1.0",
  documentType: "RequirementsReconciliation",
  repository: "hindermath/TinyCalc",
  reviewedAt: "2026-07-26",
  sources,
  summary: {
    total: requirements.length,
    AlreadySatisfied: 0,
    PartiallySatisfied: requirements.filter((item) => item.status === "PartiallySatisfied").length,
    Open: requirements.filter((item) => item.status === "Open").length,
    DeferredOptional: 0,
    Blocked: 0,
    "N/A": 0,
  },
  requirements,
};

const activePaths = intakes.map((intake) => intake.path);
const proposal = {
  schemaVersion: "1.0",
  documentType: "RequirementsIntakeMigrationProposal",
  repository: "hindermath/TinyCalc",
  canonicalIndex: "Pflichtenheft.md",
  baselineMoves: [
    {
      from: "PLAN_MICROCALC_CSHARP_DOTNET10.md",
      to: "requirements/baseline/PLAN_MICROCALC_CSHARP_DOTNET10.pre-intake-split.2026-07-26.md",
      mode: "ByteIdentical",
    },
  ],
  activeIntakes: activePaths.map((sourcePath) => ({
    sourcePath,
    targetPath: `requirements/intakes/active/${path.basename(sourcePath)}`,
    mode: "SupersedingCopy",
  })),
  archivedIntakes: [],
  backlogIntakes: [],
  canonicalSeries: {
    path: "requirements/intakes/series/tinycalc-delivery/manifest.json",
    preferredNext: "Lastenheft_Constitution_Change.md",
    orderedProductChain: [
      "Lastenheft_Constitution_Change.md",
      "Lastenheft_TerminalGui_Migration.md",
      "Lastenheft_Rename_MicroCalc_TinyCalc.md",
      "Lastenheft_A11Y_TUI.md",
      "Lastenheft_Didactic-Inline-Code-Comment-Hardening.md",
      "Lastenheft_Secure-Development-Hardening.md",
    ],
    independentGovernanceRoots: [
      "Lastenheft_Sandbox-gestuetzte-Secure-Development-Haertung.md",
      "Lastenheft_RL-SE-Checklist-Selbstpruefung.md",
      "Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md",
    ],
  },
  constraints: [
    "No Spec Kit feature is started.",
    "No product, API, dependency, or runtime behavior changes.",
    "Historical specs and hash-bound evidence remain unchanged.",
    "Both predecessor order documents remain preserved in migration history.",
  ],
};

const report = `# TinyCalc Requirements and Intake Reconciliation

## Ergebnis / Result

Die neun vorhandenen Intake-Kandidaten bleiben nach dem aktuellen
Repository-Abgleich aktiv. Zwei sind teilweise erfüllt, sieben offen. Der
Terminal.Gui-2.x-Lauf und der vollständige MicroCalc-zu-TinyCalc-Rename sind
nachweislich nicht abgeschlossen.

*All nine current intake candidates remain active after repository
reconciliation. Two are partially satisfied and seven are open. The
Terminal.Gui 2.x migration and complete MicroCalc-to-TinyCalc rename are
demonstrably unfinished.*

Die beiden Reihenfolgedokumente widersprechen sich. Für die Migration gilt die
begründete Reihenfolge unter \`docs/\` als fachliche Ausgangsbasis; künftig
ersetzt eine einzige kanonische Intake-Serie beide Listen.

## Grenzen / Boundaries

- Dieser Audit verschiebt oder ändert keine Anforderungen.
- \`PLAN_MICROCALC_CSHARP_DOTNET10.md\` bleibt bis zur Migration unverändert.
- Es wird kein Spec-Kit-Feature gestartet.
- Die Migration benötigt einen eigenen Folge-PR.
`;

const outputs = [
  [`${outputRoot}/requirements-coverage.json`, json(coverage)],
  [`${outputRoot}/migration-proposal.json`, json(proposal)],
  [`${outputRoot}/reconciliation-report.md`, report],
];

for (const [relativePath, content] of outputs) {
  const fullPath = path.join(root, relativePath);
  fs.mkdirSync(path.dirname(fullPath), {recursive: true});
  fs.writeFileSync(fullPath, content);
}

console.log(`TinyCalc reconciliation PASS (${requirements.length} intake decisions)`);
