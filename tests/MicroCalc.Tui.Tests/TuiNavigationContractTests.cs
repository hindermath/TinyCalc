using MicroCalc.Core.Model;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiNavigationContractTests
{
    public static IEnumerable<object[]> Cases()
    {
        foreach (var name in new[] { "Up", "Ctrl-E", "Down", "Ctrl-X", "Ctrl-J", "Right", "Ctrl-D", "Ctrl-M", "Enter", "Ctrl-G", "Left", "Ctrl-S", "Ctrl-A" })
        {
            var direction = name is "Up" or "Ctrl-E" ? "up" : name is "Down" or "Ctrl-X" or "Ctrl-J" ? "down"
                : name is "Left" or "Ctrl-S" or "Ctrl-A" ? "left" : "right";
            yield return [name, "B2", direction switch { "up" => "B1", "down" => "B3", "left" => "A2", _ => "C2" }, "interior"];
            yield return [name, direction switch { "up" => "B1", "down" => "B21", "left" => "A2", _ => "G2" },
                direction switch { "up" => "B21", "down" => "B1", "left" => "G1", _ => "A3" }, "edge"];
        }
    }

    [Theory]
    [MemberData(nameof(Cases))]
    [Trait("Contract", "Navigation")]
    public void EveryAlias_MovesInsideHistoricalGrid(string name, string from, string expected, string boundary)
    {
        Assert.Contains(boundary, new[] { "interior", "edge" });
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => UiContractActions.NavigateTo(ui, Parse(from)),
            ui => ui.Send(UiContractActions.KeyNamed(name)), ui =>
            {
                Assert.Equal(Parse(expected), ui.Address);
                Assert.StartsWith(expected + "  ", ui.StatusText);
                Assert.Same(ui.Root, ui.CurrentView);
                Assert.Equal(string.Empty, ui.CurrentCell.Contents);
            });
    }

    private static CellAddress Parse(string value) => new(value[0], int.Parse(value[1..], System.Globalization.CultureInfo.InvariantCulture));
}
