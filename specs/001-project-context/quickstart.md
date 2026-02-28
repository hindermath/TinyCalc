# Quickstart: Phase 2 – Extended Formula Library

**Branch**: `001-project-context` | **Date**: 2026-02-28

A hands-on guide to the 6 new functions added in Phase 2. All examples use MicroCalc's 7×21 grid
(columns A–G, rows 1–21).

---

## MIN — Smallest value in a range

Returns the smallest numeric value in a rectangular range. Empty and text cells are ignored.

```
MIN(A1>A5)
```

**Step-by-step**:
1. Enter values: A1=10, A2=20, A3=30, A4=40, A5=50
2. Navigate to B1 and type: `MIN(A1>A5)`
3. Press Enter → B1 displays `10`

**Single cell**:
```
MIN(A1)         → value of A1 (range of one)
```

**Rectangular range**:
```
MIN(A1>B3)      → smallest of 6 cells: A1, A2, A3, B1, B2, B3
```

**Edge case**: If all cells in the range are empty or text, MIN returns `0`.

---

## MAX — Largest value in a range

Returns the largest numeric value in a rectangular range. Same rules as MIN.

```
MAX(A1>A5)
```

**Step-by-step**:
1. With A1=10, A2=20, A3=30, A4=40, A5=50 in place:
2. Enter `MAX(A1>A5)` in B2
3. B2 displays `50`

**Full-grid maximum**:
```
MAX(A1>G21)     → largest value across all 147 cells
```

---

## AVERAGE — Arithmetic mean of a range

Returns the sum of numeric cells divided by their count. Returns `0` when no numeric cells exist.

```
AVERAGE(A1>A5)
```

**Step-by-step**:
1. With A1=10, A2=20, A3=30, A4=40, A5=50:
2. Enter `AVERAGE(A1>A5)` in B3
3. B3 displays `30`

**Rectangular range** (A1=1, A2=2, B1=3, B2=4):
```
AVERAGE(A1>B2)  → (1+2+3+4) / 4 = 2.5
```

**With gaps** (A1=10, A2 empty, A3=20):
```
AVERAGE(A1>A3)  → (10+20) / 2 = 15     (empty cell excluded)
```

---

## COUNT — Number of numeric cells in a range

Returns the count of cells that hold a numeric constant or a successfully calculated formula value.
Text cells and empty cells are not counted.

```
COUNT(A1>A5)
```

**Step-by-step**:
1. Enter: A1=5, A2 empty, A3=10, A4 empty, A5=15
2. Enter `COUNT(A1>A5)` in B1
3. B1 displays `3`

**Full column count**:
```
COUNT(A1>A21)   → counts numeric cells in column A
```

**All empty**:
```
COUNT(A1>A5)    → 0     (if all five cells are empty)
```

---

## ROUND — Round a value to N decimal places

Rounds `value` to `decimals` decimal places using away-from-zero rounding (midpoint rounds away
from zero, so 2.5 → 3 and -2.5 → -3).

```
ROUND(value, decimals)
```

**Basic usage**:
```
ROUND(3.14159, 2)           → 3.14
ROUND(2.5, 0)               → 3       (away from zero)
ROUND(-2.5, 0)              → -3      (away from zero, not -2)
```

**Compose with AVERAGE**:
```
ROUND(AVERAGE(A1>A5), 2)
```

1. With A1–A5 = 1, 2, 3, 4, 5:
2. `AVERAGE(A1>A5)` = 3.0 exactly → `ROUND(3.0, 2)` = 3.00

**Non-integer decimals are silently truncated**:
```
ROUND(3.14, 1.7)            → ROUND(3.14, 1) = 3.1
```

**Error — negative decimals**:
```
ROUND(3.14, -1)             → Error: "ROUND: Negative Nachkommastellen sind nicht erlaubt."
```

---

## IF — Conditional formula

Evaluates a relational condition and returns one of two expressions.

```
IF(condition, true_value, false_value)
```

A relational operator (`=`, `<>`, `<`, `<=`, `>=`, `>`) is **mandatory** in the condition.

**Greater-than comparison** (right side is a literal):
```
IF(A1>100, 1, 0)
```
1. Enter A1=150, then `IF(A1>100, 1, 0)` in B1 → B1=1
2. Change A1 to 50, recalculate → B1=0

**Other relational operators**:
```
IF(A1=A2, 10, 20)           → 10 if A1 equals A2, else 20
IF(A1<>0, A1, 0)            → A1 if non-zero, else 0
IF(A1<=10, 1, 0)            → 1 if A1 ≤ 10
IF(A1>=A2, A1, A2)          → larger of A1 and A2
```

**Compare cell difference against zero** (instead of cell-to-cell `>` which is range-sum):
```
IF(A1-B1>0, 1, 0)           → 1 if A1 > B1 numerically
```

**Branches are full expressions**:
```
IF(A1>0, MAX(A1>A5), MIN(A1>A5))   → MAX or MIN of range depending on A1
IF(A1=A2, ROUND(AVERAGE(A1>A5), 2), 0)
```

**`>` with two cell references** (range-sum semantics, per existing behavior):
```
IF(A1>B5, 1, 0)             → 1 if SUM(A1:B5) ≠ 0, else 0
                               (workaround: IF(A1-B5>0, 1, 0) for numeric comparison)
```

**Error — missing relational operator**:
```
IF(A1, 1, 0)                → Error: "IF: Bedingung muss einen Vergleichsoperator enthalten…"
                               Use: IF(A1<>0, 1, 0)
```

**Error — missing false branch**:
```
IF(A1>0, 1)                 → Error: "IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."
```

---

## Function Composition Reference

| Formula | Description |
|---------|-------------|
| `ROUND(MIN(A1>A5), 2)` | Rounded minimum |
| `ROUND(MAX(A1>A5), 0)` | Integer maximum |
| `ROUND(AVERAGE(A1>G21), 2)` | Full-grid average rounded to 2dp |
| `IF(AVERAGE(A1>A5)>10, 1, 0)` | Flag if average exceeds threshold |
| `IF(COUNT(A1>A5)=5, AVERAGE(A1>A5), 0)` | Average only when all 5 cells are filled |
| `MIN(A1>A5)+MAX(A1>A5)` | Sum of extremes in arithmetic |
| `COUNT(A1>A21)+COUNT(B1>B21)` | Total numeric cells in two columns |

---

## Running Tests

After implementing each function, verify with:

```bash
# Full test suite (Release, CI-aligned)
dotnet test MicroCalc.sln --configuration Release

# Formula golden tests only
dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj \
  --configuration Release \
  --filter "FullyQualifiedName~FormulaGoldenTests"
```

All new golden tests must be RED before implementation and GREEN after.
