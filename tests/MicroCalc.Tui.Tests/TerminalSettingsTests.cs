namespace MicroCalc.Tui.Tests;

public sealed class TerminalSettingsTests
{
    [Fact]
    public void OnlyDarwinPendingInputState_IsExcludedFromConfiguration()
    {
        const string baseline = "gfmt1:cflag=4b00:lflag=5cb:ispeed=9600:ospeed=9600\n";
        Assert.Equal(TerminalSettings.Configuration(baseline), TerminalSettings.Configuration(baseline.Replace("lflag=5cb", "lflag=200005cb")));
        foreach (var change in new[] { baseline.Replace("5cb", "5c3"), baseline.Replace("9600", "19200"), baseline.Replace("4b00", "4b01") })
            Assert.NotEqual(TerminalSettings.Configuration(baseline), TerminalSettings.Configuration(change));
        Assert.Throws<InvalidDataException>(() => TerminalSettings.Configuration("gfmt1:lflag=bad;command"));
    }

    [Fact]
    public void DifferentColorsAlone_DoNotProveReadableContrast()
    {
        Assert.Equal(21, TerminalSettings.Contrast(0xffffff, 0), 8);
        Assert.Equal(1, TerminalSettings.Contrast(0x888888, 0x888888), 8);
        Assert.True(TerminalSettings.Contrast(0x888888, 0x999999) < 4.5);
    }
}
