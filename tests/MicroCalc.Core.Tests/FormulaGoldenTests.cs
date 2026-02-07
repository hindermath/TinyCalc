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
