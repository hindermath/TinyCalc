# Abnahme: Zwischenstand, nicht Accepted / Interim acceptance, not Accepted

## Deutscher Bewertungsblock

Stand 2026-10-10. Owner Thorsten; Feature 006. Dies ist eine transparente
Zwischenbewertung für T076/T077, keine Produktfreigabe, Risikoakzeptanz oder
Completion-Erklärung. Specify/Plan/Tasks und Folgefeatures werden nicht gestartet.

| Kriterium | Tatsächlicher Stand | Offene Abschlussgrenze |
|---|---|---|
| SC-001 | Lokal 364/364 automatisierte Pfade, 462 serialisierte unabhängige Assertions; [macOS](platforms/macos/local-build105.md) | vollständige 1.092 Tupel, native Plattformen und finale Bindung |
| SC-002 | Ungefilterte Solution 669 Pass/0 Fail/0 Skip, minimale test-first Produktfixes | null offene In-Scope-Fehler unabhängig bestätigen, gemeinsamer finaler Commit |
| SC-003 | Echte macOS-PTY-Sitzungen 80x24/120x40; [native CI](platforms/native-ci-38077169518.md) je 671 Pass, 364 Pfade, 462 Assertions | dieselbe finale Vertrags-/Headbindung über alle Plattformen |
| SC-004 | Negative Dokument-/Test-/Quellen-/Klassen-/Hash-/Historienfixtures und öffentliche Datei-Integration grün | finale unabhängige Beurteilung, keine Fixture als Produktbeleg zählen |
| SC-005 | 58 Pin-/Impact-/Historienfälle grün, vier genehmigte Locks unverändert, null Upgrades | keine offene Paketfreigabe; spätere Updates brauchen separaten genehmigten Plan |
| SC-006 | Partial-/Skip-/wrong-class-/Unit-/Smoke-only-Schutz, identische zero-write Vorschau | vollständige Gate-Dateien mit echten Review-/Human-/Providerartefakten |

[US1](story-us1.md), [US2](story-us2.md), [US3](story-us3.md) und
[US4](story-us4.md) unterscheiden lokale fachliche Abdeckung, Validatorfixtures
und endgültige Abnahme. [Coverage](coverage.md) erreicht 97,02 %; 100 %
Pfadabdeckung und Zeilenabdeckung sind verschiedene Größen. Alte Run-Digests
werden nicht auf neue Dokumentations- oder Liefercommits umetikettiert.

Verbleibende Pflichtentscheidungen/Nachweise, Owner Thorsten:

Der [vorbereitete gemeinsame Bedienlauf](owner-acceptance-session.md) enthält
synthetische Testdaten, erwartete Ergebnisse F01–F14, ein separates VoiceOver-
Protokoll und die spätere Ownerentscheidung. Er ist noch nicht ausgeführt.
Die technische Übergabe nennt offene finale Nachweise; Vorbereitung ist keine
Freigabe. Daybreak-Anmeldung ist keine Voraussetzung dieses Feature-Laufs.

1. Tatsächliche menschliche VoiceOver-Bedienung gemäß
   [A11Y-Zuordnung und Ablauf](../../../docs/accessibility/006-tui-functional-contract.md):
   Person, Datum, OS/Terminal/VoiceOver, Head/Revision, Beobachtung und Befund
   erfassen. Automation kann diese Pflicht nicht übernehmen.
2. Unabhängiger read-only Review ausdrücklich genehmigt und
   [durchgeführt](../../../docs/security/secure-development/006-tui-functional-contract/independent-review.md).
   JSON-Lesegrenze nach echtem Rot korrigiert; Delta unabhängig geprüft.
3. Temporäre axe-Umgebung ausdrücklich genehmigt und
   [ausgeführt](../../../docs/accessibility/006-docfx-axe.md). Fünf Seiten ohne
   automatische Verstöße oder fehlende Artikel-Linkziele nach gezielter Korrektur;
   manuelle axe-Prüffälle bleiben als solche erhalten. Kein NuGet-Upgrade.
4. Nach vollständiger technischer und unabhängiger Abnahme: separate Owner-
   Produktentscheidung. Der erfolgte Owner-Planreview ersetzt sie nicht.

Native CI wird am tatsächlichen PR-Head geprüft. Fehlgeschlagene technische
Gates werden korrigiert; formaler Admin-Bypass macht sie nicht gültig.
Claude-Providerfehler ist ausdrücklich zurückgestellt, nicht bestanden.
Wiedervorlage: vor Accepted/Merge; bis dahin bleibt PR #104 Draft.
Keine Intake-/Serienpromotion, Archivierung oder Paketaktualisierung.

## English assessment

This is an interim assessment of all six criteria, not Accepted, risk acceptance
or feature completion. Actual local proof covers every mandatory macOS path,
669 passing tests and 97.02% changed-line coverage. Validator/policy fixtures
prove rejection strength, not native, human or independent product acceptance.
Final native results, one actual head/revision, independent reviews and complete
gate artefacts remain mandatory; historical results are never relabelled.

The owner must still provide actual human VoiceOver evidence and later the
separate product-acceptance decision. Independent read-only review and temporary
external axe tooling were expressly approved and executed. The JSON resource
boundary and DocFX failures were corrected with targeted proof. Five sampled
pages have no automatic axe violations or missing article targets; manual
review items remain explicit. Final common-head proof is still due. Deferred
Claude provider failure is not a pass. Keep the PR draft until material gates
close; formal-rule bypass cannot replace them. No intake promotion, package
upgrade or follow-up feature is authorised by this interim assessment.

The linked owner-session guide prepares synthetic data, fourteen concrete steps,
expected results, a separate VoiceOver record and the eventual owner decision.
It has not been executed and grants no acceptance. Technical handover retains
all missing final evidence; Daybreak registration is not a feature prerequisite.
