using System.Globalization;
using System.Text;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.IO;

/// <summary>
/// DE: Exportiert ein Blatt als textbasierte Druckansicht.
/// EN: Exports a worksheet as text-based print output.
/// </summary>
public static class SpreadsheetPrinter
{
    /// <summary>
    /// DE: Schreibt den Blattinhalt als ausgerichteten Text in eine Datei.
    /// EN: Writes worksheet contents as aligned text into a file.
    /// </summary>
    /// <param name="sheet">
    /// DE: Zu exportierendes Blatt.
    /// EN: Worksheet to export.
    /// </param>
    /// <param name="path">
    /// DE: Zielpfad der Ausgabedatei.
    /// EN: Target path of the output file.
    /// </param>
    /// <param name="leftMargin">
    /// DE: Anzahl Leerzeichen links vor jeder Zeile.
    /// EN: Number of left margin spaces for each row.
    /// </param>
    public static void ExportText(Spreadsheet sheet, string path, int leftMargin)
    {
        leftMargin = Math.Max(0, leftMargin);
        var margin = new string(' ', leftMargin);

        using var writer = new StreamWriter(path, false, Encoding.UTF8);
        writer.WriteLine();
        writer.WriteLine();

        for (var row = 1; row <= SpreadsheetSpec.RowCount; row++)
        {
            var line = new StringBuilder();
            for (var column = SpreadsheetSpec.MinColumn; column <= SpreadsheetSpec.MaxColumn; column++)
            {
                var cell = sheet.GetCell(column, row);
                var value = FormatCell(cell);
                line.Append(value.PadRight(11));
            }

            writer.WriteLine(margin + line.ToString().TrimEnd());
        }
    }

    private static string FormatCell(Cell cell)
    {
        if (cell.Status.HasFlag(CellStatusFlags.Text) && !cell.Status.HasFlag(CellStatusFlags.Constant))
        {
            return cell.Contents;
        }

        if (cell.Decimals >= 0)
        {
            return cell.Value.ToString($"F{cell.Decimals}", CultureInfo.InvariantCulture);
        }

        return cell.Value.ToString("E6", CultureInfo.InvariantCulture);
    }
}
