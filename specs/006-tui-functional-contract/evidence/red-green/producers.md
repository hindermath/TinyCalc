# Producer-Rot–Grün–Refactor / Producer red–green–refactor

## Deutscher Nachweisblock

T014A am 2026-10-10, macOS arm64, SDK 10.0.401. Zuerst vollständiger Release-
Build aller vier Projekte mit Version `1.6.9.34`: Exit 0, null Warnungen/Fehler.
Danach Buildzähler auf 35 erhöht und ausgeführt:

```text
dotnet test MicroCalc.sln --configuration Release --no-build --filter Contract=Producer --logger trx;LogFileName=producer-red.trx
```

Der Logger-Parameter wurde als ein Shell-Argument übergeben. Tatsächlicher Exit
1; je Projekt neun ausgeführte, neun fehlgeschlagene, null übersprungene Tests.
Keine Compiler-, Treiber-, Restore- oder Loopfehler. Die isolierte permissive
Naht akzeptierte konkrete fehlerhafte Kandidaten, wie für T014A vorgeschrieben.

| Fall in beiden Projekten | Beobachteter roter Fehler |
|---|---|
| MissingAssertions | `Malformed candidate accepted: MissingAssertions` |
| MissingResult | `Malformed candidate accepted: MissingResult` |
| DuplicateResult | `Malformed candidate accepted: DuplicateResult` |
| Skipped | `Malformed candidate accepted: Skipped` |
| Timeout | `Malformed candidate accepted: Timeout` |
| DigestMismatch | `Malformed candidate accepted: DigestMismatch` |
| FailedAssertion | `Malformed candidate accepted: FailedAssertion` |
| InterruptedPublication | `Interrupted publication accepted; partialVisible=True` |
| PositiveCandidate | `Assert.NotNull() Failure: Value is null` |

Die ersten acht Fälle scheitern an expliziten Ablehnungsassertions, nicht an
fehlender Ausgabe oder ungeprüften Ausnahmen. Der letzte Fall belegt getrennt
das positive Ausgabe-Rot am inerten Create-Stub. Die sichtbare Teil-Datei im
Abbruchfall wurde tatsächlich erzeugt und nur im eigenen Testverzeichnis
anschließend entfernt. Die Naht erzeugt keinerlei produktive Abnahmefreigabe.

| Lokaler Nachweis | SHA-256 am roten Checkpoint |
|---|---|
| Core.Tests/TestResults/producer-red.trx | `594565b8b5894a6d05ec452da0378c3c8a0112c8e7b143f0abae2692edfa0f9c` |
| Tui.Tests/TestResults/producer-red.trx | `d846aad3a7401a78f77411cdd64b9f6ca032b7b08e33a6aed1bfea46865548a7` |
| ContractEvidence/EvidenceProducer.cs | `7a28224cf4a9e2fcec621e23d4010d3699cf2440c4f7ee1705c0f5d27a9edd20` |
| ContractEvidence/ProducerTestCases.cs | `8a11c21bd456818cb3dcdd1c0f0f342a5eaf10a8f5050e731e8d68915552239c` |

TRX-Dateien sind ignorierte lokale Laufartefakte. Dieses Protokoll erhält
Beobachtungen und Hashes; kein behaupteter finaler Commit-/Plattformnachweis.
T015-Grün und Refactor werden erst nach tatsächlicher Ausführung ergänzt.

### Tatsächliches Grün und Refactor / Actual green and refactoring

Erster Grünlauf mit Buildzähler 36: dieselben 18 Tests bestanden, null Skip.
Anschließend Metadaten-/Digest-Ausgabe zum vollständigen Bundle-Schema erweitert,
die Soll-Digestbindung aus dem Kandidaten in einen separaten Aufrufkontext
verlegt und zusätzliche Negativfälle für gefälschte Sollwerte/leere Assertions
ergänzt. C#-/PowerShell-Kanonisierung verwendet gemeinsame Unicode-/Array-/Zahlen-
und Duplikatfixtures. Beide erzeugten Testbundles bestehen das strikte Schema
und die unabhängige PowerShell-Digestprüfung. Die Jobs heißen ausdrücklich
`isolated-fixture-not-acceptance`; synthetische Bindungen sind Unit-Fixtures,
keine tatsächlichen Linux-/Produkt- oder Abschlussnachweise.

Buildzähler 39, vollständiger lokaler Regressionslauf:
`dotnet test MicroCalc.sln --configuration Release --no-restore --logger
trx;LogFileName=foundation-regression.trx` (Logger als ein Argument), Exit 0.
Core: 89 Pass; TUI: 19 Pass; zusammen 108, null Fail/Skip. Darunter 26 Producer-
Tests einschließlich atomarer positiver Veröffentlichung und Erhalt einer alten
Datei bei Abbruch. Kein Produktcode geändert. Die 364 Produktpfade sind damit
noch nicht ausgeführt oder abgenommen.

## English evidence block

The full four-project Release build passed with no warnings/errors before the
first producer red run. The subsequent filtered command executed nine tests
per project: all nine failed, none skipped, exit one. Seven concrete malformed
candidates failed explicit rejection assertions. Interrupted publication also
failed explicit rejection and reported a genuinely visible partial file.
Only the separate positive-output case failed because the inert Create stub
returned no output. No infrastructure failure is counted as functional red.
The shared fixture remains isolated and cannot authorize product acceptance.
The hashes above bind local ignored traces and the red source checkpoint;
green/refactoring proof must follow actual execution, not a claimed result.

The first green run passed the same eighteen tests. Refactoring then added
complete schema-shaped output, externally supplied expected digest context,
forgery/empty-assertion protection, shared C#/PowerShell canonical fixtures and
atomic positive-publication/old-file preservation tests. Both isolated fixture
bundles passed schema and independent digest validation. Their synthetic job
and bindings explicitly cannot count as real platform/product acceptance.
The full local build-39 regression passed 108 tests (89 Core, 19 TUI), including
26 producer tests, with zero failures/skips. No product code was changed and
the 364 offered product paths remain unexecuted.
