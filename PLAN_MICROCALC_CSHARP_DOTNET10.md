# Migrationsplan: Borland MicroCalc (Pascal) -> C# / .NET 10 mit Terminal.Gui

## 1. Zielbild

Die historische MicroCalc-Beispielanwendung (`CALC.PAS`, `CALC.INC`, `CALC.HLP`) wird als moderne, wartbare C#-Anwendung auf Basis von .NET 10 neu umgesetzt.

Zielzustand:
- Laufzeit: .NET 10 (Preview/RTM je nach Verfuegbarkeit).
- UI: Text User Interface mit [Terminal.Gui](https://github.com/gui-cs/Terminal.Gui).
- Verhalten: moeglichst nahe am Original (147 Zellen, Formeln, Navigation, Datei laden/speichern, Drucken in Datei, Formatierung, Hilfe).
- Hilfe: integriertes, seitenbasiertes Hilfesystem analog `CALC.HLP`.
- Qualitaet: Tests fuer Parser/Evaluator, Core-Modelle und Use-Cases.
- DevOps: Git-Versionierung, GitHub-Repository, CI fuer Build/Test.

## 2. Analyse der Bestandsdateien

## 2.1 `CALC.PAS` (Hauptprogramm)

Kernpunkte:
- Definiert das Spreadsheet-Raster:
  - Spalten `A..G` (`FXMax = 'G'`)
  - Zeilen `1..21` (`FYMax = 21`)
  - Insgesamt 147 Zellen.
- Zellmodell (`CellRec`):
  - `CellStatus` (Attribute wie `Constant`, `Formula`, `Txt`, `OverWritten`, `Locked`, `Calculated`)
  - `Contents` (max. 70 Zeichen)
  - `Value` (Real)
  - `DEC`, `FW` (Formatierung: Dezimalstellen/Feldbreite)
- Eventloop mit Tastatursteuerung:
  - Navigation (Ctrl-/Arrow-Mapping)
  - `/` fuer Kommando-Menue
  - `ESC` oder druckbare Eingabe fuer Zellenbearbeitung.

Rueckschluss fuer Migration:
- Das Original trennt bereits Datenmodell, UI-Interaktion und Berechnungslogik in Module. Diese Trennung wird in C# sauber in Schichten ueberfuehrt.

## 2.2 `CALC.INC` (Funktionsmodule 000-005)

Enthaelt funktional fast die komplette Anwendung:

- Modul 000: Utilities/UI-Helfer
  - Welcome, Statusmeldungen, Blinken, Key-Mapping (IBM-Scancodes), AutoCalc Toggle.
- Modul 001: Grid/Init/Clear
  - Initialisierung aller Zellen, Zeichnen des Grids, Loeschen des Sheets.
- Modul 002: Navigation/Anzeige
  - Aktive Zelle, Zelltypanzeige, Bewegung links/rechts/oben/unten mit Ueberspringen gesperrter/ueberschriebener Zellen.
- Modul 003: Persistenz + Help
  - Save/Load des binären Zellformats (`file of CellRec`), Print in Textdatei, Help-Pager aus `CALC.HLP`.
- Modul 004: Parser/Evaluator
  - Rekursiver Descent-Parser fuer Zahlen, Operatoren (`+,-,*,/,^`), Klammern, Zellreferenzen, Bereichssumme (`A1>B5`) und Funktionen (`ABS,SQRT,SQR,SIN,COS,ARCTAN,LN,LOG,EXP,FACT`).
  - Rekalkulation ueber alle Formelzellen.
- Modul 005: Zelleneditierung + Format
  - Zeileneditor, Text/Formel-Erkennung, Statusverwaltung (`OverWritten`, `Locked`), Spaltenformatierung mit DEC/FW.

Rueckschluss fuer Migration:
- Die groesste fachliche Komplexitaet liegt in:
  - Status- und Seiteneffektlogik beim Editieren (`OverWritten`/`Locked`),
  - Formelparser mit rekursiver Auswertung,
  - konsistenter Anzeigeformatierung.
- Diese Teile zuerst im Core ohne UI-Abhaengigkeit implementieren und dann ans TUI anbinden.

## 2.3 `CALC.HLP` (Hilfe)

Beobachtungen:
- Reine Textdatei mit Seitenumbruechen ueber Marker `.PA`.
- Inline-Formatierungen via Steuerzeichen (historisch `^B` fuer Fett/Highlight).
- Inhaltliche Kapitel:
  - Einfuehrung und Grenzen,
  - Bedienung/Navigation,
  - Befehlsuebersicht (`/Q`, `/L`, `/S`, `/R`, `/P`, `/F`, `/A`),
  - Formelbeispiele.

Rueckschluss fuer Migration:
- Das Help-System kann als strukturierter Seiten-Pager in Terminal.Gui umgesetzt werden.
- `CALC.HLP` wird in ein neutrales Markdown- oder Plaintext-Format ueberfuehrt, Seitenkonzept bleibt erhalten.

## 3. Zielarchitektur der .NET-Umsetzung

Projektstruktur (Vorschlag):

- `src/MicroCalc.Core`
  - Domänenmodell, Parser/Evaluator, Use-Cases (ohne UI).
- `src/MicroCalc.Tui`
  - Terminal.Gui-App, Views, Keybindings, Dialoge.
- `tests/MicroCalc.Core.Tests`
  - Unit-/Property-Tests fuer Kernlogik.
- `tests/MicroCalc.Tui.Tests` (optional spaeter)
  - Smoke-/Presenter-Tests fuer UI-Flows.
- `docs/`
  - Migrationsdokumentation, Bedienhilfe, Architekturentscheidungen.

Schichten:
- Domain:
  - `Spreadsheet`, `Cell`, `CellAddress`, `CellStatusFlags`, `CellFormat`.
- Application:
  - `EditCellService`, `RecalculateService`, `FormatRangeService`, `CommandDispatcher`.
- Infrastructure:
  - `SheetSerializer` (modernes JSON + optional Legacy-Adapter),
  - `SheetPrinter` (Text-Export),
  - `HelpContentProvider`.
- Presentation (TUI):
  - GridView, StatusBar, CommandPalette/Dialog, HelpPager.

## 4. Feature-Mapping Alt -> Neu

- Grid 7x21:
  - 1:1 uebernehmen.
- Zellattribute:
  - Als `[Flags] enum` in C# modellieren.
- Navigation:
  - Arrow + Ctrl-Keybindings nachbauen.
- Zellbearbeitung:
  - Text, Zahl, Formel; ESC/Edit-Verhalten nachbilden.
- Formelengine:
  - Funktionalitaet parity-faehig zum Original.
- AutoCalc:
  - On/Off Status im UI plus sofortige/manuelle Rekalkulation.
- Commands:
  - `/` oeffnet Command-Dialog mit Originalfunktionen (Load, Save, Recalculate, Print, Format, Auto, Help, Clear, Quit).
- Help:
  - Seitenweise Navigation (`N`, `P`, `Esc`) im Help-Fenster.

## 5. Terminal.Gui Integrationsplan

Technische Leitlinien:
- Aktuelle stabile Terminal.Gui-Version verwenden, die mit .NET 10 kompatibel ist.
- UI nicht als „Paint everything manually“, sondern via Views/Layouts strukturieren.

TUI-Komponenten:
- Hauptfenster:
  - Grid-Bereich (Spalten A-G, Zeilen 1-21)
  - Statuszeile 1: aktive Zelle + Zelltyp
  - Statuszeile 2: Meldungen/Command-Hinweise.
- Eingabedialog:
  - Modales Edit-Feld fuer Zellinhalt/Formel.
- Command-Dialog (`/`):
  - Ein-Tasten-Auswahl + klar beschriftete Menuepunkte.
- Help-Pager:
  - Scroll-/Page-Navigation, Seitennummer, Close via `Esc`.

Keybindings (MVP):
- Navigation: Pfeiltasten, optional Ctrl-E/S/D/X analog Historie.
- Aktionen: `/`, `Esc`, `Enter`, `Ctrl+Q` (zus. moderner Shortcut fuer Quit).

## 6. Hilfe-System (neu)

Inhalte:
- `CALC.HLP` in `docs/help/microcalc-help.md` ueberfuehren.
- Seitenlogik beibehalten (Abschnittsmarker, z. B. `--- page ---` intern).

Runtime-Design:
- `HelpParser` liest Datei, splittet in `HelpPage`-Objekte.
- `HelpView` rendert jeweils eine Seite, zeigt Navigation (`P`, `N`, `Esc`).
- Option fuer spaetere Internationalisierung (`docs/help/de`, `docs/help/en`).

## 7. Datenformat und Persistenz

Original:
- Binärserialisierung des Pascal-Records (`.MCS`) ist nicht robust/plattformneutral.

Neues Standardformat:
- JSON-Datei, z. B. `.mcalc.json`.
- Vorteile: diffbar, testbar, versionsfaehig.

Kompatibilitaetsoption:
- Optional Legacy-Import fuer alte `.MCS` nur falls erforderlich.
- Wenn nicht zwingend benoetigt: dokumentieren, dass neue App eigenes Format nutzt.

Print-Export:
- Textausgabe (`.lst` oder `.txt`) mit linker Margin und Spaltenlayout aehnlich Original.

## 8. Parser-/Evaluator-Migrationsstrategie

Empfohlener Ansatz:
1. Lexer + Recursive-Descent-Parser neu in C# schreiben (keine direkte 1:1-Portierung von Pascal-Codezeilen).
2. AST oder direkte Auswertung mit klarer Trennung von Parsing und Evaluation.
3. Zellreferenzen und Bereichssummen (`A1>B5`) als eigene Node-Typen.
4. Built-in Funktionen mappen auf `System.Math` + eigene `Fact`-Implementierung.
5. Fehlerdiagnostik mit Positionsangabe fuer UI-Feedback.

Tests (vor UI-Integration):
- Rechenoperator-Prioritaet.
- Klammerung und verschachtelte Ausdruecke.
- Zellreferenzen + Bereichssummen.
- Funktionsaufrufe inkl. Grenzfaelle (z. B. negative SQRT).
- Regressionstests gegen Beispiele aus `CALC.HLP`.

## 9. Umsetzung in Arbeitsphasen

## Phase 0: Projekt-Setup
- Neues Repo initialisieren oder bestehendes in saubere Struktur bringen.
- `.editorconfig`, `.gitattributes`, `.gitignore` anlegen.
- Solution + Projekte (`Core`, `Tui`, `Tests`) erzeugen.
- CI-Baseline (GitHub Actions: restore/build/test).

## Phase 1: Core-Domain
- Zell-/Sheet-Modelle inkl. Statusflags.
- In-Memory Spreadsheet-Operationen.
- Formatierungsobjekte (DEC/FW) und Anzeigeformatierung.

## Phase 2: Formelengine
- Parser/Evaluator implementieren.
- Rekalkulationsservice + Abhaengigkeitsstrategie (zunaechst Full-Recalc wie Original).
- Unit-Tests breit aufbauen.

## Phase 3: Use-Cases und Persistenz
- Load/Save (JSON).
- Print-Export.
- Command-Services (Clear, FormatRange, AutoCalc).

## Phase 4: Terminal.Gui UI
- Grid-Darstellung + Cursor-/Fokuslogik.
- Zell-Edit-Dialog + Validierung.
- Command-Menue (`/`) und Statusmeldungen.
- Help-Pager anbinden.

## Phase 5: Hilfe und Dokumentation
- `CALC.HLP` in neue Hilfeinhalte uebertragen.
- Bedienungsanleitung + Tastaturmapping dokumentieren.

## Phase 6: Hardening
- E2E-Szenarien manuell pruefen.
- Fehlerbehandlung, Logging, Performance-Check.
- Release-Readiness.

## 10. Git- und GitHub-Plan

Repository-Setup:
- Git initialisieren (`main` als Default).
- Branch-Strategie:
  - `main` stabil
  - Feature-Branches mit Prefix `codex/` (z. B. `codex/core-model`, `codex/formula-engine`).

Commit-Konvention:
- `feat:`, `fix:`, `test:`, `docs:`, `chore:`.

GitHub-Einrichtung:
- Neues GitHub-Repo erstellen.
- Remote setzen und pushen.
- Branch Protection fuer `main` (mind. 1 Review, gruenes CI).
- Issue-Templates:
  - Bug, Feature, Migration-Task.
- PR-Template:
  - Problem, Loesung, Tests, Screenshots (bei UI-Aenderungen).

CI/CD (GitHub Actions):
- Workflow 1: Build + Test bei Push/PR.
- Workflow 2 (optional): Release-Artefakt fuer plattformspezifische Builds.

## 11. Qualitaetssicherung

Testpyramide:
- Viele Unit-Tests in `MicroCalc.Core.Tests`.
- Wenige Integrations-/Smoke-Tests fuer TUI-nahe Flows.

Pflichttests fuer MVP:
- Parser-Evaluator-Regression.
- Load/Save-Roundtrip.
- Formatierung DEC/FW.
- AutoCalc On/Off Verhalten.
- Help-Pager Seitenwechsel.

Definition of Done (pro Feature):
- Funktion laeuft manuell im TUI.
- Relevante Tests vorhanden.
- Doku aktualisiert.
- CI gruen.

## 12. Risiken und Gegenmassnahmen

- Risiko: Terminal.Gui API-Aenderungen.
  - Massnahme: Version pinnen, Adapter-Schicht fuer UI-spezifische Aufrufe.

- Risiko: Formelkompatibilitaet zum Original.
  - Massnahme: Golden-Tests aus Originalbeispielen und Help-Beispielen.

- Risiko: Unterschiedliches Verhalten bei numerischen Grenzfaellen.
  - Massnahme: explizite Numeric-Rules dokumentieren und testen.

- Risiko: Legacy-`.MCS` wird erwartet.
  - Massnahme: Frueh klaeren; falls noetig separaten Importer als eigenes Arbeitspaket planen.

## 13. Konkrete MVP-Abgrenzung

MVP muss enthalten:
- 7x21 Grid, Navigation, Zellbearbeitung.
- Formeln inkl. Referenzen, Bereichssumme, Standardfunktionen.
- AutoCalc, Recalculate.
- Load/Save (JSON), Print-Export.
- Format-Kommando (DEC/FW + Locking analog Originalidee).
- Help-Pager mit migrierten Inhalten.

Nicht zwingend im MVP:
- Vollstaendige Binärkompatibilitaet zu `.MCS`.
- Erweiterte Undo/Redo-Stacks.
- Plugin-System.

## 14. Empfohlene Reihenfolge der ersten Issues

1. Repo + Solution + CI aufsetzen.
2. Core-Datenmodell implementieren.
3. Parser/Evaluator mit Tests fertigstellen.
4. Recalculate + AutoCalc anbinden.
5. JSON-Persistenz + Print-Export.
6. Terminal.Gui-Grundgeruest (Grid + Statusbar).
7. Zell-Edit-Flow integrieren.
8. Command-Menue integrieren.
9. Help-System integrieren und Inhalte migrieren.
10. Finales Testen, Doku, erster GitHub-Release.

## 15. Ergebnis dieses Plans

Mit diesem Plan kann die MicroCalc-Beispielanwendung strukturiert, testbar und mit hoher Verhaltensnaehe in eine moderne C#/.NET-10-TUI-Anwendung auf Basis von Terminal.Gui ueberfuehrt werden, inklusive Hilfe-System und professionellem GitHub-Workflow.
