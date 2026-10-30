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
    private const int MaximumDocumentSizeBytes = 128 * 1024;
    private const int MaximumJsonDepth = 16;

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
        SpreadsheetDocument doc;
        using var stream = new FileStream(path, new FileStreamOptions
        {
            Mode = FileMode.Open,
            Access = FileAccess.Read,
            Share = FileShare.Read,
            BufferSize = 4096,
            Options = FileOptions.SequentialScan,
        });
        // DE: Die Grenze gilt am offenen Handle, bevor JSON-Text oder Objektgraphen Speicher belegen.
        // EN: Enforce the limit on the open handle before JSON text or object graphs allocate memory.
        if (stream.Length > MaximumDocumentSizeBytes)
        {
            throw DocumentTooLarge();
        }

        var documentBytes = new byte[MaximumDocumentSizeBytes + 1];
        var documentLength = 0;
        int bytesRead;
        while (documentLength < documentBytes.Length &&
               (bytesRead = stream.Read(documentBytes, documentLength, documentBytes.Length - documentLength)) > 0)
        {
            documentLength += bytesRead;
        }

        // DE: Auch eine nach dem Laengencheck wachsende Datei darf die Byte-Grenze nicht umgehen.
        // EN: A file that grows after the length check must not bypass the byte boundary either.
        if (documentLength > MaximumDocumentSizeBytes)
        {
            throw DocumentTooLarge();
        }

        try
        {
            doc = JsonSerializer.Deserialize<SpreadsheetDocument>(
                      documentBytes.AsSpan(0, documentLength),
                      new JsonSerializerOptions { MaxDepth = MaximumJsonDepth })
                  ?? throw new InvalidDataException("Datei enthält kein gültiges Tabellen-Dokument.");
        }
        catch (JsonException exception)
        {
            throw new InvalidDataException("Datei enthält kein gültiges Tabellen-JSON.", exception);
        }

        if (doc.Cells is null || doc.Cells.Count > SpreadsheetSpec.ColumnCount * SpreadsheetSpec.RowCount)
            throw new InvalidDataException("Ungültige Zellliste.");
        var addresses = new HashSet<CellAddress>();
        var staged = new List<(CellAddress Address, CellDocument Data)>();
        // DE: Alle Datensätze prüfen, bevor das bestehende Blatt verändert wird; Fehler dürfen keine Teilübernahme hinterlassen.
        // EN: Validate every record before changing the existing sheet; failures must not leave partial replacement.
        foreach (var item in doc.Cells)
        {
            if (item is null || !CellAddress.TryParse(item.Address, out var address) || !addresses.Add(address)
                || ((int)item.Status & ~63) != 0 || !double.IsFinite(item.Value)
                || item.Decimals is < -1 or > 11 || item.FieldWidth is < 1 or > 20
                || (item.Contents?.Length ?? 0) > SpreadsheetSpec.CellInputLimit)
                throw new InvalidDataException("Ungültiger oder doppelter Zell-Datensatz.");
            staged.Add((address, item));
        }

        engine.Clear();
        engine.SetAutoCalc(doc.AutoCalc);

        foreach (var entry in staged)
        {
            var item = entry.Data;
            var cell = engine.Sheet.GetCell(entry.Address);
            cell.Status = item.Status;
            cell.Contents = item.Contents ?? string.Empty;
            cell.Value = item.Value;
            cell.Decimals = item.Decimals;
            cell.FieldWidth = item.FieldWidth;
        }
    }

    private static InvalidDataException DocumentTooLarge() => new(
        $"Dateigröße überschreitet das Maximum von {MaximumDocumentSizeBytes} Bytes.");

    private sealed class SpreadsheetDocument
    {
        public bool AutoCalc { get; set; }

        public List<CellDocument>? Cells { get; set; }
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
