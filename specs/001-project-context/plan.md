# Implementation Plan: Phase 2 – Extended Formula Library

**Branch**: `001-project-context` | **Date**: 2026-02-28 | **Spec**: [spec.md](spec.md)
**Input**: Feature specification from `/specs/001-project-context/spec.md`

## Summary

Extend MicroCalc's formula engine with 6 new functions — MIN, MAX, AVERAGE, COUNT, IF, ROUND —
by modifying a single existing source file: `src/MicroCalc.Core/Formula/FormulaEvaluator.cs`.
The change is confined to the Core layer; no TUI code changes are required beyond updating the
help document at `docs/help/microcalc-help.md`. The approach: (1) refactor `SumRange` into a
`CollectRangeValues` helper that returns individual cell values; (2) add a lookahead guard to
disambiguate `>` as range vs. comparison inside IF conditions; (3) extend
`ParseIdentifierBasedFactor` with new function dispatch; (4) add `ParseIfExpression` and
`ParseRoundExpression` for multi-argument functions.

## Technical Context

**Language/Version**: C# 12 / .NET 10
**Primary Dependencies**: xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature)
**Storage**: N/A — JSON persistence format unchanged; new functions evaluated at runtime from
the stored `Contents` string on each `Recalculate()` call
**Testing**: xUnit, `dotnet test MicroCalc.sln --configuration Release`
**Target Platform**: Cross-platform terminal (macOS, Linux, Windows)
**Project Type**: Domain library extension (MicroCalc.Core only)
**Performance Goals**: Full 147-cell recalculation must remain imperceptible (<100ms); the new
functions add O(n) range traversal identical to the existing range-sum path
**Constraints**: No new projects or assemblies; four-project layout preserved; estimated
~150–200 net new lines of code in FormulaEvaluator.cs
**Scale/Scope**: 6 new functions; 2 new parser paths (multi-arg: IF, ROUND); 1 new helper
method (CollectRangeValues); range of impact: FormulaEvaluator.cs + test additions

## Constitution Check

*GATE: Must pass before Phase 0 research. Re-check after Phase 1 design.*

| Principle | Status | Notes |
|-----------|--------|-------|
| I. Legacy Behavioral Fidelity | ✅ PASS | Extension beyond Pascal original is documented and justified in spec §Background. Existing formula semantics (`>` range operator, all 10 functions) are fully preserved. |
| II. Layer Separation (NON-NEGOTIABLE) | ✅ PASS | All changes confined to `MicroCalc.Core/Formula/FormulaEvaluator.cs`. No Terminal.Gui type is introduced. MicroCalcEngine is unchanged. |
| III. Test-First Quality Gates (NON-NEGOTIABLE) | ✅ PASS | FR-012 mandates golden tests written and failing before implementation code exists. FR-013 mandates no regressions. Full CI (Release) gate required. |
| IV. Minimal, Focused PRs | ✅ PASS | Implementation will use a `codex/extended-formula-library` branch. This speckit branch (`001-project-context`) is planning-only. |
| V. Simplicity & YAGNI | ✅ PASS | No new projects, patterns, or abstractions. Single-file Core change. CollectRangeValues is a justified refactor of existing SumRange logic, not a new pattern. |

**Post-design re-check (Phase 1)**: All principles still pass. No violations detected.

## Project Structure

### Documentation (this feature)

```text
specs/001-project-context/
├── plan.md              # This file
├── research.md          # Phase 0 output
├── data-model.md        # Phase 1 output
├── quickstart.md        # Phase 1 output
├── contracts/
│   └── formula-grammar.md   # Phase 1 output
└── tasks.md             # Phase 2 output (/speckit.tasks)
```

### Source Code (repository root)

```text
src/
└── MicroCalc.Core/
    └── Formula/
        └── FormulaEvaluator.cs        ← single file modified

tests/
└── MicroCalc.Core.Tests/
    └── FormulaGoldenTests.cs          ← new test methods added (test-first)

docs/
└── help/
    └── microcalc-help.md              ← 6 new function entries added
```

**Structure Decision**: Option 1 (single project). No new files in `src/` — the feature is
purely additive to one existing file. Test additions go into the existing
`FormulaGoldenTests.cs` (new `[Theory]` data rows and new test methods).

## Complexity Tracking

> No Constitution Check violations — table not required.
