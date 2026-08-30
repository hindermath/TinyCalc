# Lokale Regressionsevidenz / Local Regression Evidence

## Zwischenstand nach T037 / Interim State after T037

- Plattform / Platform: Darwin, macOS 26.6, `osx-arm64`
- SDK / Runtime: .NET SDK `10.0.400`, Runtime `10.0.11`
- Checkpoint: `886a13f8866e79fe6c13e6e1227217294aabdee8`
- Finaler Restore T034 / Final restore T034: Exitcode `0`, vier Projekte,
  Terminal.Gui direkt `2.4.17`, alle 24 TUI-Pakete durch lokale
  Paketmetadaten an NuGet.org gebunden. / *Exit zero for four projects; exact
  direct package and all resolved TUI packages bind to NuGet.org.*
- Release-Build T035: Version `1.3.1.11`, Exitcode `0`, null Warnungen, null
  Fehler. / *Release build passed with no warning or error.*
- Gesamttest T036 / Full tests T036: Versionzähler `1.3.1.12`, Exitcode `0`,
  Core `76/76`, TUI `3/3`, insgesamt `79/79`, null übersprungen. / *All 79
  tests passed and none were skipped.*
- Smoke T037: Befehl
  `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke`,
  Exitcode `0`, Ausgabe exakt `SMOKE_OK`, Ende deutlich unter 30 Sekunden.
  / *The no-build smoke run exited zero, printed exactly `SMOKE_OK`, and
  completed well within 30 seconds.*

Coverage-, Dependency-Audit- und finale Hashabschnitte folgen in T038-T044.
Sie werden hier nicht vorzeitig als bestanden bezeichnet. / *Coverage,
dependency audit, and final hashes follow in T038-T044 and are not claimed
early.*

## Coverage-Ausführungen T038/T039 / Coverage Runs T038/T039

- Coverage-Test T038: isoliertes Microsoft `dotnet-coverage` `18.8.0`,
  sichere statische Managed-Initialisierung, dynamische und native
  Instrumentierung deaktiviert; genau ein Testaufruf, Exitcode `0`, `79/79`
  bestanden, null übersprungen. `tests.coverage` ist `82.748` Byte groß und
  hat SHA-256
  `67e6dd98b52207a9bbd3e65e4d284264a9942cb10e042cef861b62c9657e0ecb`.
- Coverage-Smoke T039: derselbe gebaute Produktstand, kein Build/Test-Aufruf,
  Exitcode `0`, exakt `SMOKE_OK`. `smoke.coverage` ist `82.714` Byte groß und
  hat SHA-256
  `fe69d93924806b5bf0c9851531234ec60c041f7959d756f8eafafa6f3e94f967`.
- Wiederherstellung / Restoration: Alle sechs temporär instrumentierten
  Produkt-DLL-Kopien in Source- und Testausgaben wurden direkt danach gegen
  ihre Sicherung geprüft und bytegenau wiederhergestellt. TUI-SHA-256 ist
  `0d36bd68e97d1b6025254514d67c9ec3655af4501f58d3f4ea9688c3be6488a1`,
  Core-SHA-256 ist
  `e7100515a628e1260ba9b79fd064cf3e698c1f70f67ed1b7b7ddfdf25ab10eda`.

*The isolated current Microsoft collector used safe static managed
initialisation only. The single coverage test invocation passed all 79 tests,
and the separate no-build smoke printed exactly `SMOKE_OK`. Both coverage
files are non-empty. Every temporarily instrumented product DLL copy was then
restored byte-for-byte from its verified backup.*

## Finaler lokaler Abschluss T044 / Final Local Closure T044

Stand dieses Nachweises ist der Checkpoint
`886a13f8866e79fe6c13e6e1227217294aabdee8` plus der geprüfte Arbeitsbaum von
Feature 003. Der nach T063 erforderliche Exact-Head-Lauf muss alle relevanten
Ergebnisse erneut an den dann feststehenden Commit binden. / *This evidence is
bound to checkpoint `886a13f8866e79fe6c13e6e1227217294aabdee8`
plus the reviewed Feature 003 working tree. The mandatory post-T063 exact-head
run must bind the relevant results again to the final commit.*

| Schritt / Step | Exakter Befehl / Exact command | Ergebnis / Result |
|---|---|---|
| Restore T034 | `dotnet restore MicroCalc.sln` | Exit `0`; vier Projekte / four projects |
| Build T035 | `dotnet build MicroCalc.sln --configuration Release --no-restore` | Exit `0`; Version `1.3.1.11`; 0 Warnungen, 0 Fehler / warnings, errors |
| Test T036 | `dotnet test MicroCalc.sln --configuration Release --no-build` | Exit `0`; 79/79 bestanden / passed; 0 übersprungen / skipped; Version `1.3.1.12` |
| Smoke T037 | `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` | Exit `0`; exakt / exactly `SMOKE_OK` |
| Coverage-Test T038 | `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/tests.coverage --output-format coverage -- dotnet test MicroCalc.sln --configuration Release --no-build` | Exit `0`; 79/79 bestanden; Version `1.3.1.13` |
| Coverage-Smoke T039 | `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/smoke.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` | Exit `0`; exakt / exactly `SMOKE_OK` |
| Coverage-Merge T040/T041 | Pflichtdateien plus ergänzende echte PTY-Datei / mandatory files plus supplemental real PTY file | Exit `0`; finale Cobertura gültig / final Cobertura valid |
| Scope-Vertrag T044 | `git diff --exit-code -- tests src/MicroCalc.Core CALC.HLP` | Exit `0`; keine Ausgabe / no output |

Der SHA-256 der leeren Scope-Vertragsausgabe ist
`e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855`.
Damit wurden weder Testquellen noch `MicroCalc.Core` oder `CALC.HLP` verändert.
Die temporäre Coverage-Instrumentierung ist vollständig zurückgenommen. / *The
empty contract output proves that test sources, `MicroCalc.Core`, and
`CALC.HLP` are unchanged. Temporary coverage instrumentation was fully
restored.*

### Integritätswerte / Integrity Values

| Artefakt / Artifact | SHA-256 |
|---|---|
| `Directory.Build.props` (`1.3.1.13`) | `045e21c1b2ab3b24bb38881ab3b926d113adeeee1342af3cccd9ca46e333b632` |
| `src/MicroCalc.Tui/MicroCalc.Tui.csproj` | `4ec7597b21443a7ba10204df46ad2e4148397cbceea4c533413f65a36e3b484c` |
| `src/MicroCalc.Tui/Program.cs` | `081079aa729ea410ce02e562179a9e1f36278d108b9b5069e7d0ef47877a7f66` |
| gebaute TUI-DLL / built TUI DLL | `0d36bd68e97d1b6025254514d67c9ec3655af4501f58d3f4ea9688c3be6488a1` |
| gebaute Core-DLL / built Core DLL | `e7100515a628e1260ba9b79fd064cf3e698c1f70f67ed1b7b7ddfdf25ab10eda` |
| `restore-final.txt` | `a9eaacfc32a9742e0323564dcf0a1088a0e982453eedf0f487f596651faf7157` |
| `version-evidence.md` | `6c792ea5d89cf844dcba1a51d82f994207dbadaecf2614a185332f898a532171` |
| `manual-tui.md` | `3c2bc5b232c05ec7cb10b7ddb143e7fa92943499eb4bbc51ce6dcff9a0f0620d` |
| `coverage-summary.md` | `81cbdafe3350a2c7887377b770e8a1e776812d6657af09be162535beab65bc7b` |
| finale / final `terminalgui.cobertura.xml` | `079724fba738bca09d365cdbdaa46c19efce33cf49cbfb27cb34a71011549b1c` |
| `dependency-review.md` | `8aa296af7c84d2dd0e0eb1920b8235189e973832d890ca1f7877c29d4e9c98ef` |
| `docs/security/dependency-audit.md` | `8e6cda2126c73fe1c4763c26a453a5337b808c0d88d985369d5e9eb0756d7118` |

Die geänderten ausführbaren Zeilen erreichen lokal 82,0 Prozent und bestehen
damit sowohl die 70-Prozent-Schranke als auch das 80-Prozent-Ziel. Die
Paketprüfung meldet 0 bekannte Schwachstellen und 0 unbekannte oder
unvereinbare Lizenzen. / *Changed executable lines reach 82.0 percent locally,
passing both the 70 percent floor and the 80 percent target. The package review
reports zero known vulnerabilities and zero unknown or incompatible licenses.*

Diese Evidenz gilt ausschließlich für macOS `osx-arm64`. Sie ist kein Linux-
oder Windows-Nachweis. Beide Plattformen bleiben bis zum echten CI-Gate T066
eine verbindliche Lieferabhängigkeit. / *This evidence applies only to macOS
`osx-arm64`. It is not Linux or Windows evidence; both platforms remain binding
delivery dependencies until the real CI gate T066 passes.*
