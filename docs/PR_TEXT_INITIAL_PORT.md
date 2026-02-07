## Title

feat: initial .NET 10 MicroCalc port with Terminal.Gui

## Summary

This PR ports the Borland MicroCalc sample (`CALC.PAS`, `CALC.INC`, `CALC.HLP`) to a modern C#/.NET 10 implementation with Terminal.Gui.

## What is included

- New solution structure:
  - `src/MicroCalc.Core`
  - `src/MicroCalc.Tui`
  - `tests/MicroCalc.Core.Tests`
- Spreadsheet core model for classic 7x21 grid (A..G, 1..21)
- Cell state model (`Constant`, `Formula`, `Text`, `OverWritten`, `Locked`, `Calculated`)
- Formula evaluator with support for:
  - Operators: `+`, `-`, `*`, `/`, `^`
  - Cell references: e.g. `A1`
  - Range sums: e.g. `A1>B5`
  - Functions: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`
- Recalculate + AutoCalc behavior
- Text overflow and lock behavior aligned with original concept
- JSON persistence (save/load)
- Text print/export
- Terminal.Gui app with:
  - Grid rendering
  - Keyboard navigation
  - Cell editing dialogs
  - Command palette via `/`
  - Help viewer with page navigation
- `CALC.HLP` integrated as runtime resource
- Migrated help documentation in `docs/help/microcalc-help.md`
- CI pipeline for restore/build/test (`.github/workflows/ci.yml`)

## Validation

### Automated

- `dotnet build MicroCalc.sln` passes
- `dotnet test MicroCalc.sln` passes (`6` tests)

### Manual

- App starts and renders grid
- Editing numeric/text/formula works
- Recalculate and AutoCalc toggling works
- Save/Load and print export work
- Help dialog loads and page navigation works

## Known limitations / follow-ups

- No legacy `.MCS` binary import yet (new JSON format is used)
- No full TUI integration test suite yet

## Risk

Main regression risk is formula-compatibility edge cases versus historical Pascal implementation; mitigated by unit tests and clear follow-up scope for golden test expansion.
