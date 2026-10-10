# Windows-Größenfixture: tatsächlicher CI-Befund / Actual CI size-fixture finding

## Deutscher Nachweis

[CI-Lauf 38074325189](https://github.com/hindermath/TinyCalc/actions/runs/38074325189),
Head `6124d7673cd48cb5b9cb3c54b48a2a7b4fb7f03f`, Job
`build-test (windows-latest)`: Core 217 Pass, TUI 441 Pass/11 Fail/null Skip.
Die elf TUI-Fehler betreffen acht TERM-Wege, zwei Framework-Größenprüfungen
und APP-terminal-restoration. Tatsächlicher Treiberbuffer war 120x30 statt
der vorgegebenen 80x24/120x40. Das ist Testinfrastruktur-Rot, kein Produktdefekt.
Linux wurde durch die bestehende Fail-fast-Matrix abgebrochen, nicht bestanden.

Korrektur ausschließlich im Testadapter: dieselbe reale ANSI-Factory mit der
öffentlichen [SizeMonitor-Injektion des gepinnten Frameworks](https://github.com/tui-cs/Terminal.Gui/blob/d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6/Terminal.Gui/Drivers/AnsiDriver/AnsiComponentFactory.cs).
Der Monitor meldet die vorgegebene Fixturegröße; echte Views, Tastatureingabe,
Layout, Zeichnung und unabhängige Assertions bleiben erhalten. Die vorherige
ANSI-Registrierung wird bei Dispose und Init-Fehler wiederhergestellt. Ein neuer
Test prüft die identische Registrierung nach eigener Sessionbereinigung.
Das ist kontrollierte Framework-Ausführung, keine physische Windows-PTY- oder
menschliche Evidenz. Die echte macOS-Prozess-PTY bleibt davon getrennt.

Build 109: drei gezielte Framework-Größen-/Registrierungsfälle lokal bestanden,
null Fail/Skip und keine Compilerwarnung. Befehl: `dotnet test
tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj --configuration Release
--no-restore --filter FullyQualifiedName~FrameworkTerminal_ --logger
trx;LogFileName=006-fixed-native-size109.trx`.
Originale liegen ignoriert unter `TestResults/006-fixed-native-size109.*`.
Dies ist kein behaupteter Windows-Pass: der neue native Vollvertragslauf muss
die Korrektur auf Windows und Linux am tatsächlichen Lieferhead bestätigen.

## English evidence

The linked actual Windows CI run passes 217 Core tests but fails eleven of
452 TUI tests because the driver buffer is 120x30 instead of the controlled
80x24/120x40 fixture sizes. Existing matrix fail-fast cancels Linux; cancellation
is not success. This is infrastructure red, not a product defect.

The adapter keeps the real pinned ANSI implementation, input, views, layout,
rendering and assertions while using its public size-monitor injection. Original
registration is restored even on initialisation failure; an added test checks
session disposal. Three targeted local tests pass without compiler warnings.
This proves controlled framework behaviour, not native Windows completion,
physical PTY or human accessibility. Fresh complete native CI proof remains due.
