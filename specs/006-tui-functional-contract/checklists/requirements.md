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

## Nachprüfung nach Plan und Checklist / Reassessment after plan and checklist

2026-10-07: Der frühere Autorenabgleich oben bleibt historisch, ist aber keine aktuelle Aussage „keine offenen Klärungen“. Die Durchführung der neuen Anforderungscheckliste findet RQ-001–RQ-003: Slash-Konflikt, zusätzliche/widersprüchliche historische Hilfeangebote und unvollständige angebotsspezifische Formelsemantik. Spec/Plan/Vertragsdesign präzisieren die übrigen gefundenen Textlücken; diese Quellenfragen und das menschliche Plan-Gate bleiben Open. Die komplette Baseline bleibt erhalten, keine Produktabnahme oder unabhängiger Review wird behauptet.

*The earlier author review is historical, not a current no-open-questions claim. The new review identifies three source findings; other wording gaps are corrected, while source and human approval remain Open without reducing scope.*

Klärungsfortschreibung: Nutzerantwort A löst die Slash-Frage RQ-001 kontextabhängig; RQ-002/RQ-003 bleiben offen. Die Entscheidung steht im Clarifications-Abschnitt der Spec und ist in den Designartefakten integriert. / User answer A resolves slash by context; the other source questions remain Open.

Zweite Klärungsfortschreibung: Antwort A erhält alle historischen Hilfeangebote mit getrennten Kontexten; RQ-002 ist geklärt, RQ-003 bleibt offen. / The second answer A resolves historical offers without removal; formula semantics remains Open.

Dritte Klärungsfortschreibung: Antwort A bestimmt FACT für ganze Argumente 0 bis 33, `FACT(0)=1`, sonst verständlicher Fehler ohne Abschneidung. RQ-003 ist teilweise geklärt; übrige Formelsemantik und Produktausführung bleiben offen. / The third answer A clarifies strict FACT arguments and errors; remaining formula semantics and product proof are pending.

Vierte Klärungsfortschreibung: Operatorbindung durch Antwort A geklärt, in Spec und Design integriert. RQ-003 bleibt für numerische Definitions-/Ergebnisgrenzen Open; keine Produktabnahme.

*The fourth answer A clarifies operator binding in the specification and design. Numeric boundaries keep RQ-003 Open; this is not product acceptance.*

Fünfte Antwort A: Nur endliche reelle Ergebnisse; Definitionsfehler, Überläufe und NaN/Unendlich ergeben verständliche Fehler statt erfolgreicher numerischer Zellwerte. Die vier Fehlerorakel der Spec und endliche Kontrollfälle bei späterer Umsetzung test-first binden; keine Produktprüfung hier. Alle fünf Fragen dieser Nachprüfung sind beantwortet. RQ-003 bleibt für fehlende Quellenbindung von SIN/COS/ARCTAN-Winkeleinheit, LN/LOG-Basis und ROUND-Oberpräzision Open; separat klären, nicht aus aktuellem Code ableiten. Menschliche Freigabe und Quellen-/Produktnachweise bleiben ausstehend.

*The fifth answer A requires finite real results and clear numeric failures. Bind the specification's four error cases and finite controls test-first in future authorised work; no product tests run here. Five follow-up questions are answered. Trigonometric units, logarithm bases and ROUND's upper precision remain deferred source bindings under RQ-003; human clearance and source/product proof remain pending.*

2026-10-08, erste Antwort A dieses Klärungslaufs: SIN/COS-Eingabe und ARCTAN-Ausgabe in Bogenmaß; Orakel und Quellenbindung stehen im trigonometrischen Vertrag der Spec. Kein neues π-Syntaxangebot, kein Produktnachweis. RQ-003 bleibt für LN/LOG-Basis und ROUND-Oberpräzision Open.

*The first answer A in this clarification run binds SIN/COS inputs and ARCTAN output to radians, with specification oracles and no new π syntax or product proof. Logarithm bases and ROUND's upper precision keep RQ-003 Open.*

2026-10-08, zweite Antwort A: LN zur Basis e, LOG zur Basis 10; Null und negative Argumente für beide Funktionen als verständliche Fehler. Pflichtorakel und reviewte Toleranzen gemäß Logarithmusvertrag der Spec. Der offene LN/LOG-Teilbefund ist supersediert; RQ-003 bleibt nur für die obere ROUND-Präzision Open. Kein Produktnachweis oder menschliche Planfreigabe.

*The second answer A binds LN to base e and LOG to base 10, with clear zero/negative errors and specification oracles. This supersedes the logarithm source gap; only the upper ROUND precision keeps RQ-003 Open. Product proof and human plan clearance are pending.*

2026-10-08, dritte Antwort A: ROUND-Präzision nichtnegativ gegen null abschneiden, dann 0 bis 15 einschließlich; größere Werte Fehler ohne Begrenzung. Negative Rohargumente einschließlich -0.5 Fehler vor Abschneidung; Halbwerte weiterhin weg von null. Orakel gemäß Spec. RQ-001–RQ-003-Anforderungslücken Resolved; frühere Open-Fortschreibungen sind supersedierte Historie. Keine Produktabnahme oder menschliche Planfreigabe.

*The third answer A binds ROUND to truncated nonnegative precision 0–15 with clear larger/negative-raw errors and unchanged midpoint rounding. Specification oracles resolve the identified source findings; earlier Open entries are history. All 36 requirement-quality items pass, not product acceptance. Qualified dated role/scope evidence and owner confirmation are still required for human clearance; no implementation or delivery authority is granted.*

**Aktueller Governance-Stand 2026-10-08:** Owner bestätigt privates persönliches Projekt und supersediert die zusätzliche externe qualifizierte Rollen-/Scope-Review-Pflicht. Frühere Aussagen zu diesem fehlenden Plan-Gate sind historisch überholt. Repository bleibt öffentlich; historische regulatorische Einzelstatus und Neubewertung bei konkreten Scope-Triggern bleiben erhalten. 36 Anforderungsqualitäts-Punkte Pass, kein Produktnachweis. Plan als Dokumenten-PR zur Owner-Prüfung liefern; keine Implementierung, kein Merge. Technische Security-/Preflight-/A11Y-/Plattform-Gates unverändert.

*Current governance state on 2026-10-08: the owner's personal-project decision supersedes the added external qualified review prerequisite and earlier claims that this blocks the plan. Repository visibility remains public; historical applicability dispositions and concrete-trigger reassessment remain intact. All 36 requirement-quality items pass, not product proof. Submit the documentation PR for owner review, without implementation or merge; technical gates are unchanged.*
