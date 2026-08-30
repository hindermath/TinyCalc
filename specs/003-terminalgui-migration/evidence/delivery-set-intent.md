# Beabsichtigter Lieferumfang / Intended Delivery Set

## Bindung / Binding

Dieser Pfadsatz ist aus dem akzeptierten `plan.md` mit SHA-256
`2e1ec7e977edf07b435a941f5eba139eabf841a1a6f8d10c1da235ae1a2806c9`
abgeleitet. Er gilt fuer den Produkt-PR von Feature 003. Der spaetere kausale
Closeout besitzt den getrennten, unten beschriebenen Pfadsatz.

*This path set is derived from the accepted `plan.md` with the SHA-256 shown
above. It applies to the Feature 003 product pull request. The later causal
closeout has the separate path set described below.*

Der Hash wurde an T062 nach einer rein mechanischen Entfernung nachgestellter
Leerzeichen neu gebunden. Anforderungen, Reihenfolge, Gates und Lieferumfang
des zuvor analysierten Plans sind textlich unverändert. / *The hash was rebound
at T062 after purely mechanical removal of trailing whitespace. Requirements,
ordering, gates, and delivery scope of the analysed plan are unchanged.*

## Produkt- und Automationspfade / Product and Automation Paths

- `src/MicroCalc.Tui/MicroCalc.Tui.csproj`
- `src/MicroCalc.Tui/Program.cs`
- `.github/workflows/ci.yml`
- `Directory.Build.props`

Nur die beiden TUI-Dateien duerfen Produktcode aendern. `ci.yml` ist die einzige
Workflow-Ausnahme. `Directory.Build.props` enthaelt nur die gemeinsam
ausgerichtete Feature-Version.

*Only the two TUI files may change product code. `ci.yml` is the sole workflow
exception. `Directory.Build.props` contains only the aligned feature version.*

## Feature- und Liefernachweise / Feature and Delivery Evidence

- `.specify/feature.json`
- `specs/003-terminalgui-migration/accessibility-plan.md`
- `specs/003-terminalgui-migration/architecture.md`
- `specs/003-terminalgui-migration/autonomous-run-evidence.md`
- `specs/003-terminalgui-migration/autonomous-run-gate-requirements.json`
- `specs/003-terminalgui-migration/checklists/analyze-remediation-2.md`
- `specs/003-terminalgui-migration/checklists/analyze-remediation.md`
- `specs/003-terminalgui-migration/checklists/plan-review.md`
- `specs/003-terminalgui-migration/checklists/requirements.md`
- `specs/003-terminalgui-migration/contracts/delivery-evidence-contract.md`
- `specs/003-terminalgui-migration/contracts/tui-compatibility-contract.md`
- `specs/003-terminalgui-migration/coverage-plan.md`
- `specs/003-terminalgui-migration/data-model.md`
- `specs/003-terminalgui-migration/delivery-plan.md`
- `specs/003-terminalgui-migration/dependency-plan.md`
- `specs/003-terminalgui-migration/evidence/coverage-summary.md`
- `specs/003-terminalgui-migration/evidence/delivery-set-intent.md`
- `specs/003-terminalgui-migration/evidence/delivery.md`
- `specs/003-terminalgui-migration/evidence/dependencies/dependency-review.md`
- `specs/003-terminalgui-migration/evidence/dependencies/licenses-shipped.json`
- `specs/003-terminalgui-migration/evidence/dependencies/package-selection.md`
- `specs/003-terminalgui-migration/evidence/dependencies/packages-all.json`
- `specs/003-terminalgui-migration/evidence/dependencies/packages-outdated.json`
- `specs/003-terminalgui-migration/evidence/dependencies/packages-vulnerable.json`
- `specs/003-terminalgui-migration/evidence/dependencies/restore-final.txt`
- `specs/003-terminalgui-migration/evidence/dependencies/restore-initial.txt`
- `specs/003-terminalgui-migration/evidence/documentation-review.md`
- `specs/003-terminalgui-migration/evidence/evidence-index.md`
- `specs/003-terminalgui-migration/evidence/manual-tui.md`
- `specs/003-terminalgui-migration/evidence/platform-ci.md`
- `specs/003-terminalgui-migration/evidence/preflight.md`
- `specs/003-terminalgui-migration/evidence/red-green-refactor/red-evidence.md`
- `specs/003-terminalgui-migration/evidence/red-green-refactor/source-contract-red.txt`
- `specs/003-terminalgui-migration/evidence/red-green-refactor/vertical-slice-green.md`
- `specs/003-terminalgui-migration/evidence/regression.md`
- `specs/003-terminalgui-migration/evidence/sbom-generation.md`
- `specs/003-terminalgui-migration/evidence/source-contract-green.md`
- `specs/003-terminalgui-migration/evidence/source-inventory.md`
- `specs/003-terminalgui-migration/evidence/us3-checkpoint.md`
- `specs/003-terminalgui-migration/evidence/version-evidence.md`
- `specs/003-terminalgui-migration/plan.md`
- `specs/003-terminalgui-migration/quickstart.md`
- `specs/003-terminalgui-migration/research.md`
- `specs/003-terminalgui-migration/security-plan.md`
- `specs/003-terminalgui-migration/spec.md`
- `specs/003-terminalgui-migration/supply-chain-plan.md`
- `specs/003-terminalgui-migration/tasks.md`

## Architektur, Sicherheit, A11Y, Statistik und PR / Architecture, Security, A11Y, Statistics, and PR

- `docs/PR_TEXT_TERMINALGUI_MIGRATION.md`
- `docs/accessibility/terminalgui-migration.md`
- `docs/architecture/terminalgui-migration.md`
- `docs/project-statistics.config.json`
- `docs/project-statistics.md`
- `docs/security/README.md`
- `docs/security/adr/README.md`
- `docs/security/adr/003-terminalgui-lifecycle-supply-chain.md`
- `docs/security/arc42-security.md`
- `docs/security/asvs-verification.md`
- `docs/security/dependency-audit.md`
- `docs/security/samm-assessment.md`
- `docs/security/sbom/tinycalc-terminalgui.spdx.json`
- `docs/security/security-checklist.md`
- `docs/security/security-quality-scenarios.md`
- `docs/security/supply-chain-evidence.md`
- `docs/security/threat-model.md`
- `docs/security/zero-trust-applicability.md`

## Getrennter kausaler Closeout / Separate Causal Closeout

Erst nach bestandenem Produkt-PostMerge duerfen der branchgestempelte
Lastenheft-Pfad, die kausal notwendigen Artefakte unter
`requirements/intakes/series/tinycalc-delivery/`, die abschliessende Statistik
und die vor dem Closeout-Merge bekannten getrackten Feature-Nachweise im
einzigen Closeout-Commit stehen. Der aktive Lastenheft-Quellpfad wird dabei
durch das vorhandene Skript umbenannt.

*Only after a passing product post-merge gate may the branch-stamped intake,
the causally required files under the named series directory, final statistics,
and tracked feature evidence known before the closeout merge appear in the
single closeout commit. The existing script renames the active intake source.*

## Ausgeschlossene Pfade / Excluded Paths

Ausgeschlossen sind `src/MicroCalc.Core/`, `tests/`, `CALC.HLP`, `scripts/`,
Agentenflaechen, alle anderen Workflows, `docfx.json`, `_site/`, Feature 004,
FakeDriver-Arbeit, andere Intake-Serien und generierte Build-, Test-, Coverage-
oder Cache-Ausgaben.

*Excluded paths are Core, tests, help, scripts, agent surfaces, every other
workflow, DocFX output, Feature 004, FakeDriver work, other intake series, and
generated build, test, coverage, or cache output.*

## Operativer Run-State / Operational Run State

`specs/003-terminalgui-migration/autonomous-run-state.json` ist kein
Lieferpfad. `git ls-files --error-unmatch` endete mit Exitcode 1. Der exakte
Eintrag in `.git/info/exclude` wurde durch `git check-ignore -v` identifiziert;
dieser lokale Git-Metadateneintrag ist ebenfalls nicht Teil eines Commits.

*The autonomous run state is not a delivery path. `git ls-files
--error-unmatch` exited 1. `git check-ignore -v` identified the exact local
entry in `.git/info/exclude`; that local Git metadata is also not committed.*
