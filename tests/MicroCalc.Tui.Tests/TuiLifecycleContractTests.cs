using MicroCalc.Core.Model;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiLifecycleContractTests
{
    [Fact]
    [Trait("Contract", "Lifecycle")]
    public void InteractiveGrid_HasAllHeadersRowsSelectionAndStatus()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.Equal(new CellAddress('A', 1), ui.Address);
            var lines = ui.GridText.Split(Environment.NewLine);
            Assert.Equal(22, lines.Length);
            foreach (var column in "ABCDEFG") Assert.Contains(column.ToString(), lines[0]);
            for (var row = 1; row <= 21; row++) Assert.StartsWith(row.ToString("00") + " ", lines[row]);
            Assert.Contains("[", lines[1]);
            Assert.Contains("]", lines[1]);
            Assert.Equal("A1  Text  AutoCalc: ON", ui.StatusText);
        });
    }

    [Fact]
    [Trait("Contract", "Lifecycle")]
    public void ActiveNumericCell_DoesNotLoseLastDisplayedDigit()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter), ui =>
        {
            Assert.Contains("7.00", ui.GridText.Split(Environment.NewLine)[1]);
            Assert.Contains("A1", ui.StatusText);
            Assert.DoesNotContain("Text", ui.StatusText);
        });
    }

    [Fact]
    [Trait("Contract", "Lifecycle")]
    public void QuitShortcut_EndsOwnedInteractiveLoop()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.RunToExit(ui => ui.Send(Key.Q.WithCtrl));
        Assert.Empty(adapter.App.SessionStack!);
    }
}
