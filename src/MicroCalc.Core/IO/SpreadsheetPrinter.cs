using System.Globalization;
using System.Text;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.IO;

public static class SpreadsheetPrinter
{
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
