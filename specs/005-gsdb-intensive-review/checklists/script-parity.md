# Script-Parität / Script Parity

## Ergebnis / Result

**DE:** PowerShell 7 ist die einzige semantische Engine. Der Bash-3.x-
kompatible Wrapper prüft seine Parameter, normalisiert Aktionsnamen und
delegiert mit sicher gequoteten Argumenten an `pwsh -NoProfile`. Beide
Einstiege liefern für denselben Vertrag identische stdout-/stderr-Zeilen und
Exitcodes.

**EN:** PowerShell 7 is the only semantic engine. The Bash 3.x compatible
wrapper validates its parameters, normalizes action names, and delegates with
safely quoted arguments to `pwsh -NoProfile`. Both entrypoints produce
identical stdout and stderr lines and exit codes for the same contract.

## Prüfliste / Checklist

- [x] `Set-StrictMode -Version Latest` und sichere Parameterprüfung sind aktiv. / Strict mode and safe parameter validation are active.
- [x] `set -euo pipefail`, gequotete Variablen und `--` bei lokalen Dateibefehlen sind vorhanden. / Strict Bash mode, quoted variables, and end-of-options markers for local file commands are present.
- [x] `Test-GsdbIntensiveReview` ist der typisierte Verb-Noun-Einstieg. / The approved Verb-Noun function is the typed entrypoint.
- [x] Fehlender Pfad liefert über beide Einstiege `GSDB001` und Exitcode 1. / A missing path returns GSDB001 and exit code 1 through both entrypoints.
- [x] Laufzeit-Fixtures decken `GSDB002` bis `GSDB010` einzeln ab. / Runtime fixtures cover GSDB002 through GSDB010 individually.
- [x] Produktionsnahe Negativfälle prüfen Traversal, Windows-/Backslash-Pfade, Symlink-Grenzen, exakte Markdown-/JSON-/Skript-/Registry-Locators, ungebundene oder veraltete Evidenz, Preset-Checklist-Drift, umgekehrte/verwaiste/herabgestufte Findings, generische DE/EN-Vorlagen und ungültige Status-/Metadatenkombinationen. / Production-shaped negative cases cover traversal, Windows/backslash paths, symlink boundaries, exact Markdown/JSON/script/registry locators, unbound or stale evidence, preset-checklist drift, reverse/orphaned/downgraded findings, generic DE/EN templates, and invalid status/metadata combinations.
- [x] Ungültige Aktionen und Optionen liefern stabile redigierte Meldungen, ohne den gelieferten Wert zurückzugeben. / Invalid actions and options return stable redacted messages without echoing the supplied value.
- [x] Gültiges Helper-Fixture wird nur als `fixtureMode`, nie als Produktionsmatrix, akzeptiert. / The valid helper is accepted only as fixtureMode, never as a production matrix.
- [x] PowerShell- und Bash-Ausgabe werden für jede Fehlerklasse zeilenweise verglichen. / PowerShell and Bash output is compared line by line for every failure class.
- [x] `bash -n` besteht für Wrapper und Bash-Test. / Bash syntax checks pass for wrapper and Bash test.
- [x] Comment-based Help, Bash-`--help` und Manpage beschreiben Aktionen, Read-only-Grenze, Fehlerklassen und Exitcodes. / All three help surfaces describe actions, the read-only boundary, failure classes, and exit codes.

## Dry-run und WhatIf

**DE:** `-WhatIf` oder ein Dry-run ist `N/A`, weil beide Einstiegspunkte nur
lesen. Jede spätere Schreibfunktion ist der Neubewertungs-Trigger und verlangt
dann eine sichere Vorschau vor der Mutation.

**EN:** `-WhatIf` or dry-run is `N/A` because both entrypoints are read-only.
Any future write capability is the re-evaluation trigger and then requires a
safe preview before mutation.

## Lokaler Nachweis / Local Evidence

| Datum / Date | Plattform / Platform | Prüfung / Check | Ergebnis / Result |
|---|---|---|---|
| 2026-09-06 | macOS, PowerShell 7.6.5 | PowerShell fixtures GSDB001-GSDB010 | Pass |
| 2026-09-06 | macOS, Bash 5.3 in Bash-3-compatible syntax | Bash/PowerShell linewise parity | Pass |
| 2026-09-06 | macOS | `bash -n` | Pass |

Linux- und Windows-Ergebnisse bleiben bis zu tatsächlichen CI-Logs am exakten
PR-Head `Pending`. / Linux and Windows results remain `Pending` until actual CI
logs exist for the exact PR head.
