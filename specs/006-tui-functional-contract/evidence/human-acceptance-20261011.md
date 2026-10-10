# Menschliche Produktabnahme / Human product acceptance

## Deutscher Originalnachweis und Einordnung

Quelle: ausdrückliche Meldungen von Thorsten im zugehörigen Codex-Chat, keine
automatisch erfundenen Beobachtungen. Person: Thorsten. Funktionslauf:
10.10.2026, F01–F14 **Pass**, tatsächlich 134x27 und 80x24, Befunde: keine.
Thorsten hat Feature 006 ausdrücklich aufgrund der Nachweise und seiner
Bedienprüfung abgenommen; offene In-Scope-Fehler: keine.

Prüfcommit: `737348debf6807d2d8b49e620d2dc068b62bf731`.
Binary: `1.6.17.116`; Vertragsrevision: `2`.
Binary-SHA-256:
`9330a6ebd0beaf9151369da4013dad55bd866a03cc787388fd77c2c592dcd9d7`.
Vertragsdigest:
`9fe07a0f4a1e8cfaf6b50f1054ed2fd60eafed4061e855644e8d762a923acce4`.
Die vollständige kopierte Releaseausgabe mit 51 gehashten Dateien bleibt lokal
unter `tests/MicroCalc.Tui.Tests/TestResults/voiceover-737348debf68/` erhalten.

Zeit des menschlichen A11Y-Laufs: Sonntag, **11.10.2026, 00:14:48 Europe/Berlin**.
macOS 27.0.1; Terminal 2.15; Safari 27.0.1; VoiceOver 27.

| Prüfung | Tatsächlich gemeldetes Ergebnis |
|---|---|
| VoiceOver 120x40 | `stty`: `40 120`; V1–V6 Pass |
| VoiceOver 80x24 | insgesamt ebenfalls Pass; keine zusätzlichen Einzelbeobachtungen gemeldet |
| HTML H1–H4 je angeforderter Seite | Pass; Befunde: keine |

V1 war zunächst als nicht ausgefüllter Vorlagenplatzhalter enthalten. Thorsten
hat danach ausdrücklich **„V1: Pass“** gemeldet. Es wird kein vorgelesener
Wortlaut nachträglich erfunden. H4 ist die angeforderte visuelle Prüfung, keine
numerische Kontrastmessung und kein WCAG-Zertifikat.

Die HTML-Meldung „je Seite“ bezieht sich auf die sechs zuvor angeforderten Seiten:

- `specs/006-tui-functional-contract/evidence/owner-acceptance-session.html`
- `specs/006-tui-functional-contract/evidence/acceptance.html`
- `specs/006-tui-functional-contract/evidence/platforms/native-ci-38080340767.html`
- `specs/006-tui-functional-contract/evidence/voiceover-candidate.html`
- `docs/project-statistics.html`
- `api/MicroCalc.Core.Engine.MicroCalcEngine.html`

In Thorstens Abnahmesatz waren Binary-Hash und Versionsnummer in die Felder
„Commit“ und „Vertragsrevision“ geraten. Die explizite Prüfstandzeile und spätere
Bestätigung binden eindeutig den oben genannten Commit und Revision 2. Diese
Zuordnung berichtigt Identifikatoren, nicht seine Abnahmeentscheidung.

Spätere reine Abschlussdokumentation, technische Belegreferenzen, Statistik und
Versionsmetadaten sind kein erneut von Thorsten getesteter Produktstand. Der
Liefervergleich muss unveränderte Produktquellen nachweisen und die technischen
Pflichtläufe an seinen eigenen endgültigen Commit binden. Keine Umetikettierung
dieser menschlichen Prüfung und kein automatischer Abschluss des A11Y-Intakes.

## English evidence and limits

Thorsten directly reports F01–F14 passing on 10 October at actual 134x27 and
80x24, no findings, and explicitly accepts Feature 006. His human accessibility
session is dated 11 October 2026, 00:14:48 Europe/Berlin, using macOS 27.0.1,
Terminal 2.15, Safari 27.0.1 and VoiceOver 27. V1–V6 pass at verified 120x40;
80x24 also passes overall. V1 was expressly clarified after an unfilled template.
H1–H4 pass per requested page, without findings. No spoken transcript or numeric
contrast measurement is invented. The visual check is not WCAG certification.

The immutable commit, binary hash, version and revision above resolve misplaced
identifiers in the acceptance paragraph without changing the owner's decision.
The 51-file frozen output remains preserved. Later documentation/version-only
delivery changes require unchanged-product-source evidence and their own final
technical binding, not relabelling this human session. This does not promote
the intake series, complete another feature or authorise dependency upgrades.
