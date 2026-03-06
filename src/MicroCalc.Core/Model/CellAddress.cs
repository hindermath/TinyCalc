namespace MicroCalc.Core.Model;

/// <summary>
/// DE: Unveraenderliche Adresse einer Zelle (Spalte + Zeile).
/// EN: Immutable address of one cell (column + row).
/// </summary>
public readonly record struct CellAddress
{
    /// <summary>
    /// DE: Erstellt eine validierte Zelladresse.
    /// EN: Creates a validated cell address.
    /// </summary>
    /// <param name="column">
    /// DE: Spalte im Bereich A-G.
    /// EN: Column in range A-G.
    /// </param>
    /// <param name="row">
    /// DE: Zeile im Bereich 1-21.
    /// EN: Row in range 1-21.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// DE: Wenn Spalte oder Zeile ausserhalb des gueltigen Bereichs liegt.
    /// EN: Thrown when column or row is outside valid bounds.
    /// </exception>
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

    /// <summary>
    /// DE: Spaltenbuchstabe der Adresse.
    /// EN: Column letter of the address.
    /// </summary>
    public char Column { get; }

    /// <summary>
    /// DE: Zeilennummer der Adresse.
    /// EN: Row number of the address.
    /// </summary>
    public int Row { get; }

    /// <summary>
    /// DE: Formatiert die Adresse als Text, z. B. A1.
    /// EN: Formats the address as text, e.g., A1.
    /// </summary>
    /// <returns>
    /// DE: Textdarstellung der Adresse.
    /// EN: Text representation of the address.
    /// </returns>
    public override string ToString() => $"{Column}{Row}";

    /// <summary>
    /// DE: Parst eine Zelladresse aus Text.
    /// EN: Parses a cell address from text.
    /// </summary>
    /// <param name="text">
    /// DE: Eingabetext wie A1.
    /// EN: Input text like A1.
    /// </param>
    /// <param name="address">
    /// DE: Ergebnisadresse bei Erfolg, sonst Standardwert.
    /// EN: Parsed address on success; default value otherwise.
    /// </param>
    /// <returns>
    /// DE: True bei erfolgreichem Parse.
    /// EN: True if parsing succeeds.
    /// </returns>
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
