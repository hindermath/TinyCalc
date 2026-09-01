<!-- intake-authoring:begin -->
# Lastenheft: Vollständige TUI-Funktionsabnahme und dauerhafter Regressionsvertrag

**Status:** ReadyForReview  
**Zielgruppe:** TinyCalc-Anwendende, Auszubildende ab dem ersten Ausbildungsjahr, Lehrende, Entwicklung und Review  
**Vorausgesetztes Wissen:** Grundlegende Tabellenkalkulation; Spec-Kit-Erfahrung wird nicht vorausgesetzt  
**Profil:** `level2-lastenheft`  
**Reihenfolge:** Nach der abgeschlossenen Terminal.Gui-Migration und vor dem TUI-A11Y-Intake

*Status: Ready for review. Audience: TinyCalc users, apprentices from their
first training year, teachers, developers, and reviewers. This intake follows
the completed Terminal.Gui migration and precedes the TUI accessibility intake.*

## Begriffe beim ersten Gebrauch / Terms At First Use

### Deutsch

- **Produktvertrag:** eine versionierte Liste aller angebotenen Funktionen und
  Bedienwege mit stabilen Kennungen und zugehörigen Tests.
- **Drift:** ein unbeabsichtigter Unterschied zwischen TUI, README, Laufzeithilfe,
  migrierter Hilfe, Testfällen und dem Produktvertrag.
- **PTY:** ein Pseudoterminal, in dem eine echte Terminalanwendung automatisiert
  oder manuell bedient werden kann.
- **Impact-Klasse:** eine Einstufung, welche Prüfungen eine Änderung auslöst.
- **Repository-gepinnte Version:** die im Repository ausdrücklich festgelegte
  und reproduzierbar wiederherstellbare Abhängigkeitsversion.

### English

- **Product contract:** a versioned list of all offered capabilities and user
  paths with stable identifiers and matching tests.
- **Drift:** an unintended difference between the TUI, README, runtime help,
  migrated help, tests, and product contract.
- **PTY:** a pseudo-terminal in which a real terminal application can be used
  automatically or manually.
- **Impact class:** a category that determines which checks a change triggers.
- **Repository-pinned version:** a dependency version explicitly selected in
  the repository and restored reproducibly.

## Zweck / Purpose

TinyCalc muss alle Funktionen und Bedienwege zuverlässig ausführen, die das
aktuelle Produkt über TUI, README, Laufzeithilfe und migrierte Hilfe anbietet.
Die Abnahme darf sich nicht auf Build, Unit-Tests oder einen nicht-interaktiven
Smoke-Test beschränken. Ein dauerhafter Produktvertrag soll diese Vollständigkeit
auch nach späteren Features bewahren.

*TinyCalc must reliably execute every capability and user path offered by the
current TUI, README, runtime help, and migrated help. Build, unit tests, and a
non-interactive smoke test alone are insufficient. A durable product contract
shall preserve this completeness after later features.*

## Aktueller Zustand / Current State

- Die Terminal.Gui-Migration ist technisch abgeschlossen.
- Einzelne visuelle und interaktive Fehler wurden nachträglich korrigiert.
- Die vorhandenen Tests beweisen noch nicht jeden realen Tastatur-, Dialog-,
  Datei-, Hilfe- und Terminalpfad.
- Formelfunktionen, Befehle und Bedienhinweise werden an mehreren Stellen
  gepflegt und können voneinander abweichen.
- Abhängigkeitsversionen stehen in Projektdateien, werden in Anforderungen aber
  teilweise als zeitloser Sollwert beschrieben.

*The migration is technically complete, but existing evidence does not cover
every real interaction. Capability lists are distributed across several
surfaces, and dependency snapshots may be mistaken for permanent requirements.*

## Zielzustand / Target State

- Ein maschinenlesbarer Produktvertrag enthält alle aktiven Funktionen und
  Bedienwege mit stabilen IDs.
- Jede angebotene Funktion besitzt mindestens einen ausführbaren Erfolgsfall;
  Abbruch- und Fehlerpfade werden dort ergänzt, wo sie fachlich möglich sind.
- Drift zwischen Vertrag, TUI, README und beiden Hilfequellen blockiert die
  Abnahme.
- Automatisierte Vollregression läuft bei jedem Pull Request und Push.
- Echte macOS-PTY- und VoiceOver-Nachweise werden durch klare Impact-Trigger
  verlangt und nicht pauschal für reine Textänderungen wiederholt.
- Anforderungen bleiben versionsneutral; exakte Abhängigkeitsversionen bleiben
  trotzdem gepinnt und werden in der Evidenz dokumentiert.

*The target state provides a machine-readable contract, executable success,
cancel, and error paths, drift detection, complete automated regression, and
impact-triggered real-terminal evidence. Requirements remain version-neutral
while builds continue to use exact approved pins.*

## Umfang / Scope

- Start, Beenden und Wiederherstellung des Terminals.
- Festes Raster `A1` bis `G21`, sichtbare Auswahl und Randnavigation.
- Alle in TUI oder Hilfe angebotenen Pfeil-, Steuer- und Eingabetasten.
- Zellbearbeitung mit Bestätigen, Abbrechen, leerem Wert, Text, Zahl und Formel.
- Operatoren, Zellreferenzen, Bereichssumme und alle dokumentierten eingebauten
  Formelfunktionen.
- Recalculate, AutoCalc, Load, Save, Print, Format, Clear, Help und Quit über
  Menü und Befehlspalette.
- JSON-Rundreise, Textdruck, Hilfe-Navigation, fehlende Dateien, ungültige
  Eingaben und Formel-/Zyklusfehler.
- Mindestgröße `80x24` und die jeweils dokumentierte reale Terminalgröße.
- Versionsneutraler Dependency-Preflight und dauerhafte Testtrigger.

*Scope covers the complete currently offered grid, keyboard, editing, formula,
command, persistence, printing, help, error, terminal, and dependency-preflight
contract.*

## Nicht-Ziele / Non-Goals

- Keine PL/0-Zellfunktionen in diesem Feature.
- Kein interner Rename von MicroCalc zu TinyCalc.
- Kein `.MCS`-Import, keine Formelkopie und kein Einfügen oder Löschen von
  Zeilen oder Spalten.
- Keine Emulation historischer DOS-/CP/M-Geräte oder IBM-Scancodes.
- Kein automatisches Upgrade auf die neueste Terminal.Gui-Version.
- Keine Behauptung von 100 Prozent Zeilenabdeckung.

*This feature adds neither PL/0, rename work, legacy file import, formula copy,
structural sheet operations, historical platform emulation, nor automatic
dependency upgrades. Contract completeness is distinct from line coverage.*

## Funktionale Anforderungen / Functional Requirements

- **FR-001:** Der Produktvertrag muss stabile, nie wiederverwendete IDs, Status,
  Oberfläche, Plattform, erwartetes Ergebnis und Evidenzart enthalten.
- **FR-002:** Jede aktive Funktion aus TUI, README, Laufzeithilfe oder
  migrierter Hilfe muss genau einer oder mehreren Vertrags-IDs zugeordnet sein.
- **FR-003:** Jede aktive Pflicht-ID muss einen ausführbaren Test oder einen
  ausdrücklich begründeten manuellen Nachweis besitzen.
- **FR-004:** Fehlende, doppelte, veraltete oder unbelegte Pflicht-IDs müssen
  den Merge blockieren.
- **FR-005:** Alle aktuellen Navigations-, Editier-, Formel-, Befehls-, Datei-,
  Druck-, Format-, Clear- und Hilfewege müssen erfolgreich abgenommen werden.
- **FR-006:** Dialoge müssen sowohl Bestätigen als auch Abbrechen ohne
  unbeabsichtigte Nebenwirkung unterstützen.
- **FR-007:** Alle dokumentierten Formelfunktionen müssen über den echten
  Zellbearbeitungspfad als Formeln erkannt und ausgewertet werden.
- **FR-008:** Die Regression muss mindestens Linux und Windows automatisiert
  abdecken; macOS muss über den definierten PTY-Pfad belegt werden.
- **FR-009:** Änderungen werden als `NoFunctionalImpact`, `FunctionalImpact`,
  `A11yImpact`, `TestInfrastructureImpact` oder `ReleaseCloseout` klassifiziert.
  Unklarer Impact gilt fail-safe als `FunctionalImpact + A11yImpact`.
- **FR-010:** Vor TUI-relevanten Features muss ein Preflight die aktuell im
  Repository gepinnte und freigegebene Terminal.Gui-Version sowie ihre
  Deklarations- und Lockquelle ermitteln.
- **FR-011:** Ein unveränderter Pin erlaubt nur evidenzgebundene Wiederverwendung.
  Versionsdrift verlangt vollständige Kompatibilitäts-, PTY- und A11Y-Prüfung.
- **FR-012:** Ein fehlender oder gleitender Pin blockiert die Implementierung;
  der Preflight führt selbst kein Upgrade durch.
- **FR-013:** Neue Features müssen vor Produktcode neue Vertrags-IDs und rote
  Tests ergänzen; alle bisherigen aktiven IDs bleiben regressionspflichtig.
- **FR-014:** Eine Entfernung braucht einen ausdrücklich genehmigten
  Deprecation- oder Breaking-Change-Nachweis.

*The functional requirements bind stable IDs, complete surface coverage,
executable evidence, cross-platform regression, fail-safe impact classes, and
execution-time resolution of exact repository-approved dependency pins.*

## Qualität und Governance / Quality And Governance

- C#/.NET bleibt die speichersichere Hauptlaufzeit.
- NIST SSDF und CWE Top 25 gelten; ASVS, Zero Trust und AI-SBOM sind für die
  lokale, nicht KI-enthaltende TUI `N/A` und werden so dokumentiert.
- SBOM und SLSA gelten für verteilbare Artefakte; VEX wird bei bekannten
  Schwachstellen gepflegt.
- WCAG 2.2 AA ist die Basis für anwendbare TUI- und Dokumentationskriterien.
- Lern- und Bedieninhalte stehen deutsch zuerst und englisch danach auf
  CEFR-B2-Niveau und bleiben textorientiert verständlich.
- Red-Green-Refactor ist für jede Produktkorrektur verbindlich. Geänderter
  Produktcode erreicht mindestens 70 Prozent Coverage; 80 Prozent sind Ziel.

*The quality boundary applies memory-safe C#/.NET, NIST SSDF, CWE Top 25,
supply-chain evidence, WCAG 2.2 AA, bilingual CEFR-B2 delivery, and observable
red-green-refactor evidence.*

## Abhängigkeiten und Reihenfolge / Dependencies And Order

- Harter Vorgänger: abgeschlossene Terminal.Gui-Migration.
- Harter Nachfolger: TUI-A11Y.
- Danach folgt der vollständige Rename; ältere Rename-vor-A11Y-Angaben sind
  durch diese ausdrückliche Reihenfolge ersetzt.
- Spätere PL/0-, Legacy- und Tabellenfeatures erweitern den Vertrag additiv.

*The binding order is migration, functional acceptance, accessibility, then
rename. Later PL/0, legacy, and structural features extend the contract.*

## Erwartete Artefakte und Evidenz / Expected Artifacts And Evidence

- Versionierter Produktvertrag und Driftprüfung.
- Testbarer Aktions- und Interaktionskatalog.
- Unit-, Integrations-, PTY-, Datei- und TUI-Vertragstests.
- Linux-/Windows-CI sowie commitgebundene macOS-PTY-Evidenz.
- Dependency-Preflight mit aufgelöster Version, Quelle und Lock-Nachweis.
- Zweisprachige Hilfe-/README-Aktualisierungen und Projektstatistik.

*Expected evidence includes the contract, drift checks, action catalogue,
automated and real-terminal tests, dependency resolution evidence, synchronized
documentation, and project statistics.*

## Abnahmekriterien / Acceptance Criteria

- **AC-001:** 100 Prozent der aktiven Pflicht-IDs besitzen gültige Evidenz.
- **AC-002:** Alle aktuell angebotenen Funktionen und Bedienwege bestehen auf
  dem gleichen Commit; kein offener In-Scope-Fehler bleibt bestehen.
- **AC-003:** Linux- und Windows-Automation sowie die geforderte macOS-PTY-
  Sitzung bestehen für denselben Produktvertragsstand.
- **AC-004:** Ein absichtlich erzeugter Dokumentations- oder Testdrift wird
  zuverlässig erkannt und blockiert.
- **AC-005:** Dependency-Drift, unveränderter Pin und ungepinnter Zustand werden
  korrekt unterschieden; kein automatisches Upgrade findet statt.
- **AC-006:** Build, Unit-Tests oder Smoke allein können den Abschluss nicht als
  vollständig ausweisen.

*Acceptance requires complete active-contract evidence, same-commit platform
proof, effective drift detection, safe dependency classification, and no false
completion based only on build or smoke.*

## Annahmen und Entscheidungen / Assumptions And Decisions

- **IAD001 – beantwortet:** Funktionsabnahme folgt sofort auf die Migration;
  A11Y folgt danach und Rename erst anschließend.
- **IAD002 – beantwortet:** Vollständige Automation läuft bei jedem PR und Push;
  manuelle PTY-/VoiceOver-Evidenz folgt den definierten Impact-Triggern.
- **IAD003 – beantwortet:** Abhängigkeiten werden anforderungsseitig
  versionsneutral, aber buildseitig exakt gepinnt behandelt.
- Delivery Authority bleibt `LocalImplementation`; dieses Intake erteilt keine
  Commit-, Push-, PR-, Merge-, Bypass- oder Folgefeature-Berechtigung.

*The accepted decisions bind the order, durable regression, impact-triggered
manual evidence, and version-neutral requirements with exact build pins.*

<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md als verbindliches Intake. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Bewahre den aktuellen Produktumfang, die Reihenfolge Migration -> Funktionsabnahme -> A11Y -> Rename, den wachsenden Produktvertrag, die versionsneutrale Dependency-Regel sowie Security-, A11Y-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein Folgefeature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Bewahre Scope, Reihenfolge, vollständigen Produktvertrag, versionsneutralen Dependency-Preflight, Security-, A11Y-, Plattform-, Dokumentations- und Evidenzgrenzen. Nicht pushen, keinen Pull Request erstellen oder mergen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```
<!-- intake-authoring:end -->
