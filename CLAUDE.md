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

- All work branches use either the agent branch form `codex/<short-topic>` or the numbered Spec-Kit form `NNN-short-description`.
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<topic>.<feature-branch>.md` so the delivered scope stays traceable.
- One focused PR per topic; add a PR description file `docs/PR_TEXT_<TOPIC>.md`.
- Tests must pass under `--configuration Release` (not just Debug).
- When a test calls `dotnet run --no-build`, pass the build configuration explicitly.

## Repo Version Scheme

`Directory.Build.props` carries the repo-wide `Version`, `AssemblyVersion`, and `FileVersion` values for all projects using `Major.Minor.Patch.Build`:
- `Minor` = current Spec-Kit feature/branch number, interpreted numerically as the canonical PR number for versioning (`002` -> `2`) and used immediately even before a GitHub PR exists
- `Patch` = current commit count in that feature/PR branch (after committing the current change)
- `Build` = manual build counter incremented before every `dotnet build` or `dotnet test`

Align the three version fields in `Directory.Build.props` whenever a commit is created or the branch is updated on a numbered Spec-Kit branch, before pushing.

## Code Style

Governed by `.editorconfig`:
- UTF-8, LF line endings, final newline, no trailing whitespace.
- `*.cs`: 4-space indentation; `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space indentation.
- C# conventions: `PascalCase` for types/public members, `_camelCase` for private readonly fields.
- Nullable reference types are enabled; do not suppress without reason.

## Documentation & Language Rules

- Documentation and didactic comments must be bilingual: German first, English second.
- Write both language blocks at CEFR B2 readability so trainees can follow the codebase.
- Large normative documents such as `Pflichtenheft*.md` and `Lastenheft*.md` may use a synchronized English sidecar with suffix `.EN.md` instead of an oversized inline-bilingual file; the German version remains canonical unless explicitly marked otherwise.
- Public API changes must include complete XML docs (`<summary>`, `<param>`, `<returns>`,
  `<exception>` where applicable).
- Do not suppress CS1591 globally; missing public XML docs are treated as errors.
- If API signatures or XML comments change, regenerate DocFX output in the same PR/commit.

## Help File Resolution

`CALC.HLP` must be resolvable at runtime. It lives both at `src/MicroCalc.Tui/Resources/CALC.HLP` (bundled as a resource) and at the repo root (legacy reference). Path changes must preserve both locations.

## Active Technologies
- C# 14 / .NET 10 + xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature) (001-project-context)
- N/A — JSON persistence format unchanged; new functions evaluated at runtime from (001-project-context)

## Recent Changes
- 001-project-context: Added C# 14 / .NET 10 + xUnit 2.x (tests); Terminal.Gui (TUI — untouched by this feature)

## Project Statistics

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, and `.github/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; no later top-level section should follow it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them together with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanation directly adjacent to its matching ASCII diagram group.
- When the data benefits from progression across an X-axis, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must stay understandable without relying on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must capture branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Inclusion & Accessibility

- **`Programmierung #include<everyone>`** — Diese Lernbeispiele richten sich an Azubis (Fachinformatiker AE/SI) mit Deutsch und Englisch als Arbeitssprachen sowie an sehbehinderte Lernende, die mit Braille-Displays, Screen-Readern oder Textbrowsern arbeiten. Barrierefreiheit ist kein Nice-to-have, sondern Pflichtanforderung. Learner-facing guides, statistics, and generated HTML/API documentation must stay usable on Braille displays, with screen readers, and in text browsers.
- Prefer semantic headings, lists, tables, and ASCII/text-first diagrams; do not encode essential meaning only through color, layout, or pointer-only affordances.
- Treat WCAG 2.2 conformance level AA as the concrete review baseline for generated HTML documentation, especially for page language, bypass blocks, keyboard focus visibility, non-text contrast, and readable landmark structure.
- If `docfx` output is regenerated, follow it with a text-oriented accessibility review, preferably with Playwright + `@axe-core/playwright` and a `lynx` cross-check.
- Recommended A11y toolchain for DocFX-based repos: Node 24 LTS, `npm`, Playwright, `@axe-core/playwright`, and `lynx`.
- Treat bilingual CEFR-B2 delivery and the documented A11Y proof path as formal completion criteria for learner-facing documentation and active requirement artifacts.

## Shared Parent Guidance

- The shared parent file `/Users/thorstenhindermann/RiderProjects/AGENTS.md` intentionally stores only repo-spanning baseline rules.
- Keep repository-specific build, test, workflow, architecture, and feature guidance in this repository's own files; when both layers exist, the repository-local files are the more specific authority.
<!-- claude-init-done -->

## Hinweise / Notes

- Diese Datei ergaenzt die projektspezifische Dokumentation mit agentischen Arbeitsregeln.
- This file complements the project-specific documentation with agent-oriented working rules.
