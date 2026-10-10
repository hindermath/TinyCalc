using MicroCalc.Core.Engine;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Tests;

public sealed class CellContractTests
{
    [Theory]
    [InlineData("", 0, CellStatusFlags.Text, "Text")]
    [InlineData("hello", 0, CellStatusFlags.Text, "Text")]
    [InlineData("12", 12, CellStatusFlags.Constant, "Numeric")]
    [InlineData("A2+3", 3, CellStatusFlags.Constant | CellStatusFlags.Formula | CellStatusFlags.Calculated, "Formula")]
    [Trait("Contract", "Cell")]
    public void CellTypes_HaveIndependentValuesFlagsAndStatus(string text, double expected, CellStatusFlags flags, string type)
    {
        var engine = new MicroCalcEngine();
        var result = engine.EditCell(new CellAddress('A', 1), text);
        Assert.True(result.Success, result.Message);
        var cell = engine.Sheet.GetCell('A', 1);
        Assert.Equal(text, cell.Contents);
        Assert.Equal(expected, cell.Value);
        Assert.Equal(flags, cell.Status);
        Assert.Equal(type, engine.GetCellTypeText(new CellAddress('A', 1)));
    }

    [Theory]
    [InlineData(-1, 1, "1.250000E+001", false)]
    [InlineData(0, 10, "12", false)]
    [InlineData(11, 20, "12.50000000000", true)]
    [Trait("Contract", "Cell")]
    public void FormattingBounds_PreserveValueAndSkipLockedNeighbor(int decimals, int width, string display, bool locked)
    {
        var engine = new MicroCalcEngine();
        Assert.True(engine.EditCell(new CellAddress('A', 1), "12.5").Success);
        engine.FormatRange('A', 1, 1, decimals, width);
        var cell = engine.Sheet.GetCell('A', 1);
        Assert.Equal(decimals, cell.Decimals);
        Assert.Equal(width, cell.FieldWidth);
        Assert.Equal(12.5, cell.Value);
        Assert.Equal(display, SpreadsheetSpec.FormatNumber(cell));
        Assert.Equal(locked, engine.Sheet.GetCell('B', 1).Status.HasFlag(CellStatusFlags.Locked));
        Assert.Equal(new CellAddress(locked ? 'C' : 'B', 1), engine.Move(new CellAddress('A', 1), Direction.Right));
    }

    [Fact]
    [Trait("Contract", "Cell")]
    public void TextInputLimit_IsSeventyAndInvalidFormulaPreservesPriorCell()
    {
        var engine = new MicroCalcEngine();
        var address = new CellAddress('A', 1);
        Assert.True(engine.EditCell(address, new string('z', 71)).Success);
        Assert.Equal(new string('z', 70), engine.Sheet.GetCell(address).Contents);
        Assert.True(engine.EditCell(address, "7").Success);
        var result = engine.EditCell(address, "1+");
        Assert.False(result.Success);
        Assert.NotEmpty(result.Message);
        Assert.Equal("7", engine.Sheet.GetCell(address).Contents);
        Assert.Equal(7, engine.Sheet.GetCell(address).Value);
    }

    [Fact]
    [Trait("Contract", "Cell")]
    public void InvalidEdit_PreservesOverflowFlagsAsWellAsContents()
    {
        var engine = new MicroCalcEngine();
        var address = new CellAddress('A', 1);
        Assert.True(engine.EditCell(address, new string('z', 70)).Success);
        var before = engine.Sheet.GetCell('B', 1).Status;
        Assert.True(before.HasFlag(CellStatusFlags.OverWritten));
        Assert.False(engine.EditCell(address, "1+").Success);
        Assert.Equal(before, engine.Sheet.GetCell('B', 1).Status);
    }

    [Theory]
    [InlineData("MIN(1)", 1)]
    [InlineData("MAX(1)", 1)]
    [InlineData("AVERAGE(1)", 1)]
    [InlineData("COUNT(1)", 1)]
    [InlineData("IF(1=1,2,3)", 2)]
    [InlineData("ROUND(2.5,0)", 3)]
    [Trait("Contract", "Cell")]
    public void NamedExtendedFunctions_AreNotSilentlyStoredAsText(string expression, double expected)
    {
        var engine = new MicroCalcEngine();
        Assert.True(engine.EditCell(new CellAddress('A', 1), expression).Success);
        Assert.Equal(expected, engine.Sheet.GetCell('A', 1).Value);
        Assert.True(engine.Sheet.GetCell('A', 1).Status.HasFlag(CellStatusFlags.Constant));
    }

    [Theory]
    [InlineData("SQRT(-1)")]
    [InlineData("FACT(0.5)")]
    [InlineData("ROUND(1,16)")]
    [Trait("Contract", "Cell")]
    public void InvalidNamedFunction_IsAnErrorNotText(string expression)
    {
        var engine = new MicroCalcEngine();
        var result = engine.EditCell(new CellAddress('A', 1), expression);
        Assert.False(result.Success);
        Assert.NotEmpty(result.Message);
        Assert.Equal(string.Empty, engine.Sheet.GetCell('A', 1).Contents);
    }
}
