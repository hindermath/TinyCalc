# PR: TUI-Funktionsvertrag und erweiterbare Intake-Roadmap

## Zusammenfassung / Summary

Diese Änderung führt einen vollständigen, dauerhaft erweiterbaren Vertrag für
alle heute über TUI, README und migrierte Hilfe angebotenen Funktionen ein.
Sie ordnet die Funktionsabnahme vor A11Y und Rename ein und ergänzt nach PL/0
zwei getrennte Lastenhefte für Legacy-Kompatibilität sowie Formelkopie und
Tabellenoperationen.

*This change introduces a complete and permanently extensible contract for all
capabilities currently offered through the TUI, README, and migrated help. It
orders functional acceptance before A11Y and rename, then adds separate
post-PL/0 intakes for legacy compatibility and structural spreadsheet work.*

## Umfang / Scope

- [ ] `MicroCalc.Core`
- [ ] `MicroCalc.Tui`
- [ ] Tests
- [x] Anforderungen und Intake-Governance
- [x] Dokumentation
- [ ] CI/CD

## Problem / Problem

Die abgeschlossene Terminal.Gui-Migration beweist noch keine vollständige
visuelle und interaktive Produktabnahme. Außerdem waren zukünftige PL/0- und
Legacy-Erweiterungen nicht durch einen additiven Funktionsvertrag und eine
vollständige Impact-Matrix mit den heute angebotenen Bedienwegen verbunden.

*The completed Terminal.Gui migration does not prove complete visual and
interactive product acceptance. Future PL/0 and legacy additions also lacked
an additive capability contract and a complete impact matrix tied to every
currently offered interaction path.*

## Lösung / Solution

- Neues Lastenheft für vollständige TUI-Funktionsabnahme mit stabilen,
  additiv erweiterbaren Vertrags-IDs und verbindlicher Quellenregel.
- Impact-Matrix für funktionale, A11Y-, Testinfrastruktur- und
  Release-Closeout-Änderungen.
- Versionsneutraler Terminal.Gui-Preflight anhand des jeweils freigegebenen
  Repository-Pins ohne automatisches Upgrade.
- Fortschreibung der A11Y-, Rename- und PL/0-Intakes.
- Getrennte Lastenhefte für MCS-Legacy-Kompatibilität sowie Formelkopie,
  Zeilen- und Spaltenoperationen.
- Aktualisierte 13-Ziele-Serie mit vier Wurzeln, neun harten Abhängigkeiten,
  vollständiger Vorgängerhistorie und neuem Review.

*The solution adds a stable functional contract, proportional regression
tiers, version-neutral dependency preflight, updated A11Y/rename/PL0 intakes,
separate legacy and structural-feature contracts, and a fully reviewed
thirteen-target series with preserved lineage.*

## Verhaltenshinweise / Behavioral Notes

Produktcode, Laufzeitverhalten, APIs, Pakete und persistierte Dateien werden
nicht verändert. Das Review-Ergebnis `Ready` bestätigt ausschließlich die
Konsistenz der Intake-Artefakte und ist keine Produktabnahme.

*Product code, runtime behaviour, APIs, packages, and persisted files remain
unchanged. The `Ready` review outcome applies only to intake consistency and is
not product acceptance.*

## Risiken / Risks

Das Hauptrisiko ist eine spätere Abweichung zwischen TUI, README, Hilfe und
Tests. Stabile Vertrags-IDs, Drift-Prüfungen und die Impact-Matrix begrenzen
dieses Risiko. Größere, unklare, dependency-bezogene, Rename- und
Release-Änderungen verlangen die vollständige Funktions-, A11Y-, PTY-,
VoiceOver-, DocFX/axe/lynx- und Plattformmatrix.

*The main risk is future drift between TUI, README, help, and tests. Stable
contract IDs, drift checks, and the impact matrix mitigate this risk.*

## Testplan / Test Plan

- sechs Intake-Receipts in PowerShell und Bash
- sechs Intake-Operationsartefakte in PowerShell und Bash
- 13-Ziele-Serienmanifest und Receipt in PowerShell und Bash
- vollständiger 13-Ziele-Review in PowerShell und Bash
- Governance-Konfiguration in PowerShell und Bash
- Archiv-, Hash- und Supersession-Lineage
- JSON-Syntax, Markdown-Whitespace, Reihenfolge und `git diff --check`
- Scope-Prüfung: keine Änderungen unter `src/` oder `tests/`

*The test plan validates all receipts, operations, series evidence, review
evidence, governance configuration, archive lineage, syntax, formatting, and
the requirements-only scope in both supported validation environments.*

Produkt-Build, Laufzeittests, DocFX-Neubau, PTY und VoiceOver sind für diese
reine Anforderungsänderung nicht erforderlich. Diese Gates werden durch die
neuen Intakes für die spätere Produktumsetzung verbindlich gemacht.

*No product build, runtime test, DocFX regeneration, PTY session, or VoiceOver
run is required for this requirements-only change. The new intakes make these
gates binding for later product implementation.*

## Screenshots und Terminalmitschnitte / Screenshots And Terminal Captures

Nicht anwendbar, weil dieses PR keine TUI-Implementierung verändert.

*Not applicable because this PR does not change the TUI implementation.*
