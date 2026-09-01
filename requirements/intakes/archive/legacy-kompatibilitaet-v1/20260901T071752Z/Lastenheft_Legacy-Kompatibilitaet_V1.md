<!-- intake-authoring:begin -->
# Lastenheft: Legacy-Kompatibilität Version 1

**Status:** ReadyForReview  
**Zielgruppe:** TinyCalc-Anwendende mit historischen Arbeitsblättern, Auszubildende, Lehrende, Entwicklung und Review  
**Vorausgesetztes Wissen:** Grundlegende Tabellenkalkulation; keine Kenntnisse historischer Pascal-Binärformate erforderlich  
**Profil:** `level2-lastenheft`  
**Reihenfolge:** Nach PL/0-Zellfunktionen und vor Formelkopie und Tabellenoperationen

*Status: Ready for review. This intake follows PL/0 cell functions and precedes
formula copy and structural spreadsheet operations.*

## Begriffe beim ersten Gebrauch / Terms At First Use

### Deutsch

- **Legacy-Kompatibilität:** Übernahme fachlich nutzbarer Funktionen und Daten
  des Pascal-Originals ohne unnötige Emulation alter Hardware.
- **`.MCS`:** das binäre Arbeitsblattformat des historischen MicroCalc.
- **Dialekt:** eine unterscheidbare Formatvariante, hier insbesondere die
  Zahlenrepräsentation von `TURBO.COM` und `TURBO-87.COM`.
- **Atomarer Import:** Das aktive Blatt ändert sich erst, wenn die komplette
  Eingabedatei erfolgreich geprüft und umgewandelt wurde.

### English

- **Legacy compatibility:** preservation of useful Pascal-era behavior and
  data without unnecessary emulation of old hardware.
- **`.MCS`:** the binary worksheet format used by historical MicroCalc.
- **Dialect:** a distinguishable format variant, especially the number
  representations used by `TURBO.COM` and `TURBO-87.COM`.
- **Atomic import:** the active sheet changes only after the complete input has
  been validated and converted successfully.

## Zweck und Zielzustand / Purpose And Target State

TinyCalc soll nach der PL/0-Erweiterung historische Arbeitsblätter sicher in
das moderne JSON-Format übernehmen und noch fehlende, fachlich sinnvolle
Bediensemantik des Originals zugänglich machen. Moderne Barrierefreiheit und
plattformübliche Zwischenablage bleiben vorrangig.

*After PL/0, TinyCalc shall safely import historical worksheets into the modern
JSON format and expose useful missing interaction semantics while preserving
modern accessibility and clipboard conventions.*

## Umfang / Scope

- Erkennung und Import nachgewiesener `TURBO.COM`- und `TURBO-87.COM`-`.MCS`-
  Varianten.
- Vollständige Validierung von Größe, Zellzahl, Zeichenkettenlängen, Attributen,
  Zahlen, Formatwerten und Dateiende vor Übernahme.
- Konvertierung in das jeweils aktuelle TinyCalc-Datenmodell und anschließende
  Speicherung als JSON.
- Editorsemantik für Anfang/Ende, links/rechts, Löschen links/rechts,
  Insert/Overwrite und `Esc`-Rollback.
- Schutz vorhandener Formeln vor versehentlichem direktem Überschreiben.
- Vollständiger Formelquelltext der aktiven Zelle in einer textuell
  wahrnehmbaren Status-/Detailfläche.
- Direkte Ein-Tasten-Kommandos nach `/`, `Refresh` als moderner Name für
  `Update` sowie der im Pascal-Code belegte Alias `Ctrl-F` nach rechts.

*Scope includes safe import of both evidenced binary dialects and accessible
semantic parity for editing, formula protection, status details, commands, and
the source-backed navigation alias.*

## Nicht-Ziele / Non-Goals

- Kein Schreiben oder Exportieren von `.MCS`; JSON bleibt das einzige
  kanonische Schreibformat.
- Keine Formelkopie und keine strukturellen Zeilen-/Spaltenoperationen.
- Kein direkter Drucker- oder Gerätenamenzugriff.
- Keine 8.3-Dateinamenspflicht, CP/M-/DOS-Pfadregeln, IBM-Scancodes,
  Blinkvideo- oder LowVideo-Emulation.
- Kein blockierender historischer Willkommensbildschirm; ein dauerhaft
  sichtbarer Hilfehinweis und ein sofort erreichbarer Hilfepfad gelten als
  barriereärmere Entsprechung.
- Keine Übernahme kollidierender Alt-Tasten, wenn dadurch Zwischenablage oder
  Screenreader-Bedienung beschädigt würde.

*The feature neither writes MCS files nor emulates historical devices, names,
video attributes, or conflicting shortcuts. JSON remains canonical.*

## Funktionale Anforderungen / Functional Requirements

- **FR-001:** Der Import muss beide unterstützten Dialekte deterministisch
  erkennen; mehrdeutige oder unbekannte Dateien werden abgelehnt.
- **FR-002:** Import erfolgt in einen temporären Zustand. Ein Fehler darf weder
  aktives Blatt noch AutoCalc, Auswahl oder geladene PL/0-Funktionen verändern.
- **FR-003:** Alle 147 Zellrecords müssen vollständig und innerhalb fester
  Grenzen validiert werden; nachgestellte unerwartete Daten sind ein Fehler.
- **FR-004:** Zellinhalt, Typ, Wert, Dezimalstellen und Feldbreite werden soweit
  fachlich darstellbar verlustfrei übernommen.
- **FR-005:** Nicht darstellbare oder nicht endliche Werte erzeugen eine stabile,
  verständliche Diagnose mit Dialekt und Zellposition.
- **FR-006:** Erfolgreicher Import kann als aktuelles JSON gespeichert und ohne
  Bedeutungsverlust erneut geladen werden.
- **FR-007:** `Esc` verwirft Editoränderungen vollständig; Bestätigen übernimmt
  genau den sichtbaren Inhalt.
- **FR-008:** Insert/Overwrite muss auch ohne eine plattformspezifische
  Insert-Taste über eine fokussierbare, beschriftete Aktion erreichbar sein.
- **FR-009:** Direktes Tippen über eine Formel verlangt Bestätigung; ausdrücklich
  gestartetes Bearbeiten öffnet die Formel ohne redundante Rückfrage.
- **FR-010:** Ein-Tasten-Kommandos und moderne Menü-/Palettenbedienung müssen
  dieselben Aktionen und Ergebnisse verwenden.
- **FR-011:** Historische und moderne Bedienwege werden als neue `LEGACY-*`-IDs
  in den wachsenden Produktvertrag aufgenommen.

*Requirements bind deterministic dialect detection, bounded atomic import,
round-trip conversion, accessible editing semantics, formula protection, and a
single action model for legacy and modern command paths.*

## Qualität, Sicherheit und A11Y / Quality, Security And A11Y

- `.MCS` ist nicht vertrauenswürdige Binäreingabe und bildet eine neue
  Vertrauensgrenze. Parser verwenden keine unsichere native Deserialisierung.
- NIST SSDF, CWE Top 25, STRIDE und passende CAPEC-Muster gelten für Import,
  Pfade, Ressourcenverbrauch und Fehlerbehandlung.
- ASVS und Zero Trust sind für die lokale TUI `N/A`; AI-SBOM ist `N/A`, weil KI
  nur Entwicklungswerkzeug ist.
- SBOM/SLSA gelten für verteilbare Artefakte; VEX bei bekannten
  Schwachstellen.
- Alle Diagnosen, Editorzustände und Bestätigungen erfüllen die anwendbaren
  WCAG-2.2-AA-Kriterien und sind deutsch zuerst, englisch danach dokumentiert.

*MCS is an untrusted binary boundary. Secure parsing, bounded resources,
text-first diagnostics, WCAG 2.2 AA, and applicable supply-chain evidence are
mandatory.*

## Abhängigkeiten, Risiken und Evidenz / Dependencies, Risks And Evidence

- Harter Vorgänger: vollständig abgenommene PL/0-Zellfunktionen.
- Harter Nachfolger: Formelkopie und Tabellenoperationen.
- Benötigt mindestens eine nachvollziehbare Golden Fixture je Dialekt sowie
  beschädigte, abgeschnittene, übergroße und widersprüchliche Gegenbeispiele.
- Dokumentiert Formatannahmen, Erkennungsgrenzen und bewusst nicht
  rekonstruierbare Informationen.
- Führt vollständige Funktions-, Linux-/Windows-, macOS-PTY-, VoiceOver-,
  DocFX/axe/lynx- und Security-Gates aus.

*Evidence includes provenance-bound fixtures, malformed cases, documented
format assumptions, complete regression, platform, accessibility, and security
gates.*

## Abnahmekriterien / Acceptance Criteria

- **AC-001:** Jede gültige Fixture beider Dialekte importiert alle 147 Zellen
  mit den erwarteten Inhalten, Werten, Status- und Formatdaten.
- **AC-002:** Jede ungültige Fixture endet mit stabiler Diagnose und
  unverändertem Ausgangsblatt.
- **AC-003:** Importiertes Blatt besteht JSON-Save/Load und vollständige
  Neuberechnung.
- **AC-004:** Alle neuen Editor-, Formel-, Status- und Kommandowege sind per
  Tastatur und VoiceOver bedienbar.
- **AC-005:** Frühere Vertrags-IDs und alle neuen `LEGACY-*`-IDs bestehen auf
  demselben Commit.

*Acceptance proves both dialects, atomic rejection, JSON conversion, accessible
interaction parity, and full old-plus-new contract regression.*

## Annahmen und Entscheidungen / Assumptions And Decisions

- **IAD001 – beantwortet:** Legacy-Parität und neue Tabellenoperationen werden
  als zwei serielle Intakes getrennt.
- **IAD002 – beantwortet:** Beide nachgewiesenen `.MCS`-Dialekte werden
  importiert; `.MCS` wird nicht geschrieben.
- **IAD003 – beantwortet:** Historische Plattformmechanik ist `N/A`, sofern sie
  keinen heute nutzbaren fachlichen Wert besitzt.
- Delivery Authority bleibt `LocalImplementation`; keine Remote- oder
  Folgefeature-Berechtigung wird erteilt.

<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md als verbindliches Intake. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Bewahre die Reihenfolge nach PL/0, den sicheren Import beider nachgewiesener MCS-Dialekte, JSON als einziges Schreibformat, moderne A11Y-/Zwischenablage-Priorität sowie Security-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein Folgefeature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_Legacy-Kompatibilitaet_V1.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Stoppe vor Änderungen, solange PL/0 nicht vollständig abgeschlossen ist oder keine belastbaren Fixtures beider MCS-Dialekte vorliegen. Bewahre atomaren Import, JSON-Kanon, A11Y-, Security-, Plattform-, Dokumentations- und Evidenzgrenzen. Nicht pushen, keinen Pull Request erstellen oder mergen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```
<!-- intake-authoring:end -->
