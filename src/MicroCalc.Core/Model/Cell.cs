namespace MicroCalc.Core.Model;

/// <summary>
/// DE: Repräsentiert den Zustand und Inhalt einer einzelnen Zelle.
/// EN: Represents state and content of a single cell.
/// </summary>
public sealed class Cell
{
    /// <summary>
    /// DE: Bitmaske fuer Typ- und Anzeigezustand der Zelle.
    /// EN: Bit mask for cell type and rendering state.
    /// </summary>
    public CellStatusFlags Status { get; set; } = CellStatusFlags.Text;

    /// <summary>
    /// DE: Rohinhalt, wie er gespeichert wurde (Text oder Ausdruck).
    /// EN: Raw stored content (text or expression).
    /// </summary>
    public string Contents { get; set; } = string.Empty;

    /// <summary>
    /// DE: Numerischer Wert fuer konstante oder berechnete Zellen.
    /// EN: Numeric value for constant or calculated cells.
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// DE: Anzeigeformat fuer Nachkommastellen.
    /// EN: Display format for decimal places.
    /// </summary>
    public int Decimals { get; set; } = SpreadsheetSpec.DefaultDecimals;

    /// <summary>
    /// DE: Sichtbare Feldbreite der Zelle.
    /// EN: Visible field width of the cell.
    /// </summary>
    public int FieldWidth { get; set; } = SpreadsheetSpec.DefaultFieldWidth;

    /// <summary>
    /// DE: Erstellt eine tiefe Kopie der aktuellen Zelle.
    /// EN: Creates a deep copy of the current cell.
    /// </summary>
    /// <returns>
    /// DE: Neue Zelle mit identischen Werten.
    /// EN: New cell with identical values.
    /// </returns>
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
