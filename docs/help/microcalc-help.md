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

Range sum operator:
- `A1>B5`.

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
