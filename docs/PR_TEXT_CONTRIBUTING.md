## Title

`docs: add CONTRIBUTING guide for CI and PR workflow`

## Summary

This PR adds a focused `CONTRIBUTING.md` that documents the repository's practical PR and CI rules so contributors can avoid recurring pipeline errors.

## Included Changes

- Added `/Users/thorstenhindermann/Codex/TinyCalc/CONTRIBUTING.md`
  - required `codex/*` branch naming and branch lifecycle
  - PR workflow expectations and docs-based PR descriptions
  - CI-critical build/test sequence (`Release` + `--no-build`)
  - explicit rule for smoke tests to pass configuration to `dotnet run --no-build`
  - post-merge cleanup procedure

- Added `/Users/thorstenhindermann/Codex/TinyCalc/docs/PR_TEXT_CONTRIBUTING.md`
  - ready-to-use PR description for this change

## Validation

- Documentation-only change.
- No runtime behavior or tests changed.

## Risk / Impact

- Low risk.
- Improves contributor onboarding and reduces CI regressions caused by workflow drift.
