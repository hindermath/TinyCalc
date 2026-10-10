using MicroCalc.ContractEvidence;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiFileContractTests
{
    [Theory]
    [InlineData("FILE-missing-load", "Load")]
    [InlineData("FILE-save-io-error", "Save")]
    [InlineData("FILE-print-io-error", "Print")]
    [Trait("Contract", "File")]
    public void ActualFileError_PreservesWorksheetAndOwnedFile(string id, string command)
    {
        var proof = new ExecutedPathProof(id);
        using var directory = new OwnedContractDirectory();
        var marker = Path.Combine(directory.Path, "existing.txt");
        File.WriteAllText(marker, "preserve this owned file");
        var target = command == "Load" ? Path.Combine(directory.Path, "missing.json") : directory.Path;
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        var steps = new List<Action<LegacyProgramUiAdapter>>
        {
            ui => { proof.BeginExecution(); ui.Send(new Key('7')); }, ui => ui.Send(Key.Enter),
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
            UiPathObservation.Record(proof, ui, "Grid", "7", 7);
        });
        adapter.Run(steps.ToArray());
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
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

    [Theory]
    [InlineData("FILE-roundtrip")]
    [Trait("Contract", "File")]
    public void ActualSaveAndLoad_RoundTripsNumericCellAndFileBytes(string id)
    {
        var proof = new ExecutedPathProof(id);
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "roundtrip.json");
        using var adapter = new LegacyProgramUiAdapter();
        byte[]? saved = null;
        adapter.Run(ui => { proof.BeginExecution(); ui.Send(new Key('7')); }, ui => ui.Send(Key.Enter),
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
                UiPathObservation.Record(proof, ui, "Grid", "7", 7);
            });
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

    [Theory]
    [InlineData("FILE-malformed-load", "{")]
    [InlineData("FILE-partial-invalid-load", "partial")]
    [Trait("Contract", "File")]
    public void BoundInvalidLoad_PreservesWorksheetAndBytes(string id, string document)
    {
        var proof = new ExecutedPathProof(id);
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "invalid.json");
        var json = document == "partial" ? "{\"AutoCalc\":false,\"Cells\":[" + StorageContractCases.ValidCell() + "," + StorageContractCases.ValidCell("H22") + "]}" : document;
        File.WriteAllText(path, json);
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        adapter.Run(ui => { proof.BeginExecution(); ui.Send(new Key('7')); }, ui => ui.Send(Key.Enter),
            ui => { before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Load"),
            ui => { UiContractActions.ReplacePrompt(ui, path); ui.Send(Key.Enter); }, ui =>
            {
                Assert.Equal(before, ui.Snapshot);
                Assert.Equal(json, File.ReadAllText(path));
                Assert.NotEmpty(ui.MessageText);
                Assert.DoesNotContain("Geladen:", ui.MessageText);
                Assert.DoesNotContain("Exception", ui.MessageText);
                UiPathObservation.Record(proof, ui, "Grid", "7", 7);
            });
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

    [Theory]
    [InlineData("FILE-print-zero-margin", "0", 0)]
    [InlineData("FILE-print-positive-margin", "3", 3)]
    [InlineData("FILE-print-invalid-margin", "not-a-number", 0)]
    [Trait("Contract", "File")]
    public void BoundPrint_UsesActualPromptsAndIndependentTextOracle(string id, string margin, int spaces)
    {
        var proof = new ExecutedPathProof(id);
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "print.lst");
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        adapter.Run(ui => { proof.BeginExecution(); ui.Send(new Key('7')); }, ui => ui.Send(Key.Enter),
            ui => { before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Print"),
            ui => { UiContractActions.ReplacePrompt(ui, path); ui.Send(Key.Enter); },
            ui => { UiContractActions.ReplacePrompt(ui, margin); ui.Send(Key.Enter); }, ui =>
            {
                Assert.Equal(before, ui.Snapshot);
                var lines = File.ReadAllLines(path);
                Assert.StartsWith(new string(' ', spaces) + "7.00", lines[2]);
                Assert.Contains("Exportiert:", ui.MessageText);
                UiPathObservation.Record(proof, ui, "Grid", "7", 7);
            });
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }
}
