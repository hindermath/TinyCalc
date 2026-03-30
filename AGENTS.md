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
- Large normative documents such as `Pflichtenheft*.md` and `Lastenheft*.md` may use a synchronized English sidecar with suffix `.EN.md` instead of an oversized inline-bilingual file; the German version remains canonical unless explicitly marked otherwise.
- Public APIs must include complete XML documentation (`<summary>`, `<param>`, `<returns>`, `<exception>` where applicable).
- Do not globally suppress CS1591; missing public XML docs must be fixed.
- If API signatures or XML comments change, regenerate DocFX output in the same change.

## Commit & Pull Request Guidelines
Recent history follows Conventional Commit-style prefixes (`docs:`, `test:`, `chore:`). Keep commits focused and imperative.

For contributions:
- Create a new branch named either `codex/<short-topic>` or, for Spec-Kit-driven work, `NNN-short-description`.
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<Thema>.<feature-branch>.md` so the delivered requirement scope stays traceable in the repository.
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
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; do not append later top-level sections after it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanation directly adjacent to its matching ASCII diagram group.
- When progression across an X-axis improves comprehension, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must not rely on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must record branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Inclusion & Accessibility

- Follow `Programmierung #include<everyone>`: learner-facing guides, statistics, and generated HTML/API documentation must stay usable on Braille displays, with screen readers, and in text browsers.
- Prefer semantic headings, lists, tables, and ASCII/text-first diagrams; do not encode essential meaning only through color, layout, or pointer-only affordances.
- Treat WCAG 2.2 conformance level AA as the concrete review baseline for generated HTML documentation, especially for page language, bypass blocks, keyboard focus visibility, non-text contrast, and readable landmark structure.
- If `docfx` output is regenerated, follow it with a text-oriented accessibility review, preferably with Playwright + `@axe-core/playwright` and a `lynx` cross-check.
- Recommended A11y toolchain for DocFX-based repos: Node 24 LTS, `npm`, Playwright, `@axe-core/playwright`, and `lynx`.
- Treat bilingual CEFR-B2 delivery and the documented A11Y proof path as formal completion criteria for learner-facing documentation and active requirement artifacts.

## Shared Parent Guidance

- The shared parent file `/Users/thorstenhindermann/RiderProjects/AGENTS.md` intentionally stores only repo-spanning baseline rules.
- Keep repository-specific build, test, workflow, architecture, and feature guidance in this repository's own files; when both layers exist, the repository-local files are the more specific authority.
