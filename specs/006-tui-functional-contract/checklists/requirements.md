# Qualitätscheckliste: TUI-Funktionsabnahme / Specification Quality Checklist: TUI Functional Acceptance

**Zweck / Purpose:** Vollständigkeit und Qualität vor Planung prüfen / Validate completeness and quality before planning.
**Erstellt / Created:** 2026-10-07
**Feature:** [spec.md](../spec.md)

## Inhaltsqualität / Content Quality

- [x] Keine neue Implementierungsentscheidung; technische Namen sind bindende Intake-/Governance-Grenzen. / No new implementation design; technical names are binding intake/governance constraints.
- [x] Nutzerwert und fachliche Bedürfnisse sind beschrieben. / User value and business needs are explicit.
- [x] Begriffe sind für nichttechnische Leser und Auszubildende erklärt. / Terms support non-technical readers and apprentices.
- [x] Alle Pflichtabschnitte der zusammengesetzten Vorlage sind ausgefüllt. / All mandatory composed-template sections are filled.

## Anforderungsvollständigkeit / Requirement Completeness

- [x] Keine offenen Anforderungsklärungen; IAD001–IAD005 übernommen. / No unresolved requirement clarifications; all five intake decisions retained.
- [x] FR-001–FR-017 sind eindeutig und prüfbar. / Every functional requirement is testable and unambiguous.
- [x] Alle sechs Erfolgskriterien sind messbar und entsprechen AC-001–AC-006. / Six measurable outcomes map to the intake acceptance criteria.
- [x] Erfolgskriterien beschreiben Ergebnisse; Plattformen sind vorgegebene Abnahmegrenzen. / Outcomes avoid new implementation design; platform proof is a binding acceptance constraint.
- [x] Vier Nutzungsszenarien enthalten unabhängige Prüfungen und Erfolgs-/Abbruch-/Fehlerfälle. / Four stories include independent checks and relevant outcome paths.
- [x] Grenzfälle, Scope, Nicht-Ziele und Quellen-/Konfliktregel sind vollständig. / Edge cases, scope, non-goals and source/conflict rules are complete.
- [x] Abhängigkeiten, Reihenfolge, Impact-Matrix und versionsneutraler Preflight erhalten. / Preserve dependencies, order, impact matrix and version-neutral preflight.
- [x] Alle 17 Baseline-Familien, Tastatur-/Menü-/Paletten-/Dialog-/Hilfepfade und 16 Funktionen übertragen. / Transfer all 17 baseline families, offered interaction paths and 16 functions.

## Planungsbereitschaft / Feature Readiness

- [x] Jede FR ist in der Traceability-Tabelle mit Abnahme und Prüfansatz verbunden. / Every FR maps to acceptance and a check approach.
- [x] Szenarien decken Bedienung, Daten/Hilfe, Drift und dauerhafte Regression ab. / Stories cover operation, files/help, drift and lasting regression.
- [x] Vollständigkeit, Plattformbindung und negative Abschlussfälle sind messbar. / Completeness, platform binding and negative completion checks are measurable.
- [x] Keine API-/Code-/Paketänderung oder ungefragte Funktion spezifiziert. / No unrequested API, code, dependency or capability change.
- [x] Deutsch und Englisch sind vollständig, textorientiert und auf CEFR-B2-Lernverständlichkeit geprüft. / Both language tracks are complete, text-oriented and reviewed for B2 learner clarity.
- [x] Anwendbarkeit ist getrennt von Erfüllung; künftige Produktnachweise bleiben Not Assessed. / Separate applicability from fulfilment; future product evidence remains Not Assessed.

## Prüfnotizen / Review Notes

Prüfung durch Codex am 2026-10-07: Intake-Hash und aktueller Ready-Serienreview mit Bash/PowerShell validiert; Scope und Baseline semantisch abgeglichen. FR/SC-Abdeckung, Aliaslisten, Quellenkonflikte, Nicht-Ziele und alle fünf Impact-Klassen geprüft. Technische Vorgaben wie C#, Terminal.Gui, Plattformen und Nachweistools sind übernommene Anforderungen, keine neu gewählte Implementierung. Keine Produktabnahme behauptet.

*Codex reviewed intake/review bindings and complete semantic coverage on 7 October 2026. Technical names are inherited constraints, not newly chosen implementation details. No product acceptance is claimed.*

Clarify am 2026-10-07: Eine Frage gestellt und mit Option A beantwortet. FR-003, SC-001 und das Nachweisobjekt verlangen automatisierte Tests für alle automatisierbaren Funktionswege; begründete menschliche Nachweise sind ergänzend. Die 17 Familien, 17 FR und sechs SC bleiben erhalten. Die Entscheidung steht einmal im Klärungsprotokoll und ist in beiden Sprachen integriert.

*Clarify asked and resolved one question on 7 October 2026. FR-003, SC-001 and the evidence entity require automation for every automatable functional path with supplementary human assessment. All 17 families, 17 FR and six SC remain intact; the decision is recorded once and integrated bilingually.*

Regulatorischer Quellenabgleich erhält die einzelnen technischen Entscheidungen aus `docs/security/regulatory-applicability.md` vom 2026-09-08. Thorsten klärt verbleibende Human-only-/Werkzeug-/Organisationsfragen und Scope-Änderungen spätestens im Plan-Gate; Planung nimmt Aktualitätsprüfung, qualifizierte Prüfung und betroffene Gates auf. Funktionale Scope-Fragen sind damit geklärt; technische Gestaltung, präzise Evidenzformate und regulatorischer Follow-up gehören in die Planung.

*Preserve individual technical screening decisions from the dated regulatory record. Thorsten owns remaining human-only, tooling, organisation and scope questions at the plan gate. Planning includes freshness and qualified review. Functional scope is clarified; technical design, exact evidence formats and regulatory follow-up belong to planning.*
