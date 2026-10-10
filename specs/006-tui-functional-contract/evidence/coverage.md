# Geänderte Produktzeilen / Changed product lines

## Deutscher Nachweis

Build 105 verwendet unverändert `coverlet.collector` 8.0.0. Der reale
PTY-Kindprozess startet die Produktkopie im Testoutput; dadurch werden auch
`Program` und `TerminalStateLease` gemessen. Kein neues Paket und keine dauerhafte
Produktinstrumentierung. Core- und TUI-Cobertura werden nach Datei/Zeile
vereinigt; doppelte Attachments erhöhen den Nenner nicht.

```text
pwsh -NoProfile -File scripts/measure-tui-changed-coverage.ps1 -Json
```

Vergleichsbasis ist `ffc3d56a8975341a686ff6985570369abefcfd2a`. Git-Hunks
bestimmen aktuelle hinzugefügte/geänderte C#-Zeilen unter `src`; ungetrackte neue
Produktdateien zählen vollständig. Nicht-C#-Diffheader setzen den Dateikontext
zurück. Nur ausführbare, im Collector vorhandene Sequenzpunktzeilen gehören in
den Coverage-Nenner, nicht Kommentare, Leerzeilen, Assets oder Tests.

**488/503 = 97,02 Prozent**, Gate ≥70 und separates Ziel ≥80 erreicht.
Das ist weder Branch-Coverage noch 100-Prozent-Plattform-/Tupelabnahme.

| Datei unter `src/` | Treffer / geänderte ausführbare Zeilen |
|---|---:|
| Core/Engine/MicroCalcEngine.cs | 24/24 |
| Core/Formula/FormulaEvaluator.cs | 26/27 |
| Core/IO/SpreadsheetJsonStorage.cs | 20/20 |
| Tui/GridColorScheme.cs | 2/2 |
| Tui/Help/HelpDocument.cs | 2/2 |
| Tui/Program.cs | 6/10 |
| Tui/Smoke/TuiSmokeRunner.cs | 0/1 |
| Tui/TerminalStateLease.cs | 31/39 |
| Tui/TuiSession.cs | 377/378 |

Dateikürzel Core/Tui stehen für MicroCalc.Core/MicroCalc.Tui. Der Bericht
`TestResults/006-changed-coverage105.json` hat SHA-256
`b355d48f4f9c7524c52a76209225d1d4b57cd1b7d43c7ca09fac12e7f3342335`.
Die unterschiedlichen Collectorberichte haben SHA-256
`225af1c45848ff1823145a02de512abd95a6a8f412fc1e07b7e0df6ae0218be0`
und `de0e75e359ce6170e88283236c56a93fc48d3511f9e830e7fe25d9bcffbd4479`.

Nach Collectorende stimmen DLL **und** PDB im TUI-Testoutput bytegleich mit dem
unveränderten Originaloutput überein. Core-DLL-SHA-256:
`8abbf39031834ee3b9461be9ce356d1916a7bf1192cf81eaed2577eca8dcd2ac`;
TUI-DLL: `d12cb877647193c6bb5c24dd9a4fc2a9d402847f6f21892377bc90303546b6f2`.
Die Originaldateien wurden nicht instrumentiert. Nicht getroffene Fehlerzweige
bleiben sichtbar; keine Ausschlussattribute oder Nennerverkürzung hinzugefügt.

## English evidence

Unchanged collector 8.0.0 measured Core and the actual out-of-process TUI copied
into test output. Union reports by source file/line, including new product files
and only changed executable sequence-point lines. Non-C# diff headers reset the
source context; duplicate attachments cannot increase counts.

The reproducible read-only measurement is 488/503 = 97.02%, meeting both the 70%
gate and 80% target, not branch coverage or full platform acceptance. The table
and hashes bind Build-105 originals. DLLs and PDBs for Core/TUI were restored
byte-for-byte against untouched original build output. No new package, persistent
instrumentation, exclusion attribute or removed uncovered branch was used.
