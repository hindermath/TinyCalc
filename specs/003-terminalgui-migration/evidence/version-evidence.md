# Versionsnachweis / Version Evidence

## Vertrag / Contract

Vor jedem einzelnen `dotnet build` oder `dotnet test` werden `Version`,
`AssemblyVersion` und `FileVersion` atomar auf denselben Wert
`Major.3.Patch.Build` gesetzt. `Patch` ist vor dem Feature-Commit
`git rev-list --count main..HEAD + 1`. `Build` steigt genau einmal je Aufruf.
Restore-, Run-, Audit- und Validatorbefehle aendern den Zaehler nicht.

*Before every individual `dotnet build` or `dotnet test`, all three version
fields are atomically aligned to `Major.3.Patch.Build`. Before the feature
commit, `Patch` is `git rev-list --count main..HEAD + 1`. `Build` increases
exactly once per invocation. Restore, run, audit, and validator commands do not
change the counter.*

## Ausgangszustand / Initial State

- Erfasst / Captured: `2026-08-30T11:27:48Z`
- Commit: `886a13f8866e79fe6c13e6e1227217294aabdee8`
- `git rev-list --count main..HEAD`: `0`
- Prospektiver Patch / Prospective patch: `1`
- Bestehender Wert / Existing value: `1.2.7.2`
- Naechster Build-/Testwert / Next build or test value: `1.3.1.3`
- Felder gleich / Fields aligned: `Version=AssemblyVersion=FileVersion`

## Aufrufe / Invocations

| Nr. | UTC | Alter Wert / Old | Neuer Wert / New | Befehl / Command | Exit | Commit |
|---:|---|---|---|---|---:|---|
| 1 | `2026-08-30T11:43:49Z` | `1.2.7.2` | `1.3.1.3` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `unbeobachtet / unobserved` | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 2 | `2026-08-30T11:49:40Z` | `1.3.1.3` | `1.3.1.4` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `unbeobachtet / unobserved` | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 3 | `2026-08-30T11:53:14Z` | `1.3.1.4` | `1.3.1.5` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `1` | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 4 | `2026-08-30T11:53:58Z` | `1.3.1.5` | `1.3.1.6` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `0` (3 Warnungen / warnings) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 5 | `2026-08-30T11:55:01Z` | `1.3.1.6` | `1.3.1.7` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `0` (0 Warnungen / warnings) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 6 | `2026-08-30T11:59:51Z` | `1.3.1.7` | `1.3.1.8` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `0` (0 Warnungen / warnings) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 7 | `2026-08-30T12:04:06Z` | `1.3.1.8` | `1.3.1.9` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `0` (0 Warnungen / warnings) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 8 | `2026-08-30T12:12:16Z` | `1.3.1.9` | `1.3.1.10` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `0` (0 Warnungen / warnings) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 9 | `2026-08-30T13:14:53Z` | `1.3.1.10` | `1.3.1.11` | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `0` (0 Warnungen / warnings) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 10 | `2026-08-30T13:15:28Z` | `1.3.1.11` | `1.3.1.12` | `dotnet test MicroCalc.sln --configuration Release --no-build` | `0` (79 bestanden / passed, 0 übersprungen / skipped) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |
| 11 | `2026-08-30T13:18:05Z` | `1.3.1.12` | `1.3.1.13` | `dotnet-coverage collect --output /tmp/tinycalc-003/coverage/tests.coverage --output-format coverage -- dotnet test MicroCalc.sln --configuration Release --no-build` | `0` (79 bestanden / passed, 0 übersprungen / skipped) | `886a13f8866e79fe6c13e6e1227217294aabdee8` |

Die ersten beiden Aufrufe erreichten den erfolgreichen Core-Schritt, verloren
aber wegen des beendeten verwalteten Unterprozesses Diagnose und Exitcode. Sie
werden als verbrauchte, nicht bestandene Infrastrukturversuche geführt. Aufruf
3 ist der vollständig beobachtete Ersatz-Red-Build: ausschließlich fünf
Terminal.Gui-v2-Konstruktoren blockierten die TUI. Aufruf 4 war compile-grün,
enthielt aber drei neue `CS0618`-Warnungen. Die eng begrenzte und begründete
Kompatibilitätsbehandlung wurde mit Aufruf 5 bestätigt: vollständige Solution,
Exitcode 0, null Warnungen und null Fehler. Jeder Aufruf hat genau eine eigene
Build-Erhöhung. / *The first two invocations reached the successful Core step,
but diagnostics and exit code were lost when the managed subprocess ended.
They remain consumed, failed infrastructure attempts. Invocation 3 is the
fully observed replacement red build: only five Terminal.Gui v2 constructors
blocked the TUI. Invocation 4 compiled but had three new CS0618 warnings. The
narrow, justified compatibility handling was confirmed by invocation 5: full
solution, exit code 0, zero warnings, and zero errors. Every invocation has
exactly one dedicated Build increment.*

## Prospektive Commit-Ausrichtung / Prospective Commit Alignment

- Erfasst / Captured: `2026-08-30T14:19:00Z`
- `git rev-list --count main..HEAD`: `0`
- Prospektiver Feature-Commitcount / Prospective feature commit count: `1`
- Minor: `3`
- Letzter belegter Buildzähler / Last evidenced build counter: `13`
- Soll- und Istwert / Required and actual value: `1.3.1.13`
- Gleichheit: `Version=AssemblyVersion=FileVersion`

`Directory.Build.props` war bereits exakt auf den prospektiven Commitwert
ausgerichtet und musste deshalb nicht erneut geändert werden. Nach dieser
Ausrichtung wurde kein Build und kein Test gestartet; der belegte Zähler `13`
bleibt erhalten. / *The version file already matched the prospective commit
value exactly, so no additional edit was needed. No build or test ran after
this alignment, and the evidenced build counter remains 13.*
