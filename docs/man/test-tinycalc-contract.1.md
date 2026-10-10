# test-tinycalc-contract(1)

## Deutsches Handbuch

Die PowerShell-7-Funktion `Test-TinyCalcContract` und beide Skripte prüfen denselben
vollständigen TUI-Vertrag. Sie lesen Dateien und den lokalen Git-Stand; sie starten
keine Tests, Produktprozesse, Installation, Restore oder Provideraktion.

```powershell
./scripts/test-tinycalc-contract.ps1 -RepositoryRoot . -Evidence tests/results -Json -WhatIf
. ./scripts/test-tinycalc-contract.ps1
Test-TinyCalcContract -RepositoryRoot . -Evidence tests/results -WhatIf
```

```bash
bash scripts/test-tinycalc-contract.sh --repository-root . --evidence tests/results --json --dry-run
```

Parameter: `RepositoryRoot`, `Contract`, `SourceMap`, `Evidence` (Verzeichnis),
`PinDecision`, `ImpactDecision`; optional `EvidenceRoot` als ausdrücklich erlaubte
zusätzliche Lesewurzel und `GateEvidence` (Standard `gate-proofs.json` innerhalb
des Evidenzverzeichnisses). Bash verwendet die gleichnamigen kebab-case-Optionen.
Die Skripte bieten `Json`/`--json`, `WhatIf`/`--dry-run`; das Cmdlet liefert ein
Objekt. Normalprüfung und Vorschau sind gleichermaßen vollständig read-only.

Das Verzeichnis enthält `*.bundle.json` nach EvidenceBundle-Schema sowie
`gate-proofs.json` nach Gate-Proofs-Schema. `artifactRefs` verwenden Objekte mit
`path` und `sha256`; `assertionProofRef` verwendet
`relativer/pfad#sha256=<64-kleingeschriebene-Hexzeichen>`. Der Validator prüft die
Dateibytes. Assertion-Proofs enthalten die tatsächlich aufgezeichneten
`capabilityId`, `pathId`, `scenarioKind`, `testRef`, `startedAt`, `finishedAt` und
`assertions`; sie müssen mit dem gebundenen Resultat übereinstimmen.
Kommandotext im JSON bleibt Daten und wird niemals ausgeführt.

Absolute Referenzen in JSON, `..` und Symlink-Ausbrüche sind verboten. Explizite
Eingabepfade dürfen absolut sein, müssen aber innerhalb der erlaubten Wurzeln
liegen. JSON-Eingaben sind auf 20 MiB pro Datei begrenzt. Die Ausgabe enthält
keine ANSI-Farben, Rohfehlertexte, Secrets oder privaten absoluten Pfade.

Exit 0: alle angefragten vollständigen Nachweise gültig. Exit 1: Vertrags- oder
Driftverletzung. Exit 2: fehlende/ungültige Inputs oder blockierter Preflight.
Kein Exit erteilt unabhängige Produktabnahme, Owner-Freigabe oder Lieferautorität.
Eine fehlende Plattform ist weder N/A noch ein erfolgreicher lokaler Ersatzlauf.

## English manual

Both launchers use the same PowerShell 7 engine and the `Test-TinyCalcContract`
function. They only read files and local Git state, never running tests, product
processes, installation, restore or provider actions. The examples above show
script, dot-sourced cmdlet and Bash invocation. Preview performs the same complete
zero-write checks as normal validation.

Explicit inputs are repository root, contract, source map, evidence directory,
pin and impact decisions; optional evidence root permits a second read boundary.
Gate evidence defaults to `gate-proofs.json` in the evidence directory. Scripts
offer JSON output; the cmdlet returns an object. Bash uses kebab-case names.

Evidence consists of strict `*.bundle.json` and gate-proofs JSON. Artifact refs
use objects with `path` and `sha256`; assertion-proof refs use
`relative/path#sha256=<64 lowercase hexadecimal characters>` and bind actual
file bytes. Independent assertion-proof files must reproduce the recorded result
identity, test, timestamps and assertions. JSON command strings are never executed.

Reject absolute JSON refs, parent traversal, escaping symlinks, duplicate JSON keys
and inputs exceeding 20 MiB. Explicit input paths may be absolute inside allowed
roots. Output contains no ANSI, raw exceptions, secrets or private absolute paths.
Exit 0 means valid complete evidence, 1 means a violation and 2 means blocked or
invalid inputs. None grants acceptance or delivery authority; missing platforms
cannot be relabelled as N/A or substituted by local unit tests.
