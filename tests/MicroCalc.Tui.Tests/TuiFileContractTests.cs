using MicroCalc.ContractEvidence;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiFileContractTests
{
    [Theory]
    [InlineData("Load")]
    [InlineData("Save")]
    [InlineData("Print")]
    [Trait("Contract", "File")]
    public void ActualFileError_PreservesWorksheetAndOwnedFile(string command)
    {
        using var directory = new OwnedContractDirectory();
        var marker = Path.Combine(directory.Path, "existing.txt");
        File.WriteAllText(marker, "preserve this owned file");
        var target = command == "Load" ? Path.Combine(directory.Path, "missing.json") : directory.Path;
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        var steps = new List<Action<LegacyProgramUiAdapter>>
        {
            ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter),
            ui => { before = ui.Snapshot; ui.Send(new Key('/')); },
            ui => UiContractActions.SelectButton(ui, command),
            ui => { UiContractActions.ReplacePrompt(ui, target); ui.Send(Key.Enter); },
        };
        if (command == "Print") steps.Add(ui => ui.Send(Key.Enter));
        steps.Add(ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.Equal(before, ui.Snapshot);
            Assert.NotEmpty(ui.MessageText);
            Assert.DoesNotContain("Exception", ui.MessageText);
            Assert.DoesNotContain("Gespeichert:", ui.MessageText);
            Assert.DoesNotContain("Exportiert:", ui.MessageText);
            Assert.Equal("preserve this owned file", File.ReadAllText(marker));
            Assert.False(File.Exists(Path.Combine(directory.Path, "missing.json")));
        });
        adapter.Run(steps.ToArray());
    }

    public static IEnumerable<object[]> InvalidDocuments() => StorageContractCases.InvalidDocuments();

    [Theory]
    [MemberData(nameof(InvalidDocuments))]
    [Trait("Contract", "File")]
    public void InvalidLoad_UsesActualDialogAndPreservesWholeState(string kind, string json)
    {
        Assert.NotEmpty(kind);
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "invalid.json");
        File.WriteAllText(path, json);
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        adapter.Run(ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter),
            ui => { before = ui.Snapshot; ui.Send(new Key('/')); },
            ui => UiContractActions.SelectButton(ui, "Load"),
            ui => { UiContractActions.ReplacePrompt(ui, path); ui.Send(Key.Enter); },
            ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView);
                Assert.Equal(before, ui.Snapshot);
                Assert.DoesNotContain("Geladen:", ui.MessageText);
                Assert.NotEmpty(ui.MessageText);
                Assert.DoesNotContain("Exception", ui.MessageText);
                Assert.Equal(json, File.ReadAllText(path));
            });
    }

    [Fact]
    [Trait("Contract", "File")]
    public void ActualSaveAndLoad_RoundTripsNumericCellAndFileBytes()
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "roundtrip.json");
        using var adapter = new LegacyProgramUiAdapter();
        byte[]? saved = null;
        adapter.Run(ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter),
            ui => ui.Send(new Key('/')), ui => UiContractActions.SelectButton(ui, "Save"),
            ui => { UiContractActions.ReplacePrompt(ui, path); ui.Send(Key.Enter); },
            ui => { saved = File.ReadAllBytes(path); ui.Send(new Key('9')); }, ui => ui.Send(Key.Enter),
            ui => { Assert.Equal(9, ui.CurrentCell.Value); ui.Send(new Key('/')); },
            ui => UiContractActions.SelectButton(ui, "Load"),
            ui => { UiContractActions.ReplacePrompt(ui, path); ui.Send(Key.Enter); },
            ui =>
            {
                Assert.Equal("7", ui.CurrentCell.Contents);
                Assert.Equal(7, ui.CurrentCell.Value);
                Assert.Contains("Geladen:", ui.MessageText);
                Assert.Equal(saved, File.ReadAllBytes(path));
            });
    }
}
