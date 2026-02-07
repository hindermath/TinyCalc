namespace MicroCalc.Core.Model;

public sealed class Cell
{
    public CellStatusFlags Status { get; set; } = CellStatusFlags.Text;

    public string Contents { get; set; } = string.Empty;

    public double Value { get; set; }

    public int Decimals { get; set; } = SpreadsheetSpec.DefaultDecimals;

    public int FieldWidth { get; set; } = SpreadsheetSpec.DefaultFieldWidth;

    public Cell Clone()
    {
        return new Cell
        {
            Status = Status,
            Contents = Contents,
            Value = Value,
            Decimals = Decimals,
            FieldWidth = FieldWidth,
        };
    }
}
