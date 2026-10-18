using System.Diagnostics;
using MicroCalc.ContractEvidence;

namespace MicroCalc.Tui.Tests;

/// <summary>Prüft nur PTY-Adapter-Synchronisation, keine Produktabnahme. / Tests adapter synchronization, not product acceptance.</summary>
public sealed class PtyCaptureAdapterTests
{
    /// <summary>Verzögerte echte Ausgabe muss vor dem Snapshot eintreffen. / Delayed real output must precede the snapshot.</summary>
    [Fact]
    [Trait("Contract", "MacOsPtyAdapter")]
    public async Task DelayedStates_AreCapturedBeforeInputAdvances()
    {
        if (!OperatingSystem.IsMacOS()) return; // Native Expect proof is macOS-only, not cross-platform product evidence.
        await RunFixture("delayed", (exit, output, directory) =>
        {
            Assert.True(exit == 0, output);
            Assert.Contains("MicroCalc .NET 10", File.ReadAllText(Path.Combine(directory, "grid.bin")));
            var grid = new TerminalScreen(80, 24);
            grid.Feed(File.ReadAllText(Path.Combine(directory, "grid.bin")));
            Assert.True(grid.IsComplete);
            Assert.Contains("File", grid.Text);
            Assert.Contains("Edit A1", File.ReadAllText(Path.Combine(directory, "editor.bin")));
            Assert.Contains("7.00", File.ReadAllText(Path.Combine(directory, "committed.bin"),
                new System.Text.UTF8Encoding(false, true)));
            Assert.Contains("PTY_RESTORED|0", File.ReadAllText(Path.Combine(directory, "restored.bin")));
        });
    }

    /// <summary>Fehlende Zustände und Prozessfehler bleiben blockierend. / Missing states and process failures remain blocking.</summary>
    /// <param name="mode">Fest benannter synthetischer Fehlerfall. / Explicit synthetic failure case.</param>
    [Theory]
    [InlineData("missing-grid")]
    [InlineData("missing-value")]
    [InlineData("early-exit")]
    [InlineData("bad-exit")]
    [InlineData("invalid-utf8")]
    [InlineData("partial-ansi")]
    [Trait("Contract", "MacOsPtyAdapter")]
    public async Task InvalidProcess_CannotProduceSuccessfulCapture(string mode)
    {
        if (!OperatingSystem.IsMacOS()) return;
        await RunFixture(mode, (exit, output, _) =>
        {
            Assert.NotEqual(0, exit);
            Assert.Contains("PTY_CAPTURE_FAIL:", output);
        });
    }

    private static async Task RunFixture(string mode, Action<int, string, string> verify)
    {
        Assert.Contains(mode, new[] { "delayed", "missing-grid", "missing-value", "early-exit", "bad-exit", "invalid-utf8", "partial-ansi" });
        var directory = Path.Combine(Path.GetTempPath(), "tinycalc-pty-adapter-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        try
        {
            var script = Path.Combine(directory, "fixture.sh");
            // DE: Synthetischer Kindprozess prüft ausschließlich den Adapter; niemals als Produkt-Evidence publizieren.
            // EN: This synthetic child tests only the adapter; never publish it as product evidence.
            File.WriteAllText(script, "mode='" + mode + "'\n" + """
                set -eu
                # DE: Ctrl-Q muss den eigenen Prozess erreichen, nicht XON-Flow-Control.
                # EN: The owned process must receive Ctrl-Q, not consume it as XON flow control.
                stty -icanon -echo -ixon min 1 time 0
                [ "$mode" != early-exit ] || exit 0
                if [ "$mode" = delayed ]; then sleep 4; fi
                if [ "$mode" != missing-grid ]; then
                  printf 'MicroCalc .NET 10\nF\033[0mile\n01 G\nA1  Text  AutoCalc: ON\n'
                fi
                IFS= read -r -n 1 key
                [ "$key" = 7 ] || exit 9
                printf '\nEdit A1\nValue:\n'
                IFS= read -r -n 1 key
                if [ "$mode" = delayed ]; then sleep 3; fi
                case "$mode" in
                  missing-value) : ;;
                  invalid-utf8) printf '\n7.00\nA1  Numeric  AutoCalc: ON\342' ;;
                  partial-ansi) printf '\n7.00\nA1  Numeric  AutoCalc: ON\033[' ;;
                  delayed)
                    printf '\n7.00\nA1  Numeric  AutoCalc: ON\342'
                    sleep 1
                    printf '\224\200\n'
                    ;;
                  *) printf '\n7.00\nA1  Numeric  AutoCalc: ON\n' ;;
                esac
                IFS= read -r -n 1 key
                [ "$key" = $'\021' ] || exit 8
                [ "$mode" != bad-exit ] || exit 7
                exit 0
                """ + "\n");
            var start = new ProcessStartInfo("/usr/bin/expect")
            {
                UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true
            };
            foreach (var argument in new[] { Path.Combine(FormulaContractCases.RepositoryRoot,
                "scripts/tests/tui-contract/capture-terminal.exp"), script, directory, "80", "24", "/bin/bash" })
                start.ArgumentList.Add(argument);
            using var process = Process.Start(start)!;
            var stdout = process.StandardOutput.ReadToEndAsync();
            var stderr = process.StandardError.ReadToEndAsync();
            // DE: Dasselbe harte Prozesslimit wie im echten Standard-PTY-Test bleibt bestehen.
            // EN: Preserve the real standard PTY test's hard process deadline.
            using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(25));
            try { await process.WaitForExitAsync(deadline.Token); }
            catch (OperationCanceledException)
            {
                process.Kill(entireProcessTree: true);
                using var cleanup = new CancellationTokenSource(TimeSpan.FromSeconds(5));
                await process.WaitForExitAsync(cleanup.Token);
                throw new TimeoutException("Owned adapter fixture exceeded the unchanged PTY deadline.");
            }
            verify(process.ExitCode, (await stdout) + (await stderr), directory);
        }
        finally { Directory.Delete(directory, recursive: true); }
    }
}
