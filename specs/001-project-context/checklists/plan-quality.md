# Planning Artifact Quality Checklist: Phase 2 – Extended Formula Library

**Purpose**: Validate that plan.md, research.md, data-model.md, contracts/formula-grammar.md,
and quickstart.md are complete, unambiguous, and consistent enough for an AI agent to implement
and a human reviewer to verify the Phase 2 Extended Formula Library without further clarification.
**Created**: 2026-02-28
**Feature**: [spec.md](../spec.md)
**Depth**: Thorough | **Audience**: AI agent (pre-implementation gate) · Human author (handoff review) · PR reviewer (post-implementation)
**Focus**: Planning artifact quality — decision completeness, cross-artifact consistency, implementation risk

---

## Plan Completeness

- [X] CHK001 — Does plan.md specify the exact implementation branch name (distinct from the speckit
  branch `001-project-context`) so that an agent starts work in the correct branch?
  [Completeness, Gap, Plan §Summary]

- [X] CHK002 — Does plan.md define the acceptance gate for "no regressions" — naming the exact
  test suite (`dotnet test MicroCalc.sln --configuration Release`) and requiring it to pass before
  merge? [Completeness, Plan §Technical Context, Spec §FR-013]

- [X] CHK003 — Does plan.md enumerate every file that will change (FormulaEvaluator.cs,
  FormulaGoldenTests.cs, microcalc-help.md) and explicitly confirm no other files are affected,
  so scope creep is detectable at PR review? [Completeness, Plan §Project Structure]

- [X] CHK004 — Does plan.md specify the estimated net lines of code (~150–200) with enough
  precision that a significantly larger diff would serve as a scope-creep signal for a PR
  reviewer? [Clarity, Plan §Technical Context]

- [X] CHK005 — Does plan.md distinguish which steps require human approval vs. autonomous agent
  execution — or does it assume the agent operates fully autonomously through all implementation
  phases? [Completeness, Gap]

- [X] CHK006 — Does plan.md confirm that the Constitution Check was re-evaluated post-design
  (after all planning artifacts were written), not only as a pre-research gate?
  [Completeness, Plan §Constitution Check]

---

## Research Decision Quality

- [X] CHK007 — Does research.md Decision 1 (extension point) explicitly confirm that
  `EvaluationResult`, `MicroCalcEngine`, `Cell`, and `SpreadsheetPrinter` require NO changes —
  so an agent does not inadvertently modify those types? [Completeness, Research §Decision 1,
  Spec §FR-035 (assumption)]

- [X] CHK008 — Does research.md Decision 2 (`CollectRangeValues`) specify what happens when
  `ResolveCellValue` throws a cyclic-reference exception inside the collection loop — is the
  exception propagated upward, silently skipped, or excluded from the list?
  [Clarity, Research §Decision 2, Spec §FR-010]

- [X] CHK009 — Does research.md Decision 3 (`IsRangeOperatorStart`) specify the exact bounds
  check when `_position + 1` reaches `_text.Length - 1` — i.e., when the column letter is the
  last character with no room for a digit? [Completeness, Research §Decision 3]

- [X] CHK010 — Does research.md Decision 3 specify that the lookahead checks only valid MicroCalc
  column letters A–G (via `SpreadsheetSpec.IsColumnInRange`) rather than any letter A–Z, to
  avoid misidentifying non-column identifiers as range starts?
  [Clarity, Research §Decision 3, Spec §FR-005]

- [X] CHK011 — Does research.md Decision 4 (multi-arg dispatch) specify what happens when an
  unrecognized function name is encountered — does it fall through to `ApplyFunction` (existing
  behavior) or error immediately at the dispatch level? [Completeness, Research §Decision 4]

- [X] CHK012 — Does research.md Decision 4 specify unambiguously whether `Expect('(')` is
  consumed by the dispatch caller (in `ParseIdentifierBasedFactor`) or by each specialized parse
  method (`ParseIfExpression`, `ParseRoundExpression`, `ParseRangeAggregateFunction`)?
  [Clarity, Research §Decision 4]

- [X] CHK013 — Does research.md Decision 5 (aggregate behavior) specify the result when
  MIN/MAX is applied to a range containing exactly one numeric cell — confirming the result is
  that cell's value (not 0)? [Completeness, Research §Decision 5, Spec §Edge Cases]

- [X] CHK014 — Does research.md Decision 8 (test-first order) link each implementation step to
  specific acceptance scenarios in spec.md, or does it leave test case selection open-ended for
  the implementing agent? [Completeness, Research §Decision 8, Spec §SC-007]

---

## Data Model Completeness

- [X] CHK015 — Does data-model.md define the full signature of `ParseRelationalOperator()` —
  including return type, behavior when no operator character is found (error vs. return null),
  and whether it consumes or peeks at the current character?
  [Completeness, Data Model §ParseIfExpression]

- [X] CHK016 — Does data-model.md trace the full parse path for `IF(A1>B5, 1, 0)` — where `>`
  is between two cell refs (range-sum semantics) inside the IF condition — confirming the
  condition evaluation receives the range-sum result and that no parsing conflict arises?
  [Clarity, Data Model §ParseIfExpression, Spec §Edge Cases]

- [X] CHK017 — Does data-model.md enumerate all six relational operators (`=`, `<>`, `<`, `<=`,
  `>=`, `>`) with their evaluation semantics, rather than deferring entirely to FR-005?
  [Completeness, Data Model §ParseIfExpression, Spec §FR-005]

- [X] CHK018 — Does data-model.md explicitly model the single-value path for aggregate functions
  (e.g., `MIN(42)`, `COUNT(A1)`) — specifically how `ParseRangeAggregateFunction` handles an
  expression argument that is NOT a range? [Clarity, Data Model §ParseRangeAggregateFunction]

- [X] CHK019 — Does data-model.md specify the exact AVERAGE computation for an empty list —
  confirming `Count == 0 ? 0 : Sum / Count` rather than any alternative (e.g., LINQ `.Average()`
  which throws on empty sequences)? [Clarity, Data Model §CollectRangeValues, Spec §FR-003]

- [X] CHK020 — Does data-model.md specify which `CellStatusFlags` combination identifies
  "successfully calculated" cells vs. "formula error" cells, resolving the ambiguity in
  FR-004 (COUNT)? [Clarity, Data Model §CellStatusFlags, Spec §FR-004]

- [X] CHK021 — Does data-model.md specify that `IsFormula = true` must be set inside the new
  parse methods (`ParseRangeAggregateFunction`, `ParseIfExpression`, `ParseRoundExpression`),
  consistent with how existing function paths set it?
  [Completeness, Data Model §IsRangeOperatorStart]

- [X] CHK022 — Does data-model.md confirm that no new instance variables are needed on the
  `Parser` class — or identify any new fields required beyond `_text`, `_sheet`,
  `_evaluationStack`, and `_position`? [Completeness, Data Model §Overview]

---

## Grammar Contract Quality

- [X] CHK023 — Does the grammar contract specify whether whitespace is permitted between a
  function name and its opening `(` — e.g., is `MIN (A1>A5)` valid given that `SkipWhitespace()`
  is called before `Expect('(')`? [Clarity, Grammar §Whitespace]

- [X] CHK024 — Does the grammar contract address the inverted-range case (`MIN(B1>A5)` where
  column B > column A) and confirm it is handled by `Math.Min`/`Math.Max` column normalization
  in `CollectRangeValues`? [Completeness, Grammar §aggregate_call, Spec §US1 §Scenario 4]

- [X] CHK025 — Does the grammar contract specify whether nested IF expressions are valid —
  e.g., `IF(IF(A1>0, 1, 0)=1, 10, 20)` — or explicitly declare them out of scope?
  [Completeness, Gap, Grammar §if_call]

- [X] CHK026 — Does the grammar contract define `<>` as two adjacent characters with no
  intervening whitespace, and confirm that `< >` with a space is invalid?
  [Clarity, Grammar §relop]

- [X] CHK027 — Does the grammar contract specify whether function composition depth is
  unlimited (limited only by recursion) or subject to an explicit cap — e.g.,
  `ROUND(IF(A1>0, AVERAGE(A1>A5), MIN(A1>A5)), 2)`?
  [Completeness, Gap, Grammar §formula]

- [X] CHK028 — Does the grammar contract's Backward Compatibility section explicitly confirm
  that `A1>B5` used as a standalone top-level expression (outside any function) is unchanged
  by the `IsRangeOperatorStart` guard? [Consistency, Grammar §Backward Compatibility,
  Spec §Assumptions]

- [X] CHK029 — Does the grammar contract's valid-examples table include a case where `>`
  appears both as a range operator (in one formula) and as a comparison operator (in another
  IF formula on the same sheet) — to illustrate deterministic disambiguation?
  [Coverage, Grammar §Valid Examples, Spec §Clarifications]

---

## Quickstart & Documentation Quality

- [X] CHK030 — Does quickstart.md include at least one IF example for each of the six relational
  operators (`=`, `<>`, `<`, `<=`, `>=`, `>`), or are some operators undocumented?
  [Coverage, Quickstart §IF, Spec §FR-005]

- [X] CHK031 — Does quickstart.md explain the canonical workaround for numeric cell-to-cell
  comparison (`IF(A1-B1>0, 1, 0)`) with enough detail for a user to understand why
  `IF(A1>B1, ...)` has different (range-sum) semantics? [Clarity, Quickstart §IF, Spec §Edge Cases]

- [X] CHK032 — Does quickstart.md specify exactly where in `docs/help/microcalc-help.md` the
  6 new function entries should be added — section, page, or relative position — to satisfy
  SC-005 unambiguously? [Completeness, Gap, Spec §SC-005]

- [X] CHK033 — Does quickstart.md include a COUNT example with a mix of constants, calculated
  formula cells, and text cells in the same range — to document inclusion/exclusion rules
  concretely? [Coverage, Quickstart §COUNT, Spec §FR-004]

- [X] CHK034 — Does quickstart.md specify that help documentation updates must follow the
  same format as existing entries in `docs/help/microcalc-help.md` (e.g., syntax line, sample
  input, expected output) to satisfy SC-005's "usage example" requirement?
  [Completeness, Quickstart §Running Tests, Spec §SC-005, §SC-021]

---

## Cross-Artifact Consistency

- [X] CHK035 — Are the German error message strings in data-model.md (e.g.,
  `"IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."`) character-for-character
  identical to those in spec.md §Edge Cases — with no paraphrasing drift between artifacts?
  [Consistency, Data Model §ParseIfExpression, Spec §Edge Cases, Spec §FR-011]

- [X] CHK036 — Does the grammar contract's `relop` production match the relational operator
  list in spec.md FR-005 exactly (`=`, `<>`, `<`, `<=`, `>=`, `>`) — with no operators added
  or missing? [Consistency, Grammar §relop, Spec §FR-005]

- [X] CHK037 — Does the implementation priority order in research.md Decision 8
  (P1: MIN/MAX/AVERAGE → P2: COUNT → P3a: ROUND → P3b: IF) match the priority labels in
  spec.md User Stories (US1=P1, US2=P2, US3=P3, US4=P3)?
  [Consistency, Research §Decision 8, Spec §User Stories]

- [X] CHK038 — Does data-model.md's `CollectRangeValues` inclusion rule (`Constant` OR
  `Calculated` flags) match research.md Decision 5's aggregate behavior table (formula error
  cells excluded, empty cells excluded)?
  [Consistency, Data Model §CellStatusFlags, Research §Decision 5]

- [X] CHK039 — Do research.md Decision 3 and the grammar contract's disambiguation note agree
  on the exact lookahead condition — both requiring a valid column letter (A–G) followed
  immediately by a digit? [Consistency, Research §Decision 3, Grammar §Disambiguation]

---

## Implementation Risk Coverage

- [X] CHK040 — Does any planning artifact specify a regression-guard strategy for the
  `SumRange` refactor — confirming that `CollectRangeValues().Sum()` produces results
  numerically identical to the current loop for all existing test inputs?
  [Risk, Gap, Research §Decision 2, Spec §FR-013]

- [X] CHK041 — Does any planning artifact address whether `SkipWhitespace()` between a parsed
  cell address and `>` affects the position index used by `IsRangeOperatorStart()` — i.e.,
  does the guard read from `_position` (post-whitespace) or a pre-whitespace snapshot?
  [Risk, Research §Decision 3]

- [X] CHK042 — Does any planning artifact specify a strategy if the `CollectRangeValues`
  refactor introduces a regression — e.g., a feature flag, a parallel implementation, or
  a dedicated before/after test fixture? [Risk, Gap]

- [X] CHK043 — Does any planning artifact address function name collision risk — confirming
  that none of the new names (MIN, MAX, AVERAGE, COUNT, IF, ROUND) conflict with column names
  (A–G are single letters) or any other valid identifier in the existing grammar?
  [Risk, Gap, Spec §FR-009]

---

## Test Strategy in Planning Artifacts

- [X] CHK044 — Does research.md Decision 8 or any other planning artifact specify the minimum
  number of `[Theory]` data rows per function — or does it defer entirely to the spec's
  "at least one happy path + one boundary case" without adding implementer-level precision?
  [Completeness, Research §Decision 8, Spec §FR-012, §SC-007]

- [X] CHK045 — Do the planning artifacts identify which spec acceptance scenarios require
  dedicated golden test entries — e.g., inverted range `MIN(B1>A5)`, rectangular range
  AVERAGE, IF with range-sum condition `IF(A1>B5, 1, 0)` — rather than leaving test case
  selection entirely to the implementing agent?
  [Completeness, Gap, Spec §SC-007, §US1 §Scenario 4]

---

## Notes

- Items marked `[Gap]` indicate a missing decision or specification in the planning artifacts;
  the relevant artifact should be updated before implementation begins.
- Items marked `[Clarity]` indicate ambiguity that an implementing agent may resolve differently
  than intended; these should be made explicit.
- Items marked `[Consistency]` indicate potential drift between artifacts that could cause
  an agent to implement based on one artifact while violating another.
- Items marked `[Risk]` indicate implementation decisions where an error could cause
  regressions or hard-to-detect behavioral changes.
- Run this checklist against all planning artifacts before running `/speckit.tasks`. Update
  artifacts for any `[Gap]`, `[Clarity]`, or `[Consistency]` items found to be unresolved.
