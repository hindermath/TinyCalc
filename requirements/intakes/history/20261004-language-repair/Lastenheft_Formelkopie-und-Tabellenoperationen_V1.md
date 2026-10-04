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

## Zweck / Purpose

TinyCalc soll die zwei ausdrücklich nicht implementierten Erweiterungsideen der
historischen Hilfe bereitstellen: Formeln kopieren sowie Zeilen und Spalten
einfügen oder löschen. Das feste Lernraster bleibt erhalten, Formelbezüge
bleiben nachvollziehbar und jeder mögliche Datenverlust wird vorab angezeigt.

*TinyCalc shall implement the two extension ideas explicitly absent from the
historical help: formula copy and row/column insertion or deletion. The fixed
learning grid remains, references stay explainable, and possible data loss is
shown before mutation.*

## Aktueller Zustand / Current State

- TinyCalc besitzt ein festes Raster `A1:G21`, aber keinen Befehl zum
  Formelkopieren und keine strukturelle Zeilen- oder Spaltenoperation.
- Eine Zelle speichert Inhalt, Statusflags, numerischen Wert, Dezimalstellen und
  Feldbreite; Anzeige-, Überlauf- und Berechnungszustände hängen teilweise von
  Nachbarzellen und Recalculate ab.
- Der vorhandene Formelparser wertet Bezüge aus, stellt aber noch keine
  öffentliche AST-Umschreibeschnittstelle bereit.
- JSON, Print, AutoCalc und der wachsende Produktvertrag müssen bei jeder
  strukturellen Änderung konsistent bleiben.

*TinyCalc has a fixed grid and persistent cell records but no formula-copy or
structural row/column operation. Formula rewriting and atomic sheet
transformations do not yet exist.*

## Zielzustand / Target State

- Formelkopie arbeitet aus einem unveränderlichen Quell-Snapshot und passt
  relative Bezüge AST-basiert für jedes Ziel an.
- Einfügen und Löschen verschiebt vollständige persistierte Zellrecords im
  festen Raster und zeigt jeden möglichen Verlust vorab an.
- Referenzen folgen verschobenen fachlichen Zielen; gelöschte Ziele werden
  sichtbar und dauerhaft zu `#REF!`.
- Abbruch und Fehler verändern nichts; Erfolg wird atomar angewendet und genau
  einmal konsistent neu berechnet.

*The target state provides snapshot-based relative copy, whole-cell fixed-grid
shifts, stable REF errors, previews, atomicity, and deterministic recalculation.*

## Umfang / Scope

- Kopieren der Formel der aktiven Zelle in einen gewählten Zielbereich.
- Überlappende Quell- und Zielbereiche mit unveränderlichem Quell-Snapshot,
  sodass eine früh geschriebene Zielzelle keine spätere Kopie beeinflusst.
- Relative Anpassung einfacher Zellbezüge, Bereichsenden und Zellbezüge in
  Argumenten von `PL0.<Name>(...)`.
- Einfügen und Löschen einer ausgewählten Zeile oder Spalte im festen Raster
  `A1:G21`.
- Verschieben des vollständigen persistierten Zellzustands aus Inhalt,
  Statusflags, Wert, Dezimalstellen und Feldbreite.
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
  einfügen verschiebt nach rechts. Dabei bewegt sich jeweils der vollständige
  persistierte Zellrecord. Belegte Randzellen werden als möglicher Verlust
  vollständig aufgelistet.
- **FR-006:** Zeile löschen verschiebt darunterliegende Zellen nach oben;
  Spalte löschen verschiebt rechte Zellen nach links. Auch hier bewegt sich der
  vollständige Zellrecord; der letzte Rand wird mit kanonischen
  Standardwerten leer initialisiert.
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
- **FR-013:** Alle Kopierziele werden aus derselben unveränderlichen
  Quellformel und demselben Blatt-Snapshot geplant. Überlappung darf weder
  kaskadieren noch von der Iterationsreihenfolge abhängen.
- **FR-014:** Nach einer strukturellen Verschiebung werden abgeleitete
  `Calculated`-, `OverWritten`- und `Locked`-Zustände aus dem verschobenen
  persistenten Zustand neu validiert; sie dürfen nicht als veraltete
  Anzeigeausnahme stehen bleiben.
- **FR-015:** Nach erfolgreicher Operation bleibt dieselbe gültige
  Zellkoordinate aktiv. Ihr Inhalt darf sich durch die bestätigte Verschiebung
  ändern; bei Abbruch bleiben Koordinate und Inhalt unverändert.
- **FR-016:** Vorschau und Anwendung verwenden denselben unveränderlichen
  Operationsplan einschließlich Referenzänderungen, Zellbewegungen,
  Randverlusten und erwarteter Nachberechnung.

*Requirements bind AST-aware relative copying, fixed-grid shifts, target-format
preservation, explicit impact previews, stable REF errors, atomicity, and full
old-plus-new regression.*

## Qualität, Architektur und Sicherheit / Quality, Architecture And Security

- Referenzen werden über Parser/AST verändert, niemals mit regulären
  Ausdrücken oder unstrukturiertem Textersatz.
- Planung und Ausführung werden getrennt: Eine unveränderliche Vorschau wird
  validiert und danach atomar angewendet.
- Formelkopie bewahrt ausschließlich die Ziel-Formatattribute; strukturelle
  Zeilen-/Spaltenoperationen verschieben dagegen den ganzen persistenten
  Zellrecord und validieren danach abgeleitete Zustände neu.
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

## Erwartete Artefakte / Expected Artifacts

- AST-basierter Referenz-Umschreiber und unveränderlicher Operationsplan in
  TinyCalc Core.
- Atomare Formelkopie sowie Zeilen-/Spaltentransformationen mit
  verlustanzeigender Vorschau.
- Persistentes `#REF!`-Modell und rückwärtskompatible JSON-Verarbeitung.
- Neue `SHEET-*`-Vertrags-IDs, Unit-, Integrations-, Datei-, PTY- und
  A11Y-Tests sowie aktualisierte Hilfe, API-Dokumentation,
  Security-Evidenz und Projektstatistik.

*Expected artefacts include AST rewriting, immutable plans, atomic copy and
shift operations, persistent REF errors, contract IDs, tests, documentation,
security evidence, and statistics.*

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
- **AC-007:** Überlappende Vorwärts-, Rückwärts- und zweidimensionale
  Kopierbereiche liefern unabhängig von der Iterationsreihenfolge dasselbe
  Ergebnis aus dem ursprünglichen Quell-Snapshot.
- **AC-008:** Einfügen und Löschen verschiebt Inhalt, Status, Wert,
  Dezimalstellen und Feldbreite gemeinsam; abgeleitete Zustände entsprechen
  nach Recalculate den geltenden Zellinvarianten.
- **AC-009:** Nach Erfolg bleibt die aktive Koordinate bestehen; nach Abbruch
  ist die serialisierte Tabelle einschließlich Auswahl- und AutoCalc-Zustand
  unverändert.

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
- **IAD005 – beantwortet:** Strukturelle Operationen verschieben den
  vollständigen persistenten Zellzustand, während Formelkopie die
  Zielformatierung bewahrt.
- **IAD006 – beantwortet:** Überlappende Kopien verwenden einen
  unveränderlichen Quell-Snapshot und dürfen nicht kaskadieren.
- Delivery Authority bleibt `LocalImplementation`; keine Remote- oder
  Folgefeature-Berechtigung wird erteilt.

<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md als verbindliches Intake. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Bewahre das feste 7x21-Raster, Snapshot-basierte überlappende Formelkopie, AST-basierte relative Referenzen einschließlich PL0-Aufrufen, Ziel-Formatierung bei Kopie, vollständige Zellrecords bei struktureller Verschiebung, atomare Vorschau/Bestätigung, sichtbares #REF! sowie Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein Folgefeature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_Formelkopie-und-Tabellenoperationen_V1.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Stoppe vor Änderungen, solange die Legacy-Kompatibilität nicht vollständig abgeschlossen ist. Bewahre das feste Raster, unveränderliche Quell-Snapshots, AST-basierte Referenzanpassung, vollständige Zellrecords bei Verschiebungen, atomare Operationen, explizites #REF!, Ziel-Formatierung bei Kopie, vollständige Regression sowie Security-, A11Y-, Plattform-, Dokumentations- und Evidenzgrenzen. Nicht pushen, keinen Pull Request erstellen oder mergen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```
<!-- intake-authoring:end -->
