# Technische Planung: barrierefreie TUI / Technical Plan: Accessible TUI

**Branch:** `007-tui-accessibility` | **Datum / Date:** 2026-10-12
**Basis / Basis:** [geklärte Spezifikation](spec.md), CQ-001/CQ-002 jeweils Antwort A.
**Status:** Planungsentwurf zur Owner-Prüfung; keine Umsetzung oder Lieferung freigegeben.

**Nachtrag / Addendum 2026-10-18:** `tasks.md` wurde separat beauftragt erstellt; zwei `/speckit.analyze`-Läufe führten zu beauftragten Korrekturen dieses Plans (Evidence-Pfad nach Verfassungskonvention, B01-Reihenfolge). Die Stopp-Klausel am Ende bleibt die historische Grenze des Planlaufs, kein Verbot dieser späteren Aufträge. / Tasks were generated separately; two analysis runs led to authorised plan corrections. The final stop clause remains the historical limit of the planning run.

**Dokumentennachprüfung / Document recheck:** 2026-10-18, Basis `f373437`; Korrekturen aus CHK-001–020 und PL-001–014, kein neuer Plan-/Tasks-Lauf.

*Planning draft for owner review; neither implementation nor delivery is authorised.*

## Zusammenfassung / Summary

Die vorhandene TUI wird innerhalb ihrer bestehenden Session-/Core-Grenze verbessert. Vollständiger Umfang: zehn R-A11Y-CALC-Anforderungen, acht AK-Abnahmen und alle 17 Funktionsfamilien aus Feature 006; 364 bestehende Pflichttupel je Plattform sind die Baseline, kein Deckel für additive Wege. Migration → Funktionsabnahme → A11Y → Rename bleibt bindend. Issue #107 ist ergänzende Evidenz, kein neuer Auftrag.

*Improve the existing TUI within its current session/Core boundary. Preserve all ten requirements, eight criteria and 17 functional families. The 364 existing obligation tuples per platform are a baseline, not a cap. Keep migration → functional acceptance → accessibility → rename. Issue #107 supplements evidence without granting additional work.*

Die Umsetzung beginnt erst nach separatem Auftrag mit Quellen-/Dependency-Preflight und ID-/Orakelbindung vor jeder Produktkorrektur, danach einem frühen nativen VoiceOver-Machbarkeitsgate und direkten Eingaberegressionen. Kleine Änderungen an Beschriftung, Fokus, Rückmeldung, Hilfe und Kontrast folgen nur bei belegtem Bedarf. Keine neue öffentliche API, native Bridge, linearer Ersatzmodus, Frameworkmigration oder Paketaktualisierung wird vorab beschlossen. Eine nicht erfüllbare Fokusansage bleibt Fail/Open und verlangt eine neue Entscheidung, keinen stillen Ersatz durch Zeilenlesen.

*Future authorised execution starts with source/dependency preflight and ID/oracle binding before any product correction, then early native feasibility and direct-input regression. Make small evidence-driven changes to labels, focus, feedback, help and contrast. No public API, native bridge, replacement mode, framework migration or package upgrade is selected. An unattainable focus announcement remains Fail/Open and requires a new decision rather than substitution with line reading.*

## Technischer Kontext / Technical Context

| Bereich / Area | Verbindlicher Kontext / Binding context |
|---|---|
| Sprache / Language | C# mit .NET 10 (`net10.0`), C#-14-Toolchain gemäß Planvorlage; C# ist MSL / memory-safe C# |
| Abhängigkeiten / Dependencies | Aktuell deklarierter Terminal.Gui-Pin `2.4.17`; späteren freigegebenen Pin samt vier Locks prüfen, keine normative Dauerbindung / inspect the later approved pin and four locks without permanent pinning here |
| Produkt / Product | Lokale TUI; `Program`, interne `TuiSession`, `GridColorScheme`, `TerminalStateLease`, `HelpDocument`; getrennte Core-Engine / local TUI with separate Core |
| Speicherung / Storage | Bestehende einzelne JSON-Tabelle, Textdruck und Hilferessource; kein neues Produktformat / existing JSON sheet, text print and help resource |
| Tests / Tests | xUnit, produktive Views über `LegacyProgramUiAdapter`, tatsächliche PTY-Prozesse, getrennte native VoiceOver-Sitzung / product views, real PTY and separate native reader session |
| Plattformen / Platforms | macOS, Linux, Windows; native VoiceOver-Referenz Mac A + Terminal.app / native reference from CQ-001 |
| Größen / Sizes | 80x24 und 120x40 Pflicht; 120x28 zusätzlich für #107 / baseline sizes plus reproduction |
| Leistung / Performance | Bestehende Ressourcen-/Timeoutgrenzen erhalten; kein neues SLA und keine erfundene Millisekundenschwelle für Sprache / retain resource limits, no new SLA or speech timer |
| Qualität / Quality | Alle aktiven Wege erhalten; null unbeabsichtigte Datei-/Tabellenänderungen; unmittelbare eindeutige Aktionsansage ohne zusätzliche Leseschritte / preserve every path and data invariant, immediate clear action naming |

Der bindende Registereintrag ist `RiderProjects/TinyCalc` in [constitution.md](../../constitution.md), Level-2 Project Environment Registry, mit Spiegel [.specify/memory/constitution.md](../../.specify/memory/constitution.md): .NET 10/C#, xUnit/Smoke, DocFX mit Text-A11Y und Referenzen 80/125 Zeilen je Arbeitstag. Runtime, Version, Verfassung und Agentenguidance bleiben in diesem Planlauf unverändert.

*Use the TinyCalc Level-2 registry row and its mirror: .NET 10/C#, xUnit/smoke, text-accessible DocFX and 80/125-line reference baselines. This planning run changes no runtime, assembly version, constitution or agent guidance.*

## Verfassungsprüfung / Constitution Check

Vor Forschung und nach Design geprüft am 12.10.2026. `Erfüllt` in dieser Tabelle bezeichnet Planabdeckung, niemals bestandene Produktprüfungen. Owner aller Folgeaktionen: Thorsten; Dokumentenreview: planender Agent, kein unabhängiger Review. Produktumsetzung und Produktnachweise: `Not Assessed`. Allgemeines Restrisiko: spätere Ausführung fehlt. Wiedervorlage: vor Umsetzung und bei Scope-/Pin-/Quelländerung.

*Checked before research and after design. Fulfilled here means planning coverage, not passed product checks. Thorsten owns follow-up; the planning agent performs document review only. Product implementation/evidence is Not Assessed; missing future execution is the residual risk. Re-evaluate before implementation or scope/pin/source changes.*

| Gate | Anwendbarkeit, Planentscheidung und erwartete Evidenz / Applicability, planned disposition and expected evidence |
|---|---|
| Branch/PR | Applicable; bestehender Branch 007, später fokussierter PR nur nach Lieferauftrag. Keine Git-Aktion jetzt / no delivery now |
| .NET/C#/MSL | Applicable; bestehende Projekte behalten; später SDK/Compiler und Registry abgleichen, `evidence/dependency-preflight.md` / retain projects and verify toolchain |
| Versionierung / Versioning | Applicable vor späterem Build/Test/Commit: Minor 7, Patch nach Branch-Commitzahl, Build vor jedem Build/Test erhöhen; alle drei Felder synchron. Jetzt keine Versionsänderung / align all fields only at the authorised boundary |
| Schichtgrenzen / Layers | Applicable; Core kennt weder Screenreader noch Nachweisdateien; `docs/architecture/007-tui-accessibility.md` später / Core remains independent |
| DE/EN, CEFR B2 | Applicable; Spezifikation, Planung, Laufzeithilfe und Evidenz deutsch zuerst; Begriffe beim ersten Gebrauch / bilingual learner-oriented delivery |
| XML/DocFX | Applicable bei öffentlichen API/XML-Änderungen, derzeit keine geplant. Hilfen/Dokumentationsinhalt löst DocFX + Snapshot/axe/lynx aus / conditional API docs and mandatory documentation checks |
| TDD/Coverage | Applicable bei späteren Produktkorrekturen: ausführbares Rot → Grün → Refactor; Changed-Code mindestens 70 %, Ziel 80 %. Jetzt N/A mangels Codeänderung; Trigger Produktcode / no execution now |
| Dependency/Locks | Applicable; Locked Restore erst später. `AlreadySatisfied` nur bei freigegebenem unverändertem Graph und gültigen Nachweisen; Drift verlangt Vollprüfung, kein Upgrade / neutral preflight |
| Serialisierung / Serialization | Applicable als Erhaltungspflicht: JSON-Rundreise, Fehler/Abbruch ohne Teilwirkung; kein Produktformatwechsel / preserve existing storage semantics |
| Security | Applicable; SSDF, CWE Top 25, sichere C#-Eingaben/Dateipfade/Fehler, synthetische Daten; `docs/security/security-checklist.md`, featurebezogener Nachweis gemäß Verfassungskonvention `<datum>-<scope>` unter `docs/security/secure-development/<JJJJ-MM-TT>-007-tui-accessibility/`, Datum der Ordneranlage in T005; der undatierte 006-Ordner bleibt historisch unverändert / scoped future evidence in a dated folder per constitution convention |
| Architektur/STRIDE/CAPEC | Applicable; bestehende Eingabe-, Datei-, Terminal- und Evidenzgrenzen prüfen; `docs/security/threat-model.md`, `docs/security/arc42-security.md`. Relevante CAPEC-Muster bei konkreten Risikoflows binden, keine IDs erfinden / review existing boundaries and actual threats |
| ADR/S-ADR | N/A für eine neue Architekturentscheidung in dieser Dokumentennachprüfung; keine Bridge/Trust-Boundary-Änderung beschlossen. Trigger: notwendiger materieller Entwurf; dann stoppen, Owner Thorsten entscheidet über ADR unter `docs/architecture/adr/` und S-ADR unter `docs/security/adr/` / no new design now; significant later design requires a separate decision |
| ASVS | N/A, kein Web/API/HTTP-/Auth-Dienst; Level N/A. `docs/security/asvs-verification.md`; Trigger neuer Dienst / local TUI only |
| SBOM/SLSA | Applicable für spätere Releases/CI-Artefakte, keine Erzeugung jetzt; `docs/security/supply-chain-evidence.md`, Provenienz mindestens L1 soweit machbar, keine erreichte Stufe behauptet / later artefact evidence |
| VEX | Open, bedingt durch bekannte relevante Schwachstelle; vor Umsetzung/Release Audit prüfen, Owner Thorsten, `docs/security/dependency-audit.md` / actual vulnerability disposition remains unassessed |
| AI-SBOM | N/A, KI nur Entwicklungswerkzeug, keine KI-Runtime; Supply-Chain-Notiz, Trigger Produkt-KI / development tooling only |
| Zero Trust | N/A, lokale TUI ohne verteilten/remote-verwalteten Produktfluss; `docs/security/zero-trust-applicability.md`, Trigger neue Dienste / retain local scope |
| BSI C3A/C5 | N/A, keine Cloud-Auswahl oder Deploymentänderung; `docs/security/cloud-autonomy-applicability.md`, erwarteter Assurance-Pfad `docs/security/cloud-compliance-assurance.md`; Trigger Cloudintegration / no assurance claim |
| SAMM | Applicable als vorhandener langlebiger Prozesskontext; Befunde in `docs/security/samm-assessment.md`, kein Voll-Reassessment jetzt / retain process context |
| Cheat Sheets/Proactive Controls/Scorecard | Applicable als Entwicklungs-/OSS-Reviewreferenzen; später im Dependency-/Securityreview, kein aktueller Score behauptet / supporting references, no invented audit |
| Datenschutz/regulatorischer Scope / Regulatory scope | Applicable als Verweis auf bestehende `docs/security/regulatory-applicability.md`: DS-GVO/KI-VO/CRA/NIS2/DORA getrennt für Produkt, Tools, Organisation. Keine neue Rechtsentscheidung; unbekannt bleibt Open mit bestehendem Owner/Frist / applicability reference only; preserve dated dispositions |
| A11Y | Applicable; gesamtes Intake, CQ-001/002, Kriterienmatrix und native Nachweise nach `contracts/README.md`; kein Voll-WCAG-Zertifikat / full intake and actual native proof |
| Skriptparität / Script parity | Applicable für die geplante Validatorpflege; Bash und PowerShell, Advanced Function Verb-Noun, bilinguale Hilfe, Manpage und native manuelle Prüfung je Variante; `evidence/script-parity.md` später. Ausführung jetzt N/A mangels Skriptänderung; Trigger spätere Änderung / plan paired verification; no script execution/change now |
| Agentenparität / Agent parity | N/A jetzt, keine Regeländerung. Trigger gemeinsame Guidance/Templateänderung: alle fünf Agentenflächen, Vorlagen und Spiegel atomar prüfen; `evidence/agent-parity.md` später, falls betroffen / no needless governance churn |
| Statistik / Statistics | Applicable; Ledger jetzt, commitgebundener Profil-2-Block unverändert. Später sauberer Quellencommit nur nach Auftrag; Preview/Render/Check / preserve clean-source guard |
| Autonom/parallel / Autonomous/parallel | N/A für Ausführung, kein delegierter Lauf; keine Run-State-Datei und keine Provideraktion / installation grants no authority |

Die acht Basis-Presets sind Security, Architecture, iSAQB, A11Y, Cross-platform, Agent parity, Autonomous und Parallel-autonomous mit den Versionen der Verfassung. Ergänzend installiert: Intake Authoring/Review/Sequencing, Secure Development Assurance, Model Routing und Project Statistics. Anwendbare Vorgaben sind oben gebunden; Model Routing ist operative Guidance, keine Modellbindung in Featureartefakten. Keine Preset-/Templatepflege im Arbeitspaket.

*The eight baseline presets and six installed intake/assurance/routing/statistics extensions retain their constitution versions and scoped applicability above. Model routing is operational guidance, not a feature model pin. This work changes no preset or template.*

## Projektstruktur / Project Structure

```text
specs/007-tui-accessibility/
  spec.md
  plan.md
  research.md
  data-model.md
  quickstart.md
  tasks.md
  contracts/README.md
  checklists/requirements.md
  checklists/plan.md
  checklists/a11y.md
src/MicroCalc.Tui/
  TuiSession.cs                 vorhandene Dialog-/Fokus-/Feedbackwege
  GridColorScheme.cs            vorhandene Farben/Kontrast
  TerminalStateLease.cs         vorhandene Terminalrücksetzung
  Help/HelpDocument.cs
  Resources/CALC.HLP
tests/MicroCalc.Tui.Tests/       vorhandene Vertrags-/Dialog-/Editor-/PTY-Tests
scripts/lib/tui-contract/       vorhandene lesende Validatorbausteine
scripts/tests/tui-contract/     vorhandene Negativ-/PTY-Fixtures
docs/contracts/tui/             unabhängige Baseline und aktive Vertrags-IDs
```

Die textuelle Zuordnung ist vollständig: TuiSession verantwortet Bedienkontext, Widgets vermitteln Eingaben, Core bleibt Fachlogik, Terminalhost/Reader liefern getrennt nachzuweisende Ausgabe. Keine zusätzliche Bibliothek oder neues Projekt. `tasks.md` und `checklists/a11y.md` wurden durch separat beauftragte Folgeläufe ergänzt. Spätere neue Tests bleiben im bestehenden Testprojekt, ausführungsgebundene Paritätschecklisten (`checklists/script-parity.md`, `checklists/agent-parity.md`) und Nachweise unter `evidence/`; diese Orte werden jetzt nicht als ausgeführte Evidenz angelegt.

*The structure preserves interaction in TuiSession, widgets for input and Core for domain logic, with separately verified host/reader output. Add no library/project. Separate authorised runs added tasks.md and checklists/a11y.md. Future tests stay in the existing test project, and execution-bound parity checklists (checklists/script-parity.md, checklists/agent-parity.md) plus actual proof go in evidence; no execution evidence is fabricated now.*

## Phase 0: Forschung und Vorprüfung / Research and Preflight

Die Ergebnisse stehen in [research.md](research.md). Read-only Alignment am Basiscommit `935fce0d6946748bea4119877fecab43a88ae8cb`: 13 aktuelle Receipts, Serie Active mit 13 Zielen/4 Roots/9 Kanten, A11Y Eligible, Migration/Funktionsabnahme Completed, Review `30ca6838-1bdf-49e3-8f94-d72e990c6728` Ready. Kein Governance-Drift festgestellt. Vor Umsetzung wiederholen.

*Research records repository inspection and current receipt/series/review checks at the named base. Revalidate before execution; no lifecycle changes are made.*

Besonderer technischer Befund: `scripts/test-tinycalc-contract.ps1` löst das Funktions-Intake noch über einen festen aktiven Pfad auf, obwohl das Intake archiviert wurde. Dieser Plan führt den Validator nicht als bestanden aus. Vor Regression muss eine spätere autorisierte Korrektur die bestehende Quellenbindung lifecycle-fest auflösen und alte Hash-/Negativprüfungen bewahren. Kein Wiederherstellen eines zweiten aktiven Intakes und kein Governance-Update als stiller Workaround.

*The existing contract validator still resolves the functional intake through a fixed active path after archival. This plan does not claim that validator passes. Future authorised execution must make resolution lifecycle-aware while preserving hashes and negative checks. Do not recreate an active intake or silently modify governance.*

## Phase 1: Design und Ausführungsreihenfolge / Design and Execution Order

1. **Vorprüfung und Testbindung:** Quellen-/Review-Frische, freigegebene Pakete, vier Lockdateien, genehmigte Funktionsbaseline und Impact `A11yImpact` binden. Vor jeder neuen Produktkorrektur additive IDs in Einzelwege/Plattformen expandieren, unabhängig zugeordnete Orakel und kompilierbare rote Regressionen vorbereiten. Native Erwartungen zusätzlich vor der Sitzung festhalten; eine fehlende Sitzung ist kein fachliches Rot. Validatorpfad-Befund test-first beheben, soweit durch späteren Auftrag gedeckt. Bei Drift verbindlicher Intake-Quellen stoppen und gesondertes Update/Review anfordern.
2. **Native Machbarkeit:** Mac A/Terminal.app/VoiceOver exakt protokollieren. B02 an realem Dialog mit Tab/Shift-Tab und direktem Vergleich der aktuellen Aktion prüfen; Kontrolllauf VoiceOver aus. Spätere minimale lokale Korrekturen separat rot/grün belegen. Wenn der vorhandene Stack die Ansage nicht nachweislich ermöglicht: Fail/Open, Ownerentscheidung statt Bridge-/Frameworkwechsel oder Lesefolge als Ersatz.
3. **Direkte Eingabe und Dialoge:** B01 ohne eingeschobenes End reproduzieren, neue Regression vor Korrektur; bestehende Alias-/Einfügen-/Überschreibverträge bleiben erhalten. Weil B01 mit VoiceOver aus berichtet wurde, hängt dieser Tastatur-/Funktionsteil nur von Schritt 1 ab und wird durch ein offenes oder fehlgeschlagenes natives Gate aus Schritt 2 nicht blockiert; der VO-an-Teil folgt nach Schritt 2. Alle Dialogausgänge, Default-Aktion und Rückkehrfokus nach Schritt 2 prüfen.
4. **Text, Hilfe, Kontrast:** Vollständige Befehle/Shortcuts kontextbezogen erklären, Feedback Erfolg/Abbruch/Fehler, aktive Adresse/Typ/AutoCalc und Auswahl ohne Farbabhängigkeit. Geprüfte Reader-Hinweise getrennt von Grenzen dokumentieren. Alle betroffenen Farben und Fokusindikatoren messen, nicht aus CI-Farbnamen ableiten.
5. **Nachweisintegrität konsolidieren:** Die bereits vor Produktkorrekturen gebundenen additiven IDs und alle alten aktiven Einzelwege vollständig mit tatsächlichen Resultaten abgleichen; keine IDs oder Orakel erst nachträglich an grüne Ergebnisse anpassen. Echte Assertion-/Prozessresultate und menschliche Nachweise getrennt. Fehlende/stale/inkonsistente/geschwächte Nachweise blockieren Abschluss.
6. **Vollregression und Dokumentation:** Gesamter aktiver Vertrag auf Linux/Windows, macOS-PTY, native VoiceOver-Sitzung und betroffene DocFX-Seiten am gemeinsamen Kandidaten. Security-/Architekturreview und Owner-Abnahme separat. Lieferung/Archivierung/Serienfortschreibung erst nach gesonderter Autorisierung; kein Start Rename.

*The authorised sequence is preflight with individual ID/oracle and red-regression binding, early native feasibility, direct input/dialog correction (the reader-off B01 input path depends only on preflight, not on the native gate), text/help/contrast, consolidation of actual proof, then complete regression/documentation. Bind expectations before testing; absent native execution is not an observed red failure. Never fit IDs/oracles retrospectively to green results. Stop for source drift or an unsupported native requirement. Delivery, lifecycle changes and rename require separate authority.*

## Traceability und Teststrategie / Traceability and Test Strategy

Der native Machbarkeitsnachweis vergleicht tatsächlich beobachteten Anwendungsfokus mit Sprachansage, nicht nur eine angenommene Tab-Reihenfolge. Feldfokus, Aktionsfokus, Default-Aktion und Rückkehrfokus getrennt protokollieren. Gleichzeitiger Tastendruck, Ansage und Fokus müssen derselben Interaktion zugeordnet sein. Automatisierte UI-/PTY-Belege und ein geplantes Tastaturskript ersetzen keinen gesprochenen nativen Befund.

*Native feasibility compares observed application focus with actual speech, not merely predicted tab order. Record field/action/default/return focus separately and bind key, speech and focus to the same interaction. Automated UI/PTY proof or a planned key sequence cannot replace native observation.*

Die Kurzformen R-01–10 und AK-01–08 stehen für die unveränderten `R-A11Y-CALC-*`- und `AK-A11Y-CALC-*`-IDs. Jede Zeile bezeichnet geplante Nachweise, keine ausgeführten Ergebnisse. Die acht AK werden zusätzlich einzeln ausgewertet; eine gemeinsame Zuordnung erlaubt keinen Ersatz der nativen Prüfung durch Automation.

*R-01–10 and AK-01–08 abbreviate the unchanged requirement and acceptance IDs. Rows describe planned evidence, not executed results. Assess all eight criteria separately; shared mappings do not allow automation to replace native proof.*

| Anforderung / Requirement | Szenarien / Journeys | Geplanter Prüfpfad und Nachweisart / Planned verification and evidence type | Abnahme / Acceptance |
|---|---|---|---|
| R-01 | US-001/003/004 | Vollständige kontextuelle Tasten-/Aliasreferenz; Quellenabgleich, UI-/PTY-Textnachweise / full contextual key reference, source comparison and UI/PTY text | AK-01/03/08 |
| R-02 | US-001/002/004 | Erfolg/Abbruch/Fehler und Zellkontext; UI-/PTY-Text- und Zustandsnachweise / feedback and context, UI/PTY text and state | AK-01/02/08 |
| R-03 | US-003/004 | Alle Hilfeseiten/-wege; Quellenabgleich, UI/PTY, getrennte native Lese-/Fokusbefunde und betroffene HTML-Seiten / full help, distinct native and affected HTML evidence | AK-03/07/08 |
| R-04 | US-004 | Deklaration/Locks/Freigabe, Drift-/fehlender-Pin-Negative; gebundener Preflight-Bericht / neutral source comparison and rejection tests | AK-04/08 |
| R-05 | US-001/002/004 | Raster/Auswahl/Menü/Dialog/Status/Meldung; Farbpaar-/Kontrastmessung je Zustand und Nicht-Farb-Review / measured contrast and non-colour review | AK-05/08 |
| R-06 | US-001/002/004 | Alle Dialogausgänge, direkte Eingabe, Fokus-/Dateninvarianten; UI/PTY plus getrenntes natives Fokus-/Sprachprotokoll / dialogs and direct input with distinct native speech | AK-01/02/05/08 |
| R-07 | US-001–004 | Vollständige echte PTY-Prozesswege und Terminalrücksetzung; Prozess-/Text-/Zustandsnachweise / full real-process PTY evidence | AK-01/02/06/08 |
| R-08 | US-001–004 | Impact-/Drifttrigger; gebundene native VoiceOver-Sitzung zusätzlich zu Plattformautomation / impact decision and actual native reader session | AK-06/08 |
| R-09 | US-003/004 | Tatsächlich erzeugte DocFX-Seiten; Snapshot/axe/lynx plus getrennte manuelle/offene Kriterien / actual HTML automation and manual gaps | AK-07/08 |
| R-10 | US-004 | Unabhängiger Nenner, additive IDs, Einzelweg-/Plattform-/Impact-Matrix und negative Integritätsbelege / full independently bound coverage and integrity checks | AK-01/08; Bindung aller AK / binds all criteria |

Verbindliche Impact-Matrix unverkleinert: NoFunctionalImpact verlangt Drift-/Dokumentationsprüfungen, FunctionalImpact vollständigen aktiven Linux-/Windows-Vertrag, A11yImpact zusätzlich vollständiges A11Y-Intake/macOS-PTY/VoiceOver, TestInfrastructureImpact volle Matrix plus Anti-Testschwächung, ReleaseCloseout alle Funktions-/A11Y-/DocFX-/Plattformnachweise auf demselben Commit. Permanente PR-/Push-Vollautomation aus Feature 006 bleibt erhalten; Impact liefert zusätzliche Pflichten, keinen Skip-Schalter.

*Retain the complete impact matrix, including anti-weakening and common-commit closeout. Feature 006's permanent PR/push automation remains; impact adds gates rather than permitting skips.*

## Risiken und Komplexität / Risks and Complexity Tracking

| Risiko / Risk | Begrenzung und Wiedervorlage / Mitigation and re-evaluation |
|---|---|
| Native Ansage unbekannt / Native speech unproven | Frühes Machbarkeitsgate, Owner Thorsten, vor breiter Produktkorrektur; keine aktuelle Pass-/Fail-Erfindung / native proof before broad changes |
| Historische Testlücke / Historical test gap | Direkter Tippweg ohne End, getrennte Modus-/Aliastests; Ursache erst nach Reproduktion / no assumed causality |
| Validator nach Archivierung / Archived intake path | Lifecycle-feste Bindung mit positiven/negativen Fixtures, kein Ignorieren des Gates / preserve validation |
| Globale Frameworkzustände / Framework global state | Vorhandene serielle Sessions, eigene Prozesse/Tempdaten, begrenzte Laufzeiten und Rücksetzung / owned bounded resources |
| Abnahme über Teilbelege / Partial proof inflation | Pass/Fail/Open/Incomplete getrennt, native/automatisierte/HTML-Evidenz nie austauschbar / distinct evidence types |

Keine Verfassungsverletzung wird beantragt; keine vierte Schicht, kein neues Projekt, keine Framework- oder Paketwahl. Offene technische Nachweise sind geplante Ausführungsgates, keine unbeantworteten Produktentscheidungen. Wenn ein Gate einen neuen Entwurf erzwingt, an dieser Grenze stoppen.

*No constitutional exception is requested. No extra project, layer, framework or package choice is introduced. Unexecuted proof remains an execution gate rather than an unresolved product decision; stop if it requires a new design.*

## Dokumentationsimpact und Stopp / Documentation Impact and Stop

DocFX wird über das versionierte Manifest und `dotnet tool run docfx -- build docfx.json` verwendet, nicht über eine beliebige globale Version. Der aktuelle Pin ist 2.81.0; ein später abweichendes Manifest benötigt erneute Werkzeugprüfung, kein automatisches Update in diesem Feature. Die unveränderte Konfiguration veröffentlicht `specs/007-tui-accessibility/` derzeit nicht. Diese Dateien daher direkt als Markdown prüfen; HTML-Smoke betrifft den Ledger und andere tatsächlich erzeugte Seiten und wird nicht als HTML-Nachweis der 007-Spec ausgegeben. Anwendbarkeit und tatsächliche Prüfung von 3.1.2 (Sprache von Teilen) separat dokumentieren; `html lang=de` allein beweist keine korrekte englische Sprachauszeichnung.

*Use the versioned manifest and explicit local DocFX invocation, currently pinned to 2.81.0. Recheck later manifest changes rather than updating automatically. Unchanged configuration does not publish Feature 007 sources: review them as Markdown and limit HTML claims to actually generated pages. Separately assess language-of-parts applicability and evidence; German page language alone does not prove English part markup.*

**Documentation Impact: `UpdateRequired`.** Quelle Spec/Intake, Owner Thorsten, Deutsch kanonisch mit direkt folgendem Englisch, Zielgruppe ab erstem Lehrjahr/CEFR B2. Leserpfad Serie → Intake → Spec → Plan → Contracts → Einzelweg-/Plattformnachweis; Issue #107 ergänzt den Befundkontext. Jetzt neue Planungsdateien und Ledger, keine Navigation/README/API-Ausgabe ändern; `sourceOnly`, kein Home-sync. Später Laufzeithilfe und `docs/accessibility/007-tui-accessibility.md`, Architektur-/Security-Nachweise und ggf. DocFX. Geänderte öffentliche XML-APIs lösen API-Regeneration aus. Jeder erfolgreiche DocFX-Lauf erhält Snapshot/axe/lynx im selben Arbeitspaket; unvollständige Regeln sind kein Pass.

*UpdateRequired: the intake/spec own scope; Thorsten owns review. Use bilingual B2 text and the reader path above. Planning files and the ledger change now, not navigation, README or APIs; source-only distribution with no Home sync. Future authorised implementation updates help and scoped accessibility/architecture/security evidence. API/XML changes trigger API regeneration; every DocFX build needs text-accessibility review with incomplete checks retained.*

Regulatorische Wiedervorlage folgt der bestehenden Security-Evidenz, ohne zusätzliche externe Rollen-/Scope-Planfreigabe. Keine privaten Tabellen, gesprochenen privaten Inhalte, Secrets oder Agentenlogs speichern; synthetische Daten, minimale Transkripte und zweckgebundene Aufbewahrung. Keine Telemetrie hinzufügen.

*Follow existing regulatory review triggers without reintroducing the removed external role/scope approval gate. Use synthetic data, minimal transcripts and purpose-bound retention; store no secrets, private sheets or agent logs and add no telemetry.*

Dieser Lauf endet nach Dokumentenvalidierung. Keine Implementierung, Build/Test/Restore des Produkts, `tasks.md`, Folgefeature, Commit/Push/PR/Merge oder Admin-Bypass. `sheet.mcalc.json` unverändert. Optionale Git-Hooks vor/nach Plan werden übersprungen. Ein vollständiger Feature-Abschlussbericht ist N/A für diesen einzelnen Planungslauf; Trigger vollständiger beauftragter Featureabschluss. Zusätzliche Mermaid-Grafik N/A, weil Struktur und Gatefolge vollständig in Text/Tabellen vorliegen und kein Lastenheft erstellt wird.

*Stop after planning validation. Do not implement, build/test/restore the product, create tasks, deliver or start another feature. Preserve sheet.mcalc.json and skip optional Git hooks. A whole-feature completion report is N/A for one planning command. No additional Mermaid diagram is needed: text and tables fully describe structure and gate order.*
