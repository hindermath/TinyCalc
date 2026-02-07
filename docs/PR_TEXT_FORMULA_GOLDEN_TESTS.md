## Title

`test: add formula golden regression suite`

## Summary

This PR expands formula-engine coverage with a dedicated golden regression suite.
The goal is to lock in current evaluator behavior and detect parser/evaluator regressions early.

## Included Changes

- New test file: `/Users/thorstenhindermann/Codex/TinyCalc/tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs`
- Data-driven golden cases for:
  - operator precedence (`+`, `-`, `*`, `/`, `^`)
  - normalization (`.5`, `+7`, exponent notation)
  - built-in functions (`ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`)
  - cell references and range sums (`A1>B5`)
- HLP-based reference formulas, including the complex `CALC.HLP` example
- Negative golden cases (division by zero, unknown function, out-of-range cell reference, cyclic references)
- Nested formula resolution test through referenced formula cells

## Validation

- `dotnet build MicroCalc.sln` passes
- `dotnet test MicroCalc.sln` passes
- Current result: 29/29 tests green

## Risk / Impact

- No runtime feature changes; this PR only adds tests.
- Low risk, high value for regression protection.
