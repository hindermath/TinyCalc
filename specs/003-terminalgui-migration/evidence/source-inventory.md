# Quellinventar / Source Inventory

## T004 – Ausgangsoberfläche / Baseline surface

Zeitpunkt / Time: `2026-08-30T11:31:00Z`

Die read-only Suche umfasst `Program.cs`, das TUI-Projekt, alle Dateien unter
`tests/MicroCalc.Tui.Tests/` und alle mit `rg` gefundenen Konsumenten. Es gibt
keinen Diff in Core, Tests oder Hilfe.

*The read-only search covers `Program.cs`, the TUI project, every file below
`tests/MicroCalc.Tui.Tests/`, and all consumers found by `rg`. Core, tests, and
help have no diff.*

## Compile- und Lifecycle-Inventar / Compile and lifecycle inventory

- Paket / Package: `Terminal.Gui` `1.19.0`, Ziel / target `net10.0`.
- v1-Lifecycle: `Application.Init` 1, `Application.Top` 1,
  `Application.Run` 3, `Application.Shutdown` 1 und statisches
  `Application.RequestStop` 7.
- Ereignisse / Events: `KeyPress` 2, `KeyEventEventArgs` 1 und
  `Button.Clicked` 5.
- Dialoge / Dialogs: zwei explizite `Dialog`-Konstruktionen; dazu
  `MessageBox.Query`, `PromptText`, Datei-, Funktions-, Eingabe- und Hilfewege.
- Masken / Masks: `CtrlMask` 8, `AltMask` 0.
- Smoke: Die `--smoke`-Prüfung steht vor `Application.Init`; der vorhandene
  Konsument `TuiSmokeTests.SmokeCliFlag_ExitsSuccessfully` fordert Exitcode 0
  und `SMOKE_OK`.

## Bindende Eingaben / Binding inputs

Die 13 historischen Bindings sind einzeln vorhanden:

1. `CursorUp`
2. `Ctrl+E`
3. `CursorDown`
4. `Ctrl+X`
5. `Ctrl+J`
6. `CursorRight`
7. `Ctrl+D`
8. `Ctrl+M`
9. `Enter`
10. `CursorLeft`
11. `Ctrl+S`
12. `Ctrl+A`
13. `Ctrl+Q`

Zusätzliche bestehende Editor-Eingänge sind `/`, `Esc` und druckbares ASCII;
sie gehören nicht zur 13er-Navigations-/Quit-Matrix und dürfen fachlich nicht
erweitert werden.

*Additional existing editor inputs are `/`, `Esc`, and printable ASCII. They
are outside the 13 navigation/quit bindings and must not gain new behaviour.*

## Testkonsumenten / Test consumers

`tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj` referenziert das
TUI-Projekt. `TuiSmokeTests.cs` prüft den direkten Smoke-Runner, die
Fehlerreaktion bei fehlender Hilfe und den CLI-Smoke-Prozess. Diese Dateien
bleiben unverändert.

*The TUI test project references the product. `TuiSmokeTests.cs` verifies the
direct smoke runner, missing-help failure, and CLI smoke process. These files
remain unchanged.*
