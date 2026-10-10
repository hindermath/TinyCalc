# Eingefrorener VoiceOver-Prüfstand / Frozen VoiceOver candidate

## Deutscher Nachweisrahmen

Thorstens Auftrag vom 2026-10-10 verlangt den technischen Abschluss und eine
genau gebundene Binary für seinen noch ausstehenden VoiceOver-Test. Nach
Dokumentations-/Statistikcommit wird der Prüfhead nicht durch weitere getrackte
Belegpflege verändert. Der Buildzähler wird vor dem einzigen vollständigen
`dotnet test` erhöht; dieser Befehl baut die Release-Binary ebenfalls.

Lokales Laufmanifest: `tests/MicroCalc.Tui.Tests/TestResults/voiceover-candidate.json`.
Es enthält erst nach tatsächlicher Ausführung: volle Commit-SHA, Version,
Vertrags-/Pin-Digests, kopierten vollständigen Releaseoutput, Binary-SHA-256,
Originalpfade und Hashes der TRX/PTY-/364-Pfad-Bundles, Smoke, Launcher,
SPDX-SBOM, NuGet.org-Audit, unveränderte Lizenzen und native Providerläufe.
Herkunft benennt tatsächliche Werkzeuge/Commands/Runner, keine behauptete
SLSA-Zertifizierung oder signierte Attestierung. Fehlende Ergebnisse bleiben
Open. Das ignorierte Manifest ersetzt keine getrackte finale Abnahme.

Die [Bedienanleitung](owner-acceptance-session.md) startet ausschließlich die
hashgeprüfte Kopie, ohne Restore/Rebuild. Reale Human-A11Y, manuelle HTML-Fälle
und getrennte Ownerentscheidung bleiben erforderlich. Kein Merge, kein
Intake-/Serienabschluss und kein Folgefeature vor gültigen materiellen Gates.

## English evidence boundary

The owner requests completed technical proof and an exact binary for his pending
VoiceOver session. Freeze the test commit after documentation/statistics delivery;
do not mutate tracked files while collecting its proof. Increment the build
counter before the single full Release test command, which also builds the app.
The ignored local manifest records only executed results: full commit, version,
contract/pin digests, complete copied output, binary hash, raw tests/PTY/bundles,
smoke, launcher parity, SBOM, registry audit, licences and native provider jobs.
Record actual provenance without inventing signed attestation or SLSA assurance.
Missing results stay Open. The hash-checked copied app never silently rebuilds.
Human accessibility, manual HTML checks and owner acceptance remain mandatory;
the manifest is not tracked final acceptance or permission to merge early.
