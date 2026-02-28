# Data Model: Phase 2 – Extended Formula Library

**Branch**: `001-project-context` | **Date**: 2026-02-28
**Input**: [spec.md](spec.md), [research.md](research.md), `FormulaEvaluator.cs` (458 lines)

---

## Overview

This feature does not introduce new persistent entities. All new data lives inside the
recursive-descent `Parser` (private nested class inside `FormulaEvaluator`). The model below
documents the logical concepts, method signatures, data flows, and invariants introduced by
the extension.

---

## Existing Entities (unchanged)

### `EvaluationResult`

```
EvaluationResult
├── Value     : double          (result on success)
├── IsFormula : bool            (true when expression contains cell refs or functions)
├── Error     : string?         (non-null on failure)
└── Position  : int             (1-based char position of error)
```

All new functions return `double` values via `EvaluationResult.Ok(value, isFormula: true)`.
No new result types are introduced.

### `CellAddress`

```
CellAddress
├── Column : char   (A–G, invariant: SpreadsheetSpec.IsColumnInRange)
└── Row    : int    (1–21, invariant: SpreadsheetSpec.IsRowInRange)
```

Used as input to `CollectRangeValues` and `ResolveCellValue` (unchanged).

### `CellStatusFlags` (relevant subset)

```
CellStatusFlags (Flags enum)
├── Constant   — cell holds a numeric literal or a constant formula
├── Calculated — cell holds a formula whose result is stored in Value
├── Text       — cell holds a string (excluded from numeric aggregates)
└── Formula    — cell contains a formula expression (may or may not be Calculated yet)
```

**Rule**: `CollectRangeValues` includes a cell iff it has `Constant` OR `Calculated` flag set.
Cells with only `Text` (and not `Constant`) are excluded. Empty cells (no flags) are excluded.

---

## New Logical Concepts

### `CollectRangeValues` — Range Value Collection

**Purpose**: Traverses a rectangular range and returns the numeric values of all eligible cells.
**Replaces**: The traversal loop in `SumRange` (which only accumulated a sum).

```
CollectRangeValues(from: CellAddress, to: CellAddress) → IReadOnlyList<double>
```

**Invariants**:
- Normalizes column/row order: `startCol = Min(from.Col, to.Col)`, etc.
- Calls `ResolveCellValue(addr)` for each eligible cell (cyclic reference detection applies).
- Cells with `Constant` or `Calculated` status contribute their resolved `double` value.
- Empty cells and text-only cells contribute nothing (excluded from the list).
- Returns an empty list when no eligible cells exist.

**Dependents**:

| Consumer        | Operation on result          |
|-----------------|------------------------------|
| `SumRange`      | `.Sum()`                     |
| `ParseRangeAggregateFunction` (MIN)  | `.DefaultIfEmpty(0).Min()` |
| `ParseRangeAggregateFunction` (MAX)  | `.DefaultIfEmpty(0).Max()` |
| `ParseRangeAggregateFunction` (AVERAGE) | `Count==0 ? 0 : Sum/Count` |
| `ParseRangeAggregateFunction` (COUNT)   | `.Count` (of included cells) |

---

### `IsRangeOperatorStart` — Lookahead Guard

**Purpose**: Disambiguates `>` between range-sum and greater-than comparison inside IF.
**Position in parse flow**: Called from `ParseIdentifierBasedFactor` BEFORE consuming `>`.

```
IsRangeOperatorStart() → bool
  Precondition: Current() == '>'
  Checks: _text[_position + 1] is a valid column letter (A–G) AND
          _text[_position + 2] is a digit (0–9)
  Returns true  → `>` is the range operator; consume it and parse range
  Returns false → `>` is a comparison operator; leave it for the IF condition parser
```

**State transitions in `ParseIdentifierBasedFactor`** (updated):

```
ParseIdentifierBasedFactor()
  ├── Cell address path (IsColumnInRange(letter) && HasDigitAfterColumn())
  │     ├── ParseCellAddress() → from
  │     ├── IsFormula = true
  │     └── if Current() == '>' && IsRangeOperatorStart()
  │           ├── consume '>'
  │           ├── ParseCellAddress() → to
  │           └── return SumRange(from, to)           ← EXISTING path
  │         else
  │           return ResolveCellValue(from)            ← EXISTING path (unchanged)
  │
  └── Function name path
        ├── ParseName() → name (uppercased)
        ├── SkipWhitespace()
        ├── Expect('(')
        ├── Dispatch on name:
        │     ├── "MIN","MAX","AVERAGE","COUNT" → ParseRangeAggregateFunction(name)
        │     ├── "IF"                          → ParseIfExpression()
        │     ├── "ROUND"                       → ParseRoundExpression()
        │     └── (others)                      → ParseExpression() → Expect(')') → ApplyFunction()
        └── return result
```

---

### `ParseRangeAggregateFunction` — MIN / MAX / AVERAGE / COUNT

**Purpose**: Parses a single range argument and applies an aggregate operation.

```
ParseRangeAggregateFunction(name: string) → double
  Precondition: '(' already consumed by caller
  Grammar: range_arg ')'
  where range_arg ::= cell_address '>' cell_address   (rectangular range)
                    | expression                        (single value / cell ref)
```

**Data flow**:
1. Call `ParseExpression()` — this parses the first cell address (or any expression).
2. If the expression consumed a range (`A1>B5`), `CollectRangeValues` was invoked internally
   and the aggregate is computed on the returned list.
3. If it's a single cell/value, treat the list as `[value]`.
4. Apply aggregate per dispatch table above.
5. Consume `)`.

**Special case — COUNT with single cell**: The count is 1 if the cell is numeric (Constant or
Calculated), 0 if empty or text. This matches `CollectRangeValues` filter rules: a single numeric
cell produces a list of length 1; a single empty/text cell produces an empty list.

---

### `ParseIfExpression` — IF Conditional

**Purpose**: Parses the 3-argument IF form and evaluates the appropriate branch.

```
ParseIfExpression() → double
  Precondition: '(' already consumed by caller
  Grammar: left_expr relop right_expr ',' true_expr ',' false_expr ')'
  relop ::= '=' | '<>' | '<' | '<=' | '>=' | '>'
```

**Data flow**:
1. `left_expr ← ParseExpression()`
2. `relop ← ParseRelationalOperator()` — mandatory; error if none found
3. `right_expr ← ParseExpression()`
4. `Expect(',')`
5. `true_expr ← ParseExpression()`
6. `Expect(',')`
7. `false_expr ← ParseExpression()`
8. `Expect(')')`
9. Evaluate condition: `EvaluateCondition(left, relop, right)` → bool
10. Return `condition ? true_expr : false_expr`

**Relational operator disambiguation for `>`**:
- If `relop == '>'` and the right expression starts with a valid cell address, the existing
  `ParseIdentifierBasedFactor` path consumes `A1>B5` as a range-sum.
- `IsRangeOperatorStart()` ensures `>` is consumed as range only when followed by `ColLetter+Digit`.
- All other `>` occurrences at the relational operator position are treated as greater-than.

**Error states**:

| Condition | Error message |
|-----------|---------------|
| No relational operator found after left_expr | `"IF: Bedingung muss einen Vergleichsoperator enthalten (=, <>, <, <=, >=, >)."` |
| Fewer than 3 arguments (missing `,`) | `"IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."` |
| Branch evaluation produces non-numeric (internal error) | `"IF: Wahr- und Falsch-Wert müssen numerische Ausdrücke sein."` |
| Condition operand non-numeric | `"IF: Bedingung konnte nicht ausgewertet werden."` |

---

### `ParseRoundExpression` — ROUND

**Purpose**: Parses the 2-argument ROUND form and rounds to the specified decimal places.

```
ParseRoundExpression() → double
  Precondition: '(' already consumed by caller
  Grammar: value_expr ',' decimals_expr ')'
```

**Data flow**:
1. `value ← ParseExpression()`
2. `Expect(',')`
3. `decimals_raw ← ParseExpression()`
4. `decimals ← (int)Math.Truncate(decimals_raw)` — non-integer silently truncated
5. If `decimals < 0` → error `"ROUND: Negative Nachkommastellen sind nicht erlaubt."`
6. `Expect(')')`
7. Return `Math.Round(value, decimals, MidpointRounding.AwayFromZero)`

---

## Validation Rules

| Rule | Constraint |
|------|-----------|
| Range bounds | Both `from` and `to` must satisfy `IsColumnInRange` and `IsRowInRange`; enforced by `ParseCellAddress` (unchanged) |
| ROUND decimals ≥ 0 | Enforced in `ParseRoundExpression`; negative → error |
| IF relational operator | Mandatory; absence → error |
| IF argument count | Exactly 3; fewer → error on first missing `,` |
| SQRT argument ≥ 0 | Existing rule unchanged |
| LN/LOG argument > 0 | Existing rules unchanged |

---

## Invariants Preserved

1. **Cyclic reference detection** — All new paths that call `ResolveCellValue` inherit the
   existing `HashSet<CellAddress>` guard. No new stack is needed.
2. **`IsFormula` flag** — Set to `true` whenever a cell reference or function is encountered.
   New functions all set this via the existing `ParseIdentifierBasedFactor` call path.
3. **Error position** — `FormulaParseException` always carries `Math.Max(_position + 1, 1)` as
   the 1-based position indicator (existing `Error()` helper, unchanged).
4. **Backward compatibility** — `SumRange` behavior is unchanged; `CollectRangeValues().Sum()`
   produces identical results to the current traversal loop.
