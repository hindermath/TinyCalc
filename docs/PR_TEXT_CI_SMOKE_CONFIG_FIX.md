## Title

`test: fix CI smoke test configuration mismatch`

## Summary

This PR fixes an intermittent CI failure in the TUI smoke tests.
The failing test invoked `dotnet run --no-build` without an explicit configuration, which defaults to `Debug`.
In CI, the solution is built in `Release`, so the smoke run could fail with exit code `1`.

## Included Changes

- Updated `/Users/thorstenhindermann/Codex/TinyCalc/tests/MicroCalc.Tui.Tests/TuiSmokeTests.cs`
  - smoke CLI test now resolves active test configuration (`Debug` or `Release`)
  - passes `--configuration <resolved>` to `dotnet run --no-build`

- Added this PR description file:
  - `/Users/thorstenhindermann/Codex/TinyCalc/docs/PR_TEXT_CI_SMOKE_CONFIG_FIX.md`

## Validation

Validated with the same pattern as CI:

- `dotnet build MicroCalc.sln --configuration Release`
- `dotnet test MicroCalc.sln --configuration Release --no-build`

Additionally validated locally:

- `dotnet test MicroCalc.sln`

## Risk / Impact

- Low risk, test-only change.
- No production/runtime behavior changes.
- Improves CI stability and reduces false-negative PR failures.
