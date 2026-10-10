# Echte UI-Belege / Real UI proof

## Aktueller Stand: vollständiger lokaler Lauf / Current complete local run

Build 105 ersetzt den unten archivierten Teilstand: 669 Solution-Tests bestanden
(Core 217, TUI 452), null Fail/Skip. Derselbe macOS-Lauf enthält alle 364
unterschiedlichen Pflichtpfade und 462 serialisierte unabhängige Assertions.
Der Collector hat das vollständige lokale Bundle erfolgreich gebunden.
Exakte Befehle, Zeitfenster, Revision und Digests stehen im
[macOS-Nachweis](platforms/macos/local-build105.md); die zusammengeführte
[Changed-Line-Coverage](coverage.md) beträgt 488/503 = 97,02 %.
Das ist ein echter lokaler Vollbeleg, aber keine finale Commit-/Dreiplattform-
oder menschliche Abnahme. Spätere Dokumentationsänderungen ändern den
Arbeitsbaum; der gespeicherte Laufdigest wird nicht umetikettiert.

*Build 105 supersedes the partial checkpoint below: 669 passing solution tests,
364 distinct mandatory paths, 462 serialized independent assertions and a
successfully bound native macOS bundle. Changed executable-line coverage is
488/503, or 97.02%. Linked proof retains the actual commands, times and digests.
This is complete local proof, not final-head, three-platform or human acceptance.
Later documentation edits do not relabel the recorded working-tree digest.*

## Historischer Teilstand / Historical partial checkpoint

## Deutscher Nachweisblock

2026-10-10, Branch `006-tui-functional-contract`, Basis `8115513d803b`.
Beobachtetes Ausführungsfenster 17:17–17:43 Europe/Berlin, keine Arbeitszeitmessung.
Dies ist die Fortsetzung von T043/T049 und der späteren Producer-Bindung,
kein Feature-Abschluss und kein natives vollständiges EvidenceBundle.

`ExecutedPathProof` erfasst unabhängige Soll-/Ist-Assertions aus den vorhandenen
echten Terminal.Gui-Tests. Eingaben laufen weiterhin durch produktive Views und
Bindings, nicht durch direkte Fachaufrufe. Formel-Sollwerte kommen aus dem vorab
erstellten Quellinventar; Navigationsziele und Editorinhalte werden unabhängig
assertiert. Der Schreiber ersetzt diese Assertions nicht.

Rot: Build 64 führte neun kompilierte Schreiberfälle aus: sechs Fail, drei Pass,
null Skip. Explizite Ablehnungsassertions zeigten akzeptierte falsche Werte,
Beschreibungen statt Beobachtungen, doppelte IDs und widersprüchliche Zustände.
Die frühere Compilerkorrektur in Build 63 ist ausdrücklich kein fachliches Rot.
Build 67 bestätigte zusätzlich fünf echte Producer-Fails: Beschreibung-only,
doppelte/widersprüchliche Assertions, verlorene zweite Beobachtung und Ablehnung
einer vorab erlaubten numerischen Rundungsabweichung. Build 68: Core 13/TUI 33,
zusammen 46 grün, null Fail/Skip. Die synthetische Positivfixture verwendet jetzt
typisierte Beobachtungen, nicht das unzureichende Wort „unchanged“.

Der Schreiber und Bundle-Producer erhalten alle Istwerte. Numerische Toleranzen
sind pfadgebunden; Istzahlen werden nicht auf Sollwerte gerundet. Unvollständige
oder gescheiterte Pfade veröffentlichen nichts. Erst nach allen UI-Assertions
werden Beleg, Rastertext, Statustext und Resultat atomar als eigenes Verzeichnis
sichtbar. Vertrags-IDs werden gehasht statt als Dateinamen interpretiert; Ausgabe
bleibt unter eigenen TestResults ohne Symlink-Durchlauf. Die Zeitmessung beginnt
bei der ersten realen UI-Aktion und lässt sich nicht zurücksetzen. Schemaformat
der Artefaktreferenzen und Fixture-/TRX-Zeitabgleich wurden als technische
Integrationskorrekturen behandelt, nicht als neue Produktdefekte.

| Tatsächlicher Lauf | Ergebnis | Resultate und Assertions |
|---|---|---|
| Build 71: Formel + Navigation + Schreiber | 140 Pass, 0 Fail/Skip | 124 UI-Pfade, 222 serialisierte Assertions |
| Build 72: eigene Ausgabepfade/Schreiber | 16 Pass, 0 Fail/Skip | gezielte Dateinamenshärtung, keine Produktwiederholung |
| Build 73: ASCII + Editoraliase | 111 Pass, 0 Fail/Skip | 111 UI-Pfade, 111 serialisierte Assertions |

Die 235 unterschiedlichen Pfade sind zwei getrennte lokale Zwischenläufe,
nicht ein gemeinsamer finaler Versions-/Commitnachweis. Formel-/Navigationsbelege:
`tests/MicroCalc.Tui.Tests/TestResults/contract-cases/b9693ad34edd44a6911887f29852a78c`.
Editorbelege: entsprechender Unterordner `7cb41d6c4da44f3e89d9f7c4b9b504a0`.
Editorzustände werden vor eigener Esc-Bereinigung beobachtet, aber erst nach deren
abschließenden Invarianten veröffentlicht. Die bestehenden Caret-/Modusassertions
bleiben erhalten; die serialisierten Teilbelege behaupten keine zusätzlichen Felder.

`test-executed-paths.ps1` prüft ausschließlich lesend: striktes Resultatschema,
passende tatsächlich bestandene TRX-Theory aus der richtigen TUI-Testklasse,
UTC-Zeitgrenzen, Assertion-Proof-Gleichheit, Artefakthashes, unabhängige Orakel
und vollständigen festen Teilnenner. Beide Teilnenner sind grün. Die rein interne
Prüfhülle verwendet ausdrücklich synthetische Bindungen und wird niemals als
Bundle gespeichert. Im gesamten 1.092-Tupel-Modell fehlen dabei korrekt 968
beziehungsweise 981 Resultate. Diese Zahlen dürfen nicht durch Zusammenkopieren
der unterschiedlichen Zwischenläufe in einen finalen Pass verwandelt werden.

Semantik-Guard: drei neue Ablehnungsassertions zunächst rot, danach alle 31 Fälle
grün. Doppelte Assertions, verlorene oder abweichend zusammengeführte Istwerte
werden abgelehnt. Fünf manipulierte Kopien echter Belege wurden korrekt verworfen:
fehlendes/doppeltes Resultat, veränderte Assertion, falscher Artefakthash und
geskipptes TRX. Originale, Fixture-Inputs und Repositorybytes blieben unverändert.
Ein zusätzlicher Testklassen-Bypass war zuerst rot, danach gezielt grün: ein
gleichnamiger Fall außerhalb der gebundenen TUI-Klasse reicht nicht aus.

Ausführung: `dotnet test tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj
--configuration Release --no-restore` mit den jeweiligen Klassen-/Methodenfiltern
und TRX-Loggern. Die lesenden Teilprüfungen verwenden `-EvidenceDirectory`,
`-TrxPath` und für Editorfälle `-Slice PrintableEditing`. Filterläufe sind hier
gezielte Entwicklungsnachweise, niemals Story-/Plattform-Vollabnahme.

50/83 Tasks bleiben vollständig nachgewiesen. T032/T040/T043/T049 bleiben offen:
129 weitere Pfade, vollständige finale Producer-/Plattformbindung und Story-
Nachweise fehlen. CI, PTY, VoiceOver, Coverage und unabhängige finale Reviews
bleiben eigene Gates. Keine Produkt-API, Abhängigkeit oder Intake geändert;
keine DocFX-/WCAG-Abnahme behauptet. Claude-Providerfehler bleibt auf Ownerwunsch
zurückgestellt, nicht bestanden. Keine Commits, Pushes, Merges oder Folgefeatures.

Statistik: vorhandenen Repository-Profil-2-Renderer mit `-WhatIf -Json` geprüft,
Exit 0/DRY_RUN, Quelle `8115513d803b`. Das generische Preset passt nicht zum
vorhandenen Profil-2-Konfigurationsformat; keine Migration oder Konfigurations-
umschreibung. Autorisierte Autorenfortschreibung bleibt vom generierten,
historisch gebundenen Block getrennt; kein Dirty-Guard-Bypass.

## English evidence block

This continues Feature 006 on the existing branch, not feature acceptance.
The executed-path writer first failed six of nine compiling tests. A separate
producer regression first failed all five new cases. Both were corrected with
typed observations, duplicate/conflict rejection, complete state merging and
approved per-path numeric tolerance without changing actual numbers. Core 13
and TUI 33 focused producer tests passed. Earlier compiler, artefact-format and
fixture/TRX-timing issues are infrastructure corrections, not product-red proof.

Build 71 passed 140 tests: 124 real formula/navigation paths and 16 writer guards.
Build 72 passed the 16 focused output guards. Build 73 passed 111 printable/editor
alias paths. Across two distinct intermediate runs, 235 of 364 paths now have
individual proof and 333 serialized independent assertions. Existing caret and
mode assertions remain executed without claiming unsupported serialized fields.
Editor checkpoint state precedes owned cleanup; publication follows all assertions.

Read-only checking binds each record to its actual passed TRX theory and TUI
class, timestamps, strict schemas, independent oracles and hashed proof/text.
Both fixed slices pass, not the complete contract: their checking envelopes leave
968 and 981 of 1,092 tuples missing. Synthetic envelope bindings are never saved
or presented as native full bundles. Do not merge intermediate runs into final proof.
All 31 semantic fixtures pass after three new red rejection assertions. Five
tampered real-proof copies are rejected with unchanged inputs/repository; a new
wrong-class bypass was independently red then green without rerunning the product.

The writer publishes atomically only after completed assertions, retains raw actual
values and rejects incomplete/failed observations. Hashed IDs cannot select output
paths; owned TestResults and symlink checks bound writes. Actual UI execution sets
the proof clock once. No product API or dependency changes, no new feature or Git
delivery. Fifty of 83 tasks remain fully evidenced; whole-story/final producer,
native-platform, PTY, human accessibility, coverage and independent gates stay Open.
The requested Claude provider deferral is not a successful review. Repository
Profile 2 preview is DRY_RUN/exit zero; generated statistics wait for a clean boundary.

## Originalartefakte / Original artefacts

SHA-256; Dateien unter `tests/MicroCalc.Tui.Tests/TestResults/` sind ignorierte
lokale Originale, keine getrackten vollständigen Lieferbelege.

*SHA-256; ignored local originals, not tracked complete delivery proof.*

| Datei / File | SHA-256 |
|---|---|
| 006-executed-proof-red.trx | ba7f8c3bdae7ce79b558eea2c70ebfffaf9ce299d2412c7434f41f426275b35d |
| 006-producer-observation-red.trx | 758eff090c1e36837e6076c1b0668ad5041c34c5535c8c20d60eadc9ef6ddbb8 |
| 006-observation-producers-green.log | 2611dcc8c7fdaddd72270800e5ad91a132f84bcb455f83006906a19673591154 |
| 006-observation-binding-red.log | 82f65ecd3a66021de090095ee9f249a0e21281705331d3028fa8d9658effefc2 |
| 006-observation-binding-green.log | d2654074d2a9f4b1cd260e52cb2e799862470ddef80cf0474efefba477b9a015 |
| 006-real-path-proofs-final.trx | 6ff7335d0cd22f90d2f402d1b8bc4eff22a5fd8c28e451de843e0a3871de2e92 |
| 006-real-path-binding-final.log | 980ff28a07c36412da6a3d99cea21d11a559d537124ad32779a427757a03878c |
| 006-proof-owned-paths.trx | a11bf4ef42c3714e62948536a51e1bbddaf8fae1d254b74ee0365254c6a5d213 |
| 006-editor-path-proofs.trx | c25c0d0a9a40b04ed98219c161b415e3a1c82521eb699fba02364159aaa9cf25 |
| 006-editor-path-binding.log | 2c979223be00af4a475d68e021c7094ef2a45a28c913e53e00d398bb5b216b72 |
| 006-real-proof-tampering.log | b12d16288066ca49fa46d812677303ece68ce2c004dd755f72d4d9f7eab07773 |
| 006-proof-class-binding-red.log | d013e014a25fe977a22df6d156f7fecf512e22e6446eed781fd6c7ff5946c961 |
| 006-proof-class-binding-green.log | 4e86954ffc80ed5c564ec2a6025bf305f1f90bf76adb138a51af66578363ea39 |
| 006-proof-statistics-preview.log | 370be1f50501acfabc2c2e987523bb32dfb00e22506fae638522c6951ea53585 |
