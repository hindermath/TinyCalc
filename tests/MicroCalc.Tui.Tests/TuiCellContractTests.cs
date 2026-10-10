using MicroCalc.Core.Model;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiCellContractTests
{
    [Theory]
    [InlineData("", 0, "Text")]
    [InlineData("hello", 0, "Text")]
    [InlineData("12", 12, "Numeric")]
    [InlineData("A2+3", 3, "Formula")]
    [Trait("Contract", "Cell")]
    public void ActualEditor_PreservesCellKindsValuesAndStatus(string text, double expected, string type)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(text.Length == 0 ? Key.Esc : new Key(text[0])), ui =>
        {
            if (text.Length != 0) UiContractActions.FinishTyping(ui, text);
            ui.Send(Key.Enter);
        }, ui =>
        {
            Assert.Equal(text, ui.CurrentCell.Contents);
            Assert.Equal(expected, ui.CurrentCell.Value);
            Assert.Equal($"A1  {type}  AutoCalc: ON", ui.StatusText);
            Assert.Equal(type == "Formula", ui.CurrentCell.Status.HasFlag(CellStatusFlags.Formula));
        });
    }

    [Theory]
    [InlineData(-1, 1)]
    [InlineData(0, 10)]
    [InlineData(11, 20)]
    [Trait("Contract", "Cell")]
    public void ActualFormatPrompts_BindLimitsAndLockedNavigation(int decimals, int width)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key('1')), ui =>
        {
            UiContractActions.FinishTyping(ui, "12.5");
            ui.Send(Key.Enter);
        }, ui => ui.Send(new Key('/')), ui => UiContractActions.SelectButton(ui, "Format"),
            ui => { UiContractActions.ReplacePrompt(ui, decimals.ToString(System.Globalization.CultureInfo.InvariantCulture)); ui.Send(Key.Enter); },
            ui => { UiContractActions.ReplacePrompt(ui, width.ToString(System.Globalization.CultureInfo.InvariantCulture)); ui.Send(Key.Enter); },
            ui => ui.Send(Key.Enter), ui => ui.Send(Key.Enter), ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView);
                Assert.Equal(decimals, ui.CurrentCell.Decimals);
                Assert.Equal(width, ui.CurrentCell.FieldWidth);
                Assert.Equal(12.5, ui.CurrentCell.Value);
                if (width == 20) Assert.Contains("12.50000000000", ui.GridText);
                ui.Send(Key.CursorRight);
                Assert.Equal(new CellAddress(width > 10 ? 'C' : 'B', 1), ui.Address);
            });
    }

    [Fact]
    [Trait("Contract", "Cell")]
    public void ActualEditor_EnforcesTextLimitAndExplainsInvalidFormulaWithoutMutation()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key('z')), ui =>
        {
            UiContractActions.FinishTyping(ui, new string('z', 71));
            ui.Send(Key.Enter);
        }, ui =>
        {
            Assert.Equal(new string('z', 70), ui.CurrentCell.Contents);
            Assert.Contains(new string('z', 70), ui.GridText);
            ui.Send(new Key('1'));
        }, ui =>
        {
            UiContractActions.FinishTyping(ui, "1+");
            ui.Send(Key.Enter);
        }, ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.Equal(new string('z', 70), ui.CurrentCell.Contents);
            Assert.Contains("Fehler an Position", ui.MessageText);
            Assert.DoesNotContain(" at ", ui.MessageText);
        });
    }
}
