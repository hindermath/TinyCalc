# Tasks: Phase 2 – Extended Formula Library

**Input**: Design documents from `specs/001-project-context/`
**Prerequisites**: plan.md ✅ · spec.md ✅ · research.md ✅ · data-model.md ✅ · contracts/ ✅

**Implementation branch**: `codex/extended-formula-library` (separate from speckit branch `001-project-context`)
**Single modified source file**: `src/MicroCalc.Core/Formula/FormulaEvaluator.cs`
**Test file**: `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs`
**Help doc**: `docs/help/microcalc-help.md`

**Test-first policy (FR-012, Constitution Principle III)**: Every implementation task is preceded by
a test task. Tests MUST compile and FAIL before the implementing code is written, then turn GREEN
after. No function is considered done until its golden tests are GREEN and the full suite shows
no regressions.

## Format: `[ID] [P?] [Story?] Description`

- **[P]**: Parallelizable (touches a different file from other concurrent tasks, no blocking dependency)
- **[US1/2/3/4]**: User story label (from spec.md)
- All tasks carry exact file paths

---

## Phase 1: Setup

**Purpose**: Establish the correct implementation branch and confirm a clean baseline before any code changes.

- [ ] T001 Create implementation branch `codex/extended-formula-library` from `main` (git checkout -b codex/extended-formula-library main)
- [ ] T002 Run full test suite to confirm clean baseline: `dotnet test MicroCalc.sln --configuration Release` — all existing tests must be GREEN before any changes

**Checkpoint**: Baseline confirmed — foundational refactors can begin.

---

## Phase 2: Foundational (Blocking Prerequisites)

**Purpose**: Two refactors in `FormulaEvaluator.cs` that ALL user story implementations depend on.
Neither refactor adds visible functionality; both must leave all existing tests GREEN.

**⚠️ CRITICAL**: No user story phase can begin until both T003 and T004 are complete and T005 confirms GREEN.

- [ ] T003 Extract `private IReadOnlyList<double> CollectRangeValues(CellAddress from, CellAddress to)` from `SumRange`'s traversal loop, and refactor `SumRange` to delegate: `CollectRangeValues(from, to).Sum()` in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Research §Decision 2, Data Model §CollectRangeValues)

- [ ] T004 Add `private bool IsRangeOperatorStart()` lookahead helper and replace the unconditional `Match('>')` in `ParseIdentifierBasedFactor` with a guarded check `if (Current() == '>' && IsRangeOperatorStart())` in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Research §Decision 3, Data Model §IsRangeOperatorStart)

- [ ] T005 Run full test suite (`dotnet test MicroCalc.sln --configuration Release`) to verify foundational refactors introduce no regressions — all existing tests must remain GREEN (Spec §FR-013)

**Checkpoint**: Foundation ready — user story phases can now begin in priority order.

---

## Phase 3: User Story 1 – Range Analysis Functions (Priority: P1) 🎯 MVP

**Goal**: `MIN(range)`, `MAX(range)`, `AVERAGE(range)` work for any rectangular range, single cell,
or sparse range with empty/text cells. (Spec §US1, §FR-001–FR-003)

**Independent Test**: With A1=10, A2=20, A3=30, A4=40, A5=50 — `MIN(A1>A5)` = 10,
`MAX(A1>A5)` = 50, `AVERAGE(A1>A5)` = 30. Fully verifiable without IF or ROUND.

### Tests for User Story 1 ⚠️ Write first — must FAIL before T009

- [ ] T006 [US1] Add `[Theory]` golden test rows for MIN: happy path (MIN(A1>A5)=10), empty range (MIN of all-empty cells=0), single cell (MIN(A1)=cell value), rectangular range (MIN(A1>B2) with A1=1,A2=2,B1=3,B2=4 → 1) in `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` — verify tests compile and FAIL (Spec §US1 Scenarios 1,4,5; Research §Decision 5)

- [ ] T007 [US1] Add `[Theory]` golden test rows for MAX: happy path (MAX(A1>A5)=50), empty range (MAX of all-empty=0), rectangular range (MAX(A1>B2)=4) in `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` — verify tests compile and FAIL (Spec §US1 Scenarios 2,4,5; Research §Decision 5)

- [ ] T008 [US1] Add `[Theory]` golden test rows for AVERAGE: happy path (AVERAGE(A1>A5)=30), empty range (AVERAGE of all-empty=0), rectangular range (AVERAGE(A1>B2)=2.5), sparse range with empty cells (AVERAGE(A1>A3) with A1=10,A2 empty,A3=20 → 15) in `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` — verify tests compile and FAIL (Spec §US1 Scenarios 3,4,5; Research §Decision 5)

### Implementation for User Story 1

- [ ] T009 [US1] Add `ParseRangeAggregateFunction(string name)` private method handling MIN (`values.DefaultIfEmpty(0).Min()`), MAX (`values.DefaultIfEmpty(0).Max()`), AVERAGE (`values.Count == 0 ? 0 : values.Sum() / values.Count`) using `CollectRangeValues`; extend `ParseIdentifierBasedFactor` dispatch to route `"MIN"`, `"MAX"`, `"AVERAGE"` to this method in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Research §Decision 4, Data Model §ParseRangeAggregateFunction)

- [ ] T010 [US1] Run formula golden tests (`dotnet test tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj --configuration Release --filter "FullyQualifiedName~FormulaGoldenTests"`) — all US1 tests must be GREEN; run full suite to confirm no regressions

**Checkpoint**: MIN, MAX, AVERAGE fully functional — MVP deliverable. Validate independently before proceeding.

---

## Phase 4: User Story 2 – Count Numeric Cells (Priority: P2)

**Goal**: `COUNT(range)` returns the exact count of numeric-valued cells, ignoring empty and text
cells. (Spec §US2, §FR-004)

**Independent Test**: A1=5, A2 empty, A3=10, A4 empty, A5=15 → `COUNT(A1>A5)` = 3. No dependency
on IF or ROUND.

### Tests for User Story 2 ⚠️ Write first — must FAIL before T012

- [ ] T011 [US2] Add `[Theory]` golden test rows for COUNT: sparse range (COUNT(A1>A5)=3 with 3 values and 2 empty), all-empty range (COUNT=0), all-text range (COUNT=0), single numeric cell (COUNT(A1)=1), single empty cell (COUNT(A1)=0) in `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` — verify tests compile and FAIL (Spec §US2 Scenarios 1,2,3; Research §Decision 5)

### Implementation for User Story 2

- [ ] T012 [US2] Add `"COUNT"` case to `ParseRangeAggregateFunction` returning `values.Count` (count of cells included by `CollectRangeValues`, i.e., Constant or Calculated cells only); extend `ParseIdentifierBasedFactor` dispatch to route `"COUNT"` in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Research §Decision 5, Data Model §CellStatusFlags)

- [ ] T013 [US2] Run formula golden tests and full suite — all US2 tests must be GREEN, no regressions

**Checkpoint**: COUNT functional. US1 + US2 (full statistical toolkit) independently verifiable.

---

## Phase 5: User Story 4 – Rounding (Priority: P3a)

**Goal**: `ROUND(value, decimals)` rounds using `MidpointRounding.AwayFromZero`; non-integer
decimals truncated; negative decimals produce a descriptive error. Implemented before IF because
it is simpler (2-arg, no range or relational parsing). (Spec §US4, §FR-006, Research §Decision 8)

**Independent Test**: `ROUND(3.14159, 2)` = 3.14 in any cell. No dependency on IF.

### Tests for User Story 4 ⚠️ Write first — must FAIL before T015

- [ ] T014 [US4] Add `[Theory]` golden test rows for ROUND: happy path (ROUND(3.14159,2)=3.14), away-from-zero positive (ROUND(2.5,0)=3), away-from-zero negative (ROUND(-2.5,0)=-3), non-integer decimals truncated (ROUND(3.14,1.7)=3.1), composed with AVERAGE (ROUND(AVERAGE(A1>A5),2)=3.00 for A1–A5=1,2,3,4,5); add `[Fact]` error test for negative decimals (ROUND(3.14,-1) → error message containing "Negative Nachkommastellen") in `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` — verify tests compile and FAIL (Spec §US4 Scenarios 1,2,3a,3; Research §Decision 7)

### Implementation for User Story 4

- [ ] T015 [US4] Implement `ParseRoundExpression()`: consume `value_expr`, `Expect(',')`, consume `decimals_expr`, apply `(int)Math.Truncate(decimals)`, guard `decimals < 0` with `Error("ROUND: Negative Nachkommastellen sind nicht erlaubt.")`, return `Math.Round(value, decimals, MidpointRounding.AwayFromZero)`; extend `ParseIdentifierBasedFactor` dispatch to route `"ROUND"` in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Research §Decision 7, Data Model §ParseRoundExpression)

- [ ] T016 [US4] Run formula golden tests and full suite — all US4 tests must be GREEN, no regressions

**Checkpoint**: ROUND functional. US1 + US2 + US4 all independently verifiable.

---

## Phase 6: User Story 3 – Conditional Formulas with IF (Priority: P3b)

**Goal**: `IF(condition, true_value, false_value)` evaluates a mandatory relational condition and
returns the appropriate numeric branch. Relational operator required; bare expression is a syntax
error. (Spec §US3, §FR-005, §FR-007, §FR-008, Research §Decision 8)

**Independent Test**: A1=150 → `IF(A1>100, 1, 0)` = 1. Change A1=50 → recalculate → 0.

### Tests for User Story 3 ⚠️ Write first — must FAIL before T018

- [ ] T017 [US3] Add `[Theory]` golden test rows for IF: greater-than comparison (IF(A1>100,1,0)=1 with A1=150 and =0 with A1=50), equality (IF(A1=A2,10,20)), not-equal (IF(A1<>0,A1,0)), less-than (IF(A1<10,1,0)), range-sum condition (IF(A1>B5,1,0) where A1>B5 treats `>` as range-sum per existing semantics), nested function branches (IF(A1>0,MAX(A1>A3),MIN(A1>A3))); add `[Fact]` error tests for: no relational operator (IF(A1,1,0) → error), fewer than 3 args (IF(A1>0,1) → error) in `tests/MicroCalc.Core.Tests/FormulaGoldenTests.cs` — verify tests compile and FAIL (Spec §US3 Scenarios 1,2,3,4; §Edge Cases; Research §Decision 3)

### Implementation for User Story 3

- [ ] T018 [US3] Implement `ParseRelationalOperator()`: scan for `<>`, `<=`, `>=`, `<`, `>`, `=` at current position (multi-char ops checked before single-char); return the matched operator string and advance `_position`; return `null` (do not throw) when no relational op is found — caller is responsible for the error in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Data Model §ParseIfExpression)

- [ ] T019 [US3] Implement `ParseIfExpression()`: parse `left_expr` via `ParseExpression()`, call `ParseRelationalOperator()` (throw `"IF: Bedingung muss einen Vergleichsoperator enthalten (=, <>, <, <=, >=, >)."` if null), parse `right_expr`, `Expect(',')` (throw `"IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert."` on failure), parse `true_expr`, `Expect(',')`, parse `false_expr`, `Expect(')')`, evaluate relational condition, return winning branch in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs` (Data Model §ParseIfExpression, Spec §FR-005, §FR-007)

- [ ] T020 [US3] Extend `ParseIdentifierBasedFactor` dispatch to route `"IF"` to `ParseIfExpression()` in `src/MicroCalc.Core/Formula/FormulaEvaluator.cs`

- [ ] T021 [US3] Run formula golden tests and full suite — all US3 tests must be GREEN, no regressions; confirm `IF(A1>100,1,0)` and `IF(A1>B5,1,0)` both produce correct results (context-sensitive `>` disambiguation verified)

**Checkpoint**: All 6 new functions (MIN, MAX, AVERAGE, COUNT, ROUND, IF) fully functional.

---

## Phase 7: Polish & Cross-Cutting Concerns

**Purpose**: Documentation and final validation sweep.

- [ ] T022 [P] Add 6 new function entries to `docs/help/microcalc-help.md` following the format of existing entries: function name, syntax, description, and at least one example with expected output for MIN, MAX, AVERAGE, COUNT, IF, ROUND (Spec §SC-005, §SC-021)

- [ ] T023 Run full test suite (`dotnet test MicroCalc.sln --configuration Release`) as final gate — all Core.Tests + Tui.Tests must be GREEN with no regressions (Spec §SC-006, §FR-013)

**Checkpoint**: All success criteria (SC-001 through SC-007) met. Ready for PR.

---

## Dependencies & Execution Order

### Phase Dependencies

```
Phase 1 (Setup)
    └─► Phase 2 (Foundational) — BLOCKS all user stories
            ├─► Phase 3 (US1: MIN/MAX/AVERAGE P1)  ┐
            ├─► [after US1] Phase 4 (US2: COUNT P2) ├─► Phase 7 (Polish)
            ├─► [after US2] Phase 5 (US4: ROUND P3a)│
            └─► [after ROUND] Phase 6 (US3: IF P3b) ┘
```

### User Story Dependencies

- **US1 (P1 — MIN/MAX/AVERAGE)**: Depends on Phase 2 (CollectRangeValues, IsRangeOperatorStart). No story dependencies.
- **US2 (P2 — COUNT)**: Depends on Phase 2 + US1 complete (reuses `ParseRangeAggregateFunction`). Sequential with US1.
- **US4 (P3a — ROUND)**: Depends on Phase 2. No story dependencies. Can start after Phase 2, parallel to US1/US2.
- **US3 (P3b — IF)**: Depends on Phase 2 + IsRangeOperatorStart guard (T004). Best started after US4 (simpler P3 first). Requires `ParseRelationalOperator` helper.

### Within Each User Story

1. Test tasks (TXxx) MUST be written and FAIL before implementation tasks
2. Implementation runs after tests are confirmed RED
3. Verification run after implementation — tests must be GREEN
4. Full suite regression check after each user story completes

---

## Parallel Opportunities

Only T022 (help doc, different file) is truly parallelizable with other Phase 7 work.
All other tasks modify the same two files (`FormulaEvaluator.cs`, `FormulaGoldenTests.cs`)
and must be sequential within those files.

```
# Phase 7 — can overlap:
T022: docs/help/microcalc-help.md  ← can start while T021 runs its final test sweep
T023: Final full-suite gate         ← after T022 complete
```

---

## Implementation Strategy

### MVP First (User Story 1 Only — MIN/MAX/AVERAGE)

1. Phase 1: Create branch + baseline check (T001–T002)
2. Phase 2: CollectRangeValues + IsRangeOperatorStart refactors (T003–T005)
3. Phase 3: Write tests RED → implement → GREEN (T006–T010)
4. **STOP AND VALIDATE**: Three functions work, no regressions. Demo-able.

### Incremental Delivery

| Stage | Adds | Cumulative Functions |
|-------|------|----------------------|
| After Phase 3 | MIN, MAX, AVERAGE | 3 of 6 ✅ |
| After Phase 4 | COUNT | 4 of 6 ✅ |
| After Phase 5 | ROUND | 5 of 6 ✅ |
| After Phase 6 | IF | 6 of 6 ✅ |
| After Phase 7 | Help doc, final gate | Feature complete ✅ |

### Single-Agent Execution Order

```
T001 → T002 → T003 → T004 → T005
→ T006 → T007 → T008 → T009 → T010
→ T011 → T012 → T013
→ T014 → T015 → T016
→ T017 → T018 → T019 → T020 → T021
→ T022 → T023
```

Total: 23 tasks · 7 phases · 1 source file + 1 test file + 1 help doc

---

## Notes

- All tasks follow Constitution Principle III (test-first): no function is implemented before
  its golden test exists and is confirmed RED.
- All test runs use `--configuration Release` (CI-aligned, per CLAUDE.md).
- Error messages are German throughout (Spec §FR-011), matching existing evaluator style.
- `IsFormula = true` must be set in all new parse paths (data-model.md §Invariants Preserved).
- Cyclic reference detection is inherited automatically via `ResolveCellValue` — no new
  guard code required (data-model.md §Invariants Preserved, Spec §FR-010).
- After Phase 6, open a PR to `main` with description at `docs/PR_TEXT_EXTENDED-FORMULA-LIBRARY.md`
  (CLAUDE.md branching conventions).
