# Manueller TUI-Nachweis / Manual TUI Evidence

## Dialog-Sitzung T020 / T020 Dialog Session

- Plattform / Platform: Darwin, Release-Build `1.3.1.8`, echte PTY-Sitzung
  mit standardisierten ANSI-Fähigkeitsantworten. / *Real PTY session with
  standardized ANSI capability responses.*
- Root: genau ein Fenster `MicroCalc .NET 10`; Ausgangszelle und Rückkehrzelle
  jeweils `A1`. / *Exactly one root window; start and return cell both `A1`.*
- Eingabe / Input: Printable-ASCII öffnete sichtbar `Edit A1`; `Esc` brach ab
  und zeigte wieder Root mit `Bearbeitung abgebrochen.`.
- Funktion / Function: `/` öffnete sichtbar den Commands-Dialog mit Load,
  Save, Recalc, Print, Format, Auto, Help, Clear, Quit und Cancel; Abschluss
  kehrte ohne App-Abbruch zum Root zurück.
- Datei / File: `Alt+F`, danach `L`, öffnete sichtbar Load mit Dateifeld, OK
  und Cancel. `Tab` und `Shift+Tab` durchliefen den Dialog vorwärts und
  rückwärts; `Esc` stellte Root und Fokus wieder her.
- Hilfe / Help: `Alt+H`, danach `H`, öffnete sichtbar den Help-Dialog mit
  Seitenfuß und Prev/Next/Close. `Esc` schloss nur Help und stellte Root wieder
  her.
- Beenden / Exit: `Alt+F`, danach `Q`; Exitcode `0`, kein Traceback,
  Terminalmodi und Cursor wurden wiederhergestellt. / *Exit code `0`, no
  traceback, terminal modes and cursor restored.*

Alle vier Dialogarten verwendeten dieselbe laufende Anwendungssitzung. Keine
verschachtelte Stop-Anforderung beendete versehentlich das Root-Fenster. / *All
four dialog types used the same running application session. No nested stop
request accidentally terminated the root window.*

## Vollständige Sitzung 1 / Complete Session 1

### Bediennachweis / Interaction Evidence

- UTC-Ende / UTC end: `2026-08-30T12:21:00Z`
- Plattform / Platform: Darwin, Release-Build `1.3.1.10`, echte PTY-Sitzung
  mit Terminal.Gui-Kitty-Keyboard-Aushandlung. / *Real PTY session with
  Terminal.Gui Kitty keyboard negotiation.*
- Befehl / Command:
  `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/manual-menu.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj`
- Root: genau ein Fenster `MicroCalc .NET 10`; Startzelle `A1`. / *Exactly one
  root window; start cell `A1`.*

| Nr. | Eingabe / Input | Ausgang / Start | Soll / Expected | Ist / Actual | Status |
|---:|---|---|---|---|---|
| 1 | `CursorUp` | `A2` | `A1` | `A1` | Pass |
| 2 | `Ctrl+E` | `A2` | `A1` | `A1` | Pass |
| 3 | `CursorDown` | `A1` | `A2` | `A2` | Pass |
| 4 | `Ctrl+X` | `A1` | `A2` | `A2` | Pass |
| 5 | `Ctrl+J` als eindeutiges CSI-u `Esc [ 106 ; 5 u` | `B1` | `B2` | `B2` | Pass |
| 6 | `CursorRight` | `A1` | `B1` | `B1` | Pass |
| 7 | `Ctrl+D` | `A1` | `B1` | `B1` | Pass |
| 8 | `Ctrl+M` | `A1` | `B1` | `B1` | Pass |
| 9 | `Enter` | `A1` | `B1` | `B1` | Pass |
| 10 | `CursorLeft` | `B1` | `A1` | `A1` | Pass |
| 11 | `Ctrl+S` | `B1` | `A1` | `A1` | Pass |
| 12 | `Ctrl+A` | `B1` | `A1` | `A1` | Pass |

Eine nackte LF-Bytefolge vor dem CSI-u-Nachweis war keine eindeutige physische
`Ctrl+J`-Kodierung und erzeugte keinen beobachtbaren Zellwechsel. Sie wird
nicht als Produkttaste umgedeutet. Der danach ausgeführte eindeutige
Kitty-Keyboard-Code bewegte `B1` nach `B2`. / *A bare LF byte before the CSI-u
proof was not an unambiguous physical Ctrl+J encoding and produced no observed
cell change. It is not relabelled as a product key. The subsequent unambiguous
Kitty keyboard code moved `B1` to `B2`.*

- Eingabe / Input dialog: `z` öffnete sichtbar `Edit B2` mit `Value`, `OK` und
  `Cancel`. `Tab` zeigte den Button-Fokus; `Shift+Tab` stellte den sichtbaren
  Texteingabecursor wieder her. `Esc` kehrte zu `B2` zurück und zeigte
  `Bearbeitung abgebrochen.`. / *The input dialog showed all named controls,
  forward and reverse focus, and returned safely to `B2`.*
- Funktion / Function dialog: `/` öffnete sichtbar `Commands` mit allen zehn
  vorhandenen Auswahlfeldern. Vorwärts-/Rückwärtsfokus blieb im Dialog; `Esc`
  kehrte zu `B2` zurück. / *Commands showed all ten existing choices, retained
  focus traversal, and returned to `B2`.*
- Datei / File dialog: `Alt+F`, danach `L`, öffnete sichtbar `Load` mit
  Dateifeld, `OK` und `Cancel`. `Tab` zeigte Button-Fokus, `Shift+Tab` stellte
  den Texteingabecursor wieder her, und `Esc` kehrte zu `B2` zurück. / *Load
  showed the file field, both buttons, forward and reverse focus, and safe
  return.*
- Menü-Beenden / Menu quit: `Alt+F`, danach `Q`, beendete denselben Prozess mit
  Exitcode `0`. Alternate Screen, Mouse Tracking, Bracketed Paste und Cursor
  wurden sichtbar zurückgesetzt; kein Traceback erschien. / *Menu quit exited
  zero and visibly restored terminal modes and cursor without a traceback.*

### Blockierender Coverage-Befund / Blocking Coverage Finding

`dotnet-coverage` meldete nach dem erfolgreichen TUI-Exit ausdrücklich:
`Keine Codeabdeckungsdaten verfügbar. Profiler wurde nicht initialisiert.`
Die Datei `/tmp/tinycalc-003/coverage/manual-menu.coverage` wurde zwar erzeugt,
ist aber nur 10 Byte groß (`PCH`-Header) und hat SHA-256
`e8e20f058907d569fc3db52359e4a114c88a43378221a5eca7ae35973d515697`.
Sie ist kein gültiger manueller Coverage-Nachweis. T029 bleibt deshalb
ungeprüft und der Lauf stoppt fail-closed bei 28/80 Aufgaben. / *The interaction
journey passed, but the collector explicitly reported that the profiler was
not initialised. Its 10-byte header-only file is not valid manual coverage.
T029 remains unchecked and the run stops fail-closed at 28/80 tasks.*

### Retry mit statischer Instrumentierung / Retry with Static Instrumentation

- UTC-Ende / UTC end: `2026-08-30T12:41:49Z`
- Tool: isoliertes Microsoft `dotnet-coverage` `18.8.0` unter
  `/tmp/tinycalc-003/tools`; die Release-DLL wurde zuvor in eine temporäre
  Ausgabe statisch instrumentiert. / *The isolated Microsoft 18.8.0 tool was
  used after statically instrumenting the Release DLL into a temporary output.*
- Befehl / Command: unverändert mit vorangestelltem Tool-Pfad:
  `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/manual-menu.coverage --output-format coverage -- dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj`.
- Beobachtung / Observation: Der Collector startete mit Session-ID
  `7ebe8604-6632-4fbc-a386-b67249641e4b`, aber der Kindprozess erreichte in
  mehr als 40 Sekunden keine sichtbare Terminalinitialisierung. Die echte PTY
  blieb im Echo-Modus; Root, Startzelle und Eingaben 1–12 konnten deshalb nicht
  sicher beobachtet werden. / *The collector started, but the child process did
  not reach visible terminal initialisation within more than 40 seconds. The
  real PTY stayed in echo mode, so root, start cell, and inputs 1–12 could not
  be observed safely.*
- Sichere Beendigung / Safe termination: Nur die exakte laufende PTY-Session
  wurde mit `Ctrl+C` beendet. Exitcode `130`; danach meldete das Tool erneut
  `Keine Codeabdeckungsdaten verfügbar. Profiler wurde nicht initialisiert.`
- Coverage: weiterhin 10 Byte, SHA-256
  `e8e20f058907d569fc3db52359e4a114c88a43378221a5eca7ae35973d515697`;
  gesichert als
  `/tmp/tinycalc-003/coverage/manual-menu.failed-static-retry.coverage`.
- Wiederherstellung / Restoration: Die Original-DLL wurde sofort
  wiederhergestellt. SHA-256 ist exakt
  `f176e4f857bccdfbe7447970ae5b2fad61832cd023ef6fdcc35555981fe403f2`.

Dieser Retry ist ein eigener fehlgeschlagener Versuch. Er verändert oder
ersetzt den oben dokumentierten vollständigen ersten Bedienversuch nicht.
T029 bleibt offen; T030 wurde nicht gestartet. / *This retry is a separate
failed attempt. It neither changes nor replaces the complete first interaction
attempt above. T029 remains open, and T030 was not started.*

### Erfolgreiche Coverage-Wiederholung / Successful Coverage Retry

- UTC-Ende / UTC end: `2026-08-30T13:07:00Z`
- Tool: isoliertes Microsoft `dotnet-coverage` `18.8.0`; ausschließlich die
  TUI-Release-DLL wurde mit sicherer statischer Managed-Initialisierung
  instrumentiert. Dynamische und native Instrumentierung blieben deaktiviert.
  / *Only the TUI Release DLL was instrumented with safe static managed
  initialisation; dynamic and native instrumentation stayed disabled.*
- Root und Navigation / Root and navigation: Die neue echte PTY-Sitzung
  startete in `A1`. Alle Inputs 1-12 wurden erneut aus den festgelegten
  Ausgangszellen geprüft; Ist- und Sollzellen entsprachen vollständig der
  obigen Matrix. Die mehrdeutigen Steuerzeichen `Ctrl+J`, `Ctrl+M`, `Ctrl+S`
  und `Ctrl+A` wurden zusätzlich als eindeutige CSI-u-Folgen gesendet. / *The
  fresh real PTY started at `A1`; all inputs 1-12 reproduced the matrix above,
  with ambiguous control keys also sent as unambiguous CSI-u sequences.*
- Dialoge / Dialogs: `z` öffnete `Edit A1` mit `Value`, `OK` und `Cancel`;
  `/` öffnete `Commands` mit den vorhandenen Auswahlfeldern; `Alt+F`, danach
  `L`, öffnete `Load` mit Dateifeld, `OK` und `Cancel`. In allen drei Fällen
  funktionierten `Tab`, `Shift+Tab` und `Esc`; Root und Fokus wurden sicher
  wiederhergestellt. / *Input, command, and load dialogs all showed their
  expected controls, supported forward and reverse focus, and returned safely
  to the root.*
- Menü-Beenden / Menu quit: `Alt+F`, danach `Q`, beendete mit Exitcode `0`,
  ohne Traceback. Alternate Screen, Mausmodi, Bracketed Paste und Cursor wurden
  sichtbar wiederhergestellt. / *Menu quit exited zero without a traceback and
  visibly restored all negotiated terminal modes and the cursor.*
- Coverage: `/tmp/tinycalc-003/coverage/manual-menu.coverage`, `27.915` Byte,
  SHA-256 `673f22abee3604dc6b5881bed3ec9c4d7e4b6cdb9c81f084257c9e15f72c0854`.
  Die Zusammenführung nach Cobertura ergab `67.116` Byte, SHA-256
  `e564e58395636e2aabc271f242671c02c9e71a56bfc82f1f98664d3892a878a9`,
  und enthält `MicroCalc.Tui.Program` mit `src/MicroCalc.Tui/Program.cs`.

Die fehlgeschlagenen Versuche bleiben als historische Befunde erhalten. Diese
neue Sitzung ist der erste erfolgreiche vollständige Durchgang, der dieselbe
Bedienreise und gültige Coverage gemeinsam nachweist; damit ist T029 erfüllt.
/ *Earlier failed attempts remain preserved. This is the first successful full
run that combines the complete interaction journey with valid coverage, so
T029 is satisfied.*

## Vollständige Sitzung 2 / Complete Session 2

- UTC-Ende / UTC end: `2026-08-30T13:08:00Z`
- Plattform / Platform: Darwin, Release-Build `1.3.1.10`, getrennte echte
  PTY-Sitzung mit derselben sicheren statischen Managed-Instrumentierung. /
  *Separate real PTY session with the same safe static managed instrumentation.*
- Root: Start in `A1`, leere Zelle, genau ein Fenster. / *Started at empty
  `A1` with exactly one root window.*
- Input 13: `Ctrl+Q` wurde als eindeutige CSI-u-Folge `Esc [ 113 ; 5 u`
  gesendet. Der Prozess beendete sofort mit Exitcode `0`; kein Zellinhalt,
  Dialog oder Traceback entstand. / *Unambiguous Ctrl+Q exited immediately with
  code zero and created no cell content, dialog, or traceback.*
- Terminalrestauration / Terminal restoration: Alternate Screen, Mouse
  Tracking, Bracketed Paste und Cursor wurden sichtbar zurückgesetzt.
- Coverage: `/tmp/tinycalc-003/coverage/manual-ctrlq.coverage`, `27.915` Byte,
  SHA-256 `6aa38d27ae232ec68458081a10f10daf1273b1100858df7bc0f31b06c689478e`.
  Die Cobertura-Zusammenführung ergab `67.028` Byte, SHA-256
  `b10d84d96e87f161ea51fca795e73ee204e87952c5624291ce9d1cc478dec30a`,
  und enthält `MicroCalc.Tui.Program` mit `src/MicroCalc.Tui/Program.cs`.
- Wiederherstellung / Restoration: Direkt nach der Sitzung wurde die
  nicht instrumentierte Release-DLL wiederhergestellt. Repo-DLL und Sicherung
  haben exakt SHA-256
  `f176e4f857bccdfbe7447970ae5b2fad61832cd023ef6fdcc35555981fe403f2`.

Sitzung 2 ist vom Menü-Quit getrennt und belegt den historischen Ctrl+Q-Pfad
eigenständig. Damit ist T030 erfüllt. / *Session 2 is separate from menu quit
and independently proves the historical Ctrl+Q path, satisfying T030.*
