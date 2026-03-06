<!--
Sync Impact Report
==================
Version change: 1.0.0 → 1.1.0

Modified principles:
  - I. Legacy Behavioral Fidelity → I. Didactic and Linguistic Clarity
  - III. Test-First Quality Gates (NON-NEGOTIABLE) → III. Test-First Quality Gates (NON-NEGOTIABLE)
    (materially expanded with explicit red-green expectations and trainee-facing traceability)

Added sections:
  - None

Removed sections:
  - None

Templates requiring updates:
  ✅ .specify/templates/plan-template.md — Constitution Check replaced with explicit gates.
  ✅ .specify/templates/spec-template.md — Added mandatory Documentation & Learning Requirements.
  ✅ .specify/templates/tasks-template.md — Test tasks made mandatory and doc tasks expanded.
  ⚠  .specify/templates/commands/ — Directory does not exist; no command template updates possible.

Runtime guidance docs requiring updates:
  ✅ README.md — Added constitutional documentation and bilingual-language requirements.
  ✅ AGENTS.md — Added bilingual documentation and XML/docfx compliance guidance.
  ✅ CLAUDE.md — Added bilingual documentation and XML/docfx compliance guidance.
  ✅ GEMINI.md — Added bilingual documentation and XML/docfx compliance guidance.
  ✅ .github/copilot-instructions.md — Added bilingual documentation and XML/docfx compliance guidance.
  ✅ specs/001-project-context/quickstart.md — Checked; no constitution-reference text to update.

Follow-up TODOs:
  - None.
-->

# MicroCalc Constitution

## Core Principles

### I. Didactic and Linguistic Clarity

The project is a learning artifact for German-speaking and international trainees. All
user-facing and developer-facing documentation MUST be bilingual: German block first,
English block second. Language in both blocks MUST target CEFR B2 level so non-native
trainees can follow the full workflow. Code comments that explain decisions, trade-offs,
and constraints MUST also be bilingual in the same order. Explanations MUST prioritize
clarity over cleverness.

All public APIs MUST include complete XML documentation (`<summary>`, `<param>`,
`<returns>`, and `<exception>` where applicable; `<remarks>` and `<example>` when
instructionally useful). Missing XML documentation for public API members is treated as
an error; CS1591 MUST NOT be globally suppressed. When API signatures or XML comments
change, DocFX output MUST be regenerated in the same commit/PR.

**Rationale**: This repository trains apprentices. Didactic value and language accessibility
are part of functional correctness for the project purpose.

### II. Layer Separation (NON-NEGOTIABLE)

`MicroCalc.Core` MUST have zero compile-time or runtime dependency on `MicroCalc.Tui` or any
Terminal.Gui type. All spreadsheet operations MUST be orchestrated through `MicroCalcEngine`.
UI code MUST NOT implement business logic; it MUST only call Core APIs and render the result.
New UI-only concerns (dialogs, keybindings, rendering) MUST remain exclusively in
`MicroCalc.Tui`.

**Rationale**: Enforcing the Core/Tui boundary keeps domain logic independently testable and
prevents the historical mistake of mixing UI and domain code that made the original Pascal
codebase harder to port.

### III. Test-First Quality Gates (NON-NEGOTIABLE)

All new formula behaviors, engine operations, bug fixes, and documentation-driven API
changes MUST follow a red-green workflow: tests are created first, fail first, and then
pass after implementation. Core behavior MUST be covered by xUnit tests before merge.
Formula golden tests remain the primary regression harness. The full suite MUST pass in
`Release` configuration in CI, and the TUI smoke runner (`--smoke`) MUST pass as a
non-interactive gate.

**Rationale**: An untested port is an unreliable port. Trainees must see a reproducible
TDD flow, not post-hoc test additions.

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
- **Documentation Generator**: DocFX CLI (`docfx`) MUST be used after API/XML documentation changes.
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
- **Documentation compliance review**: Every PR MUST include explicit review of bilingual
  (DE then EN, CEFR B2) and XML documentation requirements.
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
3. Run the Sync Impact Report and update any affected templates and runtime guidance files.
4. Merge only after CI passes and the amendment is summarised in the PR description.

Agent runtime guidance MUST remain aligned with this constitution in:
- `AGENTS.md`
- `CLAUDE.md`
- `GEMINI.md`
- `.github/copilot-instructions.md`

**Versioning policy**:
- MAJOR: Removal or redefinition of a principle that is backward-incompatible with existing code.
- MINOR: New principle or section added; materially expanded guidance.
- PATCH: Clarifications, wording corrections, or non-semantic refinements.

All PRs and agentic implementations MUST verify compliance with the Constitution Check gate in
`plan-template.md` before Phase 0 research begins and again after Phase 1 design.

**Version**: 1.1.0 | **Ratified**: 2026-02-28 | **Last Amended**: 2026-03-06
