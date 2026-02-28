# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

MicroCalc is a modern C#/.NET 10 port of the historical Borland MicroCalc Pascal spreadsheet example (`CALC.PAS`, `CALC.INC`, `CALC.HLP`). It uses Terminal.Gui for its TUI and demonstrates agentic AI-driven legacy porting. The original Pascal files at the repo root serve as behavioral reference for formula semantics, help content, and UI parity.

## Solution Structure

```
MicroCalc.sln
src/
  MicroCalc.Core/          # Domain logic — no UI dependencies
    Engine/                # MicroCalcEngine (orchestrates all spreadsheet operations)
    Formula/               # FormulaEvaluator + recursive-descent Parser
    Model/                 # Spreadsheet, Cell, CellAddress, SpreadsheetSpec, CellStatusFlags
    IO/                    # SpreadsheetJsonStorage, SpreadsheetPrinter
  MicroCalc.Tui/           # Terminal.Gui front end
    Program.cs             # Entry point; supports --smoke flag
    Help/                  # HelpDocument (loads CALC.HLP)
    Smoke/                 # TuiSmokeRunner (non-interactive verification)
    Resources/CALC.HLP     # Bundled help asset
tests/
  MicroCalc.Core.Tests/    # xUnit: MicroCalcEngineTests, FormulaGoldenTests
  MicroCalc.Tui.Tests/     # xUnit: TuiSmokeTests
```

**Key constants** (defined in `SpreadsheetSpec`): columns A–G, 21 rows (147 cells), cell input limit 70 chars, default field width 10.

## Build and Test Commands

```bash
# Restore
dotnet restore MicroCalc.sln

# Build (CI-aligned)
dotnet build MicroCalc.sln --configuration Release --no-restore

# Run all tests (CI-aligned)
dotnet test MicroCalc.sln --configuration Release --no-build

# Run single test class
dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj --configuration Release --filter "FullyQualifiedName~FormulaGoldenTests"

# Start interactive TUI
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj

# Smoke run (non-interactive CI check)
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

CI (`.github/workflows/ci.yml`) runs on `main` and all `codex/**` branches using Release configuration.

## Architecture: Core Layer

`MicroCalcEngine` is the single façade for all spreadsheet operations: `EditCell`, `Recalculate`, `FormatRange`, `Move`, `Clear`, and rendering helpers. It holds a `Spreadsheet` (the cell grid) and a `FormulaEvaluator`.

`FormulaEvaluator` uses a hand-rolled recursive-descent `Parser` (private nested class). Supported syntax:
- Arithmetic: `+`, `-`, `*`, `/`, `^`
- Cell reference: `A1`
- Range sum: `A1>B5` (using `>` as range operator, not `SUM()`)
- Functions: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`
- Cyclic reference detection via `HashSet<CellAddress>` per evaluation

`CellStatusFlags` is a `[Flags]` enum controlling cell type (`Text`, `Constant`, `Formula`, `Calculated`, `Locked`, `OverWritten`). Text overflow into adjacent cells is managed explicitly by `MicroCalcEngine`.

Save format is JSON (`.mcalc.json`); no legacy `.MCS` import.

## Branching and PR Conventions

- All work branches use the prefix `codex/<short-topic>`.
- One focused PR per topic; add a PR description file `docs/PR_TEXT_<TOPIC>.md`.
- Tests must pass under `--configuration Release` (not just Debug).
- When a test calls `dotnet run --no-build`, pass the build configuration explicitly.

## Code Style

Governed by `.editorconfig`:
- UTF-8, LF line endings, final newline, no trailing whitespace.
- `*.cs`: 4-space indentation; `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space indentation.
- C# conventions: `PascalCase` for types/public members, `_camelCase` for private readonly fields.
- Nullable reference types are enabled; do not suppress without reason.

## Help File Resolution

`CALC.HLP` must be resolvable at runtime. It lives both at `src/MicroCalc.Tui/Resources/CALC.HLP` (bundled as a resource) and at the repo root (legacy reference). Path changes must preserve both locations.

## Active Technologies
- C# 12 / .NET 10 + xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature) (001-project-context)
- N/A — JSON persistence format unchanged; new functions evaluated at runtime from (001-project-context)

## Recent Changes
- 001-project-context: Added C# 12 / .NET 10 + xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature)
