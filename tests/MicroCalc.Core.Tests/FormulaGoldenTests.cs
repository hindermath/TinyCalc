using MicroCalc.Core.Formula;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Tests;

public sealed class FormulaGoldenTests
{
    private readonly FormulaEvaluator _evaluator = new();

    public static IEnumerable<object[]> ArithmeticGoldenCases()
    {
        yield return ["2+3*4", 14.0, false];
        yield return ["(2+3)*4", 20.0, false];
        yield return ["2^3^2", 64.0, false];
        yield return [".5+1", 1.5, false];
        yield return ["+7", 7.0, false];
        yield return ["1.2E-3*1000", 1.2, false];
        yield return ["ABS(-3)+SQR(4)", 19.0, false];
        yield return ["LN(EXP(2))", 2.0, false];
        yield return ["LOG(1000)", 3.0, false];
        yield return ["FACT(5)", 120.0, false];
        yield return ["ARCTAN(1)", Math.PI / 4.0, false];
    }

    // ── T006: MIN golden cases (sheet: A1=10..A5=50) ─────────────────────────
    public static IEnumerable<object[]> MinGoldenCases()
    {
        // happy path: A1=10..A5=50, MIN(A1>A5)=10
        yield return ["MIN(A1>A5)", 10.0, true];
        // single numeric cell A1=10 → MIN(A1)=10
        yield return ["MIN(A1)", 10.0, true];
        // lowercase name
        yield return ["min(A1>A5)", 10.0, true];
    }

    // ── T007: MAX golden cases (sheet: A1=10..A5=50) ─────────────────────────
    public static IEnumerable<object[]> MaxGoldenCases()
    {
        // happy path
        yield return ["MAX(A1>A5)", 50.0, true];
        // lowercase name
        yield return ["max(A1>A5)", 50.0, true];
    }

    // ── T008: AVERAGE golden cases (sheet: A1=10..A5=50) ─────────────────────
    public static IEnumerable<object[]> AverageGoldenCases()
    {
        // happy path: (10+20+30+40+50)/5 = 30
        yield return ["AVERAGE(A1>A5)", 30.0, true];
        // lowercase name
        yield return ["average(A1>A5)", 30.0, true];
    }

    // ── T011: COUNT golden cases ──────────────────────────────────────────────
    // Sheet for count tests: A1=10, A6=5,A8=10,A10=15 (sparse A6..A10)
    public static IEnumerable<object[]> CountGoldenCases()
    {
        // sparse range with 3 values and 2 empty: A6=5,A7 empty,A8=10,A9 empty,A10=15 → COUNT=3
        yield return ["COUNT(A6>A10)", 3.0, true];
        // single numeric cell A1=10 → 1
        yield return ["COUNT(A1)", 1.0, true];
        // lowercase name
        yield return ["count(A6>A10)", 3.0, true];
    }

    // ── T014: ROUND golden cases ──────────────────────────────────────────────
    public static IEnumerable<object[]> RoundGoldenCases()
    {
        // happy path
        yield return ["ROUND(3.14159,2)", 3.14, true];
        // away-from-zero positive: 2.5 → 3
        yield return ["ROUND(2.5,0)", 3.0, true];
        // away-from-zero negative: -2.5 → -3
        yield return ["ROUND(-2.5,0)", -3.0, true];
        // non-integer decimals truncated: 1.7 → 1
        yield return ["ROUND(3.14,1.7)", 3.1, true];
        // composed with AVERAGE: ROUND(AVERAGE(A1>A5),2) where A1=10..A5=50 → ROUND(30,2)=30
        yield return ["ROUND(AVERAGE(A1>A5),2)", 30.0, true];
        // lowercase name
        yield return ["round(3.14159,2)", 3.14, true];
    }

    // ── T017: IF golden cases ─────────────────────────────────────────────────
    // Sheet: A1=150, A2=20, A3=10, A4=40, A5=50, B1..B5=10..50, A15=150
    // G21 is empty (default 0) for "not-equal false" test
    public static IEnumerable<object[]> IfGoldenCases()
    {
        // greater-than true branch: A1=150 > 100 → 1
        yield return ["IF(A1>100,1,0)", 1.0, true];
        // greater-than false branch: A3=10, 10>100 is false → 0
        yield return ["IF(A3>100,1,0)", 0.0, true];
        // equality true: A1=150 = A15=150 → 10
        yield return ["IF(A1=A15,10,20)", 10.0, true];
        // equality false: A1=150 ≠ A3=10 → 20
        yield return ["IF(A1=A3,10,20)", 20.0, true];
        // not-equal true: A3=10 <> 0 → A3=10
        yield return ["IF(A3<>0,A3,0)", 10.0, true];
        // not-equal false: G21=0 (empty, returns 0) <> 0 is false → 0
        yield return ["IF(G21<>0,G21,0)", 0.0, true];
        // less-than true: A3=10 < 100 → 1
        yield return ["IF(A3<100,1,0)", 1.0, true];
        // less-than false: A1=150 < 100 → 0
        yield return ["IF(A1<100,1,0)", 0.0, true];
        // less-than-or-equal true: A3=10 <= 10 → 1
        yield return ["IF(A3<=10,1,0)", 1.0, true];
        // less-than-or-equal false: A1=150 <= 100 → 0
        yield return ["IF(A1<=100,1,0)", 0.0, true];
        // greater-than-or-equal true: A1=150 >= 100 → 1
        yield return ["IF(A1>=100,1,0)", 1.0, true];
        // greater-than-or-equal false: A3=10 >= 100 → 0
        yield return ["IF(A3>=100,1,0)", 0.0, true];
        // nested function branches: A1=150>0 is true → MAX(A1>A3)=MAX(150,20,10)=150
        yield return ["IF(A1>0,MAX(A1>A3),MIN(A1>A3))", 150.0, true];
        // lowercase name
        yield return ["if(A1>100,1,0)", 1.0, true];
    }

    public static IEnumerable<object[]> InvalidFormulaCases()
    {
        yield return ["SQRT(-1)", "SQRT"];
        yield return ["LOG(0)", "LOG"];
        yield return ["UNKNOWN(2)", "Unbekannte Funktion"];
        yield return ["A22", "gültigen Bereichs"];
        yield return ["1/0", "Division durch Null"];
        yield return ["FACT(34)", "FACT erwartet"];
        yield return ["A1+", "Ausdruck"];
    }

    [Theory]
    [MemberData(nameof(ArithmeticGoldenCases))]
    public void Evaluate_ArithmeticGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        var sheet = new Spreadsheet();

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}' at {result.ErrorPosition}.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9, $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Theory]
    [MemberData(nameof(InvalidFormulaCases))]
    public void Evaluate_InvalidGoldenCases_ReturnExpectedErrors(string expression, string expectedMessageFragment)
    {
        var sheet = new Spreadsheet();

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.False(result.Success);
        Assert.Contains(expectedMessageFragment, result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        Assert.True(result.ErrorPosition >= 1);
    }

    [Fact]
    public void Evaluate_HelpExample_AdditionAndRangeSum_AreStable()
    {
        var sheet = CreateSheet(
            ('A', 1, 22),
            ('A', 2, 1),
            ('A', 3, 2),
            ('A', 4, 3));

        var expanded = _evaluator.Evaluate("(A1+A2+A3+A4)", sheet);
        var ranged = _evaluator.Evaluate("(A1>A4)", sheet);

        Assert.True(expanded.Success);
        Assert.True(ranged.Success);
        Assert.True(expanded.IsFormula);
        Assert.True(ranged.IsFormula);
        Assert.Equal(28, expanded.Value);
        Assert.Equal(28, ranged.Value);
    }

    [Fact]
    public void Evaluate_HelpExample_ComplexExpression_IsStable()
    {
        var sheet = CreateSheet(
            ('A', 1, 0.5),
            ('A', 2, 0.25),
            ('A', 8, 4),
            ('C', 1, 1),
            ('C', 2, 2),
            ('C', 3, 3),
            ('C', 4, 4),
            ('C', 5, 5));

        const string expression = "(SIN(A1)*COS(A2)/((1.2*A8)+LN(FACT(A8)+8.9E-3))+(C1>C5))";
        var result = _evaluator.Evaluate(expression, sheet);

        var expected =
            (Math.Sin(0.5) * Math.Cos(0.25) / ((1.2 * 4) + Math.Log(Factorial(4) + 8.9E-3))) +
            (1 + 2 + 3 + 4 + 5);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9, $"Expected {expected}, got {result.Value}.");
    }

    [Fact]
    public void Evaluate_HelpExample_RectangularRange_A1ToB5_IsStable()
    {
        var sheet = CreateSheet(
            ('A', 1, 1), ('A', 2, 2), ('A', 3, 3), ('A', 4, 4), ('A', 5, 5),
            ('B', 1, 10), ('B', 2, 20), ('B', 3, 30), ('B', 4, 40), ('B', 5, 50));

        var result = _evaluator.Evaluate("(A1>B5)", sheet);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(result.IsFormula);
        Assert.Equal(165, result.Value);
    }

    [Fact]
    public void Evaluate_CyclicReferences_ReturnError()
    {
        var sheet = new Spreadsheet();
        SetFormulaCell(sheet, 'A', 1, "A2");
        SetFormulaCell(sheet, 'A', 2, "A1");

        var result = _evaluator.Evaluate("A1", sheet);

        Assert.False(result.Success);
        Assert.Contains("Zyklische Referenz", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Evaluate_FormulaCellReference_ResolvesNestedFormula()
    {
        var sheet = new Spreadsheet();
        SetValueCell(sheet, 'A', 1, 10);
        SetFormulaCell(sheet, 'A', 2, "A1+5");

        var result = _evaluator.Evaluate("A2", sheet);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(result.IsFormula);
        Assert.Equal(15, result.Value);
    }

    // ── MIN tests (T006) ──────────────────────────────────────────────────────

    [Theory]
    [MemberData(nameof(MinGoldenCases))]
    public void Evaluate_MinGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        var sheet = CreateSheet(
            ('A', 1, 10), ('A', 2, 20), ('A', 3, 30), ('A', 4, 40), ('A', 5, 50));

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}'.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9,
            $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Fact]
    public void Evaluate_Min_EmptyRange_ReturnsZero()
    {
        var sheet = new Spreadsheet();
        var result = _evaluator.Evaluate("MIN(B1>B5)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Evaluate_Min_RectangularRange_ReturnsMinValue()
    {
        // A1=1,A2=2,B1=3,B2=4 → MIN(A1>B2) = 1
        var sheet = CreateSheet(('A', 1, 1), ('A', 2, 2), ('B', 1, 3), ('B', 2, 4));
        var result = _evaluator.Evaluate("MIN(A1>B2)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(Math.Abs(result.Value - 1.0) < 1e-9);
    }

    [Fact]
    public void Evaluate_Min_InvertedColumnOrder_NormalizedCorrectly()
    {
        // MIN(B2>A1) should normalize to MIN(A1>B2) = 1
        var sheet = CreateSheet(('A', 1, 1), ('A', 2, 2), ('B', 1, 3), ('B', 2, 4));
        var result = _evaluator.Evaluate("MIN(B2>A1)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(Math.Abs(result.Value - 1.0) < 1e-9);
    }

    [Fact]
    public void Evaluate_Min_CyclicReference_ReturnsError()
    {
        // A1 as Constant with Contents "MIN(A1>A5)" — evaluating triggers cyclic-ref guard
        var sheet = new Spreadsheet();
        SetFormulaCell(sheet, 'A', 1, "MIN(A1>A5)");

        var result = _evaluator.Evaluate("A1", sheet);

        Assert.False(result.Success);
        Assert.Contains("Zyklische Referenz", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        Assert.True(result.ErrorPosition >= 1);
    }

    // ── MAX tests (T007) ──────────────────────────────────────────────────────

    [Theory]
    [MemberData(nameof(MaxGoldenCases))]
    public void Evaluate_MaxGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        var sheet = CreateSheet(
            ('A', 1, 10), ('A', 2, 20), ('A', 3, 30), ('A', 4, 40), ('A', 5, 50));

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}'.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9,
            $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Fact]
    public void Evaluate_Max_EmptyRange_ReturnsZero()
    {
        var sheet = new Spreadsheet();
        var result = _evaluator.Evaluate("MAX(B1>B5)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Evaluate_Max_RectangularRange_ReturnsMaxValue()
    {
        // A1=1,A2=2,B1=3,B2=4 → MAX(A1>B2) = 4
        var sheet = CreateSheet(('A', 1, 1), ('A', 2, 2), ('B', 1, 3), ('B', 2, 4));
        var result = _evaluator.Evaluate("MAX(A1>B2)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(Math.Abs(result.Value - 4.0) < 1e-9);
    }

    // ── AVERAGE tests (T008) ──────────────────────────────────────────────────

    [Theory]
    [MemberData(nameof(AverageGoldenCases))]
    public void Evaluate_AverageGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        var sheet = CreateSheet(
            ('A', 1, 10), ('A', 2, 20), ('A', 3, 30), ('A', 4, 40), ('A', 5, 50));

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}'.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9,
            $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Fact]
    public void Evaluate_Average_EmptyRange_ReturnsZero()
    {
        var sheet = new Spreadsheet();
        var result = _evaluator.Evaluate("AVERAGE(B1>B5)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Evaluate_Average_RectangularRange_ReturnsCorrectAverage()
    {
        // A1=1,A2=2,B1=3,B2=4 → AVERAGE(A1>B2) = (1+2+3+4)/4 = 2.5
        var sheet = CreateSheet(('A', 1, 1), ('A', 2, 2), ('B', 1, 3), ('B', 2, 4));
        var result = _evaluator.Evaluate("AVERAGE(A1>B2)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(Math.Abs(result.Value - 2.5) < 1e-9);
    }

    [Fact]
    public void Evaluate_Average_SparseRange_IgnoresEmptyCells()
    {
        // A1=10, A2 empty, A3=20 → AVERAGE(A1>A3) = (10+20)/2 = 15
        var sheet = CreateSheet(('A', 1, 10), ('A', 3, 20));

        var result = _evaluator.Evaluate("AVERAGE(A1>A3)", sheet);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.True(result.IsFormula);
        Assert.True(Math.Abs(result.Value - 15.0) < 1e-9, $"Expected 15.0, got {result.Value}.");
    }

    // ── COUNT tests (T011) ────────────────────────────────────────────────────

    [Theory]
    [MemberData(nameof(CountGoldenCases))]
    public void Evaluate_CountGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        // A1=10 (single numeric for COUNT(A1)=1), A6=5,A7 empty,A8=10,A9 empty,A10=15 (sparse)
        var sheet = CreateSheet(
            ('A', 1, 10),
            ('A', 6, 5), ('A', 8, 10), ('A', 10, 15));

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}'.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9,
            $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Fact]
    public void Evaluate_Count_EmptyRange_ReturnsZero()
    {
        var sheet = new Spreadsheet();
        var result = _evaluator.Evaluate("COUNT(B1>B5)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Evaluate_Count_SingleEmptyCell_ReturnsZero()
    {
        var sheet = new Spreadsheet();
        var result = _evaluator.Evaluate("COUNT(C1)", sheet);
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(0, result.Value);
    }

    [Fact]
    public void Evaluate_Count_AllTextRange_ReturnsZero()
    {
        // Text cells are excluded from COUNT
        var sheet = new Spreadsheet();
        SetTextCell(sheet, 'A', 1, "hello");
        SetTextCell(sheet, 'A', 2, "world");

        var result = _evaluator.Evaluate("COUNT(A1>A2)", sheet);

        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(0, result.Value);
    }

    // ── ROUND tests (T014) ────────────────────────────────────────────────────

    [Theory]
    [MemberData(nameof(RoundGoldenCases))]
    public void Evaluate_RoundGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        var sheet = CreateSheet(
            ('A', 1, 10), ('A', 2, 20), ('A', 3, 30), ('A', 4, 40), ('A', 5, 50));

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}'.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9,
            $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Fact]
    public void Evaluate_Round_NegativeDecimals_ReturnsError()
    {
        var sheet = new Spreadsheet();

        var result = _evaluator.Evaluate("ROUND(3.14,-1)", sheet);

        Assert.False(result.Success);
        Assert.Contains("Negative Nachkommastellen", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        Assert.True(result.ErrorPosition >= 1);
    }

    // ── IF tests (T017) ───────────────────────────────────────────────────────

    [Theory]
    [MemberData(nameof(IfGoldenCases))]
    public void Evaluate_IfGoldenCases_ReturnExpectedValues(string expression, double expected, bool expectedIsFormula)
    {
        // A1=150, A2=20, A3=10, A4=40, A5=50, B1..B5=10,20,30,40,50, A15=150
        var sheet = CreateSheet(
            ('A', 1, 150), ('A', 2, 20), ('A', 3, 10), ('A', 4, 40), ('A', 5, 50),
            ('B', 1, 10), ('B', 2, 20), ('B', 3, 30), ('B', 4, 40), ('B', 5, 50),
            ('A', 15, 150));

        var result = _evaluator.Evaluate(expression, sheet);

        Assert.True(result.Success, $"Expected success for '{expression}', got '{result.ErrorMessage}'.");
        Assert.Equal(expectedIsFormula, result.IsFormula);
        Assert.True(Math.Abs(result.Value - expected) < 1e-9,
            $"Expected {expected} for '{expression}', got {result.Value}.");
    }

    [Fact]
    public void Evaluate_If_NoRelationalOperator_ReturnsError()
    {
        // IF(A1,1,0) — A1=5, parser reaches condition with no relop → error
        var sheet = CreateSheet(('A', 1, 5));

        var result = _evaluator.Evaluate("IF(A1,1,0)", sheet);

        Assert.False(result.Success);
        Assert.Contains("Vergleichsoperator", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        Assert.True(result.ErrorPosition >= 1);
    }

    [Fact]
    public void Evaluate_If_FewerThanThreeArgs_ReturnsError()
    {
        // IF(A1>0,1) — missing false branch → error
        var sheet = CreateSheet(('A', 1, 5));

        var result = _evaluator.Evaluate("IF(A1>0,1)", sheet);

        Assert.False(result.Success);
        Assert.Contains("3 Argumente", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        Assert.True(result.ErrorPosition >= 1);
    }

    [Fact]
    public void Evaluate_If_RangeSumCondition_GreaterIsConsumedAsRangeOp()
    {
        // IF(A1>B5,1,0) — the '>' followed by valid column B and digit 5 is consumed as range sum.
        // A1>B5 evaluates to SumRange(A1..B5), leaving no relational operator → syntax error.
        // This verifies the IsRangeOperatorStart disambiguation is active inside IF conditions.
        var sheet = CreateSheet(
            ('A', 1, 150), ('A', 2, 20), ('A', 3, 10), ('A', 4, 40), ('A', 5, 50),
            ('B', 1, 10), ('B', 2, 20), ('B', 3, 30), ('B', 4, 40), ('B', 5, 50));

        var result = _evaluator.Evaluate("IF(A1>B5,1,0)", sheet);

        Assert.False(result.Success);
        Assert.Contains("Vergleichsoperator", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
        Assert.True(result.ErrorPosition >= 1);
    }

    private static Spreadsheet CreateSheet(params (char Column, int Row, double Value)[] items)
    {
        var sheet = new Spreadsheet();
        foreach (var item in items)
        {
            SetValueCell(sheet, item.Column, item.Row, item.Value);
        }

        return sheet;
    }

    private static void SetValueCell(Spreadsheet sheet, char column, int row, double value)
    {
        var cell = sheet.GetCell(column, row);
        cell.Status = CellStatusFlags.Constant;
        cell.Contents = string.Empty;
        cell.Value = value;
    }

    private static void SetFormulaCell(Spreadsheet sheet, char column, int row, string formula)
    {
        var cell = sheet.GetCell(column, row);
        cell.Status = CellStatusFlags.Constant | CellStatusFlags.Formula;
        cell.Contents = formula;
    }

    private static void SetTextCell(Spreadsheet sheet, char column, int row, string text)
    {
        var cell = sheet.GetCell(column, row);
        cell.Status = CellStatusFlags.Text;
        cell.Contents = text;
    }

    private static double Factorial(int n)
    {
        double value = 1;
        for (var i = 2; i <= n; i++)
        {
            value *= i;
        }

        return value;
    }
}
