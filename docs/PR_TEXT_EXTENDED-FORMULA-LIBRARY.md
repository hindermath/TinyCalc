# PR: Extended Formula Library (Phase 2)

**Branch**: `codex/extended-formula-library` → `main`
**Spec**: `specs/001-project-context/spec.md`
**Implementation branch**: This branch — one focused PR per Constitution Principle IV.

---

## Summary

Extends MicroCalc's formula engine with 6 new functions — MIN, MAX, AVERAGE, COUNT, IF, ROUND — by modifying a single source file (`FormulaEvaluator.cs`). All changes are confined to `MicroCalc.Core`; no TUI code was modified.

**New functions**:
- `MIN(range)` — minimum of numeric cells in a rectangular range
- `MAX(range)` — maximum of numeric cells in a rectangular range
- `AVERAGE(range)` — arithmetic mean, empty/text cells excluded from both sum and count
- `COUNT(range)` — count of numeric (Constant or Calculated) cells in a range
- `IF(condition, true_value, false_value)` — conditional with mandatory relational operator
- `ROUND(value, decimals)` — rounds using `MidpointRounding.AwayFromZero`

All function names are case-insensitive (`min(…)` and `MIN(…)` are equivalent, per FR-009).

---

## Key Architectural Changes

### 1. `CollectRangeValues` Refactor (T003)

`SumRange`'s traversal loop was extracted into a new `private IReadOnlyList<double> CollectRangeValues(CellAddress from, CellAddress to)` method. `SumRange` now delegates to `CollectRangeValues().Sum()`.

**Backward compatibility**: Only cells with `Constant` or `Calculated` flags contribute values. Empty cells return 0 via `ResolveCellValue`; skipping their 0-contribution preserves the sum. Verified by all existing range-sum golden tests.

### 2. `IsRangeOperatorStart` Disambiguation Guard (T004)

Replaces the unconditional `Match('>')` in `ParseIdentifierBasedFactor` with a guarded check: `Current() == '>' && IsRangeOperatorStart()`. The guard looks ahead two positions: `_position+1` must be a valid column letter (A–G via `SpreadsheetSpec.IsColumnInRange`) and `_position+2` must be a digit.

**Effect**: `A1>B5` (range) is consumed by `ParseIdentifierBasedFactor`; `A1>100` (comparison) leaves `>` for `ParseRelationalOperator`. This is the critical disambiguation enabling IF to support `>` as a comparison operator while preserving existing range-sum semantics.

**Note**: `IF(A1>B5,1,0)` results in a parse error — `A1>B5` is consumed as a range sum, leaving no relational operator for the IF condition. This is expected behavior per FR-005 (relational operator mandatory in IF condition). Users should use subtraction for cell-to-cell comparison: `IF(A1-B1>0, 1, 0)`.

### 3. Extended `ParseIdentifierBasedFactor` Dispatch (T009/T012/T015/T020)

The existing `ApplyFunction` single-argument dispatch was extended with a `switch` for multi-argument functions:
- `"MIN"`, `"MAX"`, `"AVERAGE"`, `"COUNT"` → `ParseRangeAggregateFunction(name)`
- `"IF"` → `ParseIfExpression()`
- `"ROUND"` → `ParseRoundExpression()`
- All others → unchanged `ParseExpression() + ApplyFunction()` path

### 4. New Parse Methods

| Method | Purpose |
|--------|---------|
| `ParseRangeAggregateFunction(string name)` | Handles range/single-cell argument; delegates to `CollectRangeValues`; dispatches to `ApplyAggregate` |
| `ApplyAggregate(string name, IReadOnlyList<double> values)` | MIN/MAX/AVERAGE/COUNT aggregation logic |
| `ParseIfExpression()` | Parses `left relop right, true, false`; mandatory relational operator |
| `ParseRelationalOperator()` | Scans for `<>`, `<=`, `>=`, `<`, `>`, `=` (multi-char first) |
| `EvaluateCondition(double, string, double)` | Evaluates relational comparison with `1e-9` epsilon for equality |
| `ParseRoundExpression()` | Parses `value, decimals`; applies `Math.Truncate` and `Math.Round(AwayFromZero)` |

---

## Constitution Compliance

| Principle | Status | Evidence |
|-----------|--------|---------|
| I. Legacy Behavioral Fidelity | ✅ | All existing golden tests pass; `SumRange` result unchanged |
| II. Layer Separation (NON-NEGOTIABLE) | ✅ | Single file: `FormulaEvaluator.cs`; no TUI/Engine changes |
| III. Test-First Quality Gates (NON-NEGOTIABLE) | ✅ | 47 new test cases; `dotnet test --configuration Release` all GREEN |
| IV. Minimal, Focused PRs | ✅ | `codex/extended-formula-library` branch, one feature per PR |
| V. Simplicity & YAGNI | ✅ | ~200 net new lines; no new projects/abstractions |

---

## Test Coverage

**New test methods** in `FormulaGoldenTests.cs`:
- `Evaluate_MinGoldenCases_ReturnExpectedValues` (Theory, 3 rows)
- `Evaluate_Min_EmptyRange_ReturnsZero` (Fact)
- `Evaluate_Min_RectangularRange_ReturnsMinValue` (Fact)
- `Evaluate_Min_InvertedColumnOrder_NormalizedCorrectly` (Fact)
- `Evaluate_Min_CyclicReference_ReturnsError` (Fact)
- `Evaluate_MaxGoldenCases_ReturnExpectedValues` (Theory, 2 rows)
- `Evaluate_Max_EmptyRange_ReturnsZero` (Fact)
- `Evaluate_Max_RectangularRange_ReturnsMaxValue` (Fact)
- `Evaluate_AverageGoldenCases_ReturnExpectedValues` (Theory, 2 rows)
- `Evaluate_Average_EmptyRange_ReturnsZero` (Fact)
- `Evaluate_Average_RectangularRange_ReturnsCorrectAverage` (Fact)
- `Evaluate_Average_SparseRange_IgnoresEmptyCells` (Fact)
- `Evaluate_CountGoldenCases_ReturnExpectedValues` (Theory, 3 rows)
- `Evaluate_Count_EmptyRange_ReturnsZero` (Fact)
- `Evaluate_Count_SingleEmptyCell_ReturnsZero` (Fact)
- `Evaluate_Count_AllTextRange_ReturnsZero` (Fact)
- `Evaluate_RoundGoldenCases_ReturnExpectedValues` (Theory, 6 rows)
- `Evaluate_Round_NegativeDecimals_ReturnsError` (Fact)
- `Evaluate_IfGoldenCases_ReturnExpectedValues` (Theory, 14 rows)
- `Evaluate_If_NoRelationalOperator_ReturnsError` (Fact)
- `Evaluate_If_FewerThanThreeArgs_ReturnsError` (Fact)
- `Evaluate_If_RangeSumCondition_GreaterIsConsumedAsRangeOp` (Fact)

**New test method** in `MicroCalcEngineTests.cs`:
- `If_ResultTracksRecalculate_WhenDependentCellChanges` (T017a — integration test)

**Total**: 29 existing + 47 new = **76 Core tests** + 3 TUI tests = **79 total**, all GREEN.

---

## Files Changed

| File | Change |
|------|--------|
| `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` | +~200 lines: `CollectRangeValues`, `IsRangeOperatorStart`, `ParseRangeAggregateFunction`, `ApplyAggregate`, `ParseRoundExpression`, `ParseIfExpression`, `ParseRelationalOperator`, `EvaluateCondition` |
| `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` | +~200 lines: new Theory/Fact test methods and helper `SetTextCell` |
| `tests/MicroCalc.Core.Tests/MicroCalcEngineTests.cs` | +~15 lines: T017a integration test |
| `docs/help/microcalc-help.md` | +~90 lines: Page 8 with 6 new function entries |

No other files modified. Four-project solution layout preserved.

---

## Verification Commands

```bash
# Full test suite (CI-aligned)
dotnet test MicroCalc.sln --configuration Release

# Formula golden tests only
dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj --configuration Release --filter "FullyQualifiedName~FormulaGoldenTests"

# Smoke run
dotnet run --no-build --configuration Release --project src/MicroCalc.Tui/MicroCalc.Tui.csproj -- --smoke
```

🤖 Generated with [Claude Code](https://claude.com/claude-code)
