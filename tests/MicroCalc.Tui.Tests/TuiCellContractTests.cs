using MicroCalc.Core.Model;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiCellContractTests
{
    [Theory]
    [InlineData("CELL-empty", "", 0, "Text", 2, 10)]
    [InlineData("CELL-text", "hello", 0, "Text", 2, 10)]
    [InlineData("CELL-number", "12", 12, "Numeric", 2, 10)]
    [InlineData("CELL-formula", "A2+3", 3, "Formula", 2, 10)]
    [InlineData("CELL-flags", "A2+3", 3, "Formula", 2, 10)]
    [InlineData("CELL-overflow", "abcdefghijklmnopqrstuv", 0, "Text", 2, 10)]
    [InlineData("CELL-width-min", "12.5", 12.5, "Numeric", 2, 1)]
    [InlineData("CELL-width-max", "12.5", 12.5, "Numeric", 2, 20)]
    [InlineData("CELL-decimals-scientific", "12.5", 12.5, "Numeric", -1, 10)]
    [InlineData("CELL-decimals-min", "12.5", 12.5, "Numeric", 0, 10)]
    [InlineData("CELL-decimals-max", "12.5", 12.5, "Numeric", 11, 20)]
    [InlineData("CELL-locked-formula", "A2+3", 3, "Formula", 2, 20)]
    [InlineData("CELL-invalid-input", "1+", 7, "Numeric", 2, 10)]
    [Trait("Contract", "RemainingCell")]
    public void BoundCellPath_UsesActualEditorAndIndependentOracle(string id, string text, double expected, string type, int decimals, int width)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        var steps = new List<Action<LegacyProgramUiAdapter>> { _ => proof.BeginExecution() };
        if (id == "CELL-invalid-input") { steps.Add(ui => ui.Send(new Key('7'))); steps.Add(ui => ui.Send(Key.Enter)); }
        steps.Add(ui => ui.Send(Key.Esc));
        steps.Add(ui => { UiContractActions.ReplacePrompt(ui, text); ui.Send(Key.Enter); });
        if (id.Contains("width-", StringComparison.Ordinal) || id.Contains("decimals-", StringComparison.Ordinal) || id == "CELL-locked-formula")
        {
            steps.Add(ui => ui.Send(new Key('/')));
            steps.Add(ui => UiContractActions.SelectButton(ui, "Format"));
            steps.Add(ui => { UiContractActions.ReplacePrompt(ui, decimals.ToString(System.Globalization.CultureInfo.InvariantCulture)); ui.Send(Key.Enter); });
            steps.Add(ui => { UiContractActions.ReplacePrompt(ui, width.ToString(System.Globalization.CultureInfo.InvariantCulture)); ui.Send(Key.Enter); });
            steps.Add(ui => ui.Send(Key.Enter)); steps.Add(ui => ui.Send(Key.Enter));
        }
        steps.Add(ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            var contents = id == "CELL-invalid-input" ? "7" : text;
            Assert.Equal(contents, ui.CurrentCell.Contents);
            Assert.Equal(expected, ui.CurrentCell.Value);
            Assert.Equal(decimals, ui.CurrentCell.Decimals);
            Assert.Equal(width, ui.CurrentCell.FieldWidth);
            Assert.Contains($"A1  {type}  AutoCalc: ON", ui.StatusText);
            if (type == "Formula") Assert.True(ui.CurrentCell.Status.HasFlag(CellStatusFlags.Formula | CellStatusFlags.Calculated));
            if (id == "CELL-invalid-input") Assert.Contains("Fehler an Position", ui.MessageText);
            if (id == "CELL-overflow")
            {
                Assert.Contains(text, ui.GridText);
                // DE: 22 Zeichen belegen bei Breite 10 drei Spalten; B und C sind Überlaufzellen.
                // EN: At width 10, 22 characters occupy three columns; B and C are overflow cells.
                ui.Send(Key.CursorRight); Assert.Equal(new CellAddress('D', 1), ui.Address);
                ui.Send(Key.CursorLeft); Assert.Equal(new CellAddress('A', 1), ui.Address);
            }
            if (width == 20)
            {
                ui.Send(Key.CursorRight); Assert.Equal(new CellAddress('C', 1), ui.Address);
                ui.Send(Key.CursorLeft); Assert.Equal(new CellAddress('A', 1), ui.Address);
            }
            UiPathObservation.Record(proof, ui, "Grid", contents, expected);
        });
        adapter.Run(steps.ToArray());
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

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
