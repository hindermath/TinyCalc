# Test Case Specification Quality Checklist: Phase 2 – Extended Formula Library

**Purpose**: Validate that the test case specifications in tasks T006–T017a are complete,
unambiguous, and precise enough for an AI agent to write correct xUnit 2.x test code in
`FormulaGoldenTests.cs` and `MicroCalcEngineTests.cs` without guessing at conventions,
cell setup APIs, expected values, or assertion patterns.
**Created**: 2026-02-28
**Feature**: [spec.md](../spec.md)
**Depth**: Standard | **Audience**: AI agent self-validation (gate before T001 execution)
**Focus**: Test case specification quality — xUnit conventions, cell setup, expected outputs,
error assertions, and scenario coverage completeness

---

## xUnit Conventions & Test Method Structure

- [X] CHK001 — Do the test tasks specify whether new `[Theory]` golden cases should be added
  as `yield return` entries in a **new** static data method or **appended to an existing** one
  (such as `ArithmeticGoldenCases`)? Without this, an agent may append MIN rows to the wrong
  method or create duplicate method names. [Clarity, Gap, tasks.md T006–T017]

- [X] CHK002 — Do the test tasks specify whether to use `[MemberData(nameof(...))]` (the
  established convention in `FormulaGoldenTests.cs`) or `[InlineData(...)]` for new test rows?
  Mixing conventions breaks the existing pattern without justification. [Clarity, tasks.md T006–T017]

- [X] CHK003 — Do the test tasks specify that the success-case data tuple requires **three**
  elements — `(string expression, double expected, bool expectedIsFormula)` — matching the
  existing `ArithmeticGoldenCases` signature, and that all new function tests must pass
  `true` for `expectedIsFormula`? The task descriptions omit the `isFormula` element entirely.
  [Completeness, Gap, tasks.md T006–T014, FormulaGoldenTests.cs:10–23]

- [X] CHK004 — Do the test tasks specify test method naming following the existing convention
  (`Evaluate_ArithmeticGoldenCases_ReturnExpectedValues`) — e.g.,
  `Evaluate_MinGoldenCases_ReturnExpectedValues` — so the agent does not invent arbitrary names?
  [Clarity, Gap, tasks.md T006–T017]

- [X] CHK005 — Do the test tasks confirm that the existing floating-point assertion
  (`Math.Abs(result.Value - expected) < 1e-9`) applies to all new numeric test cases, and
  that all specified expected values (3.14, 2.5, 15.0, etc.) are within this tolerance when
  compared to the actual computed result? [Clarity, tasks.md T006–T014,
  FormulaGoldenTests.cs:46]

---

## Cell Setup Specification

- [X] CHK006 — Do the test tasks specify the Spreadsheet cell initialization API for
  `FormulaGoldenTests` — specifically, how an agent sets A1=10 (Constant cell) when using
  `new Spreadsheet()` without `MicroCalcEngine`? The tasks describe required cell values but
  never the API to write them. [Completeness, Gap, tasks.md T006–T017]

- [X] CHK007 — For T008's sparse AVERAGE test ("A2 empty"), is "empty" defined precisely as the
  default uninitialized cell state of `new Spreadsheet()` — i.e., no `CellStatusFlags` set and
  `Contents = null/""` — rather than an explicit empty-cell API call? COUNT and AVERAGE
  correctness depends on this distinction. [Clarity, tasks.md T008, Spec §FR-003, §FR-004]

- [X] CHK008 — For T006's cyclic-reference `[Fact]` test, is the exact cell setup API specified
  — i.e., which property and flag combination (`cell.Contents = "MIN(A1>A5)"` +
  `cell.Status = CellStatusFlags.Constant`) causes `ResolveCellValue` to re-parse the cell
  and trigger the cyclic-reference guard? [Completeness, Gap, tasks.md T006, Spec §FR-010]

- [X] CHK009 — For T011's "all-text range" COUNT test, is the method for creating a text cell
  (`CellStatusFlags.Text` set, `Constant` flag NOT set) in a plain `Spreadsheet` specified —
  so the agent does not accidentally mark text cells as Constant, which would include them in
  `CollectRangeValues`? [Clarity, tasks.md T011, Spec §FR-004, data-model.md §CellStatusFlags]

- [X] CHK010 — For T017's IF equality test `IF(A1=A2,10,20)`, are both A1 and A2 values
  specified with separate `[InlineData]`/`yield return` rows for each branch — e.g.,
  "A1=5,A2=5 → 10" (true branch) and "A1=5,A2=6 → 20" (false branch)? The current
  description provides only the formula, leaving expected output and cell values ambiguous.
  [Completeness, tasks.md T017]

- [X] CHK011 — For T017's IF not-equal test `IF(A1<>0,A1,0)`, is A1's specific value and
  therefore the expected output explicitly stated — e.g., "A1=5 → expected 5", "A1=0 → expected 0"
  as two separate test rows? Currently "A1,0" does not specify what A1 is. [Completeness,
  tasks.md T017]

- [X] CHK012 — For T017's range-sum condition test `IF(A1>B5,1,0)`, are the values for all
  cells in the A1–B5 range (10 cells across 2 columns and 5 rows) specified so that SUM(A1:B5)
  and therefore the expected output (0 or 1) is deterministic? [Completeness, tasks.md T017,
  Spec §US3 Scenario 4]

---

## Expected Output Precision

- [X] CHK013 — For T006's MIN single-cell test, is "cell value" replaced with a concrete
  number — e.g., "A1=42, MIN(A1)=42" — so the agent does not have to invent a test value?
  The placeholder "cell value" is not an actionable expected output. [Clarity, tasks.md T006]

- [X] CHK014 — For T014's ROUND composition test, is the expected output clarified as the
  `double` value `3.0` (not "3.00") — since `Math.Round(3.0, 2, AwayFromZero)` returns `3.0`
  in IEEE 754 double, and "3.00" could mislead an agent into asserting decimal formatting?
  [Clarity, tasks.md T014, Spec §FR-006]

- [X] CHK015 — For T017's nested-branch test `IF(A1>0,MAX(A1>A3),MIN(A1>A3))`, are A1, A2,
  and A3 values defined and the specific expected output stated — e.g., "A1=10,A2=20,A3=30,
  A1>0 is true → MAX(10,20,30)=30" — rather than the vague "MAX or MIN result"?
  [Completeness, tasks.md T017]

- [X] CHK016 — For T011's COUNT sparse range test, is it explicitly stated which cells hold
  values and which are empty — e.g., "A1=5, A2=empty, A3=10, A4=empty, A5=15" — consistent
  with the Phase 4 Independent Test description, rather than leaving "3 values and 2 empty"
  unpositioned? [Clarity, tasks.md T011, tasks.md Phase 4 §Independent Test]

- [X] CHK017 — For T008's rectangular AVERAGE test `AVERAGE(A1>B2)=2.5`, are all four cell
  values confirmed (A1=1,A2=2,B1=3,B2=4) and is it clear that column A cells are rows 1–2
  and column B cells are rows 1–2 — not rows 3–4? Misreading row vs. column layout would
  produce a wrong expected value. [Clarity, tasks.md T008]

---

## Error Test Precision

- [X] CHK018 — Do the test tasks list the exact German error message fragment for each `[Fact]`
  error test — or must the agent cross-reference `data-model.md` to find the correct substrings?
  Currently T006 says "containing 'Zyklische Referenz'" and T014 says "containing 'Negative
  Nachkommastellen'" but T017's error fragments for "no relop" and "fewer than 3 args" are
  not quoted in the task description. [Clarity, Gap, tasks.md T006, T014, T017]

- [X] CHK019 — For T006's cyclic-reference error, is the exact fragment specified as
  `"Zyklische Referenz in A1"` (cell address appended, per the existing
  `Error($"Zyklische Referenz in {address}.")` format) rather than just "Zyklische Referenz",
  which is also a substring of the format but less precise? [Clarity, tasks.md T006,
  FormulaEvaluator.cs:272]

- [X] CHK020 — For T017's "no relational operator" error test `IF(A1,1,0)`, is A1's value
  specified so the parser deterministically reaches the relop-parse step before failing — e.g.,
  "A1=5" rather than leaving A1 empty (which would cause `ResolveCellValue` to return 0.0,
  still reaching the relop step, but should be explicit)? [Clarity, tasks.md T017]

- [X] CHK021 — Do the error test tasks specify whether `result.ErrorPosition >= 1` should be
  asserted (as the existing `Evaluate_InvalidGoldenCases` method does) or whether error position
  checking is intentionally omitted for the new error tests? Omitting it silently breaks
  Constitution §III's error-position invariant. [Completeness, Gap, tasks.md T006, T014, T017,
  FormulaGoldenTests.cs:59]

---

## Integration Test Precision

- [X] CHK022 — Does T017a specify that `result.Success` (the return value of `Recalculate()`)
  should be asserted after each recalculate call — not only `B1.Value` — so that a silent
  evaluation failure inside IF does not produce a false-positive test? [Completeness,
  tasks.md T017a, MicroCalcEngineTests.cs:45–47]

- [X] CHK023 — Does T017a specify the exact `EditCell` API call for entering the IF formula in
  B1 — i.e., `engine.EditCell(new CellAddress('B', 1), "IF(A1>100, 1, 0)")` — consistent with
  the existing `MicroCalcEngineTests.cs` convention, rather than leaving the call signature
  implicit? [Clarity, tasks.md T017a, MicroCalcEngineTests.cs:14]

---

## Coverage Completeness

- [X] CHK024 — Is an inverted-column-order range test (e.g., `MIN(B1>A5)` where column B >
  column A) included in T006 or T007, confirming that `CollectRangeValues` column-order
  normalization works? This was listed as a required acceptance scenario in spec.md §US1
  Scenario 4 but is absent from the test task descriptions. [Coverage, Gap, tasks.md T006–T007,
  Spec §US1 Scenario 4]

- [X] CHK025 — Does T017 include test rows for the `<=` (less-than-or-equal) and `>=`
  (greater-than-or-equal) relational operators? Current task description covers `>`, `=`, `<>`,
  `<`, and lowercase `if`, but `<=` and `>=` are not listed — yet FR-005 requires all six
  operators. [Coverage, tasks.md T017, Spec §FR-005]

---

## Notes

- All items gate on the **task descriptions** as requirements for the implementing agent —
  not on the generated test code itself.
- An agent that passes this checklist before starting T006 will be able to write all golden
  tests without making undocumented assumptions about xUnit conventions, Spreadsheet API usage,
  or expected numeric values.
- Items marked `[Gap]` indicate missing information that must be resolved in tasks.md before
  the implementing agent begins the corresponding task.
- The existing `FormulaGoldenTests.cs` (lines 1–60) and `MicroCalcEngineTests.cs` (lines 1–49)
  provide the authoritative convention reference; task descriptions should either quote these
  conventions or explicitly reference those files.
