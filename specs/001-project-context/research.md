# Research: Phase 2 – Extended Formula Library

**Branch**: `001-project-context` | **Date**: 2026-02-28
**Source**: Analysis of `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (458 lines)

---

## Decision 1: Extension Point

**Decision**: Extend `ParseIdentifierBasedFactor` in the nested `Parser` class inside
`FormulaEvaluator.cs`. No new files, classes, or public types are introduced.

**Rationale**: All 10 existing functions are dispatched from `ParseIdentifierBasedFactor` via
`ApplyFunction()`. Adding MIN/MAX/AVERAGE/COUNT/IF/ROUND follows the identical pattern. The
parser is a private nested class — there is no public API surface to version.

**Alternatives considered**:
- Separate `AggregateEvaluator` class: rejected — violates Principle V (YAGNI), one pattern
  for all functions is simpler.
- Extending `EvaluationResult` to carry text: rejected — not needed (IF branches are
  numeric-only per spec §FR-008, §Clarifications session 2026-02-28).

---

## Decision 2: Range Value Collection Refactor

**Decision**: Extract a new private method `CollectRangeValues(CellAddress from, CellAddress to)`
that returns `IReadOnlyList<double>` (numeric values of all cells in the rectangular range,
skipping empty/text cells). Refactor `SumRange` to call `CollectRangeValues().Sum()`. MIN, MAX,
AVERAGE, and COUNT all call `CollectRangeValues`.

**Rationale**: The existing `SumRange` traverses the range but discards individual values.
MIN/MAX/AVERAGE/COUNT require individual values. This refactor avoids duplicating the traversal
loop and ensures cyclic-reference detection is applied consistently (via the existing
`ResolveCellValue` call inside the loop).

**Implementation sketch**:
```csharp
private IReadOnlyList<double> CollectRangeValues(CellAddress from, CellAddress to)
{
    var startCol = Math.Min(SpreadsheetSpec.ColumnToIndex(from.Column),
                            SpreadsheetSpec.ColumnToIndex(to.Column));
    var endCol   = Math.Max(SpreadsheetSpec.ColumnToIndex(from.Column),
                            SpreadsheetSpec.ColumnToIndex(to.Column));
    var startRow = Math.Min(from.Row, to.Row);
    var endRow   = Math.Max(from.Row, to.Row);

    var values = new List<double>();
    for (var row = startRow; row <= endRow; row++)
        for (var col = startCol; col <= endCol; col++)
        {
            var addr = new CellAddress(SpreadsheetSpec.IndexToColumn(col), row);
            var cell = _sheet.GetCell(addr);
            if (cell.Status.HasFlag(CellStatusFlags.Constant) ||
                cell.Status.HasFlag(CellStatusFlags.Calculated))
                values.Add(ResolveCellValue(addr));
        }
    return values;
}

private double SumRange(CellAddress from, CellAddress to)
    => CollectRangeValues(from, to).Sum();
```

**Alternatives considered**:
- LINQ `.Where` on all cells: equivalent but less readable for the row/column loop pattern
  already established in SumRange.

---

## Decision 3: `>` Disambiguation Lookahead

**Decision**: Replace the unconditional `Match('>')` in `ParseIdentifierBasedFactor` (line 189
of the current file) with a guarded check: consume `>` and enter range-sum mode ONLY when the
character immediately after `>` is a valid column letter (A–G) followed by a digit. Otherwise,
leave `>` unconsumed so IF condition parsing can treat it as a comparison operator.

**Rationale**: `IF(A1>100, 1, 0)` currently fails because after parsing `A1`, the parser sees
`>`, tries to parse a cell address, and fails on `1` (not a letter). The guard makes `A1>100`
parse `A1` as a cell reference and leave `>100` for the IF condition parser. `A1>B5` retains
existing range semantics because `B5` passes the lookahead test.

**Implementation**:
```csharp
// In ParseIdentifierBasedFactor, replace:
//   if (Match('>')) { var to = ParseCellAddress(); return SumRange(from, to); }
// With:
if (Current() == '>' && IsRangeOperatorStart())
{
    _position++; // consume '>'
    var to = ParseCellAddress();
    return SumRange(from, to);
}
return ResolveCellValue(from);

// New helper:
private bool IsRangeOperatorStart()
{
    // Returns true if the char after '>' is a valid cell address start (ColLetter + Digit)
    var next = _position + 1;
    if (next >= _text.Length) return false;
    var col = char.ToUpperInvariant(_text[next]);
    if (!SpreadsheetSpec.IsColumnInRange(col)) return false;
    return next + 1 < _text.Length && char.IsDigit(_text[next + 1]);
}
```

**Alternatives considered**:
- Exception-based backtracking: catch the "Spalte erwartet" error and back up — rejected as
  control flow via exceptions is fragile and slow.
- Separate parser mode flag for "inside IF condition": rejected — more invasive.

---

## Decision 4: Multi-Argument Function Dispatch

**Decision**: In `ParseIdentifierBasedFactor`, detect function names that require special
parsing BEFORE calling `ParseExpression()` for the argument:

```
ParseName() → check against dispatch table:
  MIN/MAX/AVERAGE/COUNT → ParseRangeAggregateFunction(name)
  IF                    → ParseIfExpression()
  ROUND                 → ParseRoundExpression()
  (others)              → existing: ParseExpression() + ApplyFunction()
```

`ParseRangeAggregateFunction(name)`:
- Expects `(`, then parses the range argument as either a range (`A1>B5`) or a single
  cell/expression, then `)`.
- Calls the appropriate aggregate on the collected values.

`ParseIfExpression()`:
- Expects `(` already consumed by caller.
- Parses: left_expr, relational_op (mandatory), right_expr, `,`, true_expr, `,`, false_expr, `)`.
- If no relational op found after left_expr AND left_expr already consumed a `>` range operator
  internally (i.e., next char is `,`): use left_expr result as condition (non-zero = true) — this
  handles the `IF(A1>B5, 1, 0)` range-sum-as-condition case per spec §Clarifications.
- If no relational op and no internal range: error "IF: Bedingung muss einen
  Vergleichsoperator enthalten."

`ParseRoundExpression()`:
- Expects `(` already consumed by caller.
- Parses: value_expr, `,`, decimals_expr, `)`.
- Applies `Math.Round(value, (int)Math.Truncate(decimals), MidpointRounding.AwayFromZero)`.

**Rationale**: This dispatch keeps the existing `ApplyFunction` switch for 1-arg functions
unchanged, avoiding regression risk. Multi-arg functions are cleanly separated.

---

## Decision 5: Aggregate Function Behavior

| Function | Empty range | Single cell ref | Formula error cells |
|----------|-------------|-----------------|---------------------|
| MIN | Returns 0 | Returns cell value | Excluded (ResolveCellValue returns stored Value = 0) |
| MAX | Returns 0 | Returns cell value | Excluded |
| AVERAGE | Returns 0 | Returns cell value | Excluded |
| COUNT | Returns 0 | Returns 1 if numeric, 0 if empty/text | Excluded (not Constant/Calculated) |

**Rationale**: Consistent with spec §Edge Cases. Returning 0 for empty ranges avoids a
separate null/error result type and is consistent with AVERAGE's existing documented behavior.

---

## Decision 6: Comma Parsing

**Decision**: Reuse the existing `Match(',')` / `Expect(',')` pattern (already in the parser
as `Expect(char)`). No new tokenizer infrastructure is needed. Commas are only valid as
argument separators inside IF and ROUND; the existing expression grammar does not use commas,
so there is no ambiguity.

---

## Decision 7: ROUND with Non-Integer Decimals

**Decision**: Truncate the `decimals` argument to integer using `(int)Math.Truncate(decimals)`
before passing to `Math.Round`. This is consistent with Excel/LibreOffice behavior and requires
no additional validation branch.

---

## Decision 8: Test-First Implementation Order

Per Constitution Principle III, the implementation order within each priority group is:
1. Write golden test (xUnit `[Theory]` or `[Fact]`) — verify it compiles but FAILS
2. Implement the function in FormulaEvaluator.cs
3. Run tests — verify GREEN
4. Run full suite — verify no regressions

Implementation priority order per spec:
- P1: MIN, MAX, AVERAGE (depend on CollectRangeValues + IsRangeOperatorStart refactors)
- P2: COUNT (same infrastructure as P1)
- P3a: ROUND (simple 2-arg, no range needed)
- P3b: IF (most complex; condition parser, relational ops)
- Help doc update: after all functions pass tests

---

## Resolved NEEDS CLARIFICATION Items

None — all Technical Context fields were resolvable from the existing codebase without
external research.
