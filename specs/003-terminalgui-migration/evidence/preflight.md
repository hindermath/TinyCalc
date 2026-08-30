# Vorprüfung / Preflight

## T001 – Laufzustand und akzeptierte Eingaben / Run state and accepted inputs

Zeitpunkt / Time: `2026-08-30T11:24:00Z`
Branch: `003-terminalgui-migration`
Run-ID: `38ad4c1d-bf85-4053-b585-eb490176b727`

Der PowerShell-Validator für den autonomen Lauf endete mit Exitcode `0` und
meldete `stage Implement`, `status Active` sowie `tasks 0/80`. Das gebundene
Plan-Review-Ergebnis wurde ebenfalls mit Exitcode `0` als `Completed` validiert.
Damit ist TG-GATE-001 vor der ersten Implementierungsänderung erfüllt.

*The autonomous-run PowerShell validator exited with code `0` and reported
`stage Implement`, `status Active`, and `tasks 0/80`. The bound plan-review
result also validated as `Completed` with exit code `0`. This satisfies
TG-GATE-001 before the first implementation change.*

| Artefakt / Artefact | SHA-256 |
|---|---|
| `requirements/intakes/active/Lastenheft_TerminalGui_Migration.md` | `fd59040e8bb736b0944e74ab855b72a3a8b843487ae64509926d4a9e79c68160` |
| `requirements/intakes/series/tinycalc-delivery/intake-review-result.json` | `6f33209dedb2c51525f4443e44e1877466bb096bc030a748484936b96299559b` |
| `requirements/intakes/series/tinycalc-delivery/intake-review-request.json` | `7020241199793ab1d94575a7d1f804b27fd916c7cde8597adb22ee654876d042` |
| `requirements/intakes/series/tinycalc-delivery/manifest.json` | `eef3cfd5b9e43395ab9ee59848bb183f1429a3104e5ce4a0980393987a530be2` |
| `specs/003-terminalgui-migration/spec.md` | `cb43e3542f2a692878d271d8fbf1839b7b85fa8f374951c5a44d0539bfaf4bfc` |
| `specs/003-terminalgui-migration/checklists/requirements.md` | `54b469d0f996fb7eb45bf13ca31b7832ae871f4997a967cd13fa70922211d01c` |
| `specs/003-terminalgui-migration/checklists/plan-review.md` | `6dcebf979611f042be56ae7cffd7ebc72b652260395782200daec3d54be80f10` |
| `specs/003-terminalgui-migration/checklists/analyze-remediation.md` | `e18ce95bcf6f67358db25e1c194d0ead48fc0ce89e3353d79b8c6c7460e0fa06` |
| `specs/003-terminalgui-migration/checklists/analyze-remediation-2.md` | `fbd2028626aa3ad00d1338123ac88113abfa59f6440965b3fc2474cb5bd18d96` |

## T002 – Gate-Freeze und Preset-Stack / Gate freeze and preset stack

`jq` fand `48` Gate-Einträge, `48` eindeutige Gate-IDs, keine Duplikate und
keinen leeren `requiredScope`. `rg` bestätigte `40/40` abgeschlossene
Plan-Review-Punkte, sieben als `Fixed` geschlossene Befunde in der ersten und
sechs als `Fixed` geschlossene Befunde in der zweiten Analyze-Remediation.
Die einzigen Treffer für den Text `NEEDS CLARIFICATION` sind der ausdrückliche
Prüftoken in TG-GATE-002 und die T002-Aufgabenbeschreibung; sie sind keine
offenen Marker. Es gibt keine Template-Platzhalter in den akzeptierten
Artefakten.

*`jq` found `48` gate rows, `48` unique gate IDs, no duplicates, and no empty
`requiredScope`. `rg` confirmed `40/40` completed plan-review checks, seven
findings closed as `Fixed` in the first Analyze remediation, and six in the
second. The only `NEEDS CLARIFICATION` text is the explicit TG-GATE-002 search
token and the T002 task wording; neither is an open marker. No template
placeholder remains in accepted artefacts.*

Der materialisierte Stack stimmt mit der kanonischen Acht-Preset-Matrix
überein: `security-governance` v0.6.2/10,
`architecture-governance` v0.5.2/20,
`isaqb-architecture-governance` v0.2.2/30,
`a11y-governance` v0.4.3/40,
`cross-platform-governance` v0.2.2/50,
`agent-parity-governance` v0.4.2/60,
`autonomous-run-governance` v0.4.1/70 und
`parallel-autonomous-run-governance` v0.2.6/80.

*The materialised stack matches the canonical eight-preset matrix with the
versions and priorities listed above.*

## T003 – Betriebssystem und Toolchain / Operating system and toolchain

Zeitpunkt / Time: `2026-08-30T11:28:00Z`

| Werkzeug / Tool | Beobachteter Wert / Observed value |
|---|---|
| Betriebssystem / Operating system | Darwin, macOS `26.6.2`, arm64 |
| PowerShell | `7.6.5` |
| .NET SDK | `10.0.400` |
| Git | `2.50.1 (Apple Git-155)` |
| GitHub CLI | `2.97.0` |
| ripgrep | `15.2.0` |
| jq | `1.7.1-apple` |
| dotnet-coverage | `18.5.2+6e39b75eaf98f2691cf62dbf259669cc13851fd3` |
| Syft | `1.51.0`, `darwin/arm64` |

Alle geforderten Programme sind ausführbar. `gh auth status` endet jedoch mit
Exitcode `1`, weil das Token des aktiven Kontos `hindermath` ungültig ist.
Dieser konkrete Provider-Blocker wird bei T060 erneut geprüft; lokale
Implementierungs- und Prüfschritte benötigen keine Ersatzsprache.

*All required tools are executable. However, `gh auth status` exits with code
`1` because the token for active account `hindermath` is invalid. This concrete
provider blocker is rechecked at T060; local implementation and verification
need no replacement language.*
