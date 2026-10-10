# Quellen-Preflight / Source preflight

## Deutscher Nachweisblock

2026-10-10, Branch `006-tui-functional-contract`, HEAD `ffc3d56a8975341a686ff6985570369abefcfd2a`. Nur read-only Quellprüfungen; keine Intake-/Serienänderung oder Produktabnahme.

Die folgenden vorhandenen Validatoren liefen aus der Repository-Wurzel. PowerShell mit `pwsh -NoProfile -File`, Bash mit `bash`; jede unten aufgeführte Ausführung endete mit Exit 0.

| Skript unter `.specify/presets/` | PowerShell-Argumente | Bash-Argumente | Ergebnis |
|---|---|---|---|
| `intake-sequencing-governance/scripts/validate-intake-governance-config` | `-Config requirements/intake-governance-config.json -Repo . -Json` | `--config requirements/intake-governance-config.json --repo . --json` | Aligned; 9 aktive Intakes, 13 Serienziele, 9 Abhängigkeiten |
| `intake-sequencing-governance/scripts/validate-intake-series-manifest` | `-File requirements/intakes/series/tinycalc-delivery/manifest.json -Repo . -Json` | `--file requirements/intakes/series/tinycalc-delivery/manifest.json --repo . --json` | Active; TUI Eligible, Migration Completed |
| `intake-sequencing-governance/scripts/validate-intake-series-receipt` | `-File requirements/intakes/series/tinycalc-delivery/receipt.json -Repo . -Json` | `--file requirements/intakes/series/tinycalc-delivery/receipt.json --repo . --json` | Receipt `b5a367bf-a2a2-4f6a-9801-f02acf2183a9` gültig |
| `intake-review-governance/scripts/validate-intake-review-result` | `-Result requirements/intakes/series/tinycalc-delivery/intake-review-result.json -Repo .` | `--result requirements/intakes/series/tinycalc-delivery/intake-review-result.json --repo .` | Review `192a2219-0b1e-4a71-a336-502848cf10b0` current, Series/Ready, 13 Ziele |

Zusätzlich: `node scripts/render-requirements-intake-governance.mjs` und `node scripts/validate-requirements-intake-alignment.mjs` jeweils Exit 0; deterministische Ansichten aktuell, kanonische Artefakte erhalten. Keine pauschale Wiederholung des fachlich abgeschlossenen Intake-Reviews.

TUI-Authoring-Receipt zusätzlich in beiden Varianten geprüft: `intake-authoring-governance/scripts/validate-intake-authoring-receipt.ps1 -Receipt specs/intake-authoring-receipts/tui-funktionsabnahme-und-regressionsvertrag.json -Repo .` und `.sh --receipt` mit demselben Pfad und `--repo .`; beide Exit 0. Receipt `4389131a-dec4-4431-8eb5-0e57c17ec20a`, ReadyForReview, fünf gebundene Quellen, aktuell. / Both additional authoring receipt checks passed with five current source bindings.

| Gebundene Datei | SHA-256 |
|---|---|
| Verbindliches TUI-Intake | `c07016800b9e02e56f123ed6af187d0b5fedd22c1689a1b8909fcc6e8f70c6ac` |
| Serienmanifest | `bccde554dc1ae47c69c4327c6a1e4332bd7f54556e255c75ae5097a541cd71cc` |
| Serienreview-Ergebnis | `88815318b6317facf6e3715695686c44bcf075fbb0aabc8a7d04ce7b4f0c036d` |
| Serienreceipt | `1278c3189d307b00546fe3ea4a9f20a9c5cdb3c3fdc4da49b613fd75e53ee5c4` |
| TUI-Authoring-Receipt | `ff340169c837aa6b32c66cfb2141de79a690f42a4e1457b40a85beccf1677c23` |

## English evidence block

On 2026-10-10 both existing PowerShell and Bash variants completed the four checks above with exit zero. The thirteen-target series is Active, the bound review is current and Ready, the migration predecessor is Completed and this feature is Eligible. Both read-only linked-view/alignment commands also passed. The hashes bind this checkpoint to the canonical source files; no intake was edited and no product acceptance is claimed. The completed substantive review was not rerun unnecessarily.
