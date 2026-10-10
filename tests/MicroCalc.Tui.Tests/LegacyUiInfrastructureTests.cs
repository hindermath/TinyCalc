using MicroCalc.Core.Model;
using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[CollectionDefinition("Terminal.Gui contract", DisableParallelization = true)]
public sealed class TerminalGuiContractCollection;

[Collection("Terminal.Gui contract")]
public sealed class LegacyUiInfrastructureTests
{
    [Fact]
    [Trait("Contract", "LegacyInfrastructure")]
    public void ExistingViews_DispatchNavigationAndRealEditorCancellation()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(
            ui =>
            {
                Assert.Equal(new CellAddress('A', 1), ui.Address);
                Assert.Contains("A", ui.GridText);
                Assert.Contains("AutoCalc: ON", ui.StatusText);
            },
            ui => ui.Send(Key.CursorRight),
            ui => Assert.Equal(new CellAddress('B', 1), ui.Address),
            ui => ui.Send(new Key('3')),
            ui =>
            {
                Assert.True(ui.CurrentView is Dialog, ui.MessageText);
                var dialog = Assert.IsType<Dialog>(ui.CurrentView);
                var input = Assert.Single(LegacyProgramUiAdapter.Descendants(dialog).OfType<TextField>());
                Assert.Equal("3", input.Text.ToString());
                ui.Send(Key.Esc);
            },
            ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView);
                Assert.Equal(string.Empty, ui.CurrentCell.Contents);
                Assert.Equal(new CellAddress('B', 1), ui.Address);
            });
    }
}
