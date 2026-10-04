<!-- intake-authoring:begin -->
# Lastenheft: Barrierefreiheit der TinyCalc TUI (A11Y)

**Status:** ReadyForReview
**Zielgruppe:** TinyCalc-Anwendende, Auszubildende, Lehrende, Entwicklung und Review
**Vorausgesetztes Wissen:** Grundlegende Tastaturbedienung; Kenntnisse über Screenreader oder Spec Kit werden nicht vorausgesetzt
**Profil:** `level2-lastenheft`
**Reihenfolge:** Nach der vollständigen TUI-Funktionsabnahme und vor dem internen Rename

*Status: Ready for review. This intake follows complete TUI functional
acceptance and precedes the internal rename.*

## Begriffe beim ersten Gebrauch / Terms At First Use

### Deutsch

- **A11Y:** Kurzform für Barrierefreiheit; zwischen `A` und `Y` stehen elf
  ausgelassene Buchstaben.
- **Screenreader:** Software, die sichtbaren Text und Bedienelemente vorliest
  oder an eine Braillezeile überträgt.
- **PTY:** ein Pseudoterminal für echte, automatisierte oder manuelle
  Terminalbedienung.
- **Fokus:** das aktuell per Tastatur bedienbare Element.
- **Impact-Klasse:** die im Produktvertrag festgelegte Einstufung, welche
  Prüfungen eine Änderung auslöst.

### English

- **A11Y:** short form for accessibility; eleven letters are omitted between
  `A` and `Y`.
- **Screen reader:** software that speaks visible text and controls or sends
  them to a Braille display.
- **PTY:** a pseudo-terminal for real automated or manual terminal interaction.
- **Focus:** the control currently operated from the keyboard.
- **Impact class:** the product-contract category that selects required checks.

## Zweck / Purpose

TinyCalc muss vollständig per Tastatur bedienbar, textuell verständlich und in
den anwendbaren Kriterien mit WCAG 2.2 Level AA vereinbar sein. Farbe, Position
oder Fokusrahmen dürfen nie allein Bedeutung tragen. Die Abnahme verbindet
automatisierte Prüfungen mit echten macOS-PTY- und VoiceOver-Bedienpfaden.

*TinyCalc must remain keyboard-operable, text-first, and conformant with
applicable WCAG 2.2 AA criteria. Automated checks are combined with real macOS
PTY and VoiceOver interaction.*

## Aktueller Zustand / Current State

- Die Terminal.Gui-Migration ist technisch abgeschlossen und kein Auftrag
  dieses Intakes.
- TinyCalc verwendet die jeweils im Repository ausdrücklich gepinnte und
  freigegebene Terminal.Gui-Version.
- Raster, Status- und Nachrichtenzeile, Menüs, Dialoge und mehrseitige Hilfe
  sind vorhanden, aber noch nicht vollständig mit realen Tastatur- und
  Screenreader-Pfaden abgenommen.
- Der vorgelagerte Produktvertrag inventarisiert alle aktuellen Tasten,
  Befehle, Dialoge, Datei-, Formel- und Hilfepfade.
- DocFX besitzt einen eigenen HTML-A11Y-Pfad mit Playwright/axe und lynx, der
  bei DocFX-Änderungen verbindlich ist.

*The migration is complete. Existing UI paths are inventoried by the preceding
product contract, but complete real-keyboard and screen-reader evidence is
still required.*

## Zielzustand / Target State

- Jede aktive Vertrags-ID besitzt eine tastaturbedienbare, textuell erkennbare
  und fokussichere Darstellung.
- Status, Fehler, Bestätigungen, Auswahl und Hilfe bleiben ohne Farbe
  verständlich.
- Automatisierte TUI-/PTY-Prüfungen und impact-gebundene VoiceOver-Nachweise
  beziehen sich auf denselben Commit.
- DocFX-Inhalte erfüllen den dokumentierten axe- und lynx-Nachweis.
- Spätere Features erweitern die A11Y-Vertrags-IDs additiv und führen die
  erforderlichen Gates dauerhaft erneut aus.

*Every active contract path gains keyboard, text, focus, PTY, screen-reader,
and documentation evidence appropriate to its impact.*

## Umfang / Scope

- Hauptfenster, Menü, Raster, aktive Zelle, Status- und Nachrichtenzeile.
- Sämtliche im Produktvertrag aufgeführten Navigationstasten und Aliasse.
- Editor, Befehlspalette sowie Load-, Save-, Print-, Format- und
  Clear-Bestätigungen einschließlich Abbruch.
- Hilfe mit Buttons, `P`/`N`, `Esc`, Seitenstatus und vollständiger
  Shortcut-Referenz.
- Fokusreihenfolge, sichtbarer Fokus, Kontrast, Textfeedback und Terminalgrößen.
- Linux-/Windows-Automation, macOS-PTY und impact-gebundene VoiceOver-Sitzung.
- DocFX/axe/lynx bei geänderten Dokumentations- oder API-Seiten.

*Scope covers every current TUI interaction, dialog, help path, focus and text
state, required platforms, real-terminal evidence, and documentation A11Y.*

## Nicht-Ziele / Non-Goals

- Keine erneute Terminal.Gui-Migration und kein automatisches
  Dependency-Upgrade.
- Keine Änderung der Formel- oder Tabellenfachlogik ohne einen während der
  A11Y-Prüfung bestätigten Funktionsdefekt.
- Keine Maus als alleiniger oder primärer Bedienweg.
- Keine Behauptung nativer UI-Automation-Semantik, die Terminal und Framework
  nicht bereitstellen.
- Kein interner Rename; er folgt als eigener Intake nach erfolgreicher A11Y-
  Abnahme.

*This intake does not repeat the migration, upgrade dependencies, redesign
spreadsheet logic, require pointer-only interaction, claim unavailable native
automation semantics, or perform the later rename.*

## Funktionale Anforderungen / Functional Requirements

- **R-A11Y-CALC-01:** Status- und Hilfetexte müssen alle kontextuell verfügbaren
  Tasten aus dem Produktvertrag vollständig und ohne widersprüchliche
  Doppelbelegung erklären.
- **R-A11Y-CALC-02:** Jede benutzerinitiierte Aktion erzeugt eine eindeutige
  sichtbare Textmeldung für Erfolg, Abbruch oder Fehler. Reine Farb- oder
  Positionsänderung genügt nicht.
- **R-A11Y-CALC-03:** Die mehrseitige Hilfe enthält eine strukturierte,
  textbrowser- und screenreadergeeignete Shortcut- und Befehlsreferenz.
- **R-A11Y-CALC-04:** Ein Preflight bestätigt die abgeschlossene Migration und
  löst die aktuell freigegebene Repository-Pin- und Lockquelle auf. Der Zustand
  wird als `AlreadySatisfied` belegt; Drift löst die vollständigen
  Kompatibilitäts-, PTY- und A11Y-Gates aus, aber kein automatisches Upgrade.
- **R-A11Y-CALC-05:** Text erreicht mindestens 4,5:1 Kontrast und große
  Textdarstellung mindestens 3:1, soweit das Terminal Farben kontrollierbar
  wiedergibt. Nicht-Text-Fokus- und Auswahlindikatoren erreichen die
  anwendbaren WCAG-2.2-AA-Anforderungen und besitzen zusätzlich Textbedeutung.
- **R-A11Y-CALC-06:** Alle Dialoge besitzen eine logische Fokusreihenfolge,
  eindeutig beschriftete Aktionen und vollständige Tastaturpfade für
  Bestätigen und Abbrechen.
- **R-A11Y-CALC-07:** Prozessbasierte PTY-Tests führen Navigation, Bearbeitung,
  Befehle, Hilfe, Datei- und Fehlerpfade mit beobachtbaren Textresultaten aus.
- **R-A11Y-CALC-08:** `A11yImpact`, größere TUI-Änderungen,
  Dependency-Drift und Release-Closeout verlangen eine dokumentierte
  macOS-VoiceOver-Sitzung; reine Textänderungen ohne TUI- oder DocFX-Wirkung
  wiederholen sie nicht.
- **R-A11Y-CALC-09:** Jede DocFX-Regeneration wird auf repräsentativen Seiten
  mit Playwright plus `@axe-core/playwright` und zusätzlich mit `lynx`
  textorientiert geprüft.
- **R-A11Y-CALC-10:** Alle Nachweise werden als stabile `A11Y-*`-IDs an den
  wachsenden Produktvertrag gebunden; alle früheren aktiven IDs bleiben
  Pflichtregression.

*Requirements cover contract-driven labels, text feedback, help, dependency
preflight, contrast, focus, PTY, VoiceOver, DocFX, and additive contract IDs.*

## Qualität, Sicherheit und Governance / Quality, Security And Governance

- WCAG 2.2 Level AA ist die konkrete Basis, soweit Kriterien auf Terminal oder
  HTML anwendbar sind.
- C#/.NET bleibt die speichersichere Hauptlaufzeit. NIST SSDF und CWE Top 25
  gelten immer.
- SBOM und SLSA gelten für verteilbare Artefakte; VEX wird bei bekannten
  Schwachstellen gepflegt.
- ASVS und Zero Trust sind für die lokale TUI begründet `N/A`. AI-SBOM ist
  `N/A`, weil KI nur Entwicklungswerkzeug ist.
- Dokumentation und Lerntexte stehen deutsch zuerst und englisch danach auf
  CEFR-B2-Niveau und bleiben für Braillezeile und Textbrowser verständlich.

*The quality boundary applies WCAG 2.2 AA, secure C#/.NET, NIST SSDF, CWE Top
25, applicable supply-chain evidence, and bilingual text-first delivery.*

## Abhängigkeiten, Risiken und Evidenz / Dependencies, Risks And Evidence

- Harter Vorgänger: vollständige TUI-Funktionsabnahme mit aktuellem
  Produktvertrag.
- Harter Nachfolger: interner Rename von MicroCalc zu TinyCalc.
- Risiken sind unvollständige Shortcut-Texte, Fokusverlust, rein farbliche
  Zustände, abgeschnittene Statusmeldungen, falsche Dialogabbruchpfade,
  Terminaltreiber-Unterschiede und nicht reproduzierbare VoiceOver-Nachweise.
- Evidenz umfasst Unit-/TUI-/PTY-Tests, Linux-/Windows-CI,
  commitgebundene macOS-PTY-/VoiceOver-Protokolle und DocFX/axe/lynx.
- Unsicherer Impact wird fail-safe als `FunctionalImpact + A11yImpact`
  klassifiziert.

*The intake depends on the functional contract and produces automated,
cross-platform, real-terminal, VoiceOver, and documentation evidence before
the rename.*

## Erwartete Artefakte / Expected Artifacts

- Vertragsgebundene Shortcut-, Fokus-, Status-, Dialog- und Hilfeverbesserungen.
- `A11Y-*`-Testfälle und Evidence-Matrix für automatisierte und manuelle
  Nachweise.
- Reproduzierbare macOS-PTY- und VoiceOver-Bedienprotokolle.
- Aktualisierte zweisprachige Hilfe, DocFX-Ausgabe und axe-/lynx-Evidenz, wenn
  diese Inhalte betroffen sind.
- Aktualisierte A11Y-/Security-Dokumentation und Projektstatistik nach den
  Repository-Regeln.

*Expected artefacts include accessible interaction updates, contract tests,
real-terminal evidence, documentation proof, security evidence, and
statistics.*

## Abnahmekriterien / Acceptance Criteria

- **AK-A11Y-CALC-01:** Jede aktive Vertrags-ID ist vollständig per Tastatur
  erreichbar und liefert eindeutigen sichtbaren Text.
- **AK-A11Y-CALC-02:** Erfolg, Abbruch und Fehler aller Dialoge verändern Fokus
  und Daten nur wie dokumentiert.
- **AK-A11Y-CALC-03:** Hilfe und Status erklären alle aktuellen Tasten und
  Befehle ohne Widerspruch.
- **AK-A11Y-CALC-04:** Der Dependency-Preflight belegt Migration und aktuellen
  Pin versionsneutral; Drift löst die Vollmatrix aus und kein Pfad führt ein
  Upgrade durch.
- **AK-A11Y-CALC-05:** Kontrast-, Fokus- und Nicht-Farb-Prüfungen bestehen für
  Raster, Auswahl, Menü, Dialoge, Status und Nachrichten.
- **AK-A11Y-CALC-06:** Linux-/Windows-Automation, macOS-PTY und die geforderte
  VoiceOver-Sitzung bestehen für denselben Commit.
- **AK-A11Y-CALC-07:** Geänderte DocFX-Seiten besitzen keine serious/critical
  axe-Verstöße und sind mit lynx vollständig verständlich.
- **AK-A11Y-CALC-08:** Alle früheren und neuen `A11Y-*`-Vertrags-IDs bestehen;
  Build, Unit-Test oder Smoke allein können den Abschluss nicht ausweisen.

*Acceptance proves complete keyboard and text paths, safe dialogs, current
dependency evidence, contrast, cross-platform PTY/VoiceOver, DocFX A11Y, and
full contract regression.*

## Annahmen und Entscheidungen / Assumptions And Decisions

- **IAD001 – beantwortet:** Die Terminal.Gui-Migration ist abgeschlossen und
  wird als `AlreadySatisfied` belegt, nicht erneut implementiert.
- **IAD002 – beantwortet:** Funktionsabnahme ist harter Vorgänger; Rename folgt
  erst nach dieser A11Y-Abnahme.
- **IAD003 – beantwortet:** Dependency-Anforderungen bleiben versionsneutral;
  maßgeblich ist der aktuelle freigegebene Repository-Pin zur Ausführungszeit.
- **IAD004 – beantwortet:** Vollständige Automation bleibt dauerhaft aktiv;
  reale macOS-PTY-/VoiceOver-Evidenz folgt den verbindlichen Impact-Triggern.
- Delivery Authority bleibt `LocalImplementation`; dieses Intake erteilt keine
  Commit-, Push-, PR-, Merge-, Bypass- oder Folgefeature-Berechtigung.

<!-- intake-authoring:prompts -->
## Ausführbare Spec-Kit-Prompts / Copy-Ready Spec Kit Prompts

### Specify

<!-- spec-kit-command-id: speckit.specify -->
```text
$speckit-specify Nutze requirements/intakes/active/Lastenheft_A11Y_TUI.md als verbindliches Intake. Erstelle oder aktualisiere ausschließlich die passende Feature-Spezifikation. Behandle die Terminal.Gui-Migration als AlreadySatisfied, löse den aktuellen Repository-Pin versionsneutral auf und bewahre die Reihenfolge Funktionsabnahme -> A11Y -> Rename, den vollständigen Produktvertrag, WCAG 2.2 AA, PTY-/VoiceOver-, DocFX/axe/lynx-, Security-, Plattform-, Dokumentations- und Evidenzgrenzen. Implementiere nichts; committe und pushe nicht; erstelle oder merge keinen Pull Request und starte kein Folgefeature.
```

### Autonomous

<!-- spec-kit-command-id: speckit.autonomous -->
```text
$speckit-autonomous Führe genau einen vollständigen autonomen Spec-Kit-Lauf mit requirements/intakes/active/Lastenheft_A11Y_TUI.md als verbindlichem Intake aus. Delivery Mode: LocalImplementation. Stoppe vor Änderungen, solange die vollständige Funktionsabnahme nicht abgeschlossen ist oder der Repository-Pin ungeklärt ist. Behandle die Migration als AlreadySatisfied und bewahre Produktvertrag, WCAG 2.2 AA, Impact-Matrix, PTY-/VoiceOver-, DocFX/axe/lynx-, Security-, Plattform-, Dokumentations- und Evidenzgrenzen. Nicht pushen, keinen Pull Request erstellen oder mergen, keinen Bypass nutzen, keine Secrets offenlegen und kein Folgefeature starten.
```
<!-- intake-authoring:end -->
