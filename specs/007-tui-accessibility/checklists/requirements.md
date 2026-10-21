# Spezifikationsqualität: A11Y-TUI / Specification Quality: Accessible TUI

**Erstellt / Created:** 2026-10-12
**Durchführungshinweise präzisiert / Verification instructions refined:** 2026-10-18
**Feature:** [spec.md](../spec.md)
**Zweck:** Anforderungsqualität prüfen, keine Produktabnahme. Prüfung durch den erstellenden Agenten, kein unabhängiger Produktreview. Jede Zeile besitzt einen Durchführungshinweis.

*Purpose: assess requirements quality, not product acceptance. Reviewed by the authoring agent, not an independent product reviewer. Every item includes a verification instruction.*

## Inhaltsqualität / Content Quality

- [x] CHK-001 Keine neue Implementierungsentscheidung.
  Durchführungshinweis: In spec.md Anforderungen und Nicht-Ziele Zeile für Zeile auf neue APIs, Bridges, Frameworkwechsel und vorgeschriebene Lösungen prüfen. Bestanden, wenn nur Nutzerziele und bestehender Technologiekontext festgelegt sind; neue technische Entscheidungen als Befund mit Abschnittsanker erfassen.
  *Verification instructions: Review requirements and non-goals in spec.md for new APIs, bridges, framework changes or prescribed solutions. Pass only for user goals and existing technology context; record new design choices with a section reference.*
- [x] CHK-002 Nutzerwert im Mittelpunkt.
  Durchführungshinweis: US-001 bis US-004 jeweils mit einer konkreten Nutzerhandlung und ihrem Nutzen verbinden. Bestanden, wenn jede Story unabhängig prüfbare Tastatur-/Textbedienung, sichere Dialoge oder belastbare Nachweise beschreibt; interne Testerfolge allein reichen nicht.
  *Verification instructions: Map each of US-001 to US-004 to a user action and benefit. Pass for independently verifiable interaction, safe dialogs or reliable evidence, not internal test success alone.*
- [x] CHK-003 Verständlich für Zielgruppe.
  Durchführungshinweis: Lesehilfe und alle neu ergänzten Absätze in beiden Sprachen lesen; Fachbegriffe beim ersten Gebrauch, gleiche Pflichten und CEFR-B2-Verständlichkeit prüfen. Bestanden, wenn Lernende ab dem ersten Lehrjahr ohne Spec-Kit-Vorwissen den Text verstehen; Sprachlücken mit Fundstelle notieren.
  *Verification instructions: Read both language tracks and check first-use definitions, equivalent obligations and B2 readability for first-year trainees without process knowledge. Record any missing or unequal explanation.*
- [x] CHK-004 Pflichtabschnitte ausgefüllt.
  Durchführungshinweis: Die Überschriften in spec.md gegen die lokale Spec-Vorlage und anwendbare Preset-Ergänzungen abgleichen. Für Szenarien, Anforderungen, Verfassung, Entitäten, Erfolgskriterien und Annahmen Inhalt statt Platzhalter nachweisen; nicht anwendbare Abschnitte benötigen eine Begründung.
  *Verification instructions: Compare spec headings with the local template and applicable preset additions. Require actual content for scenarios, requirements, constitution, entities, outcomes and assumptions; justify non-applicability.*

## Anforderungsvollständigkeit / Requirement Completeness

- [x] CHK-005 Keine offenen fachlichen Marker.
  Durchführungshinweis: In spec.md nach NEEDS CLARIFICATION, TODO, TBD und offenen fachlichen Alternativen suchen; CQ-001/CQ-002 mit den zwei protokollierten Antworten abgleichen. Bestanden ohne unbeantwortete Produktentscheidung; unbekannte historische Beobachtungen nicht als beantwortet oder reproduziert markieren.
  *Verification instructions: Search for clarification markers and unresolved product alternatives; compare both CQ records with the accepted answers. Unknown historical observations must remain unknown, not resolved or reproduced.*
- [x] CHK-006 Alle Abnahmedetails eindeutig.
  Durchführungshinweis: CQ-001/CQ-002 gegen US-002, R-A11Y-CALC-06 und den Plattformvertrag lesen. Bestanden nur bei Mac A/Terminal.app/VoiceOver mit Konfiguration je Lauf und unmittelbarer eindeutiger Aktionsansage ohne Zusatzlesen; daraus keinen Produkt-Pass ableiten.
  *Verification instructions: Compare the accepted choices with US-002, requirement 06 and the platform contract. Require the per-run reference and immediate action naming without extra reading; this establishes document consistency, not product success.*
- [x] CHK-007 Ergebnisse messbar.
  Durchführungshinweis: Jede der acht AK-Zeilen auf Nenner, Ergebnis und Nachweisart prüfen. Vollständige Wege, Null-Upgrade/Null-Teilwirkung, Kontrastschwellen und gemeinsame Commitbindung müssen prüfbar sein; fehlende Mess- oder Ergebnisregeln mit AK-ID als Befund notieren.
  *Verification instructions: Review all eight criteria for denominator, outcome and evidence type. Require complete paths, zero unintended effects/upgrades, contrast thresholds and common commit bindings; identify missing rules by criterion ID.*
- [x] CHK-008 Nutzerbezogene Erfolgskriterien.
  Durchführungshinweis: Für jedes Erfolgskriterium fragen, welches beobachtbare Nutzerergebnis es belegt. Bestanden, wenn Build-, Widget- oder Buffer-Erfolg keinen Nutzer-/Screenreader-Nachweis ersetzt; die vom Intake vorgegebenen DocFX-Prüfwerkzeuge bleiben erhalten.
  *Verification instructions: Check the observable user outcome behind each criterion. Build or widget results cannot replace user or native-reader evidence; retain the intake's prescribed documentation verification tools.*
- [x] CHK-009 Alle Szenarien definiert.
  Durchführungshinweis: US-001 bis US-004 gegen alle Vertragsfamilien auf Erfolg, Abbruch, Fehler und Randfälle abgleichen. Für Dialoge zusätzlich Fokus-, Tabellen- und Datei-Invarianten prüfen; fehlende Szenarioarten unter der betroffenen Familie dokumentieren.
  *Verification instructions: Map all journeys and contract families to success, cancellation, failure and boundaries. Include focus, sheet and file invariants for dialogs; record missing scenario types per family.*
- [x] CHK-010 Grenzfälle vorhanden.
  Durchführungshinweis: Grenzfallliste auf 80x24/120x40 und zusätzlich 120x28, direkte Eingabe ohne End, Pin-/Quell-/Binary-Drift sowie Open/Incomplete-Nachweise prüfen. Bestanden, wenn unbekannte oder teilweise geprüfte Fälle ausdrücklich keinen Pass erlauben.
  *Verification instructions: Check all sizes, direct typing, dependency/source/binary drift and incomplete evidence. Pass only when unknown or partial results explicitly cannot establish success.*
- [x] CHK-011 Umfang begrenzt.
  Durchführungshinweis: Nicht-Ziele und Issue-Bezug mit dem Intake vergleichen. Bestanden ohne neue Apps, PL/0, Rename, Migration, automatisches Upgrade oder automatische Issue-Promotion; notwendige Umfangsänderungen als separate Ownerentscheidung kennzeichnen.
  *Verification instructions: Compare non-goals and issue references with the intake. Reject additional apps, integrations, rename, migration, automatic upgrades or issue promotion without a separate scope decision.*
- [x] CHK-012 Abhängigkeiten und Annahmen benannt.
  Durchführungshinweis: Read-only scripts/validate-requirements-intake-alignment.ps1 und die Bash-Variante ausführen; Receipts, Manifest und Reviewbindung auf Aktualität prüfen. Bestanden bei gültigen Bindungen und Completed-Vorgängern; Drift stoppt die Weiterarbeit, Pending ist keine Startfreigabe.
  *Verification instructions: Run both read-only alignment variants and inspect current receipt, series and review bindings. Drift stops continuation; completed predecessors do not grant execution authority and Pending is not start permission.*

## Feature-Bereitschaft / Feature Readiness

- [x] CHK-013 Jede Intake-Anforderung besitzt Abnahmezuordnung.
  Durchführungshinweis: Die zehn R-A11Y-CALC-IDs einzeln in der Traceability-Tabelle suchen und AK- sowie US-Zuordnung notieren. Bestanden bei 10/10 vollständigen Zuordnungen ohne entfernte, doppelt verwendete oder umgedeutete IDs.
  *Verification instructions: Find all ten requirement IDs and record their acceptance/journey mappings. Require complete coverage without removed, recycled or reinterpreted identities.*
- [x] CHK-014 Szenarien decken Hauptwege ab.
  Durchführungshinweis: Die vollständige Funktionsbaseline gegen den aktiven Produktvertrag und unabhängigen Katalog aus Feature 006 abgleichen. Alle 17 Familien sowie deren Einzelwege/Aliasse/Fehlerfälle müssen erhalten bleiben; Beispiele oder Sammelzeilen sind kein Vollständigkeitsnachweis.
  *Verification instructions: Compare the preserved baseline with Feature 006's active contract and independent catalogue. Retain all families and individual obligations; examples or aggregate rows do not prove completeness.*
- [x] CHK-015 Anforderungsabdeckung statt behauptetem Produkt-Pass.
  Durchführungshinweis: Jede Pass-Aussage nach Geltungsbereich einordnen: Dokumentenqualität, Automation, PTY, HTML oder native Bedienung. Bestanden, wenn keine Anforderungsabdeckung als ausgeführte Produktabnahme erscheint; unbelegte Aussagen als Befund markieren.
  *Verification instructions: Classify every success claim by evidence type and scope. Requirements coverage must never be presented as executed product acceptance; flag unsupported claims.*
- [x] CHK-016 Keine Implementierung in der Spezifikation.
  Durchführungshinweis: Anforderungen auf konkrete Module, Methoden, öffentliche API-Signaturen oder Bauanweisungen prüfen. Bestanden, wenn die Spec Was/Warum beschreibt und technische Lösungen dem Plan überlässt; vorhandene bindende Technologien bleiben zulässiger Kontext.
  *Verification instructions: Inspect requirements for module/method/API design or implementation instructions. Keep specification outcomes separate from technical planning while retaining binding existing technology context.*

## Ergänzende Nachweisgrenzen / Additional Evidence Boundaries

- [x] CHK-017 Issue #107 samt beiden Kommentaren gelesen.
  Durchführungshinweis: Issue #107 einschließlich beider verlinkten Kommentare read-only mit B01/B02, Zeilenlesen und Berichtsumgebung vergleichen. Bestanden, wenn berichtet/reproduziert/verifiziert getrennt bleiben und historischer Host, fehlende Ansagetexte und Ursachen nicht erfunden werden.
  *Verification instructions: Compare issue #107 and both referenced comments read-only with the recorded observations. Preserve evidence-strength distinctions and do not invent historical host, speech or cause.*
- [x] CHK-018 Plattform-/Frameworkgrenzen getrennt.
  Durchführungshinweis: Die Zuständigkeitsabschnitte auf TinyCalc, Terminal.Gui, Terminalhost und Reader prüfen; Textlesen, Anwendungsfokus und native Semantik getrennt zuordnen. Bestanden ohne Ableitung von VoiceOver auf Narrator/NVDA oder von PTY/Widget auf native Bedienung.
  *Verification instructions: Review each responsibility layer and distinguish text reading, application focus and native semantics. Reject cross-reader or automated-to-native compatibility inference.*
- [x] CHK-019 Historische Evidenz geschützt.
  Durchführungshinweis: Mit git diff prüfen, dass alte Abnahmeprotokolle und Serienartefakte unverändert sind; historische Aussagen in der Spec auf Szenario/Plattform/Commit begrenzen. Bestanden ohne pauschalen Widerruf oder allgemeine Kompatibilitätszusage.
  *Verification instructions: Check Git changes for preserved historical acceptance and series files. Historical results retain their tested scope without blanket revocation or compatibility promises.*
- [x] CHK-020 Governance-Anwendbarkeit aufgezeichnet.
  Durchführungshinweis: Governance-Matrix gegen Verfassung und installierte Presets lesen. Für jeden anwendbaren Standard Evidenzpfad, für N/A Begründung/Trigger und für Open Owner/Folgeaktion prüfen; keine aufgehobene externe Rollen-/Scope-Hürde wieder einführen.
  *Verification instructions: Compare applicability with the constitution and installed presets. Require evidence paths, justified non-applicability and owned follow-up for gaps without reintroducing the removed external review gate.*

## Nachprüfung der Durchführungshinweise / Verification Instruction Recheck

18.10.2026, Basis `f373437`, Prüfung durch den bearbeitenden Agenten, kein unabhängiger Produktreview. Pass bedeutet hier Dokumentenkonsistenz nach Korrektur, nicht ausgeführte Produktprüfung. Owner verbleibender Produkt-/Plattformnachweise: Thorsten, Wiedervorlage vor Umsetzung/finalem Kandidaten.

*Authoring-agent document review, not independent product acceptance. Passing rows establish corrected document consistency only; Thorsten owns future execution before implementation/final acceptance.*

| Prüfpunkt / Item | Ergebnis und Beleg / Result and evidence |
|---|---|
| CHK-001 | Pass — Spec Nicht-Ziele/CR-004: keine neue Produktlösung; Dokumentenrechte berichtigt / no new product solution; corrected document scope. |
| CHK-002 | Pass — US-001–004: selbstständige Bedienung, sichere Dialoge, Hilfe und Evidenz getrennt prüfbar / distinct user-valued journeys. |
| CHK-003 | Pass — Lesehilfe und DE/EN-Paare geprüft; Einfüge-/Überschreib- und Nachweisbegriffe konkretisiert / language parity and mode/evidence terminology reviewed. |
| CHK-004 | Pass — Lokale Spec-Vorlage: Szenarien, Requirements/CR, Entitäten, Erfolgskriterien, Annahmen vorhanden / mandatory sections present. |
| CHK-005 | Pass — Zwei CQ-Antworten erhalten, keine neuen fachlichen Marker / both accepted answers retained; no new unresolved choice. |
| CHK-006 | Pass — CQ-001/002, US-002, R-06 und Contracts gleichgerichtet; tatsächlicher Fokus statt vermuteter Tab-Reihenfolge / consistent reference/speech criteria and observed focus. |
| CHK-007 | Pass — AK-01–08 vollständig; R-05/Contracts um Messweg und 3:1-Nichttextkriterium präzisiert / all criteria present; contrast proof clarified. |
| CHK-008 | Pass — AK-Tabellen: Nutzerausgänge von Build/Widget/HTML-Teilbelegen getrennt / user outcomes distinguished from partial technical evidence. |
| CHK-009 | Pass — Baseline-/Grenzfälle gelesen; Contracts erhalten Modus-, Abbruch-/Dateninvarianten / baseline boundaries and mode/cancellation obligations preserved. |
| CHK-010 | Pass — 80x24/120x40 plus 120x28; Drift, fehlende Ansage/Prüfung und unkontrollierbare Farben ohne Pass / sizes and failure/evidence boundaries preserved. |
| CHK-011 | Pass — Intake-Nichtziele und #107 abgeglichen; kein Rename/PL0/Frameworkwechsel/Upgrade / scope and non-goals preserved. |
| CHK-012 | Pass — Beide Alignment-Varianten erneut geprüft; aktuelle 13 Receipts, Serie/Review; Completed-Vorgänger / current bindings verified in both variants. |
| CHK-013 | Pass — Zehn R-IDs in Spec zu acht AK und vier US rückverfolgbar / ten requirements mapped to eight criteria and four journeys. |
| CHK-014 | Pass — Aktiver Produktvertrag read-only: 17 Pflichtfamilien/364 Wege je Plattform, keine Auswahl / complete independent denominator retained. |
| CHK-015 | Pass — CR-010 von Prüfbehauptung zu Prüfpflicht korrigiert; HTML-/Native-Grenzen erhalten / corrected unexecuted review claim; preserved evidence limits. |
| CHK-016 | Pass — Spec beschreibt Ziele und Nachweisgrenzen, technische Orakel/Schemaänderungen nur im Design / specification remains outcome-oriented. |
| CHK-017 | Pass — #107 und beide Kommentare live gelesen; B01/B02 berichtet, historische Angaben weiterhin offen / current issue context read without invented reproduction. |
| CHK-018 | Pass — Spec Zuständigkeitsgrenzen/Contracts: TinyCalc, Framework, Host und Reader getrennt / responsibilities and evidence types separated. |
| CHK-019 | Pass — Git-Diff begrenzt; alte Protokolle und Serienartefakte unangetastet / historical evidence and lifecycle files preserved. |
| CHK-020 | Pass — Verfassung/14 Presets/Security-Matrix abgeglichen; N/A-/Open-Owner/Trigger erhalten / applicability and existing approval model preserved. |

## Ergebnis / Result

Dokumentennachprüfung vom 18.10.2026: 20/20 Punkte geprüft; gefundene Inkonsistenzen direkt korrigiert und oben je Prüfpunkt belegt. Zehn Anforderungen, acht Abnahmen, 17 Pflichtfamilien und beide CQ-Antworten erhalten. Die Planung liegt bereits vor; kein erneuter Plan-Lauf erforderlich allein wegen des früheren Clarify-Textes. Ownerprüfung und ein gesonderter Tasks-/Umsetzungsauftrag bleiben getrennt. Kein Produktnachweis, Commit/Push oder nachfolgendes Kommando ausgeführt.

*Document recheck on 18 October: all 20 instructions completed with corrected findings and row-level evidence above. Preserve all requirements, criteria, families and answers. Planning already exists; stale Clarify wording does not require rerunning it. Owner review and separate task/implementation authority remain distinct. No product proof, Git delivery or next workflow command executed.*

## Governance-Nachprüfung 2026-10-21 / Governance Recheck 2026-10-21

Frühere Checkboxen und Ergebnisse bleiben historische Dokumentenprüfungen. Die folgenden neuen Punkte sind bis zum unabhängigen Review offen, keine Produktabnahme.

*Earlier checks remain historical document reviews. New checks below are pending independent review, not product acceptance.*

- [x] GOV007-01 Sind GA-007-01–03 in Spec, Plan und T003/T005/T047/T048 vollständig abgebildet? Durchführung: Quellen 3.4.4/0.1.5 und alle 50 Kontroll-IDs mit der Impact-Matrix vergleichen; Statusachsen, Metadatenpflicht und Nachweisgrenzen prüfen. Bestanden nur ohne ausgelassene Kontrolle oder übertragene Produkt-Erfüllung.
  *Are GA-007-01–03 fully mapped? Compare checked sources and all 50 IDs with the impact map, status axes, metadata and proof boundaries. Pass only without missing controls or transferred product fulfilment.*
- [x] GOV007-02 Bleiben Intake, CQ-001/CQ-002, zehn Anforderungen, acht Kriterien, 17 Familien und mindestens 364 Wege je Plattform erhalten? Durchführung: Diff und Quellenhashes prüfen, 60 offene Aufgaben zählen; historische Abnahmen und fehlende native Nachweise nicht umdeuten. Ein Dokumenten-Pass bestätigt keine Screenreader-Kompatibilität.
  *Are intake, clarified decisions and the complete baseline preserved? Check diffs/hashes and 60 unchecked tasks; do not reinterpret history or missing native evidence. A document pass proves no screenreader compatibility.*

Dokumentennachprüfung am 21.10.2026 durch den unabhängigen Reviewer: GOV007-01 und GOV007-02 nach Korrektur IR001 erfüllt. Nur Dokumentenqualität, keine Umsetzung oder Produkt-/Screenreader-Abnahme. Hashgebundener Nachweis: `specs/intake-authoring-operations/44f5901d-e5d9-42b8-b975-4693195d034f/independent-review.json`.

*Independent document recheck on 21 October 2026: both new checks passed after correction IR001. This confirms document quality only, not implementation or product/screenreader acceptance. The separate review evidence binds the final source hashes.*
