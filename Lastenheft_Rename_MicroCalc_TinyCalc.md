# Lastenheft: Umbenennung MicroCalc → TinyCalc

**Dokument-Status:** Entwurf
**Erstellt:** 2026-03-31
**Betrifft:** Alle Dateien und Ordner im Repository, die den String „MicroCalc" enthalten
**Empfohlener Durchführungszeitraum:** Als eigenständiger PR; kann parallel zur
Terminal.Gui-Migration (`Lastenheft_TerminalGui_Migration.md`) vorbereitet, aber
idealerweise **nach** der Migration gemergt werden, um Konflikte zu vermeiden.
**Wichtig:** Die GitHub-Repository-URL bleibt unverändert
(`github.com/hindermath/TinyCalc`) — nur der interne Code-Namespace ändert sich.

---

## Ausgangslage und Motivation

Das Projekt heißt nach außen **TinyCalc** (GitHub-Repo, README-Titel, Workspace-Name),
verwendet intern aber noch den ursprünglichen Pascal-Port-Namen **MicroCalc**.
Diese Diskrepanz verwirrt Lernende und erschwert die Orientierung im Code.

Ein vollständiger Rename auf `TinyCalc` in allen Namespaces, Projektnamen
und Dokumenten stellt Konsistenz her — das Projekt nennt sich überall gleich.

---

## Vollständige Rename-Übersicht

### 1. Solution-Datei

| Aktuell | Neu |
|---------|-----|
| `MicroCalc.sln` | `TinyCalc.sln` |

### 2. Projektordner und .csproj-Dateien (4 Projekte)

| Aktueller Ordner | Neuer Ordner | .csproj-Datei |
|-----------------|-------------|---------------|
| `src/MicroCalc.Core/` | `src/TinyCalc.Core/` | `TinyCalc.Core.csproj` |
| `src/MicroCalc.Tui/` | `src/TinyCalc.Tui/` | `TinyCalc.Tui.csproj` |
| `tests/MicroCalc.Core.Tests/` | `tests/TinyCalc.Core.Tests/` | `TinyCalc.Core.Tests.csproj` |
| `tests/MicroCalc.Tui.Tests/` | `tests/TinyCalc.Tui.Tests/` | `TinyCalc.Tui.Tests.csproj` |

### 3. Namespaces und Using-Statements (19 + 20 Stellen)

| Alt | Neu |
|-----|-----|
| `namespace MicroCalc.Core.Engine` | `namespace TinyCalc.Core.Engine` |
| `namespace MicroCalc.Core.Formula` | `namespace TinyCalc.Core.Formula` |
| `namespace MicroCalc.Core.IO` | `namespace TinyCalc.Core.IO` |
| `namespace MicroCalc.Core.Model` | `namespace TinyCalc.Core.Model` |
| `namespace MicroCalc.Tui` | `namespace TinyCalc.Tui` |
| `namespace MicroCalc.Tui.Help` | `namespace TinyCalc.Tui.Help` |
| `namespace MicroCalc.Tui.Smoke` | `namespace TinyCalc.Tui.Smoke` |
| `namespace MicroCalc.Core.Tests` | `namespace TinyCalc.Core.Tests` |
| `namespace MicroCalc.Tui.Tests` | `namespace TinyCalc.Tui.Tests` |
| `using MicroCalc.*` (20×) | `using TinyCalc.*` |

### 4. UI-Text in Program.cs

| Stelle | Alt | Neu |
|--------|-----|-----|
| Window-Titel (Program.cs ~Z. 80) | `"MicroCalc .NET 10"` | `"TinyCalc .NET 10"` |

### 5. GitHub Actions CI-Workflow (`.github/workflows/ci.yml`)

| Zeile | Alt | Neu |
|-------|-----|-----|
| restore | `dotnet restore MicroCalc.sln` | `dotnet restore TinyCalc.sln` |
| build | `dotnet build MicroCalc.sln ...` | `dotnet build TinyCalc.sln ...` |
| test | `dotnet test MicroCalc.sln ...` | `dotnet test TinyCalc.sln ...` |

### 6. Markdown-Dateien (25 Dateien enthalten „MicroCalc")

Alle `MicroCalc`-Textstellen in Fließtext, Überschriften, Code-Blöcken und
Pfadangaben sind zu ersetzen. Dateiliste:

| Datei | Typ |
|-------|-----|
| `README.md` | Haupt-README |
| `AGENTS.md`, `CLAUDE.md`, `GEMINI.md` | KI-Agenten-Dateien |
| `CONTRIBUTING.md` | Beitrags-Leitfaden |
| `PLAN_MICROCALC_CSHARP_DOTNET10.md` | Plan-Datei (Inhalt ersetzen, ggf. umbenennen) |
| `docs/help/microcalc-help.md` | **Datei umbenennen** → `tinycalc-help.md` |
| `docs/project-statistics.md` | Statistik-Ledger |
| `docs/PR_TEXT_*.md` (6 Dateien) | PR-Text-Archiv (historisch, ggf. belassen) |
| `Lastenheft_A11Y_TUI.md` | Neu erstelltes Lastenheft (bereits MicroCalc-Refs) |
| `.github/copilot-instructions.md` | Copilot-Instruktionen |
| `.github/pull_request_template.md` | PR-Template |
| `.specify/memory/constitution.md` | Spec-Kit-Constitution |
| `.specify/templates/plan-template.md` | Spec-Kit-Template |
| `specs/001-project-context/*.md` (5 Dateien) | Spec-Kit-Kontext |

**Hinweis zu PR-Text-Archiven:** Die `docs/PR_TEXT_*.md`-Dateien sind historische
Commit-Protokolle. Dort kann „MicroCalc" als historischer Name belassen werden
oder durch „TinyCalc (ehem. MicroCalc)" ersetzt werden — Entscheidung beim PR.

### 7. Rider IDE-Ordner

| Ordner | Verhalten |
|--------|-----------|
| `.idea/.idea.MicroCalc/` | Wird automatisch neu angelegt, sobald Rider die umbenannte `TinyCalc.sln` öffnet. Alten Ordner nach dem Rename löschen. |

---

## Anforderungen

### R-RN-TC-01: Atomarer Rename in einem einzigen PR

Alle Änderungen unter Abschnitt „Rename-Übersicht" sind in **einem** PR zu
bündeln, um einen inkonsistenten Zwischenzustand im Repository zu vermeiden.
Der PR-Titel lautet: `refactor: MicroCalc → TinyCalc vollständiger Namespace-Rename`.

### R-RN-TC-02: Empfohlene Werkzeuge für den Rename

Empfohlen: JetBrains Rider **Rename Refactoring** (`F2` auf Solution/Projekt/Namespace)
für Namespaces und Projektnamen. Rider aktualisiert `.sln`, alle `.csproj`-Querverweise,
Namespaces und `using`-Statements automatisch.

Für Markdown und andere Textdateien: globales Suchen & Ersetzen
(`MicroCalc` → `TinyCalc`) mit Ausnahme der historischen PR-Text-Archive
(Entscheidung liegt beim Durchführenden).

### R-RN-TC-03: Datei `docs/help/microcalc-help.md` umbenennen

```bash
git mv docs/help/microcalc-help.md docs/help/tinycalc-help.md
```

Alle Verweise auf `microcalc-help.md` in anderen Dateien müssen
auf `tinycalc-help.md` aktualisiert werden.

### R-RN-TC-04: CI-Workflow muss nach Rename funktionieren

Nach dem Rename muss der GitHub Actions Workflow `ci.yml` grün sein:

```bash
dotnet restore TinyCalc.sln
dotnet build TinyCalc.sln --configuration Release --no-restore
dotnet test TinyCalc.sln --configuration Release --no-build
```

### R-RN-TC-05: Smoke-Test bleibt lauffähig

```bash
dotnet run --no-build --configuration Release \
  --project src/TinyCalc.Tui/TinyCalc.Tui.csproj -- --smoke
# Erwartete Ausgabe: SMOKE_OK
```

### R-RN-TC-06: Keine verbleibenden `MicroCalc`-Strings im aktiven Code

Nach dem PR darf kein `MicroCalc`-String mehr in:
- `.cs`-Dateien (Namespaces, using-Statements, String-Literale)
- `.csproj`-Dateien (Projektnamen, ProjectReference-Pfade)
- `.sln`-Datei
- `.github/workflows/ci.yml`
- `README.md`, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`

vorkommen. Prüfbefehl:
```bash
grep -r "MicroCalc" --include="*.cs" --include="*.csproj" --include="*.sln" \
  --include="*.yml" src/ tests/ .github/ README.md AGENTS.md CLAUDE.md GEMINI.md
# Erwartetes Ergebnis: keine Ausgabe
```

---

## Nicht im Scope

- Änderung der GitHub-Repository-URL (bleibt `github.com/hindermath/TinyCalc`)
- Änderung der NuGet-Paket-ID (kein öffentliches Paket vorhanden)
- Inhalte der historischen `docs/PR_TEXT_*.md`-Archive (optional)
- Terminal.Gui-Migration (separates Lastenheft)

---

## Akzeptanzkriterien

| ID | Kriterium |
|----|-----------|
| AK-RN-TC-01 | Solution heißt `TinyCalc.sln`; alle 4 Projektordner und .csproj-Dateien umbenannt |
| AK-RN-TC-02 | `grep -r "MicroCalc" src/ tests/` liefert keine Treffer |
| AK-RN-TC-03 | `grep -r "MicroCalc" .github/` liefert keine Treffer |
| AK-RN-TC-04 | `dotnet test TinyCalc.sln --configuration Release` vollständig grün |
| AK-RN-TC-05 | `--smoke`-Modus gibt `SMOKE_OK` aus |
| AK-RN-TC-06 | `docs/help/tinycalc-help.md` vorhanden; alte Datei gelöscht |
| AK-RN-TC-07 | Window-Titel in der laufenden App zeigt „TinyCalc .NET 10" |

---

## Beispiel: Agentic-AI-Dialog (Platzhalter)

Dieser Abschnitt wird während der Umsetzung mit Commit-URLs und Zeitstempeln befüllt.

---

## Hinweis für Lernende

**Deutsch:** Ein vollständiger Namespace-Rename ist ein klassisches Refactoring.
Rider macht den Großteil automatisch — aber die Dokumentation (Markdown, YAML, CI)
muss manuell oder per globalem Suchen & Ersetzen nachgezogen werden.
Ein `grep` nach dem alten Namen am Ende des PRs ist die einfachste Abnahme-Prüfung.

**English:** A complete namespace rename is a classic refactoring. Rider handles most of it
automatically — but documentation (Markdown, YAML, CI) must be updated manually or via
global search & replace. A `grep` for the old name at the end of the PR is the simplest
acceptance check.
