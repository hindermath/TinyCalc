# Repository Guidelines

## Project Structure & Module Organization
`MicroCalc.sln` is the solution entry point. Production code lives under `src/`:
- `src/MicroCalc.Core`: spreadsheet domain, engine, formula evaluation, and IO (`Engine/`, `Formula/`, `Model/`, `IO/`).
- `src/MicroCalc.Tui`: Terminal.Gui front end (`Program.cs`), help loading (`Help/`), smoke mode (`Smoke/`), and bundled help asset (`Resources/CALC.HLP`).

Tests live under `tests/`:
- `tests/MicroCalc.Core.Tests`
- `tests/MicroCalc.Tui.Tests`

Process and PR support docs are under `docs/`. Legacy Pascal reference files (`CALC.PAS`, `CALC.INC`, `CALC.HLP`) stay at repo root for behavior parity checks.

## Build, Test, and Development Commands
- `dotnet restore MicroCalc.sln`: restore all dependencies.
- `dotnet build MicroCalc.sln --configuration Release --no-restore`: CI-aligned build.
- `dotnet test MicroCalc.sln --configuration Release --no-build`: run xUnit suites in CI mode.
- `dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj`: start interactive TUI app.
- `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke`: run non-interactive smoke checks.

## Coding Style & Naming Conventions
Follow `.editorconfig`:
- UTF-8, LF, final newline, trimmed trailing whitespace.
- 4 spaces for `*.cs`; 2 spaces for `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.yaml`, `*.json`.

C# conventions in this repo:
- `PascalCase` for types and public members.
- `_camelCase` for private readonly fields.
- Keep nullable reference types enabled; avoid disabling warnings without reason.

## Testing Guidelines
Use xUnit (`Microsoft.NET.Test.Sdk`, `xunit`, `coverlet.collector`). Name test files/classes with `*Tests` (for example, `MicroCalcEngineTests`, `TuiSmokeTests`). Add or update tests for every behavior change, especially formula evaluation and recalc flows. No hard coverage threshold is enforced, but regression-focused tests are expected before PR.

## Commit & Pull Request Guidelines
Recent history follows Conventional Commit-style prefixes (`docs:`, `test:`, `chore:`). Keep commits focused and imperative.

For contributions:
- Create a new branch named `codex/<short-topic>`.
- Open one focused PR per topic.
- Add/update a PR description file in `docs/` (for example, `docs/PR_TEXT_<TOPIC>.md`).
- Complete the PR template: problem, solution, risks, and test plan.
- Include screenshots/terminal captures when TUI behavior changes.
