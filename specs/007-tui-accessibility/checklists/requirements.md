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

## Ergebnis / Result

Dokumentenprüfung nach Clarify: 20 von 20 Punkten erfüllt; beide fachlichen Entscheidungen sind durch Thorsten geklärt und konsistent eingearbeitet. Vollständige Aufnahme von zehn Anforderungen, acht Abnahmekriterien und 17 Funktionsfamilien; kein Produktnachweis ausgeführt. Bereit für separat beauftragtes `$speckit-plan` mit erneuter Frischeprüfung, keine Implementierungsfreigabe. Kein nachfolgendes Kommando gestartet. Der optionale Commit-Hook ist gemäß Nutzerauftrag übersprungen.

*Document review after Clarify: all 20 items satisfied; Thorsten resolved both decisions and they are integrated consistently. All ten requirements, eight acceptance criteria and 17 functional families are covered, with no product verification executed. Ready for separately authorised planning after renewed freshness checks, not implementation approval. No follow-up command started; optional commit hook skipped as requested.*
