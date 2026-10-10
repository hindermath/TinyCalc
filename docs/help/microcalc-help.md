# MicroCalc Help (Migrated)

## Aktueller Portvertrag / Current port contract

Deutsch: Feature 006 ist lokal implementiert; Plattform- und Produktabnahme
sind noch offen. Die historischen englischen Seiten unten bleiben als
Lernreferenz erhalten. Für den aktuellen Port gelten diese Präzisierungen:

- Raster A1:G21; Randbewegungen laufen im Raster um. Rechts zusätzlich Ctrl-M,
  Enter und Ctrl-G; unten zusätzlich Ctrl-J. Die übrigen Pfeil-/Ctrl-Aliase
  stehen in Page 4 und im [Bedienvertrag](../../README.md#bedien--und-formelvertrag--interaction-and-formula-contract).
- Esc öffnet vorhandenen Inhalt; druckbares ASCII startet neuen Inhalt.
  Raster-`/` öffnet die Palette, Editor-`/` bleibt Text oder Division.
- Editor: Ctrl-S/D links/rechts, Ctrl-A/F Anfang/Ende, DEL/Ctrl-G links/rechts
  löschen, Ctrl-V/Ins Einfügen/Überschreiben. Enter übernimmt OK; Esc/Cancel
  verwirft ohne Daten-/Dateiänderung. Höchstens 70 Zeichen je Zelle.
- Palette: Q/L/S/R/P/F/A für Quit/Load/Save/Recalculate/Print/Format/AutoCalc.
  Die Laufzeithilfe wird aus CALC.HLP beziehungsweise Resources/CALC.HLP geladen.
- Potenzen binden rechts und stärker als Vorzeichen: 2^3^2=512, -2^2=-4,
  (-2)^2=4, 2^-2=0.25. FACT nur für ganze Zahlen 0..33, mit FACT(0)=1.
- SIN/COS und ARCTAN nutzen Bogenmaß; LN Basis e, LOG Basis 10, beide nur für
  positive Argumente. Definitionsfehler und nichtendliche Ergebnisse sind Fehler.
- Leere numerische Mengen ergeben bei MIN/MAX/AVERAGE 0; COUNT zählt Zahlen.
  Bereichssumme und IF-Zellvergleich bleiben wie auf Page 8 beschrieben getrennt.
- ROUND: Halbwerte weg von null; nichtnegative Präzision abschneiden, dann 0..15.
  15.9 ist zulässig; 16, -0.5 und -1 scheitern verständlich, ohne Clamp.
- Ungültiges Load verändert weder vorhandene Zellen noch Auswahl/AutoCalc.
  Print exportiert Text; Abbruch des Randprompts schreibt keine Datei.

English: Feature 006 is implemented locally; platform and product acceptance
remain open. Historical English pages below remain learning references, with
these binding clarifications for the current port:

- Grid A1:G21; edges wrap inside it. Right additionally accepts Ctrl-M, Enter
  and Ctrl-G; down also accepts Ctrl-J. Other arrow/Ctrl aliases appear in Page 4
  and the linked interaction contract.
- Esc opens existing contents; printable ASCII starts new contents. Grid `/`
  opens the palette; editor `/` remains text or division. Editor Ctrl-S/D move
  left/right, Ctrl-A/F to start/end; DEL/Ctrl-G delete left/right; Ctrl-V/Ins
  toggle insert/overwrite. Enter accepts OK, Esc/Cancel discards without changing
  data or files. Cell contents have a seventy-character limit.
- Palette Q/L/S/R/P/F/A select Quit/Load/Save/Recalculate/Print/Format/AutoCalc.
  Runtime help loads CALC.HLP or Resources/CALC.HLP.
- Powers associate right before signs, using the four examples above. FACT
  accepts only integers 0–33, with FACT(0)=1. SIN/COS and ARCTAN use radians;
  LN is base e, LOG base ten, both for positive arguments. Domain/non-finite
  results are errors. MIN/MAX/AVERAGE of no numeric cells return zero; COUNT
  counts numbers. Page 8 distinguishes range sums from IF cell comparison.
- ROUND uses midpoint-away-from-zero and truncates nonnegative precision to
  0–15. 15.9 is valid; 16, -0.5 and -1 fail clearly without clamping.
- Invalid Load preserves cells, selection and AutoCalc. Print exports text;
  cancelling its margin prompt writes no file.

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
- `COUNT(A1>A1)` → 1 (single numeric cell)
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
Negative raw `decimals` produces an error, including -0.5. After truncation,
precision must be 0..15; 15.9 becomes 15, while 16 is an error without clamping.

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
- Typing printable ASCII starts editing with that character; grid `/` opens the palette instead.
- `Enter` confirms in dialogs.
- Cancel leaves previous value unchanged.
