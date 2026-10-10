using System.Text.Json;

namespace MicroCalc.ContractEvidence;

internal sealed class OwnedContractDirectory : IDisposable
{
    internal string Path { get; } = Directory.CreateTempSubdirectory("tinycalc-contract-").FullName;
    public void Dispose() => Directory.Delete(Path, true);
}

internal static class StorageContractCases
{
    internal static string ValidCell(string address = "A1", string contents = "99", int status = 1, int decimals = 2, int width = 10)
        => JsonSerializer.Serialize(new { Address = address, Contents = contents, Status = status, Value = 99, Decimals = decimals, FieldWidth = width });

    internal static IEnumerable<object[]> InvalidDocuments()
    {
        yield return ["malformed", "{"];
        yield return ["null-document", "null"];
        yield return ["null-cells", "{\"AutoCalc\":false,\"Cells\":null}"];
        yield return ["null-cell", "{\"AutoCalc\":false,\"Cells\":[null]}"];
        foreach (var entry in new[]
        {
            ("invalid-address", ValidCell("H22")), ("duplicate-address", ValidCell()),
            ("invalid-status", ValidCell("B1", status: 128)), ("invalid-decimals", ValidCell("B1", decimals: 12)),
            ("invalid-width", ValidCell("B1", width: 0)), ("input-overflow", ValidCell("B1", contents: new string('z', 71))),
        })
        {
            // DE: Ein gültiger erster Datensatz macht unzulässige Teilübernahmen im zweiten sichtbar.
            // EN: A valid first record exposes impermissible partial replacement in the second record.
            yield return [entry.Item1, "{\"AutoCalc\":false,\"Cells\":[" + ValidCell() + "," + entry.Item2 + "]}"];
        }
    }
}
