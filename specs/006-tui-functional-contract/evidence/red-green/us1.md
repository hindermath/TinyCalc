# US1: tatsächliches Rot und Session-Extraktion / Actual red and session extraction

## Deutscher Nachweisblock

2026-10-10, macOS arm64, Terminal.Gui 2.4.17, SDK 10.0.401.
T016: Buildzähler 41, `dotnet test tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj
--configuration Release --no-restore --filter Contract=LegacyInfrastructure
--logger trx;LogFileName=legacy-infrastructure.trx --blame-hang-timeout 180s`.
Logger als einzelnes Argument; Exit 0, ein Pass, null Fail/Skip. Echte ANSI-App,
produktives BuildWindow, CursorRight nach B1, Editorseed 3, Esc und unveränderte
leere Zelle. Reflection nur für Setup/View-Erzeugung und read-only Beobachtung.
Kein Ersatz durch Engine-Fachaufrufe; kein PTY-/VoiceOver-Nachweis.

T019: Buildzähler 44, gleicher Testbefehl mit Filter `Contract=VerticalSlice`
und Logger `vertical-slice-red.trx`: Exit 1, drei ausgeführte Tests, zwei Pass,
ein Fail, null Skip. `2^3^2` wurde per Tastatur durch den wirklichen Editor
eingegeben und mit Enter übernommen. Tatsächlicher Wert 64, Sollwert 512.
Kontrollen `2+3` → 5 und Abbruch bestehender 7 ohne Mutation bestehen; nach
Navigation ist der vollständige Wert sichtbar. Vorbereitende Compilerkorrektur
im Test und frühere Anzeigeassertions sind ausdrücklich nicht dieser Rotbeleg.

T020: Buildzähler 45, Filter `Contract=VerticalSlice|Contract=LegacyInfrastructure`,
Logger `session-extraction.trx`: Exit 1, vier Tests, drei Pass, derselbe eine
fachliche Fail (512 erwartet, 64 beobachtet), null Skip. Dieselben Views/Bindings
liegen jetzt in einer internen instanzgebundenen TuiSession; Program besitzt
weiter den CLI/App-Lebenszyklus. Session besitzt Root/Engine, App bleibt beim
Aufrufer. Adapter enthält keine Reflection mehr, Assertions bleiben erhalten.
Keine Formelsemantik vor T026–T029 korrigiert; vollständiges Grün bleibt offen.

| Lokaler ignorierter Nachweis | SHA-256 |
|---|---|
| legacy-infrastructure.trx | d3aeef3ec19de8db60b389890f6e4fe677348bfad4cccd00948efaf8fc289968 |
| vertical-slice-red.trx | c65e7991f1425aef5a4cc628028e25cf5b51633d26971e015aaa42bf4d50f2b7 |
| LegacyProgramUiAdapter.cs vor Extraktion | 0a67c0f1a6926b90faf54d9d3a4478fed996ec841c4362f3af3dcdf2a6033951 |
| TuiVerticalSliceContractTests.cs | d35aca9c5f73a9f35bc0712464b63db52e3719996d85b1f2506c07845b9b5d47 |

### Orakelkorrektur vor Navigationstests / Oracle correction before navigation tests

Die erste unveröffentlichte Baseline hatte „begrenzt“ irrtümlich als Stehenbleiben
am Rand operationalisiert. Intake/Spec verlangen innerhalb A1:G21 zu bleiben,
keine neue Clamp-Semantik. Unabhängige historische Quelle `CALC.INC`, Prozeduren
MoveUp/Down/Right/Left (296–377), belegt Umlauf: B1↑B21, B21↓B1, G2→A3,
A2←G1. Die 13 Randorakel wurden vor Tests entsprechend korrigiert und separat
an diese Quelle gebunden; keine ID/kein Alias entfernt, keine Produktänderung.
Baseline-Digest nun `f7d4293cd12877b46fd2a34c89038ff7936c6811371517f4c336cd44e4352a49`.
Source-Map aktualisiert die Extraktionsanker im vorgesehenen T039; deren alte
Program-Hashes sind bis dahin nicht als aktuelle Produkt-Quellprüfung gültig.

### T021–T031: Tests vor Korrektur / Tests before fixes

Alle 98 OP-/REF-/Legacy-/Extended-Funktionsorakel wurden in beiden Testprojekten
aus dem unabhängigen Quellinventar, nicht aus Vertragsresultaten, ausgeführt.
Build 49: Core 106 Tests (inklusive acht Zelltests), 93 Pass/13 Fail; TUI 106,
89 Pass/17 Fail; jeweils null Skip. Drei damalige TUI-Fails betrafen noch die
testseitige Buttonbeobachtung, nicht Produktrot. Diese wurde vor Korrekturen
auf die reale Dialog.Buttons-Sammlung umgestellt, weiterhin per Tab/Enter.
Build 51: acht tatsächliche Zell-UI-Tests, sechs Pass/zwei Fail: breite Zahlen
und überlaufender Text werden in der bestehenden Ansicht abgeschnitten.
Build 52: zusätzliche Core-Zellgrenzen, 18 Tests, acht Pass/zehn Fail: sechs
Extended-Namen als Text statt Zahl, drei ungültige benannte Funktionen als Text
statt Fehler, verlorene OverWritten-Flags nach ungültiger Eingabe.

Build 48 bestätigte außerdem 150 UI-Tests: 137 Pass/13 Fail. Darunter drei
damals noch unbrauchbare Buttonbeobachtungen; die übrigen Fehler zeigen die
abgeschnittene aktive Zahl, zwei fehlende Raster-Ctrl-G-Wege und sieben
historische Editor-Aliase. Alle 95 ASCII-Eingaben waren durchlaufen. Ein früher
Test-Mapper hatte versehentlich Ctrl+Shift statt Ctrl erzeugt; ausschließlich
der korrigierte Build-48-Lauf zählt hier als Alias-Rot.

| Defektklasse | Rote fachliche Fälle | Minimale Korrektur |
|---|---|---|
| Potenz/Vorzeichen | OP-power-right, OP-sign-after-power, OP-positive-sign | Rekursive Rechtsbindung, Potenz vor Vorzeichen, unäres Plus |
| FACT | fact-invalid-0/-1/-3 | Rohwert ganzzahlig und 0..33 vor Cast prüfen |
| ROUND | round-too-large/-overflow-precision/-negative-fraction | Endliche Rohgrenzen vor Cast, keine Framework-Ausnahme |
| Endliche Zahlen | OP-power-domain/-overflow, sqr-overflow, exp-overflow | Endliche Parser-/Funktions-/Zahlengrenze |
| Selbstreferenz | REF-cycle über echten Editor | Zieladresse bereits beim ersten Auswerten im Zykluspfad |
| Funktionsklassifikation | MIN/MAX/AVERAGE/COUNT/IF/ROUND ohne äußere Klammern | Alle angebotenen Namen erkennen, ungültige Funktionen nicht als Text retten |
| Fehlerintegrität | verlorene OverWritten-Flags | Überlauftrail erst bei tatsächlich übernommener Eingabe löschen |
| Anzeige | aktive 7.00, Breite 20/11 Dezimalstellen, 70 Zeichen Text | Fester Zeilenpuffer mit später Begrenzung, breite/überdeckte Felder erhalten |
| Raster/Editor | Ctrl-G sowie sieben historische Aliasfälle | Bestehende View-Bindings kontextgebunden ergänzen/ersetzen |

Erster Vollversuch Build 53 deckte eine kollidierende vorhandene Tastenbindung
auf; dies ist kein zusätzlicher fachlicher Rotbeleg. Bestehende Aliase werden
nun vor dem gezielten Neusetzen entfernt. Ein historischer Golden-Test mit
64 wurde aufgrund der ausdrücklich genehmigten RQ-002 auf 512 fortgeschrieben;
die frühere verständliche ROUND-Negativmeldung bleibt erhalten.

Build 55, tatsächlicher vollständiger lokaler Lauf:

```text
dotnet test MicroCalc.sln --configuration Release --no-restore --logger trx;LogFileName=us1-green-final.trx --blame-hang-timeout 180s
```

Logger als einzelnes Argument. Exit 0; Core 205 Pass, TUI 271 Pass; insgesamt
476, null Fail/Skip. Dieselben fachlichen Rotfälle sind grün. Laufartefakte:
Core SHA-256 `a72d46a4ad52731844f657e7327fbbe5cc113df94fe8228b50dee38e62ba4746`,
TUI `293dcf18215d89cfa578c02b42ba2ed8869aa7b88843aa4da91a1793de2fe155`.
Session-Extraktions-TRX: `2d6c52b9a72184e587339b7af7caffd4c60b9c4469b4ea1f1158c041a1aec5dc`.
Die unterstützten öffentlichen Signaturen/XML-Kommentare bleiben unverändert;
EvaluateForCell und TuiSession sind interne Implementierung, kein öffentlicher Testmodus.

T032 bleibt offen: Dies ist eine tatsächliche lokale Regression, noch kein
vollständiges 364-Pfad-Abnahmebundle, kein finaler Commit, kein Linux-/Windows-
oder PTY-/VoiceOver-Nachweis. Die Quit-Infrastruktur wird zusätzlich so
gehärtet, dass nur der produktive Befehl, nicht automatische Testbereinigung,
den Exit-Erfolg verursachen darf. Die native Terminal-Wiederherstellung bleibt
dem tatsächlichen PTY-Protokoll vorbehalten.

## English evidence block

The build-41 legacy infrastructure probe passed one actual production-view
navigation/editor-cancellation test. It is framework-loop evidence, not a real
PTY or human accessibility acceptance result. The build-44 vertical slice ran
three tests: two controls passed; real keyboard entry of `2^3^2` yielded 64
instead of the approved 512. No compiler/driver failure counts as that red.
Build 45 moved the same views and bindings into an internal owned session and
removed temporary reflection. Its four tests retain the same one domain
failure and three passing controls. Formula fixes and full-story green remain
future tasks; no product/platform completion is claimed.

Before navigation tests, thirteen unpublished edge oracles were corrected from
an unsupported clamp assumption to the historical in-grid wrap documented by
CALC.INC. No obligation or alias was removed and no product behaviour changed.
The independent baseline digest was refreshed; current extracted source-map
anchors/hashes remain a declared T039 follow-up, not a falsely current check.

Builds 48/49/51/52 recorded actual UI and independent Core failures before
product corrections. Incorrect Ctrl+Shift test mapping and temporary button
observation failures are explicitly excluded from domain-red claims. The table
above separates approved power/sign, FACT, ROUND, finite-number, cycle, named
function classification, overflow-state, display and contextual key defects.
Fixes preserve production views and public API signatures. An obsolete golden
64 expectation was updated under explicit approved RQ-002, not weakened to
match implementation. The first full attempt also caught a binding collision;
aliases now remove an existing binding before replacement.

The complete build-55 local regression passed 476 tests (205 Core, 271 TUI),
zero failure/skip, command and actual ignored-trace hashes above. T032 remains
open: no complete 364-path acceptance bundle, exact final commit, native
Linux/Windows, real PTY or human VoiceOver proof is claimed. Quit controls are
additionally strengthened so cleanup cannot masquerade as a product exit.
