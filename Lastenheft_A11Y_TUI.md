# Lastenheft: Barrierefreiheit der TinyCalc TUI (A11Y)

**Dokument-Status:** Entwurf
**Erstellt:** 2026-03-31
**Empfohlener Durchführungszeitraum:** Parallel zur oder direkt nach der Migration
von Terminal.Gui 1.19.0 auf 2.0.0 (die Migration selbst ist Voraussetzung für R-A11Y-CALC-04).
Die Kurzfrist-Anforderungen (R-A11Y-CALC-01 bis R-A11Y-CALC-03) können auch auf 1.19.0 umgesetzt werden.
**Grundlage:** `docs/tui-a11y-assessment.md` im RiderProjects-Workspace

---

## Ausgangslage

TinyCalc nutzt **Terminal.Gui 1.19.0** (statisches `Application.Init()`-Modell).
Das ist die ältere, weniger aktiv gewartete API; die aktuelle Empfehlung ist 2.0.0.

Die Anwendung besitzt viele Keyboard-Shortcuts (`Ctrl+E/X/D/S/A`, `/`, `Esc`, `Ctrl+Q`,
`P`/`N`), die jedoch nur fragmentarisch im UI sichtbar sind: Die Statuszeile zeigt
lediglich `"Type '/' for commands"`. Ein Nutzer mit Screen-Reader weiß nicht,
welche weiteren Shortcuts existieren.

Das Tabellenkalkulationsmodell (Zellnavigation per Pfeiltasten, Formel-Eingabe per `Esc`)
ist grundsätzlich gut für Keyboard-Navigation geeignet — es fehlt nur die explizite
Dokumentation und das Text-Feedback.

---

## Anforderungen

### R-A11Y-CALC-01: Vollständige Shortcut-Legende in der StatusBar

Die Statuszeile muss alle wichtigen Shortcuts als sichtbaren Text anzeigen.
Da der Platz begrenzt ist, ist eine kontextabhängige Rotation akzeptabel
(z. B. Navigation-Shortcuts im Normal-Modus, Bearbeitungs-Shortcuts im Editier-Modus).

Mindestinhalt im Normal-Modus:

```
/ Befehle  Esc Bearbeiten  Ctrl+Q Beenden  Ctrl+S Speichern  P/N Hilfe
```

Mindestinhalt im Editier-Modus:

```
Enter Bestätigen  Esc Abbrechen  Ctrl+A Zeilenanfang  Ctrl+E Zeilenende
```

### R-A11Y-CALC-02: Text-Bestätigung nach jeder Aktion

Nach jeder benutzerinitierten Aktion muss eine Meldung in der Nachrichtenzeile
als **sichtbarer Text** erscheinen.

Beispiele:
- Datei gespeichert → `„Gespeichert: <Dateiname>"`
- Neue Datei → `„Neue Tabelle erstellt"`
- Formel-Fehler → `„Fehler in Zelle <B3>: Division durch null"`
- Bereich kopiert → `„<N> Zellen kopiert"`

Reine Farbänderungen (z. B. Zelle wird hervorgehoben) genügen nicht als
alleiniges Feedback für Screen-Reader-Nutzer.

### R-A11Y-CALC-03: Hilfe-Dialog mit vollständiger Shortcut-Referenz

Der bestehende Hilfe-Dialog (erreichbar via `P`/`N`) muss eine vollständige,
strukturierte Referenz aller Keyboard-Shortcuts enthalten — in tabellarischer
Form, die von Screen-Readern als Text erfasst werden kann.
Die aktuelle mehrseitige Hilfe ist beizubehalten; die Shortcut-Referenz kann
als eigene Hilfeseite ergänzt werden.

### R-A11Y-CALC-04: Migration auf Terminal.Gui 2.0.0

TinyCalc verwendet noch die veraltete statische API von Terminal.Gui 1.19.0.
Die Migration auf 2.0.0 (instanzbasiertes `Application.Create().Init()`) ist
Voraussetzung für:
- Zugriff auf neuere `ColorScheme`-APIs für High-Contrast
- Besseres Test-Support durch `FakeDriver` (Headless-Tests ohne echtes Terminal)
- Langfristige Wartbarkeit und Kompatibilität mit TinyPl0

Die Migration soll als eigenständiger PR mit vollständigem Regressionstest
(`dotnet test MicroCalc.sln`) durchgeführt werden.

### R-A11Y-CALC-05: Farbkontrast WCAG 2.2 AA

Nach der Migration (R-A11Y-CALC-04) müssen alle verwendeten `ColorScheme`-
Definitionen einen Mindest-Kontrast von **4,5:1** (WCAG 2.2 AA, Normaltext)
einhalten. Zellen, Statuszeilen, Nachrichtenzeilen und aktive Zell-Hervorhebung
sind einzeln zu prüfen.

### R-A11Y-CALC-06: A11Y-Tests für Dokumentations-HTML (Playwright+axe)

Die mit `docfx` generierte TinyCalc-Dokumentation muss durch automatisierte
Playwright-Tests mit `@axe-core/playwright` auf WCAG 2.2 AA-Konformität geprüft
werden — analog zu TuiVision (`tests/web-a11y/`).
Zusätzlich: Validierung mit `lynx` als Text-Browser.
Diese Tests sind in `ci.yml` zu integrieren.

### R-A11Y-CALC-07: Prozessbasierte Keyboard-Integrationstests (mittelfristig)

Ergänzende Integrationstests, die TinyCalc als Prozess starten, Tastatureingaben
via stdin simulieren und Ausgaben via stdout auf erwartete Textmuster prüfen.
Ziel: maschinenlesbare Verifikation der Keyboard-Navigation ohne Screen-Reader.
Hinweis: Playwright kann Terminal-UIs nicht direkt testen; dieser Ansatz
ist die praktikable Alternative.

---

## Nicht im Scope

- Vollständige Screen-Reader-Semantik (Terminal.Gui bietet keine UI-Automation-Integration)
- Maus als primärer Eingabekanal
- Änderungen an der Formel-Engine (`MicroCalc.Core`)
- Änderungen an den Golden-Tests (außer Anpassungen durch die Migration)

---

## Akzeptanzkriterien

| ID | Kriterium |
|----|-----------|
| AK-A11Y-CALC-01 | StatusBar zeigt kontextabhängige, vollständige Shortcut-Legende |
| AK-A11Y-CALC-02 | Jede Aktion erzeugt sichtbaren Text in Nachrichtenzeile oder Statuszeile |
| AK-A11Y-CALC-03 | Hilfe-Dialog enthält vollständige Shortcut-Referenz als strukturierten Text |
| AK-A11Y-CALC-04 | `dotnet test MicroCalc.sln` nach Migration auf Terminal.Gui 2.0.0 vollständig grün |
| AK-A11Y-CALC-05 | Alle ColorScheme-Kombinationen erreichen Kontrast ≥ 4,5:1 |
| AK-A11Y-CALC-06 | Playwright+axe-Tests für DocFX-HTML ohne serious/critical Violations |
| AK-A11Y-CALC-07 | lynx kann Dokumentationsstartseite vollständig als Text darstellen |

---

## Beispiel: Agentic-AI-Dialog (Platzhalter für spätere Durchführung)

Dieser Abschnitt wird während der Umsetzung mit Agentic-AI plus Spec-Kit/SDD
befüllt — jeder Schritt mit Commit-URL und Zeitstempel.

---

## Hinweis für Lernende

**Deutsch:** Bei Tabellenkalkulationen ist die Tastaturnavigation besonders wichtig:
Pfeiltasten für Zellnavigation, Tab für Spaltensprung, Enter für Eingabebestätigung
sind Standard. Ein Screen-Reader-Nutzer ist auf **sichtbaren Text** angewiesen —
alles, was nur durch Farbe oder Position kommuniziert wird, ist nicht zugänglich.

**English:** Keyboard navigation is especially important for spreadsheets: arrow keys
for cell navigation, Tab for column jumps, Enter to confirm input. A screen reader
user depends on visible text — anything communicated only through colour or position
is not accessible.
