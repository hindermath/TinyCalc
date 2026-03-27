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

## Documentation & Language Guidelines
- Documentation and didactic comments must be bilingual: German block first, English block second.
- Both language blocks should target CEFR B2 readability for trainees.
- Public APIs must include complete XML documentation (`<summary>`, `<param>`, `<returns>`, `<exception>` where applicable).
- Do not globally suppress CS1591; missing public XML docs must be fixed.
- If API signatures or XML comments change, regenerate DocFX output in the same change.

## Commit & Pull Request Guidelines
Recent history follows Conventional Commit-style prefixes (`docs:`, `test:`, `chore:`). Keep commits focused and imperative.

For contributions:
- Create a new branch named either `codex/<short-topic>` or, for Spec-Kit-driven work, `NNN-short-description`.
- Open one focused PR per topic.
- Add/update a PR description file in `docs/` (for example, `docs/PR_TEXT_<TOPIC>.md`).
- Complete the PR template: problem, solution, risks, and test plan.
- Include screenshots/terminal captures when TUI behavior changes.

## Build Versioning

- Repo-wide assembly version fields live in `Directory.Build.props` and MUST keep `Version`, `AssemblyVersion`, and `FileVersion` aligned for all projects.
- The scheme is `Major.Minor.Patch.Build`.
- `Minor` = current Spec-Kit feature/branch number, interpreted numerically as the canonical PR number for versioning (`002` -> `2`) and used immediately even before a GitHub PR exists.
- `Patch` = current commit count in that feature/PR branch after committing the current change.
- `Build` = manual build counter incremented by the bot before every `dotnet build` or `dotnet test`.
- Before any commit or push on a numbered Spec-Kit branch, the repo-wide version fields in `Directory.Build.props` MUST be aligned to this scheme.

## Project Statistics

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, and `.github/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Each update must record branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.
