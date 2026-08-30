using Terminal.Gui.Drawing;

namespace MicroCalc.Tui.Tests;

public sealed class GridColorSchemeTests
{
    [Fact]
    public void Create_UsesContrastingColorsForReadOnlyGridText()
    {
        var scheme = GridColorScheme.Create();

        Assert.Equal(Color.Black, scheme.Normal.Foreground);
        Assert.Equal(Color.Gray, scheme.Normal.Background);
        Assert.Equal(Color.Black, scheme.ReadOnly.Foreground);
        Assert.Equal(Color.Gray, scheme.ReadOnly.Background);
        Assert.NotEqual(scheme.ReadOnly.Foreground, scheme.ReadOnly.Background);
    }

    [Fact]
    public void Create_KeepsHighlightedGridTextDistinct()
    {
        var scheme = GridColorScheme.Create();

        Assert.Equal(Color.White, scheme.Focus.Foreground);
        Assert.Equal(Color.Blue, scheme.Focus.Background);
        Assert.Equal(Color.White, scheme.Active.Foreground);
        Assert.Equal(Color.Blue, scheme.Active.Background);
        Assert.NotEqual(scheme.Focus.Foreground, scheme.Focus.Background);
    }
}
