using System.Text.Json;
using MicroCalc.Core.Engine;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.IO;

/// <summary>
/// DE: Persistenz fuer MicroCalc-Tabellen im JSON-Format.
/// EN: Persistence for MicroCalc worksheets in JSON format.
/// </summary>
public static class SpreadsheetJsonStorage
{
    /// <summary>
    /// DE: Speichert den Engine-Zustand als JSON-Datei.
    /// EN: Saves the engine state as a JSON file.
    /// </summary>
    /// <param name="path">
    /// DE: Zielpfad der JSON-Datei.
    /// EN: Target path of the JSON file.
    /// </param>
    /// <param name="engine">
    /// DE: Engine mit dem zu speichernden Blattzustand.
    /// EN: Engine containing the worksheet state to save.
    /// </param>
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

    /// <summary>
    /// DE: Laedt einen Engine-Zustand aus einer JSON-Datei.
    /// EN: Loads an engine state from a JSON file.
    /// </summary>
    /// <param name="path">
    /// DE: Quellpfad der JSON-Datei.
    /// EN: Source path of the JSON file.
    /// </param>
    /// <param name="engine">
    /// DE: Ziel-Engine, die mit den gelesenen Daten gefuellt wird.
    /// EN: Target engine to be populated with loaded data.
    /// </param>
    /// <exception cref="InvalidDataException">
    /// DE: Wenn die Datei kein gueltiges Spreadsheet-Dokument enthaelt.
    /// EN: Thrown when the file does not contain a valid spreadsheet document.
    /// </exception>
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
