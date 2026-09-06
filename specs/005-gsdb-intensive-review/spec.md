# Feature-Spezifikation: GSDB-Intensivpruefung / Feature Specification: Intensive GSDB Review

**Feature Branch**: `005-gsdb-intensive-review`
**Created / Erstellt**: 2026-09-06
**Status**: Tasks complete; Analyze in progress / tasks complete; analyze in progress
**Input / Bindender Intake**: `requirements/intakes/active/Lastenheft_GSDB-Spec-Kit-Intensivpruefung.md`
**Run / Lauf**: `69674c80-911c-40ff-9a0e-004f7b13b832`

**DE:** Die Generische Secure-Development Basis (GSDB) beschreibt Regeln fuer
sichere Entwicklung. Dieses Feature verlangt eine intensive, nachvollziehbare
Pruefung von TinyCalc gegen diese Basis, beide Constitutions, die installierten
Governance-Presets und projektspezifische Nachweise. Ein Preset ist ein Paket
von Arbeitsregeln und Vorlagen; Evidenz ist ein nachpruefbarer Beleg. Spec Kit
trennt Anforderungen, Klaerung, Planung und Pruefung in Phasen. Diese
Spezifikation beschreibt das geforderte Ergebnis, keine bereits erfolgte
Intensivpruefung oder Freigabe.

**EN:** The Generic Secure Development Baseline (GSDB) describes secure
development rules. This feature requires an intensive, traceable review of
TinyCalc against that baseline, both constitutions, installed governance
presets, and project evidence. A preset is a package of workflow rules and
templates; evidence is a verifiable record. Spec Kit separates requirements,
clarification, planning, and verification into phases. This specification
defines the required result; it does not claim a completed review or approval.

## Nutzerszenarien und Pruefung / User Scenarios & Testing

### User Story 1 - Vollstaendige Abdeckung / Complete coverage (Priority: P1)

**DE:** Als Projektverantwortlicher moechte ich jeden GSDB-Pruefpunkt mit Quelle,
Bewertung und Beleg finden, damit keine Checkliste unbemerkt fehlt.
**Warum P1:** Ohne vollstaendige Abdeckung ist das Ergebnis nicht belastbar.
**Unabhaengige Pruefung:** Quelleninventar und Evidenzmatrix abgleichen; jede
Quell-ID muss genau einer Bewertung zugeordnet sein.

**EN:** As the project owner, I want every GSDB item linked to its source,
assessment, and evidence so that no checklist is silently missed.
**Why P1:** Complete coverage is necessary for a reliable result.
**Independent test:** Compare the source inventory and evidence matrix; each
source ID must map to exactly one assessment.

**Akzeptanzszenarien / Acceptance Scenarios:**

1. **DE:** Bei vorhandener GSDB erfasst die Pruefung Richtlinie, CL-01 bis CL-12,
   Sammelband, Lernpfad und alle mitgeltenden Dokumente. Fehlende oder
   widerspruechliche Quellen erzeugen einen sichtbaren offenen Befund.
   **EN:** Given the GSDB, review covers the guideline, CL-01 to CL-12,
   compendium, learning path, and all related documents. Missing or conflicting
   sources produce a visible open finding.
2. **DE:** Alte Preflight- oder Feature-Evidenz darf erst nach Pruefung von
   Scope und Aktualitaet als Nachweis wiederverwendet werden.
   **EN:** Old preflight or feature evidence may be reused only after checking
   its scope and freshness.

### User Story 2 - Ehrliche Entscheidungen / Honest decisions (Priority: P1)

**DE:** Als Reviewer moechte ich Anwendbarkeit, Erfuellung und menschliche
Zustaendigkeit getrennt sehen, damit offene Arbeit nicht als Erfolg erscheint.
**Warum P1:** Falsche Erfuellungsbehauptungen untergraben den Pruefzweck.
**Unabhaengige Pruefung:** Je einen anwendbaren, nicht anwendbaren, unbelegten
und Human-only-Punkt gegen Begruendung und Nachweise lesen.

**EN:** As a reviewer, I want applicability, fulfillment, and human responsibility
shown separately so unfinished work cannot appear complete.
**Why P1:** False fulfillment claims defeat the review's purpose.
**Independent test:** Read one applicable, non-applicable, unsupported, and
human-only item against its rationale and evidence.

**Akzeptanzszenarien / Acceptance Scenarios:**

1. **DE:** Fehlt ein belastbarer Erfüllungsbeleg bei bekanntem Umfang, bleibt
   der Punkt `Applicable` und erhält einen nicht erfüllten Umsetzungsstatus;
   Owner, Folgearbeit, erwarteter Nachweis, Zieltermin,
   Neubewertungs-Trigger und Restrisiko werden benannt. `Open` gilt nur, wenn
   die Anwendbarkeit selbst noch ungeklärt ist.
   **EN:** When reliable fulfilment evidence is missing for known scope, the
   item remains `Applicable` and receives a non-fulfilled implementation
   status; owner, follow-up, expected evidence, target date, re-evaluation
   trigger, and residual risk are named. `Open` applies only when applicability
   itself remains unresolved.
2. **DE:** Erfordert ein Punkt menschliche Freigabe, wird er `Human-only`.
   Ohne echte menschliche Entscheidung behauptet kein Agent seine Erledigung.
   Ein begruendetes `N/A` bleibt sichtbar.
   **EN:** A control requiring human approval is marked `Human-only`. No agent
   claims completion without an actual human decision. Justified `N/A` remains visible.
3. **DE:** Fehlende regulatorische Evidenz erzeugt nur dann `Open`, wenn dadurch
   die rechtliche Anwendbarkeit ungeklärt bleibt. Bei bekanntem Umfang entsteht
   ein nicht erfüllter Status mit Befund; der Ausbildungszweck allein
   entscheidet keine rechtliche Anwendbarkeit.
   **EN:** Missing regulatory evidence produces `Open` only when legal
   applicability therefore remains unresolved. For known scope it produces a
   non-fulfilled status with a finding; training purpose alone does not
   determine legal applicability.

### User Story 3 - Verstaendliche Nacharbeit / Understandable follow-up (Priority: P2)

**DE:** Als lernende Person ab Lehrjahr 1 moechte ich Grund, Status und naechsten
Schritt ohne Spec-Kit-Vorwissen verstehen und bei komplexen Entscheidungen
eine verantwortliche Person erkennen.
**Warum P2:** Das Ergebnis soll als Lern- und Reviewunterlage verwendbar sein.
**Unabhaengige Pruefung:** Ohne Farbe oder grafische Navigation fuer einen
offenen Punkt Owner, Beleg und naechsten Schritt im Text finden.

**EN:** As a first-year apprentice, I want to understand the reason, status,
and next step without prior Spec Kit knowledge and identify who owns complex decisions.
**Why P2:** The result must support learning and review.
**Independent test:** Locate an open item's owner, evidence, and next action
in the text without color or graphical navigation.

**Akzeptanzszenarien / Acceptance Scenarios:**

1. **DE:** Eine Ausbildungs-, Projekt- oder Security-Rolle uebernimmt
   fortgeschrittene Entscheidungen. Das Lehrjahr allein begruendet niemals `N/A`.
   **EN:** An instructor, project owner, or security role owns advanced
   decisions. Training year alone never justifies `N/A`.
2. **DE:** Deutsch und Englisch vermitteln auf CEFR B2 denselben Scope,
   Status und Folgeauftrag. Tabellen bleiben als Text verstaendlich.
   **EN:** German and English at CEFR B2 convey the same scope, status, and
   follow-up. Tables remain understandable as text.

### User Story 4 - Nachweisbarer Abschluss / Evidence-based closeout (Priority: P2)

**DE:** Als Laufverantwortlicher moechte ich den spaeteren Lieferabschluss an
konkrete Pruefungen binden, damit gruene Sammelstatus keine fehlende Evidenz verdecken.
**Warum P2:** Der gespeicherte Lauf sieht `MergeAndSync` vor: Zusammenfuehren
und anschliessendes Abgleichen mit dem Standardbranch.
**Unabhaengige Pruefung:** Die unten definierten Gates gegen ihre
Nachweisvertraege pruefen, ohne Remote-Aktionen auszufuehren.

**EN:** As the run owner, I want eventual delivery completion bound to specific
checks so green aggregate states cannot hide missing evidence.
**Why P2:** The recorded run targets `MergeAndSync`: merge and synchronize with
the default branch.
**Independent test:** Compare the gates below with their evidence contracts
without performing remote actions.

**Akzeptanzszenarien / Acceptance Scenarios:**

1. **DE:** Aendert sich der Commit, verlieren abhaengige Checks ihre
   Abschlussgueltigkeit. Providerfehler oder verweigerte Laeufe sind kein Pass.
   **EN:** A changed commit invalidates dependent closeout checks. Provider
   errors or refused runs are not passing evidence.
2. **DE:** Specify-Abschluss meldet nur fertige Spezifikationsarbeit. Pruefung,
   Umsetzung, Merge und Sync bleiben getrennt nachzuweisende spaetere Schritte.
   **EN:** Specify completion reports only finished specification work. Review,
   implementation, merge, and sync remain separately evidenced later steps.

### Grenzfaelle / Edge Cases

**DE:** Doppelte oder fehlende CL-IDs, abweichende Sammelbandtexte, alte Pfade,
Preset-Drift und widerspruechliche Nachweise erzeugen Befunde statt stiller
Auswahl. Vorhandene Ordner, gruener Preflight und installierte Vorlagen beweisen
keine erfuellte Kontrolle. Unerreichbare Scanner oder Quellen werden mit Datum
und Folgearbeit dokumentiert. Geheime Inhalte werden nicht in Belege kopiert.
Ein fehlender menschlicher Reviewer bleibt offen.

**EN:** Duplicate or missing CL IDs, differing compendium text, stale paths,
preset drift, and conflicting evidence produce findings instead of silent
selection. Existing folders, green preflight, and installed templates do not
prove fulfillment. Unavailable scanners or sources require a dated record and
follow-up. Evidence must not copy secrets. Missing human reviewers remain open.

## Anforderungen / Requirements

### Funktionale Anforderungen / Functional Requirements

**DE:** Diese Anforderungen gelten fuer das gesamte Prueffeature. Die
Schreibgrenze dieser Specify-Phase steht im Abschnitt Laufgrenzen.

**EN:** These requirements apply to the entire review feature. This Specify
phase's write boundary is defined under run boundaries.

| ID | Deutsch | English |
|---|---|---|
| FR-001 | Nur den bindenden Intake bearbeiten; Serienreihenfolge und Nicht-Ziele erhalten. | Handle only the binding intake; preserve series ordering and non-goals. |
| FR-002 | Quelleninventar mit Pfad, Version, Pruefdatum und normalisiertem SHA-256 erstellen: Richtlinie, 12 CLs, Sammelband, alle mitgeltenden Dokumente, Lernpfad, beide Constitutions und Presets. | Inventory paths, versions, review dates, and normalized SHA-256 values for the guideline, 12 CLs, compendium, all related documents, learning path, both constitutions, and presets. |
| FR-003 | Jeden CL-Punkt nach stabiler ID bewerten. Das Baseline-Manifest nennt 157 Punkte; die Zahl gegen echte Quellen verifizieren. | Assess every CL item by stable ID. The baseline manifest declares 157 items; verify that count against actual sources. |
| FR-004 | Richtlinie, Einzelchecklisten, Sammelband und mitgeltende Dokumente abgleichen; Pflichten ausserhalb der CLs mit eigenen Quellverweisen erfassen. | Reconcile guideline, individual checklists, compendium, and related documents; record duties outside CL coverage with their own source references. |
| FR-005 | Je Punkt Anwendbarkeit, Umsetzungsstatus, Lernstufe (`Foundation`, `Intermediate`, `Advanced`), Begruendung, konkreten Evidenzpfad samt Fundstelle, Owner, Reviewer, Follow-up, erwarteten Nachweis, Zieltermin, Neubewertungs-Trigger und Restrisiko dokumentieren. Bei erledigter Folgearbeit darf der Zieltermin nur mit begruendetem `N/A` entfallen. | Record applicability, implementation status, learning stage (`Foundation`, `Intermediate`, `Advanced`), rationale, concrete evidence path and locator, owner, reviewer, follow-up, expected evidence, target date, re-evaluation trigger, and residual risk per item. Completed follow-up may omit a date only through a justified `N/A`. |
| FR-006 | `Applicable`, `N/A`, `Open` von `Fulfilled`, `Partly Fulfilled`, `Not Fulfilled`, `Not Assessed` trennen. `Open` auf der ersten Achse bedeutet nur ungeklärte Anwendbarkeit. `Applicable` ist kein Erfolg und bleibt bei fehlender Erfuellungsevidenz `Applicable` mit einem nicht erfuellten Umsetzungsstatus und Befund. `N/A` verlangt Grund und `Not Assessed`. | Separate `Applicable`, `N/A`, `Open` from `Fulfilled`, `Partly Fulfilled`, `Not Fulfilled`, `Not Assessed`. `Open` on the first axis means unresolved applicability only. `Applicable` is not success and remains `Applicable` when fulfilment evidence is missing, paired with a non-fulfilled implementation status and a finding. `N/A` requires rationale and `Not Assessed`. |
| FR-007 | C#-MSL-Status, sichere APIs, Eingaben, Fehlerbehandlung, Datei-I/O, Abhaengigkeiten und native Grenzen pruefen. | Review C# MSL status, secure APIs, input, errors, file I/O, dependencies, and native boundaries. |
| FR-008 | Installierte Presets mit der Achtermatrix und Preset-zu-CL-Mapping vergleichen; weitere Presets einbeziehen, Drift und alte Sechs-/Siebenerangaben klassifizieren. | Compare installed presets with the eight-preset matrix and preset-to-CL mapping; include extra presets, classify drift and old six/seven-preset statements. |
| FR-009 | Bestehende Sicherheits- und Feature-Nachweise auf Scope, Aktualitaet, Quelle und Widerspruch pruefen; Wiederverwendung und neue Verifikation unterscheiden. | Check existing security and feature evidence for scope, freshness, source, and contradictions; distinguish reuse from new verification. |
| FR-010 | Human-only-Kontrollen markieren. Keine formale Freigabe, Secret-Rotation, Providerfreigabe oder Branch-Protection-Aenderung durch Agenten ausfuehren oder behaupten. | Mark human-only controls. Agents must not perform or claim formal approval, secret rotation, provider approval, or branch-protection changes. |
| FR-011 | Priorisierte offene Haertungspunkte mit ID, Schweregrad, Quelle, Owner, konkreter Folgearbeit, Trigger und Restrisiko liefern; keine Haertung automatisch ausfuehren. | Deliver prioritized open hardening findings with ID, severity, source, owner, concrete follow-up, trigger, and residual risk; do not automatically harden the product. |
| FR-012 | Lernpolitik und barrierefreie bilinguale Nachweise erhalten; keine automatischen Noten, Zertifikate oder pauschalen Sicherheitsbehauptungen ableiten. | Preserve learner policy and accessible bilingual evidence; infer no automatic grades, certificates, or blanket security claims. |
| FR-013 | Akzeptanz und Lieferung mit stabilen Gates, aktuellem Commit-Bezug und ehrlicher Fehlerklassifikation belegen; Specify-Erfolg vom Laufabschluss trennen. | Evidence acceptance and delivery through stable gates, current commit binding, and honest failure classification; separate Specify success from run completion. |
| FR-014 | Geplante Nachweispfade als zukuenftig kennzeichnen. Feststellungen mit Datum, Scope und Fundstelle belegen; offene Quellen nicht als geprueft darstellen. | Label planned evidence paths as future evidence. Support conclusions with date, scope, and locator; do not present unresolved sources as reviewed. |

### Constitution-Anforderungen / Constitution Requirements

**DE:** Bindend sind `constitution.md` und `.specify/memory/constitution.md`,
insbesondere Prinzipien XI bis XVIII sowie die Registry-Zeile
`RiderProjects/TinyCalc`: .NET 10/C#, lokale Tabellenkalkulation mit Terminal.Gui,
Pascal-Verhaltensreferenzen, `MicroCalc.sln`, xUnit und TUI-Smoke. C# ist eine
erlaubte Memory-Safe Language (MSL: Sprache mit Schutz vor vielen
Speicherfehlern). Sichere APIs und native Abhaengigkeiten sind trotzdem zu
pruefen. Kein Runtime- oder Hardwarezwang erfordert einen Sprachwechsel.

**EN:** Binding sources are both constitutions, especially Principles XI
through XVIII and the `RiderProjects/TinyCalc` registry row: .NET 10/C#, local
spreadsheet with Terminal.Gui, Pascal behavior references, `MicroCalc.sln`,
xUnit, and TUI smoke. C# is an allowed memory-safe language (MSL: a language
that prevents many memory errors). Secure APIs and native dependencies still
require review. No runtime or hardware constraint requires a language change.

**DE:** Documentation Impact ist genau `UpdateRequired`. Zielgruppen sind
Projektverantwortliche, Reviewer, ausbildende Personen, Fachinformatik-Lernende
und Lernende beider IT-kaufmaennischen Berufe ab Lehrjahr 1 ohne Spec-Kit-Vorwissen.
Betroffen sind Anforderungs-, Sicherheits-, Governance- und Lernnachweise.
Kanonisch bleiben Intake und GSDB; Owner ist Projektverantwortlicher Thorsten
Hindermann mit fachlich zustaendigen Reviewern. Lesepfad: von
`docs/security/README.md` zur neuen GSDB-Evidenz, dann zur Quelle und Nacharbeit.
Ein Indexverweis ist im spaeteren Ergebnis erforderlich; diese Phase aendert
keine Navigation. Dokumentklasse: projektbezogener Pruefbericht und aktive
Feature-Anforderung; Verteilung: oeffentliches Repository nach Inhaltspruefung.
Sprachstrategie: Deutsch zuerst, vollstaendiger englischer Partnerblock im
selben Dokument, CEFR B2. Home-Sync ist `N/A`, da keine zentrale Regel geaendert
wird; Trigger ist eine solche Aenderung. Plattform-/Beispielbeleg: Textreview
auf macOS; Linux-/Windows-Aussagen brauchen eigene Belege. Nachweisort:
`docs/accessibility/gsdb-intensive-review.md` und die Feature-Evidenzmatrix.

**EN:** Documentation Impact is exactly `UpdateRequired`. Audiences include
project owners, reviewers, instructors, IT specialist apprentices, and both
IT management occupations from year one without prior Spec Kit knowledge.
Affected families are requirements, security, governance, and learning evidence.
The intake and GSDB remain canonical; project owner Thorsten Hindermann owns
the result with appropriate specialist reviewers. The reader path leads from
`docs/security/README.md` to GSDB evidence, sources, and follow-up. A later result
requires an index link; this phase changes no navigation. Document class:
project assessment and active feature requirement; distribution: public
repository after content review. Language strategy: German first and a complete
English partner block in the same document at CEFR B2. Home sync is `N/A` because
no central rule changes; such a change is the trigger. Platform/example proof:
macOS text review; Linux/Windows claims require separate evidence. Evidence:
`docs/accessibility/gsdb-intensive-review.md` and the feature matrix.

**DE:** Statistikfortschreibung ist fuer den spaeteren Feature-Abschluss
erforderlich, ausserhalb der zwei erlaubten Dateien dieser Phase.
`docs/project-statistics.md` und Konfiguration bleiben bindend: 80 und 125
Zeilen/Arbeitstag, 7,8 Stunden/Tag, sichtbares Git-Fenster, Produktions-/Test-/
Dokumentationszeilen und chronologisches Ledger. Gemeinsame Agentenregeln
werden nur geprueft. Spaeter genehmigte Aenderungen verlangen Abgleich beider
Constitutions, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`,
`.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md` und
betroffener Spec-Kit-Vorlagen/-Flaechen. Keine beabsichtigte Agentenabweichung;
keine konkreten Modellnamen in Feature-Artefakten.

**EN:** Statistics refresh is required for later feature completion, outside
this phase's two permitted files. The statistics ledger and configuration
remain binding: 80 and 125 lines/workday, 7.8 hours/day, visible Git window,
production/test/documentation counts, and chronological entries. Shared agent
rules are reviewed only. Later authorized changes require joint review of
both constitutions, `AGENTS.md`, `CLAUDE.md`, `GEMINI.md`,
`.github/copilot-instructions.md`, `.github/agents/copilot-instructions.md`, and
affected Spec Kit templates/surfaces. No intentional agent divergence and no
concrete model names in feature artifacts.

### Zentrale Entitaeten / Key Entities

- **Quellinventar / Source inventory:** Identitaet, Version, Pfad, Hash und
  Scope / identity, version, path, hash, and scope.
- **Pruefpunkt / Review item:** Stabile Quellen-ID, beide Statusachsen und
  FR-005-Felder / stable source ID, both status axes, and FR-005 fields.
- **Befund / Finding:** Nachweisluecke oder Widerspruch mit Schweregrad, Owner
  und Nacharbeit / evidence gap or contradiction with severity, owner, and follow-up.
- **Gate-Evidenz / Gate evidence:** Pruefschranke mit Scope, Befehl, Plattform,
  Ergebnis und Commit-Bezug / verification gate with scope, command, platform,
  outcome, and commit binding.

## Erfolgskriterien / Success Criteria

### Messbare Ergebnisse / Measurable Outcomes

| ID | Deutsch | English |
|---|---|---|
| SC-001 | 12 von 12 CLs und 100 Prozent verifizierter Quell-IDs bewertet; keine unerklaerte fehlende/doppelte Zuordnung. Richtlinie, Sammelband und alle mitgeltenden Dokumente sichtbar abgeglichen. | All 12 CLs and 100% of verified source IDs assessed; no unexplained missing/duplicate mapping. Guideline, compendium, and all related documents visibly reconciled. |
| SC-002 | Jede Bewertung enthaelt alle FR-005-Felder; jedes `N/A` hat Grund und Trigger, jede offene oder nicht erfuellte Bewertung hat Zieltermin und erwarteten Nachweis, und keine unbelegte Aussage gilt als `Fulfilled`. | Every assessment contains all FR-005 fields; every `N/A` has a reason and trigger, every open or non-fulfilled assessment has a target date and expected evidence, and no unsupported assertion is `Fulfilled`. |
| SC-003 | Alle Human-only-Punkte erkennbar; null unbelegte menschliche Freigaben, Sicherheits-, Rechts- oder Zertifizierungsbehauptungen. | All human-only items identifiable; zero unsupported human approvals or security, legal, or certification claims. |
| SC-004 | Jeder offene Befund zur Quelle und priorisierten Nacharbeit verfolgbar; alle acht Standard-Presets und weitere installierte Presets dispositioniert. | Every open finding traceable to its source and prioritized follow-up; all eight standard presets and extra installed presets dispositioned. |
| SC-005 | Textreview findet fuer jeden Befund in beiden Sprachen Status, Owner, Abhaengigkeiten und naechste Schritte ohne Farbe oder grafische Position. | Text review locates every finding's status, owner, dependencies, and next actions in both languages without color or graphical position. |
| SC-006 | Vor Lieferabschluss alle Pflicht-Gates am relevanten Stand belegt; null Providerverweigerungen, fehlende Reviews oder alte Checks als Pass gezaehlt. Merge und Sync getrennt belegt. | Before delivery completion all mandatory gates evidenced for the relevant state; no provider refusals, missing reviews, or stale checks counted as passes. Merge and sync evidenced separately. |

## Annahmen und Abhaengigkeiten / Assumptions

**DE:** Akzeptierte Eingaben und Hashes stehen im Laufzustand. Serienreview:
`Ready`; GSDB: eigenstaendiger `Eligible`-Root. Andere Pending-/Blocked-Intakes
bleiben ausserhalb dieses Features. Reihenfolge gemaess Intake: GSDB-Quellen,
MSL/Sprachregeln, Preset-Installation und Mapping, Projektnachweise, Ergebnis
und Nacharbeit. Preflight und Feature 004 sind Quellen, kein Ersatz fuer den
Intensivlauf. Baseline 3.2.0 und ihre 157 Punkte sind Ausgangswerte fuer einen
Vollabgleich; Drift wird dokumentiert. Die Spezifikation setzt keine
Produkt-Haertung, neue Tools oder neuen Pruef-Frameworks voraus.

**EN:** Accepted inputs and hashes are in the run state. Series review is
`Ready`; GSDB is an independent `Eligible` root. Other pending/blocked intakes
remain outside this feature. Intake order is GSDB sources, MSL/language rules,
preset installation/mapping, project evidence, results, and follow-up.
Preflight and Feature 004 are sources, not substitutes for this intensive run.
Baseline 3.2.0 and its 157 items are starting values for full reconciliation;
drift is documented. No product hardening, new tools, or new review frameworks
are assumed.

## Sicherheits- und Governance-Anwendbarkeit / Security and Governance Applicability

**DE:** Die Tabelle bestimmt Pruefumfang, nicht Erfuellung. `Open` bedeutet
ausschliesslich ausstehende Klaerung der Anwendbarkeit. Fehlende
Erfuellungsevidenz bei bekanntem Umfang erzeugt einen nicht erfuellten Status
und Befund. Alle genannten Pfade sind erwartete
Nachweisorte; vorhandene Dateien brauchen Neubewertung fuer Feature 005.
Owner aller Zeilen ist der Projektverantwortliche; Reviewer sind zustaendige
Security-, Architektur-, A11Y- oder Governance-Rollen. Eine unbesetzte Rolle
blockiert `Fulfilled`; sie macht die Anwendbarkeit nur dann `Open`, wenn diese
Rolle den Umfang klaeren muss. Bis zur Pruefung besteht als Restrisiko moegliche fehlende
Aktualitaet oder Abdeckung. Follow-up ist der zeilenbezogene Abgleich;
zusaetzliche Trigger sind neue Befunde und Scope-/Quellen-Drift. Diese Angaben
werden je Punkt konkretisiert und ersetzen keine menschliche Risikoakzeptanz.

**EN:** The table defines review scope, not fulfillment. `Open` means pending
applicability clarification only. Missing fulfilment evidence for known scope
creates a non-fulfilled status and finding. Paths are expected evidence locations; existing
files need reassessment for Feature 005. The project owner owns all rows;
reviewers are appropriate security, architecture, accessibility, or governance
roles. An unassigned role blocks `Fulfilled`; it makes applicability `Open`
only when that role must determine scope. Pending review, residual risk is possible
missing freshness or coverage. Follow-up is row-specific review; additional
triggers are new findings and scope/source drift. These fields become specific
per item and do not replace human risk acceptance.

| Thema / Topic | Status | Begruendung, Evidenz, Trigger / Rationale, evidence, trigger |
|---|---|---|
| NIST SSDF | Applicable | Sicheren Lebenszyklus mit Vorbereitung, Schutz, Erstellung und Reaktion pruefen / review secure lifecycle preparation, protection, production, and response. `docs/security/gsdb-intensive-review/evidence-matrix.md`, `docs/security/security-checklist.md`; Trigger: SDLC-Aenderung / lifecycle change. |
| CWE Top 25 | Applicable | Haeufige schwere Softwarefehler gegen Eingaben, Formeln, Datei-I/O und Fehlerpfade pruefen / assess severe common weaknesses against inputs, formulas, file I/O, and errors. `docs/security/security-checklist.md`, `docs/security/threat-model.md`; Trigger: Code oder neue Schwachstellenliste / code or new weakness list. |
| C# MSL / Secure Coding | Applicable | C# speichersicher; sichere APIs und native Grenzen getrennt pruefen / C# memory-safe; assess secure APIs and native boundaries separately. `docs/security/security-checklist.md`, `docs/security/dependency-audit.md`, Feature-Matrix / feature matrix; Trigger: unsafe/native Code oder Sprachwechsel / unsafe/native code or language change. |
| OWASP ASVS | N/A | Web-Verifikationsstandard: lokale TUI ohne Web/API/HTTP/Auth-Dienst; ASVS-Level N/A / web verification standard: local TUI without web/API/HTTP/auth service; ASVS level N/A. `docs/security/asvs-verification.md`; Trigger: solcher Dienst verlangt neue Level-/Scope-Entscheidung / such service requires a new level/scope decision. |
| SBOM | Applicable | Maschinenlesbares Komponentenverzeichnis fuer verteilbares Produkt pruefen / review machine-readable component inventory for distributable product. `docs/security/supply-chain-evidence.md`, `docs/security/sbom/`, `docs/security/dependency-audit.md`; Trigger: Paket-, Artefakt- oder Releasewechsel / package, artifact, or release change. |
| VEX | Open | Betroffenheit durch bekannte Schwachstellen; alter Null-Fund-Scan beweist keinen aktuellen Stand / vulnerability impact; old clean scan does not prove current state. `docs/security/dependency-audit.md`, `docs/security/supply-chain-evidence.md`; aktueller Scan entscheidet Applicable oder begruendetes N/A / current scan determines Applicable or justified N/A. Trigger: Advisory oder Graphwechsel / advisory or graph change. |
| SLSA / Provenance | Applicable | Herkunft und Build-Integritaet der CI-/Lieferartefakte pruefen; keinen unbelegten Level behaupten / review origin and build integrity of CI/delivery artifacts; claim no unsupported level. `docs/security/supply-chain-evidence.md`, Feature-Gate-Evidenz / feature gate evidence; Trigger: Builder/Workflow/Artefaktwechsel / builder/workflow/artifact change. |
| AI-SBOM | N/A | KI nur Entwicklungswerkzeug; keine Modelle, KI-Dienste, Trainings-/Embedding-Daten oder Inferenz im Produkt / AI development tooling only; no models, AI services, training/embedding data, or inference in product. `docs/security/supply-chain-evidence.md`; Trigger: KI-Produktkomponente aktiviert sieben G7/BSI-Evidenzcluster / AI product component activates seven G7/BSI evidence clusters. |
| STRIDE / CIA / CAPEC | Applicable | Bedrohungsarten, Vertraulichkeit/Integritaet/Verfuegbarkeit und Angriffsmuster wichtiger Grenzen pruefen / assess threat categories, confidentiality/integrity/availability, and attack patterns at important boundaries. `docs/security/threat-model.md`, `docs/security/security-quality-scenarios.md`; Trigger: Datenfluss oder Angriffspfad / data flow or attack path change. |
| Zero Trust | N/A Produkt / product; Applicable Lieferumgebung / delivery environment | Lokales Einprozessprodukt ohne verteilte Identitaet; Remote-Repo/CI-Zugriff ist eine bestehende Identitaets- und Providergrenze / local single-process product without distributed identity; repository/CI access is an existing identity and provider boundary. `docs/security/zero-trust-applicability.md`; Trigger: Netzwerk-/Cloud-/Identitaets-/Remotegrenze / network/cloud/identity/remote boundary. |
| OWASP SAMM | Applicable | Sicherheitsreife und Verbesserungen fuer langlebiges Projekt / security maturity and improvements for long-lived project. `docs/security/samm-assessment.md`; Trigger: periodischer Review, Audit, Vorfall / periodic review, audit, incident. |
| OWASP Cheat Sheet Series / Proactive Controls | Applicable | Praktische Zusatzregeln zu Eingaben, APIs und Fehlern / practical supporting rules for inputs, APIs, and errors. `docs/security/security-checklist.md`; Trigger: Code-/Frameworkwechsel / code/framework change. |
| OpenSSF Scorecard | Applicable | OSS und wichtige Abhaengigkeiten pruefen; keinen Score erfinden / review OSS and important dependencies; invent no score. `docs/security/dependency-audit.md`, `docs/security/supply-chain-evidence.md`; Trigger: Release oder Abhaengigkeit / release or dependency change. |
| BSI C3A / BSI C5 | Open | Cloud-Autonomie und Cloud-Assurance fuer Repo-/CI-/Artefaktprovider pruefen; lokale Runtime begruendet kein Toolchain-N/A / assess cloud autonomy and assurance for repository/CI/artifact providers; local runtime does not justify toolchain N/A. `docs/security/cloud-autonomy-applicability.md`, `docs/security/cloud-compliance-assurance.md`; Trigger: Provider/Hostingwechsel / provider/hosting change. |
| NIS2 / CRA / EU AI Act / DORA | Open, einzeln / individually | Regulatorischen Scope belegen; kein Rechtsurteil allein aus Ausbildungszweck / evidence regulatory scope; no legal conclusion from training purpose alone. `docs/security/regulatory-applicability.md`, CL-07 in Feature-Matrix / CL-07 in feature matrix; Trigger: Marktbereitstellung, Kundenlieferung, regulierter Sektor, Cloudbetrieb, KI-Runtime / market placement, customer delivery, regulated sector, cloud operation, AI runtime. |
| Datenschutz / Privacy, CL-11 | Open | Datenarten und moegliche Datenschutz-Folgenabschaetzung pruefen; keine echten personenbezogenen oder geheimen Daten in Belegen / assess data classes and possible privacy impact assessment; no real personal or secret data in evidence. `docs/security/regulatory-applicability.md`, `docs/security/threat-model.md`, Feature-Matrix / feature matrix; Trigger: neue personenbezogene Flows / new personal data flows. |
| WCAG 2.2 AA | Applicable | Barrierefreiheit betroffener Texte und anwendbarer HTML-Flaechen / accessibility of affected text and applicable HTML surfaces. `docs/accessibility/gsdb-intensive-review.md`; Trigger: Text-/Navigations-/Render-/UI-Aenderung / text/navigation/render/UI change. |

**DE:** Jede regulatorische Regel braucht eine eigene Entscheidung mit Scope,
aktueller primaerer Quelle, Pruefdatum, Owner, Reviewer, Restrisiko und Trigger.
Spaeteres `N/A` kann auf belegtem privaten Ausbildungsbetrieb ohne regulierten
Scope beruhen; Ausbildung allein genuegt nicht. Rechtliche Freigaben bleiben
Human-only. Diese Phase trifft keine rechtliche Anwendbarkeitsentscheidung.
VEX darf bekannte verwundbare ausgelieferte Komponenten nicht als Freigabe
umdeuten. Aktuelle Lieferblocker bleiben bestehen; keine Haertung ausfuehren.

**EN:** Each regulation needs its own decision with scope, current primary
source, review date, owner, reviewer, residual risk, and trigger. Later `N/A`
may rely on evidenced private training use without regulated scope; training
alone is insufficient. Legal approval remains human-only. This phase makes no
legal applicability determination. VEX must not reinterpret known vulnerable
shipped components as approved. Current delivery blockers remain; do not harden.

## Checklisten- und Preset-Abdeckung / Checklist and Preset Coverage

**DE:** Alle Bereiche unten werden geprueft, auch wenn einzelne Kontrollen
spaeter begruendet `N/A` sind. Neue gemeinsame Evidenz ist unter
`docs/security/gsdb-intensive-review/` vorgesehen: `source-inventory.md`,
`evidence-matrix.md`, `preset-mapping.md`, `open-findings.md`. Diese geplanten
Dateien sind keine bereits abgeschlossenen Nachweise.

**EN:** All areas below are reviewed, even if individual controls later have
justified `N/A` decisions. Common new evidence is expected under
`docs/security/gsdb-intensive-review/`: `source-inventory.md`,
`evidence-matrix.md`, `preset-mapping.md`, `open-findings.md`. These planned
files are not already completed evidence.

| CL | Bereich / Area | Zusaetzliche Nachweisquelle / Additional evidence source |
|---|---|---|
| CL-01 | Standards-Anwendbarkeit / Standards applicability | Constitution; `docs/security/regulatory-applicability.md` |
| CL-02 | Sichere Architektur / Secure architecture | `docs/security/arc42-security.md`; `docs/architecture/` |
| CL-03 | Krypto-Mindestvorgaben / Cryptographic minimum rules | `docs/security/security-checklist.md`; `docs/security/adr/` |
| CL-04 | Bedrohungsmodellierung / Threat modeling | `docs/security/threat-model.md`; `docs/security/security-quality-scenarios.md` |
| CL-05 | Lieferkette und Build-Integritaet / Supply chain and build integrity | `docs/security/supply-chain-evidence.md`; `docs/security/dependency-audit.md` |
| CL-06 | Schwachstellenoffenlegung / Vulnerability disclosure | `docs/security/samm-assessment.md`; Melde-/Owner-Befunde in Feature-Matrix / disclosure/owner findings in feature matrix |
| CL-07 | CRA-Anwendbarkeit / CRA applicability | `docs/security/regulatory-applicability.md` |
| CL-08 | Sicherheits-Code-Review / Security code review | `docs/security/security-checklist.md`; `src/`; `tests/` |
| CL-09 | KI-Codeerzeugung / AI code generation | Agentenregeln, Reviews / agent rules, reviews; `docs/security/supply-chain-evidence.md` |
| CL-10 | Sichere Entwicklungsumgebung / Secure development environment | `.github/workflows/`; Umgebungs-/Berechtigungsevidenz in Feature-Matrix / environment/permission evidence in feature matrix |
| CL-11 | Datenschutz-Folgenabschaetzung / Privacy impact assessment | `docs/security/regulatory-applicability.md`; `docs/security/threat-model.md` |
| CL-12 | Agentische KI-Sandbox / Agentic AI sandbox | Laufzustand und freigegebene Mount-/Netzwerk-/Werkzeuggrenzen in Feature-Matrix / run state and authorized mount/network/tool boundaries in feature matrix |

**DE:** Standardmatrix (Version/Prioritaet): `security-governance` v0.6.2/10,
`architecture-governance` v0.5.2/20, `isaqb-architecture-governance` v0.2.2/30,
`a11y-governance` v0.4.3/40, `cross-platform-governance` v0.2.2/50,
`agent-parity-governance` v0.4.2/60, `autonomous-run-governance` v0.4.1/70,
`parallel-autonomous-run-governance` v0.2.6/80. Die Installation aller acht
ist Pruefgegenstand. Inhaltlich gelten Security, Architektur, A11Y, Paritaet
und autonome Evidenz; Cross-Platform betrifft vorhandene Tools. Parallele
Kampagne: `N/A`, weil nur ein Feature beauftragt ist; Trigger ist eine neue
ausdrueckliche Kampagnenbeauftragung. Weitere installierte Intake-, Routing-
und Secure-Development-Assurance-Presets sind zu inventarisieren und auf ihre
Checkpoints abzubilden. Installation erteilt keine Ausfuehrungsrechte.

**EN:** The eight version/priority pairs above form the binding standard matrix.
Installation of all eight is reviewed. Security, architecture, accessibility,
parity, and autonomous evidence apply; cross-platform review covers existing
tools. Parallel campaign: `N/A`, since only one feature is commissioned; a new
explicit campaign delegation is the trigger. Additional installed intake,
routing, and secure-development-assurance presets must be inventoried and
mapped to their checkpoints. Installation grants no execution authority.

## Architektur, Lernpolitik und Pruefgrenzen / Architecture, Learner Policy, and Verification Boundaries

**DE:** Keine Produktarchitektur, Schnittstelle, Runtime oder Topologie wird
geaendert. Pruefgegenstand sind bestehende Grenzen: Dateiinhalt zur Formel- und
Tabellenverarbeitung, verwalteter Code zu nativen Bibliotheken, Repository zu
Build/Abhaengigkeiten sowie Agent zu Dateisystem, Netzwerk und Provider.
Oeffentliche Quellen, interne Metadaten und vertrauliche Nutzerdaten/Secrets
sind zu unterscheiden. Geheimnisse duerfen nicht in oeffentliche Evidenz gelangen.
Qualitaetsziele, technische Schulden und Sicherheits-Querschnittskonzepte
werden anhand `docs/architecture/`, `docs/security/arc42-security.md` und
`docs/security/security-quality-scenarios.md` bewertet. Neue ADRs (begruendete
Architekturentscheidungen) und S-ADRs sind `N/A`, solange nur bewertet wird;
Trigger ist eine spaeter autorisierte Architekturentscheidung. Luecken kommen
in Matrix und Nacharbeit, nicht in ungefragte Umsetzung.

**EN:** No product architecture, interface, runtime, or topology changes.
Review covers existing boundaries: file content into formulas/spreadsheets,
managed code into native libraries, repository into build/dependencies, and
agent into filesystem/network/provider access. Distinguish public sources,
internal metadata, and confidential user data/secrets. Secrets must not enter
public evidence. Assess quality goals, technical debt, and cross-cutting
security through `docs/architecture/`, `docs/security/arc42-security.md`, and
`docs/security/security-quality-scenarios.md`. New ADRs (reasoned architecture
decisions) and security ADRs are `N/A` while only assessing; later authorized
architecture decisions are the trigger. Gaps enter the matrix and follow-up,
not unrequested implementation.

**DE:** Bindender Lernpfad:
`docs/secure-development/Lernpfad_Sichere-Entwicklung_Lehrjahr-1-bis-3.md`.
Sicherheit ab Tag 1; erst verstehen, dann pruefen, dann dokumentieren.
Anwendbarkeit folgt dem Projekt, nicht der Lernstufe. Eine ausbildende,
projekt- oder sicherheitsverantwortliche Person entscheidet fortgeschrittene
Fragen. Lernaufgaben erzeugen einen kleinen nachvollziehbaren Beleg;
Checklistenstatus erzeugt keine Note oder Zertifizierung. Neue Texte erklaeren
Fachwoerter beim ersten Gebrauch oder verlinken die Lernfassung. Status,
Abhaengigkeiten und naechste Schritte stehen vollstaendig in Text. Keine neue
Produktfunktion oder breitere TUI-Abnahme wird begonnen.

**EN:** The learning path above is binding: security from day one; understand,
then review, then document. Applicability follows the project, not learner
level. Instructors, project owners, or security owners decide advanced issues.
Learning tasks produce a small traceable record; checklist status creates no
grade or certification. New text explains terms on first use or links to the
learning version. Status, dependencies, and next steps remain complete in text.
No new product function or broader TUI acceptance feature starts.

**DE:** A11Y prueft Markdown-Struktur, Lesereihenfolge, Linktexte, korrekte
deutsche Orthografie ohne ASCII-Umlautersatz und Sprachparitaet; WCAG 2.2 AA
soweit anwendbar, besonders 1.3.1, 1.3.2, 1.4.1 und 2.4.6. `docfx.json` nimmt
alle geaenderten `docs/**/*.md` auf. Deshalb sind DocFX-Regeneration sowie der
textorientierte A11Y-Smoke mit lynx fuer dieses Feature `Applicable`.
Playwright/axe ist der bevorzugte Zusatz, wenn das gepruefte Harness vorhanden
ist; seine Nichtverfuegbarkeit wird sichtbar dokumentiert. Die Pruefung umfasst
Sprache/Sprachwechsel (3.1.1/3.1.2), Tastatur
(2.1.1), Sprungnavigation (2.4.1), sichtbarem/unverdecktem Fokus
(2.4.7/2.4.11), Kontrast (1.4.3/1.4.11) und semantischen Landmarks. Textreview
und Werkzeug-Smoke sind kein behaupteter Screenreader-Nutzertest oder globale
WCAG-Zertifizierung. Bilder, Diagramme und neue Codebeispiele sind hier `N/A`;
spaetere Ergaenzung verlangt Alt-Text, Textalternative oder Sprach-Tag.

**EN:** Accessibility review covers Markdown structure, reading order, link
text, correct German orthography without ASCII umlaut substitutions, and
language parity; WCAG 2.2 AA applies where relevant. Because `docfx.json`
includes every changed `docs/**/*.md`, DocFX regeneration plus a lynx
text-oriented accessibility smoke are `Applicable` for this feature.
Playwright/axe is the preferred addition when the reviewed harness is
available; its absence is recorded explicitly. The HTML review covers language
and language changes (3.1.1/3.1.2), keyboard
(2.1.1), bypass navigation (2.4.1), visible and unobscured focus
(2.4.7/2.4.11), contrast (1.4.3/1.4.11), and semantic landmarks. Text review
and tool smoke are not a claimed screen-reader user test or blanket WCAG
certification. Images, diagrams, and new code examples are `N/A` here; adding
them requires alt text, text alternatives, or language tags.

**DE:** Der neue read-only Matrixvalidator mit PowerShell-Einstieg, strengem
Bash-Wrapper, man-Page, bilingualer PowerShell-Hilfe und eigener
Paritaetscheckliste ist `Applicable`. Beide Varianten muessen auf den
deklarierten Plattformen dieselben Status-, Fehler- und Exitcode-Semantiken
liefern. `-WhatIf`/Dry-run ist fuer diesen ausschliesslich lesenden Validator
`N/A`; Trigger ist jede spaetere Mutation. TDD und Changed-Code-Coverage sind
fuer Produktcode `N/A`; die neuen JSON-/Hash-Validatoren brauchen dennoch
beobachtbares RED/GREEN und Regression. Spaeter genehmigter Produktcode verlangt
beobachtbares Rot/Gruen/Regression, 70 Prozent Mindest-Coverage und 80 Prozent
Ziel. Neue XML-API-Dokumentation und Warum-Kommentare sind hier `N/A`, da keine
Signatur/Logik geaendert wird. Solche Aenderungen verlangen vollstaendige XML-
Kommentare, keine globale CS1591-Unterdrueckung, moderate bilinguale
Warum-Kommentare und bei API-/XML-Aenderung DocFX samt A11Y-Smoke.

**EN:** The new read-only matrix validator with a PowerShell entrypoint, strict
Bash wrapper, man page, bilingual PowerShell help, and dedicated parity
checklist is `Applicable`. Both variants must provide identical status, error,
and exit-code semantics on the declared platforms. `-WhatIf`/dry-run is `N/A`
for this read-only validator; any later mutation is the trigger. Product-code
TDD and changed-code coverage are `N/A`, but the new JSON/hash validator still
requires observable RED/GREEN and regression. Later authorized product
code requires observable red/green/regression, 70% minimum coverage, and an
80% target. New XML API documentation and why-comments are `N/A` here because
no signature/logic changes. Such changes require complete XML comments, no
global CS1591 suppression, moderate bilingual why-comments, and DocFX plus
accessibility smoke for API/XML changes.

## Laufgrenzen und Liefernachweise / Run Boundaries and Delivery Evidence

**DE:** Akzeptierter Laufzustand und `autonomous-run-evidence.md` dokumentieren
`MergeAndSync` samt Autoritaetsquelle. Der kopierbare autonome Intake-Prompt
bleibt eine `LocalImplementation`-Alternative, nicht die Autorisierung dieses
bereits manuell gestarteten Laufs. Der aktuelle Plan-Review-Auftrag begrenzt
Schreibzugriffe auf die benannten Planungsartefakte, diese Plan-Review-
Checkliste und das strukturierte Runner-Ergebnis. Keine Implementierung,
Commits, Pushes, PR-Erstellung, Merges, Intake-Umbenennung oder neuen Features.

**EN:** Accepted run state and `autonomous-run-evidence.md` record `MergeAndSync`
and its authority source. The copy-ready autonomous intake prompt remains a
`LocalImplementation` alternative, not authority for this already manually
started run. The current plan-review instruction limits writes to the named
planning artefacts, this plan-review checklist, and the structured runner
result. No implementation, commits, pushes, PR creation, merges, intake
renaming, or new features are allowed.

**DE:** Spaetere Lieferaktionen brauchen gueltige aktuelle Autoritaet. Der
dokumentierte Admin-Bypass gilt hoechstens fuer eine verbleibende formale
Merge-Regel nach allen materiellen technischen, Security-, A11Y-, Governance-,
Evidenz- und Review-Gates. Er ersetzt keine menschliche Fachfreigabe und
erlaubt weder Branch-Protection-Aenderung noch Providerfreigabe. Offene
Haertungsbefunde sind von unvollstaendigen Pruef-Gates zu trennen: Ein
vollstaendiger Bericht darf begruendete offene Produktkontrollen enthalten;
fehlende Pruefabdeckung oder Pflicht-Liefer-Gates blockieren den Abschluss.

**EN:** Later delivery actions need valid current authority. The recorded
admin bypass applies at most to a remaining formal merge rule after all
material technical, security, accessibility, governance, evidence, and review
gates pass. It replaces no human specialist approval and grants no branch-
protection change or provider approval. Separate open hardening findings from
unfinished review gates: a complete report may include reasoned open product
controls; missing review coverage or mandatory delivery gates block completion.

**DE:** Die Gates unten bestimmen den erforderlichen Nachweisumfang fuer
spaetere Phasen; sie sind keine ausgefuehrten Ergebnisse. Maschinenlesbare
Gate-Anforderungen stehen unter
`specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json`
stehen. Jeder Gate braucht Status, Scope, Befehls-Tokens, Runner-/Plattform-
Tokens, Begruendung und Trigger. Neue Delivery-Set- und Gate-Evidenzentscheidungen
nutzen Schema 2.0; Phasenergebnisse behalten Schema 1.0. Historische
Schema-1.0-Liefernachweise sind keine aktuelle Freigabe.

**EN:** The gates below define required evidence for later phases; they are
not executed results. The machine-readable requirements are at
`specs/005-gsdb-intensive-review/contracts/autonomous-run-gate-requirements.json`.
Each gate needs applicability, scope, command tokens, runner/platform tokens,
rationale, and trigger. New delivery-set and gate-evidence decisions use
schema 2.0; phase results retain schema 1.0. Historical schema-1.0 delivery
evidence is not current approval.

| Gate-ID | Status | Scope und Nachweis / Scope and evidence |
|---|---|---|
| GSDB-SPEC | Applicable | Spezifikation mit Intake-/Governance-Abgleich; `validate-autonomous-phase-result.ps1`, Phase `specify`, Payload-Hash / specification with intake/governance review, phase-result validation, and payload hash. |
| GSDB-COVERAGE | Applicable | Vollstaendige Quellen-/CL-Abdeckung, zwei Statusachsen, Human-only und Nacharbeit; konkrete Pruefbefehle spaeter binden / complete source/CL coverage, both status axes, human-only and follow-up; bind concrete validation commands later. |
| GSDB-SECURITY | Applicable | Obige Dispositionen, aktuelle Evidenz, Reviewer, Restrisiken; Scan-/Reviewbefehle dem Scope zuordnen / dispositions above, current evidence, reviewers, residual risks; map scan/review commands to scope. |
| GSDB-A11Y | Applicable | DE/EN- und Textreview; bei DocFX Render-/Text-Smoke; tatsaechliche Befehle und Plattform belegen / DE/EN and text review; rendered/text smoke for DocFX; evidence actual commands and platform. |
| GSDB-REGRESSION | Applicable | Restore, Release-Build, vollständige xUnit-Tests und exaktes `SMOKE_OK` sind trotz dokumentationszentriertem Scope Pflicht; Produkt-Coverage bleibt nur ohne `src/`-Delta `N/A` / restore, Release build, full xUnit tests, and exact `SMOKE_OK` are mandatory despite documentation-centred scope; product coverage remains `N/A` only without a `src/` delta. |
| GSDB-PREMERGE | Applicable | Exakter PR-Head, aktueller Review, Pflichtchecks mit Workflow/Job/Runner/Plattform/Befehl, Delivery-Set-Validierung und frische temporaere PreMerge-Evidenz / exact PR head, current review, required checks mapped to workflow/job/runner/platform/command, delivery-set validation, fresh temporary PreMerge evidence. |
| GSDB-MERGE-SYNC | Applicable | Merge-Commit, Remote-Standardbranch und lokaler Sync getrennt; PostMerge an PreMerge-Hash binden, deklarierte idempotente Nachaktionen und Abschlussvalidierung / separate merge commit, remote default branch, local sync; bind PostMerge to PreMerge hash, declared idempotent post-actions and final validation. |

**DE:** Fuer `GSDB-REGRESSION`: Owner Laufverantwortlicher, Follow-up verbindliche
Gate-Zuordnung vor Implementierung/Lieferung, Trigger akzeptierter Plan und
Diff-/Workflow-Aenderung, Restrisiko unerkannte Regression. Reine Textdateien
rechtfertigen keine pauschale Ausnahme fuer konsumierende Validatoren.
Versionsanhebungsregeln gelten bei spaeteren Build-/Testlaeufen. Gruene
Jobnamen ersetzen keine Befehlsnachweise. Spaetere Pruefbefehle fuer
Delivery-Set und Pre-/PostMerge muessen die vorhandenen
`validate-autonomous-delivery-set.ps1` und
`validate-autonomous-gate-evidence.ps1` einbeziehen.

**EN:** For `GSDB-REGRESSION`: owner is the run owner; follow-up is binding gate
mapping before implementation/delivery; triggers are the accepted plan and
diff/workflow changes; residual risk is undetected regression. Textual files
do not justify blanket exemptions for consuming validators. Version increment
rules apply to later builds/tests. Green job names do not replace command
evidence. Later delivery-set and Pre/PostMerge checks must include existing
`validate-autonomous-delivery-set.ps1` and
`validate-autonomous-gate-evidence.ps1` validators.

**DE:** Zustand: `specs/005-gsdb-intensive-review/autonomous-run-state.json`;
lesbare Evidenz: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`.
Temporaere PreMerge-/PostMerge-/Delivery-Set-Nachweise gehoeren unter
`.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/`.
Ein kausaler Abschluss kann noetig sein, weil Merge-/Sync-Belege erst nach dem
Merge entstehen; sie sind keine vorherige Pruefung desselben Commits.
Mutable externe Validierungstokens sind nicht deklariert: `N/A`; spaetere
Provideranforderungen loesen dokumentierte Neubewertung aus.

**EN:** State: `specs/005-gsdb-intensive-review/autonomous-run-state.json`;
readable evidence: `specs/005-gsdb-intensive-review/autonomous-run-evidence.md`.
Temporary PreMerge/PostMerge/delivery-set evidence belongs under
`.specify/runtime/autonomous-routing/69674c80-911c-40ff-9a0e-004f7b13b832/`.
Causal closeout may be necessary because merge/sync proof exists only after
merging; it is not a prior check of that same commit. Mutable external
validation tokens are not declared: `N/A`; later provider requirements trigger
documented reassessment.

**DE:** Bewusster Stop wird am sicheren Grenzpunkt `PausedByUser` und verlangt
ausdrueckliches Resume. Nach unerwarteter Unterbrechung sind Autoritaet,
Branch/Head, akzeptierte Hashes, Drift und Evidenz erneut zu pruefen.
Fehlende Rechte, gescheiterte materielle Gates oder Scope-Konflikte blockieren.
Retrospektiven duerfen portable Lernpunkte und Folgearbeit benennen, aber
keinen neuen Intake, keine Haertung oder Kampagne automatisch starten.

**EN:** A deliberate stop becomes `PausedByUser` at a safe boundary and requires
explicit resume. After unexpected interruption, revalidate authority,
branch/head, accepted hashes, drift, and evidence. Missing authority, failed
material gates, or scope conflicts block progress. Retrospectives may name
portable learning and follow-up but must not automatically start a new intake,
hardening effort, or campaign.

## Specify-Pruefvermerk / Specify Review Record

**DE:** Gegen bindenden Intake, akzeptierte Serien-/Laufinformationen, lokale
Vorlage und Governance-Addenda geprueft. FR-001 bis FR-014, vier priorisierte
Nutzerszenarien, Grenzfaelle und SC-001 bis SC-006 decken Scope, Nicht-Ziele,
Quellen, Statusmodell, Human-only, Lernpolitik und Liefernachweise ab. Alle
Pflichtabschnitte sind ausgefuellt; keine wesentliche Anforderungsklaerung
verbleibt. Offene Bewertungen oben sind explizite Auftraege der spaeteren
Pruefung. Textreview bestaetigt DE/EN-Bloecke, benannte Tabellen und textuelle
Status-/Folgeangaben; kein praktischer Assistenztechnik-Test wird behauptet.
Die separate Requirements-Checkliste ist abgeschlossen; diese Plan-Review-
Phase prueft nun Plan und Sidecars. Noch keine `tasks.md`: Das Specify-Ergebnis verwendet null erwartete und null
abgeschlossene Implementierungsaufgaben. `Completed` gilt nur fuer Specify
und ist an den normalisierten Hash dieser Spezifikation gebunden.

**EN:** Reviewed against the binding intake, accepted series/run information,
local template, and governance addenda. FR-001 through FR-014, four prioritized
user scenarios, edge cases, and SC-001 through SC-006 cover scope, non-goals,
sources, status semantics, human-only boundaries, learner policy, and delivery
evidence. All required sections are filled; no material requirements
clarification remains. Open assessments above are explicit duties for later
review. Text review confirms DE/EN blocks, named tables, and textual status/
follow-up; no practical assistive-technology test is claimed. The separate
requirements checklist is complete; this plan-review phase now reviews the
plan and sidecars. No
`tasks.md` exists yet: Specify uses zero expected and zero completed
implementation tasks. `Completed` applies only to Specify and is bound to
this specification's normalized hash.
