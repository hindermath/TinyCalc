using MicroCalc.Core.Engine;
using MicroCalc.Core.IO;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Tests;

public sealed class MicroCalcEngineTests
{
    [Fact]
    public void EditCell_EvaluatesArithmeticExpression()
    {
        var engine = new MicroCalcEngine();

        var result = engine.EditCell(new CellAddress('A', 1), "2+3*4");

        Assert.True(result.Success);
        Assert.Equal(14, engine.Sheet.GetCell('A', 1).Value);
        Assert.True(engine.Sheet.GetCell('A', 1).Status.HasFlag(CellStatusFlags.Constant));
    }

    [Fact]
    public void EditCell_SupportsRangeSumFormula()
    {
        var engine = new MicroCalcEngine();
        engine.EditCell(new CellAddress('A', 1), "1");
        engine.EditCell(new CellAddress('A', 2), "2");
        engine.EditCell(new CellAddress('A', 3), "3");

        var result = engine.EditCell(new CellAddress('A', 4), "(A1>A3)");

        Assert.True(result.Success);
        var cell = engine.Sheet.GetCell('A', 4);
        Assert.Equal(6, cell.Value);
        Assert.True(cell.Status.HasFlag(CellStatusFlags.Formula));
    }

    [Fact]
    public void Recalculate_UpdatesFormulaAfterDependencyChanged()
    {
        var engine = new MicroCalcEngine();
        engine.EditCell(new CellAddress('A', 1), "10");
        engine.EditCell(new CellAddress('A', 2), "A1+5");

        engine.EditCell(new CellAddress('A', 1), "20");
        var recalc = engine.Recalculate();

        Assert.True(recalc.Success);
        Assert.Equal(25, engine.Sheet.GetCell('A', 2).Value);
    }

    [Fact]
    public void Evaluator_SupportsFunctions()
    {
        var engine = new MicroCalcEngine();

        var result = engine.EditCell(new CellAddress('B', 1), "FACT(5)");

        Assert.True(result.Success);
        Assert.Equal(120, engine.Sheet.GetCell('B', 1).Value);
    }

    // T017a — IF integration test: result tracks cell changes on every Recalculate
    [Fact]
    public void If_ResultTracksRecalculate_WhenDependentCellChanges()
    {
        var engine = new MicroCalcEngine();
        engine.EditCell(new CellAddress('A', 1), "150");
        var editResult = engine.EditCell(new CellAddress('B', 1), "IF(A1>100, 1, 0)");
        Assert.True(editResult.Success, editResult.Message);
        Assert.Equal(1, engine.Sheet.GetCell('B', 1).Value);

        engine.EditCell(new CellAddress('A', 1), "50");
        var recalc = engine.Recalculate();

        Assert.True(recalc.Success, string.Join("; ", recalc.Errors));
        Assert.Equal(0, engine.Sheet.GetCell('B', 1).Value);
    }

    [Fact]
    public void FormatRange_LocksNextColumnWhenWidthGreaterThanTen()
    {
        var engine = new MicroCalcEngine();

        engine.FormatRange('A', 1, 1, 2, 15);

        Assert.True(engine.Sheet.GetCell('B', 1).Status.HasFlag(CellStatusFlags.Locked));
    }

    [Fact]
    public void JsonStorage_RoundtripPreservesState()
    {
        var engine = new MicroCalcEngine();
        engine.EditCell(new CellAddress('A', 1), "42");
        engine.EditCell(new CellAddress('C', 2), "Hello");
        engine.ToggleAutoCalc();

        var path = Path.Combine(Path.GetTempPath(), $"microcalc-{Guid.NewGuid():N}.json");
        try
        {
            SpreadsheetJsonStorage.Save(path, engine);

            var loaded = new MicroCalcEngine();
            SpreadsheetJsonStorage.Load(path, loaded);

            Assert.False(loaded.AutoCalc);
            Assert.Equal(42, loaded.Sheet.GetCell('A', 1).Value);
            Assert.Equal("Hello", loaded.Sheet.GetCell('C', 2).Contents);
        }
        finally
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
