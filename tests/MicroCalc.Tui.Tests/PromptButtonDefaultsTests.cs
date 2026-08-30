using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

public sealed class PromptButtonDefaultsTests
{
    [Fact]
    public void SetPromptButtonDefaults_RoutesEnterFromTextFieldToOk()
    {
        using var dialog = new Dialog();
        var textField = new TextField();
        var ok = new Button { Text = "OK", IsDefault = true };
        var cancel = new Button { Text = "Cancel", IsDefault = false };
        var okAccepted = false;
        ok.Accepting += (_, args) =>
        {
            okAccepted = true;
            args.Handled = true;
        };

        dialog.Add(textField);
        dialog.AddButton(ok);
        dialog.AddButton(cancel);

        Program.SetPromptButtonDefaults(dialog, ok, cancel);
        var enterCommands = textField.KeyBindings.GetCommands(Key.Enter);
        var handled = textField.InvokeCommand(Command.Accept);

        Assert.True(ok.IsDefault);
        Assert.False(cancel.IsDefault);
        Assert.Same(ok, dialog.DefaultAcceptView);
        Assert.Contains(Command.Accept, enterCommands);
        Assert.True(handled);
        Assert.True(okAccepted);
    }
}
