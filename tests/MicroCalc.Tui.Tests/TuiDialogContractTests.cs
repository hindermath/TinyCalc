using System.Security.Cryptography;
using System.Text.Json;
using MicroCalc.ContractEvidence;
using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiDialogContractTests
{
    public static IEnumerable<object[]> Cases()
    {
        foreach (var dialog in new[] { "Editor", "Load", "Save", "PrintFile", "PrintMargin", "FormatDecimals", "FormatWidth", "FormatFrom", "FormatTo", "Clear", "Palette" })
            foreach (var action in new[] { "Enter", "Button", "Esc", "Cancel" }) yield return [dialog, action];
    }

    [Theory]
    [MemberData(nameof(Cases))]
    [Trait("Contract", "Dialog")]
    public void EveryDialogStage_ConfirmsOrCancelsWithoutPartialEffects(string kind, string action)
    {
        using var directory = new OwnedContractDirectory();
        var jsonPath = Path.Combine(directory.Path, "sheet.json");
        var printPath = Path.Combine(directory.Path, "sheet.lst");
        File.WriteAllText(jsonPath, "{\"AutoCalc\":false,\"Cells\":[" + StorageContractCases.ValidCell() + "]}");
        File.WriteAllText(printPath, "existing output must survive cancellation");
        using var adapter = new LegacyProgramUiAdapter();
        var steps = new List<Action<LegacyProgramUiAdapter>>
        {
            ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter),
            ui => ui.Send(new Key('/')), ui => UiContractActions.SelectButton(ui, "Auto"),
        };
        string? before = null;
        string? filesBefore = null;
        var cancel = action is "Esc" or "Cancel";
        steps.Add(ui =>
        {
            Assert.False(ui.AutoCalc);
            before = ui.Snapshot;
            filesBefore = Files(directory.Path);
            ui.Send(kind == "Editor" ? Key.Esc : new Key('/'));
        });
        if (kind != "Editor" && kind != "Palette")
            steps.Add(ui => UiContractActions.SelectButton(ui, kind.StartsWith("Print", StringComparison.Ordinal) ? "Print"
                : kind.StartsWith("Format", StringComparison.Ordinal) ? "Format" : kind));
        var stage = kind switch { "PrintMargin" or "FormatWidth" => 1, "FormatFrom" => 2, "FormatTo" => 3, _ => 0 };
        for (var i = 0; i < stage; i++)
        {
            var promptIndex = i;
            steps.Add(ui =>
            {
                UiContractActions.ReplacePrompt(ui, kind.StartsWith("Print", StringComparison.Ordinal) ? printPath
                    : promptIndex == 0 ? "3" : promptIndex == 1 ? "15" : "1");
                ui.Send(Key.Enter);
            });
        }
        var stagedSuccess = !cancel && kind is "PrintFile" or "FormatDecimals" or "FormatWidth" or "FormatFrom";
        steps.Add(ui =>
        {
            Assert.Equal(before, ui.Snapshot);
            Assert.Equal(filesBefore, Files(directory.Path));
            if (kind is not "Clear" and not "Palette")
                UiContractActions.ReplacePrompt(ui, kind switch
                {
                    "Editor" => "9", "Load" or "Save" => jsonPath, "PrintFile" => printPath,
                    "PrintMargin" or "FormatDecimals" => "3", "FormatWidth" => "15", _ => "1",
                });
            if (cancel)
            {
                if (action == "Esc") ui.Send(Key.Esc);
                else UiContractActions.SelectButton(ui, kind == "Clear" ? "No" : "Cancel");
            }
            else if (kind is "Clear" or "Palette")
                UiContractActions.SelectButton(ui, kind == "Clear" ? "Yes" : "Recalc");
            else if (action == "Enter") ui.Send(Key.Enter);
            else UiContractActions.SelectButton(ui, "OK");
        });
        if (stagedSuccess)
            steps.Add(ui =>
            {
                Assert.IsType<Dialog>(ui.CurrentView);
                Assert.Equal(before, ui.Snapshot);
                Assert.Equal(filesBefore, Files(directory.Path));
                ui.Send(Key.Esc);
            });
        steps.Add(ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            if (cancel || stagedSuccess || kind is "Save" or "PrintMargin" or "Palette")
                Assert.Equal(before, ui.Snapshot);
            if (cancel || stagedSuccess || kind is "Editor" or "Load" or "Clear" or "Palette" || kind.StartsWith("Format", StringComparison.Ordinal))
                Assert.Equal(filesBefore, Files(directory.Path));
            if (cancel || stagedSuccess) return;
            switch (kind)
            {
                case "Editor": Assert.Equal("9", ui.CurrentCell.Contents); Assert.Equal(9, ui.CurrentCell.Value); break;
                case "Load": Assert.Equal("99", ui.CurrentCell.Contents); Assert.Equal(99, ui.CurrentCell.Value); break;
                case "Save":
                    using (var doc = JsonDocument.Parse(File.ReadAllText(jsonPath)))
                        Assert.Equal(7, doc.RootElement.GetProperty("Cells")[0].GetProperty("Value").GetDouble());
                    break;
                case "PrintMargin": Assert.StartsWith("   7.00", File.ReadAllLines(printPath)[2]); break;
                case "FormatTo": Assert.Equal(3, ui.CurrentCell.Decimals); Assert.Equal(15, ui.CurrentCell.FieldWidth); break;
                case "Clear": Assert.Equal(string.Empty, ui.CurrentCell.Contents); Assert.True(ui.AutoCalc); break;
                case "Palette": Assert.Equal("Recalculate abgeschlossen.", ui.MessageText); break;
            }
        });
        adapter.Run(steps.ToArray());
    }

    private static string Files(string root) => JsonSerializer.Serialize(Directory.GetFiles(root).Order(StringComparer.Ordinal)
        .Select(path => new { Name = Path.GetFileName(path), Hash = Convert.ToHexString(SHA256.HashData(File.ReadAllBytes(path))) }));
}
