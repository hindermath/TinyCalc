# MicroCalc Help (Migrated)

## Page 1 - Introduction

MicroCalc is a small spreadsheet example application. It demonstrates how text, numbers, and formulas are entered and calculated in a compact grid.

Key limitations in the historical sample:
- no copy formulas command,
- no insert/delete rows or columns.

## Page 2 - Core Features

The application provides:
- load sheet,
- save sheet,
- auto recalculation (toggle),
- print/export to text file,
- clear worksheet.

## Page 3 - Grid Concept

Cells range from `A1` to `G21`.

Example formula:
- `(A1+A2+A3+A4)`
- abbreviated range sum: `(A1>A4)`.

## Page 4 - Navigation

Classic movement keys:
- Up: `Ctrl-E` or arrow up,
- Down: `Ctrl-X` or arrow down,
- Left: `Ctrl-S` or arrow left,
- Right: `Ctrl-D` or arrow right.

Cell state is shown in the status line (`Text`, `Numeric`, `Formula`).

## Page 5 - Formula Language

Supported operators:
- `+`, `-`, `*`, `/`, `^`.

Supported functions:
- `ABS`, `SQRT`, `SQR`, `SIN`, `COS`, `ARCTAN`, `LN`, `LOG`, `EXP`, `FACT`.
- `MIN`, `MAX`, `AVERAGE`, `COUNT`, `IF`, `ROUND` (Phase 2 — Extended Formula Library).

Range sum operator:
- `A1>B5`.

## Page 8 - Extended Functions (Phase 2)

### MIN(range)

Returns the smallest value in a rectangular range, ignoring empty and text cells.
If the range is empty, returns `0`.

Syntax: `MIN(from>to)` or `MIN(cell)`

Examples:
- `MIN(A1>A5)` → 10 (when A1=10, A2=20, A3=30, A4=40, A5=50)
- `MIN(A1>B2)` → 1 (when A1=1, A2=2, B1=3, B2=4)
- `MIN(A1)`   → 42 (when A1=42)

---

### MAX(range)

Returns the largest value in a rectangular range, ignoring empty and text cells.
If the range is empty, returns `0`.

Syntax: `MAX(from>to)` or `MAX(cell)`

Examples:
- `MAX(A1>A5)` → 50 (when A1=10, A2=20, A3=30, A4=40, A5=50)
- `MAX(A1>B2)` → 4 (when A1=1, A2=2, B1=3, B2=4)

---

### AVERAGE(range)

Returns the arithmetic mean of numeric cells in a range. Empty and text cells are
excluded from both the sum and the count. If no numeric cells exist, returns `0`.

Syntax: `AVERAGE(from>to)` or `AVERAGE(cell)`

Examples:
- `AVERAGE(A1>A5)` → 30 (when A1=10, A2=20, A3=30, A4=40, A5=50)
- `AVERAGE(A1>A3)` → 15 (when A1=10, A2 empty, A3=20 — empty cell excluded)

---

### COUNT(range)

Returns the number of numeric cells (Constant or Calculated) in a range.
Empty cells and text cells are not counted.

Syntax: `COUNT(from>to)` or `COUNT(cell)`

Examples:
- `COUNT(A1>A5)` → 3 (when A1=5, A2 empty, A3=10, A4 empty, A5=15)
- `COUNT(A1>`A1)` → 1 (single numeric cell)
- `COUNT(A1>A3)` → 0 (when A1, A2, A3 all contain text)

---

### IF(condition, true_value, false_value)

Evaluates a relational condition and returns `true_value` if it is met, otherwise
`false_value`. The condition **must** contain one of the six relational operators:
`=`, `<>`, `<`, `<=`, `>=`, `>`.

**Important**: When `>` appears between two bare cell references (e.g., `A1>B5`),
it retains range-sum semantics (see Page 3). To compare two cell values, use
subtraction: `IF(A1-B1>0, 1, 0)`.

Syntax: `IF(left relop right, true_value, false_value)`

Examples:
- `IF(A1>100, 1, 0)`    → 1 when A1=150, 0 when A1=50
- `IF(A1=A2, 10, 20)`   → 10 when A1 equals A2, 20 otherwise
- `IF(A1<>0, A1, 0)`    → A1 when A1 is non-zero, 0 otherwise
- `IF(A1-B1>0, 1, 0)`   → 1 when A1 > B1 (numeric comparison via subtraction)
- `IF(A1>0, MAX(A1>A3), MIN(A1>A3))` → MAX or MIN of range based on A1

Supported relational operators: `=`, `<>`, `<`, `<=`, `>=`, `>`

---

### ROUND(value, decimals)

Rounds `value` to the specified number of decimal places using midpoint-away-from-zero
rounding. A non-integer `decimals` argument is truncated toward zero.
Negative `decimals` produces an error.

Syntax: `ROUND(value, decimals)`

Examples:
- `ROUND(3.14159, 2)` → 3.14
- `ROUND(2.5, 0)`     → 3 (away from zero)
- `ROUND(-2.5, 0)`    → -3 (away from zero)
- `ROUND(3.14, 1.7)`  → 3.1 (decimals 1.7 truncated to 1)
- `ROUND(AVERAGE(A1>A5), 2)` → rounds the average to 2 decimal places

## Page 6 - Commands

`/` opens the command palette.

Commands:
- `Load`,
- `Save`,
- `Recalculate`,
- `Print`,
- `Format`,
- `AutoCalc`,
- `Help`,
- `Clear`,
- `Quit`.

## Page 7 - Editing

- `Esc` edits current cell.
- Typing any printable character starts editing with that character.
- `Enter` confirms in dialogs.
- Cancel leaves previous value unchanged.
