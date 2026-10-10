# Dokumentationswirkung / Documentation impact

## Deutscher Entscheidungsblock

Entscheidung `UpdateRequired`, Feature 006. Zielgruppe sind Lernende ab dem
ersten Ausbildungsjahr und TinyCalc-Anwendende; Owner Thorsten, Umsetzung
Feature-Entwicklung. Intake/Spec/Plan bleiben unverändert verbindlich. Kein
Home-Sync, Produkt-Rename oder neues Funktionsangebot.

Lesepfad: [README](../../../README.md) →
[Hilfe](../../../docs/help/microcalc-help.md) →
[Vertragsleitfaden](../../../docs/contracts/tui/README.md) →
[Katalog](../../../docs/contracts/tui/catalog.md) →
[lokale echte Vollbelege](platforms/macos/local-build105.md).
Formelbeispiele und Tastenkontexte folgen den genehmigten Orakeln. Historische
Pascal-Hilfe wird ausdrücklich von den aktuellen DE-/EN-Portseiten getrennt.
Die ausgelieferte Ressource und Root-Hilfe bleiben gleich; die Anzahl der
Hilfeseiten ändert sich nicht. P/N, Scrollen, Fokusumlauf und Schließen stehen
als Text in der Hilfe; Farbe ist nie die einzige Informationsquelle.

Neue Texte verwenden DE zuerst, EN danach, semantische Überschriften und
lesbare Tabellen. Der generierte Katalog zählt alle 1.092 Tupel, nicht bestandene
Tests. `render-tui-contract-catalog.ps1` wurde nach Quellbindung ausgeführt;
Katalog-/Validatorprüfungen und DocFX-A11Y werden getrennt ausgewiesen.
DocFX 107 ist erfolgreich: null Fehler/83 Warnungen. Die gezielt ergänzte
Publikation der Feature- und gebundenen Intake-/JSON-Artefakte beseitigt die
Feature-006-Linkwarnungen. Vier tatsächliche Leserpfadseiten besitzen `lang=de`,
je eine Main-Landmark, lesbare ARIA-Snapshots und null fehlende Artikel-Linkziele.
Lynx prüft README/Hilfe/Vertragsleitfaden explizit in UTF-8. Die API-Stichprobe
besitzt ebenfalls Sprache und Landmark, aber zwei fehlende historische
Namespace-Ziele. axe und menschliche A11Y bleiben offen; T073 ist nicht erledigt.
T072 ist für die Dokumentationsentscheidung und den aktuellen Leserpfad belegt;
dieses Dokument erteilt keine Produktfreigabe.

Ignoriertes Original `TestResults/006-docfx107-playwright.json`, SHA-256:
`5ea00882851ba7c075375cd0bfa2a79cb0c2b2ad3e4fc2dea50175b835a0c7a7`.
Build-/Lynx-Protokolle liegen im gleichen eigenen TestResults-Verzeichnis.

## English decision block

UpdateRequired applies to first-year learners and product users. The linked
README/help/contract/catalogue/evidence path retains approved semantics, explicit
historical-versus-current help, bilingual text and a colour-independent reading
path. Bundled and root help match without adding pages. The catalogue describes
all 1,092 obligations, not passed tests. Separate documentation generation,
DocFX build 107 passes with no errors and 83 warnings. Four actual reading-path
pages have German language, one main landmark, readable ARIA snapshots and no
missing article targets. Explicit UTF-8 Lynx checks cover README/help/guide.
The API sample retains two missing historical namespace targets. axe and human
accessibility remain Open under T073. T072 closes the documentation decision
and current reader path, not product acceptance. The hash above binds the actual
ignored Playwright report. No home synchronisation, rename or new feature.
