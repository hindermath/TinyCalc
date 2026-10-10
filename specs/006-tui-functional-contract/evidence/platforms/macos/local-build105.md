# macOS: tatsächlicher lokaler Vollvertrag / Actual local full contract

## Deutscher Nachweis

2026-10-10, macOS 27.0 arm64, .NET 10.0.401, PowerShell 7.6.6.
Build 105: Core 217, TUI 452 Pass; null Fail/Skip. Alle 364 unterschiedlichen
Pflichtpfade und 462 serialisierte Assertions stammen aus demselben Lauf.
Die frühere Build-91-Ausgabe bleibt separat unter `TestResults/native-ci-build91`.

```text
dotnet test MicroCalc.sln --configuration Release --no-restore --collect:"XPlat Code Coverage" --logger trx --results-directory tests/MicroCalc.Tui.Tests/TestResults/native-ci
pwsh -NoProfile -File scripts/collect-tui-contract-evidence.ps1 -Action Collect
```

Vor dem Test erfasste `Capture` denselben Befehl, Runner `macOS 27.0 arm64 local`
und Job `Feature-006-local-build105`. Der Collector startete selbst keine Tests.
Er prüfte beide bestandenen TRX-Dateien, Resultatschemas, tatsächliche Testklasse,
ID, Zeit, Assertions, Artefakthashes und vollständigen nativen Nenner: Exit 0,
`NATIVE_AUTOMATION_BOUND: macos; 364 paths`.

| Bindung | Tatsächlicher Wert |
|---|---|
| HEAD | `8115513d803bae4914f84df98ce36491752e1df4` |
| Arbeitsbaumdigest | `bb4282416e03d545b7ed9e23efb1b937b67ce064adddc82bd5de9631c0cccd4c` |
| Vertragsrevision / Digest | 2 / `9fe07a0f4a1e8cfaf6b50f1054ed2fd60eafed4061e855644e8d762a923acce4` |
| Bundle-Run-ID | `0d54fe90-f8a1-47b0-adcb-ffe74b006042` |
| Payload-Digest | `ba1bdcb6dff32c99d5c9e5a3f187a2dbf18e9a90cca8d062bf9c50e8b02ca95a` |
| Bundle-Datei-SHA-256 | `6433e49eb010a6c55881f0a3f96f5dbe3cd47cd90950806443e73454b7a3001a` |
| Testlog-SHA-256 | `08a192b7560900aabc428985002c76d9b5403aa8e632a1de1c231ca73c612c7b` |
| Pfad-Ausgabe | `tests/MicroCalc.Tui.Tests/TestResults/contract-cases/c6ed655d44e9431f853a9da0c84bb567` |
| Beobachtungsfenster | 19:30:42.979674–19:34:00.814188 Europe/Berlin |

`macos.bundle.json` liegt unverändert im ignorierten `TestResults/native-ci`.
Das ist ein gebundener lokaler Zwischenstand, kein finales Exact-Head-Paket.
Spätere Dokumentationsänderungen werden nicht auf diesen Digest umetikettiert.
Linux/Windows, menschliches VoiceOver und unabhängige Abnahme bleiben getrennt.

Echte Prozesse prüfen 80x24/120x40: sichtbaren Text, Raster, Editor/Enter,
Kontrast und Terminalrücksetzung. Der ergänzende 80x24-Prozess prüft Navigation,
Palette/Recalculate, Load/Fehlermeldung und Hilfe. Expect beantwortet nur echte
Terminalabfragen; Sollzustände werden aus dem Rohtrace rekonstruiert. Nur die
eigene Prozessgruppe wird bereinigt. Fristen 30/180/5 Sekunden bleiben bestehen;
die Gesamtsuite aus vielen isolierten Sitzungen ist keine einzelne Sitzung.

## English evidence

Build 105 passed 217 Core and 452 TUI tests with zero failures/skips. One run
produced all 364 paths and 462 independent serialized assertions. Capture bound
the actual command, local runner/job and hashes before execution. Collection
validated both TRX files, exact TUI test identity/timing, schemas, assertions,
artifacts and the complete native denominator, then exited zero.

The table binds immutable ignored originals, not a final delivery head. Later
documentation must not relabel this working-tree digest. Real processes cover
both required terminal sizes and restoration; the extra 80x24 session covers
navigation, commands, files/errors and help. Terminal protocol replies do not
set product state. The 30/180/5-second owned-session limits remain unchanged.
Linux/Windows, human VoiceOver and independent acceptance remain separate.
