# Feature-Spezifikation: Constitution-Abgleich für didaktische und sprachliche Klarheit / Feature Specification: Constitution Alignment for Pedagogical and Linguistic Clarity

**Feature-Branch / Feature Branch**: `002-constitution-change`
**Erstellt / Created**: 2026-08-29
**Status / Status**: Bereit für die Klärungsphase / Ready for clarification
**Verbindliche Eingabe / Binding Input**: `requirements/intakes/active/Lastenheft_Constitution_Change.002-constitution-change.md`
**Feature-Verzeichnis / Feature Directory**: `specs/002-constitution-change`

## Ziel und Nutzen / Goal and Value

TinyCalc soll eine widerspruchsfreie und prüfbare Governance für verständliche
Lerninhalte, vollständige öffentliche API-Dokumentation und einen sichtbaren
TDD-Lernweg erhalten. TDD bedeutet **Test Driven Development**: Zuerst zeigt
ein Test den fehlenden oder falschen Zustand rot, danach macht die Umsetzung
ihn grün und räumt die Lösung ohne Verhaltensänderung auf. Bereits erfüllte
Regeln werden nicht erneut umgesetzt.

*TinyCalc shall have consistent and verifiable governance for understandable
learning content, complete public API documentation, and a visible TDD learning
path. TDD means **Test Driven Development**: a test first shows the missing or
incorrect state in red, implementation then makes it green, and refactoring
improves the solution without changing behaviour. Rules already fulfilled are
not implemented again.*

## Umfang / Scope

Dieser Lauf gleicht das verbindliche Lastenheft mit dem aktuellen Repository
ab und plant nur als `Applicable` eingestufte Punkte. Zum Feature gehören:

- ein TinyCalc-spezifischer Governance-Abschnitt „Didaktische und sprachliche
  Klarheit / Pedagogical and Linguistic Clarity“, ohne das bestehende
  Security-First-Prinzip I zu ersetzen;
- ein ausdrücklicher didaktischer TDD-Ablauf für neue Funktionen und
  Fehlerkorrekturen;
- die synchrone Pflege der kanonischen Constitution, ihres Spiegels, aller
  gepflegten Agentenflächen und betroffenen Spec-Kit-Templates;
- die Prüfung, dass die bereits aktive Schranke für vollständige öffentliche
  XML-Dokumentation erhalten bleibt;
- eine angemessene, zweisprachige Warum-Kommentierung für später geänderte
  nicht-triviale Logik;
- die Aktualisierung der Projektstatistik und der erforderlichen
  Dokumentations-, Security- und A11Y-Evidenz.

*This run reconciles the binding intake with the current repository and plans
only items classified as `Applicable`. It covers a TinyCalc-specific governance
section without replacing Security-First Principle I, an explicit pedagogical
TDD flow, synchronized constitution mirrors, agent surfaces and affected
Spec-Kit templates, preservation of the existing public XML documentation
gate, suitable bilingual why-comments for later non-trivial logic, and the
required statistics, documentation, security, and accessibility evidence.*

## Nicht-Ziele / Non-Goals

- Keine neue Tabellenkalkulationsfunktion und keine Änderung von Formelparser,
  Rechenwerk, Persistenz, TUI-Verhalten oder Legacy-Kompatibilität.
- Keine erneute Umsetzung der bereits aktiven XML-Dokumentationsschranke in
  `MicroCalc.Core` und `MicroCalc.Tui`.
- Keine XML-Dokumentation für lokale Variablen; C# bietet dafür keine
  XML-Dokumentationsfläche.
- Keine pauschale Übersetzung oder Überarbeitung aller vorhandenen Kommentare
  und Dokumente. Die spätere didaktische Kommentarhärtung behält ihren
  eigenständigen Serienplatz.
- Keine Änderung oder Neuanlage eines Skripts, Cmdlets, Workflows oder einer
  Manpage.
- Keine Änderung von Abhängigkeiten, Netzwerk-, Cloud-, Authentifizierungs-,
  Autorisierungs- oder Laufzeit-Vertrauensgrenzen.
- In dieser Specify-Phase keine Implementierung, kein Commit, Push, Pull
  Request, Merge, Admin-Bypass und kein Start eines weiteren Features.

*There is no new spreadsheet capability and no formula, engine, persistence,
TUI, or legacy-compatibility change. The existing XML documentation gate is not
reimplemented. Local variables receive no XML documentation because C# has no
such documentation surface. Existing comments and documents are not globally
rewritten, and the later didactic-comment hardening keeps its series position.
The feature adds no script, cmdlet, workflow, man page, dependency, or runtime
trust boundary. Specify performs no implementation or remote delivery action.*

## Reihenfolge und Abhängigkeiten / Ordering and Dependencies

1. Die akzeptierten Intake-, Review- und Manifest-Hashes bilden die
   Eingangsschranke.
2. Die bestehende gemeinsame Governance wird von projektlokalen Änderungen
   getrennt; Security-First bleibt Prinzip I.
3. Constitution, Spiegel, Agentenflächen und betroffene Templates werden als
   eine semantische Paritätsmenge behandelt.
4. Die bestehende öffentliche XML-Dokumentationsschranke wird geprüft, nicht
   neu erfunden.
5. Erst nach erfolgreichem Abschluss darf die Seriensteuerung einen nächsten
   Intake freigeben; dieses Feature startet ihn nicht.

*Accepted intake, review, and manifest hashes form the entry gate. Shared and
project-local governance remain distinct, with Security-First still Principle
I. Constitution mirrors, agent surfaces, and affected templates form one
semantic parity set. The existing XML documentation gate is verified rather
than reinvented. A later intake starts only through a separate series decision.*

## Nutzerszenarien und Tests / User Scenarios and Testing

### User Story 1 – Verständliche, einheitliche Lernregeln / Understandable and Consistent Learning Rules (Priorität / Priority: P1)

Als auszubildende, lehrende oder neu mitwirkende Person möchte ich dieselben
klaren Regeln zu Sprache, Dokumentation, Kommentaren und Tests an allen
verbindlichen Einstiegen finden, damit ich TinyCalc ohne Spec-Kit-Vorwissen
nachvollziehen kann.

*As an apprentice, teacher, or new contributor, I want the same clear rules for
language, documentation, comments, and tests at every binding entry point so I
can understand TinyCalc without prior Spec Kit knowledge.*

**Warum diese Priorität / Why this priority**: Widersprüchliche Governance kann
jede spätere Code- und Dokumentationsarbeit in eine falsche Richtung lenken.

**Unabhängiger Test / Independent Test**: Die kanonische Constitution, ihr
Spiegel, alle gepflegten Agentenflächen und betroffenen Templates werden gegen
dieselbe Regelmenge geprüft.

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Gegeben / Given** eine neue mitwirkende Person sucht die Lernregeln,
   **wenn / when** sie einen verbindlichen Einstieg liest, **dann / then**
   findet sie Deutsch zuerst, Englisch danach, CEFR B2, text-first A11Y,
   öffentliche XML-Dokumentation und TDD ohne widersprüchliche Aussage.
2. **Gegeben / Given** Security-First ist Prinzip I, **wenn / when** die
   didaktische Regel ergänzt wird, **dann / then** bleibt Prinzip I unverändert
   und der neue Titel erscheint eindeutig im TinyCalc-Level-2-Addendum.

### User Story 2 – Nachweisbar dokumentierte öffentliche API / Verifiably Documented Public API (Priorität / Priority: P1)

Als lernende oder integrierende Person möchte ich mich darauf verlassen, dass
jede öffentliche Produkt-API verständlich dokumentiert bleibt und fehlende
Dokumentation den Build sichtbar stoppt.

*As a learner or integrator, I want every public product API to remain clearly
documented and missing documentation to stop the build visibly.*

**Warum diese Priorität / Why this priority**: Die Schranke ist bereits aktiv
und schützt Lernende; der Governance-Abgleich darf sie weder abschwächen noch
doppelt oder widersprüchlich definieren.

**Unabhängiger Test / Independent Test**: Beide Produktprojekte behalten ihre
Dokumentationserzeugung und behandeln fehlende öffentliche XML-Dokumentation
als Fehler; ein sauberer Build weist den Zustand nach.

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Gegeben / Given** eine öffentliche API, **wenn / when** ihre
   Dokumentation geprüft wird, **dann / then** sind Zusammenfassung, Parameter,
   Rückgabe und mögliche Ausnahmen dort beschrieben, wo sie fachlich gelten.
2. **Gegeben / Given** eine erforderliche XML-Dokumentation fehlt, **wenn /
   when** die Build-Schranke läuft, **dann / then** schlägt sie sichtbar fehl
   und wird nicht global unterdrückt.
3. **Gegeben / Given** API-Signaturen oder XML-Kommentare ändern sich später,
   **wenn / when** der Arbeitsgegenstand abgeschlossen wird, **dann / then**
   liegen DocFX- und textorientierte A11Y-Evidenz aus demselben Gegenstand vor.

### User Story 3 – TDD als sichtbarer Lernweg / TDD as a Visible Learning Path (Priorität / Priority: P2)

Als auszubildende oder entwickelnde Person möchte ich bei neuen Funktionen und
Fehlerkorrekturen Rot → Grün → Aufräumen nachvollziehen können, damit Tests
nicht nur Endkontrolle, sondern Teil des Lernwegs sind.

*As an apprentice or developer, I want to follow red → green → refactor for
new features and fixes so tests are part of learning rather than only a final
check.*

**Warum diese Priorität / Why this priority**: Tests sind bereits Pflicht; der
Intake ergänzt den ausdrücklich sichtbaren Lern- und Evidenzablauf.

**Unabhängiger Test / Independent Test**: Governance und spätere Aufgaben
nennen für jede betroffene neue Funktion oder Fehlerkorrektur roten Test,
grüne Umsetzung und Regression oder begründen ein `N/A`.

**Akzeptanzszenarien / Acceptance Scenarios**:

1. **Gegeben / Given** eine neue Funktion oder Fehlerkorrektur, **wenn / when**
   Aufgaben geplant werden, **dann / then** ist der TDD-Ablauf mit
   beobachtbarer Rot-, Grün- und Regressionsevidenz enthalten.
2. **Gegeben / Given** reine Governance- oder Textarbeit, **wenn / when** TDD
   bewertet wird, **dann / then** wird `N/A` kurz begründet und bei der nächsten
   Logikänderung erneut geprüft.

### Grenzfälle / Edge Cases

- Eine erfüllte Anforderung bleibt `AlreadySatisfied` und erzeugt keine
  Implementierungsaufgabe.
- Eine veraltete Intake-Formulierung darf Security-First-Prinzip I nicht
  umbenennen oder verdrängen.
- XML-Elemente sind nur erforderlich, wenn sie zur jeweiligen öffentlichen API
  passen; lokale Variablen erhalten keine künstlichen XML-Kommentare.
- Eine reine Markdown-Änderung löst nicht automatisch einen API-Neubau aus.
  API-, XML- oder DocFX-Navigationsänderungen lösen die dokumentierte Prüfung
  aus.
- Semantisch abweichende Agentenflächen bestehen die Paritätsschranke nicht,
  auch wenn jede Datei syntaktisch gültig ist.
- Ein später autorisierter Admin-Bypass darf fehlende fachliche, Security- oder
  Evidence-Gates nicht in ein bestandenes Ergebnis umdeuten.

## Intake-Abgleich / Intake Reconciliation

`Applicable` wird in diesem Feature umgesetzt. `AlreadySatisfied` ist bereits
belegt. `N/A` ist technisch nicht anwendbar. `FollowUp` bleibt absichtlich bei
einem späteren, geordneten Intake. Es gibt keine ungeklärte `Open`-Anforderung.

| ID | Intake-Anforderung / Intake requirement | Einstufung / Classification | Begründung und Evidenz / Rationale and evidence |
|---|---|---|---|
| IR-001 | Lesbarkeit und Lernwert haben Vorrang; Komponenten bleiben verständlich getrennt. / Readability and learning value take priority; components remain understandable. | `AlreadySatisfied` | Repository-Guidance und bestehende Core-/TUI-Trennung tragen diese Regel. / Guidance and the existing Core/TUI separation already carry the rule. |
| IR-002 | Lerntexte stehen Deutsch zuerst und Englisch danach. / Learning text is German first and English second. | `AlreadySatisfied` | Constitution VII/VIII und Agenten-Guidance enthalten die Reihenfolge. / Constitution and agent guidance contain the order. |
| IR-003 | Beide Sprachblöcke zielen auf CEFR B2. / Both language blocks target CEFR B2. | `AlreadySatisfied` | Constitution VIII sowie A11Y- und Projekt-Guidance belegen das Ziel. / Constitution and guidance evidence the target. |
| IR-004 | Der didaktische Grundsatz trägt den Titel „Didaktische und sprachliche Klarheit“. / The pedagogical rule has the stated title. | `Applicable` | Der sichere Ort ist das TinyCalc-Level-2-Addendum; Security-First bleibt Prinzip I. / The safe location is the TinyCalc Level-2 addendum; Security-First remains Principle I. |
| IR-005 | Öffentliche Typen und Mitglieder besitzen vollständige, anwendbare XML-Dokumentation. / Public types and members have complete applicable XML documentation. | `AlreadySatisfied` | Beide Produktprojekte erzeugen XML-Dokumentation und behandeln CS1591 als Fehler. / Both product projects generate XML docs and treat CS1591 as an error. |
| IR-006 | XML-Kommentare gelten auch für lokale Variablen. / XML comments also apply to local variables. | `N/A` | C# bietet keine XML-Dokumentationsfläche für lokale Variablen; normale Warum-Kommentare bleiben möglich. Wiedervorlage bei neuer öffentlicher API-Fläche. / C# has no XML-doc surface for locals; normal why-comments remain possible. Recheck for new public API. |
| IR-007 | Geeignete didaktische Kommentare stehen DE zuerst, EN danach. / Suitable didactic comments are DE first, EN second. | `AlreadySatisfied` | Die Agenten-Guidance fordert moderate zweisprachige Warum-Kommentare. / Agent guidance requires moderate bilingual why-comments. |
| IR-008 | Dokumentation dient als Lernmaterial für Fachinformatiker. / Documentation serves as learning material for IT apprentices. | `AlreadySatisfied` | Constitution und Repository-Guidance benennen Lernende und erstes Ausbildungsjahr. / Constitution and guidance name learners and first-year audiences. |
| IR-009 | Kommentare erklären Entscheidungen, Abwägungen und Grenzen. / Comments explain decisions, trade-offs, and constraints. | `AlreadySatisfied` | `AGENTS.md` und die gepflegten Agentenflächen enthalten die Warum-Regel. / Maintained guidance contains the why-rule. |
| IR-010 | Fehlende öffentliche XML-Dokumentation ist Build-Fehler; keine globale CS1591-Unterdrückung. / Missing public XML docs fail the build; no global CS1591 suppression. | `AlreadySatisfied` | `MicroCalc.Core` und `MicroCalc.Tui` führen `CS1591` in `WarningsAsErrors`. / Both product projects list CS1591 in WarningsAsErrors. |
| IR-011 | API-/XML-Änderungen erzeugen DocFX-Ausgabe im selben Commit/PR. / API or XML changes regenerate DocFX in the same commit/PR. | `AlreadySatisfied` | Agenten-Guidance und `docfx.json` definieren den Prozess. / Guidance and docfx configuration define the process. |
| IR-012 | Gemeinsame Laufzeit-Guidance wird über alle Agentenflächen gepflegt. / Shared runtime guidance is maintained across all agent surfaces. | `Applicable` | Der neue Titel und TDD-Ablauf müssen atomar in `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`, beiden Copilot-Flächen und betroffenen Templates geprüft werden. / The title and TDD flow require atomic parity review. |
| IR-013 | Dokumentationskonformität wird erneut geprüft und Lücken werden geschlossen. / Documentation compliance is rechecked and gaps are closed. | `Applicable` | Die vorhandene Build-Schranke wird als Regression geprüft; echte öffentliche Lücken bleiben innerhalb dieses Features. / The existing build gate is regression-tested; real public gaps remain in scope. |
| IR-014 | Jede allgemeine Prosaänderung startet DocFX. / Every general prose change starts DocFX. | `N/A` | Die spezifischere aktuelle Regel bindet DocFX an API, XML, Navigation oder Präsentation. Wiedervorlage bei einem solchen Trigger. / The current specific rule binds DocFX to API, XML, navigation, or presentation changes. Recheck on such a trigger. |
| IR-015 | Neue Funktionen und Fehlerkorrekturen zeigen TDD Rot → Grün → Aufräumen. / New features and fixes show TDD red → green → refactor. | `Applicable` | Tests sind Pflicht, aber der ausdrückliche didaktische Evidenzablauf fehlt. / Tests are mandatory, but the explicit learning-evidence flow is missing. |
| IR-016 | Vorhandene Kommentare werden vollständig didaktisch nachgearbeitet. / Existing comments are fully remediated for teaching. | `FollowUp` | Die Serienkette reserviert die Bestandsprüfung für `Lastenheft_Didactic-Inline-Code-Comment-Hardening.md`. / The series reserves the inventory review for the later didactic-comment intake. |

## Anforderungen / Requirements

### Funktionale Anforderungen / Functional Requirements

- **FR-001**: Die kanonische Constitution MUSS im TinyCalc-Level-2-Addendum
  einen klar abgegrenzten Abschnitt „Didaktische und sprachliche Klarheit /
  Pedagogical and Linguistic Clarity“ führen, ohne Security-First-Prinzip I zu
  ersetzen oder abzuschwächen.
- **FR-002**: `constitution.md` und `.specify/memory/constitution.md` MÜSSEN
  nach jeder Änderung inhaltlich und bytegleich synchron sein.
- **FR-003**: Die Governance MUSS für neue Funktionen und Fehlerkorrekturen
  TDD Rot → Grün → Aufräumen mit beobachtbarer Evidenz verlangen; reine
  Governance- oder Textarbeit DARF TDD mit Begründung als `N/A` einstufen.
- **FR-004**: Die bestehende öffentliche XML-Dokumentationsschranke in beiden
  Produktprojekten MUSS erhalten bleiben und durch einen erfolgreichen Build
  sowie eine Prüfung gegen globale CS1591-Unterdrückung belegt werden.
- **FR-005**: Öffentliche XML-Dokumentation MUSS Zusammenfassung, Parameter,
  Rückgabe und Ausnahmen jeweils dort enthalten, wo diese Elemente fachlich
  anwendbar sind; lokale Variablen sind ausgeschlossen.
- **FR-006**: Gemeinsame Regeln MÜSSEN atomar über `AGENTS.md`, `CLAUDE.md`,
  `GEMINI.md`, `.github/copilot-instructions.md`,
  `.github/agents/copilot-instructions.md` und betroffene Spec-Kit-Templates
  abgeglichen werden. Absichtliche Abweichungen benötigen Begründung.
- **FR-007**: Lernendenbezogene neue oder geänderte Texte MÜSSEN Deutsch zuerst
  und Englisch danach auf CEFR-B2-Niveau liefern, Fachbegriffe bei der ersten
  Verwendung erklären und text-first verständlich bleiben.
- **FR-008**: Bei Änderungen an API-Signaturen, XML-Kommentaren,
  DocFX-Navigation oder API-Präsentation MÜSSEN DocFX und die dokumentierte
  textorientierte A11Y-Prüfung im selben Arbeitsgegenstand erfolgreich sein.
- **FR-009**: `docs/project-statistics.md` MUSS nach der Umsetzung genau einen
  chronologisch passenden Feature-Eintrag sowie aktualisierte text-first
  ASCII-Trends enthalten.
- **FR-010**: Kein späterer Intake DARF durch dieses Feature gestartet oder
  vorgezogen werden; Status und nächste Aktion bleiben aus der Serie ableitbar.

*The canonical constitution must add a scoped TinyCalc pedagogical and
linguistic clarity section without weakening Security-First. Both constitution
copies remain byte-identical. Governance must require observable TDD evidence
for features and fixes, preserve the existing public XML documentation gate,
document only applicable API elements, maintain all shared agent and template
surfaces atomically, deliver learner text in bilingual CEFR-B2 text-first form,
run DocFX and accessibility proof on defined triggers, update statistics once,
and start no later intake.*

### Constitution-Anforderungen / Constitution Requirements

- **CR-001**: Der Level-2-Registry-Eintrag für TinyCalc ist verbindlicher
  Kontext: C#/.NET 10, `MicroCalc.sln`, xUnit, TUI-Smoke, DocFX/A11Y und die
  Baselines 80 beziehungsweise 125 Zeilen pro Arbeitstag.
- **CR-002**: C# ist eine speichersichere Sprache der MSL-Erlaubnisliste;
  sichere .NET-Entwicklung bleibt dennoch verpflichtend.
- **CR-003**: NIST SSDF und CWE Top 25 gelten für Planung, Umsetzung, Review
  und Abschluss. Nicht anwendbare Standards werden begründet und mit
  Wiedervorlage dokumentiert.
- **CR-004**: Nutzer- und Lernartefakte folgen WCAG 2.2 AA, text-first,
  DE zuerst/EN danach und CEFR B2; Status und Entscheidungen dürfen nicht nur
  visuell vermittelt werden.
- **CR-005**: Die genaue Standard-Acht-Preset-Matrix aus
  `scripts/config/spec-kit-governance-presets.json` gilt; separat verwaltete
  optionale Intake-Presets werden nicht fälschlich als Standardmatrix gezählt.
- **CR-006**: Die Dokumentationsauswirkung dieses Features ist genau
  `UpdateRequired` und folgt dem unten festgelegten Evidenzpfad.
- **CR-007**: Der aktuelle Specify-Schritt gewährt keine Implementierungs- oder
  Remote-Autorität. Der gewünschte spätere Liefermodus ist `MergeAndSync` mit
  ausdrücklich genanntem Admin-Bypass; diese Autorität MUSS an der
  Delivery-Grenze gegen exakten Head, Scope und Gates erneut bestätigt werden.

## Zentrale Artefakte / Key Entities

- **Governance-Spiegelpaar / Governance Mirror Pair**: kanonische Constitution,
  synchroner Memory-Spiegel, Version und Inhaltsidentität.
- **Agenten-Paritätsmenge / Agent Parity Set**: fünf gepflegte Agentenflächen
  plus betroffene Templates und ihre semantisch gemeinsamen Regeln.
- **Intake-Klassifikation / Intake Classification**: genau eine Einstufung,
  Begründung, Evidenz und Wiedervorlage je Intake-Position.
- **Dokumentationsschranke / Documentation Gate**: Produktprojekte,
  öffentliche API-Fläche, erforderliche XML-Elemente und Build-Evidenz.
- **Feature-Evidenz / Feature Evidence**: Spec, Checkliste, spätere
  Plan-/Task-/Build-/A11Y-/Security-/Statistiknachweise.

## Governance-Anwendbarkeit und Audit-Evidenz / Governance Applicability and Audit Evidence

| Prüfpunkt / Checkpoint | Status | Begründung und Evidenz / Rationale and evidence | Wiedervorlage / Re-evaluation |
|---|---|---|---|
| NIST SSDF | `Applicable` | Für Level 2 immer Pflicht; Spec und Checkliste sind Prepare-Evidenz. / Always mandatory; spec and checklist are Prepare evidence. | Plan, Tasks, Implementierung, Review und Abschluss. / At every later phase. |
| CWE Top 25 | `Applicable` | Governance-, Build- und Dokumentationsänderungen erhalten Security-Review; keine neue Eingabegrenze. / Changes receive security review; no new input boundary. | Bei Code-, Datei- oder Build-Logikänderung. / On code, file, or build-logic change. |
| C#-MSL und Secure Coding | `Applicable` | C#/.NET 10 ist speichersicher; sichere .NET-Regeln gelten. / C# is memory-safe; secure .NET rules apply. | Implementierung und Review. / Implementation and review. |
| OWASP ASVS | `N/A` | Kein Web-, API-, HTTP- oder Authentifizierungs-Scope. / No web, API, HTTP, or auth scope. | Bei entsprechendem Scope. / On such scope. |
| SBOM, VEX und SLSA | `N/A` | Keine Abhängigkeit, ausgelieferte Komponente oder Build-/Publishing-Pipeline wird geändert. / No dependency, shipped component, or pipeline changes. | Vor Release, CVE-Bewertung oder Pipelineänderung. / Before release, CVE review, or pipeline change. |
| AI-SBOM | `N/A` | KI ist nur Entwicklungswerkzeug und kein Produktbestandteil. / AI is development tooling only. | Bei KI-Runtime, Modell, Daten oder Inferenzdienst im Produkt. / On product AI. |
| OpenSSF Scorecard | `N/A` | Keine neue externe Abhängigkeit und kein Release-Scope. / No new dependency or release scope. | Bei Abhängigkeit oder Release. / On dependency or release. |
| NIS2, CRA, EU AI Act, DORA | `N/A` | Keine Marktbereitstellung, regulierte Dienstleistung, KI-Runtime oder Finanz-ICT-Änderung. / No applicable regulatory trigger. | Bei Änderung eines Triggers. / On trigger change. |
| STRIDE/CIA, CAPEC und Trust Boundaries | `N/A` | Keine Laufzeit-, Datenfluss- oder Vertrauensgrenzenänderung. / No runtime, data-flow, or trust-boundary change. | Bei externem Input, Datei-/Netzwerkfluss oder Privilegänderung. / On such changes. |
| S-ADR und arc42 Security | `N/A` | Keine sicherheitsrelevante Architekturentscheidung. / No security architecture decision. | Bei Architektur- oder Trust-Boundary-Änderung. / On architecture change. |
| Zero Trust, BSI C3A und BSI C5 | `N/A` | Kein verteiltes, Cloud-, Provider- oder Remote-System betroffen. / No distributed, cloud, provider, or remote system. | Bei entsprechendem Betriebsmodell. / On such an operating model. |
| OWASP SAMM | `N/A` | Bestehende Bewertung bleibt unverändert; kein Security-Prozess wird geändert. / Existing assessment remains unchanged. | Bei Security-Prozessänderung. / On security-process change. |
| Allgemeine iSAQB-/arc42-Architektur | `N/A` | Kontext, Schnittstellen, Bausteine, Runtime und Deployment bleiben unverändert. / Architecture remains unchanged. | Bei struktureller oder laufzeitbezogener Änderung. / On architecture change. |
| WCAG 2.2 AA und text-first | `Applicable` | Spec, Checkliste und spätere Governance-Dokumentation sind nutzerseitig. / User-facing documentation is affected. | Bei jeder Text- oder DocFX-Änderung. / On each text or DocFX change. |
| DE zuerst, EN danach, CEFR B2 | `Applicable` | Spec und Checkliste liefern beide Sprachpfade in der geforderten Reihenfolge. / Both language paths are provided. | Bei jeder Textänderung. / On each text change. |
| Didaktische Inline-Kommentare | `N/A` für Specify | Specify ändert keine C#-Logik. / Specify changes no C# logic. | Bei späterer Logikänderung. / On later logic change. |
| Skript-/Cmdlet-Parität | `N/A` | Kein skriptförmiges Werkzeug wird geändert; daher keine `.sh`/`.ps1`-, Manpage-, Cmdlet- oder Dry-run-Fläche. / No script-shaped tool changes. | Bei Automations- oder Manpage-Änderung. / On tooling change. |
| Agentenparität und Templates | `Applicable` | FR-006 benennt die gemeinsame Pflegemenge; keine absichtliche Abweichung geplant. / FR-006 defines the parity set. | Vor Abschluss semantisch prüfen. / Before closeout. |
| Security-Evidenz unter `docs/security/` | `Applicable`, überwiegend `AlreadySatisfied` | Vorhanden sind Threat Model, arc42 Security, Checklist, Dependency Audit, ASVS-, Supply-Chain-, Zero-Trust- und SAMM-Dateien; nur tatsächliche Trigger ändern sie. / Required evidence files exist; only real triggers update them. | Im Plan je Datei entscheiden. / Decide per file in planning. |
| Architektur-Evidenz unter `docs/architecture/` | `N/A` | Keine Architekturänderung; feature-lokale Spec und Checkliste reichen. / No architecture change. | Bei Architekturtrigger. / On architecture trigger. |
| Audit-Checkliste | `Applicable` | `specs/002-constitution-change/checklists/requirements.md`. / Feature checklist. | An jeder Phasengrenze. / At every phase boundary. |

## Autonomous-run-Anwendbarkeit / Autonomous-run Applicability

- **Liefermodus / Delivery mode**: `MergeAndSync` mit vom Nutzer ausdrücklich
  gewünschtem Admin-Bypass für eine spätere Delivery-Grenze. Specify selbst
  darf weder committen noch Remote-Aktionen ausführen.
- **Feature-Identität / Feature identity**: Branch `002-constitution-change`,
  Verzeichnis `specs/002-constitution-change`; noch kein autonomer Run-State.
- **Akzeptierte Eingaben / Accepted inputs**:
  - Intake: `dce77a3f0c5aee07cd6c033c27d3cfdf5c991208e8dd8eeba02e49505193d37f`
  - Review-Ergebnis: `271790e2f3b79e640726b8c05e70fbb0e6cf605077a20496f48b61f7ff2c5647`
  - Review-Anfrage: `1836955690f990ea66339c0374dde0f01fcffdb9b019ef875e6cd753c75f35b9`
  - Serienmanifest: `c9d5235a900c0046fc5a906582ddbc360d759d19d8dd859362faf431a4d969a6`
- **Delivery-Set-/Schemaänderung / Delivery-set or schema change**: `N/A`;
  dieses Feature ändert keine autonome Ergebnis- oder Gate-Semantik.
- **Mutable Validation Tokens**: `N/A` in Specify; keine Provider-, Review-
  oder Merge-Tokens werden verwendet.
- **Kausaler Abschluss / Causal closeout**: in Specify `N/A`; ein späterer
  vollständiger Lauf muss Merge, `main`-Synchronisation und Post-Merge-Zustand
  kausal belegen.
- **Stopp und Wiederaufnahme / Stop and resume**: Ein späterer autonomer Lauf
  muss bei bewusstem Stopp pausieren und bei Unterbrechung Branch, Hashes,
  Scope, Routing und Artefakte vor Resume prüfen.
- **Admin-Bypass-Grenze / Admin-bypass boundary**: Der Bypass ist kein Ersatz
  für fehlgeschlagene fachliche, Security-, A11Y- oder Evidence-Gates. Er darf
  nur nach erneuter Autoritätsprüfung am exakten Delivery-Head eingesetzt
  werden.

### Akzeptanz-Schranken / Acceptance Gates

| Gate-ID | Status | Erforderliche Evidenz / Required evidence | Wiedervorlage / Re-evaluation |
|---|---|---|---|
| `SPEC-GATE-001` | `Applicable` | Vier akzeptierte normalisierte Eingabehashes stimmen. / Four accepted input hashes match. | Vor jeder Phasenfortsetzung. / Before each phase. |
| `SPEC-GATE-002` | `Applicable` | Jede Intake-Position besitzt genau eine erlaubte Klassifikation; nur `Applicable` erzeugt Arbeit. / Every intake item has one classification; only Applicable creates work. | Clarify und Analyze. |
| `SPEC-GATE-003` | `Applicable` | Spec und Checkliste sind vollständig, DE→EN, CEFR B2, text-first und ohne Klärungsmarker. / Spec and checklist are complete and accessible. | Bei Textänderung. / On text change. |
| `SPEC-GATE-004` | `Applicable` | Scope, Nicht-Ziele, Reihenfolge, Governance und Evidenz sind nachvollziehbar; kein anderer Intake wurde gestartet. / Boundaries remain traceable. | Vor Phasenabschluss. / Before phase completion. |
| `SPEC-GATE-005` | `N/A` | Keine Runner-, Delivery- oder Gate-Schemaänderung. / No autonomous schema change. | Bei Semantikänderung. / On semantic change. |

## Dokumentationsauswirkung / Documentation Impact

**Entscheidung / Decision**: `UpdateRequired`

- **Zielgruppen / Audiences**: Auszubildende ab dem ersten Ausbildungsjahr,
  Lehrende, Entwicklerinnen und Entwickler, Reviewer und KI-Agenten.
- **Leserpfade / Reader paths**: Constitution oder Agenten-Guidance → Sprach-,
  A11Y-, XML- und TDD-Regeln → Nachweise → nächste Serienaktion.
- **Dokumentfamilien / Documentation families**: normative Governance,
  Agenten-Guidance, Spec-Kit-Templates und Projektstatistik; generierte API-
  Dokumentation nur bei tatsächlichem XML-/API-/DocFX-Trigger.
- **Kanonische Quelle und Owner / Canonical source and owner**:
  `constitution.md`, Repository-Maintainer; Standard-Preset-Matrix aus
  `scripts/config/spec-kit-governance-presets.json`, Spec-Kit-Maintainer.
- **Navigation / Navigation impact**: Der TinyCalc-Level-2-Abschnitt bleibt im
  vorhandenen Addendum auffindbar; keine neue Hauptnavigation.
- **Dokumentklasse / Document class**: Level-2-Governance mit Spiegel- und
  Template-Ableitungen.
- **Sprachstrategie / Language strategy**: kurze Texte inline DE zuerst, EN
  danach; große normative Dokumente dürfen einen synchronen `.EN.md`-Partner
  verwenden. Kein neuer Sidecar ist geplant.
- **Plattform-/Beispielnachweis / Platform and example proof**: semantisches
  Markdown plattformneutral; Build-/DocFX-/A11Y-Nachweis nach Registry-Vertrag.
- **Distribution und Home-Sync / Distribution and home sync**:
  repository-lokaler `sourceOnly`-Inhalt; Home-Sync `N/A`, weil keine externe
  Home-Runtime-Fläche geändert wird.
- **Evidenz / Evidence**: diese Spec, Qualitätscheckliste, spätere Build-, Test-,
  Paritäts-, DocFX-/A11Y- und Statistiknachweise sowie bei Triggern die
  vorhandenen Dateien unter `docs/security/`.
- **Wiedervorlage / Re-evaluation trigger**: jede Änderung an Constitution,
  öffentlicher API, XML-Kommentaren, DocFX, Agentenparität, Preset-Matrix oder
  Statistikmethodik.

## Annahmen / Assumptions

- Der Intake und die drei Review-/Serienartefakte bleiben unverändert.
- `constitution.md` ist kanonisch; `.specify/memory/constitution.md` ist der
  synchrone Spiegel.
- Vollständige öffentliche XML-Dokumentation bedeutet „wo anwendbar“ und
  verlangt keine erfundenen Rückgabe- oder Ausnahmeabschnitte.
- Der spätere Plan darf Prüfkommandos konkretisieren, aber Scope und Abnahme
  nicht erweitern.
- `MergeAndSync` und Admin-Bypass sind spätere Lieferabsicht, keine Erlaubnis
  für Remote-Aktionen in Specify.

## Risiken / Risks

- Ein ungenauer Governance-Text könnte Security-First versehentlich
  verdrängen; FR-001 verhindert das ausdrücklich.
- Parität über mehrere Guidance- und Template-Flächen kann semantisch driften;
  ein gemeinsamer Review bleibt Pflicht.
- Eine überbreite XML-Regel könnte nutzlose Kommentare erzeugen; FR-005
  begrenzt sie auf anwendbare öffentliche API-Flächen.
- Ein erfolgreicher Build allein beweist keine zugängliche DocFX-Ausgabe; bei
  Triggern bleibt der textorientierte A11Y-Nachweis eigenständig.
- Ein Admin-Bypass könnte fälschlich als Qualitätsfreigabe verstanden werden;
  seine klar begrenzte Delivery-Rolle verhindert diese Gleichsetzung.

## Test- und Evidenzstrategie / Test and Evidence Strategy

1. Die vier akzeptierten Eingabehashes vor jeder Phasenfortsetzung vergleichen.
2. Intake-Klassifikation auf Vollständigkeit, Einzigkeit und erlaubte Werte
   prüfen.
3. Constitution, Spiegel, Agentenflächen und betroffene Templates semantisch
   sowie mit vorhandenen Homogenitätsprüfungen vergleichen.
4. Die vorhandene öffentliche XML-Dokumentationsschranke durch Build und
   Projektkonfigurationsprüfung bestätigen.
5. Die vollständige xUnit-Suite ausführen. Bei späterer Produktlogik gilt TDD
   Rot → Grün → Aufräumen; reine Governance-Arbeit erhält ein begründetes
   `N/A`.
6. Bei API-, XML- oder DocFX-Triggern DocFX aus dem Repository-Hauptverzeichnis
   ausführen und repräsentative Seiten mit Playwright/axe sowie `lynx`
   textorientiert prüfen.
7. Dokumentations-, Security-, A11Y-, Agentenparitäts- und Statistik-Evidenz
   vor Abschluss gegen diese Spec prüfen.

## Messbare Ergebnisse / Measurable Outcomes

- **SC-001**: 100 % der 16 Intake-Positionen besitzen genau eine erlaubte
  Einstufung; 100 % der geplanten Arbeit stammt aus `Applicable`-Positionen.
- **SC-002**: 100 % der gepflegten Constitution-, Agenten- und betroffenen
  Template-Flächen enthalten semantisch dieselben neuen Regeln; keine
  unbegründete Abweichung bleibt.
- **SC-003**: Beide Produktprojekte behalten Dokumentationserzeugung und aktive
  CS1591-Fehlerschranke; ein sauberer Build meldet keine öffentliche
  Dokumentationslücke.
- **SC-004**: Bei jedem tatsächlichen API-/XML-/DocFX-Trigger liegen genau ein
  erfolgreicher DocFX-Nachweis und ein textorientierter A11Y-Nachweis aus
  demselben Arbeitsgegenstand vor.
- **SC-005**: 100 % der betroffenen neuen Funktionen oder Fehlerkorrekturen
  besitzen Rot-, Grün- und Regressionsevidenz oder ein überprüfbares `N/A`.
- **SC-006**: Alle bestehenden automatisierten Tests bleiben erfolgreich und
  die Projektstatistik enthält genau einen neuen, chronologisch korrekten
  Feature-Eintrag.
- **SC-007**: Reviewer und Lernende können Scope, Nicht-Ziele, Reihenfolge,
  Status, Evidenz und nächste sichere Aktion vollständig aus Text entnehmen.

*All 16 intake items have exactly one classification and all planned work comes
from Applicable items. Every maintained governance surface carries the same
rules. Both product projects retain their active XML documentation gate. Each
actual API/XML/DocFX trigger has successful generation and text-oriented
accessibility evidence. Every affected feature or fix has TDD evidence or a
reviewable N/A. Existing tests remain successful, statistics gain one correct
entry, and all important decisions remain understandable from text alone.*
