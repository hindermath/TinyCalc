using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiVerticalSliceContractTests
{
    [Theory]
    [Trait("Contract", "VerticalSlice")]
    [InlineData("2+3", 5)]
    [InlineData("2^3^2", 512)]
    public void RealEditor_FormulaIsAcceptedAndRendered(string formula, double expected)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(
            ui => ui.Send(new Key(formula[0])),
            ui =>
            {
                var dialog = Assert.IsType<Dialog>(ui.CurrentView);
                var input = Assert.Single(LegacyProgramUiAdapter.Descendants(dialog).OfType<TextField>());
                ui.Send(Key.End);
                foreach (var character in formula.Skip(1))
                    ui.Send(new Key(character));
                Assert.Equal(formula, input.Text.ToString());
                ui.Send(Key.Enter);
            },
            ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView);
                Assert.Equal(formula, ui.CurrentCell.Contents);
                Assert.DoesNotContain("Fehler", ui.MessageText);
                Assert.Equal(expected, ui.CurrentCell.Value);
                ui.Send(Key.CursorRight);
                Assert.Contains(expected.ToString("F2", System.Globalization.CultureInfo.InvariantCulture), ui.GridText);
            });
    }

    [Fact]
    [Trait("Contract", "VerticalSlice")]
    public void RealEditor_CancellationPreservesExistingFormulaAndValue()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(
            ui => ui.Send(new Key('7')),
            ui => ui.Send(Key.Enter),
            ui =>
            {
                Assert.Equal(7, ui.CurrentCell.Value);
                ui.Send(Key.Esc);
            },
            ui =>
            {
                var dialog = Assert.IsType<Dialog>(ui.CurrentView);
                var input = Assert.Single(LegacyProgramUiAdapter.Descendants(dialog).OfType<TextField>());
                Assert.Equal("7", input.Text.ToString());
                ui.Send(new Key('9'));
                ui.Send(Key.Esc);
            },
            ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView);
                Assert.Equal("7", ui.CurrentCell.Contents);
                Assert.Equal(7, ui.CurrentCell.Value);
                ui.Send(Key.CursorRight);
                Assert.Contains("7.00", ui.GridText);
            });
    }
}
