using MicroCalc.ContractEvidence;
using MicroCalc.Core.Model;
using Terminal.Gui.Input;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiFormulaContractTests
{
    public static IEnumerable<object[]> Cases() => FormulaContractCases.Read().Select(offer => new object[] { offer.GetProperty("id").GetString()! });

    [Theory]
    [MemberData(nameof(Cases))]
    [Trait("Contract", "Formula")]
    public void EveryFormula_UsesRealEditorAndIndependentOracle(string id)
    {
        var offer = FormulaContractCases.Find(id);
        var expression = FormulaContractCases.Expression(offer);
        var error = offer.GetProperty("scenarioKind").GetString() == "Error";
        var steps = new List<Action<LegacyProgramUiAdapter>>();
        foreach (var cell in offer.GetProperty("setup").GetProperty("cells").EnumerateObject())
        {
            Assert.True(CellAddress.TryParse(cell.Name, out var address));
            var text = cell.Value.GetString()!;
            steps.Add(ui => { UiContractActions.NavigateTo(ui, address); ui.Send(new Key(text[0])); });
            steps.Add(ui => { UiContractActions.FinishTyping(ui, text); ui.Send(Key.Enter); });
            steps.Add(ui => Assert.Equal(text, ui.CurrentCell.Contents));
        }
        steps.Add(ui => { UiContractActions.NavigateTo(ui, new CellAddress('A', 1)); ui.Send(new Key('7')); });
        steps.Add(ui => ui.Send(Key.Enter));
        steps.Add(ui => ui.Send(new Key(expression[0])));
        steps.Add(ui => { UiContractActions.FinishTyping(ui, expression); ui.Send(Key.Enter); });
        steps.Add(ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            if (error)
            {
                Assert.Contains("Fehler an Position", ui.MessageText);
                Assert.DoesNotContain("Exception", ui.MessageText);
                Assert.Equal("7", ui.CurrentCell.Contents);
                Assert.Equal(7, ui.CurrentCell.Value);
            }
            else
            {
                Assert.DoesNotContain("Fehler", ui.MessageText);
                Assert.Equal(expression, ui.CurrentCell.Contents);
                FormulaContractCases.AssertNumeric(id, offer.GetProperty("oracle").GetDouble(), ui.CurrentCell.Value);
                Assert.Contains("[", ui.GridText.Split(Environment.NewLine)[1]);
                Assert.Contains("AutoCalc: ON", ui.StatusText);
            }
        });
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(steps.ToArray());
    }
}
