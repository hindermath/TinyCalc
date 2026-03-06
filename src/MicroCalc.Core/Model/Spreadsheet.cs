namespace MicroCalc.Core.Model;

/// <summary>
/// DE: Reines Datenmodell fuer das feste MicroCalc-Grid.
/// EN: Pure data model for the fixed MicroCalc grid.
/// </summary>
public sealed class Spreadsheet
{
    private readonly Cell[,] _cells;

    /// <summary>
    /// DE: Erstellt ein neues Blatt und initialisiert alle Zellen.
    /// EN: Creates a new sheet and initializes all cells.
    /// </summary>
    public Spreadsheet()
    {
        _cells = new Cell[SpreadsheetSpec.ColumnCount, SpreadsheetSpec.RowCount];
        Reset();
    }

    /// <summary>
    /// DE: Setzt alle Zellen auf Standardwerte zurueck.
    /// EN: Resets all cells to default values.
    /// </summary>
    public void Reset()
    {
        for (var row = 1; row <= SpreadsheetSpec.RowCount; row++)
        {
            for (var column = SpreadsheetSpec.MinColumn; column <= SpreadsheetSpec.MaxColumn; column++)
            {
                var address = new CellAddress(column, row);
                _cells[SpreadsheetSpec.ColumnToIndex(column), row - 1] = new Cell();
            }
        }
    }

    /// <summary>
    /// DE: Liefert die Zelle an einer gegebenen Adresse.
    /// EN: Returns the cell at a given address.
    /// </summary>
    /// <param name="address">
    /// DE: Zelladresse im gueltigen Bereich.
    /// EN: Cell address within valid bounds.
    /// </param>
    /// <returns>
    /// DE: Referenz auf die gespeicherte Zelle.
    /// EN: Reference to the stored cell.
    /// </returns>
    public Cell GetCell(CellAddress address)
    {
        return _cells[SpreadsheetSpec.ColumnToIndex(address.Column), address.Row - 1];
    }

    /// <summary>
    /// DE: Liefert die Zelle ueber Spalte und Zeile.
    /// EN: Returns the cell by column and row.
    /// </summary>
    /// <param name="column">
    /// DE: Spalte A-G.
    /// EN: Column A-G.
    /// </param>
    /// <param name="row">
    /// DE: Zeile 1-21.
    /// EN: Row 1-21.
    /// </param>
    /// <returns>
    /// DE: Referenz auf die gespeicherte Zelle.
    /// EN: Reference to the stored cell.
    /// </returns>
    public Cell GetCell(char column, int row)
    {
        return GetCell(new CellAddress(column, row));
    }

    /// <summary>
    /// DE: Iteriert alle Zelladressen zeilenweise von oben nach unten.
    /// EN: Iterates all addresses row by row from top to bottom.
    /// </summary>
    /// <returns>
    /// DE: Sequenz aller Adressen im Grid.
    /// EN: Sequence of all addresses in the grid.
    /// </returns>
    public IEnumerable<CellAddress> AddressesRowMajor()
    {
        for (var row = 1; row <= SpreadsheetSpec.RowCount; row++)
        {
            for (var column = SpreadsheetSpec.MinColumn; column <= SpreadsheetSpec.MaxColumn; column++)
            {
                yield return new CellAddress(column, row);
            }
        }
    }
}
