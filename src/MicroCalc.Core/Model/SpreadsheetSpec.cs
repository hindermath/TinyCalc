using System.Globalization;

namespace MicroCalc.Core.Model;

/// <summary>
/// DE: Zentrale Konstanten und Hilfsfunktionen fuer das feste MicroCalc-Grid.
/// EN: Central constants and helper functions for the fixed MicroCalc grid.
/// </summary>
public static class SpreadsheetSpec
{
    /// <summary>
    /// DE: Erste gueltige Spalte.
    /// EN: First valid column.
    /// </summary>
    public const char MinColumn = 'A';
    /// <summary>
    /// DE: Letzte gueltige Spalte.
    /// EN: Last valid column.
    /// </summary>
    public const char MaxColumn = 'G';
    /// <summary>
    /// DE: Anzahl der Zeilen.
    /// EN: Number of rows.
    /// </summary>
    public const int RowCount = 21;
    /// <summary>
    /// DE: Anzahl der Spalten.
    /// EN: Number of columns.
    /// </summary>
    public const int ColumnCount = MaxColumn - MinColumn + 1;
    /// <summary>
    /// DE: Standardanzahl von Nachkommastellen.
    /// EN: Default number of decimal places.
    /// </summary>
    public const int DefaultDecimals = 2;
    /// <summary>
    /// DE: Standardbreite einer Zelle in Zeichen.
    /// EN: Default width of one cell in characters.
    /// </summary>
    public const int DefaultFieldWidth = 10;
    /// <summary>
    /// DE: Maximale Laenge eines Zellinputs.
    /// EN: Maximum length of one cell input.
    /// </summary>
    public const int CellInputLimit = 70;

    /// <summary>
    /// DE: Liefert alle gueltigen Spalten A-G.
    /// EN: Returns all valid columns A-G.
    /// </summary>
    /// <returns>
    /// DE: Sequenz der gueltigen Spalten.
    /// EN: Sequence of valid columns.
    /// </returns>
    public static IEnumerable<char> Columns()
    {
        for (var column = MinColumn; column <= MaxColumn; column++)
        {
            yield return column;
        }
    }

    /// <summary>
    /// DE: Prueft, ob eine Spalte innerhalb des gueltigen Bereichs liegt.
    /// EN: Checks whether a column is inside valid bounds.
    /// </summary>
    /// <param name="column">
    /// DE: Zu pruefender Spaltenwert.
    /// EN: Column value to check.
    /// </param>
    /// <returns>
    /// DE: True bei gueltiger Spalte.
    /// EN: True for a valid column.
    /// </returns>
    public static bool IsColumnInRange(char column)
    {
        var normalized = char.ToUpperInvariant(column);
        return normalized is >= MinColumn and <= MaxColumn;
    }

    /// <summary>
    /// DE: Prueft, ob eine Zeile innerhalb des gueltigen Bereichs liegt.
    /// EN: Checks whether a row is inside valid bounds.
    /// </summary>
    /// <param name="row">
    /// DE: Zu pruefende Zeilennummer.
    /// EN: Row number to check.
    /// </param>
    /// <returns>
    /// DE: True bei gueltiger Zeile.
    /// EN: True for a valid row.
    /// </returns>
    public static bool IsRowInRange(int row)
    {
        return row is >= 1 and <= RowCount;
    }

    /// <summary>
    /// DE: Wandelt eine Spalte A-G in einen Null-basierten Index um.
    /// EN: Converts a column A-G into a zero-based index.
    /// </summary>
    /// <param name="column">
    /// DE: Spaltenbuchstabe.
    /// EN: Column letter.
    /// </param>
    /// <returns>
    /// DE: Null-basierter Spaltenindex.
    /// EN: Zero-based column index.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// DE: Wenn die Spalte ausserhalb von A-G liegt.
    /// EN: Thrown when the column is outside A-G.
    /// </exception>
    public static int ColumnToIndex(char column)
    {
        var normalized = char.ToUpperInvariant(column);
        if (!IsColumnInRange(normalized))
        {
            throw new ArgumentOutOfRangeException(nameof(column));
        }

        return normalized - MinColumn;
    }

    /// <summary>
    /// DE: Wandelt einen Null-basierten Index in eine Spalte A-G um.
    /// EN: Converts a zero-based index into a column A-G.
    /// </summary>
    /// <param name="index">
    /// DE: Null-basierter Spaltenindex.
    /// EN: Zero-based column index.
    /// </param>
    /// <returns>
    /// DE: Spaltenbuchstabe.
    /// EN: Column letter.
    /// </returns>
    /// <exception cref="ArgumentOutOfRangeException">
    /// DE: Wenn der Index ausserhalb des gueltigen Bereichs liegt.
    /// EN: Thrown when the index is outside valid bounds.
    /// </exception>
    public static char IndexToColumn(int index)
    {
        if (index < 0 || index >= ColumnCount)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        return (char)(MinColumn + index);
    }

    /// <summary>
    /// DE: Formatiert den numerischen Zellwert gemaess Dezimal-Einstellung.
    /// EN: Formats the numeric cell value according to decimal settings.
    /// </summary>
    /// <param name="cell">
    /// DE: Zu formatierende Zelle.
    /// EN: Cell to format.
    /// </param>
    /// <returns>
    /// DE: Formatierter Zahlenwert als Text.
    /// EN: Formatted numeric value as text.
    /// </returns>
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
