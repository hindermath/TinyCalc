namespace MicroCalc.Core.Model;

public sealed class Spreadsheet
{
    private readonly Cell[,] _cells;

    public Spreadsheet()
    {
        _cells = new Cell[SpreadsheetSpec.ColumnCount, SpreadsheetSpec.RowCount];
        Reset();
    }

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

    public Cell GetCell(CellAddress address)
    {
        return _cells[SpreadsheetSpec.ColumnToIndex(address.Column), address.Row - 1];
    }

    public Cell GetCell(char column, int row)
    {
        return GetCell(new CellAddress(column, row));
    }

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
