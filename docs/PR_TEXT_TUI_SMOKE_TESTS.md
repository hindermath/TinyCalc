## Title

`test: add TUI smoke tests and smoke runner mode`

## Summary

This PR adds a lightweight smoke-test layer for the Terminal.Gui application.
It introduces a non-interactive `--smoke` execution path and a dedicated TUI smoke test project to validate basic runtime wiring.

## Included Changes

- Added smoke execution mode to TUI app:
  - `/Users/thorstenhindermann/Codex/TinyCalc/src/MicroCalc.Tui/Program.cs`
  - supports `--smoke` and returns explicit success/failure output + exit code
- Added smoke runner abstraction:
  - `/Users/thorstenhindermann/Codex/TinyCalc/src/MicroCalc.Tui/Smoke/TuiSmokeRunner.cs`
  - validates core engine render/edit behavior
  - validates help file presence and loadability
- Added dedicated TUI test project:
  - `/Users/thorstenhindermann/Codex/TinyCalc/tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj`
  - `/Users/thorstenhindermann/Codex/TinyCalc/tests/MicroCalc.Tui.Tests/TuiSmokeTests.cs`
- Added project to solution:
  - `/Users/thorstenhindermann/Codex/TinyCalc/MicroCalc.sln`

## Test Coverage Added

- Smoke runner succeeds with valid `CALC.HLP`
- Smoke runner fails with missing help file (expected failure path)
- CLI smoke invocation works:
  - `dotnet run --no-build --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke`
  - expected marker `SMOKE_OK` and exit code `0`

## Validation

- `dotnet build MicroCalc.sln` passes
- `dotnet test MicroCalc.sln` passes
  - `MicroCalc.Core.Tests`: 29 passing
  - `MicroCalc.Tui.Tests`: 3 passing

## Risk / Impact

- No user-visible behavior change in normal interactive mode.
- Low risk; change is additive and focused on testability and CI confidence.
