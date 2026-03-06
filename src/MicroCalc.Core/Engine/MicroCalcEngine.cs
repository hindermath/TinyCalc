using System.Globalization;
using MicroCalc.Core.Formula;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Engine;

/// <summary>
/// DE: Zentrale Fassade fuer alle Spreadsheet-Operationen in MicroCalc.
/// EN: Central facade for all spreadsheet operations in MicroCalc.
/// </summary>
public sealed class MicroCalcEngine
{
    private readonly FormulaEvaluator _evaluator = new();

    /// <summary>
    /// DE: Das aktuell geladene Arbeitsblatt.
    /// EN: The currently loaded worksheet.
    /// </summary>
    public Spreadsheet Sheet { get; } = new();

    /// <summary>
    /// DE: Steuert, ob nach jeder Eingabe automatisch neu berechnet wird.
    /// EN: Controls whether recalculation runs automatically after each edit.
    /// </summary>
    public bool AutoCalc { get; private set; } = true;

    /// <summary>
    /// DE: Aktuelle Cursor-Position im Grid.
    /// EN: Current cursor position in the grid.
    /// </summary>
    public CellAddress CurrentCell { get; set; } = new('A', 1);

    /// <summary>
    /// DE: Setzt das Blatt auf den Ausgangszustand zurueck.
    /// EN: Resets the worksheet to its initial state.
    /// </summary>
    public void Clear()
    {
        Sheet.Reset();
        CurrentCell = new CellAddress('A', 1);
        AutoCalc = true;
    }

    /// <summary>
    /// DE: Aktiviert oder deaktiviert die automatische Neuberechnung.
    /// EN: Enables or disables automatic recalculation.
    /// </summary>
    /// <param name="value">
    /// DE: Gewuenschter AutoCalc-Status.
    /// EN: Desired AutoCalc state.
    /// </param>
    public void SetAutoCalc(bool value)
    {
        AutoCalc = value;
    }

    /// <summary>
    /// DE: Schaltet den AutoCalc-Status um.
    /// EN: Toggles the AutoCalc state.
    /// </summary>
    public void ToggleAutoCalc()
    {
        AutoCalc = !AutoCalc;
    }

    /// <summary>
    /// DE: Schreibt einen Zellinhalt und bewertet ihn als Text, Zahl oder Formel.
    /// EN: Writes cell content and evaluates it as text, numeric value, or formula.
    /// </summary>
    /// <param name="address">
    /// DE: Zieladresse der zu bearbeitenden Zelle.
    /// EN: Target address of the cell to edit.
    /// </param>
    /// <param name="input">
    /// DE: Benutzereingabe fuer die Zelle.
    /// EN: User input for the cell.
    /// </param>
    /// <returns>
    /// DE: Ergebnis mit Erfolg, Meldung und optionaler Fehlerposition.
    /// EN: Result with success flag, message, and optional error position.
    /// </returns>
    public EditResult EditCell(CellAddress address, string input)
    {
        var value = (input ?? string.Empty).TrimEnd();
        if (value.Length > SpreadsheetSpec.CellInputLimit)
        {
            value = value[..SpreadsheetSpec.CellInputLimit];
        }

        var cell = Sheet.GetCell(address);
        ClearOverwrittenTrail(address);

        if (string.IsNullOrEmpty(value))
        {
            cell.Status = CellStatusFlags.Text;
            cell.Contents = string.Empty;
            cell.Value = 0;
            return new EditResult(true, "Zelle geleert.");
        }

        if (ShouldEvaluateAsExpression(value))
        {
            var eval = _evaluator.Evaluate(value, Sheet);
            if (!eval.Success)
            {
                return LooksNumericOrFormula(value)
                    ? new EditResult(false, eval.ErrorMessage, eval.ErrorPosition)
                    : SaveTextCell(cell, address, value);
            }

            cell.Contents = value;
            cell.Value = eval.Value;
            cell.Status = CellStatusFlags.Constant;
            if (eval.IsFormula)
            {
                cell.Status |= CellStatusFlags.Formula;
            }

            if (AutoCalc)
            {
                var recalc = Recalculate();
                if (!recalc.Success)
                {
                    return new EditResult(false, string.Join("; ", recalc.Errors));
                }
            }

            return new EditResult(true, eval.IsFormula ? "Formel gespeichert." : "Wert gespeichert.");
        }

        return SaveTextCell(cell, address, value);
    }

    /// <summary>
    /// DE: Berechnet alle Formelzellen im Blatt neu.
    /// EN: Recalculates all formula cells in the worksheet.
    /// </summary>
    /// <returns>
    /// DE: Erfolg sowie eventuelle Fehlermeldungen pro Zelle.
    /// EN: Success state and optional per-cell error messages.
    /// </returns>
    public RecalculateResult Recalculate()
    {
        var errors = new List<string>();

        foreach (var address in Sheet.AddressesRowMajor())
        {
            var cell = Sheet.GetCell(address);
            if (!cell.Status.HasFlag(CellStatusFlags.Formula))
            {
                continue;
            }

            var eval = _evaluator.Evaluate(cell.Contents, Sheet);
            if (!eval.Success)
            {
                errors.Add($"{address}: {eval.ErrorMessage} (Pos {eval.ErrorPosition})");
                continue;
            }

            cell.Value = eval.Value;
            cell.Status |= CellStatusFlags.Calculated;
        }

        return errors.Count == 0 ? RecalculateResult.Ok() : new RecalculateResult(false, errors);
    }

    /// <summary>
    /// DE: Wendet Dezimalstellen und Feldbreite auf einen Zellbereich in einer Spalte an.
    /// EN: Applies decimals and field width to a row range in one column.
    /// </summary>
    /// <param name="column">
    /// DE: Spalte (A-G), die formatiert wird.
    /// EN: Column (A-G) to format.
    /// </param>
    /// <param name="fromRow">
    /// DE: Startzeile des Bereichs.
    /// EN: Start row of the range.
    /// </param>
    /// <param name="toRow">
    /// DE: Endzeile des Bereichs.
    /// EN: End row of the range.
    /// </param>
    /// <param name="decimals">
    /// DE: Gewuenschte Nachkommastellen.
    /// EN: Requested number of decimal places.
    /// </param>
    /// <param name="fieldWidth">
    /// DE: Gewuenschte Feldbreite.
    /// EN: Requested field width.
    /// </param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// DE: Wenn die Spalte ausserhalb von A-G liegt.
    /// EN: Thrown when the column is outside A-G.
    /// </exception>
    public void FormatRange(char column, int fromRow, int toRow, int decimals, int fieldWidth)
    {
        var normalizedColumn = char.ToUpperInvariant(column);
        if (!SpreadsheetSpec.IsColumnInRange(normalizedColumn))
        {
            throw new ArgumentOutOfRangeException(nameof(column));
        }

        if (fromRow > toRow)
        {
            (fromRow, toRow) = (toRow, fromRow);
        }

        fromRow = Math.Clamp(fromRow, 1, SpreadsheetSpec.RowCount);
        toRow = Math.Clamp(toRow, 1, SpreadsheetSpec.RowCount);

        for (var row = fromRow; row <= toRow; row++)
        {
            var current = Sheet.GetCell(normalizedColumn, row);
            current.Decimals = Math.Clamp(decimals, -1, 11);
            current.FieldWidth = Math.Clamp(fieldWidth, 1, 20);

            var nextColumnIndex = SpreadsheetSpec.ColumnToIndex(normalizedColumn) + 1;
            if (nextColumnIndex >= SpreadsheetSpec.ColumnCount)
            {
                continue;
            }

            var next = Sheet.GetCell(SpreadsheetSpec.IndexToColumn(nextColumnIndex), row);
            if (current.FieldWidth > SpreadsheetSpec.DefaultFieldWidth)
            {
                next.Status |= CellStatusFlags.Locked | CellStatusFlags.Text;
                next.Contents = string.Empty;
            }
            else
            {
                next.Status &= ~CellStatusFlags.Locked;
            }
        }
    }

    /// <summary>
    /// DE: Bewegt den Cursor in eine Richtung und ueberspringt gesperrte/verdeckte Zellen.
    /// EN: Moves the cursor in one direction while skipping locked/overwritten cells.
    /// </summary>
    /// <param name="start">
    /// DE: Startposition der Bewegung.
    /// EN: Start position for movement.
    /// </param>
    /// <param name="direction">
    /// DE: Bewegungsrichtung.
    /// EN: Movement direction.
    /// </param>
    /// <returns>
    /// DE: Erreichte Zielposition.
    /// EN: Reached target position.
    /// </returns>
    public CellAddress Move(CellAddress start, Direction direction)
    {
        var maxSteps = SpreadsheetSpec.RowCount * SpreadsheetSpec.ColumnCount;
        var current = start;

        for (var step = 0; step < maxSteps; step++)
        {
            current = direction switch
            {
                Direction.Up => MoveUp(current),
                Direction.Down => MoveDown(current),
                Direction.Left => MoveLeft(current),
                _ => MoveRight(current),
            };

            var status = Sheet.GetCell(current).Status;
            if ((status & (CellStatusFlags.Locked | CellStatusFlags.OverWritten)) == 0)
            {
                return current;
            }
        }

        return start;
    }

    /// <summary>
    /// DE: Liefert den sichtbaren Zelltyp-Text fuer die Statuszeile.
    /// EN: Returns the visible cell-type text for the status line.
    /// </summary>
    /// <param name="address">
    /// DE: Adresse der Zelle.
    /// EN: Cell address.
    /// </param>
    /// <returns>
    /// DE: Einer der Werte "Text", "Numeric" oder "Formula".
    /// EN: One of "Text", "Numeric", or "Formula".
    /// </returns>
    public string GetCellTypeText(CellAddress address)
    {
        var status = Sheet.GetCell(address).Status;
        if (status.HasFlag(CellStatusFlags.Formula))
        {
            return "Formula";
        }

        if (status.HasFlag(CellStatusFlags.Constant))
        {
            return "Numeric";
        }

        return "Text";
    }

    /// <summary>
    /// DE: Rendert das komplette Grid als Textdarstellung.
    /// EN: Renders the full grid as a text representation.
    /// </summary>
    /// <returns>
    /// DE: Mehrzeilige Ansicht des Tabelleninhalts.
    /// EN: Multi-line view of the worksheet contents.
    /// </returns>
    public string RenderGridText()
    {
        var lines = new List<string>();
        lines.Add("    A           B           C           D           E           F           G");

        for (var row = 1; row <= SpreadsheetSpec.RowCount; row++)
        {
            var rowParts = new List<string> { row.ToString("00", CultureInfo.InvariantCulture) + " " };
            for (var column = SpreadsheetSpec.MinColumn; column <= SpreadsheetSpec.MaxColumn; column++)
            {
                var address = new CellAddress(column, row);
                var cell = Sheet.GetCell(address);
                var visible = FormatCellVisibleText(cell, 11);
                if (address.Equals(CurrentCell))
                {
                    visible = "[" + visible[1..10] + "]";
                }

                rowParts.Add(visible);
            }

            lines.Add(string.Concat(rowParts));
        }

        return string.Join(Environment.NewLine, lines);
    }

    /// <summary>
    /// DE: Baut die kompakte Statuszeile fuer die aktuelle Cursor-Position.
    /// EN: Builds the compact status line for the current cursor position.
    /// </summary>
    /// <returns>
    /// DE: Status mit Zelle, Typ und AutoCalc-Zustand.
    /// EN: Status including cell, type, and AutoCalc state.
    /// </returns>
    public string GetStatusLine()
    {
        var cell = Sheet.GetCell(CurrentCell);
        var type = GetCellTypeText(CurrentCell);
        return $"{CurrentCell}  {type}  AutoCalc: {(AutoCalc ? "ON" : "OFF")}";
    }

    private static bool LooksNumericOrFormula(string input)
    {
        var first = input[0];
        return char.IsDigit(first) || first is '+' or '-' or '.' or '(' or ')';
    }

    private static bool ShouldEvaluateAsExpression(string input)
    {
        if (LooksNumericOrFormula(input))
        {
            return true;
        }

        if (CellAddress.TryParse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0], out _))
        {
            return true;
        }

        if (input.Contains('>') || input.Contains('+') || input.Contains('-') || input.Contains('*') || input.Contains('/') || input.Contains('^'))
        {
            return true;
        }

        var upper = input.ToUpperInvariant();
        return upper.StartsWith("ABS(", StringComparison.Ordinal)
               || upper.StartsWith("SQRT(", StringComparison.Ordinal)
               || upper.StartsWith("SQR(", StringComparison.Ordinal)
               || upper.StartsWith("SIN(", StringComparison.Ordinal)
               || upper.StartsWith("COS(", StringComparison.Ordinal)
               || upper.StartsWith("ARCTAN(", StringComparison.Ordinal)
               || upper.StartsWith("LN(", StringComparison.Ordinal)
               || upper.StartsWith("LOG(", StringComparison.Ordinal)
               || upper.StartsWith("EXP(", StringComparison.Ordinal)
               || upper.StartsWith("FACT(", StringComparison.Ordinal);
    }

    private EditResult SaveTextCell(Cell cell, CellAddress address, string value)
    {
        cell.Status = CellStatusFlags.Text;
        cell.Contents = value;
        cell.Value = 0;
        ApplyTextOverflow(address, value);
        return new EditResult(true, "Text gespeichert.");
    }

    private void ClearOverwrittenTrail(CellAddress start)
    {
        var startIndex = SpreadsheetSpec.ColumnToIndex(start.Column) + 1;
        for (var index = startIndex; index < SpreadsheetSpec.ColumnCount; index++)
        {
            var column = SpreadsheetSpec.IndexToColumn(index);
            var cell = Sheet.GetCell(column, start.Row);
            if (!cell.Status.HasFlag(CellStatusFlags.OverWritten))
            {
                break;
            }

            cell.Status = CellStatusFlags.Text;
            cell.Contents = string.Empty;
            cell.Value = 0;
        }
    }

    private void ApplyTextOverflow(CellAddress start, string text)
    {
        var remaining = text.Length - SpreadsheetSpec.DefaultFieldWidth;
        var startIndex = SpreadsheetSpec.ColumnToIndex(start.Column) + 1;

        for (var index = startIndex; index < SpreadsheetSpec.ColumnCount; index++)
        {
            var column = SpreadsheetSpec.IndexToColumn(index);
            var cell = Sheet.GetCell(column, start.Row);

            if (remaining <= 0)
            {
                if (cell.Status.HasFlag(CellStatusFlags.OverWritten))
                {
                    cell.Status = CellStatusFlags.Text;
                    cell.Contents = string.Empty;
                    cell.Value = 0;
                }

                continue;
            }

            if (!string.IsNullOrEmpty(cell.Contents) && !cell.Status.HasFlag(CellStatusFlags.OverWritten))
            {
                break;
            }

            cell.Status = CellStatusFlags.Text | CellStatusFlags.OverWritten;
            cell.Contents = string.Empty;
            cell.Value = 0;
            remaining -= 11;
        }
    }

    private static string FormatCellVisibleText(Cell cell, int width)
    {
        if (cell.Status.HasFlag(CellStatusFlags.Text) && !cell.Status.HasFlag(CellStatusFlags.Constant))
        {
            var text = cell.Contents ?? string.Empty;
            if (text.Length > width)
            {
                return text[..width];
            }

            return text.PadRight(width);
        }

        var numeric = SpreadsheetSpec.FormatNumber(cell);
        if (numeric.Length > width)
        {
            return numeric[..width];
        }

        return numeric.PadLeft(width);
    }

    private static CellAddress MoveUp(CellAddress current)
    {
        var row = current.Row - 1;
        if (row < 1)
        {
            row = SpreadsheetSpec.RowCount;
        }

        return new CellAddress(current.Column, row);
    }

    private static CellAddress MoveDown(CellAddress current)
    {
        var row = current.Row + 1;
        if (row > SpreadsheetSpec.RowCount)
        {
            row = 1;
        }

        return new CellAddress(current.Column, row);
    }

    private static CellAddress MoveLeft(CellAddress current)
    {
        var columnIndex = SpreadsheetSpec.ColumnToIndex(current.Column) - 1;
        var row = current.Row;

        if (columnIndex < 0)
        {
            columnIndex = SpreadsheetSpec.ColumnCount - 1;
            row--;
            if (row < 1)
            {
                row = SpreadsheetSpec.RowCount;
            }
        }

        return new CellAddress(SpreadsheetSpec.IndexToColumn(columnIndex), row);
    }

    private static CellAddress MoveRight(CellAddress current)
    {
        var columnIndex = SpreadsheetSpec.ColumnToIndex(current.Column) + 1;
        var row = current.Row;

        if (columnIndex >= SpreadsheetSpec.ColumnCount)
        {
            columnIndex = 0;
            row++;
            if (row > SpreadsheetSpec.RowCount)
            {
                row = 1;
            }
        }

        return new CellAddress(SpreadsheetSpec.IndexToColumn(columnIndex), row);
    }
}
