# Rot-Nachweis / Red Evidence

## Source-Vertrag / Source Contract

- Befehl / Command: inline PowerShell source contract against
  `src/MicroCalc.Tui/MicroCalc.Tui.csproj` and `src/MicroCalc.Tui/Program.cs`
- Exitcode / Exit code: `1` (erwartet / expected)
- Rohbeleg / Raw evidence:
  `specs/003-terminalgui-migration/evidence/red-green-refactor/source-contract-red.txt`
- SHA-256: `467c1a6dd178d8c0aef2a0833bfa20061fb02c8279789f51734da3ad08bbd7ee`

Der Vertrag fand ausschließlich den vorgesehenen Ausgangszustand: v1-Paket,
statischer Lifecycle, acht `CtrlMask`-Ausdrücke und fehlende v2-Symbole. Die
13 Eingaben waren vollständig inventarisiert. / *The contract found only the
planned initial state: v1 package, static lifecycle, eight CtrlMask expressions,
and missing v2 symbols. All 13 inputs were inventoried.*

## Compile-Red und beobachteter Ersatz / Compile Red and Observed Replacement

- UTC: `2026-08-30T11:43:49Z`
- Befehl / Command:
  `dotnet build MicroCalc.sln --configuration Release --no-restore`
- Exitcode / Exit code: `unbeobachtet / unobserved`
- Version: `1.3.1.3`
- Commit: `886a13f8866e79fe6c13e6e1227217294aabdee8`
- SHA-256 der Eingaben / Input hashes:
  `Program.cs=faa8fe7b348fde00572339181226ac9c2248e9ea5ccbe0f9621a5bcc37bf1950`,
  `MicroCalc.Tui.csproj=4ec7597b21443a7ba10204df46ad2e4148397cbceea4c533413f65a36e3b484c`.

`MicroCalc.Core` wurde erfolgreich erzeugt und die TUI-Ausgabe blieb
unverändert. Der verwaltete Phasen-Unterprozess verlor jedoch die abschließende
TUI-Diagnose und den Exitcode. Dieser erste Aufruf bleibt deshalb als
verbrauchter Infrastrukturversuch gekennzeichnet. / *MicroCalc.Core built and
the TUI output remained unchanged. The managed phase subprocess lost the final
TUI diagnostics and exit code, so this first invocation remains classified as
a consumed infrastructure attempt.*

Der vollständig beobachtete Ersatzlauf erfolgte am
`2026-08-30T11:53:14Z` mit Version `1.3.1.5`, demselben Befehl und Exitcode
`1`. Seine Eingabe-Hashes lauten
`Program.cs=7401e665a3a7495144aa7f535bc934251ad8f7182fcb7eaabda554f0702d8abe`,
`MicroCalc.Tui.csproj=4ec7597b21443a7ba10204df46ad2e4148397cbceea4c533413f65a36e3b484c`
und
`Directory.Build.props=28e7e8f005d912cdb4f140ba0c4b849b64a212589216d8c231d3c4ae260cf3f1`.
Der Compiler meldete ausschließlich fünf `CS1729`-Fehler für vier alte
`Label(...)`- und einen alten `TextField(...)`-Konstruktor in `Program.cs`.
Core und Core-Tests bauten; es gab keinen Restore-, Core-, Test- oder
Toolchainfehler. Damit ist die v2-Kompatibilitätsklasse exakt abgegrenzt. /
*The fully observed replacement ran at `2026-08-30T11:53:14Z` with version
`1.3.1.5`, the same command, and exit code `1`. The compiler reported only
five `CS1729` failures for four legacy `Label(...)` constructors and one
legacy `TextField(...)` constructor in `Program.cs`. Core and Core tests
built; there was no restore, Core, test, or toolchain failure. This precisely
bounds the v2 compatibility failure class.*

Die anschließende minimale Konstruktoranpassung führte über einen compile-grünen
Zwischenlauf mit drei `CS0618`-Warnungen zum endgültigen Green-Build
`1.3.1.7`: Exitcode `0`, null Warnungen, null Fehler. Die Warnungen wurden nur
an den drei weiterhin intake-konformen `TextView`-Verwendungen lokal und
begründet behandelt; ein zusätzliches Editor-Paket blieb außerhalb des
genehmigten Abhängigkeitsumfangs. / *The following minimal constructor change
led through a compile-green intermediate run with three `CS0618` warnings to
the final `1.3.1.7` green build: exit code `0`, zero warnings, zero errors.
The warnings are handled locally and with justification only at the three
intake-compatible `TextView` uses; no extra editor package entered the approved
dependency scope.*

## Scope-Prüfung / Scope Check

- `git diff --exit-code -- src/MicroCalc.Core tests CALC.HLP`: Exitcode `0`.
- Bestehende Testquellen, Core und `CALC.HLP` sind unverändert. / *Existing
  test sources, Core, and CALC.HLP are unchanged.*
- Der Rot-Zustand enthält nur laufzugehörige Feature-Artefakte, die exakte
  Paketänderung und den serialisierten Versionswert. / *The red state contains
  only run-owned feature artefacts, the exact package change, and the serialized
  version value.*
