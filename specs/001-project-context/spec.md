# Feature Specification: Phase 2 – Extended Formula Library

**Feature Branch**: `001-project-context`
**Created**: 2026-02-28
**Status**: Draft
**Input**: User description: "understand the project and push development forward with Agentic-AI"

---

## Background & Project Context

MicroCalc Phase 1 is complete. The C#/.NET 10 port faithfully replicates the original Borland
Pascal MicroCalc spreadsheet (CALC.PAS / CALC.INC) with:

- 7 × 21 cell grid (A–G, rows 1–21, 147 cells)
- Full formula engine: arithmetic operators, cell references, rectangular range sums (`A1>B5`),
  10 mathematical functions (ABS, SQRT, SQR, SIN, COS, ARCTAN, LN, LOG, EXP, FACT)
- JSON persistence, ASCII print export, paginated help viewer
- Terminal.Gui TUI with menus, keyboard navigation, AutoCalc, Format, Clear
- xUnit test suite: golden formula tests, engine integration tests, TUI smoke tests
- GitHub Actions CI (Release configuration)

**Phase 2 goal**: Extend MicroCalc beyond the Pascal original by adding standard spreadsheet
formula functions that users expect in any calculator-class tool. These additions demonstrate
the Agentic-AI driven feature development workflow this project showcases.

---

## User Scenarios & Testing *(mandatory)*

### User Story 1 – Range Analysis Functions (Priority: P1)

A user enters a set of numeric values across a column (e.g., monthly expenses in A1 through A12)
and wants to instantly see the minimum, maximum, and average. They type `MIN(A1>A12)`,
`MAX(A1>A12)`, and `AVERAGE(A1>A12)` into formula cells and get correct results immediately,
just like in any modern spreadsheet.

**Why this priority**: Aggregate analysis is the most common reason people use a spreadsheet.
Without MIN, MAX, and AVERAGE, MicroCalc cannot serve even basic data-analysis workflows.

**Independent Test**: Enter 5 numeric values in A1–A5, then enter `MIN(A1>A5)` in B1,
`MAX(A1>A5)` in B2, `AVERAGE(A1>A5)` in B3. Verify each cell shows the correct result.
This is fully testable without IF or ROUND being implemented.

**Acceptance Scenarios**:

1. **Given** A1=10, A2=20, A3=30, A4=40, A5=50,
   **When** the user enters `MIN(A1>A5)` in B1,
   **Then** B1 displays 10.

2. **Given** the same values,
   **When** the user enters `MAX(A1>A5)` in B2,
   **Then** B2 displays 50.

3. **Given** the same values,
   **When** the user enters `AVERAGE(A1>A5)` in B3,
   **Then** B3 displays 30.

4. **Given** a rectangular range A1=1, A2=2, B1=3, B2=4,
   **When** the user enters `AVERAGE(A1>B2)`,
   **Then** the result is 2.5.

5. **Given** a range where some cells are empty or contain text,
   **When** MIN, MAX, or AVERAGE is evaluated,
   **Then** only numeric cells contribute; empty and text cells are ignored.

---

### User Story 2 – Count Numeric Cells (Priority: P2)

A user has a range where some cells hold numbers and others are empty or contain text labels.
They want to know exactly how many numeric values exist in the range. They type
`COUNT(A1>A21)` and get the correct count of numeric-valued cells.

**Why this priority**: COUNT completes the basic statistical toolkit (MIN/MAX/AVERAGE/COUNT)
and is needed to validate data entry and calculate weighted results. It builds directly on the
range infrastructure from Story 1.

**Independent Test**: Enter numbers in A1, A3, A5 and leave A2, A4 empty. Enter
`COUNT(A1>A5)` in B1. Verify B1 = 3. Testable independently of IF and ROUND.

**Acceptance Scenarios**:

1. **Given** A1=5, A2 empty, A3=10, A4 empty, A5=15,
   **When** the user enters `COUNT(A1>A5)`,
   **Then** the result is 3.

2. **Given** A1=1, A2="Label", A3=2,
   **When** the user enters `COUNT(A1>A3)`,
   **Then** the result is 2 (text cell excluded).

3. **Given** all cells in a range are empty,
   **When** COUNT is evaluated,
   **Then** the result is 0.

---

### User Story 3 – Conditional Formulas with IF (Priority: P3)

A user wants to flag values that exceed a threshold. They type `IF(A1>100, 1, 0)` into a cell
and receive 1 when A1 exceeds 100, or 0 otherwise. After changing A1, the IF result updates
automatically when AutoCalc is on.

**Why this priority**: IF is the foundation of conditional logic in any spreadsheet. It is more
complex than the aggregate functions (requires relational operator parsing inside the condition
expression), so it is P3 — valuable but not blocking P1 or P2.

**Independent Test**: Enter A1=150, then enter `IF(A1>100, 1, 0)` in B1. Verify B1=1.
Change A1 to 50 and trigger recalculate. Verify B1=0.

**Acceptance Scenarios**:

1. **Given** A1=150,
   **When** the user enters `IF(A1>100, 1, 0)` in B1,
   **Then** B1 = 1.

2. **Given** A1=50,
   **When** the same formula is recalculated,
   **Then** B1 = 0.

3. **Given** `IF(A1=A2, MAX(A1>A3), MIN(A1>A3))`,
   **When** evaluated,
   **Then** the true/false branches are themselves formula sub-expressions that evaluate
   correctly.

4. **Given** an IF formula with a syntactically invalid condition,
   **When** evaluated,
   **Then** a descriptive error message is shown and the cell is not updated to a value.

---

### User Story 4 – Rounding (Priority: P3)

A user calculates an AVERAGE and wants the formula result stored at exactly 2 decimal places
(independent of the cell display format). They enter `ROUND(AVERAGE(A1>A5), 2)` and get a
value rounded to 2 decimal places that other formula cells can reference.

**Why this priority**: ROUND follows the same single-argument pattern as existing functions,
making it easy to implement alongside P1. Treated as P3 because it is less critical than
MIN/MAX/AVERAGE/COUNT — it is in scope for this feature branch but implemented last.

**Independent Test**: Enter `ROUND(3.14159, 2)` in A1. Verify A1 = 3.14. Fully testable alone.

**Acceptance Scenarios**:

1. **Given** `ROUND(3.14159, 2)`,
   **When** evaluated,
   **Then** the result is 3.14.

2. **Given** `ROUND(2.5, 0)`,
   **When** evaluated,
   **Then** the result is 3 (away-from-zero rounding).

3a. **Given** `ROUND(-2.5, 0)`,
    **When** evaluated,
    **Then** the result is -3 (away from zero, not -2).

3. **Given** `ROUND(AVERAGE(A1>A5), 2)` with A1–A5 = 1, 2, 3, 4, 5,
   **When** evaluated,
   **Then** the result is 3.00.

---

### Edge Cases

- What happens when MIN or MAX is applied to a range where all cells are empty or text?
  → Returns 0 (consistent with AVERAGE on an empty range returning 0).
- How does IF handle non-numeric condition operands?
  → Returns a descriptive error: "IF: Bedingung konnte nicht ausgewertet werden."
- What happens when ROUND receives a negative decimal count?
  → Returns a descriptive error; negative precision is not supported in this version.
- What happens when ROUND's `decimals` argument is non-integer, e.g., `ROUND(3.14, 1.5)`?
  → Truncated silently to its integer part: `ROUND(3.14, 1.5)` evaluates as `ROUND(3.14, 1)` = 3.1.
- What happens when COUNT is applied to a single cell reference instead of a range?
  → Returns 1 if the cell is numeric, 0 if empty or text.
- What happens when MIN/MAX/AVERAGE is applied to a single cell reference?
  → Evaluates the single cell value directly (range of one).
- What does `IF(A1>B2, 1, 0)` mean when both operands are cell addresses?
  → `A1>B2` is treated as a range-sum (existing semantics); if the sum is non-zero the true branch
  is returned, otherwise the false branch. To compare A1 and B2 numerically, write
  `IF(A1-B2>0, 1, 0)` (subtracting B2 from A1 makes the right side a non-cell expression).
- What happens when IF is called with fewer than 3 arguments, e.g., `IF(A1>0, 1)`?
  → Error: "IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert." All 3 arguments are
  mandatory; there is no default for the false branch.
- What happens when an IF branch evaluates to a text value?
  → Error: "IF: Wahr- und Falsch-Wert müssen numerische Ausdrücke sein." Text results are not
  supported in IF branches.
- What happens when an IF condition contains no relational operator, e.g., `IF(A1, 1, 0)`?
  → Syntax error: "IF: Bedingung muss einen Vergleichsoperator enthalten (=, <>, <, <=, >=, >)."
  A relational operator is mandatory.

---

## Requirements *(mandatory)*

### Functional Requirements

- **FR-001**: The formula engine MUST support `MIN(range)` returning the smallest numeric value
  in the range, ignoring empty and text cells.
- **FR-002**: The formula engine MUST support `MAX(range)` returning the largest numeric value
  in the range, ignoring empty and text cells.
- **FR-003**: The formula engine MUST support `AVERAGE(range)` returning the arithmetic mean
  of all numeric cells in the range; returns 0 when no numeric cells are found.
- **FR-004**: The formula engine MUST support `COUNT(range)` returning the number of cells
  in the range that contain a numeric constant or a successfully calculated formula value.
- **FR-005**: The formula engine MUST support `IF(condition, true_value, false_value)` where
  condition is exactly one relational expression of the form `left_expr OP right_expr`, with OP
  being one of `=`, `<>`, `<`, `<=`, `>=`, or context-sensitive `>` (when right operand is
  non-cell: greater-than comparison; when both operands are cell addresses: range-sum, existing
  behavior). A bare expression with no relational operator is a syntax error. true_value and
  false_value are full numeric formula sub-expressions; text values in either branch MUST produce
  a descriptive error.
- **FR-006**: The formula engine MUST support `ROUND(value, decimals)` rounding `value` to
  `decimals` decimal places using away-from-zero rounding (`MidpointRounding.AwayFromZero`):
  midpoint values round away from zero, so `ROUND(2.5, 0)` = 3 and `ROUND(-2.5, 0)` = -3.
  Non-integer `decimals` values are truncated to their integer part before rounding (no error).
- **FR-007**: `IF` called with fewer than 3 arguments MUST return a descriptive error:
  "IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."
- **FR-008**: `IF` branches that evaluate to a text value MUST return a descriptive error:
  "IF: Wahr- und Falsch-Wert müssen numerische Ausdrücke sein."
- **FR-009**: All new functions MUST be case-insensitive (consistent with existing functions).
- **FR-010**: All new functions MUST participate in cyclic-reference detection.
- **FR-011**: Error messages for new functions MUST be in German with a position indicator,
  consistent with the existing evaluator error style.
- **FR-012**: Each new function MUST have at least one golden xUnit test (happy path) and one
  error/edge-case test before the implementing code is merged.
- **FR-013**: All existing formula golden tests MUST continue to pass after the additions.

### Key Entities

- **Formula Evaluator**: the core extension point; the Parser's factor-dispatch method is where
  all new function names are registered and evaluated.
- **Range Values**: the set of numeric cell values returned by an `A1>B5` range expression;
  new aggregate functions consume this same structure.
- **Condition Expression**: a new sub-expression type introduced by IF that evaluates a
  relational comparison and returns a boolean decision (true/false branch selection).

---

## Success Criteria *(mandatory)*

### Measurable Outcomes

- **SC-001**: Users can type `MIN(A1>G21)`, `MAX(A1>G21)`, and `AVERAGE(A1>G21)` into any
  cell and receive correct results for all numeric cells in the range.
- **SC-002**: Users can type `COUNT(A1>G21)` and receive the exact count of cells that hold
  a numeric or successfully calculated formula value.
- **SC-003**: Users can type `IF(A1>0, A1, 0)` and the formula updates correctly on every
  recalculate (automatic or manual) when the referenced cell changes.
- **SC-004**: Users can type `ROUND(value_or_formula, n)` and the stored cell value is rounded
  to n decimal places for subsequent formula references.
- **SC-005**: All 6 new functions are documented with a usage example in the help content
  (`docs/help/microcalc-help.md`).
- **SC-006**: The full xUnit test suite (Core.Tests + Tui.Tests) passes under
  `--configuration Release` with no regressions introduced.
- **SC-007**: At least one golden test exists per function covering the happy path and at least
  one error or boundary case.

---

## Assumptions

- New functions use the existing range syntax `A1>B5`; no new syntax is introduced.
- IF comparison operators work on numeric values only; string comparison is out of scope.
- ROUND uses `Math.Round` with `MidpointRounding.AwayFromZero` (midpoint rounds away from zero; this is the canonical rounding mode for this feature — see FR-006).
- Error messages remain in German, matching the existing evaluator style.
- No TUI changes are required beyond updating the help document.

---

## Clarifications

### Session 2026-02-28

- Q: How is the `>` operator disambiguated inside an IF condition given that `>` is already the range-sum operator? → A: Context-sensitive (`>`): when both operands are cell addresses, `>` is the range operator (existing behavior); when the right-hand operand is a numeric expression or literal (not a cell address), `>` is a greater-than comparison. Users who need to compare two cell values numerically write `IF(A1-B2>0, ...)` as a workaround.
- Q: Should IF and ROUND (P3) be in scope for this feature or deferred to a separate branch? → A: All 6 functions (MIN, MAX, AVERAGE, COUNT, IF, ROUND) are in scope. P3 items are implemented last but not deferred.
- Q: Can IF branches return text values, or are they restricted to numeric results? → A: Numeric only — both true and false branches MUST evaluate to numeric values; text branches are out of scope.
- Q: What happens when IF is called with fewer than 3 arguments? → A: Error — all 3 arguments (condition, true_value, false_value) are mandatory; fewer than 3 produces "IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."
- Q: Is a relational operator required in the IF condition, or is a bare expression valid (non-zero = true)? → A: Relational operator required — the condition MUST contain exactly one relational operator (`=`, `<>`, `<`, `<=`, `>=`, or context-sensitive `>`). `IF(A1, 1, 0)` is a syntax error; users must write `IF(A1<>0, 1, 0)`.
- Q: For `ROUND(-2.5, 0)`, is the result -3 (AwayFromZero) or -2 (half-up toward +∞)? → A: -3 — `MidpointRounding.AwayFromZero` is the canonical rounding mode; "half-up" in FR-006 means away from zero, not toward positive infinity.
- Q: When ROUND's `decimals` argument is a non-integer (e.g., `ROUND(3.14, 1.5)`), should the engine truncate or error? → A: Truncate silently — `decimals` is truncated to its integer part before rounding; `ROUND(3.14, 1.5)` evaluates as `ROUND(3.14, 1)` = 3.1.
