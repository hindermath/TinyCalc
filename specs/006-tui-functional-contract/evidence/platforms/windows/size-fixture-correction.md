# Windows-Größenfixture: tatsächlicher CI-Befund / Actual CI size-fixture finding

## Deutscher Nachweis

[CI-Lauf 38074325189](https://github.com/hindermath/TinyCalc/actions/runs/38074325189),
Head `6124d7673cd48cb5b9cb3c54b48a2a7b4fb7f03f`, Job
`build-test (windows-latest)`: Core 217 Pass, TUI 441 Pass/11 Fail/null Skip.
Die elf TUI-Fehler betreffen acht TERM-Wege, zwei Framework-Größenprüfungen
und APP-terminal-restoration. Tatsächlicher Treiberbuffer war 120x30 statt
der vorgegebenen 80x24/120x40. Das ist Testinfrastruktur-Rot, kein Produktdefekt.
Linux wurde durch die bestehende Fail-fast-Matrix abgebrochen, nicht bestanden.

Erster, inzwischen supersedierter Korrekturversuch im Testadapter: dieselbe reale ANSI-Factory mit der
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

The first, now superseded adapter attempt keeps the real pinned ANSI implementation, input, views, layout,
rendering and assertions while using its public size-monitor injection. Original
registration is restored even on initialisation failure; an added test checks
session disposal. Three targeted local tests pass without compiler warnings.
This proves controlled framework behaviour, not native Windows completion,
physical PTY or human accessibility. Fresh complete native CI proof remains due.

## Tatsächliche Folgekorrektur / Actual follow-up correction

Deutsch: [Lauf 38075699435](https://github.com/hindermath/TinyCalc/actions/runs/38075699435)
am Head `891d99f0287697400513bc03c6ebcb3f36705a8d` widerlegt die erste
Windows-Hypothese: 120x30 bleibt bestehen. Die gepinnte
[ApplicationImpl.Driver](https://github.com/tui-cs/Terminal.Gui/blob/d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6/Terminal.Gui/App/ApplicationImpl.Driver.cs)
erstellt bei Namensauswahl die Factory direkt; die registrierte CreateFactory
wird nicht aufgerufen. Der wirkungslose Registry-/Monitor-Eingriff ist entfernt.
Der Adapter setzt stattdessen den öffentlichen Größenmodus vor Init auf
AnsiQuery, setzt die gewünschte Screen-Größe und stellt den ursprünglichen
Modus bei Fehler/Dispose wieder her. Echte ANSI-Views, Buffer und Eingabe bleiben
erhalten; keine Änderung an Produktdefaults, Paketen oder physischen Konsolen.

Linux: Core 217 Pass, TUI 444 Pass/9 Fail/null Skip. Die neun Publikationen
kollidieren mit dem reservierten `grid.txt`. Rohphasen heißen nun `native-*`;
die Sicherheitsprüfung bleibt streng. Die zwei lokalen Frameworkfälle prüfen
jetzt auch vollständige Publikation von sechs nichtleeren Rohartefakten in
einem eigenen, anschließend bereinigten Testverzeichnis. Keine doppelten
Vertragsbelege gelangen in den Collector.

Build 110: beide Publikationsfälle tatsächlich rot. Build 111: diese zwei und
drei bestehende Namensablehnungen grün. Build 112: Polling-Restaurierungsfall
tatsächlich rot, AnsiQuery-Fall grün. Build 113: alle sieben gezielten Fälle
grün, null Fail/Skip. Originale: ignorierte `TestResults/006-native-publication110-red.*`,
`006-native-publication111-green.*`, `006-native-polling112-red.*` und
`006-native-fixture113-green.*`. Dies ersetzt keinen neuen nativen Vollbeleg.

English: Actual native CI disproves the registry-factory hypothesis: the pinned
driver selector constructs its factory directly. Remove the ineffective override
and set the supported ANSI query mode before Init, restoring the original mode
after disposal/failure. Keep real framework rendering and input; do not change
product defaults or the physical console. Linux's nine raw-proof publication
failures are reserved-name collisions, corrected with distinct native-prefixed
phase names rather than a weaker security check. Real local red/green tests now
exercise publication and restoration from both size modes: seven targeted cases
pass in build 113. Fresh complete native proof remains mandatory.

## Hosted-I/O-Isolation / Hosted I/O isolation

Deutsch: [Lauf 38076466855](https://github.com/hindermath/TinyCalc/actions/runs/38076466855),
Head `bed41f1852cfd530d1c229121a503269af603318`: Windows Core 217 Pass,
TUI 443 Pass/11 Fail/null Skip; die Größenantwort des Hosted-Terminals bleibt
wirksam. Der Größenmodus allein genügt nicht. Der gepinnte
[dokumentierte Framework-Testhook](https://github.com/tui-cs/Terminal.Gui/blob/d0a0ed9b150d3fc8aacf4ab07b7f7d91264fe6d6/Terminal.Gui/Drivers/Driver.cs)
`DisableRealDriverIO=1` isoliert ausschließlich die serialisierten Framework-
Sessions vom fremden Terminal. Reale Views, Buffer, Layout und injizierte
Tastaturereignisse bleiben aktiv; dies ist ausdrücklich keine physische PTY-
oder VoiceOver-Evidenz. Ursprüngliche Umgebungsvariable und Größenmodus werden
bei Init-Fehler und Dispose wiederhergestellt. Echte macOS-Prozess-PTYs laufen
separat ohne diesen Hook. Build 114: zwei Restaurierungsfälle rot; Build 115:
sieben gezielte Publikations-/Restaurierungs-/Ablehnungsfälle grün, null Fail/Skip.
Originale ignoriert unter `TestResults/006-native-io114-red.*` und
`006-native-io115-green.*`; neuer nativer Vollbeleg bleibt erforderlich.

English: Actual Windows CI shows that ANSI mode alone does not isolate hosted
terminal size replies. Use the pinned framework's documented buffer-only I/O
test hook only inside serialised framework sessions and restore both original
settings after failure/disposal. Keep actual framework views/rendering/input;
do not claim physical PTY or human evidence. Separate real macOS process PTYs
do not use this hook. Two genuine red cases become seven targeted green cases
in build 115, with zero failures/skips. Fresh full native proof remains due.
