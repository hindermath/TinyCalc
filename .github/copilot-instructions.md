# MicroCalc – Copilot Instructions

## Build & Test

```bash
# Restore
dotnet restore MicroCalc.sln

# Build (CI-aligned)
dotnet build MicroCalc.sln --configuration Release --no-restore

# Run all tests (CI-aligned)
dotnet test MicroCalc.sln --configuration Release --no-build

# Run a single test class
dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj --configuration Release --filter "FullyQualifiedName~FormulaGoldenTests"

# Smoke run (non-interactive, validates TUI without Terminal.Gui window)
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke

# Start interactive TUI
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

CI runs on `main` and all `codex/**`, `claude/**`, `gemini/**`, `copilot/**` branches using the Release configuration.

## Architecture

Two projects, strict dependency direction: `MicroCalc.Core` has no UI dependency; `MicroCalc.Tui` references Core.

**`MicroCalc.Core`** – all spreadsheet logic:
- `Engine/MicroCalcEngine` – single façade for all operations (`EditCell`, `Recalculate`, `FormatRange`, `Move`, `Clear`). Call `EditCell` to store a value; it triggers `Recalculate` automatically when `AutoCalc` is on.
- `Formula/FormulaEvaluator` – evaluates an expression string against a `Spreadsheet`. Internally delegates to a private `Parser` (recursive-descent). Cyclic reference detection uses a `HashSet<CellAddress>` per evaluation call.
- `Model/Spreadsheet` + `Model/Cell` – the data grid. Grid bounds are fixed constants in `SpreadsheetSpec` (columns A–G, 21 rows).
- `IO/SpreadsheetJsonStorage` – save/load to `.mcalc.json`. No legacy `.MCS` format.

**`MicroCalc.Tui`** – Terminal.Gui front end. `Program.cs` is the entry point; it checks for `--smoke` and delegates to `TuiSmokeRunner` before touching Terminal.Gui.

**Legacy reference files** at repo root (`CALC.PAS`, `CALC.INC`, `CALC.HLP`) are Pascal source and help content kept for behavior parity; they are not compiled.

## Key Conventions

### Formula syntax (non-obvious)
- Range sum uses `>` as the operator: `A1>B5` means "sum A1 through B5", not a comparison.
- No `SUM()` function — use the `A1>B5` syntax instead.
- Supported functions: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`.
- Error messages from the parser are in German (the codebase language for user-facing strings).

### `CellStatusFlags` is a `[Flags]` enum — check with `HasFlag`
- `Text` = plain string cell
- `Constant` = numeric or expression cell (stored value)
- `Formula` = contains a cell reference or range (recalculated on `Recalculate`)
- `OverWritten` = cell is visually occupied by text overflow from the cell to its left
- `Locked` = cell blocked because the preceding cell uses an expanded field width

A cell can simultaneously be `Constant | Formula` (a formula that has been evaluated).

### Text overflow
When a text cell's content exceeds `DefaultFieldWidth` (10), `MicroCalcEngine.ApplyTextOverflow` marks adjacent right-hand cells as `OverWritten`. `ClearOverwrittenTrail` reverses this when the source cell is edited. Always call through `EditCell`, not by mutating `Cell` directly.

### `SpreadsheetSpec` constants
Fixed grid: columns `A`–`G` (7 columns), 21 rows, 147 total cells. Cell input capped at 70 characters. Default field width 10, default decimals 2. All bounds checks go through `SpreadsheetSpec.IsColumnInRange` / `IsRowInRange`.

### Testing pattern
- `FormulaGoldenTests` — `[Theory]`/`[MemberData]` table of expression → expected value. Add new cases here for any formula behaviour change.
- `MicroCalcEngineTests` — integration-style tests through the engine façade.
- `TuiSmokeTests` — calls `TuiSmokeRunner.Run(...)` which exercises help loading and basic rendering without a Terminal.Gui window.

### Branching & PRs
- Work branches: `copilot/<short-topic>`
- Add a PR description file: `docs/PR_TEXT_<TOPIC>.md`
- Commits follow Conventional Commit prefixes: `feat:`, `fix:`, `test:`, `docs:`, `chore:`

### Code style (`.editorconfig`)
- `*.cs`: 4-space indent; `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space indent
- UTF-8, LF line endings, final newline, no trailing whitespace
- `PascalCase` for types and public members; `_camelCase` for private readonly fields
- Nullable reference types enabled — do not suppress without reason
