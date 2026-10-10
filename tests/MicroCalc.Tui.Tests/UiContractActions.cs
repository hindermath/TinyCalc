using MicroCalc.Core.Model;
using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

internal static class UiContractActions
{
    internal static TextField Input(LegacyProgramUiAdapter ui) => Assert.Single(
        LegacyProgramUiAdapter.Descendants(Assert.IsType<Dialog>(ui.CurrentView)).OfType<TextField>());

    internal static void NavigateTo(LegacyProgramUiAdapter ui, CellAddress target)
    {
        // DE: Testvorbereitung nutzt dieselben realen Pfeiltasten, keine Engine-Zuweisung.
        // EN: Test setup uses the same actual arrow keys, not engine state assignment.
        while (ui.Address.Column < target.Column) ui.Send(Key.CursorRight);
        while (ui.Address.Column > target.Column) ui.Send(Key.CursorLeft);
        while (ui.Address.Row < target.Row) ui.Send(Key.CursorDown);
        while (ui.Address.Row > target.Row) ui.Send(Key.CursorUp);
    }

    internal static void FinishTyping(LegacyProgramUiAdapter ui, string text)
    {
        ui.Send(Key.End);
        foreach (var character in text.Skip(1)) ui.Send(new Key(character));
        Assert.Equal(text, Input(ui).Text.ToString());
    }

    internal static void ReplacePrompt(LegacyProgramUiAdapter ui, string text)
    {
        ui.Send(Key.Home);
        ui.Send(Key.End.WithShift);
        ui.Send(Key.Backspace);
        foreach (var character in text) ui.Send(new Key(character));
        Assert.Equal(text, Input(ui).Text.ToString());
    }

    internal static void SelectButton(LegacyProgramUiAdapter ui, string text)
    {
        FocusButton(ui, text);
        ui.Send(Key.Enter);
    }

    internal static void FocusButton(LegacyProgramUiAdapter ui, string text)
    {
        var buttons = Assert.IsType<Dialog>(ui.CurrentView).Buttons.ToArray();
        var matches = buttons.Where(button => button.Text.ToString().Replace("_", string.Empty, StringComparison.Ordinal) == text).ToArray();
        Assert.True(matches.Length == 1, $"Button {text}; actual buttons: {string.Join(" | ", buttons.Select(button => button.Text.ToString()))}");
        var button = matches[0];
        for (var i = 0; !button.HasFocus && i < 40; i++) ui.Send(Key.Tab);
        Assert.True(button.HasFocus);
    }

    internal static void SelectMenu(LegacyProgramUiAdapter ui, string text)
    {
        var bar = Assert.Single(LegacyProgramUiAdapter.Descendants(ui.Root).OfType<MenuBar>());
        var group = text is "Load" or "Save" or "Print" or "Quit" ? 0 : text == "Help" ? 2 : 1;
        ui.Send(bar.Key);
        for (var i = 0; i < group; i++) ui.Send(Key.CursorRight);
        var heading = Assert.IsType<MenuBarItem>(bar.SubViews.OfType<MenuBarItem>().ElementAt(group));
        var menu = heading.PopoverMenu!.Root!;
        var item = Assert.Single(LegacyProgramUiAdapter.Descendants(menu).OfType<MenuItem>(),
            item => item.Title.ToString().Replace("_", string.Empty, StringComparison.Ordinal) == text);
        for (var i = 0; !item.HasFocus && i < 30; i++) ui.Send(Key.CursorDown);
        Assert.True(item.HasFocus, $"Menu command did not gain focus: {text}");
        ui.Send(Key.Enter);
    }

    internal static Key KeyNamed(string name) => name switch
    {
        "Up" => Key.CursorUp, "Down" => Key.CursorDown,
        "Right" => Key.CursorRight, "Left" => Key.CursorLeft,
        "Enter" => Key.Enter, "DEL" => Key.Backspace, "Ins" => Key.InsertChar,
        _ when name.StartsWith("Ctrl-", StringComparison.Ordinal) => new Key(char.ToLowerInvariant(name[^1])).WithCtrl,
        _ => throw new ArgumentException("Unknown contract key.", nameof(name)),
    };
}
