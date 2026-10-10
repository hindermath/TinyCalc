using MicroCalc.Core.Model;
using Terminal.Gui.Input;
using System.Diagnostics;
using System.Text.Json.Nodes;
using MicroCalc.ContractEvidence;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiLifecycleContractTests
{
    [Theory]
    [InlineData("APP-terminal-restoration")]
    public Task ActualTerminalRestoration_BindsOwnedProcess(string id) => TuiTerminalContractTests.Verify(id, 80, 24, "restore");
    [Theory]
    [InlineData("APP-smoke-ok", false)]
    [InlineData("APP-smoke-fail", true)]
    [Trait("Contract", "SmokeProcess")]
    public async Task ActualSmokeCli_BindsExitAndExactOutput(string id, bool missingHelp)
    {
        var proof = new ExecutedPathProof(id);
        using var directory = new OwnedContractDirectory();
        var configuration = AppContext.BaseDirectory.Contains($"{Path.DirectorySeparatorChar}Release{Path.DirectorySeparatorChar}", StringComparison.Ordinal) ? "Release" : "Debug";
        var source = Path.Combine(FormulaContractCases.RepositoryRoot, "src/MicroCalc.Tui/bin", configuration, "net10.0");
        // DE: Fehlende Hilfe nur in einer eigenen Binary-Kopie simulieren; laufende Benutzer-Apps bleiben unberührt.
        // EN: Simulate missing help only in an owned binary copy; leave running user applications untouched.
        foreach (var file in Directory.GetFiles(source, "*", SearchOption.AllDirectories))
        {
            if (missingHelp && Path.GetFileName(file) == "CALC.HLP") continue;
            var target = Path.Combine(directory.Path, Path.GetRelativePath(source, file));
            Directory.CreateDirectory(Path.GetDirectoryName(target)!);
            File.Copy(file, target);
        }
        var start = new ProcessStartInfo("dotnet") { UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true, WorkingDirectory = directory.Path };
        start.ArgumentList.Add(Path.Combine(directory.Path, "MicroCalc.Tui.dll"));
        start.ArgumentList.Add("--smoke");
        proof.BeginExecution();
        using var process = Process.Start(start)!;
        var output = process.StandardOutput.ReadToEndAsync();
        var errors = process.StandardError.ReadToEndAsync();
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(25));
        try { await process.WaitForExitAsync(deadline.Token); }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            using var cleanup = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await process.WaitForExitAsync(cleanup.Token);
            throw new TimeoutException("Smoke process exceeded deadline.");
        }
        var stdout = await output; var stderr = await errors;
        Assert.Equal(missingHelp ? 1 : 0, process.ExitCode);
        if (!missingHelp) { Assert.Equal("SMOKE_OK" + Environment.NewLine, stdout); Assert.Empty(stderr); }
        else { Assert.Empty(stdout); Assert.StartsWith("SMOKE_FAIL" + Environment.NewLine, stderr); Assert.Contains("file not found", stderr); Assert.DoesNotContain("Exception", stderr); }
        Assert.True(proof.Observe("actual-smoke-process", new JsonObject { ["focus"] = "Terminal", ["error"] = missingHelp, ["value"] = missingHelp ? 1 : 0 },
            new JsonObject { ["focus"] = "Terminal", ["error"] = process.ExitCode != 0, ["value"] = process.ExitCode }).Accepted);
        // DE: Private temporäre Pfade nicht in den textfirst Beleg übernehmen; Exit/Fehler wurden davor exakt geprüft.
        // EN: Do not copy private temporary paths to text-first proof; exit/error were checked exactly above.
        Assert.NotNull(proof.Complete(missingHelp ? "SMOKE_FAIL; missing owned help asset" : stdout.TrimEnd(), "Noninteractive process returned to terminal"));
    }

    [Theory]
    [InlineData("APP-interactive-start")]
    [InlineData("GRID-bounds-A1-G21")]
    [InlineData("GRID-headers-A-G-01-21")]
    [InlineData("GRID-active-cell")]
    [InlineData("GRID-type-status")]
    [InlineData("GRID-autocalc-status")]
    [InlineData("GRID-edge-render")]
    [Trait("Contract", "Lifecycle")]
    public void InteractiveGrid_HasAllHeadersRowsSelectionAndStatus(string id)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui =>
        {
            proof.BeginExecution();
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.Equal(new CellAddress('A', 1), ui.Address);
            var lines = ui.GridText.Split(Environment.NewLine);
            Assert.Equal(22, lines.Length);
            foreach (var column in "ABCDEFG") Assert.Contains(column.ToString(), lines[0]);
            for (var row = 1; row <= 21; row++) Assert.StartsWith(row.ToString("00") + " ", lines[row]);
            Assert.Contains("[", lines[1]);
            Assert.Contains("]", lines[1]);
            Assert.Equal("A1  Text  AutoCalc: ON", ui.StatusText);
            if (id is "GRID-bounds-A1-G21" or "GRID-edge-render")
            {
                UiContractActions.NavigateTo(ui, new CellAddress('G', 21));
                Assert.Equal(new CellAddress('G', 21), ui.Address);
                Assert.Contains("[", ui.GridText.Split(Environment.NewLine)[21]);
                Assert.Contains("G21", ui.StatusText);
            }
            UiPathObservation.Record(proof, ui, "Grid", string.Empty, 0);
        });
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }

    [Fact]
    [Trait("Contract", "Lifecycle")]
    public void ActiveNumericCell_DoesNotLoseLastDisplayedDigit()
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key('7')), ui => ui.Send(Key.Enter), ui =>
        {
            Assert.Contains("7.00", ui.GridText.Split(Environment.NewLine)[1]);
            Assert.Contains("A1", ui.StatusText);
            Assert.DoesNotContain("Text", ui.StatusText);
        });
    }

    [Theory]
    [InlineData("APP-ordered-quit")]
    [Trait("Contract", "Lifecycle")]
    public void QuitShortcut_EndsOwnedInteractiveLoop(string id)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        adapter.RunToExit(ui => { proof.BeginExecution(); ui.Send(Key.Q.WithCtrl); });
        Assert.Empty(adapter.App.SessionStack!);
        UiPathObservation.Record(proof, adapter, "Terminal");
        Assert.NotNull(proof.Complete(adapter.GridText, adapter.StatusText));
    }
}
