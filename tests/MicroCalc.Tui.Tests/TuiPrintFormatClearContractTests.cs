using MicroCalc.ContractEvidence;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiPrintFormatClearContractTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(3)]
    [InlineData(-1)]
    [Trait("Contract", "Print")]
    public void ActualPrint_HasTwentyOneRowsAndRequestedNonnegativeMargin(int margin)
    {
        using var directory = new OwnedContractDirectory();
        var path = Path.Combine(directory.Path, "sheet.lst");
        File.WriteAllText(path, "previous owned print output");
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        adapter.Run(ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter),
            ui => { before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Print"),
            ui => { UiContractActions.ReplacePrompt(ui, path); ui.Send(Key.Enter); },
            ui => { Assert.Equal("previous owned print output", File.ReadAllText(path)); UiContractActions.ReplacePrompt(ui, margin.ToString(System.Globalization.CultureInfo.InvariantCulture)); ui.Send(Key.Enter); },
            ui =>
            {
                Assert.Equal(before, ui.Snapshot);
                Assert.Same(ui.Root, ui.CurrentView);
                var lines = File.ReadAllLines(path);
                Assert.Equal(23, lines.Length);
                Assert.Equal(string.Empty, lines[0]);
                Assert.Equal(string.Empty, lines[1]);
                Assert.Equal(new string(' ', Math.Max(0, margin)) + "7.00", lines[2]);
                Assert.Contains("Exportiert:", ui.MessageText);
            });
    }
}
