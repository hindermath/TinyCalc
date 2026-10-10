# Produktabnahme und Liefergrenze / Product acceptance and delivery boundary

## Aktueller Abschlussstand 11.10.2026 / Current closeout state

Die folgenden älteren Zwischenstände bleiben historische Belege. Maßgeblich
sind jetzt [Thorstens tatsächliche Produkt-/VoiceOver-/HTML-Abnahme](human-acceptance-20261011.md)
auf dem eingefrorenen Prüfstand und der [Lieferabschluss](delivery-closeout.md).
Keine erneute Specify-/Plan-/Tasks-Phase und kein Folgefeature.

| Kriterium | Tatsächlich belegtes Ergebnis |
|---|---|
| SC-001 | 17 Familien, 364 Pfade je nativem OS, 1092 Tupel und 1386 Assertions insgesamt; keine Filter-/Skip-Lücke |
| SC-002 | Je OS 671 Pass/0 Fail/0 Skip, echte test-first Produktfixes, unabhängiger Review und Owner: keine offenen In-Scope-Produktfehler |
| SC-003 | Linux/Windows Push-CI 38086468591 und macOS exakt 737348d; echte PTY 80x24/120x40; separater Humanlauf |
| SC-004 | Echte Rot-Grün-Provenienz und vollständige negative Validator-/Historien-/Source-/Hash-Integration; Fixtures zählen nicht als Produkttupel |
| SC-005 | Vier unveränderte genehmigte Locks, kohärenter Graph, keine Upgrades; ausschließlich veraltete Autoritätsreferenz erneuert |
| SC-006 | Fail-closed Vollmatrix-/Gateprüfung, schreibfreie Launcher/WhatIf; finaler tatsächlicher Gate-Exit am Lieferhead bleibt erforderlich |

Owner-Produktabnahme: **Accepted für den unveränderten Prüfstand 737348d,
Binary 1.6.17.116, Revision 2**. Funktion, VoiceOver und HTML sind tatsächlich
von Thorsten gemeldet, nicht durch Automation ersetzt. Fachlicher unabhängiger
Review ist erfüllt. Der zusätzliche Claude-Providerfehler bleibt Nicht-Pass;
ein etwaiger formaler Providercheck-Bypass ersetzt keinen fachlichen Review.

T081/finaler Merge-/Sync-Nachweis bleibt bis zur tatsächlichen Ausführung offen.
Die ignorierten Runtime-Originale und PR #104 erfassen dessen Abschluss am
eingefrorenen Lieferhead, ohne selbstreferenzielle neue Belegcommits.

*The historical interim assessment below is superseded by actual owner acceptance
of the unchanged frozen candidate, complete native proof and independent review.
All six criteria are mapped above. Final exact-head technical validation and
merge/sync are still required. Preserve human and historical execution bindings;
runtime originals and PR #104 record actual completion without a commit loop.*

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
