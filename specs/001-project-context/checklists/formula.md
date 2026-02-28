# Formula Requirements Quality Checklist: Phase 2 – Extended Formula Library

**Purpose**: Validate that formula, parsing, and error/test requirements are unambiguous enough
for an AI agent to generate deterministic implementation tasks without requiring further
clarification. Each item is a "unit test" for the requirement text itself.
**Created**: 2026-02-28
**Feature**: [spec.md](../spec.md)
**Depth**: Standard | **Audience**: AI agent self-validation (pre-plan gate)
**Focus**: Formula semantics · Parsing & disambiguation · Error handling & test requirements

---

## Requirement Completeness

- [X] CHK001 — Does the spec define behavior when ROUND's `decimals` argument is a
  non-integer value (e.g., `ROUND(3.14, 1.5)`)? [Gap, Spec §Edge Cases]

- [X] CHK002 — Does the spec define behavior when MIN/MAX/AVERAGE/COUNT receive a numeric
  literal instead of a range or cell reference (e.g., `MIN(42)`)? [Gap]

- [X] CHK003 — Does the spec define whether IF's condition requires a relational operator, or
  whether any non-zero numeric expression is treated as true (e.g., `IF(A1, 1, 0)`)? [Gap,
  Spec §FR-005]

- [X] CHK004 — Does the spec define behavior for a range expression inside an IF branch, e.g.,
  `IF(A1>0, A1>B5, 0)` where the true-branch result is a range sum? [Gap, Spec §US3]

- [X] CHK005 — Does the spec define what happens when COUNT is applied to a range containing
  formula cells whose evaluation produced an error? [Gap, Spec §FR-004]

- [X] CHK006 — Does SC-005 specify the target location within `docs/help/microcalc-help.md`
  (section, page, or page-break position) where the 6 new functions must be documented?
  [Completeness, Spec §SC-005]

- [X] CHK007 — Does the spec define whether parentheses are permitted in the IF condition
  expression, e.g., `IF((A1+B1)>100, 1, 0)`? [Gap, Spec §FR-005]

- [X] CHK008 — Does the spec define behavior when the `decimals` argument of ROUND is itself
  a formula or cell reference (e.g., `ROUND(A1, B1)`) rather than a literal? [Gap, Spec §FR-006]

---

## Requirement Clarity

- [X] CHK009 — Is the context-sensitive `>` disambiguation rule in FR-005 precise enough for
  complex left-hand expressions? Is `IF(A1+B1>C1, 1, 0)` a comparison (left side is not a bare
  cell address) or a range (right side is a cell)? [Clarity, Spec §FR-005]

- [X] CHK010 — Is "cell address" precisely defined in FR-005 for the disambiguation rule — does
  it mean only a bare cell reference (`A1`) or any sub-expression that resolves to a cell value?
  [Clarity, Spec §FR-005]

- [X] CHK011 — Is "successfully calculated formula value" in FR-004 (COUNT) precisely defined:
  does it include formula cells whose result is exactly 0, or only non-zero results? [Clarity,
  Spec §FR-004]

- [X] CHK012 — Is "half-up rounding" in FR-006 unambiguous for negative numbers? Is
  `ROUND(-2.5, 0)` expected to return -3 (away from zero) or -2 (toward zero)? The Assumptions
  section references `MidpointRounding.AwayFromZero` but the spec body says "half-up" —
  are these terms confirmed to be synonymous? [Clarity, Spec §FR-006, §Assumptions]

- [X] CHK013 — Is "numeric cells" in FR-001/FR-002/FR-003/FR-004 precisely defined: does it
  include only `Constant` status cells, or also `Formula | Calculated` cells whose value is a
  valid number? [Clarity, Spec §FR-001 to FR-004]

- [X] CHK014 — Are the specific German error message strings in the Edge Cases section the
  canonical, required strings, or are they illustrative examples? An AI agent must know whether
  to reproduce them verbatim or paraphrase. [Clarity, Spec §Edge Cases]

- [X] CHK015 — Does FR-011 ("error messages in German with a position indicator") define the
  format of the position indicator — e.g., character offset, token index, or 1-based column?
  [Clarity, Spec §FR-011]

---

## Requirement Consistency

- [X] CHK016 — Is the edge-case decision that MIN/MAX on an all-empty range returns 0
  mathematically justified or noted as a deliberate convention? Returning 0 for MIN of an empty
  set is non-standard; an agent needs confirmation this is intentional and not an oversight.
  [Consistency, Spec §Edge Cases]

- [X] CHK017 — Are the error message requirements in FR-011 (German + position indicator)
  consistent with the specific message strings in Edge Cases, which omit position indicators
  (e.g., "IF: Bedingung konnte nicht ausgewertet werden" contains no position token)? [Consistency,
  Spec §FR-011, §Edge Cases]

- [X] CHK018 — Does the context-sensitive `>` rule in FR-005 (IF condition) remain consistent
  with the existing range semantics stated in Background §Formula Engine — or does it silently
  change behavior for any expression already valid in Phase 1? [Consistency, Spec §FR-005,
  §Background]

- [X] CHK019 — Are FR numbering and ordering consistent — FR-007 and FR-008 (IF-specific rules)
  appear between FR-006 (ROUND) and FR-009 (case-insensitivity), which may imply the IF-specific
  rules apply only to IF. Is scope of FR-007/FR-008 limited to IF or does it apply to all
  functions? [Consistency, Spec §FR-007, §FR-008]

---

## Acceptance Criteria Quality

- [X] CHK020 — Is SC-001 ("receive correct results for all numeric cells") measurable without
  implementation knowledge — is "correct" defined by reference to the acceptance scenarios, a
  mathematical definition, or both? [Measurability, Spec §SC-001]

- [X] CHK021 — Is SC-005 ("documented with a usage example") measurable: is a minimum
  acceptable example defined (e.g., must include: function syntax, sample input, expected
  output)? [Measurability, Spec §SC-005]

- [X] CHK022 — Is SC-007 ("at least one golden test per function covering the happy path and at
  least one error or boundary case") specific enough for an agent to determine which boundary
  case is mandatory for each of the 6 functions — or does it leave the choice of boundary case
  open-ended? [Measurability, Spec §SC-007]

- [X] CHK023 — Do the acceptance scenarios in US1 include a rectangular range case where column
  order matters (e.g., `MIN(B1>A3)` where B > A), to verify the engine handles inverted range
  bounds? [Acceptance Criteria, Spec §US1]

---

## Scenario Coverage

- [X] CHK024 — Are requirements defined for function composition, e.g., `ROUND(MIN(A1>A5), 2)`,
  `IF(AVERAGE(A1>A5)>10, 1, 0)`, `COUNT(A1>A5)+MIN(A1>A5)`? [Coverage, Spec §US3, §US4]

- [X] CHK025 — Is there a scenario defined where the context-sensitive `>` rule is exercised
  explicitly — a test case where the same formula sheet uses `>` as range in one cell and as
  comparison (in an IF condition) in another, to confirm the disambiguation is deterministic?
  [Coverage, Spec §FR-005, §Clarifications]

- [X] CHK026 — Are requirements defined for the cyclic-reference scenario specific to the new
  functions — e.g., `MIN(A1>A5)` where A3 contains a formula referencing the MIN cell? [Coverage,
  Spec §FR-010]

- [X] CHK027 — Is there a scenario defined for AVERAGE/MIN/MAX/COUNT applied to the full grid
  range `A1>G21` (all 147 cells), validating behavior at maximum scale? [Coverage, Spec §SC-001]

---

## Edge Case Coverage

- [X] CHK028 — Does the spec define behavior for `ROUND(value, 0)` — rounding to zero decimal
  places yielding an integer result — including whether the stored `double` value is exactly an
  integer or may carry floating-point noise? [Edge Case, Spec §US4]

- [X] CHK029 — Does the spec define behavior for IF with identical true and false branches
  (e.g., `IF(A1>0, 5, 5)`) — is this valid, and does it trigger any degenerate parsing path?
  [Edge Case]

- [X] CHK030 — Does the spec define behavior when an aggregate function's range includes the
  result cell itself (indirect cycle via aggregate), e.g., `A3` contains `MIN(A1>A5)` and A3 is
  within the range A1 to A5? [Edge Case, Spec §FR-010]

- [X] CHK031 — Does the spec address behavior when `COUNT` is called on a range where all cells
  hold text — is this covered by the "returns 0" rule stated for all-empty ranges, or is it a
  separate case? [Edge Case, Spec §US2, §Edge Cases]

---

## Non-Functional Requirements

- [X] CHK032 — Are backward-compatibility requirements stated: do existing `.mcalc.json` files
  containing only Phase 1 formulas (no new functions) load and recalculate correctly after the
  extension is deployed? [Non-Functional, Gap]

- [X] CHK033 — Are there requirements ensuring that adding 6 new function cases to the parser
  does not measurably affect evaluation time for the 147-cell grid under normal use? [Non-Functional,
  Gap — acceptable to defer to plan if performance risk is judged low]

---

## Dependencies & Assumptions

- [X] CHK034 — Is the assumption "no TUI changes required beyond the help document" validated
  against the need to surface new error messages from the new functions through the existing
  TUI error-display path — confirming that path is already general enough? [Assumption,
  Spec §Assumptions]

- [X] CHK035 — Is the assumption that `FormulaEvaluator.ParseFactor` is the only extension
  point validated — does the spec confirm no changes are needed to `EvaluationResult`,
  `MicroCalcEngine`, `Cell`, or `SpreadsheetPrinter`? [Dependency, Spec §Key Entities]

- [X] CHK036 — Is the assumption that `MidpointRounding.AwayFromZero` equals "half-up" for all
  input values (including negative numbers) explicitly confirmed as a project-level design
  decision, rather than inferred from .NET documentation? [Assumption, Spec §Assumptions,
  §FR-006]

---

## Notes

- Items marked `[Gap]` indicate a missing requirement; the spec should be updated to address
  them before `/speckit.plan` is run.
- Items marked `[Clarity]` indicate existing requirements that an AI agent may interpret
  differently from the author's intent; the spec should be made more precise.
- Items marked `[Consistency]` indicate potential contradictions between sections.
- CHK033 is flagged as acceptable to defer if the planning phase judges the performance
  impact negligible.
- Run this checklist against spec.md before running `/speckit.plan`. Update spec for any
  `[Gap]` or `[Clarity]` items found to be unresolved.
