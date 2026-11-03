## Problem und Lösung / Problem and solution

DE: Die installierte Model-Routing-Version 0.1.7 und die vorrangigen Root-Resolver bieten die neue breite Erkennung für Claude, OpenCode und Copilot noch nicht vollständig. Diese Lieferung installiert das veröffentlichte Preset **0.2.1** mit Priorität **61** und übernimmt seine vollständigen Resolver-Ressourcen. Codex und agy bleiben unverändert.

EN: Install released Model Routing Governance **0.2.1**, priority **61**, including the complete top-level runtime closure. This enables the released broad-discovery implementation while preserving Codex/agy behavior. Exactly one of fourteen presets changes; thirteen unrelated payloads and registry entries are verified preserved.

Release: [v0.2.1](https://github.com/hindermath/spec-kit-preset-model-routing-governance/releases/tag/v0.2.1), commit `6cf0c98d80f3f68d73ac8148dbbb4d29fe614f95`, archive SHA-256 `5e85338327f5c738dfe4c009b7ba8bcdd2ac664f721447d6561bdc1b8c29bbca` (49 files, 97749 bytes). All archive blobs match that commit; installed content matches this release. Source [PR15](https://github.com/hindermath/spec-kit-preset-model-routing-governance/pull/15) fixes two test-only lint findings from 0.2.0; runtime is unchanged.

## Tests und Grenzen / Tests and limits

- Exact project-specific fourteen-preset matrix and preservation of the other thirteen payloads/registry entries.
- 35 offline root/preset parity and complete-runtime assertions for all five harnesses; 119 installed broad-selection assertions.
- Existing agent-surface parity, full tracked-file PSScriptAnalyzer with the existing pinned settings, Bash syntax and new-commit-range secret scan.
- New native installation CI on macOS, Linux and Windows, plus existing repository gates. Exact-head technical success is required before admin merge.
- German/English installation evidence and limits: `docs/maintenance/model-routing-v021-installation.md` and JSON; README navigation and statistics ledger updated. Documentation Impact **UpdateRequired**, owner Thorsten Hindermann.

Authority: named release/installation, **MergeAndSync with admin bypass**. No other fleet target, application feature, personal-profile refresh/migration, SDK/tool installation, login, inference, image build, container start/replacement, or formal provider/security/accessibility approval. Product/platform acceptance remains separate. Review unavailability is recorded separately from technical success.

## Scope

- [x] Tests
- [x] Docs
- [x] CI/CD
- MicroCalc.Core / MicroCalc.Tui: unchanged.

## Behavioral Notes / Verhaltenshinweise

Spreadsheet behavior and UI remain unchanged. Existing personal model profiles
are preserved; new selection takes effect only on a separately requested refresh.

## Test Plan

Automated: 35 installation assertions, 119 broad-selection assertions, eight
existing agent-surface tests, strict tracked-file PowerShell analysis and exact
matrix verification pass locally. Native PR checks remain required before merge.
.NET build/test and interactive application smoke are not run locally for this
preset-only change; existing product CI remains in place.

Manual/UI captures: not applicable; no UI changes.

## Risks / Risiken

The root resolver can hide the installed preset; complete closure copying and
root/preset parity address that integration risk. Real account availability,
SDK access and inference are separate, unperformed checks.

## Checklist

- [x] Repository conventions followed
- [x] Relevant tests added and run locally
- [x] Bilingual documentation updated
- [ ] Exact-head native PR CI green (required before delivery)
