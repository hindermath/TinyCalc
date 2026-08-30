# Vertikaler Green-Slice / Vertical Green Slice

## Release-Build

- UTC: `2026-08-30T11:55:01Z`
- Version: `1.3.1.7`
- Befehl / Command:
  `dotnet build MicroCalc.sln --configuration Release --no-restore`
- Ergebnis / Result: Exitcode `0`, `0` Warnungen / warnings, `0` Fehler / errors.

Die vollständige Solution einschließlich TUI und beider bestehender Testsammlungen
wurde erzeugt. / *The full solution, including the TUI and both existing test
assemblies, was built.*

## Headless Smoke

- UTC: `2026-08-30T11:57:43Z`
- Befehl / Command:
  `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke`
- Ergebnis / Result: Exitcode `0` in `1.3` Sekunden, genau ein sichtbares
  `SMOKE_OK`, keine TUI-Initialisierung. / *Exit code `0` in `1.3` seconds,
  exactly one visible `SMOKE_OK`, and no TUI initialization.*

## Erster manueller macOS-Slice / First Manual macOS Slice

- Plattform / Platform: Darwin, echte PTY-Sitzung / real PTY session.
- Versuch / Attempt: `1`; nicht neu etikettiert / not relabelled.
- Start: Das Alternate-Screen-Setup wurde sichtbar; nach den standardisierten
  Terminal-Fähigkeitsantworten erschien genau ein Root-Fenster mit Titel
  `MicroCalc .NET 10`, File/Sheet/Help-Menü, Zellraster, Status und Meldungszeile.
- Menü: `Alt+F` zeigte sichtbar Load, Save, Print und Quit. Eine vom einfachen
  PTY zunächst als Root-Navigation interpretierte Cursorfolge öffnete Load;
  `Esc` schloss den Dialog und stellte dasselbe Root-Fenster wieder her.
- Beenden: `Alt+F`, danach der sichtbare `Q`-Accelerator, löste ausschließlich
  Menü-Quit aus. / *`Alt+F`, followed by the visible `Q` accelerator, invoked
  menu Quit only.*
- Ergebnis / Result: Exitcode `0`; kein Traceback; Alternate Screen, Mouse
  Tracking, Bracketed Paste und Cursorzustand wurden zurückgesetzt. / *Exit
  code `0`; no traceback; alternate screen, mouse tracking, bracketed paste,
  and cursor state were restored.*

Dieser Slice ist nur der frühe Lifecycle-Nachweis. Er ersetzt nicht die zwei
vollständigen Sitzungen für SC-006. / *This slice is only the early lifecycle
proof. It does not replace the two complete SC-006 sessions.*

## Lifecycle-Source-Contract

- Befehl / Command: inline PowerShell contract against
  `src/MicroCalc.Tui/Program.cs`.
- Ergebnis / Result: Exitcode `0`, `LIFECYCLE_CONTRACT=PASS`.
- Zählwerte / Counts: `Application.Top=0`, statische `Init/Run/Shutdown=0`,
  `Create().Init()=1`, `IApplication`-Owner `=1`, Root-Owner `=1`,
  `app.Run(root)=1`, gebundene `RequestStop`-Pfade `=7`, creator-owned
  Dialogstrecken `=2`. / *Bound RequestStop paths `=7`; creator-owned dialog
  paths `=2`.*
