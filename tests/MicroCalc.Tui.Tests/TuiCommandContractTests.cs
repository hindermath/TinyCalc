using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiCommandContractTests
{
    public static IEnumerable<object[]> Routes()
    {
        foreach (var command in new[] { "Load", "Save", "Recalculate", "Print", "Format", "AutoCalc", "Help", "Clear", "Quit" })
            foreach (var route in new[] { "Menu", "Palette" }) yield return [$"CMD-{command.ToLowerInvariant()}-{route.ToLowerInvariant()}", command, route];
    }

    [Theory]
    [MemberData(nameof(Routes))]
    [Trait("Contract", "Command")]
    public void EveryCommand_UsesEachActualOfferedRoute(string id, string command, string route)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        var steps = new List<Action<LegacyProgramUiAdapter>> { _ => proof.BeginExecution() };
        if (route == "Menu") steps.Add(ui => UiContractActions.SelectMenu(ui, command));
        else
        {
            steps.Add(ui => ui.Send(new Key('/')));
            steps.Add(ui => UiContractActions.SelectButton(ui, command switch { "Recalculate" => "Recalc", "AutoCalc" => "Auto", _ => command }));
        }
        if (command != "Quit")
        {
            steps.Add(ui => CheckAction(ui, command));
            steps.Add(ui => Assert.Same(ui.Root, ui.CurrentView));
            steps.Add(ui => UiPathObservation.Record(proof, ui, "Grid"));
        }
        if (command == "Quit") adapter.RunToExit(steps.ToArray());
        else adapter.Run(steps.ToArray());
        if (command == "Quit") { Assert.Empty(adapter.App.SessionStack!); UiPathObservation.Record(proof, adapter, "Terminal"); }
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

    [Theory]
    [InlineData("CMD-letter-q", 'q', "Quit")]
    [InlineData("CMD-letter-l", 'l', "Load")]
    [InlineData("CMD-letter-s", 's', "Save")]
    [InlineData("CMD-letter-r", 'r', "Recalculate")]
    [InlineData("CMD-letter-p", 'p', "Print")]
    [InlineData("CMD-letter-f", 'f', "Format")]
    [InlineData("CMD-letter-a", 'a', "AutoCalc")]
    [Trait("Contract", "CommandLetter")]
    public void HistoricalLetters_AreCommandsOnlyInsidePalette(string id, char letter, string command)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        var steps = new List<Action<LegacyProgramUiAdapter>>
        {
            ui => { proof.BeginExecution(); ui.Send(new Key('/')); },
            ui => ui.Send(new Key(letter)),
        };
        if (command != "Quit") steps.Add(ui => CheckAction(ui, command));
        if (command != "Quit") steps.Add(ui => UiPathObservation.Record(proof, ui, "Grid"));
        if (command == "Quit") adapter.RunToExit(steps.ToArray());
        else adapter.Run(steps.ToArray());
        if (command == "Quit") { Assert.Empty(adapter.App.SessionStack!); UiPathObservation.Record(proof, adapter, "Terminal"); }
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

    [Theory]
    [InlineData("CMD-ctrl-q")]
    [Trait("Contract", "Command")]
    public void QuitShortcut_PublishesActualExit(string id)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        adapter.RunToExit(ui => { proof.BeginExecution(); ui.Send(Key.Q.WithCtrl); });
        Assert.Empty(adapter.App.SessionStack!);
        UiPathObservation.Record(proof, adapter, "Terminal");
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

    private static void CheckAction(LegacyProgramUiAdapter ui, string command)
    {
        if (command is "Recalculate" or "AutoCalc")
        {
            Assert.Same(ui.Root, ui.CurrentView);
            if (command == "AutoCalc")
            {
                Assert.False(ui.AutoCalc);
                Assert.Contains("AutoCalc: OFF", ui.StatusText);
            }
            else Assert.Equal("Recalculate abgeschlossen.", ui.MessageText);
            return;
        }
        Assert.True(ui.CurrentView is Dialog, $"{command}: {ui.MessageText}");
        Assert.Equal(command, ui.CurrentView!.Title.ToString());
        if (command is "Load" or "Save" or "Print" or "Format") Assert.NotNull(UiContractActions.Input(ui));
        if (command == "Help") Assert.Contains(LegacyProgramUiAdapter.Descendants(ui.CurrentView), view => view.Text.ToString().Contains("MicroCalc", StringComparison.OrdinalIgnoreCase));
        ui.Send(Key.Esc);
    }
}
