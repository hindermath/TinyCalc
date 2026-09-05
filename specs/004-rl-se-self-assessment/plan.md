# Implementation Plan: RL-SE-/Checklist-Selbstpruefung

**Branch**: `004-rl-se-self-assessment` | **Date**: 2026-09-05 | **Spec**: [spec.md](spec.md)
**Input**: `requirements/intakes/active/Lastenheft_RL-SE-Checklist-Selbstpruefung.md`

## Summary

TinyCalc erhaelt eine repository-lokale, auditfaehige Selbstpruefung gegen die
Secure-Development-Baseline 3.2.0. Ein kleiner Matrixvertrag gewinnt die 157
kanonischen IDs aus `CL_01` bis `CL_12`, verlangt jede ID genau einmal und
prueft Statuskombinationen, Pflichtfelder und lokale Evidenzpfade. Der Lauf
erzeugt die vier Evidence-Gates des Assurance-Presets, eine DE-first/EN-second
Matrix, einen Abschlussbericht und ausdrueckliche Folgearbeit. Produktcode,
Architektur und externe Konfiguration bleiben unveraendert.

*TinyCalc receives a repository-local, audit-ready self-assessment against
Secure Development Baseline 3.2.0. A small matrix contract derives all 157
canonical IDs from `CL_01` through `CL_12`, requires each ID exactly once, and
checks status combinations, mandatory fields, and local evidence paths. The run
creates the assurance preset's four evidence gates, a German-first/English-
second matrix, a closeout report, and explicit follow-up work. Product code,
architecture, and external configuration remain unchanged.*

## Technical Context

**Language/Version**: C# 14 / .NET 10 for the unchanged product; PowerShell 7
and Bash/Python-backed repository validators for governance evidence
**Primary Dependencies**: Existing .NET SDK, xUnit, installed Spec-Kit presets,
Git/GitHub CLI; no new product or NuGet dependency
**Storage**: Versioned Markdown and JSON under `specs/004-...` and
`docs/security/secure-development/2026-09-05-rl-se-self-assessment/`
**Testing**: JSON Schema and matrix-contract checks, paired Bash/PowerShell
entrypoints on CI Linux/Windows, `dotnet restore/build/test`, TUI smoke,
governance and secret gates
**Target Platform**: Registered macOS local environment plus GitHub-hosted
Linux and Windows build/test; repository validators remain cross-platform
**Project Type**: Documentation/evidence feature for a .NET spreadsheet and
Terminal.Gui TUI
**Performance Goals**: Validate 157 rows deterministically in one invocation;
runtime performance is not changed
**Constraints**: Exact source IDs; no unsupported positive claim; no product
hardening; no Human-only approval; text-first WCAG 2.2 AA; DE-first/EN-second
CEFR B2; no secrets or private paths
**Scale/Scope**: 12 checklist families, 157 IDs, all baseline-controlled
documents, 13 installed presets, four assurance gates and one closeout report

## Constitution Check

*GATE: Passed before research and re-checked after design.*

- **Level-2 environment**: Uses the `RiderProjects/TinyCalc` registry row:
  .NET 10/C#, `MicroCalc.sln`, xUnit, TUI smoke, DocFX/A11Y rules, manual
  baseline 80 and Thorsten-Solo baseline 125 lines/workday, and the five agent
  surfaces.
- **Branch and PR flow**: Work stays on `004-rl-se-self-assessment`, uses one
  focused PR, exact-head review and MergeAndSync. Admin bypass may address only
  a remaining formal merge rule after all material gates are green.
- **Toolchain**: Product validation uses .NET 10 and C# 14. PowerShell is
  invoked with `-NoProfile`; Bash uses quoted paths and fail-closed scripts.
- **MSL**: C# is on the Memory-Safe Language allow-list. MSL status does not
  replace API, I/O, dependency, configuration or error-path review.
- **Architecture**: No product structure, interface, runtime flow, deployment
  or trust boundary changes. Existing architecture, threat model, arc42 and
  S-ADR are assessed and linked; no new ADR is justified.
- **Secure coding**: No product code changes. Any small evidence validator must
  reject malformed/duplicate/unknown IDs and invalid status combinations,
  constrain paths to the repository, avoid dynamic execution and expose no
  secrets or internal state.
- **Security documentation**: The assessment context creates `baseline.json`,
  one delta, `closure.json`, `image-impact.json`, `evidence-matrix.md` and a
  closeout report. Existing threat model, security checklist, arc42,
  dependency audit, quality scenarios, applicability notes, SAMM and
  supply-chain evidence are referenced or updated only when the assessment
  establishes a concrete current fact.
- **Standards**: NIST SSDF and CWE Top 25 always apply. STRIDE and CAPEC apply
  to the current trust-boundary assessment. SBOM and SLSA/Provenance apply to
  distributable/CI artefacts. VEX becomes applicable for a known finding that
  needs disposition. SAMM is reviewed because TinyCalc is long-lived. CRA,
  NIS2, EU AI Act, DORA, BSI C3A and BSI C5 receive explicit project-scope
  decisions without legal or audit claims. OWASP Cheat Sheets, Proactive
  Controls and OpenSSF Scorecard are supporting references.
- **ASVS**: `N/A` for the local TUI without Web/API/HTTP/Auth service. Trigger:
  introduction of such a service.
- **AI-SBOM**: `N/A`; AI is development tooling only. Trigger: a shipped or
  operated model, dataset, inference service or AI runtime.
- **Zero Trust**: `N/A` for the local single-process TUI and unchanged
  architecture. Trigger: Cloud, remote, service or network architecture.
- **Supply chain**: Current SBOM, dependency audit and provenance posture are
  assessed. The feature adds no dependency. A vulnerability blocks delivery;
  VEX cannot waive a shipped known vulnerability.
- **Presets**: All 13 enabled presets are inventoried:
  `security-governance` 0.6.2, `secure-development-assurance-governance` 0.1.2,
  `architecture-governance` 0.5.2, `isaqb-architecture-governance` 0.2.2,
  `a11y-governance` 0.4.3, `cross-platform-governance` 0.2.2,
  `agent-parity-governance` 0.4.2, `model-routing-governance` 0.1.4,
  `intake-authoring-governance` 0.3.1, `intake-review-governance` 0.2.1,
  `intake-sequencing-governance` 0.2.3, `autonomous-run-governance` 0.4.1 and
  `parallel-autonomous-run-governance` 0.2.6. Command-specific `N/A` cases are
  recorded; installation alone grants no authority.
- **Security-first**: No credentials, token values, agent logs, runtime state,
  history database or private absolute path enters the delivery set.
- **A11Y and language**: New reader-facing Markdown is German first and English
  second, CEFR B2, semantic and text-first. A manual screenreader/text-browser
  oriented review checks headings, tables, link text and non-colour meaning.
  No DocFX source or generated site changes, so DocFX regeneration is `N/A`;
  trigger is a navigation or generated-doc change.
- **Public API and comments**: No public API or product logic changes. XML docs,
  CS1591 and didactic code-comment updates are `N/A`; trigger is product code.
- **TDD/coverage**: Product-code TDD and changed-code coverage are `N/A` because
  no product code changes. Evidence work still follows RED (missing matrix),
  GREEN (complete matrix) and regression. Any later product edit restores the
  70% minimum and 80% target.
- **Statistics**: `docs/project-statistics.md` is updated using Methodology 2,
  80 manual and 125 Thorsten-Solo lines/workday. Renderer `-CheckOnly` must pass.
- **Agent parity**: No shared agent rule changes are planned; all five guidance
  files remain unchanged. A real shared-rule change would require an atomic
  five-surface update.
- **Documentation Impact**: `UpdateRequired`. Audiences are project owners,
  reviewers, developers and apprentices. Canonical source is the accepted
  RL-SE intake, owned by project/security review. Affected families are
  Spec-Kit, the new assurance context, security index or specific existing
  evidence only when justified, closeout/PR documentation and statistics.
  Language partner is inline DE/EN. Platform proof is macOS plus CI Linux and
  Windows. Distribution is repository-internal; Home sync is `N/A`. Navigation
  changes only if the new context is otherwise undiscoverable. Re-evaluate on
  baseline, architecture, product, distribution or navigation change.

### Post-design re-check

The schema makes identity, status transitions, required fields and
Human-only boundaries explicit. The validator design is repository-local and
cross-platform. No unresolved constitutional exception or complexity waiver
remains.

## Project Structure

### Documentation and evidence created by this feature

```text
specs/004-rl-se-self-assessment/
├── spec.md
├── plan.md
├── research.md
├── data-model.md
├── quickstart.md
├── tasks.md
├── autonomous-run-evidence.md
├── autonomous-run-state.json
├── checklists/
│   ├── requirements.md
│   ├── plan-review.md
│   └── analyze-remediation.md
├── evidence/
│   ├── evidence-index.md
│   ├── accepted-premerge.json
│   └── postmerge.json
└── contracts/
    ├── assessment-matrix.schema.json
    └── autonomous-run-gate-requirements.json

docs/security/secure-development/2026-09-05-rl-se-self-assessment/
├── baseline.json
├── deltas/rl-se-assessment.json
├── closure.json
├── image-impact.json
├── assessment-matrix.json
└── evidence-matrix.md

docs/
├── PR_TEXT_RL_SE_SELF_ASSESSMENT.md
├── documentation-impact/rl-se-self-assessment.json
└── project-statistics.md

scripts/
├── validate-rl-se-assessment.ps1
└── validate-rl-se-assessment.sh

.github/workflows/
└── ci.yml                  # adds the assessment contract to Linux/Windows CI
```

### Existing product and test structure (validated, not modified)

```text
src/
├── MicroCalc.Core/
└── MicroCalc.Tui/

tests/
├── MicroCalc.Core.Tests/
└── MicroCalc.Tui.Tests/

MicroCalc.sln
Directory.Build.props
```

**Structure Decision**: Keep the assessment beside other security evidence and
its executable contract under repository `scripts/`. The PowerShell entrypoint
implements the typed validation; Bash delegates to the same deterministic
contract. The existing Linux/Windows CI matrix invokes the matching entrypoint.
No product source or xUnit test file is changed; `ci.yml` is the sole approved
workflow delta.

## Implementation Strategy

### Phase 0 - Source and decision research

1. Freeze the baseline manifest hash, controlled document hashes, checklist ID
   set and 13-preset inventory.
2. Decide canonical source precedence, five-disposition/two-axis mapping,
   Human-only handling, evidence strength and regulatory boundaries.
3. Record all decisions in [research.md](research.md).

### Phase 1 - Contract and evidence design

1. Define the machine-readable matrix schema in
   [assessment-matrix.schema.json](contracts/assessment-matrix.schema.json).
2. Define entities, invariants and transitions in [data-model.md](data-model.md).
3. Declare all delivery gates in
   [autonomous-run-gate-requirements.json](contracts/autonomous-run-gate-requirements.json).
4. Document the reproducible operator path in [quickstart.md](quickstart.md).

### Phase 2 - RED/GREEN vertical slice

1. Create the evidence directory and row-contract tests before the real matrix.
2. For every run, create a fresh temporary directory and validate a guaranteed
   missing path inside it; require a non-zero exit and named ownership failure.
   This RED proof remains repeatable after the production matrix exists.
3. Test the isolated row-validation function with one valid row and focused
   invalid duplicate/status/path/Human-only cases. The production document
   schema always remains fixed at exactly 157 rows; no one-row document is
   called schema-valid.
4. Broaden deterministically to the complete 157-row production matrix and
   require both local entrypoints plus Linux/Windows CI to pass.
5. Preserve RED and GREEN commands, outputs and hashes in run evidence.

### Phase 3 - Complete assessment

1. Generate one row per canonical ID from individual checklist headings.
2. Review each row against repository evidence; do not infer fulfillment from
   file existence alone.
3. Map every relevant checkpoint of all 13 installed presets to a concrete
   matrix/report reference or an explicit, triggered non-applicability in
   `evidence/evidence-index.md`; an inventory entry alone is insufficient.
4. Create baseline, delta, closure and image-impact gate evidence compatible
   with Assurance Governance 0.1.2.
5. Run `speckit-secure-development-status`, perform the independent
   `speckit-secure-development-review`, and require a truthful successful
   technical result. Human decisions stay separate and open unless actual
   authority/evidence exists.
6. Produce the bilingual report, explicit follow-up list and documentation
   impact record. Update the security index only as needed for discoverability.

### Phase 4 - Regression and delivery

1. Validate matrix/schema, assurance gates, intake/series evidence, installed
   presets, documentation impact, statistics and secret/homogeneity checks.
2. Increment the repository build counter before every `dotnet build` or
   `dotnet test`; align `Version`, `AssemblyVersion` and `FileVersion` with
   feature minor 4 and current feature commit count before commit/push.
3. Restore, build, test and smoke the unchanged product locally; rely on exact
   CI job evidence for Linux/Windows and required platform gates.
4. Validate the exact delivery set before each commit, stage only intended
   paths, use focused conventional commits and verify the repository-required
   co-author trailer if current constitution requires it.
5. Open one focused PR, converge all checks and actionable review threads on
   the exact head, then produce and validate the temporary schema-2.0 PreMerge
   snapshot `/tmp/tinycalc-004-rlse/gates/premerge.json` with one Primary row
   per gate.
6. Merge normally when possible. Use approved admin bypass only if the sole
   remaining blocker is formal. Verify provider merge commit and parents,
   fast-forward local `main`, then create the pre-named single causal
   evidence-only closeout required for tracked
   `evidence/accepted-premerge.json` and `evidence/postmerge.json`. Validate
   schema-2.0 PostMerge against the accepted PreMerge hash and make no product
   delta. Provider verification after that closeout remains read-only in the
   ignored runtime `closeout-provider-evidence.json`.
7. Mark the run complete only after terminal closeout fields, final read-only
   validation and branch cleanup. Then, and only then, GSDB may start.

## Complexity Tracking

No constitution violation is required. The small paired validator is justified
because existing repository tools do not enforce the feature-specific mapping
between all 157 canonical IDs, five dispositions, both GSDB status axes and the
full per-row evidence contract. It remains evidence tooling and does not change
the product runtime.
