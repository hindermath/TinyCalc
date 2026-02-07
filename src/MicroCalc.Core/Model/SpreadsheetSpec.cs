using System.Globalization;

namespace MicroCalc.Core.Model;

public static class SpreadsheetSpec
{
    public const char MinColumn = 'A';
    public const char MaxColumn = 'G';
    public const int RowCount = 21;
    public const int ColumnCount = MaxColumn - MinColumn + 1;
    public const int DefaultDecimals = 2;
    public const int DefaultFieldWidth = 10;
    public const int CellInputLimit = 70;

    public static IEnumerable<char> Columns()
    {
        for (var column = MinColumn; column <= MaxColumn; column++)
        {
            yield return column;
        }
    }

    public static bool IsColumnInRange(char column)
    {
        var normalized = char.ToUpperInvariant(column);
        return normalized is >= MinColumn and <= MaxColumn;
    }

    public static bool IsRowInRange(int row)
    {
        return row is >= 1 and <= RowCount;
    }

    public static int ColumnToIndex(char column)
    {
        var normalized = char.ToUpperInvariant(column);
        if (!IsColumnInRange(normalized))
        {
            throw new ArgumentOutOfRangeException(nameof(column));
        }

        return normalized - MinColumn;
    }

    public static char IndexToColumn(int index)
    {
        if (index < 0 || index >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (char)(MinColumn + index);
    }

    public static string FormatNumber(Cell cell)
    {
        var culture = CultureInfo.InvariantCulture;
        if (cell.Decimals >= 0)
        {
            return cell.Value.ToString($"F{cell.Decimals}", culture);
        }

        return cell.Value.ToString("E6", culture);
    }
}
