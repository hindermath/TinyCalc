namespace MicroCalc.Tui.Tests;

public sealed class TerminalScreenTests
{
    [Fact]
    public void FragmentedQueries_DoNotMoveCursorOrSupplyVisibleText()
    {
        var screen = new TerminalScreen(80,24);
        screen.Feed("\u001b[3;5H\u001b[?");
        Assert.False(screen.IsComplete);
        screen.Feed("uX");
        Assert.Equal('X',screen.At(4,2).Character);
        Assert.DoesNotContain("?u",screen.Text);
    }
    [Fact]
    public void ErasedOrOverwrittenText_IsNotVisibleProof()
    {
        var screen = new TerminalScreen(80, 24);
        screen.Feed("A1  Numeric  AutoCalc: ON\u001b[2J\u001b[Hblank");
        Assert.DoesNotContain("AutoCalc", screen.Text);
        screen.Feed("\u001b[Hxxxxx");
        Assert.StartsWith("xxxxx", screen.Text);
    }

    [Fact]
    public void CoordinatesColorsAndAlternateBuffer_AreStateNotStreamMatches()
    {
        var screen = new TerminalScreen(80, 24);
        screen.Feed("shell\u001b[?1049h\u001b[2J\u001b[3;5H\u001b[97;44mA1\u001b[?25l");
        Assert.Equal('A', screen.At(4, 2).Character);
        Assert.NotEqual(screen.At(4, 2).Foreground, screen.At(4, 2).Background);
        Assert.False(screen.CursorVisible);
        Assert.True(screen.AlternateBuffer);
        screen.Feed("\u001b[?1049l\u001b[?25h");
        Assert.False(screen.AlternateBuffer);
        Assert.True(screen.CursorVisible);
        Assert.StartsWith("shell", screen.Text);
    }

    [Fact]
    public void IncompleteControlSequences_AreNotSilentlyDiscarded()
    {
        var screen = new TerminalScreen(80, 24);
        screen.Feed("\u001b[");
        Assert.False(screen.IsComplete);
        screen.Feed("2J");
        Assert.True(screen.IsComplete);
    }

    [Fact]
    public void UnsupportedScreenMutation_CannotYieldAcceptance()
    {
        var screen = new TerminalScreen(80, 24);
        Assert.Throws<InvalidDataException>(() => screen.Feed("\u001b[7S"));
    }
}
