<!-- intake-authoring:begin -->
# Lastenheft: Formelkopie und Tabellenoperationen Version 1

**Status:** ReadyForReview  
**Zielgruppe:** TinyCalc-Anwendende, Auszubildende, Lehrende, Entwicklung und Review  
**Vorausgesetztes Wissen:** Zelladressen und einfache Formeln; Spec-Kit-Erfahrung wird nicht vorausgesetzt  
**Profil:** `level2-lastenheft`  
**Reihenfolge:** Nach der Legacy-Kompatibilität

*Status: Ready for review. This intake follows the completed legacy
compatibility feature.*

## Begriffe beim ersten Gebrauch / Terms At First Use

### Deutsch

- **Relativer Bezug:** Eine Zelladresse, die beim Kopieren um denselben Zeilen-
  und Spaltenabstand wie die Formel verschoben wird.
- **AST:** die strukturierte Darstellung einer geparsten Formel. Sie erlaubt
  sichere Referenzänderungen ohne fehleranfälliges Suchen und Ersetzen im Text.
- **Atomare Operation:** Entweder werden alle geplanten Zelländerungen
  übernommen oder keine.
- **`#REF!`:** ein sichtbarer, stabiler Fehler für einen Bezug auf eine
  tatsächlich gelöschte Zelle.

### English

- **Relative reference:** a cell address shifted by the same row and column
  distance as the copied formula.
- **AST:** the structured representation of a parsed formula, allowing safe
  reference changes without fragile text replacement.
- **Atomic operation:** either every planned cell change is applied or none is.
- **`#REF!`:** a visible stable error for a reference to a deleted cell.

## Zweck und Zielzustand / Purpose And Target State

TinyCalc soll die zwei ausdrücklich nicht implementierten Erweiterungsideen der
historischen Hilfe bereitstellen: Formeln kopieren sowie Zeilen und Spalten
einfügen oder löschen. Das feste Lernraster bleibt erhalten, Formelbezüge
bleiben nachvollziehbar und jeder mögliche Datenverlust wird vorab angezeigt.

*TinyCalc shall implement the two extension ideas explicitly absent from the
historical help: formula copy and row/column insertion or deletion. The fixed
learning grid remains, references stay explainable, and possible data loss is
shown before mutation.*

## Umfang / Scope

- Kopieren der Formel der aktiven Zelle in einen gewählten Zielbereich.
- Relative Anpassung einfacher Zellbezüge, Bereichsenden und Zellbezüge in
  Argumenten von `PL0.<Name>(...)`.
- Einfügen und Löschen einer ausgewählten Zeile oder Spalte im festen Raster
  `A1:G21`.
- Vorschau der betroffenen Zellen, Formeln, Referenzfehler und Randverluste.
- Explizite Bestätigung vor Überschreiben oder Datenverlust.
- Recalculate/AutoCalc, JSON, Print und Hilfe nach jeder Operation.

*Scope covers relative formula copy and atomic fixed-grid row/column
transformations, including PL/0 arguments, impact preview, confirmation, and
all affected product paths.*

## Nicht-Ziele / Non-Goals

- Kein dynamisch wachsendes oder schrumpfendes Raster.
- Keine absoluten Bezüge mit neuer `$`-Syntax in Version 1.
- Kein Kopieren von Zellformaten; die Formatierung des Zielbereichs bleibt
  erhalten.
- Keine stillen Bezugsumleitungen auf Nachbarzellen.
- Kein automatisches Bestätigen destruktiver Operationen.
- Kein allgemeines Undo-/Redo-System in Version 1.

*Version 1 keeps the 7x21 grid, adds no absolute-reference syntax or general
undo system, preserves target formatting, and performs no silent redirection.*

## Funktionale Anforderungen / Functional Requirements

- **FR-001:** Formelkopie akzeptiert nur eine gültige Formelzelle als Quelle
  und einen vollständig innerhalb `A1:G21` liegenden Zielbereich.
- **FR-002:** Jeder relative Zellbezug wird um den Abstand zwischen Quelle und
  jeweiligem Ziel verschoben; ein Bezug außerhalb des Rasters blockiert die
  gesamte Kopieroperation vor Mutation.
- **FR-003:** Bereichsoperatoren und Zellbezüge in verschachtelten eingebauten
  sowie PL/0-Funktionsargumenten werden AST-basiert angepasst.
- **FR-004:** Zielzellen behalten Dezimalstellen, Feldbreite und andere
  Formatattribute. Vorhandene Inhalte werden nur nach Bestätigung ersetzt.
- **FR-005:** Zeile einfügen verschiebt ab der Auswahl nach unten; Spalte
  einfügen verschiebt nach rechts. Belegte Randzellen werden als möglicher
  Verlust vollständig aufgelistet.
- **FR-006:** Zeile löschen verschiebt darunterliegende Zellen nach oben;
  Spalte löschen verschiebt rechte Zellen nach links. Der letzte Rand wird leer.
- **FR-007:** Referenzen auf mitverschobene Zellen folgen ihrem fachlichen Ziel.
  Referenzen auf tatsächlich gelöschte Zellen werden zu `#REF!`.
- **FR-008:** `#REF!` bleibt im Formeltext und nach JSON-Save/Load sichtbar und
  liefert eine stabile Fehlerdiagnose statt eines veralteten Zahlenwerts.
- **FR-009:** Vorschau und Bestätigung nennen Operation, Bereich,
  Überschreibungen, Randverlust und Anzahl entstehender `#REF!`-Formeln in Text.
- **FR-010:** Abbruch, ungültige Referenz, Parserfehler oder Laufzeitfehler lässt
  Blatt, AutoCalc und aktuelle Auswahl unverändert.
- **FR-011:** Nach Erfolg werden betroffene Formeln genau einmal neu berechnet;
  nicht betroffene Werte bleiben unverändert.
- **FR-012:** Alle neuen Bedienwege erhalten `SHEET-*`-IDs; sämtliche früheren
  Vertrags-IDs bleiben Pflichtregression.

*Requirements bind AST-aware relative copying, fixed-grid shifts, target-format
preservation, explicit impact previews, stable REF errors, atomicity, and full
old-plus-new regression.*

## Qualität, Architektur und Sicherheit / Quality, Architecture And Security

- Referenzen werden über Parser/AST verändert, niemals mit regulären
  Ausdrücken oder unstrukturiertem Textersatz.
- Planung und Ausführung werden getrennt: Eine unveränderliche Vorschau wird
  validiert und danach atomar angewendet.
- Fail-safe defaults verhindern Teiländerungen und nicht bestätigten
  Datenverlust.
- C#/.NET bleibt die speichersichere Hauptlaufzeit; NIST SSDF und CWE Top 25
  gelten. ASVS, Zero Trust und AI-SBOM sind begründet `N/A`.
- TUI-Vorschau, Bestätigung und Fehlerzustände erfüllen die anwendbaren
  WCAG-2.2-AA-Kriterien und sind deutsch zuerst, englisch danach dokumentiert.

*AST-based rewriting, immutable previews, atomic application, fail-safe
defaults, secure C#/.NET, and accessible bilingual interaction are mandatory.*

## Abhängigkeiten, Risiken und Evidenz / Dependencies, Risks And Evidence

- Harter Vorgänger: Legacy-Kompatibilität; dadurch sind PL/0-Syntax und
  historischer Import bereits Bestandteil des aktuellen Produktvertrags.
- Risiken: Off-by-one-Fehler, Bezugskorruption, stiller Randverlust,
  Teilmutation und veraltete AutoCalc-Werte.
- Testfälle umfassen erste, mittlere und letzte Zeile/Spalte, Einzel- und
  Bereichsbezüge, verschachtelte Funktionen, PL/0-Aufrufe, leere und belegte
  Ränder, Abbruch, JSON-Rundreise und `#REF!`.
- Vollständige Linux-/Windows-, macOS-PTY-, VoiceOver-, DocFX/axe/lynx- und
  Security-Gates sind erforderlich.

*The feature depends on completed legacy compatibility and requires boundary,
reference, PL/0, atomicity, persistence, platform, accessibility, and security
evidence.*

## Abnahmekriterien / Acceptance Criteria

- **AC-001:** Eine Formelkopie in jeden gültigen Zielbereich erzeugt exakt die
  erwarteten relativen Bezüge und verändert keine Zielformatierung.
- **AC-002:** Ein außerhalb des Rasters liegender Zielbezug blockiert ohne
  Teiländerung.
- **AC-003:** Einfügen und Löschen an Anfang, Mitte und Ende jeder Achse liefert
  die erwartete Zell- und Formelzuordnung.
- **AC-004:** Gelöschte Ziele erzeugen reproduzierbar `#REF!`; Save/Load und
  Recalculate bewahren den Fehlerzustand.
- **AC-005:** Jede destruktive Vorschau kann abgebrochen werden; der vorherige
  Zustand bleibt byteweise gleich serialisierbar.
- **AC-006:** Alle bisherigen und neuen Vertrags-IDs bestehen auf demselben
  Commit und allen verbindlichen Plattformen.

*Acceptance proves relative copy, fixed-grid transformations, REF behavior,
atomic cancellation, persistence, and complete contract regression.*

## Annahmen und Entscheidungen / Assumptions And Decisions

- **IAD001 – beantwortet:** Das Raster bleibt fest bei 7 Spalten und 21 Zeilen.
- **IAD002 – beantwortet:** Formelkopie und Verschiebungen passen relative
  Referenzen an.
- **IAD003 – beantwortet:** Bezüge auf gelöschte Zellen werden als `#REF!`
  sichtbar, nicht blockiert oder still umgebogen.
- **IAD004 – beantwortet:** Dieses Feature folgt als eigener serieller Intake
  auf die echte Legacy-Kompatibilität.
- Delivery Authority bleibt `LocalImplementation`; keine Remote- oder
  Folgefeature-Berechtigung wird erteilt.

<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md als verbindliches Intake. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Bewahre das feste 7x21-Raster, AST-basierte relative Referenzen einschließlich PL0-Aufrufen, Ziel-Formatierung, atomare Vorschau/Bestätigung, sichtbares #REF! sowie Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein Folgefeature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Stoppe vor Änderungen, solange die Legacy-Kompatibilität nicht vollständig abgeschlossen ist. Bewahre das feste Raster, AST-basierte Referenzanpassung, atomare Operationen, explizites #REF!, Ziel-Formatierung, vollständige Regression sowie Security-, A11Y-, Plattform-, Dokumentations- und Evidenzgrenzen. Nicht pushen, keinen Pull Request erstellen oder mergen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```
<!-- intake-authoring:end -->
