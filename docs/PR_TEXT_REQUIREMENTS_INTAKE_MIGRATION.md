# PR: Consolidate TinyCalc requirements and intake governance

## Problem / Problem

TinyCalc kept one historical product plan, nine active Lastenhefte, two
competing order documents, and first-generation receipts at repository root or
under unrelated evidence directories. The current execution order and the
historical baseline were therefore difficult to distinguish.

*TinyCalc kept one historical product plan, nine active intakes, two competing
order documents, and first-generation receipts at repository root or in
unrelated evidence directories. This made current execution order and the
historical baseline difficult to distinguish.*

## Lösung / Solution

- Preserve the product plan and all predecessor intakes byte-identically under
  `requirements/baseline/` and `requirements/intakes/history/`.
- Publish a slim `Pflichtenheft.md`, one active-intake directory, and one
  machine-readable series with exactly one `Eligible` target.
- Supersede schema-1.1 receipts with validated schema-2.0 receipts.
- Add config-driven Bash, PowerShell, Node, negative-fixture, and three-OS CI
  validation.
- Align current documentation and maintained agent guidance without starting a
  Spec Kit feature.

## Risiken / Risks

The migration changes requirement paths. Supersession receipts, preserved
predecessors, normalized hashes, and deterministic validators make that change
reviewable. Product code, APIs, dependencies, and runtime behavior are
unchanged.

## Testplan / Test Plan

- `bash scripts/validate-requirements-intake-alignment.sh`
- `pwsh -NoProfile -File scripts/validate-requirements-intake-alignment.ps1`
- `node scripts/tests/requirements-intake-alignment-tests.mjs`
- `node scripts/reconcile-requirements-intakes.mjs`
- `specify check`
- `git diff --check`
- `pwsh -NoProfile -File scripts/check-homogeneity.ps1`
