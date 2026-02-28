<!--
Sync Impact Report
==================
Version change: N/A (raw template) → 1.0.0 (initial ratification)

Modified principles: N/A — initial fill-in; no prior principles existed.

Added sections:
  - Core Principles (I–V)
  - Technology Constraints
  - Development Workflow
  - Governance

Removed sections: N/A

Templates requiring updates:
  ✅ .specify/templates/plan-template.md — Constitution Check gate is already a
     generic placeholder ("Gates determined based on constitution file"); aligned
     with MicroCalc principles — no structural change needed.
  ✅ .specify/templates/spec-template.md — Generic; no MicroCalc-specific
     mandatory sections added that would require template changes.
  ✅ .specify/templates/tasks-template.md — Generic; task categories unchanged.
  ✅ .specify/templates/agent-file-template.md — Generic; no agent-specific
     (CLAUDE-only) language present; no update required.
  ✅ .specify/templates/checklist-template.md — Generic; no update required.
  ⚠  .specify/templates/commands/ — Directory contains no command files;
     no updates possible or required.

Follow-up TODOs: None — all placeholders resolved.
-->

# MicroCalc Constitution

## Core Principles

### I. Legacy Behavioral Fidelity

The port MUST preserve the behavioral contract of the original Borland MicroCalc Pascal
implementation (`CALC.PAS`, `CALC.INC`, `CALC.HLP`). Formula semantics, the A–G × 1–21
grid (147 cells), cell-type rules, navigation behavior, and help content MUST match the Pascal
reference. Any intentional deviation MUST be documented and justified in the relevant PR
description.

**Rationale**: The primary purpose of this project is to demonstrate a faithful, agentic legacy
port. Undocumented behavioral drift defeats that purpose and makes regression detection impossible.

### II. Layer Separation (NON-NEGOTIABLE)

`MicroCalc.Core` MUST have zero compile-time or runtime dependency on `MicroCalc.Tui` or any
Terminal.Gui type. All spreadsheet operations MUST be orchestrated through `MicroCalcEngine`.
UI code MUST NOT implement business logic; it MUST only call Core APIs and render the result.
New UI-only concerns (dialogs, keybindings, rendering) MUST remain exclusively in `MicroCalc.Tui`.

**Rationale**: Enforcing the Core/Tui boundary keeps domain logic independently testable and
prevents the historical mistake of mixing UI and domain code that made the original Pascal
codebase harder to port.

### III. Test-First Quality Gates (NON-NEGOTIABLE)

All new formula behaviors, engine operations, and bug fixes MUST be covered by xUnit tests before
the implementing code is merged. Formula golden tests MUST serve as the primary regression harness.
The full test suite MUST pass under `--configuration Release` in CI before any PR is merged.
The smoke runner (`--smoke` flag on `MicroCalc.Tui`) MUST pass as a non-interactive verification
gate. Tests MUST be written so they fail first, then pass after implementation.

**Rationale**: An untested port is an unreliable port. Regression coverage must be provable,
not assumed.

### IV. Minimal, Focused PRs

Each PR MUST address exactly one topic on a `codex/<short-topic>` branch. Large changes MUST be
decomposed into sequential, independently mergeable PRs. Every PR MUST include a description
document at `docs/PR_TEXT_<TOPIC>.md`. Force-pushes to `main` are prohibited. CI MUST be green
on the branch before a PR is opened.

**Rationale**: Small, reviewable PRs preserve the end-to-end agentic process narrative, allow CI
to catch regressions at the finest granularity, and keep the project history legible.

### V. Simplicity & YAGNI

No abstraction, pattern, or feature may be introduced without a clear, immediate requirement
traceable to the Pascal reference (`CALC.PAS`/`CALC.INC`) or an explicit, documented project
goal. Every deviation from the simplest possible implementation MUST be justified in the plan or
PR. Legacy `.MCS` import is explicitly out of scope and MUST NOT be added. New projects or
assemblies MUST NOT be created without written justification; the current four-project layout
(`Core`, `Tui`, `Core.Tests`, `Tui.Tests`) is the approved baseline.

**Rationale**: Over-engineering a port produces maintenance burden and obscures the teaching value
of the direct Pascal-to-C# translation.

## Technology Constraints

- **Runtime**: .NET 10 / C# 14 — no downgrade without an explicit, recorded decision.
- **UI Framework**: Terminal.Gui — no alternative TUI library may be introduced.
- **Test Framework**: xUnit — all test projects MUST use xUnit; mixing frameworks is prohibited.
- **Persistence**: JSON (`.mcalc.json`) is the sole supported save/load format.
- **CI Platform**: GitHub Actions (`.github/workflows/ci.yml`) — Release configuration only.
- **Code style** (governed by `.editorconfig`):
  - UTF-8 encoding, LF line endings, final newline required, no trailing whitespace.
  - C# files: 4-space indentation. `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space.
  - `PascalCase` for types and public members; `_camelCase` for private readonly fields.
  - Nullable reference types MUST be enabled project-wide; suppressions require written
    justification inline with the suppression pragma.

## Development Workflow

- **Branch naming**: All work branches MUST carry the prefix `codex/<short-topic>`.
- **CI alignment**: All `dotnet test` invocations MUST pass `--configuration Release`.
- **Help file resolution**: `CALC.HLP` MUST remain resolvable at both
  `src/MicroCalc.Tui/Resources/CALC.HLP` (bundled EmbeddedResource) and the repo root (legacy
  reference). Any path change MUST preserve both locations.
- **PR documentation**: Every PR MUST include a corresponding `docs/PR_TEXT_<TOPIC>.md`.
- **Incremental delivery**: Each `codex/*` branch MUST be independently buildable and testable
  before a PR is opened. No big-bang merges.
- **Smoke verification**: After each merge to `main`, the smoke run
  (`dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke`)
  MUST exit cleanly.

## Governance

This constitution supersedes all informal conventions and takes precedence over ad-hoc decisions.
Amendments MUST follow this procedure:

1. Open a `codex/constitution-<topic>` branch.
2. Update `.specify/memory/constitution.md` with the proposed change, increment the version
   per the versioning policy below, and set `LAST_AMENDED_DATE` to the amendment date.
3. Run the Sync Impact Report and update any affected templates listed therein.
4. Merge only after CI passes and the amendment is summarised in the PR description.

**Versioning policy**:
- MAJOR: Removal or redefinition of a principle that is backward-incompatible with existing code.
- MINOR: New principle or section added; materially expanded guidance.
- PATCH: Clarifications, wording corrections, or non-semantic refinements.

All PRs and agentic implementations MUST verify compliance with the Constitution Check gate in
`plan-template.md` before Phase 0 research begins and again after Phase 1 design.

**Version**: 1.0.0 | **Ratified**: 2026-02-28 | **Last Amended**: 2026-02-28
