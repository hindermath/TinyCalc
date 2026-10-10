using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiEditingContractTests
{
    public static IEnumerable<object[]> PrintableAscii() => Enumerable.Range(32, 95).Select(code => new object[] { code });

    [Theory]
    [MemberData(nameof(PrintableAscii))]
    [Trait("Contract", "Editing")]
    public void EveryAsciiCharacter_HasItsOwnGridContext(int code)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key((char)code)), ui =>
        {
            var dialog = Assert.IsType<Dialog>(ui.CurrentView);
            if (code == '/')
            {
                Assert.Equal("Commands", dialog.Title.ToString());
                Assert.Empty(LegacyProgramUiAdapter.Descendants(dialog).OfType<TextField>());
            }
            else
            {
                Assert.Equal("Edit A1", dialog.Title.ToString());
                var input = UiContractActions.Input(ui);
                Assert.Equal(((char)code).ToString(), input.Text.ToString());
                Assert.True(input.HasFocus);
            }
            ui.Send(Key.Esc);
        }, ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.Equal(string.Empty, ui.CurrentCell.Contents);
        });
    }

    [Theory]
    [InlineData("8/2", 4)]
    [InlineData("hello/world", 0)]
    [Trait("Contract", "Editing")]
    public void EditorSlash_IsLiteralAndNeverOpensPalette(string text, double value)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key(text[0])), ui =>
        {
            UiContractActions.FinishTyping(ui, text);
            Assert.Equal("Edit A1", ui.CurrentView!.Title.ToString());
            ui.Send(Key.Enter);
        }, ui =>
        {
            Assert.Equal(text, ui.CurrentCell.Contents);
            Assert.Equal(value, ui.CurrentCell.Value);
            Assert.Same(ui.Root, ui.CurrentView);
        });
    }

    public static IEnumerable<object[]> EditorAliases()
    {
        foreach (var name in new[] { "Ctrl-S", "Ctrl-D", "Ctrl-A", "Ctrl-F", "DEL", "Ctrl-G", "Ctrl-V", "Ins" })
            foreach (var edge in new[] { false, true }) yield return [name, edge];
    }

    [Theory]
    [MemberData(nameof(EditorAliases))]
    [Trait("Contract", "EditorAlias")]
    public void EveryHistoricalAlias_PreservesCaretContentsAndMode(string name, bool edge)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key('a')), ui =>
        {
            UiContractActions.FinishTyping(ui, "abc");
            ui.Send(Key.Home);
            var start = edge ? name is "Ctrl-D" or "Ctrl-F" or "Ctrl-G" or "Ctrl-V" or "Ins" ? 3 : 0 : 1;
            for (var i = 0; i < start; i++) ui.Send(Key.CursorRight);
            var input = UiContractActions.Input(ui);
            Assert.Equal(start, input.InsertionPoint);
            ui.Send(UiContractActions.KeyNamed(name));
            var expectedCaret = name switch
            {
                "Ctrl-S" or "DEL" => Math.Max(0, start - 1),
                "Ctrl-D" => Math.Min(3, start + 1), "Ctrl-A" => 0, "Ctrl-F" => 3, _ => start,
            };
            Assert.Equal(expectedCaret, input.InsertionPoint);
            var expectedText = name switch
            {
                "DEL" when !edge => "bc", "Ctrl-G" when !edge => "ac", _ => "abc",
            };
            if (name is "Ctrl-V" or "Ins")
            {
                ui.Send(new Key('Z'));
                expectedText = edge ? "abcZ" : "aZc";
            }
            Assert.Equal(expectedText, input.Text.ToString());
            Assert.True(input.HasFocus);
            ui.Send(Key.Esc);
        }, ui => Assert.Equal(string.Empty, ui.CurrentCell.Contents));
    }
}
