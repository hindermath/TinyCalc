# Spezifikations-Qualitätscheckliste / Specification Quality Checklist: Terminal.Gui-2.x-Migration

**Zweck / Purpose**: Vollständigkeit und Qualität vor der nächsten Spec-Kit-Phase prüfen / Validate completeness and quality before the next Spec Kit phase
**Erstellt / Created**: 2026-08-30
**Feature / Feature**: [spec.md](../spec.md)
**Bindender Intake / Binding intake**: `requirements/intakes/active/Lastenheft_TerminalGui_Migration.md`
**Akzeptierter SHA-256 / Accepted SHA-256**: `fd59040e8bb736b0944e74ab855b72a3a8b843487ae64509926d4a9e79c68160`
**Validierungsdurchlauf / Validation iteration**: 1 von / of 3
**Ergebnis / Result**: Bestanden / Passed

## Inhaltsqualität / Content Quality

- [x] Keine frei erfundenen Implementierungsdetails; die genannten Paket-,
  Lifecycle- und Tastaturbezeichner sind bindende Migrations- und
  Akzeptanzgrenzen aus dem Intake. / No invented implementation details; named
  package, lifecycle, and keyboard identifiers are binding migration and
  acceptance boundaries from the intake.
- [x] Auf Nutzerwert und fachlichen Bedarf ausgerichtet. / Focused on user value
  and business needs.
- [x] Für nicht technische Stakeholder und Lernende auf CEFR B2 verständlich;
  notwendige Fachbegriffe werden erklärt. / Written for non-technical
  stakeholders and learners at CEFR B2, with required terms explained.
- [x] Alle Pflichtabschnitte sind vollständig. / All mandatory sections are
  completed.

## Anforderungsvollständigkeit / Requirement Completeness

- [x] Keine offenen Klärungsmarker sind vorhanden. / No clarification markers
  remain.
- [x] Anforderungen sind testbar und eindeutig. / Requirements are testable and
  unambiguous.
- [x] Erfolgskriterien sind messbar. / Success criteria are measurable.
- [x] Erfolgskriterien beschreiben überprüfbare Ergebnisse; unvermeidbare
  technische Namen stehen nur in den bindenden Migrationsanforderungen und
  Evidenzzuordnungen. / Success criteria describe verifiable outcomes;
  unavoidable technical names remain in binding migration requirements and
  evidence mappings.
- [x] Alle Akzeptanzszenarien sind definiert. / All acceptance scenarios are
  defined.
- [x] Grenz- und Fehlerfälle sind identifiziert. / Edge and error cases are
  identified.
- [x] Scope und Nicht-Ziele sind klar begrenzt. / Scope and non-goals are clearly
  bounded.
- [x] Abhängigkeiten und Annahmen sind identifiziert. / Dependencies and
  assumptions are identified.

## Feature-Bereitschaft / Feature Readiness

- [x] Alle funktionalen Anforderungen besitzen klare Abnahmekriterien oder
  Evidenzzuordnungen. / All functional requirements have clear acceptance
  criteria or evidence mappings.
- [x] Nutzer-Szenarien decken die Hauptabläufe ab. / User scenarios cover the
  primary flows.
- [x] Das Feature erfüllt bei erfolgreicher Abnahme die messbaren Ergebnisse.
  / The feature meets the measurable outcomes when acceptance passes.
- [x] Keine frei wählbare Architekturentscheidung wird in der Spezifikation
  vorweggenommen; die zwei im Intake erlaubten 2.x-Lifecycle-Varianten bleiben
  der Planung überlassen. / No discretionary architecture choice leaks into
  the specification; planning retains the two 2.x lifecycle options allowed by
  the intake.

## Intake- und Traceability-Prüfung / Intake and Traceability Review

- [x] Intake-Pfad, Ready-Review und akzeptierter SHA-256 stimmen mit dem
  autonomen Run-State überein. / Intake path, Ready review, and accepted SHA-256
  match autonomous run state.
- [x] R-TG-TC-01 bis R-TG-TC-05 sind `Applicable`; R-TG-TC-06 bleibt
  `FollowUp` in einem separaten PR. / R-TG-TC-01 through R-TG-TC-05 are
  `Applicable`; R-TG-TC-06 remains a separate pull-request `FollowUp`.
- [x] AK-TG-TC-01 bis AK-TG-TC-06 sind einzeln auf Anforderungen und Evidenz
  abgebildet. / AK-TG-TC-01 through AK-TG-TC-06 each map to requirements and
  evidence.
- [x] Core-Migration, Formeländerungen, Rename, neue Features, FakeDriver-Tests
  und weitere Intakes bleiben außerhalb des Scopes. / Core migration, formula
  changes, rename, new features, FakeDriver tests, and other intakes remain out
  of scope.
- [x] Die geordnete Seriengrenze bleibt erhalten: Feature 003 wird separat vor
  Feature 004 abgeschlossen. / Ordered series scope is preserved: Feature 003
  completes separately before Feature 004.
- [x] Die Specify-Phase autorisiert keine Implementierung, Commits, Pushes,
  Pull Requests, Merges, Intake-Serienänderungen oder Folgefeatures. / The
  Specify phase authorizes no implementation, commits, pushes, pull requests,
  merges, intake-series changes, or follow-up features.

## Governance- und Evidenzprüfung / Governance and Evidence Review

- [x] TinyCalc-Level-2-Registry, .NET-10/C#-MSL-Entscheidung und
  C#/.NET-Secure-Coding sind festgehalten. / TinyCalc Level-2 registry, .NET
  10/C# MSL decision, and C#/.NET secure coding are recorded.
- [x] NIST SSDF und CWE Top 25 sind `Applicable` und nicht als `N/A`
  behandelt. / NIST SSDF and CWE Top 25 are `Applicable` and not treated as
  `N/A`.
- [x] STRIDE, CAPEC-153, CAPEC-538, Dependency Audit, SBOM und SLSA besitzen
  konkrete Evidenzpfade. / STRIDE, CAPEC-153, CAPEC-538, dependency audit,
  SBOM, and SLSA have concrete evidence paths.
- [x] OWASP ASVS, VEX, AI-SBOM, Zero Trust, BSI C3A und BSI C5 besitzen jeweils
  ein begründetes `N/A` mit Wiedervorlage. / OWASP ASVS, VEX, AI-SBOM, Zero
  Trust, BSI C3A, and BSI C5 each have a justified `N/A` and re-evaluation
  trigger.
- [x] WCAG 2.2 AA, Tastatur, Fokus, lineare Textalternative und die A11Y-
  Evidenzdatei sind festgelegt. / WCAG 2.2 AA, keyboard, focus, linear text
  alternative, and the accessibility evidence file are defined.
- [x] Deutsch zuerst, Englisch danach, CEFR B2 und Lernzielgruppe ab dem ersten
  Ausbildungsjahr sind durchgängig berücksichtigt. / German-first,
  English-second, CEFR B2, and the first-year learner audience are consistently
  covered.
- [x] Script-Parität und Agent-Parität sind mit Begründung und Wiedervorlage
  `N/A`; die gepflegten Agentenflächen sind vollständig genannt. / Script parity
  and agent parity are justified `N/A` decisions with triggers; all maintained
  agent surfaces are named.
- [x] Die exakte Acht-Preset-Matrix und die autonome Run-ID sind dokumentiert;
  konkrete Modellnamen oder Provider-Zugangsdaten stehen nicht in der Spec. /
  The exact eight-preset matrix and autonomous run ID are documented; no
  concrete model names or provider credentials appear in the spec.
- [x] Genau eine Dokumentationswirkung (`UpdateRequired`) enthält Zielgruppen,
  Familien, Leserpfade, Quelle/Owner, Navigation, Klasse, Sprache, Plattform,
  Distribution, Home-Sync, Evidenz und Wiedervorlage. / Exactly one
  Documentation Impact decision (`UpdateRequired`) covers all required fields.
- [x] Rot-Grün-Aufräumen, mindestens 70 Prozent Changed-Code-Coverage und das
  80-Prozent-Ziel sind blockierende Liefergates. / Red-green-refactor, at least
  70% changed-code coverage, and the 80% target are delivery gates.

## Gate-Ergebnis / Gate Result

| Prüfung / Check | Ergebnis / Result | Evidenz / Evidence |
|---|---|---|
| Pflicht-Platzhalter / Mandatory placeholders | Pass | Keine Template-Platzhalter verbleiben / no template placeholders remain |
| Klärungsbedarf / Clarification need | Pass | Kein offener Marker; keine vermeidbare Frage / no open marker or avoidable question |
| Intake-Abdeckung / Intake coverage | Pass | Sechs Anforderungen und sechs Akzeptanzkriterien vollständig abgebildet / six requirements and six acceptance criteria mapped |
| Governance-Abdeckung / Governance coverage | Pass | Anwendbarkeit, Implementierungsstand, Owner/Review, Risiko, Evidenz und Trigger dokumentiert / applicability, implementation, owner/review, risk, evidence, and trigger documented |
| Scope-Schutz / Scope protection | Pass | Produktänderungen auf zwei TUI-Dateien begrenzt; Nachweise getrennt / product changes limited to two TUI files; evidence separated |
| Sprach- und A11Y-Qualität / Language and A11Y quality | Pass | DE-first/EN-second, CEFR B2, semantischer und linearer Text / semantic linear text |

## Hinweise / Notes

- Die Qualitätsprüfung bestand im ersten Durchlauf. Es sind keine Änderungen
  aus einem zweiten oder dritten Durchlauf erforderlich. / Quality validation
  passed on the first iteration; no second or third iteration is required.
- Diese Checkliste bewertet die Spezifikationsqualität. Build-, Test-, Smoke-,
  Coverage-, A11Y-, Security-, SBOM- und SLSA-Belege entstehen erst in den
  später autorisierten Phasen und dürfen dort nur bei vollständigem Nachweis
  als erfüllt markiert werden. / This checklist validates specification
  quality. Build, test, smoke, coverage, accessibility, security, SBOM, and
  SLSA evidence belongs to later authorized phases and may be marked fulfilled
  only with complete proof.
- R-TG-TC-06 ist kein offener Spezifikationspunkt. Es ist bewusst als separater
  Follow-up-Lieferumfang festgelegt. / R-TG-TC-06 is not an open specification
  issue; it is deliberately a separate follow-up delivery scope.
