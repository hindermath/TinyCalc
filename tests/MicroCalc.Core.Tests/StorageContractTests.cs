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
