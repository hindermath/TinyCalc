# Plattform-CI-Nachweis / Platform CI Evidence

## Bindung / Binding

| Feld / Field | Wert / Value |
|---|---|
| Pull Request | `https://github.com/hindermath/TinyCalc/pull/60` |
| Workflow | `ci` aus `.github/workflows/ci.yml` |
| Run | `33317549562` |
| Unveränderliche Run-URL / Immutable run URL | `https://github.com/hindermath/TinyCalc/actions/runs/33317549562` |
| Ereignis / Event | `pull_request` |
| Head SHA | `d0a5bd435488d9c57a905f883e6c90a919b0c134` |
| Run-Zustand / Run state | `completed`, `success` |
| Provider-Zeitfenster / Provider window | `2026-08-30T14:41:19Z` bis `2026-08-30T14:42:28Z` |

Diese Evidenz zählt ausschließlich den Pull-Request-Run auf dem gebundenen
Head. Frühere Push-Runs, gleichnamige Jobs auf einem anderen Ereignis und
lokale macOS-Nachweise ersetzen ihn nicht. / *This evidence counts only the
pull-request run at the bound head. Earlier push runs, same-named jobs from a
different event, and local macOS evidence do not replace it.*

## Ubuntu-Produktjob / Ubuntu Product Job

| Feld / Field | Wert / Value |
|---|---|
| Job | `build-test (ubuntu-latest)` |
| Job-ID | `99273646336` |
| Unveränderliche URL / Immutable URL | `https://github.com/hindermath/TinyCalc/actions/runs/33317549562/job/99273646336` |
| Runner-Label | `ubuntu-latest` |
| Tatsächliches Image / Actual image | `ubuntu-24.04` |
| Zeitraum / Window | `2026-08-30T14:41:19Z` bis `2026-08-30T14:41:50Z` |
| Ergebnis / Result | `completed`, `success` |

| Schritt / Step | Exakter Befehl / Exact command | Provider-Ergebnis / Provider result |
|---|---|---|
| Restore | `dotnet restore MicroCalc.sln` | `success`, Exitcode `0` |
| Build | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `success`, Exitcode `0`, `Build succeeded.` |
| Test | `dotnet test MicroCalc.sln --configuration Release --no-build` | `success`, Exitcode `0`, 76 Core + 3 TUI = 79 bestanden, 0 fehlgeschlagen, 0 übersprungen |
| Smoke | `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` | `success`, Exitcode `0`, genau eine sichtbare Zeile `SMOKE_OK` |

Der Smoke-Schritt prüfte zusätzlich maschinenlesbar, dass die Ausgabeliste
genau ein Element enthält und dieses Element ordinal exakt `SMOKE_OK` ist. /
*The smoke step also checked that the output list contains exactly one item
and that its ordinal value is exactly `SMOKE_OK`.*

## Windows-Produktjob / Windows Product Job

| Feld / Field | Wert / Value |
|---|---|
| Job | `build-test (windows-latest)` |
| Job-ID | `99273646446` |
| Unveränderliche URL / Immutable URL | `https://github.com/hindermath/TinyCalc/actions/runs/33317549562/job/99273646446` |
| Runner-Label | `windows-latest` |
| Tatsächliches Image / Actual image | `windows-2025-vs2026` |
| Zeitraum / Window | `2026-08-30T14:41:21Z` bis `2026-08-30T14:42:28Z` |
| Ergebnis / Result | `completed`, `success` |

| Schritt / Step | Exakter Befehl / Exact command | Provider-Ergebnis / Provider result |
|---|---|---|
| Restore | `dotnet restore MicroCalc.sln` | `success`, Exitcode `0` |
| Build | `dotnet build MicroCalc.sln --configuration Release --no-restore` | `success`, Exitcode `0`, `Build succeeded.` |
| Test | `dotnet test MicroCalc.sln --configuration Release --no-build` | `success`, Exitcode `0`, 76 Core + 3 TUI = 79 bestanden, 0 fehlgeschlagen, 0 übersprungen |
| Smoke | `dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke` | `success`, Exitcode `0`, genau eine sichtbare Zeile `SMOKE_OK` |

Auch der Windows-Smoke verwendete dieselbe exakte Ausgabebedingung. Der Jobname
allein wurde nicht als Beleg gewertet; Befehle, Step-Ergebnisse, Logausgabe,
Runner und Head wurden gemeinsam geprüft. / *Windows used the same exact
output condition. The job name alone was not accepted; commands, step results,
log output, runner, and head were reviewed together.*

## Schlussfolgerung und Grenze / Conclusion and Boundary

Die plattformbezogenen Produktgates für Ubuntu und Windows sind auf dem
unveränderten PR-Head bestanden. Diese Datei belegt noch keine übrigen
Repository-Checks, keine Review-Konvergenz, keine Schema-2.0-Gesamtevidenz und
keinen Merge. Jede spätere Änderung des `headRefOid` macht diesen Nachweis
ungültig und verlangt eine vollständige Wiederholung. / *The Ubuntu and
Windows product gates pass at the unchanged pull-request head. This file does
not yet prove all repository checks, review convergence, complete schema-2.0
evidence, or merge. Any later head change invalidates this proof.*
