# Implementation Plan: GSDB-Intensivpruefung / Intensive GSDB Review

**Branch**: `005-gsdb-intensive-review` | **Date**: 2026-09-06 | **Spec**: [spec.md](spec.md)
**Input**: `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md`
**Run**: `69674c80-911c-40ff-9a0e-004f7b13b832` (`MergeAndSync`)

## Zusammenfassung / Summary

**DE:** TinyCalc erhaelt eine vollstaendige, repository-lokale Intensivpruefung
gegen die GSDB 3.2.0. Ein neuer maschinenlesbarer Matrixvertrag bindet die
Richtlinie, alle 12 Einzelchecklisten mit aktuell 157 eindeutigen IDs, den
generierten Sammelband, mitgeltende Dokumente, Lernpfad, beide Constitutions,
13 installierte Presets, Workflows, Validatoren und bestehende
Projektnachweise. Jede Bewertung trennt Anwendbarkeit und Erfuellung und nennt
Lernstufe, Fundstelle, Owner, Reviewer, Folgearbeit, erwarteten Nachweis,
Zieltermin, Trigger und Restrisiko. Die Umsetzung
erzeugt Nachweise und priorisierte Haertungsbefunde, haertet aber keinen
Produktcode und behauptet keine Human-only-Freigabe.

**EN:** TinyCalc receives a complete repository-local intensive review against
GSDB 3.2.0. A new machine-readable matrix contract binds the guideline, all 12
individual checklists with the current 157 unique IDs, the generated
compendium, related documents, learning path, both constitutions, 13 installed
presets, workflows, validators, and existing project evidence. Every assessment
separates applicability from fulfilment and records a learning stage, locator,
owner, reviewer, follow-up, expected evidence, target date, trigger, and
residual risk. Implementation creates evidence and
prioritised hardening findings, but does not harden product code or claim any
human-only approval.

## Technical Context

**Language/Version**: Unchanged product: C# 14 / .NET 10; evidence automation:
PowerShell 7 with a strict Bash wrapper; JSON Schema draft 2020-12
**Primary Dependencies**: Existing .NET SDK, xUnit, Terminal.Gui 2.4.17,
Git/GitHub CLI, PowerShell 7, Bash, installed Spec-Kit presets; no new product,
NuGet, npm, Python, or service dependency
**Storage**: Versioned Markdown and JSON under `specs/005-...`,
`docs/security/gsdb-intensive-review/`, `docs/accessibility/`, and existing
security evidence paths; exact-head lifecycle snapshots remain temporary under
`.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/`
**Testing**: JSON Schema plus semantic contract fixtures; paired PowerShell/Bash
validation; current governance validators; .NET restore/build/xUnit/TUI smoke;
DocFX regeneration plus mandatory lynx and preferred Playwright/axe accessibility
smoke when the reviewed harness is available;
Linux/Windows CI and applicable macOS/Linux/Windows governance jobs
**Target Platform**: Registered macOS development host; GitHub-hosted Linux and
Windows product CI; three-platform requirements, homogeneity, and intake jobs
where the workflow actually declares them
**Project Type**: Assessment and evidence feature for a local .NET spreadsheet
and Terminal.Gui TUI
**Performance Goals**: Deterministically reconcile 157 current checklist IDs,
all controlled GSDB sources, and 13 installed presets in one validator run;
product runtime performance is unchanged
**Constraints**: Assessment-only; no automatic hardening; no human approval,
legal opinion, certification, secret rotation, provider approval, or
branch-protection mutation; repository-relative evidence; DE-first/EN-second
CEFR B2; text-first WCAG 2.2 AA; exact-head evidence must not self-invalidate
**Scale/Scope**: GSDB manifest 3.2.0; 12 families and 157 IDs; 30 baseline-bound
text documents plus managed references/binary integrity; two byte-identical
constitutions; 13 installed presets; current workflows and validators; Feature
004 evidence with 21 fulfilled, 32 N/A, 42 open, and 62 follow-up rows

## Constitution Check

*GATE: Passed before Phase 0 research and re-checked after Phase 1 design.*

- **Level-2 environment**: The binding `RiderProjects/TinyCalc` registry row in
  both constitutions requires .NET 10/C#, `MicroCalc.sln`, xUnit, non-interactive
  TUI smoke, DocFX/A11Y coupling, 80 manual and 125 Thorsten-Solo lines/workday,
  and coordinated agent surfaces. The two constitutions are currently
  byte-identical at SHA-256
  `c57f6e586d93a48b2254550367289e9e3e3ba6645ebb8f308f2e9e24dc7c93b9`.
- **Branch and PR flow**: Work stays on `005-gsdb-intensive-review`, uses one
  focused PR and the accepted `MergeAndSync` lifecycle. Intake branch-stamping
  and series mutation occur only in the authorised causal closeout after the
  feature merge. No successor feature starts.
- **Toolchain**: Product checks use .NET 10/C# 14. PowerShell always uses
  `-NoProfile` and `Set-StrictMode -Version Latest`; Bash uses quoted variables,
  `--` where applicable, and `set -euo pipefail`.
- **MSL**: C# is on the Principle XI memory-safe-language allow-list. This does
  not waive secure API, deserialisation, path, formula-input, error, native
  boundary, dependency, or file-I/O review. No platform constraint justifies a
  language change.
- **Secure coding**: The feature does not alter product code. Evidence
  validators must reject malformed JSON, unknown/duplicate/missing IDs,
  contradictory status axes, unsafe paths, stale hashes, missing locators,
  learning stages, target dates or expected evidence, unsupported fulfilment,
  and fabricated Human-only evidence. `Open` means unresolved applicability;
  missing fulfilment evidence keeps known applicability `Applicable`, selects a
  non-fulfilled implementation status, and creates a linked finding. Validators
  may not use dynamic execution or expose secrets/internal state.
- **Architecture**: Product components, interfaces, runtime, deployment, and
  topology remain unchanged. Review covers existing boundaries from file input
  into formulas/spreadsheets, managed code into native dependencies, repository
  into build/providers, and agent into filesystem/network/provider access.
  Context, building-block, runtime and deployment views are reassessed together
  with Defense in Depth, Least Privilege, Fail-Safe Defaults, Attack Surface
  Reduction, separation of authentication/authorization/logging/validation,
  secure configuration, threat model, arc42, quality scenarios, technical debt,
  and S-ADR evidence. New ADR/S-ADR is `N/A`; trigger: an authorised design,
  trust-boundary, integration, or deployment change.
- **Security documentation**: Existing `threat-model.md`,
  `arc42-security.md`, `security-checklist.md`, `dependency-audit.md`,
  `security-quality-scenarios.md`, `asvs-verification.md`,
  `supply-chain-evidence.md`, `zero-trust-applicability.md`, and
  `samm-assessment.md` require freshness review. The absent default files
  `regulatory-applicability.md`, `cloud-autonomy-applicability.md`, and
  `cloud-compliance-assurance.md` are planned evidence, not current facts.
- **NIST SSDF and CWE Top 25**: `Applicable` for all Level-2 work. The matrix
  maps lifecycle practices and relevant weaknesses to exact TinyCalc evidence;
  neither may be marked N/A.
- **STRIDE, CIA, and CAPEC**: `Applicable` to the four existing trust-boundary
  groups. Current threat and quality evidence is re-reviewed; risky paths gain
  CAPEC locators. No mitigation is implemented by this feature.
- **OWASP ASVS**: `N/A`; TinyCalc remains a local TUI with no Web/API/HTTP/auth
  service. Trigger: introduction of such a service, which also requires a
  named ASVS level and verification scope.
- **SBOM, VEX, SLSA, and OpenSSF**: SBOM and provenance review are
  `Applicable` because TinyCalc is distributable and uses CI. VEX disposition
  is an applicable review gate whose result depends on a current vulnerability
  scan; no old clean scan is reused as current proof. OpenSSF and dependency
  maintenance are supporting applicable checks. No unsupported SLSA level is
  claimed.
- **AI-SBOM**: `N/A`; AI is development tooling only and no model, dataset,
  inference service, or AI runtime ships or operates with TinyCalc. Trigger:
  any such product or runtime component, activating the seven G7/BSI evidence
  clusters.
- **Zero Trust**: Product applicability is `N/A` for the unchanged local
  single-process TUI. Delivery-environment applicability is `Applicable` for
  repository, CI, identity, and provider boundaries. Trigger for product
  reassessment: network, cloud, remote, service, or identity architecture.
- **BSI C3A/C5 and regulation**: Cloud autonomy/assurance and NIS2, CRA, EU AI
  Act, DORA, and privacy receive separate evidence-based applicability reviews.
  Current primary sources, date, scope, owner, reviewer, trigger, and residual
  risk are mandatory. Legal acceptance remains Human-only.
- **OWASP SAMM and supporting guidance**: SAMM is `Applicable` because the
  repository is long-lived. OWASP Cheat Sheets and Proactive Controls inform
  input/API/error review; CAPEC and OpenSSF remain traceable supporting sources.
- **Supply-chain evidence**: Current NuGet graph, lock/pinning exceptions,
  SPDX SBOM, VEX decision, provenance boundary, workflow action pinning, and
  critical-CVE absence are reassessed. The plan introduces no dependency.
- **Preset inventory**: The exact eight-preset standard matrix applies:
  `security-governance` 0.6.2/10, `architecture-governance` 0.5.2/20,
  `isaqb-architecture-governance` 0.2.2/30, `a11y-governance` 0.4.3/40,
  `cross-platform-governance` 0.2.2/50, `agent-parity-governance` 0.4.2/60,
  `autonomous-run-governance` 0.4.1/70, and
  `parallel-autonomous-run-governance` 0.2.6/80. Five additional installed
  presets are also mapped: secure-development-assurance 0.1.2, model-routing
  0.1.4, intake-authoring 0.3.1, intake-review 0.2.1, and intake-sequencing
  0.2.3. Installation grants no execution authority.
- **Security-first**: No credential, token value, local runner profile, agent
  log, ignored runtime state, history database, private absolute path, or
  personal data is added to tracked evidence.
- **Inclusion/A11Y**: All new reader-facing Markdown/JSON-derived views are
  semantic, text-complete, and usable without colour or spatial position.
  Review covers WCAG 2.2 AA criteria applicable to Markdown and the existing
  reader path. German text uses correct umlauts and `ß`, not ASCII
  substitutions. No screen-reader user test or certification is claimed.
- **Bilingual learner delivery**: German comes first with complete English
  partner blocks at CEFR B2. Technical terms are explained at first use or
  linked to the learner path. Applicability follows project scope, never
  training year; checklist status creates no grade or certificate.
- **Public XML documentation and DocFX**: Product APIs and XML comments are not
  changed; CS1591 remains enforced. Because `docfx.json` includes every changed
  `docs/**/*.md`, DocFX regeneration and a representative lynx HTML smoke are
  `Applicable` in the same work item. Playwright/axe is the preferred additional
  smoke when its reviewed harness is available; an unavailable harness is
  recorded explicitly. The evidence is text-oriented and makes no global
  accessibility certification claim.
- **Didactic why-comments**: Product-code comments are `N/A`; trigger: later
  authorised non-trivial logic. New validator comments, if needed, explain only
  decisions/proof boundaries in moderate DE-first/EN-second form.
- **TDD and coverage**: Product-code TDD and changed-product coverage are
  `N/A`, triggered by any `src/` or product-test change. Such a change restores
  observable RED/GREEN/regression with at least 70% changed-code coverage and
  an 80% target. Evidence validators still require repeatable RED, smallest
  GREEN, negative fixtures, and full regression before real assessment data is
  accepted.
- **Cross-platform validator contract**: The read-only PowerShell implementation
  and strict Bash wrapper require matching parameters, outputs, error classes,
  and exit codes; Linux/Windows CI plus local macOS evidence is mandatory. A
  dedicated `checklists/script-parity.md`, bilingual PowerShell help, approved
  `Test-GsdbIntensiveReview` naming, Bash man page, quoting, end-of-options, and
  Bash 3.x compatibility are reviewed. `-WhatIf`/dry-run is `N/A` only because
  validation performs no mutation; any future writer reopens that decision.
- **Serialization and data conventions**: UTF-8 without BOM, LF, canonical
  repository-relative `/` paths, lowercase 64-character normalized SHA-256,
  ISO-8601 UTC/date values, stable IDs, deterministic sorting, and JSON Schema
  draft 2020-12. Unknown properties fail closed.
- **Dependency currency and pinning**: No package change is planned. Current
  direct/transitive, outdated, and vulnerable package output is evidence.
  The observed absence of local Dependabot/Renovate configuration and central
  Dependency-Track ingestion is assessed explicitly against CL-05 and recorded
  as owned follow-up rather than silently treated as fulfilled. Current GitHub
  alert posture is provider evidence only when captured for the exact scope.
  Any pinning exception must name owner, reason, expiry/review date, trigger,
  and residual risk; a known critical CVE blocks delivery.
- **Statistics**: `docs/project-statistics.md` and its configuration are updated
  after the implementation phase. The entry records branch/phase, observable
  work window, production/test/documentation lines, work packages, 80 and 125
  lines/workday, 7.8 hours/day, 21.5 workdays/month, strict chronological order,
  and refreshed final ASCII trends.
- **Agent parity**: The five maintained guidance surfaces and affected Spec-Kit
  templates are reviewed but not changed because no shared rule changes.
  A discovered governance-rule correction triggers an explicitly authorised
  atomic parity update; it must not be folded silently into this assessment.
- **Documentation Impact**: Exactly `UpdateRequired`. Canonical sources are the
  accepted GSDB intake and GSDB baseline. Owner is Thorsten Hindermann with
  named specialist reviewers. Audiences are project owners, reviewers,
  instructors, IT specialists, and both IT-management occupations from year 1
  without Spec-Kit knowledge. Affected classes are feature, security,
  governance, A11Y, PR, intake-closeout, and statistics evidence. The reader
  path is `docs/security/README.md` to the new GSDB context, then sources and
  follow-up. Language partner is inline DE/EN; platform example is macOS with
  actual CI claims limited to logged runners. Distribution is public after
  content review. Home sync is `N/A`; trigger: a central shared-rule change.

### Post-design re-check

**DE:** Die Datenmodelle trennen Quellen, CL-Zeilen, externe Pflichten,
Presets, Befunde und Gate-Evidenz. Der Gate-Vertrag deklariert vor der
Implementierung jeden Akzeptanz- und Liefernachweis mit stabiler ID. Der
Requirements-Vertrag bleibt kompatibel mit Schema 1.0 des installierten
Validators; alle neuen PreMerge-/PostMerge-Snapshots verwenden Schema 2.0.
Keine Constitution-Ausnahme und keine pauschale Erfuellungsbehauptung bleibt.

**EN:** The data models separate sources, checklist rows, external duties,
presets, findings, and gate evidence. Before implementation, the gate contract
declares every acceptance and delivery proof with a stable ID. The requirements
contract remains compatible with the installed validator's schema 1.0; all new
PreMerge/PostMerge snapshots use schema 2.0. No constitutional exception or
blanket fulfilment claim remains.

## Project Structure

### Documentation and evidence planned for this feature

```text
specs/005-gsdb-intensive-review/
├── spec.md
├── plan.md
├── research.md
├── data-model.md
├── quickstart.md
├── tasks.md                         # created only by /speckit.tasks
├── autonomous-run-evidence.md
├── autonomous-run-state.json              # local operational state; never tracked
├── checklists/
│   ├── requirements.md
│   ├── plan-review.md
│   ├── script-parity.md              # created during implementation
│   └── analyze-remediation.md        # created and accepted by /speckit.analyze
└── contracts/
    ├── evidence-matrix.schema.json
    └── autonomous-run-gate-requirements.json

docs/security/gsdb-intensive-review/
├── source-inventory.md
├── evidence-matrix.json
├── evidence-matrix.md
├── preset-mapping.md
└── open-findings.md

docs/security/
├── README.md
├── regulatory-applicability.md
├── cloud-autonomy-applicability.md
├── cloud-compliance-assurance.md
└── existing mandatory evidence files   # update only from current findings

docs/accessibility/
└── gsdb-intensive-review.md

docs/
├── PR_TEXT_GSDB_INTENSIVE_REVIEW.md
├── documentation-impact/gsdb-intensive-review.json
└── project-statistics.md

scripts/
├── validate-gsdb-intensive-review.ps1
├── validate-gsdb-intensive-review.sh
└── tests/gsdb-intensive-review/         # deterministic RED/GREEN fixtures

docs/man/
└── validate-gsdb-intensive-review.1

.github/workflows/
└── ci.yml                               # paired validator jobs are required
```

### Existing product and evidence structure inspected, not hardened

```text
src/
├── MicroCalc.Core/
└── MicroCalc.Tui/

tests/
├── MicroCalc.Core.Tests/
└── MicroCalc.Tui.Tests/

docs/secure-development/
├── baseline-manifest.json
├── Richtlinie_Sichere-Entwicklung.md
├── Checklistensammelband_Sichere-Entwicklung.md
├── Lernpfad_Sichere-Entwicklung_Lehrjahr-1-bis-3.md
├── checklisten/CL_01...CL_12
└── mitgeltende-dokumente/

docs/security/secure-development/2026-09-05-rl-se-self-assessment/
└── Feature-004 baseline, matrix, delta, closure, image impact, and report

MicroCalc.sln
Directory.Build.props
constitution.md
.specify/memory/constitution.md
```

**Structure Decision:** The review owns one dated/logical security evidence
context plus a feature-local schema and gate contract. A PowerShell cmdlet-style
validator entry (`Test-GsdbIntensiveReview`) provides typed semantics; the
script and Bash wrapper expose stable automation interfaces. The Bash wrapper
delegates to the same PowerShell implementation to prevent semantic drift.
The man page and bilingual PowerShell help ship with the validator. Product
projects and xUnit suites remain read-only assessment targets.

### Intended delivery sets

**DE:** Die Feature-Liefermenge ist auf die folgenden repository-relativen
Pfade geschlossen. Die drei Fixture-Tests erzeugen alle negativen Varianten
nur unter einem temporären Pfad; deshalb ist keine unbenannte Fixture-Datei
zulässig. `_site/` bleibt ungetrackter lokaler Prüfausstoß. Die geprüften
`src/`-, `tests/`-, Baseline-, Constitution-, Solution- und Projektdateien
bleiben unverändert; ausgenommen sind ausschließlich die benannte
`Directory.Build.props`-Versionsaktualisierung und der exakte lokale
Laufzustands-Ausschluss in `.gitignore`.

**EN:** The feature delivery set is closed to the following repository-relative
paths. The three fixture-test files generate every negative variant only under
a temporary path, so no unnamed fixture file is allowed. `_site/` remains
untracked local proof output. The inspected `src/`, `tests/`, baseline,
constitution, solution, and project files remain unchanged; the sole exception
is the named `Directory.Build.props` version update plus the exact local
run-state exclusion in `.gitignore`.

```text
.gitignore
Directory.Build.props
.github/workflows/ci.yml
specs/intake-authoring-receipts/rename-microcalc-tinycalc.json
specs/005-gsdb-intensive-review/spec.md
specs/005-gsdb-intensive-review/plan.md
specs/005-gsdb-intensive-review/research.md
specs/005-gsdb-intensive-review/data-model.md
specs/005-gsdb-intensive-review/quickstart.md
specs/005-gsdb-intensive-review/tasks.md
specs/005-gsdb-intensive-review/autonomous-run-evidence.md
specs/005-gsdb-intensive-review/checklists/requirements.md
specs/005-gsdb-intensive-review/checklists/plan-review.md
specs/005-gsdb-intensive-review/checklists/analyze-remediation.md
specs/005-gsdb-intensive-review/checklists/script-parity.md
specs/005-gsdb-intensive-review/contracts/evidence-matrix.schema.json
specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json
docs/security/gsdb-intensive-review/source-inventory.md
docs/security/gsdb-intensive-review/evidence-matrix.json
docs/security/gsdb-intensive-review/evidence-matrix.md
docs/security/gsdb-intensive-review/preset-mapping.md
docs/security/gsdb-intensive-review/open-findings.md
docs/security/README.md
docs/security/threat-model.md
docs/security/arc42-security.md
docs/security/security-checklist.md
docs/security/dependency-audit.md
docs/security/security-quality-scenarios.md
docs/security/asvs-verification.md
docs/security/supply-chain-evidence.md
docs/security/zero-trust-applicability.md
docs/security/samm-assessment.md
docs/security/regulatory-applicability.md
docs/security/cloud-autonomy-applicability.md
docs/security/cloud-compliance-assurance.md
docs/accessibility/gsdb-intensive-review.md
docs/PR_TEXT_GSDB_INTENSIVE_REVIEW.md
docs/documentation-impact/gsdb-intensive-review.json
docs/project-statistics.md
scripts/validate-gsdb-intensive-review.ps1
scripts/validate-gsdb-intensive-review.sh
scripts/tests/gsdb-intensive-review/valid-assessment.json
scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.ps1
scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.sh
docs/man/validate-gsdb-intensive-review.1
```

Before each commit or push, the read-only delivery-set validator receives the
exact current subset from this list and reconciles it with tracked, untracked,
staged, and unstaged state. `tasks.md` repeats the closed set, and each task
names its exact writer and evidence paths.
The Analyze phase added `checklists/analyze-remediation.md` and revalidated it
with Plan and Tasks. The explicitly approved derived CI-hash correction in
`specs/intake-authoring-receipts/rename-microcalc-tinycalc.json` is also part
of the closed set. Any further new or removed path blocks until Plan, Tasks,
and review evidence are revalidated. The operational
`autonomous-run-state.json` is repository-local state, is excluded by the
feature's exact `.gitignore` entry before staging, and never enters a commit;
its readable history is maintained in `autonomous-run-evidence.md`.

The single causal closeout uses exactly branch
`codex/005-gsdb-intensive-review-closeout`. Its one intended commit is limited
to these paths:

```text
requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md
requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.005-gsdb-intensive-review.md
requirements/intakes/series/tinycalc-delivery/manifest.json
requirements/intakes/series/tinycalc-delivery/operation.json
requirements/intakes/series/tinycalc-delivery/order.md
requirements/intakes/series/tinycalc-delivery/receipt.json
requirements/intakes/series/tinycalc-delivery/intake-review-request.json
requirements/intakes/series/tinycalc-delivery/intake-review-result.json
requirements/intakes/series/tinycalc-delivery/intake-review-report.md
specs/005-gsdb-intensive-review/autonomous-run-evidence.md
specs/005-gsdb-intensive-review/evidence/accepted-premerge.json
specs/005-gsdb-intensive-review/evidence/postmerge.json
```

The first path is a deletion and the second is its branch-stamped replacement.
Review request/result/report enter the current subset only when the selected
series workflow refreshes all three. No other conditional path is allowed
without renewed Plan/Tasks/review. Runtime provider logs, phase results, and
the operational run state remain local/ignored; their hashes and terminal facts
are summarized in tracked readable evidence wherever causally possible. The
closeout may not add a successor intake, feature, campaign, or unrelated
remediation.

## Implementation Strategy

### Phase 0 - Freeze sources and research decisions

1. Revalidate active run state, branch/head, accepted hashes, intake review,
   series eligibility, and the 13-preset inventory.
2. Capture normalized hashes and versions for the manifest, guideline,
   compendium, all 12 checklists, all related/learning/managed references,
   both constitutions, presets, workflows, validators, and relevant evidence.
3. Derive all checklist IDs from individual checklist headings; require the
   observed family counts to total 157. Compare the compendium's 157 unique
   occurrences and content blocks against their canonical source files.
4. Record precedence, evidence freshness, status, Human-only, standards,
   architecture, regulation, A11Y, and delivery decisions in
   [research.md](research.md).

### Phase 1 - Contract and operator design

1. Use [evidence-matrix.schema.json](contracts/evidence-matrix.schema.json) to
   define source inventory, exactly 157 checklist rows, non-CL duties, 13 preset
   dispositions, findings, summary counts, safe evidence locators, learning
   stage, target date, expected evidence, and Human-only boundaries.
2. Use [data-model.md](data-model.md) for invariants, transitions, precedence,
   failure classes, and lifecycle ownership.
3. Use
   [autonomous-run-gate-requirements.json](contracts/autonomous-run-gate-requirements.json)
   to declare `GSDB-GATE-001` through `GSDB-GATE-033` before implementation.
   Every Applicable gate carries exact command and runner/platform tokens;
   every N/A gate carries a rationale and re-evaluation trigger.
4. Use [quickstart.md](quickstart.md) for the repeatable RED/GREEN, assessment,
   governance, product-regression, PR, exact-head, merge, and sync sequence.

### Phase 2 - TDD vertical slice for evidence validation

1. **RED 1:** A fresh missing matrix path must fail with `GSDB001` and a
   non-zero exit through PowerShell and Bash.
2. **RED 2:** Focused fixtures must fail for unknown/duplicate/missing IDs,
   invalid axis combinations, missing evidence locator/reviewer/trigger,
   learning stage/target date/expected evidence, unsafe/absolute/escaping paths,
   stale or uppercase hashes, fabricated
   Human-only approval, preset omission, compendium mismatch, and summary drift.
3. **GREEN 1:** Implement only schema and one-row/source helper semantics needed
   for focused valid fixtures. A one-row fixture is never called a valid
   production matrix.
4. **GREEN 2:** Accept the full production artifact only at 12/12 families,
   157/157 exact IDs, complete controlled sources, 13/13 presets, reconciled
   compendium, and internally derived summaries.
5. **REGRESSION:** Run both entrypoints locally and in the existing Linux/
   Windows CI matrix. Preserve expected-failure exit code, stdout/stderr,
   command, platform, fixture hash, and final GREEN hash in run evidence.

### Phase 3 - Intensive assessment and documentation evidence

1. Populate the source inventory from current files, not Feature-004 hashes by
   assumption. Mark reused evidence with observed date, scope, freshness, and
   exact locator.
2. Assess each canonical checklist item once. `Open` is used only while
   applicability is unresolved. Missing fulfilment evidence prevents
   `Fulfilled`, requires a linked finding and due follow-up, and does not erase
   already known `Applicable` scope. `N/A` pairs with `Not Assessed`.
3. Reconcile guideline and related-document duties not represented by a CL ID
   in separate `externalDuties` rows. Reconcile all 13 presets to CLs,
   checkpoints, actual installed versions, or triggered N/A decisions.
4. Review current product/security/architecture/workflow evidence. Record gaps
   as stable findings with severity, owner, reviewer, follow-up, trigger, and
   residual risk. Do not modify product code or provider configuration.
5. Produce the bilingual evidence matrix, source inventory, preset mapping,
   open-findings report, regulatory/cloud applicability notes, and A11Y proof.
   Update existing mandatory security evidence only when a new current fact is
   established and preserve prior evidence history.
6. Run secure-development status and one independent bounded technical review.
   Keep pilot, project, general release, legal acceptance, and risk acceptance
   open unless genuine Human-only evidence exists outside agent claims.

### Phase 4 - Regression, statistics, and exact delivery set

1. Validate matrix/schema, all GSDB source/preset mappings, assurance evidence,
   documentation impact, statistics, intake alignment, secret/homogeneity, and
   PowerShell/Bash parity. Regenerate DocFX and run a representative lynx smoke
   because the delivery changes `docs/**/*.md`. Add Playwright/axe when its
   reviewed harness is available and otherwise record that preferred tool as
   unavailable.
2. Before each later build/test, align `Version`, `AssemblyVersion`, and
   `FileVersion` to
   `1.5.<prospective-feature-commit-count>.<incremented-build-counter>`.
   The prospective count includes the pending commit being prepared; all three
   fields must be equal before commit or push.
   Run restore, Release build, all xUnit tests, and exact `SMOKE_OK` locally.
3. Validate the intended tracked/untracked delivery set read-only before every
   commit; stage only intended paths and run `git diff --cached --check`.
4. Update `docs/project-statistics.md` only after implementation evidence is
   complete, using the required baselines and final ASCII diagrams.

### Phase 5 - PR review, PreMerge, merge, and closeout

1. Push and create one focused PR only under the run's still-valid authority.
   Converge required checks (`gh pr checks --required --watch --fail-fast`) and
   review threads on the exact current head. A
   provider refusal, missing reviewer, stale check, or green job name without
   command evidence is not a pass.
2. Generate a fresh temporary schema-2.0 `PreMerge` snapshot under the run's
   ignored runtime directory. It binds the normalized requirements hash and
   exact reviewed head, contains one `Primary` row per declared gate, and makes
   no merge claim. Validate it with `validate-autonomous-gate-evidence.ps1`.
3. Prefer normal merge. `GSDB-GATE-029` declares Admin-Bypass as `N/A` initially.
   If and only if every material gate passes and the sole remaining provider
   blocker is a formal merge rule, update that requirement to Applicable,
   re-review the changed exact head, regenerate PreMerge evidence, and use the
   already authorised `--admin` path. It may not replace specialist approval,
   provider approval, or a failed material gate and may not alter protection.
4. Verify the actual provider merge commit and parents, then fast-forward local
   `main`. Create the pre-named branch
   `codex/005-gsdb-intensive-review-closeout` for one single-commit-capable,
   evidence-only closeout because
   branch-stamp, series completion, and PostMerge facts cannot exist before the
   feature merge. Rename only the GSDB intake with `.005-gsdb-intensive-review`,
   update the series exactly once, validate the PowerShell and Bash variants,
   and do not start another target.
5. Generate schema-2.0 `PostMerge` evidence with empty `changedPaths`, the
   accepted PreMerge hash, reviewed feature head, and actual merge commit.
   Complete declared idempotent post-actions, close the causal PR if required,
   fast-forward again, run final read-only validation, clean branches, and mark
   the autonomous run `Completed` only when all terminal closeout fields pass.

## Acceptance Gate Index

**DE:** Der maschinenlesbare Vertrag ist verbindlich. Diese Kurzsicht zeigt die
vollstaendige Vorabdeklaration, nicht ausgefuehrte Ergebnisse.

**EN:** The machine-readable contract is binding. This compact view shows the
complete declaration made before implementation, not executed results.

| Gate range | Scope | Planned disposition |
|---|---|---|
| `GSDB-GATE-001`-`004` | Run/intake/spec phase and source/compendium identity | Applicable |
| `GSDB-GATE-005`-`007` | Matrix TDD, complete assessment, presets and prior-evidence freshness | Applicable |
| `GSDB-GATE-008`-`010` | NIST/CWE, secure coding, STRIDE/CAPEC/architecture | Applicable |
| `GSDB-GATE-011` | Product ASVS | N/A with Web/API/Auth trigger |
| `GSDB-GATE-012`-`013` | SBOM/provenance/OpenSSF and current VEX disposition | Applicable |
| `GSDB-GATE-014` | Product AI-SBOM | N/A with AI-runtime trigger |
| `GSDB-GATE-015` | Product Zero Trust | N/A with distributed-boundary trigger |
| `GSDB-GATE-016`-`018` | Delivery Zero Trust, BSI cloud, regulation/privacy/SAMM | Applicable |
| `GSDB-GATE-019` | Markdown bilingual/WCAG text evidence | Applicable |
| `GSDB-GATE-020` | DocFX regeneration, mandatory lynx, and preferred available Playwright/axe HTML evidence | Applicable |
| `GSDB-GATE-021` | Paired evidence-validator TDD and CI | Applicable |
| `GSDB-GATE-022` | Product changed-code coverage | N/A with product-code trigger |
| `GSDB-GATE-023`-`026` | Product regression, dependencies, docs/statistics, secrets/parity | Applicable |
| `GSDB-GATE-027` | Exact intended delivery set and version discipline | Applicable |
| `GSDB-GATE-028` | Exact-head PR checks and review convergence | Applicable |
| `GSDB-GATE-029` | Formal-only Admin-Bypass | N/A initially; strict trigger above |
| `GSDB-GATE-030` | Temporary schema-2.0 PreMerge | Applicable |
| `GSDB-GATE-031` | Merge, PostMerge, and fast-forward sync | Applicable |
| `GSDB-GATE-032` | Intake branch-stamp, series closeout, final state | Applicable |
| `GSDB-GATE-033` | Parallel campaign/follow-up feature | N/A with explicit-delegation trigger |

## Complexity Tracking

No constitutional violation is required. A feature-specific paired validator
is justified because the Feature-004 contract does not require the new
reviewer and evidence-locator fields, external non-CL duties, complete preset
dispositions, compendium content parity, or current source-freshness rules.
The validator remains evidence tooling and changes neither TinyCalc runtime nor
product security posture.
