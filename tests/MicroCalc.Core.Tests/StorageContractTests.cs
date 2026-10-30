using System.Text.Json;
using MicroCalc.ContractEvidence;
using MicroCalc.Core.Engine;
using MicroCalc.Core.IO;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Tests;

public sealed class StorageContractTests
{
    public static IEnumerable<object[]> InvalidDocuments() => StorageContractCases.InvalidDocuments();

    [Theory]
    [MemberData(nameof(InvalidDocuments))]
    [Trait("Contract", "Storage")]
    public void InvalidLoad_RejectsAndPreservesTheCompleteExistingWorksheet(string kind, string json)
    {
        Assert.NotEmpty(kind);
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "invalid.json");
        File.WriteAllText(path, json);
        var engine = Seed();
        var before = Snapshot(engine);
        Assert.Throws<InvalidDataException>(() => SpreadsheetJsonStorage.Load(path, engine));
        Assert.Equal(before, Snapshot(engine));
        Assert.Equal(json, File.ReadAllText(path));
    }

    [Fact]
    [Trait("Contract", "Storage")]
    public void RoundTrip_PreservesAllCellFieldsAndAutoCalcWithoutChangingSource()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "roundtrip.json");
        var engine = Seed();
        SpreadsheetJsonStorage.Save(path, engine);
        var bytes = File.ReadAllBytes(path);
        var loaded = new MicroCalcEngine();
        SpreadsheetJsonStorage.Load(path, loaded);
        Assert.Equal(Snapshot(engine, includeSelection: false), Snapshot(loaded, includeSelection: false));
        Assert.Equal(bytes, File.ReadAllBytes(path));
    }

    [Fact]
    [Trait("Contract", "Storage")]
    public void MissingFile_DoesNotReplaceExistingWorksheet()
    {
        using var directory = new OwnedContractDirectory();
        var engine = Seed();
        var before = Snapshot(engine);
        Assert.Throws<FileNotFoundException>(() => SpreadsheetJsonStorage.Load(Path.Combine(directory.Path, "missing.json"), engine));
        Assert.Equal(before, Snapshot(engine));
    }

    [Fact]
    [Trait("Security", "ResourceLimit")]
    public void OversizedLoad_IsRejectedBeforeReplacingTheWorksheet()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "oversized.json");
        File.WriteAllText(path, $$"""
            {"AutoCalc":true,"Cells":[],"Padding":"{{new string('x', 1024 * 1024)}}"}
            """);
        var engine = Seed();
        var before = Snapshot(engine);

        var exception = Assert.Throws<InvalidDataException>(() => SpreadsheetJsonStorage.Load(path, engine));

        Assert.Contains("Dateigröße", exception.Message, StringComparison.OrdinalIgnoreCase);
        Assert.Equal(before, Snapshot(engine));
    }

    [Fact]
    [Trait("Security", "ResourceLimit")]
    public void DeeplyNestedLoad_IsRejectedBeforeReplacingTheWorksheet()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "deep.json");
        var nested = string.Concat(Enumerable.Repeat("[", 20)) + "0" + string.Concat(Enumerable.Repeat("]", 20));
        File.WriteAllText(path, $"{{\"AutoCalc\":true,\"Cells\":[],\"Nested\":{nested}}}");
        var engine = Seed();
        var before = Snapshot(engine);

        Assert.Throws<InvalidDataException>(() => SpreadsheetJsonStorage.Load(path, engine));

        Assert.Equal(before, Snapshot(engine));
    }

    [Fact]
    [Trait("Security", "ResourceLimit")]
    public void MaximumWorksheetSavedByTheApplication_RemainsLoadable()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "maximum.json");
        var engine = new MicroCalcEngine();
        foreach (var address in engine.Sheet.AddressesRowMajor())
        {
            var cell = engine.Sheet.GetCell(address);
            cell.Contents = new string('\u001f', SpreadsheetSpec.CellInputLimit);
            cell.Status = CellStatusFlags.Text;
        }

        SpreadsheetJsonStorage.Save(path, engine);
        var loaded = new MicroCalcEngine();
        SpreadsheetJsonStorage.Load(path, loaded);

        Assert.Equal(Snapshot(engine, includeSelection: false), Snapshot(loaded, includeSelection: false));
    }

    [Fact]
    [Trait("Contract", "Storage")]
    public void SmallUnknownProperty_RemainsForwardCompatible()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "forward-compatible.json");
        File.WriteAllText(path, """
            {"AutoCalc":false,"Cells":[],"FutureMetadata":{"Version":1}}
            """);
        var engine = Seed();

        SpreadsheetJsonStorage.Load(path, engine);

        Assert.False(engine.AutoCalc);
        Assert.All(engine.Sheet.AddressesRowMajor(),
            address => Assert.Equal(CellStatusFlags.Text, engine.Sheet.GetCell(address).Status));
    }

    private static MicroCalcEngine Seed()
    {
        var engine = new MicroCalcEngine();
        Assert.True(engine.EditCell(new CellAddress('A', 1), "7").Success);
        Assert.True(engine.EditCell(new CellAddress('C', 2), "hello").Success);
        Assert.True(engine.EditCell(new CellAddress('D', 2), "A1+3").Success);
        engine.FormatRange('A', 1, 1, 3, 15);
        engine.SetAutoCalc(false);
        engine.CurrentCell = new CellAddress('C', 2);
        return engine;
    }

    private static string Snapshot(MicroCalcEngine engine, bool includeSelection = true) => JsonSerializer.Serialize(new
    {
        engine.AutoCalc, Selection = includeSelection ? engine.CurrentCell.ToString() : null,
        Cells = engine.Sheet.AddressesRowMajor().Select(address => new { Address = address.ToString(), Cell = engine.Sheet.GetCell(address).Clone() }),
    });
}
