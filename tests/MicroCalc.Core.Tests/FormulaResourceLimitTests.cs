using MicroCalc.ContractEvidence;
using MicroCalc.Core.Engine;
using MicroCalc.Core.Formula;
using MicroCalc.Core.IO;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Tests;

public sealed class FormulaResourceLimitTests
{
    [Fact]
    public void Evaluate_RepeatedReferenceDag_UsesBoundedAllocations()
    {
        var sheet = new Spreadsheet();
        SetFormulaCell(sheet, new CellAddress('A', 1), "1");
        for (var row = 2; row <= 20; row++)
        {
            SetFormulaCell(sheet, new CellAddress('A', row), $"A{row - 1}+A{row - 1}");
        }

        var evaluator = new FormulaEvaluator();
        Assert.True(evaluator.Evaluate("1", sheet).Success);
        var allocatedBefore = GC.GetAllocatedBytesForCurrentThread();

        var result = evaluator.Evaluate("A20", sheet);

        var allocatedBytes = GC.GetAllocatedBytesForCurrentThread() - allocatedBefore;
        Assert.True(result.Success, result.ErrorMessage);
        Assert.Equal(Math.Pow(2, 19), result.Value);
        Assert.True(allocatedBytes < 2_000_000,
            $"Repeated-reference evaluation allocated {allocatedBytes} bytes instead of remaining bounded.");
    }

    [Fact]
    public void Evaluate_ExcessiveRangeVisits_StopAtWorkBudget()
    {
        var evaluator = new FormulaEvaluator();
        var expression = string.Join('+', Enumerable.Repeat("(A1>G21)", 2500));

        var result = evaluator.Evaluate(expression, new Spreadsheet());

        Assert.False(result.Success);
        Assert.Contains("Berechnungsbudget", result.ErrorMessage, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void LoadedRepeatedReferenceDag_RecalculatesWithExactResult()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "repeated-reference.json");
        var source = new MicroCalcEngine();
        SetFormulaCell(source.Sheet, new CellAddress('A', 1), "1");
        for (var row = 2; row <= 20; row++)
        {
            SetFormulaCell(source.Sheet, new CellAddress('A', row), $"A{row - 1}+A{row - 1}");
        }
        SpreadsheetJsonStorage.Save(path, source);
        var loaded = new MicroCalcEngine();
        SpreadsheetJsonStorage.Load(path, loaded);

        var result = loaded.Recalculate();

        Assert.True(result.Success, string.Join("; ", result.Errors));
        Assert.Equal(Math.Pow(2, 19), loaded.Sheet.GetCell('A', 20).Value);
    }

    [Fact]
    public void Recalculate_NonConstantFormulaDependency_DoesNotHideItsSelfCycle()
    {
        var engine = new MicroCalcEngine();
        SetFormulaCell(engine.Sheet, new CellAddress('A', 1), "B1");
        var unusualFormula = engine.Sheet.GetCell('B', 1);
        unusualFormula.Contents = "B1";
        unusualFormula.Value = 7;
        unusualFormula.Status = CellStatusFlags.Formula;

        var result = engine.Recalculate();

        Assert.False(result.Success);
        Assert.Contains(result.Errors,
            error => error.StartsWith("B1:", StringComparison.Ordinal) &&
                     error.Contains("Zyklische Referenz", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public void Recalculate_NonConstantFormulaDependency_IsStillEvaluatedAtItsOwnRoot()
    {
        var engine = new MicroCalcEngine();
        SetFormulaCell(engine.Sheet, new CellAddress('A', 1), "B1");
        var unusualFormula = engine.Sheet.GetCell('B', 1);
        unusualFormula.Contents = "2+2";
        unusualFormula.Value = 7;
        unusualFormula.Status = CellStatusFlags.Formula;

        var result = engine.Recalculate();

        Assert.True(result.Success, string.Join("; ", result.Errors));
        Assert.Equal(4, unusualFormula.Value);
    }

    private static void SetFormulaCell(Spreadsheet sheet, CellAddress address, string contents)
    {
        var cell = sheet.GetCell(address);
        cell.Contents = contents;
        cell.Status = CellStatusFlags.Constant | CellStatusFlags.Formula;
    }
}
