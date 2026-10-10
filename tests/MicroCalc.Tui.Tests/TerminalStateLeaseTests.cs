namespace MicroCalc.Tui.Tests;

public sealed class TerminalStateLeaseTests
{
    [Fact]
    public void FinalRestoreRunsAfterLateDriverProcessExitHook()
    {
        var calls = new List<string[]>();
        using var lease = new TerminalStateLease(args => { calls.Add(args); return args[0] == "-g" ? "gfmt1:cflag=4b00:iflag=2b02\n" : string.Empty; });
        Action? onExit = null;
        lease.RegisterFinalRestore(callback => onExit = callback);
        lease.Dispose();
        Assert.NotNull(onExit);
        onExit();
        Assert.Equal(3, calls.Count);
        Assert.Equal(calls[1], calls[2]);
    }

    [Fact]
    public void CapturesBeforeDriverAndRestoresExactSnapshotOnce()
    {
        var calls = new List<string[]>();
        var lease = new TerminalStateLease(args => { calls.Add(args); return args[0] == "-g" ? "gfmt1:cflag=4b00:iflag=2b02\n" : string.Empty; });
        Assert.Equal(new[] { "-g" }, Assert.Single(calls));
        lease.Dispose(); lease.Dispose();
        Assert.Equal(2, calls.Count);
        Assert.Equal(new[] { "gfmt1:cflag=4b00:iflag=2b02" }, calls[1]);
    }

    [Theory]
    [InlineData("")]
    [InlineData("-a")]
    [InlineData("gfmt1:bad;command")]
    [InlineData("gfmt1:state\nsecond-line")]
    public void InvalidSnapshot_NeverBecomesAProcessArgument(string snapshot)
    {
        var calls = 0;
        Assert.Throws<InvalidDataException>(() => new TerminalStateLease(_ => { calls++; return snapshot; }));
        Assert.Equal(1, calls);
    }
}
