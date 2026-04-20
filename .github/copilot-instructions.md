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
# Always pass --configuration explicitly with --no-build; CI uses Release
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke

# Start interactive TUI
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

CI runs on `main` and all `codex/**` branches using the Release configuration.

`Directory.Build.props` carries the repo-wide `Version`, `AssemblyVersion`, and `FileVersion` values for all projects using `Major.Minor.Patch.Build`:
- `Minor` = current Spec-Kit feature/branch number, interpreted numerically as the canonical PR number for versioning (`002` -> `2`) and used immediately even before a GitHub PR exists
- `Patch` = current commit count in that feature/PR branch (after committing the current change)
- `Build` = manual build counter incremented before every `dotnet build` or `dotnet test`

On numbered Spec-Kit branches, align those three version fields before pushing.

## Architecture

Two production projects plus two test projects, strict dependency direction:
`MicroCalc.Core` has no UI dependency; `MicroCalc.Tui` references Core.

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
- Supported functions: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`, `MIN`, `MAX`, `AVERAGE`, `COUNT`, `ROUND`, `IF`. Function names are case-insensitive.
- `IF(condition,trueVal,falseVal)` — conditions use `>` as greater-than comparison inside `IF`. Outside `IF`, `A1>B5` is a range sum, not a comparison.
- `ROUND(value,decimals)` — rounds to the given number of decimal places.
- Error messages from the parser are in German (the codebase language for user-facing strings).

### `CellStatusFlags` is a `[Flags]` enum — check with `HasFlag`
- `Text` = plain string cell
- `Constant` = numeric or expression cell (stored value)
- `Formula` = contains a cell reference or range (recalculated on `Recalculate`)
- `Calculated` = formula has been evaluated and has a current value
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
- Work branches: `codex/<short-topic>` or numbered Spec-Kit branches `NNN-short-description`
- When a dedicated feature branch has implemented the requirements of a Lastenheft, rename that file to `Lastenheft_<topic>.<feature-branch>.md` so the delivered scope stays traceable.
- Add a PR description file: `docs/PR_TEXT_<TOPIC>.md`
- Commits follow Conventional Commit prefixes: `feat:`, `fix:`, `test:`, `docs:`, `chore:`

### Documentation & language
- All code comments and documentation must be **bilingual: German block first, English block second**, both at CEFR B2 readability.
- Large normative documents such as `Pflichtenheft*.md` and `Lastenheft*.md` may use a synchronized English sidecar with suffix `.EN.md` instead of an oversized inline-bilingual file; the German version remains canonical unless explicitly marked otherwise.
- Public APIs require complete XML docs (`<summary>`, `<param>`, `<returns>`, `<exception>` where applicable). Do not suppress CS1591 globally — missing XML docs are treated as build errors.
- When API signatures or XML comments change, regenerate DocFX output in the same PR.

### TDD expectation
- For behavior changes, write tests first and make them fail (RED) before implementation.
- Implement against failing tests, then verify GREEN in `Release` configuration.

### Code style (`.editorconfig`)
- `*.cs`: 4-space indent; `*.csproj`, `*.sln`, `*.md`, `*.yml`, `*.json`: 2-space indent
- UTF-8, LF line endings, final newline, no trailing whitespace
- `PascalCase` for types and public members; `_camelCase` for private readonly fields
- Nullable reference types enabled — do not suppress without reason

## Project Statistics

- When shared AI-agent guidance, workflow conventions, or statistics methodology changes, review and update `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, and `.github/copilot-instructions.md` together when they are affected.
- Shared guidance must not be updated in only one of these files; any intentional agent-specific divergence must be documented in the same change.
- Maintain `docs/project-statistics.md` as the living statistics ledger for the repository.
- Update the file after each completed Spec-Kit implementation phase, after each agent-driven repository change, or when a refresh is explicitly requested.
- Within the `## Fortschreibungsprotokoll` table, keep entries in strict chronological order: oldest entry at the top, newest and most recently added entry at the bottom; entries with the same date keep their insertion order.
- Keep a final top-level `## Gesamtstatistik` block as the last section of `docs/project-statistics.md`; do not append later top-level sections after it.
- Inside that final `## Gesamtstatistik` block, maintain compact ASCII-only trend diagrams directly below the textual overall summary and refresh them with every statistics update; cover at least the artifact mix, the documented branch/phase curves, the documented acceleration factors from agentic AI plus Spec-Kit/SDD support, and a direct comparison between experienced-developer effort, Thorsten-solo effort, and the visible AI-assisted delivery window.
- Keep each short CEFR-B2 explanatory text directly adjacent to its matching ASCII diagram group.
- When the data benefits from progression across an X-axis, add simple ASCII X/Y charts as a second visualization layer; keep them approximate, readable in plain Markdown, and explained in CEFR-B2 language.
- Keep the statistics section plain-text friendly for Braille displays, screen readers, and text browsers; diagrams and explanations must stay understandable without relying on color or visual layout alone.
- When DocFX content, documentation navigation, or API presentation changes, validate representative `_site/` pages through a text-oriented review path, preferably with a local Playwright accessibility snapshot.
- Treat every successful `docfx` regeneration as requiring the matching text-oriented A11y smoke check in the same work item.
- Each update must capture branch or phase, observable work window, production/test/documentation line counts, main work packages, the conservative manual baseline of 80 manually created lines per workday across code, tests, and documentation, and the repo-specific Thorsten-Solo comparison baseline of 125 lines per workday for this Pascal-derived port.
- When effort is converted into months, use explicit assumptions such as 21.5 workdays per month and, if applicable, 30 vacation days per year through calendar year 2026 and 31 vacation days per year from calendar year 2027 onward under a TVoeD-style 5-day-week calendar.
- When reporting acceleration, compare both manual references against visible Git active days and label the result as a blended repository speedup rather than a stopwatch measurement.
- When hour values are shown, convert the day-based estimates with the TVoeD working-day baseline of `7.8 hours` (`7h 48m`) per day.

## Inclusion & Accessibility

- Follow `Programmierung #include<everyone>`: Diese Lernbeispiele richten sich an Azubis (Fachinformatiker AE/SI), die auf Deutsch und Englisch arbeiten, **sowie** an sehbehinderte Lernende, die Braille-Displays, Screen-Reader oder Textbrowser nutzen. Barrierefreiheit ist Pflichtanforderung, kein Nice-to-have. / *These learning examples target apprentices working in German and English, **and** visually impaired learners using Braille displays, screen readers, or text browsers. Accessibility is mandatory.*
- Prefer semantic headings, lists, tables, and ASCII/text-first diagrams; do not encode essential meaning only through color, layout, or pointer-only affordances.
- Treat WCAG 2.2 conformance level AA as the concrete review baseline for generated HTML documentation, especially for page language, bypass blocks, keyboard focus visibility, non-text contrast, and readable landmark structure.
- If `docfx` output is regenerated, follow it with a text-oriented accessibility review, preferably with Playwright + `@axe-core/playwright` and a `lynx` cross-check.
- Recommended A11y toolchain for DocFX-based repos: Node 24 LTS, `npm`, Playwright, `@axe-core/playwright`, and `lynx`.
- Treat bilingual CEFR-B2 delivery and the documented A11Y proof path as formal completion criteria for learner-facing documentation and active requirement artifacts.

## Workspace Baseline (vollständig aus `RiderProjects/.github/copilot-instructions.md`)

Diese Regeln gelten für alle Repositories in diesem Workspace. Projektspezifische Regeln in dieser Datei haben Vorrang, wenn sie konkreter sind. GitHub Copilot liest keine übergeordneten `copilot-instructions.md`-Dateien automatisch; daher sind die Workspace-Regeln hier vollständig eingebettet.

### Dokumentation
- Leitprinzip: `Programmierung #include<everyone>` — Diese Lernbeispiele richten sich an Azubis (Fachinformatiker AE/SI), die auf Deutsch und Englisch arbeiten, **sowie** an sehbehinderte Lernende, die Braille-Displays, Screen-Reader oder Textbrowser nutzen. Barrierefreiheit ist Pflichtanforderung, kein Nice-to-have. / *These learning examples target apprentices working in German and English, **and** visually impaired learners using Braille displays, screen readers, or text browsers. Accessibility is mandatory.*
- Deutsch und Englisch zielen beide auf CEFR-B2-Lesbarkeit; Reihenfolge: **Deutsch zuerst, Englisch danach**.
- **Die deutsche Fassung ist kanonisch**, außer dieses Repository markiert eine andere Sprache explizit als primär.
- Große normative Dokumente (`Pflichtenheft*.md`, `Lastenheft*.md`) verwenden eine synchronisierte `.EN.md`-Sidecar-Datei statt einer überlangen Inline-Zweisprachigkeit.
- Bilinguales CEFR-B2-Deliverable ist ein **formales Abnahmekriterium** für learner-facing Dokumentation und aktive Anforderungsartefakte.

### Barrierefreiheit (Accessibility)
- Generiertes HTML-Dokumentation muss **WCAG 2.2 Level AA** erfüllen.
- Semantische Überschriften, Listen, Tabellen und ASCII/Text-First-Diagramme bevorzugen.
- **Wesentliche Bedeutung NICHT nur durch Farbe, Layout oder Maus-only-Affordances kodieren.**
- Guides, Statistiken, Beispiele und generierte API-Dokumentation müssen in text-first Assistive-Setups lesbar bleiben.
- Der dokumentierte **A11Y-Nachweispfad ist ein formales Abnahmekriterium** für learner-facing Dokumentation und aktive Anforderungsartefakte.

### DocFX-Review-Regel
- Wenn ein Repository Dokumentation mit `docfx` neu generiert, muss **dasselbe Work-Item** auch den passenden A11Y-Review ausführen.
- Bevorzugtes Toolchain: **Node 24 LTS**, **`npm`**, **`@axe-core/playwright`**, **`lynx`**.
- Playwright + axe für automatisierte Smoke-Checks verwenden; `lynx` als zusätzlichen Textbrowser-Prüfpfad.

### Statistik-Ledger
- `docs/project-statistics.md` als lebendes Ledger pflegen, wenn diese Datei im Repository existiert.
- Den abschließenden Top-Level-Block `## Gesamtstatistik` als letzten Abschnitt halten.
- ASCII-Diagramme textbrowserfreundlich halten und **kurze CEFR-B2-Erklärungen direkt neben** das jeweilige Diagramm platzieren.
- Dokumentierte **Beschleunigungsfaktoren aus Agentic AI plus Spec-Kit/SDD** einschließen sowie einen Vergleich zwischen experienced-developer-Aufwand, Thorsten-solo-Aufwand und dem sichtbaren AI-assisted-Delivery-Fenster (sofern dieses Repository diese Metriken führt).

### Änderungsdisziplin
- **Nicht davon ausgehen**, dass eine Cross-Repository-Regel projekt-spezifische Build-, Test- oder Release-Anforderungen ersetzt.
- Wenn eine gemeinsame Regel sich ändert und mehrere Repositories betroffen sind, lokale Projektguidance **und** das jeweilige Statistik-Ledger gemeinsam aktualisieren.
- `CODEX_CROSS_REPO_PROMPTS.md` synchron halten, wenn sich übergreifende Prompting-Guidance ändert, damit der wiederverwendbare Prompt mit der aktuellen Baseline übereinstimmt.

## Gemeinsame Governance-Ergaenzung / Shared Governance Addendum

- Alle nutzerseitigen Artefakte muessen barrierefrei gedacht und geprueft werden: CLI-Ausgaben, Dokumentation, HTML, UI und generierte Templates; WCAG 2.2 Level AA ist die Standard-Basis, sobald die Kriterien auf das Artefakt anwendbar sind.
- All user-facing artefacts must be designed and reviewed for accessibility: CLI output, documentation, HTML, UI, and generated templates; WCAG 2.2 Level AA is the default baseline wherever the criteria apply.

- Fuer C#/.NET-Repositories gilt standardmaessig eine Thorsten-Solo-Basis von `125` Zeilen/Arbeitstag, sofern das Repo keinen abweichenden, begruendeten Wert dokumentiert.
- The default Thorsten-solo baseline for C#/.NET repositories is `125` lines/workday unless the repository documents a justified deviation.

<!-- SPECKIT START -->
For additional context about technologies to be used, project structure,
shell commands, and other important information, read the current plan
<!-- SPECKIT END -->
