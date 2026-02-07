namespace MicroCalc.Core.Model;

public readonly record struct CellAddress
{
    public CellAddress(char column, int row)
    {
        Column = char.ToUpperInvariant(column);
        Row = row;

        if (!SpreadsheetSpec.IsColumnInRange(Column))
        {
            throw new ArgumentOutOfRangeException(nameof(column));
        }

        if (!SpreadsheetSpec.IsRowInRange(Row))
        {
            throw new ArgumentOutOfRangeException(nameof(row));
        }
    }

    public char Column { get; }

    public int Row { get; }

    public override string ToString() => $"{Column}{Row}";

    public static bool TryParse(string text, out CellAddress address)
    {
        address = default;
        if (string.IsNullOrWhiteSpace(text))
        {
            return false;
        }

        var normalized = text.Trim().ToUpperInvariant();
        if (normalized.Length < 2)
        {
            return false;
        }

        var column = normalized[0];
        if (!SpreadsheetSpec.IsColumnInRange(column))
        {
            return false;
        }

        if (!int.TryParse(normalized[1..], out var row))
        {
            return false;
        }

        if (!SpreadsheetSpec.IsRowInRange(row))
        {
            return false;
        }

        address = new CellAddress(column, row);
        return true;
    }
}
