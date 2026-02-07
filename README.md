# MicroCalc .NET 10 (Terminal.Gui)

Portierung der Borland-MicroCalc-Beispielanwendung nach C#/.NET 10 mit Text-UI auf Basis von Terminal.Gui.

## Projekte

- `src/MicroCalc.Core`: Spreadsheet-Logik, Formelparser, Persistenz, Print-Export.
- `src/MicroCalc.Tui`: Terminal-Benutzeroberflaeche.
- `tests/MicroCalc.Core.Tests`: Unit-Tests fuer Kernlogik.

## Start

```bash
dotnet run --project src/MicroCalc.Tui/MicroCalc.Tui.csproj
```

## Tests

```bash
dotnet test MicroCalc.sln
```
