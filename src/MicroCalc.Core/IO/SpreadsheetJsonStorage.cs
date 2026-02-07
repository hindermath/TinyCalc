using System.Text.Json;
using MicroCalc.Core.Engine;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.IO;

public static class SpreadsheetJsonStorage
{
    public static void Save(string path, MicroCalcEngine engine)
    {
        var doc = new SpreadsheetDocument
        {
            AutoCalc = engine.AutoCalc,
            Cells = engine.Sheet.AddressesRowMajor()
                .Select(address =>
                {
                    var cell = engine.Sheet.GetCell(address);
                    return new CellDocument
                    {
                        Address = address.ToString(),
                        Status = cell.Status,
                        Contents = cell.Contents,
                        Value = cell.Value,
                        Decimals = cell.Decimals,
                        FieldWidth = cell.FieldWidth,
                    };
                })
                .ToList(),
        };

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        var json = JsonSerializer.Serialize(doc, options);
        File.WriteAllText(path, json);
    }

    public static void Load(string path, MicroCalcEngine engine)
    {
        var json = File.ReadAllText(path);
        var doc = JsonSerializer.Deserialize<SpreadsheetDocument>(json)
                  ?? throw new InvalidDataException("Datei konnte nicht gelesen werden.");

        engine.Clear();
        engine.SetAutoCalc(doc.AutoCalc);

        foreach (var item in doc.Cells)
        {
            if (!CellAddress.TryParse(item.Address, out var address))
            {
                continue;
            }

            var cell = engine.Sheet.GetCell(address);
            cell.Status = item.Status;
            cell.Contents = item.Contents ?? string.Empty;
            cell.Value = item.Value;
            cell.Decimals = item.Decimals;
            cell.FieldWidth = item.FieldWidth;
        }
    }

    private sealed class SpreadsheetDocument
    {
        public bool AutoCalc { get; set; }

        public List<CellDocument> Cells { get; set; } = [];
    }

    private sealed class CellDocument
    {
        public string Address { get; set; } = string.Empty;

        public CellStatusFlags Status { get; set; }

        public string? Contents { get; set; }

        public double Value { get; set; }

        public int Decimals { get; set; }

        public int FieldWidth { get; set; }
    }
}
