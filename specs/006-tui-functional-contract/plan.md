# Implementierungsplan: TUI-Funktionsabnahme und Regressionsvertrag / Implementation Plan

**Branch:** `006-tui-functional-contract` | **Datum / Date:** 2026-10-07 | **Spec:** [spec.md](spec.md)
**Input:** Geklärte Spezifikation und [verbindliches Intake](../../requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md).
**Status:** Autorenplanung, RQ-001–RQ-003 und Owner-Planreview abgeschlossen; 36 Anforderungsqualitäts-Punkte Pass. Thorstens Review vom 2026-10-08 bindet `6693ee58aabdc99e1532cea66cb38dc80bb7deda`; PR #101 gemergt als `541d883127174a178bdb1a1070440253fd23f2b8`. Zusätzlicher externer Rollen-/Scope-Review entfällt gemäß Owner-Entscheidung. Keine Implementierungsfreigabe, Produktabnahme oder Preflight-Erfüllung. / Author planning, clarification and owner plan review complete; the added external review prerequisite remains superseded. Execution, product acceptance and preflight are not cleared.
**Planungsbasis / Planning baseline:** `de65e8db85f3bc7fb4361aa0c49a894938ce3e56`; Intake-SHA-256 `c07016800b9e02e56f123ed6af187d0b5fedd22c1689a1b8909fcc6e8f70c6ac`.

## Summary / Zusammenfassung

Die vollständige Vereinigungsmenge aus TUI, README, gebündelter Hilfe und migrierter Hilfe wird als versionierter JSON-Produktvertrag geführt. Alle 17 Familien, FR-001 bis FR-017 und AC/SC-001 bis 006 bleiben erhalten. Jeder Alias, Menü-/Palettenweg sowie Erfolgs-, Abbruch- und Fehlerfall erhält eine eigene Prüfpflicht. Automatisierbare Wege werden automatisiert geprüft; menschliche Wahrnehmungsnachweise sind nur ergänzend.

*Maintain the complete union of the TUI, README and both help sources as a versioned JSON product contract. Preserve all seventeen families, requirements and six acceptance criteria. Every offered path has its own proof obligation; manual perception evidence only supplements automation.*

Die technische Lösung nutzt die bestehenden vier Projekte. Ein interner, instanzgebundener TUI-Sitzungseinstieg macht dieselben Views, Bindings und Dialoge für Tests erreichbar. Terminal.Gui-Eingabeinjektion prüft echte UI-Wege auf Linux und Windows; macOS prüft zusätzlich den echten Prozess im Pseudoterminal (PTY). Core-Tests liefern genaue Fachorakel, ersetzen aber niemals den Editorweg. Ein read-only PowerShell-Vertragsvalidator mit Bash-Einstieg prüft Baseline, Quellen, Testausführung, Pin und Nachweise fail-closed: unbekannte oder fehlende Pflichtbelege sperren Abnahme.

*Use the four existing projects and an internal instance-owned TUI session. Framework input injection exercises actual views and dialogs on Linux and Windows; a real process PTY adds macOS proof. Core tests provide precise domain oracles but cannot replace editor tests. One read-only PowerShell validator with a Bash entry point blocks missing or unknown evidence.*

Reihenfolge bleibt Migration → Funktionsabnahme → A11Y → Rename. Dieses Feature führt weder PL/0 noch Rename aus und startet das A11Y-Folgefeature nicht. Für eigenen `A11yImpact` sind dessen verlinkte Gates dennoch erforderlich, ohne dessen Serienstatus vorzeitig abzuschließen.

*Retain migration → functional acceptance → accessibility → rename. Do not implement PL/0 or rename, start the next feature, or mark its series status complete. Apply linked accessibility gates to this feature's own accessibility impact.*

## Technical Context / Technischer Kontext

| Feld / Field | Verifizierter Stand und Entscheidung / Verified state and decision |
|---|---|
| Language/Version | C# 14 auf `net10.0`; lokales SDK `10.0.401`. C# ist MSL. Kein `global.json` vorhanden; reproduzierbaren SDK-Stand im späteren Preflight erfassen. / C# 14 on .NET 10; record SDK during execution. |
| Primary Dependencies | Beobachtet: Terminal.Gui `2.4.17`; xUnit `2.9.3`, Runner `3.1.5`, Test SDK `18.3.0`, Coverlet `8.0.0`. Das sind Bestandswerte, keine normative Versionsauswahl und kein Upgradeauftrag. / Observed pins only, not an upgrade instruction. |
| Storage | Bestehendes Tabellen-JSON und Textdruck unverändert; zusätzliche Vertrags-/Nachweis-JSON-Dateien außerhalb des Produktformats. / Preserve spreadsheet JSON/text export; evidence has a separate format. |
| Testing | Bestehende xUnit-Projekte; datengetriebene Core-/TUI-Vertragstests, negative Validatorfixtures, macOS-Prozess-PTY und ergänzende VoiceOver-Sitzung. / Existing xUnit projects plus contract, drift and real-terminal checks. |
| Target Platform | Native Linux-/Windows-CI; lokales macOS `osx-arm64` mit Terminal und VoiceOver. / Native Linux/Windows CI and separate local macOS proof. |
| Project Type | Lokale TUI plus Core-Bibliothek; kein Server, HTTP-Dienst oder Auth-System. / Local TUI/library, no service. |
| Performance Goals | Vorhandene Bedienbarkeit bewahren; keine neue erfundene Latenz-SLA. Jede Testinteraktion hat einen begrenzten Timeout, jede Sitzung einen Gesamtdeadline; Timeout ist Fehler, nicht Skip. / Preserve usability; bounded tests fail on timeout. |
| Constraints | Raster `A1:G21`; reale Größe `80x24` und dokumentierter Testfall `120x40`; kein Live-Datensatz, kein automatisches Upgrade, kein öffentlicher Testmodus. / Fixed grid, minimum/larger size, synthetic data and internal seams only. |
| Scale/Scope | 17 Baseline-Familien, 17 FR, sechs AC/SC, vier Stories und fünf Impact-Klassen; Abdeckung aller aktiven IDs/Pfade statt 100% Zeilen-Coverage. / Complete active-path coverage, not a line-coverage claim. |

Die Registry-Zeile `RiderProjects/TinyCalc` in `constitution.md` und `.specify/memory/constitution.md` ist bindend: `MicroCalc.sln`, .NET 10/C#, xUnit, Smoke, DocFX-A11Y und Statistikreferenzen 80/125 Zeilen je Arbeitstag. Neue öffentliche APIs sind nicht geplant. Falls eine Defektkorrektur öffentliche Signaturen/XML-Kommentare verändert, gehören XML-Dokumentation, DocFX und axe/lynx zwingend dazu.

*Apply the binding TinyCalc registry row and its build, documentation, accessibility and statistics rules. No public API change is planned; any later public/XML change requires matching DocFX and accessibility evidence.*

## Constitution Check / Verfassungsprüfung

Vor Phase 0 wurde der saubere Feature-Branch und die reine Planungsautorität bestätigt. `Planned` bedeutet geplanter Nachweis, nicht bestandene Produktprüfung. Die Owner-Scope-Entscheidung vom 2026-10-08 ersetzt das zusätzlich eingeführte externe Human-only-Review-Gate; historische regulatorische Dispositionen bleiben erhalten. Der Plan wird als Dokumenten-PR durch Thorsten reviewt; keine automatische Produktfreigabe.

*Planning-only authority remains bounded. The owner's personal-project scope decision supersedes the added external human-only review prerequisite while preserving historical applicability records. Thorsten reviews this documentation PR; planned proof is not product approval.*

Installierte Basismatrix: Security 0.7.0, Architecture 0.6.1, iSAQB 0.2.2, A11Y 0.4.3, Cross-Platform 0.2.2, Agent-Parity 0.4.2, Autonomous 0.4.4 und Parallel-Autonomous 0.2.6. Ergänzend gelten Intake-Authoring 0.3.7, Intake-Review 0.2.4, Intake-Sequencing 0.2.7, Secure-Development-Assurance 0.1.3, Model-Routing 0.1.4 und Project-Statistics 0.1.0. Keine Presetänderung. Autoren-/Review-/Sequenzregeln binden Quellen; Assurance prüft technische Security, Routing bleibt operativ, Statistik bleibt reproduzierbare Transparenz. Autonomous/Parallel sind für diesen Einzelaufruf N/A, mit Trigger separat beauftragter Lauf.

*The installed eight-preset baseline and six additional governance presets remain unchanged. Source, assurance, routing and statistics rules apply in their stated roles; autonomous and campaign execution remain N/A unless separately requested.*

| Gate | Vor Forschung / Before research | Nach Design / After design; Evidenz und Folgeaktion / Evidence and follow-up |
|---|---|---|
| Branch / PR / Authority | Pass für Planung / planning | Pass für lokalen Entwurf; Commit, Push, PR und Merge benötigen neuen Auftrag. Alte MergeAndSync-Freigaben werden nicht auf diesen Lauf übertragen. / Fresh delivery authority required. |
| Intake / Serienreihenfolge | Aktuelle Quellen prüfen / verify | Review/Manifest vor Ausführung erneut validieren; Migration muss Completed bleiben, Funktionsabnahme vor A11Y/Rename. / Revalidate before execution. |
| Angebotskonflikte / Offer conflicts | Im Review entdeckt / found | RQ-001–RQ-003 durch Nutzerentscheidungen geklärt; 36 Anforderungsqualitäts-Punkte Pass. Angebote und mathematische Orakel vollständig erhalten; Quellenangleichung/Produktnachweise separat. / Identified findings resolved, not product-tested. |
| .NET / C# / MSL | Pass | Bestehende Ziel-Frameworks beibehalten; kein neuer Produkt-Runtime. / Keep runtime. |
| Schichten / Layers | Pass | Core kennt weder TUI noch Vertragsevidenz; TUI verwendet Core; Tests/Validator bleiben außerhalb der Produktdaten. / Preserve layering. |
| Pin / Supply chain | Bestands-Pin vorhanden / observed | `Open` für Ausführung: keine Produkt-Lockdateien vorhanden. Owner Feature-Entwicklung; vor Produktcode freigegebene Auflösung und Lockquellen herstellen, Locked Restore belegen. / Resolve before code. |
| TDD / Coverage | N/A für Planung / planning | Umsetzung Planned: Rot–Grün–Refactor, geänderter Produktcode ≥70%, Ziel ≥80%; kein Skip als Pass. / Required for product edits. |
| Datenformate / Serialization | Pass für Design | Vorhandenes Tabellenformat bewahren; untrusted JSON/Formeln prüfen, malformed Load darf Daten nicht teilweise verändern. / Preserve format and validate boundaries. |
| Sprache / A11Y / Docs | Pass für Planungsartefakte | DE zuerst, EN danach, B2, Textalternativen; Umsetzungsevidenz in `docs/accessibility/006-tui-functional-contract.md`. / Bilingual accessible evidence required. |
| Security | Applicable, Planned | SSDF/CWE, STRIDE/CIA/CAPEC, C#-Regeln, Security-/Supply-Chain-Reviews; Pfade unten. / Explicit secure-development proof. |
| Rollen-/Scope-Entscheidung / Role and scope decision | Owner bestätigt / confirmed | Privates persönliches Projekt; kein zusätzliches externes qualifiziertes Review als Plan-Gate. Owner-PR-Review ausstehend; bei konkreter Nutzungs-/Daten-/Provideränderung Anwendbarkeit vor betroffenem Schritt erneut prüfen. Historische Einzelstatus nicht pauschal auf N/A setzen. / Owner scope recorded, review pending; reassess on concrete triggers. |
| Agentenregeln / Agent guidance | N/A für Änderung / change | Keine gemeinsamen Regeländerungen. Bei Trigger alle fünf Agentenflächen, Templates und Verfassungen atomar prüfen. / Reassess shared-rule changes. |
| Statistik / Statistics | Applicable | Ledger am Ende dieser Planung fortschreiben; generierten Git-Block erst an separat genehmigter sauberer Commit-Grenze rendern. / Ledger now, generated refresh at authorised clean boundary. |

### Security- und Assurance-Matrix / Security and assurance matrix

Feature-Entwicklung besitzt technische Evidenz; vor Abnahme prüft ein unabhängiger Reviewer. Thorsten besitzt menschliche und regulatorische Entscheidungen. `N/A` gilt nur im benannten Scope und mit Trigger.

*Feature development owns technical proof, an independent reviewer checks acceptance, and Thorsten owns human/regulatory decisions. N/A is limited to the stated scope and trigger.*

| Kontrollpunkt / Checkpoint | Anwendbarkeit, Aktion und Evidenz / Applicability, action and evidence |
|---|---|
| NIST SSDF / CWE Top 25 / C# Secure Coding | Applicable: Eingaben, Datei-I/O, Fehler, Prozesssteuerung und Evidenzgrenzen prüfen; `docs/security/security-checklist.md` und `docs/security/secure-development/006-tui-functional-contract/`. CWE-20/22/400 als relevante Eingabe-, Pfad- und Ressourcenrisiken prüfen, nicht als nachgewiesene Befunde ausgeben. / Assess relevant risks, not presumed vulnerabilities. |
| STRIDE / CIA / CAPEC / arc42 / S-ADR | Applicable: Tastatur/Formel → Engine, JSON/Hilfe → Produkt, Paketquelle → Build, Testbericht → Abnahme als Grenzen dokumentieren. `docs/security/threat-model.md`, `arc42-security.md`, `security-quality-scenarios.md`, `adr/004-tui-contract-evidence.md`. CAPEC für bestätigte Hochrisikoflows auswählen. / Document boundaries and selected attack patterns. |
| SBOM / SLSA / Dependency audit | Applicable: freigegebene direkte/transitive Pins, Lizenzen, CVE-Prüfung und tatsächliche Buildherkunft in `docs/security/dependency-audit.md` und `supply-chain-evidence.md`; alte SBOM nicht als aktuelle ausgeben. / Bind exact components and actual provenance. |
| VEX | Conditional: bekannte Schwachstelle → begründete Disposition; sonst datierten Kein-Befund-Stand dokumentieren. / Record vulnerability disposition or dated no-finding state. |
| ASVS | N/A: keine Web/API/HTTP-/Auth-Dienste; kein ASVS-Level erfunden. Trigger neuer Dienst, Pfad `docs/security/asvs-verification.md`. / Reassess service introduction. |
| Produkt-AI-SBOM / Product AI-SBOM | N/A: KI nur Entwicklungswerkzeug, nicht Produkt-Runtime; Tool-Datenschutz separat. Trigger Modell/Dataset/Inferenz im Produkt; `supply-chain-evidence.md`. / Reassess runtime AI. |
| Zero Trust | N/A lokales Produkt; Trigger remote/servicebasierte Laufzeit, `zero-trust-applicability.md`. / Local-only product boundary. |
| C3A / C5 | N/A Produkt ohne Cloud-Runtime; CI-/KI-Toolanbieter separat `Open` bis Scope-Prüfung durch Thorsten. `cloud-autonomy-applicability.md`/`cloud-compliance-assurance.md`; Providerwechsel triggert Review. Bei Anwendbarkeit 30 C3A-Gruppen und exakte C/AC-IDs erhalten; C5 Typ 1/2, Zeitraum und Kundenpflichten unterscheiden. Keine Zertifizierung behaupten. / Separate tooling assurance from product scope. |
| SAMM / OpenSSF / OWASP-Referenzen | Applicable als unterstützender langlebiger OSS-/Review-Kontext: `samm-assessment.md`, Dependency Audit und Checkliste. Kein neuer externer Dienst ohne Autorität. / Supporting review context, no unauthorised provider action. |
| Dependency-Tracking | `Open`: keine Renovate-/Dependabot-Konfiguration im geprüften Bestand gefunden; Feature-Entwicklung prüft vorhandene Providerkonfiguration und plant kleinste genehmigte Automatisierung. Dependency Track nur bei vorhandenem genehmigtem Endpoint; kein Serveraufbau aus diesem Feature ableiten. Vor Lieferfreigabe in Dependency Audit dispositionieren. / Verify automation and record bounded follow-up. |

Bestehende regulatorische Vorprüfung vom 2026-09-08 in `docs/security/regulatory-applicability.md` bleibt historisch erhalten: CRA aktuell N/A mit Wiedervorlage 2026-12-31; Produkt-KI-VO N/A mit Human-only-Bestätigung offen; Produkt-DS-GVO N/A und Delivery Applicable; NIS2/DORA Open. Produkt, KI-/CI-Werkzeuge und nutzende Organisation werden getrennt nach rechtlicher Rolle, Deutschland/EU beziehungsweise tatsächlich bestätigter Jurisdiktion, datierter Primärquelle und Anwendungszeitpunkt bewertet. Ausbildungszweck ist keine pauschale Ausnahme.

*Preserve the dated existing regulatory screening, not a fresh legal ruling. Separately assess product, development tooling and operating organisation with confirmed roles, jurisdiction and dated primary sources. Training is not a blanket exemption.*

Thorsten dokumentiert am 2026-10-08 die private persönliche Nutzung und lehnt die zusätzliche externe qualifizierte Review-Pflicht für diesen Plan ab. Dies supersediert das frühere Human-only-Plan-Gate; kein gesetzlicher Befreiungstatbestand wird behauptet. Öffentliche Repository-Sichtbarkeit bleibt unverändert. Daten bleiben synthetisch; keine persönlichen Tabellen, Secrets oder privaten Logs. Bei tatsächlich geändertem Produkt-/Tool-/Organisationsscope vor betroffenem Schritt erneut prüfen. Owner-Review erfolgt im PR; technische Evidenzgates bleiben bestehen.

*The owner's 2026-10-08 personal-project decision supersedes the added external review requirement, not statutory applicability or technical evidence gates. Public repository visibility stays unchanged. Use synthetic data and reassess concrete scope changes before affected steps. Owner review takes place in the PR.*

## Project Structure / Projektstruktur

```text
specs/006-tui-functional-contract/
  spec.md                       existing requirement source
  plan.md                       technical design
  research.md                   decisions and alternatives
  data-model.md                 logical contract/evidence model
  quickstart.md                 future validation sequence
  contracts/README.md           validator and runner interfaces
  checklists/plan.md             planning review
  evidence/                     future run evidence; not created by Plan
  tasks.md                      future speckit-tasks output; not created by Plan

src/MicroCalc.Core/              Engine, Formula, Model, IO remain here
src/MicroCalc.Tui/               Program + internal TuiSession; Help, Smoke
tests/MicroCalc.Core.Tests/      domain contract/negative fixtures
tests/MicroCalc.Tui.Tests/       UI contract fixtures, execution records
docs/contracts/tui/             future product-contract.json, source-map.json
scripts/                        future test-tinycalc-contract.ps1/.sh
scripts/tests/tui-contract/     future validator fixtures + PTY adapter
docs/man/                       future test-tinycalc-contract.1.md
docs/architecture/              future tui-functional-contract.md + ADR
docs/security/                  existing evidence plus feature review
docs/accessibility/             feature PTY/VoiceOver/parity evidence
```

Bestehende Projekte erweitern, keine vierte/fünfte Produktionsschicht und keine neue öffentliche API. Neue Testadapter gehören ausschließlich zur Infrastruktur. Die Tabelle unter `contracts/README.md` bindet jede Familie an Testarten; einzelne IDs werden vor Produktcode additiv inventarisiert.

*Extend existing projects without a new production layer or public API. Keep adapters in infrastructure; inventory concrete additive IDs before product edits.*

## Umsetzung in Phasen / Implementation phases

**Fortschreibung nach PR #101 / Update after PR #101:** Der unten aus dem ursprünglichen Plan erhaltene Auftrag „Owner-PR-Review einholen“ ist durch Review/Merge erledigt; spätere Ausführung bestätigt nur dessen Frische und die neue Implementierungsautorität. Historische Open-/Pending-Aussagen beschreiben frühere Checkpoints, nicht den aktuellen Planstatus.

*The original request to obtain owner PR review is fulfilled. Later execution verifies freshness and fresh implementation authority; historical pending statements are not current status.*

1. **Freigabe/Preflight:** Owner-PR-Review einholen; dokumentierten privaten Scope und konkrete Änderungstrigger prüfen; geklärte RQ-001–RQ-003-Kontexte und mathematische Orakel vollständig in Quellen/Katalog angleichen; Intake-/Review-/Vorgängerfrische prüfen. Aktuellen freigegebenen Pin auflösen, Deklarationen und direkte/transitive Lockdaten vergleichen. Fehlende Locks nicht stillschweigend heilen: genehmigte Infrastrukturvorbereitung erzeugt überprüfte Lockdaten ohne automatisches Upgrade; anschließend Locked Restore und neue Entscheidung. Gleichbleibender Pin darf nur zu wirklich passender Evidenz passen, keine alte Gesamtfreigabe erben.
2. **Vertrag zuerst:** Alle 17 Familien, jeden Alias und jede Angebotsquelle inventarisieren; eindeutige Textfehler gesondert erfassen. JSON-Modell, additive IDs, Quellen-/Testzuordnung und negative Validatorfixtures erstellen. Vollständige Kompilierfläche und Testinfrastruktur vor dem ersten roten Produkt-Test prüfen.
3. **Vertikaler Slice:** APP/GRID → EDIT → Formel → sichtbares Ergebnis → Dialogabbruch. Roter Test muss durch den echten Editorpfad scheitern; minimalen internen Sitzungseinstieg herstellen, Grün und Refactor belegen. Keine alternative Test-Fachlogik oder unechte Menüs.
4. **Vollbaseline:** Navigation/ASCII, Zellen, Operatoren/Referenzen, alle 16 Funktionen, neun Befehle über Menü und Palette, Dateien/Druck/Format/Clear/Hilfe, Größen/Fokus/Terminalzustand abdecken. Defekte test-first korrigieren; substantielles Angebot niemals als Tippfehler entfernen. Alle Erfolgs-/Abbruch-/Fehlerpfade ausführen.
5. **Dauerregression:** Read-only Validator mit negativen Drift-/Testschwächungsfällen fertigstellen; CI Linux/Windows um Vollvertrag ergänzen. Workflow-Pushfilter für `006-*` und künftige nummerierte Features korrigieren; jeder PR/Push muss Vertragsprüfung starten. Impact-Matrix bestimmt Zusatznachweise, nicht die Abschaltung der Vollfunktionsregression.
6. **Abnahme/Evidenz:** macOS-PTY `80x24`/`120x40`, für eigenen A11yImpact VoiceOver und sämtliche verlinkten A11Y-Gates; Security-/Architektur-/Dokumentationsabgleich, Coverage und erforderliche DocFX/axe/lynx. Alle sechs AC/SC und null offene In-Scope-Fehler separat prüfen. Statistik seriell und Liefermenge exakt prüfen; ohne neue Remote-Autorität lokal stoppen.

*Phases: clear human/preflight gates; inventory the full contract before code; prove one real editor vertical slice test-first; cover the entire baseline; enforce permanent drift-aware Linux/Windows CI; collect same-revision terminal, accessibility, security and documentation acceptance. No phase implicitly grants remote delivery.*

### Prüfschärfe und Regressionsmatrix / Test strength and regression matrix

**Test-first-Fundament / Test-first foundation:** T014A schreibt kompilierbare rote Producer-Tests für fehlende Assertions/Resultate und unterbrochene atomare Ausgabe vor T015. T016 verwendet vor der Session-Extraktion ausschließlich einen testseitigen `LegacyProgramUiAdapter`: bestehende `Program.BuildWindow`/`RefreshUi` über eng begrenzte Reflection, echte Root-/Dialog-Views und Framework-Eingabeinjektion. Keine direkten Aufrufe von `HandleKey`, `OpenEditor`, `EditCell` oder Engine-Fachaktionen zur Ausführung des geprüften Wegs. Zustände dürfen read-only beobachtet werden; Initialisierung/Reset sind isolierte Testvorbereitung. Statische Zustände je Test definiert zurücksetzen, Sitzungen seriell ausführen, eigene Ressourcen sicher freigeben. T019 nutzt diesen kompilierten Einstieg und bestätigte Formelabweichungen als fachliches Rot; T020 extrahiert danach die interne Session und entfernt temporäre Reflection. Extraktion allein korrigiert keine Formel; deren Rot bleibt bis T026–T030, vollständiges Slice-Grün vor T032. Fehlende Member, Loop-/Treiber-/Compilerfehler sind Infrastrukturblocker, kein fachliches Rot. Fehlt die Fähigkeit am aufgelösten Pin, stoppen und Alternative reviewen, nicht auf Smoke/Engine-only ausweichen.

Negatives Producer-Rot verlangt unabhängig erzeugte fehlerhafte Kandidaten und explizit fehlschlagende Ablehnungs-/Fehlercode-Assertions an einer zunächst permissiven, isolierten Testnaht, einschließlich sichtbar gewordener Teil-Ausgabe. Ein inerter Producer ohne Bundle genügt nur für das positive Ausgabe-Rot; kein Bundle, NotImplemented oder Ausnahme beweisen keine rote Ablehnung. Die permissive Naht darf nie produktive Freigabe oder Merge-Evidenz erzeugen.

*T014A establishes compiling failing producer tests before T015. Independently generated malformed candidates exercise explicit rejection/error-code assertions against an initially permissive isolated test seam, including unsafe partial publication. No bundle or exception cannot prove negative red; an inert producer only establishes positive-output red. The seam never grants production approval or merge evidence. T016 uses a test-only adapter with narrow reflection to existing view construction/refresh and real input. No direct business calls execute tested paths. Read-only observation and isolated setup/reset are allowed. Serialize sessions and clean up owned resources. T019 records actual formula drift; T020 extracts the session and removes temporary reflection. Domain red remains until T026–T030, with full slice green before T032. Missing members, compiler or loop failures block infrastructure, not count as red or permit weaker proof.*

`NoFunctionalImpact`: Vertragsdrift und betroffene Dokumentationschecks; DocFX nur bei Wirkung. `FunctionalImpact`: vollständiger automatisierter aktiver Vertrag Linux/Windows. `A11yImpact`: zusätzlich alle verlinkten A11Y-Gates, macOS-PTY/VoiceOver. `TestInfrastructureImpact`: Vollmatrix plus nachgewiesene Erkennung geschwächter/ausgelassener Tests. `ReleaseCloseout`: vollständige Funktion/A11Y, DocFX/axe/lynx, macOS und Linux/Windows am selben Commit. Unklarer Impact, Dependency-Drift und größere Änderungen verlangen mindestens Funktion+A11Y. Reine Textkorrektur ohne TUI/DocFX-Wirkung erfordert keinen neuen VoiceOver-Lauf.

*Preserve all five impact classes from the specification. Uncertainty and major/dependency changes require full functional and accessibility proof. Text-only changes do not automatically require another manual screen-reader session.*

Permanent bei jedem PR/Push: vollständiger automatisierter aktiver Vertrag auf Linux und Windows, einschließlich NoFunctionalImpact. Die genannten Matrixzeilen legen zusätzliche Nachweise fest. IAD002 bleibt verbindlich; ein Pathfilter darf die Vollregression nicht unterdrücken.

*Full automated Linux/Windows contract regression runs on every PR and push, including NoFunctionalImpact. Matrix rows add proof; filters cannot suppress the intake's permanent obligation.*

Designgrenzen für die Infrastruktur: 30 Sekunden pro Interaktionsschritt, 180 Sekunden pro isolierter Sitzung, 5 Sekunden Cleanup-Nachlauf. Das sind initiale Sicherheitsgrenzen, keine gemessenen Leistungswerte oder Produkt-SLA. Feature-Entwicklung reviewt sie vor dem jeweiligen Task; jede begründete Anpassung benötigt eine neue Decision-Bindung. Eine Zeitüberschreitung liefert Fail, beendet ausschließlich eigene Prozesse und sperrt das Bundle.

*Initial infrastructure budgets are 30 seconds per step, 180 per session and five for cleanup. Review changes before tasks and bind a new decision; timeout fails instead of silently extending or skipping.*

Mindestprüfungen gegen falsches Grün: Pflicht-ID/Alias löschen oder doppeln, Test ausfiltern/skippen, Assertions abschwächen, fremden/veralteten Commit oder Pin melden, nur Smoke anbieten, README-Angebot entfernen, COUNT-Backticks/Rasterbeispiel isoliert korrigieren und neue substanzielle Angebote ergänzen. Prüfer muss jeden Fall korrekt unterscheiden; Schema-Validität allein genügt nicht.

*Negative cases cover missing/duplicate obligations, skips, weaker assertions, stale revisions/pins, smoke-only proof and documentation versus substantive changes. Schema validity alone is insufficient.*

### Dokumentation, Plattformparität und Liefergrenze / Documentation, parity and delivery boundary

**Documentation Impact: `UpdateRequired`.** Owner Feature-Entwicklung; Intake ist Umfangsquelle, Vertrag seine maschinenlesbare Operationalisierung. README → Bedienhilfe → Vertrag → Evidenz ist der Leserpfad; Feature-Links führen zu Architektur/Security/A11Y. Produkt-, Lern-, Betriebs- und Prüfdokumente DE-first/EN-second B2, ohne Spec-Kit-Vorwissen. Beispiele im Raster, Navigation und Textbrowserdarstellung prüfen. Distribution nur Repository/Produkt, kein Home-Sync. Trigger: Funktion, Hilfe, Pin, Test/Evidenz oder API/XML verändert.

*Update product and review guidance with the intake as scope authority and clear reader paths to proof. Use accessible bilingual B2 content and in-grid examples. No Home-runtime distribution.*

Bash und PowerShell teilen denselben read-only Validator. `Test-TinyCalcContract` verwendet den freigegebenen Verb `Test`; Manpage, DE/EN-Kommentarhilfe, `--dry-run`/`-WhatIf`, Bash 3-Kompatibilität, `set -euo pipefail`, Quoting, `Set-StrictMode -Version Latest`, `-NoProfile` und explizite Repository-Wurzel gehören zu einem Arbeitspaket. Beide Vorschauvarianten lesen und prüfen vollständig, schreiben aber nichts und starten keinen Produkt-/Providerlauf. Native Variantenprüfung: Bash auf macOS/Linux, PowerShell auf Windows; Paritätsevidenz in `docs/accessibility/006-tui-contract-parity.md`.

*Deliver paired launchers, approved cmdlet, man-page, bilingual help, safe execution rules and native parity proof. Dry-run/WhatIf validates without writes or execution.*

Gemeinsame Agentenregeln sind unverändert (`N/A` Änderungsbedarf); ein späterer Regeltrigger verlangt gleichzeitigen Abgleich von `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, beiden Copilot-Flächen, Templates und Verfassungen. Kein Modellname wird in Feature-Artefakte gepinnt.

*No shared guidance change is planned. If needed, update all maintained surfaces atomically and keep feature artifacts model-neutral.*

Dieser einzelne Plan-Aufruf führt keine Autonomie/Kampagne, kein Gate-Token und keinen Run-State aus (`N/A`). Ein separat beauftragter autonomer Lauf muss vor Produktcode reviewed Gate-Anforderungen und `evidence/` anlegen, den installierten Exact-Head-Validator benennen, Phasenergebnisse/Run-State validieren, gemeinsamen Schreibzugriff serialisieren und bei Pause/Drift nur mit ausdrücklichem Resume weiterlaufen. Default bleibt `LocalImplementation`; Remote-Aufgaben brauchen aktuelle Autorität. Vollständiger Abschlussbericht erst nach abgeschlossenem Feature, nicht nach Plan.

Dann vorgesehene Pfade: `contracts/autonomous-run-gate-requirements.json`, `evidence/autonomous-run-gate-evidence-premerge.json` und gesonderter PostMerge-Nachweis nur bei aktueller Mergeautorität; Validator `.specify/presets/autonomous-run-governance/scripts/validate-autonomous-gate-evidence.ps1` beziehungsweise `.sh`. Git-Liefermenge mit `validate-autonomous-delivery-set.ps1/.sh` prüfen. Drift klassifizieren, laufende Operation vor Wiederaufnahme neu binden und am nächsten sicheren Gate stoppen; dieser Plan legt keine fingierten ausgeführten Gate-Resultate an.

*Autonomous execution and run-state are N/A for this planning call. A separately authorised run must establish its reviewed gate contract, exact-head evidence and resume boundaries before code. LocalImplementation remains the default.*

*The named future requirement and PreMerge evidence files use the installed gate-evidence and delivery-set validators. PostMerge proof needs fresh merge authority. Rebind in-flight work on resume; never fabricate execution records during planning.*

## Complexity Tracking / Komplexität

Keine Verfassungsausnahme beantragt. Offene Pflichtgates sind Blocker, keine akzeptierten Ausnahmen. Die interne Sitzungsgrenze und der separate Validator sind in [research.md](research.md) begründet; keine neue Produktabhängigkeit geplant.

*No constitutional exception is requested. Open gates are blockers, not waivers. Research records design trade-offs without adding a product dependency.*

## Nächste Grenze / Next boundary

Planungsartefakte prüfen und anhalten. `$speckit-tasks` kann daraus einen getrennten Aufgabenentwurf mit zuerst blockierenden Freigabe-/Preflight-Aufgaben erstellen; es schließt das menschliche Gate nicht. Keine Tasks, Implementierung, Builds, Tests, Commits, Pushes oder PRs aus diesem Plan-Aufruf.

RQ-001/RQ-002 sind als Kontextregeln geklärt, nicht als bestandene Produktnachweise. RQ-003 ist für FACT geklärt, bleibt für übrige Formelsemantik Klärungsblocker. Vor einer späteren Evaluatoränderung zuerst rote Vertragstests für ganzzahlige Argumente 0 bis 33, `FACT(0)=1` und Fehler bei Bruchteilen, negativen Argumenten und Werten über 33 ergänzen. Insbesondere `FACT(-0.5)` und `FACT(33.9)` müssen vor jeder Abschneidung scheitern. Kein solcher Test oder Produktfix wird hier ausgeführt. Früheres „Entwurf abgeschlossen“ bezeichnet keine vollständige Klarheit oder Freigabe; der aktuelle Quellenbefund hat Vorrang.

*FACT now requires integer arguments from 0 to 33, with FACT(0)=1 and clear errors otherwise. Write failing contract tests before any later evaluator change; no tests or product fix run here. Remaining formula semantics blocks approval; earlier design completion is not clearance.*

*Stop after planning validation. A separately requested task breakdown must preserve the human/preflight blockers and grants no implementation or delivery authority.*

Vierte Antwort A klärt die Operatorbindung in RQ-003: Potenz rechtsassoziativ und stärker als unäre Vorzeichen, Klammern zuerst; `*`/`/` und binäres `+`/`-` jeweils linksassoziativ. Die sieben Orakelfälle der Spec zuerst als rote Regressionstests anlegen, danach nur bei separater Implementierungsfreigabe den Parser korrigieren. Verbleibende numerische Definitions-/Ergebnisgrenzen und menschliches Gate bleiben Open.

*The fourth answer A clarifies power/sign binding. Add the specification's seven failing regression cases before a separately authorised parser fix; numeric domain/result boundaries and human clearance remain Open.*

Fünfte Antwort A: Nur endliche reelle Ergebnisse; Definitionsfehler, Überläufe und NaN/Unendlich ergeben verständliche Fehler statt erfolgreicher numerischer Zellwerte. Die vier Fehlerorakel der Spec und endliche Kontrollfälle bei späterer Umsetzung test-first binden; keine Produktprüfung hier. Alle fünf Fragen dieser Nachprüfung sind beantwortet. RQ-003 bleibt für fehlende Quellenbindung von SIN/COS/ARCTAN-Winkeleinheit, LN/LOG-Basis und ROUND-Oberpräzision Open; separat klären, nicht aus aktuellem Code ableiten. Menschliche Freigabe und Quellen-/Produktnachweise bleiben ausstehend.

*The fifth answer A requires finite real results and clear numeric failures. Bind the specification's four error cases and finite controls test-first in future authorised work; no product tests run here. Five follow-up questions are answered. Trigonometric units, logarithm bases and ROUND's upper precision remain deferred source bindings under RQ-003; human clearance and source/product proof remain pending.*

2026-10-08, erste Antwort A dieses Klärungslaufs: SIN/COS-Eingabe und ARCTAN-Ausgabe in Bogenmaß; Orakel und Quellenbindung stehen im trigonometrischen Vertrag der Spec. Kein neues π-Syntaxangebot, kein Produktnachweis. RQ-003 bleibt für LN/LOG-Basis und ROUND-Oberpräzision Open.

*The first answer A in this clarification run binds SIN/COS inputs and ARCTAN output to radians, with specification oracles and no new π syntax or product proof. Logarithm bases and ROUND's upper precision keep RQ-003 Open.*

2026-10-08, zweite Antwort A: LN zur Basis e, LOG zur Basis 10; Null und negative Argumente für beide Funktionen als verständliche Fehler. Pflichtorakel und reviewte Toleranzen gemäß Logarithmusvertrag der Spec. Der offene LN/LOG-Teilbefund ist supersediert; RQ-003 bleibt nur für die obere ROUND-Präzision Open. Kein Produktnachweis oder menschliche Planfreigabe.

*The second answer A binds LN to base e and LOG to base 10, with clear zero/negative errors and specification oracles. This supersedes the logarithm source gap; only the upper ROUND precision keeps RQ-003 Open. Product proof and human plan clearance are pending.*

2026-10-08, dritte Antwort A: ROUND-Präzision nichtnegativ gegen null abschneiden, dann 0 bis 15 einschließlich; größere Werte Fehler ohne Begrenzung. Negative Rohargumente einschließlich -0.5 Fehler vor Abschneidung; Halbwerte weiterhin weg von null. Orakel gemäß Spec. RQ-001–RQ-003-Anforderungslücken Resolved; frühere Open-Fortschreibungen sind supersedierte Historie. Keine Produktabnahme oder menschliche Planfreigabe. Für das Human-only-Gate fehlt der gebundene Nachweis mit Reviewdatum, qualifiziertem Reviewer, bestätigtem Produkt-/Tool-/Organisationsscope, Rollen/Jurisdiktion und begründeten Dispositionen/Triggern der benannten regulatorischen Punkte. Thorstens Bestätigung muss diesen Nachweis referenzieren; pauschale Freigabe ersetzt ihn nicht. NIST SSDF/CWE bleiben Applicable; Security-/Supply-Chain-Evidenz vor Ausführung/Abnahme erheben; ASVS/Produkt-AI-SBOM/Zero Trust bleiben begründet N/A.

*The third answer A binds ROUND to truncated nonnegative precision 0–15 with clear larger/negative-raw errors and unchanged midpoint rounding. Specification oracles resolve the identified source findings; earlier Open entries are history. All 36 requirement-quality items pass, not product acceptance. Qualified dated role/scope evidence and owner confirmation are still required for human clearance; no implementation or delivery authority is granted.*

**Aktueller Governance-Stand 2026-10-08:** Owner bestätigt privates persönliches Projekt und supersediert die zusätzliche externe qualifizierte Rollen-/Scope-Review-Pflicht. Frühere Aussagen zu diesem fehlenden Plan-Gate sind historisch überholt. Repository bleibt öffentlich; historische regulatorische Einzelstatus und Neubewertung bei konkreten Scope-Triggern bleiben erhalten. 36 Anforderungsqualitäts-Punkte Pass, kein Produktnachweis. Plan als Dokumenten-PR zur Owner-Prüfung liefern; keine Implementierung, kein Merge. Technische Security-/Preflight-/A11Y-/Plattform-Gates unverändert.

*Current governance state on 2026-10-08: the owner's personal-project decision supersedes the added external qualified review prerequisite and earlier claims that this blocks the plan. Repository visibility remains public; historical applicability dispositions and concrete-trigger reassessment remain intact. All 36 requirement-quality items pass, not product proof. Submit the documentation PR for owner review, without implementation or merge; technical gates are unchanged.*
