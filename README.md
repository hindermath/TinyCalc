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

## Verbindliche Dokumentationsregeln (Constitution v1.1.0)

- Dokumentation und didaktische Kommentare muessen zweisprachig sein:
  zuerst Deutsch, danach Englisch.
- Beide Sprachbloecke muessen auf CEFR-/GER-B2-Niveau formuliert sein.
- Oeffentliche APIs muessen vollstaendige XML-Dokumentation pflegen
  (`<summary>`, `<param>`, `<returns>`, `<exception>` wenn anwendbar).
- Bei Aenderungen an API-Signaturen oder XML-Kommentaren muss die DocFX-Ausgabe
  im selben Commit/PR aktualisiert werden.

## Relevante Dokumente im Repo

- Portierungsplan: `PLAN_MICROCALC_CSHARP_DOTNET10.md`
- Initialer PR-Text: `docs/PR_TEXT_INITIAL_PORT.md`
- PR-Workflow-Notiz: `docs/WORKFLOW_NOTES.md`
- Beispiel PR-Text fuer Workflow-Notiz: `docs/PR_TEXT_PR_PROCESS_NOTE.md`
- Migrierte Help-Inhalte: `docs/help/microcalc-help.md`

---

Dieses Repository soll bewusst nicht nur "Code" liefern, sondern einen nachvollziehbaren End-to-End-Prozess zeigen: von Legacy-Analyse ueber Architektur und Tests bis hin zu PR-getriebener, agentischer Umsetzung.

## Inklusion und Barrierefreiheit / Inclusion and Accessibility

- Folge dem Leitsatz `Programmierung #include<everyone>`: Lernmaterialien, Guides und erzeugte HTML-/API-Dokumentation muessen fuer Braille-Zeile, Screenreader und Textbrowser nutzbar bleiben.
- Follow `Programmierung #include<everyone>`: learner-facing material, guides, and generated HTML/API documentation must stay usable on Braille displays, with screen readers, and in text browsers.
- Fuer erzeugte HTML-Dokumentation gilt WCAG 2.2 Konformitaetsstufe AA als praktische Basis.
- For generated HTML documentation, WCAG 2.2 conformance level AA is the practical baseline.
- Nach jedem `docfx`-Neubau soll ein textorientierter A11y-Review folgen, bevorzugt mit Playwright + `@axe-core/playwright` und `lynx`.
- After every `docfx` regeneration, a text-oriented accessibility review should follow, preferably with Playwright + `@axe-core/playwright` and `lynx`.

## Spec-kit-Workflow

Neue Features in diesem Workspace werden nach dem **Specification-Driven Development (SDD)**-Workflow entwickelt.
Der Workflow verwendet das `speckit`-CLI-Tool (GitHub Copilot Skill).

Schritte für ein neues Feature:

1. **Spezifikation erstellen** — `speckit specify "Feature-Name"` → `specs/{branch}/spec.md`
2. **Klärungsfragen** — `speckit clarify` → offene Fragen in `spec.md` beantworten
3. **Implementierungsplan** — `speckit plan` → `specs/{branch}/plan.md`
4. **Aufgabenliste** — `speckit tasks` → `specs/{branch}/tasks.md`
5. **Implementieren** — `speckit implement` → Aufgaben aus `tasks.md` abarbeiten
6. **Validieren** — `bash scripts/check-homogeneity.sh` → Compliance-Score prüfen

Alle Spec-Artefakte werden im Branch-Verzeichnis `specs/{branch}/` gespeichert und versioniert.

---

## Spec-kit Workflow

New features in this workspace are developed following the **Specification-Driven Development (SDD)** workflow.
The workflow uses the `speckit` CLI tool (GitHub Copilot Skill).

Steps for a new feature:

1. **Create specification** — `speckit specify "Feature Name"` → `specs/{branch}/spec.md`
2. **Clarification questions** — `speckit clarify` → answer open questions in `spec.md`
3. **Implementation plan** — `speckit plan` → `specs/{branch}/plan.md`
4. **Task list** — `speckit tasks` → `specs/{branch}/tasks.md`
5. **Implement** — `speckit implement` → work through tasks in `tasks.md`
6. **Validate** — `bash scripts/check-homogeneity.sh` → check compliance score

All spec artefacts are stored and versioned in the branch directory `specs/{branch}/`.

---

## Homogeneity Guardian — Skript-Kurzreferenz / Script Quick Reference

### `scripts/check-homogeneity.sh` / `scripts/check-homogeneity.ps1`

Prüft dieses Projekt auf Compliance (constitution.md, A11Y, Spec-kit, Azubis-Abschnitte, STATS.md).
*Checks this project for compliance (constitution.md, A11Y, Spec-kit, Azubis sections, STATS.md).*

```bash
bash scripts/check-homogeneity.sh

# JSON-Ausgabe für CI/Scripting / JSON output for CI/scripting
bash scripts/check-homogeneity.sh --json
```

```powershell
pwsh scripts/check-homogeneity.ps1
pwsh scripts/check-homogeneity.ps1 -Json
```

---

### `scripts/init-stats.sh` / `scripts/init-stats.ps1`

Schreibt einen Baseline-Eintrag in `STATS.md`. Einmalig nach dem Einrichten ausführen.
*Writes a baseline entry to `STATS.md`. Run once after initial setup.*

```bash
bash scripts/init-stats.sh
```

```powershell
pwsh scripts/init-stats.ps1
```

---

### `scripts/rename-lastenheft.sh` / `scripts/rename-lastenheft.ps1`

Benennt eine Lastenheft-Datei via `git mv` um und committet — fügt Branch-Suffix hinzu.
*Renames a Lastenheft file via `git mv` and commits — adds branch suffix.*

```bash
# Datei umbenennen und committen / Rename and commit
bash scripts/rename-lastenheft.sh Lastenheft_foo.md 002-feature-branch
# Ergebnis / Result: Lastenheft_foo.002-feature-branch.md
```

```powershell
pwsh scripts/rename-lastenheft.ps1 -File Lastenheft_foo.md -Branch 002-feature-branch
```

---

### `scripts/install-hooks.sh` / `scripts/install-hooks.ps1`

Installiert den `pre-push`-Hook nach dem Clonen auf einem neuen Gerät.
*Installs the `pre-push` hook after cloning on a new device.*

```bash
bash scripts/install-hooks.sh
```

```powershell
pwsh scripts/install-hooks.ps1
```

## Für Azubis / For Apprentices

Willkommen! Diese Sektion beschreibt den Einstieg in die Entwicklungsumgebung
für Fachinformatiker-Azubis und andere Einsteiger.

**Voraussetzungen:**

- Git (macOS: `brew install git` / Windows: `winget install Git.Git`)
- PowerShell 7+ (Windows: `winget install Microsoft.PowerShell`)
- ripgrep (macOS: `brew install ripgrep` / Windows: `winget install BurntSushi.ripgrep.MSVC`)
- GitHub CLI (macOS: `brew install gh` / Windows: `winget install GitHub.cli`)

**Ersten Schritt ausführen:**

```bash
# Repository klonen
git clone <repo-url>
cd <projekt-verzeichnis>

# Hooks installieren
bash scripts/install-hooks.sh

# Compliance prüfen
bash scripts/check-homogeneity.sh
```

**Hilfreiche Befehle:**

| Befehl | Beschreibung |
|--------|--------------|
| `bash scripts/check-homogeneity.sh` | Compliance-Bericht anzeigen |
| `bash scripts/init-stats.sh` | Compliance-Baseline in STATS.md schreiben |
| `git log --oneline -10` | Letzte 10 Commits anzeigen |

Bei Fragen: Issue im GitHub-Repository erstellen oder Mentor ansprechen.

---

Welcome! This section describes how to get started with the development
environment for apprentice software developers (Fachinformatiker-Azubis) and
other beginners.

**Prerequisites:**

- Git (macOS: `brew install git` / Windows: `winget install Git.Git`)
- PowerShell 7+ (Windows: `winget install Microsoft.PowerShell`)
- ripgrep (macOS: `brew install ripgrep` / Windows: `winget install BurntSushi.ripgrep.MSVC`)
- GitHub CLI (macOS: `brew install gh` / Windows: `winget install GitHub.cli`)

**First steps:**

```bash
# Clone the repository
git clone <repo-url>
cd <project-directory>

# Install hooks
bash scripts/install-hooks.sh

# Check compliance
bash scripts/check-homogeneity.sh
```

**Useful commands:**

| Command | Description |
|---------|-------------|
| `bash scripts/check-homogeneity.sh` | Show compliance report |
| `bash scripts/init-stats.sh` | Write compliance baseline to STATS.md |
| `git log --oneline -10` | Show last 10 commits |

For questions: open an issue in the GitHub repository or ask your mentor.
