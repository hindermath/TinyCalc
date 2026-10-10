# Anforderungscheckliste: TUI-Funktionsvertrag / Requirements Checklist: TUI Functional Contract

**Zweck / Purpose:** Vollständigkeit, Klarheit, Konsistenz und Prüfbarkeit der Anforderungen vor Aufgabenplanung und Freigabe beurteilen. / Assess requirement completeness, clarity, consistency and measurability before task planning and approval.
**Erstellt / Created:** 2026-10-07
**Kästchenstand / Checkbox status:** 2026-10-10: Auf Thorstens Auftrag an die dokumentierten 36 Pass-Ergebnisse vom 2026-10-08 angeglichen. Historische Reviewnotizen bleiben erhalten; es wurde keine Produktabnahme vorweggenommen. / Aligned with the recorded 36 passing requirement-quality results on the owner's instruction; historical notes remain, without claiming product acceptance.
**Feature:** [spec.md](../spec.md)
**Kontext / Context:** [plan.md](../plan.md), [Datenmodell / data model](../data-model.md), [Schnittstellen / interfaces](../contracts/README.md), [verbindliches Intake / binding intake](../../../requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md).
**Tiefe / Depth:** Standard, risikoorientiert und über den gesamten verbindlichen Umfang. / Standard, risk-focused, across the complete binding scope.
**Anwendende / Audience:** Autor und unabhängiger Reviewer vor Tasks beziehungsweise Planfreigabe. / Author and independent reviewer before tasks or plan approval.

Diese durch `speckit-checklist` erzeugte Liste prüft die geschriebenen Anforderungen, nicht die Produktfunktion. Durchführungshinweise beschreiben einen Dokumentenreview, keine Befehle zur Produktabnahme. Ein Gate ist eine verpflichtende Prüfschranke; Evidenz ist ein prüfbarer Nachweis. Jeder Punkt bleibt zunächst offen: Erzeugung der Liste bedeutet nicht, dass der Review schon erfolgt ist.

*This generated checklist reviews written requirements, not implementation behaviour. Each procedure note guides document review, not product acceptance. A gate is a mandatory checkpoint and evidence is verifiable proof. Items start unchecked; generation does not constitute review.*

Für jeden Punkt Fundstelle, Datum, Reviewer und Ergebnis dokumentieren. Nur abhaken, wenn die Frage anhand eindeutiger Anforderungen beantwortet ist. Bei Lücke oder Konflikt das Kästchen offen lassen und Befund, Owner und Klärungsbedarf ergänzen. `N/A` braucht Grund und Wiederprüfungstrigger; zukünftige Produktnachweise bleiben davon getrennt. Bestehende Specify-/Plan-Checklisten werden nicht ersetzt.

*Record source, date, reviewer and outcome per item. Check it only when clear requirements answer the question. Keep gaps open with finding and owner; justify N/A with a trigger. Preserve earlier checklists and separate future product proof.*

## Anforderungsvollständigkeit / Requirement completeness

- [x] CHK001 Ist die vollständige Vereinigungsmenge der vier Angebotsquellen verbindlich beschrieben, ohne dass Discovery den Umfang verkleinern darf? / Is the full union of the four offered surfaces binding without scope reduction? [Completeness, Spec §Umfang, FR-002, FR-015]
  - Durchführungshinweis: Intake und Spec nebeneinander lesen; TUI, README, Laufzeithilfe und migrierte Hilfe sowie die additive Discovery-Regel markieren. Fehlende Quelle oder einschränkende Formulierung als Befund erfassen. / Procedure: Compare intake and spec; identify all four surfaces and additive discovery. Record missing or restrictive wording.

- [x] CHK002 Sind alle 17 Baseline-Familien mit gleicher Bedeutung in Spec und geplantem Vertrag enthalten? / Are all seventeen baseline families preserved with matching meaning? [Completeness, Spec §Baseline, FR-005, FR-015]
  - Durchführungshinweis: Die Familienzeilen im Intake, in der Spec und unter Contracts C-01 eins zu eins zuordnen; je Zeile den vollständigen Inhalt statt nur den Namen vergleichen. Keine Familie als optional behandeln. / Procedure: Map every family across the three documents and compare full content, not names alone.

- [x] CHK003 Sind alle Navigationsaliase, beide Befehlsoberflächen und sämtliche Hilfewege als einzelne Prüfpflichten definiert? / Are all aliases, command surfaces and help routes individually required? [Coverage, Spec §Baseline, FR-003, FR-005]
  - Durchführungshinweis: Die geschriebenen Tastenlisten, neun Befehle über Menü und Palette sowie P/N, Buttons und Schließen-Wege abgleichen. Eine Sammelbezeichnung ohne Pflicht je angebotenem Weg als Lücke notieren. / Procedure: Compare explicit key, command and help lists; flag grouping that loses individual obligations.

- [x] CHK004 Sind alle zehn Legacy- und sechs erweiterten Funktionen einschließlich echter Zellbearbeitung im Anforderungsumfang enthalten? / Are all sixteen functions required through actual cell editing? [Completeness, Spec §FUNC-LEGACY/FUNC-EXT, FR-007]
  - Durchführungshinweis: Die Funktionsnamen im Intake und in der Spec zuordnen und die Editorpflicht lesen. Eine Formulierung, die allein Evaluator-Unit-Tests genügen lässt, als Konflikt erfassen. / Procedure: Map function names and editor obligations; flag any acceptance based only on evaluator tests.

- [x] CHK005 Sind Nicht-Ziele und die Reihenfolge Migration → Funktionsabnahme → A11Y → Rename unverändert und eindeutig begrenzt? / Are non-goals and intake ordering preserved? [Consistency, Spec §Nicht-Ziele, §Annahmen und Abhängigkeiten]
  - Durchführungshinweis: Nicht-Zielliste und Vorgänger-/Nachfolgertext mit dem Intake vergleichen. Eigene impactbedingte A11Y-Pflichten von einer Freigabe des A11Y-Folgefeatures unterscheiden. / Procedure: Compare exclusions and order; separate current impact obligations from starting the next feature.

## Klarheit und Begriffspräzision / Clarity and precision

- [x] CHK006 Sind stabile Vertrags-ID, Pfad, aktive Pflicht-ID und Alias so definiert, dass ihre Zuordnung nicht beliebig ist? / Are identities and path obligations defined unambiguously? [Clarity, Spec FR-001, §Schlüsselobjekte]
  - Durchführungshinweis: Definitionen und Datenmodell vergleichen; festhalten, welche Angaben eine Capability und ein Pfad benötigen und wie mehrere Aliase derselben ID ihre einzelnen Pflichten behalten. / Procedure: Compare definitions and model; identify mandatory identity and per-alias fields.

- [x] CHK007 Ist die akzeptierte Klärung eindeutig: Automation für alle automatisierbaren Funktionen, menschliche Nachweise nur ergänzend? / Is the accepted automation clarification unambiguous? [Clarity, Spec §Clarifications, FR-003, SC-001]
  - Durchführungshinweis: Klärungsantwort, FR-003, SC-001 und Nachweisdefinition in beiden Sprachen vergleichen. Jede Formulierung, die manuellen Ersatz erlaubt, als Widerspruch markieren. / Procedure: Compare the answer and normative sections in both languages; flag manual substitution.

- [x] CHK008 Sind substantielle Angebote von eindeutigen Tipp-, Syntax- und Rasterfehlern anhand nachvollziehbarer Kriterien getrennt? / Are substantive offers distinguished from clear documentation defects? [Clarity, Spec FR-014, FR-016]
  - Durchführungshinweis: Konfliktregel und COUNT-/Rasterbeispiele lesen; prüfen, ob unklare Fälle offen bleiben und inhaltliche Entfernung ausdrücklich genehmigt werden muss. / Procedure: Review classification rules and examples; require unresolved cases to remain open and removal to need authority.

- [x] CHK009 Sind gleicher Commit, Vertragsrevision, Quellfrische und ergänzende Evidence-only-Änderungen widerspruchsfrei definiert? / Are revision and freshness requirements consistent? [Clarity, Spec CR-014, SC-002, SC-003]
  - Durchführungshinweis: Spec, Datenmodell und Contracts C-03 auf finale Bindung und lokale Zwischenstände abgleichen. Eine alte oder gemischte Quelle darf textlich keine Gesamtfreigabe ermöglichen; unklare Ausnahme als Befund erfassen. / Procedure: Compare final and interim bindings; flag wording that permits stale or mixed proof.

## Konsistenz und dauerhafte Regression / Consistency and lasting regression

- [x] CHK010 Sind alle fünf Impact-Klassen mit denselben Pflichtnachweisen und derselben Fail-safe-Regel beschrieben? / Do all five impact classes retain matching obligations? [Consistency, Spec FR-009, §Regressions- und Impact-Matrix]
  - Durchführungshinweis: Jede Zeile der Spec-Matrix mit Plan und Schnittstellenvertrag vergleichen. Unklarer Impact muss FunctionalImpact+A11yImpact bleiben; erleichternde Umdeutungen als Konflikt notieren. / Procedure: Compare every matrix row and uncertainty rule across artifacts.

- [x] CHK011 Ist das Verhältnis zwischen dauerhafter PR-/Push-Regressionspflicht und impactgesteuerten Zusatznachweisen klar? / Is permanent regression distinguished from impact-triggered additional proof? [Consistency, Spec §Regressions- und Impact-Matrix, FR-008, FR-009]
  - Durchführungshinweis: Formulierungen zu jedem PR/Push, NoFunctionalImpact und manuellen Zusatznachweisen nebeneinanderstellen. Notieren, falls unklar bleibt, welche Pflicht unverändert besteht oder ein optionaler Schritt sie abschalten könnte. / Procedure: Compare trigger wording and flag unclear mandatory versus additional checks.

- [x] CHK012 Sind neue IDs vor Produktcode, fortbestehende alte Regression und nie wiederverwendete IDs durchgängig gefordert? / Are additive identity and prior-regression obligations consistent? [Consistency, Spec FR-001, FR-013, FR-017]
  - Durchführungshinweis: FR-Texte mit dem Lebenszyklus im Datenmodell abgleichen; prüfen, ob neue Funktion, Rückkehr und neue Semantik unterscheidbar sind, ohne alte Pflichten still zu löschen. / Procedure: Compare lifecycle and requirement wording for addition, return and semantic change.

- [x] CHK013 Ist Entfernung oder Deprecation nur mit explizitem genehmigtem Nachweis zulässig? / Does removal require explicit authorised evidence? [Consistency, Spec FR-014]
  - Durchführungshinweis: Removal-Regel und ChangeAuthority-Beschreibung lesen; Genehmigungsreferenz, betroffene IDs und Erhalt der Geschichte müssen verlangt werden. Bloßen Autorenentscheid als unzureichend markieren. / Procedure: Require approval reference, affected identities and preserved history.

## Qualität der Abnahmekriterien / Acceptance criteria quality

- [x] CHK014 Haben alle 17 FR eine nachvollziehbare Zuordnung zu den sechs unveränderten AC/SC? / Do all requirements map to the six unchanged acceptance criteria? [Traceability, Spec §Traceability-Tabelle, SC-001–SC-006]
  - Durchführungshinweis: FR-001 bis FR-017 in der Traceability-Tabelle abhaken und jede SC dem entsprechenden Intake-AC zuordnen. Fehlende oder semantisch geänderte Zuordnung als Befund aufschreiben. / Procedure: Map each FR and each intake acceptance criterion without changing meaning.

- [x] CHK015 Ist die 100-Prozent-Abdeckung durch einen klaren Nenner für Pflicht-IDs und jeden angebotenen automatisierbaren Weg messbar? / Does complete coverage have an explicit denominator? [Measurability, Spec SC-001, FR-003]
  - Durchführungshinweis: Definition der aktiven Pflichtmenge und der Einzelpfade lesen; prüfen, ob Stichproben, bloße Familienzählung oder Zeilen-Coverage den Nenner nicht ersetzen können. / Procedure: Require the complete active path set rather than samples or line coverage.

- [x] CHK016 Sind Pass, Fail, Skipped und NotAssessed sowie Ablehnung von Build-/Unit-/Smoke-only-Nachweisen eindeutig geregelt? / Are evidence outcomes and insufficient proof clearly distinguished? [Acceptance Criteria, Spec SC-006, FR-004]
  - Durchführungshinweis: SC-006 und Evidence-/PathResult-Regeln abgleichen. Für ausgelassene oder unbelegte Pflichten muss ein blockierendes Ergebnis beschrieben sein, nicht ein impliziter Pass. / Procedure: Compare outcome rules and require missing or skipped obligations to block.

- [x] CHK017 Sind fehlende, doppelte, veraltete IDs und absichtliche Dokumentations-/Testschwächung als getrennte negative Abnahmebedingungen beschrieben? / Are negative acceptance conditions explicitly covered? [Measurability, Spec SC-004, FR-004, FR-016]
  - Durchführungshinweis: Die benannten Fehlklassen in Spec und Plan sammeln; prüfen, ob koordinierte Entfernung von Vertrag und Tests oder abgeschwächte Orakel erfasst sind. Fehlende Klasse dokumentieren, keine Mutation ausführen. / Procedure: Review described negative classes, including coordinated deletion and weaker oracles; do not run mutations.

- [x] CHK018 Sind technische Vollständigkeit, unabhängiger Review, menschliche Abnahme und Serienabschluss als getrennte Entscheidungen definiert? / Are technical and human acceptance stages separate? [Clarity, Spec §Governance, SC-002, SC-006]
  - Durchführungshinweis: Statusdefinitionen und Freigabetexte lesen; nachweisen, dass ein Validator-Pass oder die Checklistenerstellung keine Owner-, Merge- oder Folgefeaturefreigabe bedeutet. / Procedure: Review status wording and exclude automatic promotion from technical success.

## Szenarien und Grenzfälle / Scenarios and edge cases

- [x] CHK019 Sind für Editor und alle genannten Dialoge Bestätigung, Abbruch und unbeabsichtigte Teilwirkung ausreichend spezifiziert? / Are confirm, cancel and partial-effect requirements complete? [Coverage, Spec US-001/US-002, FR-006]
  - Durchführungshinweis: Editor, Load, Save, Print, Format, Clear und Palette den Szenarien zuordnen. Festhalten, welche Daten-, Datei- und Fokusinvarianten bei Abbruch gefordert sind und wo Erwartungen fehlen. / Procedure: Map every dialog to explicit cancellation and state-preservation obligations.

- [x] CHK020 Sind für Datei-/Hilfefehler Datenintegrität, verständlicher Fehler und Terminalzustand ausdrücklich gefordert? / Are file/help failure and recovery obligations explicit? [Coverage, Spec §Grenzfälle, US-002]
  - Durchführungshinweis: Fehlend, beschädigt und ungültig als dokumentierte Szenarien vergleichen. Anforderungen an bestehenden Inhalt und Wiederherstellung markieren; unklare Wiederaufnahme/Teilmutation als Lücke erfassen. / Procedure: Compare exception and recovery wording without executing file operations.

- [x] CHK021 Sind Zelltypen, Sperren, Flags, Überlauf, Formatierung, leere/textuelle Referenzen und Zyklen vollständig beschrieben? / Are cell and reference boundaries included? [Coverage, Spec §CELL/REF, §Grenzfälle]
  - Durchführungshinweis: Jede aufgezählte Grenzfallklasse gegen Intake und Spec zuordnen; prüfen, ob Ergebnis- oder Fehleranforderungen fehlen. Eine reine Aufzählung ohne später bestimmbaren Erwartungsbezug als Lücke kennzeichnen. / Procedure: Map each boundary class to an expected outcome or error requirement.

- [x] CHK022 Sind Operatorsyntax sowie Definitions-, Grenz- und Fehlerfälle aller Funktionen eindeutig einer bindenden Angebotsquelle zugeordnet? / Are formula boundaries traceable to binding sources? [Coverage, Spec §OP/FUNC, FR-007]
  - Durchführungshinweis: Funktions-/Operatorfamilien mit der Quellenregel lesen. Undefinierte Priorität, Argumentgrenze oder Fehlersemantik als konkreten Klärungsbedarf notieren; keine neue Mathematik aus Annahmen ergänzen. / Procedure: Identify any undefined semantics and source references without inventing behaviour.

- [x] CHK023 Ist der mögliche Konflikt zwischen druckbarem ASCII und reserviertem Palettenzeichen ausdrücklich und ohne Scope-Verkleinerung geklärt? / Is printable input versus reserved command semantics resolved without scope reduction? [Conflict, Spec §EDIT/CMD, Contracts C-01]
  - Durchführungshinweis: „jedes druckbare ASCII-Zeichen“ mit „/ öffnet Palette“ und der Vertragsinterpretation vergleichen. Nur abhaken, wenn Kontext/Vorrang eindeutig aus bindendem Text folgt; sonst Konflikt mit beiden Fundstellen offen lassen. / Procedure: Compare the two obligations and require explicit context or precedence; keep unresolved interpretation open.

- [x] CHK024 Sind Rastergrenzen, Mindestgröße und größere Terminalgröße sowie Fokus-/Kontrast-/Textzustände eindeutig abgegrenzt? / Are grid and terminal-size requirements explicit? [Clarity, Spec §GRID/TERM, §Grenzfälle]
  - Durchführungshinweis: A1:G21, 80x24 und die im Plan gewählte größere Größe vergleichen. Planungsparameter von normativer Intake-Anforderung trennen; nicht dokumentierte Ausnahmen oder reine Farbbedeutung als Lücke erfassen. / Procedure: Separate normative limits from planned test parameters and flag visual-only meaning.

## Nichtfunktionale Anforderungen / Non-functional requirements

- [x] CHK025 Sind Tastatur, Fokus, Textfeedback, Kontrast und Assistenztechnik nach anwendbarem WCAG 2.2 AA vollständig im Scope definiert? / Is applicable accessibility scope complete? [Completeness, Spec CR-002, §Barrierefreiheit]
  - Durchführungshinweis: TUI-Oberflächen und verlinkte A11Y-Gates abgleichen; pro Bereich die vorgeschriebene Eigenschaft und Nachweisart finden. Keine nicht verfügbare native Screenreader-Semantik voraussetzen. / Procedure: Map surfaces to applicable criteria and proof types without inventing platform capabilities.

- [x] CHK026 Sind Linux-/Windows-Automation und macOS-PTY-/VoiceOver-Pflichten samt Triggern klar getrennt? / Are native automation and human terminal proof distinguished? [Clarity, Spec FR-008, CR-014, SC-003]
  - Durchführungshinweis: Plattform- und Impacttexte lesen; prüfen, ob reale Plattform, gleicher Commit und tatsächlicher ausgeführter Job verlangt werden. Hosted-Governance oder injizierte Tasten dürfen textlich kein VoiceOver ersetzen. / Procedure: Require actual platform binding and keep governance/input injection distinct from human proof.

- [x] CHK027 Sind DE-first/EN-second, B2-Leseverständlichkeit, Begriffsdefinitionen und textorientierte Leserpfade vollständig gefordert? / Are bilingual and text-first requirements complete? [Completeness, Spec CR-003, CR-013]
  - Durchführungshinweis: Sprach- und Dokumentationsabschnitt gegen Zielgruppe lesen; beide Fassungen auf gleichwertige Muss-Regeln und Verständlichkeit ohne Spec-Kit-Vorwissen vergleichen. / Procedure: Compare both language tracks and novice reader assumptions.

- [x] CHK028 Sind öffentliche API-/XML- und DocFX-Änderungstrigger samt axe-/lynx-Pflicht eindeutig dokumentiert? / Are documentation generation triggers and accessibility obligations explicit? [Consistency, Spec §Dokumentation, §Barrierefreiheit]
  - Durchführungshinweis: Die Wenn-dann-Regeln zu API/XML/DocFX markieren und mit Plan vergleichen. N/A darf nur bei unverändertem Scope gelten; keine pauschale Freistellung für Dokumentationsarbeit zulassen. / Procedure: Compare trigger rules and require scoped rationale for non-applicability.

- [x] CHK029 Sind SSDF/CWE, sichere Eingabe-/Datei-/Fehlergrenzen und Threat-Model-/Architektur-Evidenz mit Ownern und Pfaden spezifiziert? / Are secure-development requirements attributable and traceable? [Completeness, Spec CR-005/006/010/011]
  - Durchführungshinweis: Jede anwendbare Security-Regel ihrem Scope, Evidence-Pfad und verantwortlichen Review zuordnen. Speichersicherheit darf keine Eingabe- oder Deserialisierungsanforderung ersetzen. / Procedure: Map security obligations to scope, evidence and ownership, independently of memory safety.

- [x] CHK030 Sind Applicable, N/A, Open und zukünftige Erfüllung für sämtliche benannten Standards klar getrennt? / Are applicability and fulfilment statuses distinct? [Consistency, Spec §Security, CR-007–CR-009]
  - Durchführungshinweis: SSDF/CWE, ASVS, SBOM/VEX/SLSA, AI-SBOM, Zero Trust, C3A/C5 und ergänzende Referenzen durchgehen. Bei N/A Grund/Trigger, bei Open Owner/Aktion/Gate finden; keinen künftigen Nachweis als bestanden lesen. / Procedure: Review each status and its rationale, owner and trigger without promoting planned proof.

- [x] CHK031 Sind begrenzte Wartezeiten, Ressourcen-/Prozessschutz und Terminalwiederherstellung als Qualitätsanforderungen hinreichend bestimmt? / Are bounded waiting and recovery expectations sufficiently specified? [Gap, Spec §Grenzfälle, Plan §Technical Context]
  - Durchführungshinweis: Prüfen, ob festgelegt ist, wie Timeouts als Fehler behandelt werden und wer fehlende konkrete Grenzen vor der jeweiligen Aufgabenfreigabe festlegt. Keine erfundene Produkt-Latenz-SLA verlangen. / Procedure: Identify required timeout outcomes and ownership of unresolved limits, not an invented latency promise.

## Abhängigkeiten, Annahmen und Freigaben / Dependencies, assumptions and approvals

- [x] CHK032 Ist der Dependency-Preflight versionsneutral und sind Freigabe-, Deklarations-, Lock- und Vergleichsquellen vollständig gefordert? / Is dependency preflight version-neutral with complete source obligations? [Completeness, Spec FR-010–FR-012, SC-005]
  - Durchführungshinweis: Die geforderten Quellen und Zustände im Spec-/Plantext zuordnen; Bestandsversion von normativem Pin unterscheiden. Fehlende, floating oder inkohärente Quellen müssen einen klaren Blocker erzeugen. / Procedure: Map sources and states, separating observed versions from approval obligations.

- [x] CHK033 Sind Wiederverwendung bei unverändertem Pin, Drift-Vollmatrix und Verbot automatischer Upgrades konsistent definiert? / Are reuse, drift and no-upgrade rules consistent? [Consistency, Spec FR-011/012, SC-005]
  - Durchführungshinweis: AlreadySatisfied-/Drift-/Blocked-Texte vergleichen. Derselbe Versionsname allein darf keine alte Evidenz gültig machen; fehlende Locks dürfen nicht stillschweigend als erfüllter Preflight gelten. / Procedure: Compare state rules and flag silent reuse or repair assumptions.

- [x] CHK034 Sind bestehende regulatorische Einzelentscheidungen, Produkt-/Tool-/Organisationsscope und offene menschliche Planfreigabe nachvollziehbar dokumentiert? / Are regulatory scope and human approval obligations attributable? [Assumption, Spec §Regulatorischer Quellenabgleich]
  - Durchführungshinweis: Datierte Vorprüfung mit Spec und Plan vergleichen; Rolle, Land, Quellenstand, Owner, Frist/Gate und Trigger markieren. Ausbildungszweck oder AI-SBOM-N/A darf keine pauschale Rechtsausnahme begründen; keine Rechtsprüfung in diesem Checklistenschritt durchführen. / Procedure: Review recorded screening and remaining human obligations, without issuing legal clearance.

- [x] CHK035 Sind Dokumentations-, Skript-/Agentenparitäts-, Statistik- und Liefergrenzen ohne implizite Ausführungserlaubnis definiert? / Are governance and delivery boundaries explicit? [Completeness, Spec §Dokumentation, CR-012–CR-014]
  - Durchführungshinweis: Dokumentationsentscheidung, paired Varianten/Help/Manpage, Regeländerungstrigger und Statistikgrenze lesen. Commit/Push/PR/Merge, Autonomie und Folgefeature müssen eigene Autorität behalten. / Procedure: Review scope and conditional parity obligations; exclude implicit delivery permission.

- [x] CHK036 Sind offene Widersprüche und Annahmen mit konkretem Owner, Klärungsaktion und nächstem sicheren Gate behandelbar? / Are remaining ambiguities assigned actionable ownership? [Ambiguity, Spec §Annahmen, Plan §Constitution Check]
  - Durchführungshinweis: Alle beim Review offen gebliebenen CHK-IDs sammeln; je Befund Fundstellen, Auswirkung, Owner und Freigabegrenze festhalten. Klärbare Textlücke, fehlende Ausführungsevidenz und menschliche Entscheidung getrennt kennzeichnen. / Procedure: Consolidate open findings and distinguish wording gaps, future proof and human decisions.

## Prüfnotizen / Review notes

Jede Durchführung beginnt mit dem Dokumentenabgleich, nicht mit einem Produktlauf. Für Ergebnisse kann je CHK-ID ein kurzer DE/EN-Vermerk ergänzt werden: Fundstellen; Ergebnis Pass/Open/N/A; Begründung; Reviewer/Datum; Owner und Aktion bei Open. Keine Kästchen allein wegen vorhandener Builds, Tests oder dieser erzeugten Liste abhaken.

*Begin with document comparison, not execution. Add a short bilingual result per CHK identity: sources, status, rationale, reviewer/date and owner/action for Open. Existing builds or generation of this list do not justify checking items.*

## Durchgeführter Dokumentenreview / Completed document review

Datum: 2026-10-07; Reviewer: Codex, auf ausdrücklichen Korrekturauftrag. Tiefe: vollständiger Autorenabgleich aller 36 Durchführungshinweise, kein unabhängiger Produktreview oder Rechtsgutachten. Die ursprünglich offenen Kästchen oben dokumentieren den Erzeugungsstand; die folgenden Resultate sind der aktuelle Reviewstand. Pass bedeutet ausreichende Anforderungsformulierung, niemals bestandener Produktlauf.

*On explicit correction authority, Codex reviewed all thirty-six procedure notes. This is an author document review, not independent product or legal acceptance. Original unchecked boxes preserve generation state; the results below are current. Pass refers only to requirement quality.*

| CHK | Ergebnis / Outcome | Fundstelle und Bearbeitung / Source and disposition |
|---|---|---|
| CHK001 | Pass | Spec §Umfang/Präzisierungen: vier Quellen und additive Discovery; zusätzliche Angebote RQ-002 erhalten. / Four sources and additive offers retained. |
| CHK002 | Pass | Intake-/Spec-Baseline und Contracts C-01: 17 Familien vollständig, neue Discovery innerhalb dieser Familien. / All families preserved. |
| CHK003 | Open | RQ-002: Konflikte bei historischen Navigations-/Editier-/Befehlsangeboten noch nicht aufgelöst. / Historical offered paths remain conflicting. |
| CHK004 | Pass | Spec §FUNC-LEGACY/FUNC-EXT, FR-007: 16 Namen und echter Editorpflichtweg; offene Detailsemantik unter CHK022. / Complete function scope, separate semantics finding. |
| CHK005 | Pass | Spec §Nicht-Ziele/Annahmen, Plan Summary: Reihenfolge und Folgefeaturegrenze unverändert. / Ordering and exclusions preserved. |
| CHK006 | Pass | Spec §Identität und Abdeckung, Datenmodell Entities: ID-/Pfad-/Kontextbegriff präzisiert. / Identity and path semantics clarified. |
| CHK007 | Pass | Spec Clarifications, FR-003/SC-001: kein manueller Automationsersatz. / Accepted automation boundary preserved. |
| CHK008 | Pass | Spec §Quellsemantik/Aktuelle Quellenbefunde: Textdefekt getrennt von offenen Angeboten. / Defects distinguished from semantic offers. |
| CHK009 | Pass | Spec §Evidenzfrische, Datenmodell Gültigkeit, Contracts C-03: Evidence-only-Ausnahme entfernt. / Exact final-head consistency clarified. |
| CHK010 | Pass | Spec/Plan Impact-Matrix: fünf Klassen und Fail-safe-Regel identisch. / Five impact classes retained. |
| CHK011 | Pass | Intake IAD002, Spec §Dauertrigger, Plan Prüfschärfe: Vollautomation bei jedem PR/Push einschließlich NoFunctionalImpact explizit. / Permanent regression clarified. |
| CHK012 | Pass | FR-001/013/017 und Datenmodell Zustände: additive IDs, alte Pflichten, kein Recycling. / Additive identity lifecycle explicit. |
| CHK013 | Pass | FR-014/ChangeAuthority: Entfernung verlangt Genehmigungsreferenz und erhaltene Geschichte. / Removal authority explicit. |
| CHK014 | Pass | Spec Traceability: FR-001–FR-017 auf SC-001–SC-006 und Intake-AC abgebildet. / Complete requirement mapping. |
| CHK015 | Pass | Spec §Identität und Abdeckung, Datenmodell Nenner: vollständige ID/Pfad/Plattform/Szenario-Tupel. / Coverage denominator explicit. |
| CHK016 | Pass | SC-006 und PathResult: fehlend/Fail/Skipped/NotAssessed blockieren, Smoke kein Vollnachweis. / Insufficient outcomes cannot pass. |
| CHK017 | Pass | Plan Mindestprüfungen, Contracts C-01/C-03: koordinierte Entfernung und Orakelschwächung erfasst. / Negative proof-strength classes covered. |
| CHK018 | Pass | Datenmodell Abnahmestufen, Plan Freigabegrenze: technische, unabhängige und menschliche Entscheidungen getrennt. / Acceptance roles separate. |
| CHK019 | Pass | Spec §Dialog- und Fehlerzustände: Auswahl/AutoCalc/Dateien/Fokus und zweiter Print-Abbruch präzisiert. / Cancellation invariants clarified. |
| CHK020 | Pass | Spec §Dialog- und Fehlerzustände, US-002: fehlerhaftes Load ohne Teilmutation, bedienbarer Hauptkontext und Terminalwiederherstellung. / Recovery requirements explicit. |
| CHK021 | Pass | Spec CELL/REF/Grenzfälle und Contracts Pfadpflichtfelder: alle Klassen, explizite erwartete Zustände vor ausführbarem Katalog. / Cell/reference outcome obligations complete. |
| CHK022 | Open | RQ-003: Operator-/Legacy-Grenzsemantik nicht überall eindeutig angeboten; FACT-Integertext und beobachtete Truncation nicht normativ entschieden. / Formula semantic source gaps remain. |
| CHK023 | Open | RQ-001: ASCII-Angebot und Slash-Palette beide erhalten; kein genehmigter Vorrang. / Slash conflict remains unresolved. |
| CHK024 | Pass | Spec GRID/TERM und Plan Technical Context: A1:G21, 80x24, größere Größe 120x40 als Designparameter getrennt. / Normative and planned sizes distinguished. |
| CHK025 | Pass | CR-002, Spec Barrierefreiheit und verlinktes A11Y-Intake: alle anwendbaren Bereiche, keine behauptete native Semantik. / Accessible scope and proof boundary defined. |
| CHK026 | Pass | FR-008/CR-014, Plan/Contracts: native Plattformautomation versus macOS-PTY/VoiceOver separat. / Platform and human proof distinguished. |
| CHK027 | Pass | CR-003/013, DE/EN-Abschnitte: B2, Begriffsdefinitionen und Textpfade erhalten. / Bilingual accessible reader requirements retained. |
| CHK028 | Pass | Spec Dokumentation/Barrierefreiheit, Quickstart: API/XML-/DocFX-Trigger mit axe/lynx. / Documentation proof triggers explicit. |
| CHK029 | Pass | CR-005/006/010/011, Plan Security-Matrix: Grenzen, Owner, Review und Pfade konkret. / Security responsibilities and evidence mapped. |
| CHK030 | Pass | Spec/Plan Anwendbarkeitsmatrizen: Applicable/N/A/Open von Erfüllung getrennt, Trigger/Owner aufgeführt. / Applicability not promoted to fulfilment. |
| CHK031 | Pass | Spec §Warte-/Ressourcengrenzen, Plan Prüfschärfe, Datenmodell Decision: 30/180/5-Sekunden-Designgrenzen, Review und Timeout-Fail. / Bounded infrastructure obligations added. |
| CHK032 | Pass | FR-010–012, PinDecision und Plan: tatsächliche Freigabe-/Deklarations-/Lock-/Quellenprüfung versionsneutral. / Required preflight sources explicit. |
| CHK033 | Pass | FR-011/012, Datenmodell Zustände: passende Evidenz, Drift-Vollmatrix, fehlende Locks blockieren, kein Upgrade. / Dependency states and boundaries consistent. |
| CHK034 | Pass | Spec regulatorischer Quellenabgleich, Plan Human-only-Gate: historischer Status, Rollen, Owner/Frist/Trigger dokumentiert; Freigabe selbst weiterhin Open. / Human approval obligation documented, not fulfilled. |
| CHK035 | Pass | Spec/Plan Dokumentations-/Paritäts-/Statistik-/Liefergrenzen: keine implizite Remote-/Autonomiefreigabe. / Governance authority boundaries preserved. |
| CHK036 | Pass | Spec §Aktuelle Quellenbefunde, Plan Gates, Register unten: alle verbleibenden Befunde mit Owner/Aktion/Grenze. / Remaining findings actionable and attributable. |

### Offene Entscheidungen / Open decisions

| Befund / Finding | Owner | Aktion und Grenze / Action and boundary |
|---|---|---|
| RQ-001 / CHK023 | Feature-Entwicklung + Thorsten | ASCII-/Slash-Vorrang aus bindenden Quellen klären; erforderliche normative Änderung nur über genehmigte Intake-/Klärungsprozedur. Vor Planfreigabe und betroffenem Produktcode. / Resolve authority before approval and code. |
| RQ-002 / CHK003 | Feature-Entwicklung + Thorsten | Zusätzliches Help-Angebot vollständig inventarisieren und widersprüchliche Keys/Bildschirmkommando fachlich angleichen; keine historische Pauschalausnahme. Vor Planfreigabe und betroffenem Produktcode. / Resolve all offered help conflicts without removal. |
| RQ-003 / CHK022 | Feature-Entwicklung + Thorsten | Fehlende Operator-/Legacy-Grenzen und dokumentierte Fehler fachlich reviewen; Implementierung allein nicht als Norm übernehmen. Vor Planfreigabe und betroffenem Produktcode. / Review missing semantics, not merely mirror current code. |
| Human-only-Regulatorik | Thorsten + qualifizierter Reviewer | Rollen/Scope/Quellen bis Planfreigabe bestätigen; bestehende Rechtsentscheidungen nicht überschreiben. / Qualified scope review remains required. |
| Pin-/Lock-/Plattform-/Produktnachweise | Feature-Entwicklung + unabhängiger Reviewer | Erst in separat beauftragter Umsetzung erheben; fehlende Locks blockieren Produktcode, fehlende Nachweise Abnahme. / Execution proof remains future and blocking. |

**Ergebnis:** 33 Punkte Pass, drei Punkte Open; keine N/A-Punkte. Behebbare Textlücken direkt in Spec, Plan, Datenmodell, Contracts, Research und Quickstart korrigiert. Keine Intake-/Produkt-/API-/Abhängigkeitsänderung, kein Produktlauf, keine unabhängige oder menschliche Freigabe. Der Aufgabenentwurf darf offene Klärungsgates zuerst abbilden, nicht ihre Lösung voraussetzen.

*Thirty-three requirement-quality points pass and three remain Open. Wording corrections are applied in the affected feature documents. No intake/product change or execution/acceptance is implied; any task breakdown must preserve unresolved gates.*

### Klärungsfortschreibung / Clarification update

2026-10-07, Nutzerentscheidung A, integriert durch Codex: CHK023/RQ-001 nun Pass/Resolved für Anforderungsklarheit. Im Raster öffnet `/` die Palette, im offenen Editor ist es Eingabetext; andere druckbare ASCII-Zeichen starten im Raster die Bearbeitung. Aktueller Gesamtstand: 34 Pass, zwei Open (CHK003/RQ-002, CHK022/RQ-003). Die frühere Ergebnistabelle und das Register bleiben als Reviewhistorie erhalten; Quellenangleichung, Produktnachweise und menschliches Gate weiterhin nicht erfüllt.

*User answer A resolves CHK023/RQ-001 at requirement level. Current results are thirty-four Pass and two Open; prior review records remain historical, not current completion claims.*

Zweite Klärung 2026-10-07, Nutzerantwort A: CHK003/RQ-002 nun Pass/Resolved für Anforderungsklarheit. Alle historischen Funktionen/Tasten bleiben Pflicht; Raster/Editor/Befehlsauswahl unterscheiden ihre Bedeutung. Aktueller Stand: 35 Pass, ein Open (CHK022/RQ-003). Quellenangleichung, Ausführung und menschliche Freigaben sind weiterhin keine erledigten Nachweise.

Dritte Klärung 2026-10-07, Nutzerantwort A: FACT akzeptiert ganze Argumente 0 bis 33; `FACT(0)=1`, Bruchteile/negative/zu große Werte ergeben Fehler ohne Truncation. Der historische CHK022-Befund zur unentschiedenen FACT-Semantik ist damit supersediert; RQ-003 bleibt für übrige Formelgrenzen Open. Aktueller Stand unverändert 35 Pass, ein Open. Quellenangleichung, Produktnachweise und menschliche Freigaben bleiben separat ausstehend.

*The third answer A resolves FACT's domain and supersedes that part of the historical finding. Remaining formula semantics keeps CHK022/RQ-003 Open: 35 Pass, one Open. Source alignment, execution and human clearance remain pending.*

*The second answer A resolves CHK003/RQ-002 while preserving every offer by context. Current quality results: thirty-five Pass, one Open; execution and approval remain separate.*

Vierte Klärung 2026-10-07, Nutzerantwort A: Operatorbindung in CHK022/RQ-003 entschieden; Potenzketten rechts, Potenz vor unären Vorzeichen, Klammern zuerst. Der entsprechende historische offene Teilbefund ist supersediert. Aktueller Stand 35 Pass, ein Open für verbleibende numerische Definitions-/Ergebnisgrenzen. Quellen-/Produktnachweise und menschliche Freigabe weiterhin ausstehend.

*The fourth answer A supersedes the unresolved operator-binding finding. CHK022/RQ-003 remains Open for numeric domain/result boundaries: 35 Pass, one Open. Source/product proof and human clearance are still pending.*

Fünfte Antwort A: Nur endliche reelle Ergebnisse; Definitionsfehler, Überläufe und NaN/Unendlich ergeben verständliche Fehler statt erfolgreicher numerischer Zellwerte. Die vier Fehlerorakel der Spec und endliche Kontrollfälle bei späterer Umsetzung test-first binden; keine Produktprüfung hier. Alle fünf Fragen dieser Nachprüfung sind beantwortet. RQ-003 bleibt für fehlende Quellenbindung von SIN/COS/ARCTAN-Winkeleinheit, LN/LOG-Basis und ROUND-Oberpräzision Open; separat klären, nicht aus aktuellem Code ableiten. Menschliche Freigabe und Quellen-/Produktnachweise bleiben ausstehend. Aktueller Stand: 35 Pass, ein Open (CHK022/RQ-003); die historische offene numerische Fehlerpolitik ist supersediert.

*The fifth answer A requires finite real results and clear numeric failures. Bind the specification's four error cases and finite controls test-first in future authorised work; no product tests run here. Five follow-up questions are answered. Trigonometric units, logarithm bases and ROUND's upper precision remain deferred source bindings under RQ-003; human clearance and source/product proof remain pending.*

2026-10-08, erste Antwort A dieses Klärungslaufs: SIN/COS-Eingabe und ARCTAN-Ausgabe in Bogenmaß; Orakel und Quellenbindung stehen im trigonometrischen Vertrag der Spec. Kein neues π-Syntaxangebot, kein Produktnachweis. RQ-003 bleibt für LN/LOG-Basis und ROUND-Oberpräzision Open. Der historische offene Winkel-Teilbefund ist supersediert; aktueller Stand weiterhin 35 Pass, ein Open (CHK022/RQ-003).

*The first answer A in this clarification run binds SIN/COS inputs and ARCTAN output to radians, with specification oracles and no new π syntax or product proof. Logarithm bases and ROUND's upper precision keep RQ-003 Open.*

2026-10-08, zweite Antwort A: LN zur Basis e, LOG zur Basis 10; Null und negative Argumente für beide Funktionen als verständliche Fehler. Pflichtorakel und reviewte Toleranzen gemäß Logarithmusvertrag der Spec. Der offene LN/LOG-Teilbefund ist supersediert; RQ-003 bleibt nur für die obere ROUND-Präzision Open. Kein Produktnachweis oder menschliche Planfreigabe. Aktueller Stand: 35 Pass, ein Open (CHK022/RQ-003).

*The second answer A binds LN to base e and LOG to base 10, with clear zero/negative errors and specification oracles. This supersedes the logarithm source gap; only the upper ROUND precision keeps RQ-003 Open. Product proof and human plan clearance are pending.*

2026-10-08, dritte Antwort A: ROUND-Präzision nichtnegativ gegen null abschneiden, dann 0 bis 15 einschließlich; größere Werte Fehler ohne Begrenzung. Negative Rohargumente einschließlich -0.5 Fehler vor Abschneidung; Halbwerte weiterhin weg von null. Orakel gemäß Spec. RQ-001–RQ-003-Anforderungslücken Resolved; frühere Open-Fortschreibungen sind supersedierte Historie. Keine Produktabnahme oder menschliche Planfreigabe. Gezielte Nachprüfung CHK022 durch Codex auf Nutzerauftrag: Klärungsantworten und Spec §Präzisierungen binden FACT, Operatoren, numerische Fehler, Trigonometrie, Logarithmen und ROUND; vorhandene erweiterte Funktionsregeln erhalten. CHK022 Pass; CHK003/CHK023 bereits Pass; übrige 33 Ergebnisse unverändert. Aktuell 36 Pass, null Open in der Anforderungsqualitätsliste. CHK034 prüft die Dokumentation des menschlichen Gates, nicht dessen Erfüllung.

*The third answer A binds ROUND to truncated nonnegative precision 0–15 with clear larger/negative-raw errors and unchanged midpoint rounding. Specification oracles resolve the identified source findings; earlier Open entries are history. All 36 requirement-quality items pass, not product acceptance. Qualified dated role/scope evidence and owner confirmation are still required for human clearance; no implementation or delivery authority is granted.*

**Aktueller Governance-Stand 2026-10-08:** Owner bestätigt privates persönliches Projekt und supersediert die zusätzliche externe qualifizierte Rollen-/Scope-Review-Pflicht. Frühere Aussagen zu diesem fehlenden Plan-Gate sind historisch überholt. Repository bleibt öffentlich; historische regulatorische Einzelstatus und Neubewertung bei konkreten Scope-Triggern bleiben erhalten. 36 Anforderungsqualitäts-Punkte Pass, kein Produktnachweis. Plan als Dokumenten-PR zur Owner-Prüfung liefern; keine Implementierung, kein Merge. Technische Security-/Preflight-/A11Y-/Plattform-Gates unverändert.

*Current governance state on 2026-10-08: the owner's personal-project decision supersedes the added external qualified review prerequisite and earlier claims that this blocks the plan. Repository visibility remains public; historical applicability dispositions and concrete-trigger reassessment remain intact. All 36 requirement-quality items pass, not product proof. Submit the documentation PR for owner review, without implementation or merge; technical gates are unchanged.*
