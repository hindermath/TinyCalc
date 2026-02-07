# MicroCalc .NET 10 (Terminal.Gui)

Dieses Repository ist ein oeffentliches Anschauungsprojekt fuer eine agentische Portierung:

- Ausgangspunkt: historische Borland MicroCalc Beispielanwendung in Pascal
- Ziel: moderne C#/.NET 10 Beispielanwendung mit Terminal UI
- Zweck: nachvollziehbar zeigen, wie Agentic-AI einen strukturierten Port von Legacy-Code umsetzen kann

## Projektziel

Die alte MicroCalc-Beispielanwendung (`CALC.PAS`, `CALC.INC`, `CALC.HLP`) wurde als Referenz analysiert und in eine neue Architektur ueberfuehrt:

- Runtime: .NET 10
- UI: Terminal.Gui
- Domainenlogik: getrennt von UI
- Tests: Core-Tests + erweiterte Regressionstests
- Hilfe: integrierte Help-Ansicht auf Basis von `CALC.HLP`

## Originalquellen (Legacy)

Im Repository enthalten:

- `CALC.PAS`
- `CALC.INC`
- `CALC.HLP`

Diese Dateien dienen als fachliche Referenz fuer Verhalten, Formelsprache, Bedienung und Help-Inhalte.

## Ergebnisarchitektur

### Solution/Projekte

- `MicroCalc.sln`
- `src/MicroCalc.Core`
- `src/MicroCalc.Tui`
- `tests/MicroCalc.Core.Tests`

In erweiterten PR-Branches zusaetzlich:
- `tests/MicroCalc.Tui.Tests`

### Schichtenmodell

- `MicroCalc.Core`
  - Zellmodell / Spreadsheet-Domain
  - Formelparser + Evaluator
  - Recalculate / AutoCalc / Format-Logik
  - Persistenz (JSON) + Print-Export
- `MicroCalc.Tui`
  - Terminal.Gui Anwendung
  - Grid-Rendering
  - Eingabedialoge
  - Command-Palette
  - Hilfeanzeige

## Funktionsumfang der Portierung

### Spreadsheet

- Grid A..G und 1..21 (147 Zellen)
- Zelltypen analog Legacy (Text, Numeric, Formula, etc.)
- Navigation ueber Pfeiltasten und klassische Ctrl-Belegung

### Formelsprache

Unterstuetzt:

- Operatoren: `+`, `-`, `*`, `/`, `^`
- Zellreferenzen: `A1`
- Bereichssumme: `A1>B5`
- Funktionen: `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`

### Commands (TUI)

- Load
- Save
- Recalculate
- Print
- Format
- AutoCalc
- Help
- Clear
- Quit

### Hilfe

- Laufzeit-Hilfe aus `CALC.HLP`
- Seitenweise Navigation im Help-Dialog
- Migrierte inhaltliche Fassung unter `docs/help/microcalc-help.md`

## Datenformate

- Neues natives Speicherformat: JSON (`.mcalc.json`)
- Print-Export als Textdatei (`.lst`/`.txt`-artig)
- Legacy `.MCS` Import ist bewusst nicht Teil des Scopes

## Agentic-AI Vorgehensmodell (wie die Portierung umgesetzt wurde)

Die Portierung wurde in klaren, reproduzierbaren Schritten durchgefuehrt:

1. Legacy-Analyse
- Modulweise Analyse von Pascal-Code und Help-Datei
- Ableitung von Kernfunktionen und Verhaltensregeln

2. Zielarchitektur definieren
- Trennung Core vs. UI vs. Tests
- Plan in `PLAN_MICROCALC_CSHARP_DOTNET10.md`

3. Initialer Port
- Core-Domain + Evaluator + Persistenz
- Terminal.Gui Frontend
- Basis-Tests und CI

4. Qualitaetsausbau
- Golden Regression Suite fuer Formeln
- TUI-Smoke-Tests inkl. `--smoke` Modus
- Help-Pfad-Fix fuer robuste Datei-Aufloesung

5. PR-basierter Delivery-Flow
- Mehrere kleine, nachvollziehbare `codex/*` Branches
- PR-Textdateien unter `docs/`
- Nach jedem Merge: neuer Folge-Branch fuer weitere Aenderungen

## Teststrategie

### Core Tests

In `tests/MicroCalc.Core.Tests`:
- Engine- und Evaluator-Tests
- Persistenz-Roundtrip
- Format/Locking
- Formel-Golden-Cases (in entsprechenden PR-Branches)

### TUI Smoke Tests

In `tests/MicroCalc.Tui.Tests` (in erweiterten PR-Branches):
- Smoke-Runner mit Help-Datei
- Negativfall bei fehlender Help-Datei
- CLI-Smokemode (`--smoke`)

## Lokales Starten

```bash
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

## Lokales Testen

```bash
dotnet test MicroCalc.sln
```

Optionaler Smoke-Run:

```bash
dotnet run --no-build --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

## CI

GitHub Actions Workflow:

- `.github/workflows/ci.yml`
- Fuehrt Restore, Build und Test aus

## PR-/Branch-Chronik dieser Portierung

Historisch in dieser Konversation/Umsetzung entstanden:

- `codex/initial-microcalc-port`
  - Initialer Port (Core + TUI + Basis-Tests + CI)
- `codex/formula-golden-tests` und `codex/formula-golden-tests-v2`
  - Formel-Golden-Regressionen
  - TUI-Smoke-Tests
  - Help-Pfad-Fix
- `codex/pr-process-note` und `codex/pr-process-note-v2`
  - Dokumentation des PR-Vorgehens

Hinweis:
- Der Integrationsstand kann je nach Zielbranch variieren (z. B. `main` vs. andere Integrations-Branches).
- In diesem Repo wurde iterativ mit mehreren Folge-PRs gearbeitet.

## Leitfaden fuer andere Teams

Wenn du dieses Repo als Blaupause fuer eine eigene Legacy-Portierung nutzen willst:

1. Analyse zuerst, Code danach
- Legacy-Funktionen sauber inventarisieren (Input, Output, Seiteneffekte)

2. Domaine von UI trennen
- Parser/Evaluator/Businesslogik testbar ohne UI bauen

3. Frueh automatisierte Regressionen aufbauen
- Golden-Cases aus echten Legacy-Beispielen

4. Kleine PRs statt Big-Bang
- Pro Risiko-/Themenblock ein PR

5. Dokumentation als First-Class Artefakt
- Plan, PR-Texte, Workflow-Notizen im Repo halten

## Relevante Dokumente im Repo

- Portierungsplan: `PLAN_MICROCALC_CSHARP_DOTNET10.md`
- Initialer PR-Text: `docs/PR_TEXT_INITIAL_PORT.md`
- PR-Workflow-Notiz: `docs/WORKFLOW_NOTES.md`
- Beispiel PR-Text fuer Workflow-Notiz: `docs/PR_TEXT_PR_PROCESS_NOTE.md`
- Migrierte Help-Inhalte: `docs/help/microcalc-help.md`

---

Dieses Repository soll bewusst nicht nur "Code" liefern, sondern einen nachvollziehbaren End-to-End-Prozess zeigen: von Legacy-Analyse ueber Architektur und Tests bis hin zu PR-getriebener, agentischer Umsetzung.
