using System.Diagnostics;
using System.Text;
using System.Text.Json.Nodes;
using MicroCalc.ContractEvidence;
using Terminal.Gui.Input;
using Terminal.Gui.Views;
using Terminal.Gui.Drawing;
using Terminal.Gui.Drivers;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiTerminalContractTests
{
    public static IEnumerable<object[]> Cases()
    {
        foreach (var size in new[] { (Width: 80, Height: 24), (Width: 120, Height: 40) })
            foreach (var scenario in new[] { "visible-grid", "focus", "contrast", "restore" })
                yield return [$"TERM-{size.Width}x{size.Height}-{scenario}", size.Width, size.Height, scenario];
    }

    [Theory]
    [MemberData(nameof(Cases))]
    [Trait("Contract", "MacOsPty")]
    public async Task ActualProcessTerminal_RequiresVisibleStateAndRestoration(string id, int width, int height, string scenario)
        => await Verify(id, width, height, scenario);

    [Theory]
    [InlineData(80, 24)]
    [InlineData(120, 40)]
    public void FrameworkTerminal_UsesActualRenderedBufferAndInput(int width, int height)
    {
        var directory = Path.Combine(FormulaContractCases.RepositoryRoot,
            "tests/MicroCalc.Tui.Tests/TestResults/terminal-publication-fixtures", Guid.NewGuid().ToString("N"));
        try
        {
            VerifyFramework($"TERM-{width}x{height}-contrast", width, height, "contrast", true, directory);
            Assert.Single(Directory.GetFiles(directory, "path-result.json", SearchOption.AllDirectories));
            var rawArtifacts = Directory.GetFiles(directory, "native-*", SearchOption.AllDirectories);
            Assert.Equal(6, rawArtifacts.Length);
            Assert.All(rawArtifacts, path => Assert.True(new FileInfo(path).Length > 0));
        }
        finally
        {
            if (Directory.Exists(directory)) Directory.Delete(directory, recursive: true);
        }
    }

    [Theory]
    [InlineData(SizeDetectionMode.Polling)]
    [InlineData(SizeDetectionMode.AnsiQuery)]
    public void FrameworkTerminal_RestoresOriginalSizeDetection(SizeDetectionMode configured)
    {
        var original = Driver.SizeDetection;
        var originalIo = Environment.GetEnvironmentVariable("DisableRealDriverIO");
        try
        {
            Driver.SizeDetection = configured;
            Environment.SetEnvironmentVariable("DisableRealDriverIO", "contract-test-original");
            using (var adapter = new LegacyProgramUiAdapter(80, 24))
                adapter.Run(ui =>
                {
                    Assert.Equal(SizeDetectionMode.AnsiQuery, Driver.SizeDetection);
                    Assert.Equal("1", Environment.GetEnvironmentVariable("DisableRealDriverIO"));
                    Assert.Equal(80, ui.App.Driver!.Cols);
                    Assert.Equal(24, ui.App.Driver.Rows);
                });
            Assert.Equal(configured, Driver.SizeDetection);
            Assert.Equal("contract-test-original", Environment.GetEnvironmentVariable("DisableRealDriverIO"));
        }
        finally
        {
            Driver.SizeDetection = original;
            Environment.SetEnvironmentVariable("DisableRealDriverIO", originalIo);
        }
    }

    [Fact]
    [Trait("Contract", "MacOsAccessibilitySupplement")]
    public async Task MacOsSupplement_ObservesNavigationCommandsHelpFilesAndErrors()
    {
        // DE: Ergänzender macOS-Nachweis, keine Windows-/Linux-Pflicht und niemals VoiceOver-Ersatz.
        // EN: Supplementary macOS proof, not a Windows/Linux obligation and never a VoiceOver substitute.
        if (!OperatingSystem.IsMacOS()) return;
        var root = FormulaContractCases.RepositoryRoot;
        var directory = Path.Combine(root, "tests/MicroCalc.Tui.Tests/TestResults/pty", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        var start = new ProcessStartInfo("/usr/bin/expect") { UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true };
        foreach (var argument in new[] { Path.Combine(root, "scripts/tests/tui-contract/capture-terminal.exp"),
            Path.Combine(AppContext.BaseDirectory, "MicroCalc.Tui.dll"), directory, "80", "24", "dotnet", "accessibility" })
            start.ArgumentList.Add(argument);
        using var process = Process.Start(start)!;
        var stdout = process.StandardOutput.ReadToEndAsync();
        var stderr = process.StandardError.ReadToEndAsync();
        using var deadline = new CancellationTokenSource(TimeSpan.FromSeconds(30));
        try { await process.WaitForExitAsync(deadline.Token); }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            using var cleanup = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await process.WaitForExitAsync(cleanup.Token);
            throw new TimeoutException("Owned accessibility PTY exceeded deadline.");
        }
        Assert.True(process.ExitCode == 0, $"PTY adapter exit {process.ExitCode}: {await stderr}; {await stdout}");
        string Read(string phase)
        {
            var screen = new TerminalScreen(80, 24);
            screen.Feed(File.ReadAllText(Path.Combine(directory, phase + ".bin"), new UTF8Encoding(false, true)));
            Assert.True(screen.IsComplete);
            File.WriteAllText(Path.Combine(directory, phase + ".txt"), screen.Text);
            return screen.Text;
        }
        Assert.Contains("B1  Text", Read("navigation"));
        Assert.Contains("Select command", Read("commands"));
        Assert.Contains("Recalculate abgeschlossen.", Read("recalculated"));
        Assert.Contains("Load", Read("file-dialog"));
        Assert.Contains("Datei:", Read("file-dialog"));
        Assert.Contains("sheet.mcalc.json", Read("file-error"));
        Assert.DoesNotContain("Datei:", Read("file-error"));
        Assert.Contains("INTRODUCTION", Read("help"));
        Assert.Contains("Page 1/", Read("help"));
        Assert.Contains("7.00", Read("committed"));
        Assert.Contains("PTY_RESTORED|0", Read("restored"));
        Assert.Equal(TerminalSettings.Configuration(File.ReadAllText(Path.Combine(directory, "stty-before.txt"))),
            TerminalSettings.Configuration(File.ReadAllText(Path.Combine(directory, "stty-after.txt"))));
        Assert.False(File.Exists(Path.Combine(directory, "sheet.mcalc.json")));
    }

    private static void VerifyFramework(string id, int width, int height, string scenario, bool publish, string? proofDirectory = null)
    {
        // DE: Native CI prüft echte Views/Treiberbuffer; nur macOS ergänzt den separaten Prozess-PTY.
        // EN: Native CI checks real views/driver buffers; only macOS adds the separate process PTY.
        var proof = publish ? new ExecutedPathProof(id) : null;
        using var adapter = new LegacyProgramUiAdapter(width, height);
        var artifacts = new Dictionary<string, byte[]>(StringComparer.Ordinal);
        var gridFocus = "Other";
        string Capture(string phase)
        {
            var driver = adapter.App.Driver!;
            var ansi = driver.ToAnsi();
            var cells = driver.Contents!;
            Assert.Equal(height, cells.GetLength(0));
            Assert.Equal(width, cells.GetLength(1));
            var text = string.Join("\n", Enumerable.Range(0, height).Select(y =>
                string.Concat(Enumerable.Range(0, width).Select(x => cells[y, x].Grapheme ?? " "))));
            // DE: Rohphasen getrennt benennen; grid.txt bleibt dem zusammenfassenden Beleg vorbehalten.
            // EN: Name raw phases separately; grid.txt is reserved for the summary proof.
            artifacts.Add("native-" + phase + ".bin", Encoding.UTF8.GetBytes(ansi));
            artifacts.Add("native-" + phase + ".txt", Encoding.UTF8.GetBytes(text));
            if (scenario == "contrast")
                for (var y = 0; y < height; y++) for (var x = 0; x < width; x++)
                {
                    var cell = cells[y, x];
                    if (!string.IsNullOrWhiteSpace(cell.Grapheme))
                    {
                        Assert.True(cell.Attribute.HasValue);
                        // DE: Der Headless-ANSI-Testterminal nutzt Weiß/Schwarz; reale Defaults belegt nur der PTY.
                        // EN: The headless ANSI test terminal uses white/black; only PTY proves real defaults.
                        var foreground = cell.Attribute.Value.Foreground;
                        var background = cell.Attribute.Value.Background;
                        if (foreground == Color.None) foreground = Color.White;
                        if (background == Color.None) background = Color.Black;
                        Assert.True(TerminalSettings.Contrast((foreground.R << 16) | (foreground.G << 8) | foreground.B,
                            (background.R << 16) | (background.G << 8) | background.B) >= 4.5,
                            $"Native {phase} unreadable at {x},{y}: '{cell.Grapheme}' foreground={foreground} background={background}; default={driver.DefaultAttribute}");
                    }
                }
            return text;
        }
        adapter.RunToExit(ui => { proof?.BeginExecution(); }, ui =>
        {
            Assert.Equal(width, ui.App.Driver!.Cols);
            Assert.Equal(height, ui.App.Driver.Rows);
            var grid = Capture("grid");
            Assert.Contains("MicroCalc .NET 10", grid);
            Assert.Contains("01 ", grid);
            Assert.Contains("A1  Text  AutoCalc: ON", grid);
            ui.Send(new Key('7'));
        }, ui =>
        {
            var editor = Capture("editor");
            Assert.Contains("Edit A1", editor);
            Assert.True(LegacyProgramUiAdapter.Descendants(ui.CurrentView!).OfType<TextField>().Single().HasFocus);
            ui.Send(Key.Enter);
        }, ui =>
        {
            var committed = Capture("committed");
            Assert.DoesNotContain("Edit A1", committed);
            Assert.Contains("7.00", committed);
            Assert.Contains("A1  Numeric  AutoCalc: ON", committed);
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.True(ui.Root.HasFocus);
            gridFocus = UiPathObservation.Focus(ui);
            ui.Send(Key.Q.WithCtrl);
        });
        Assert.Empty(adapter.App.SessionStack!);
        var focus = id == "APP-terminal-restoration" ? "Terminal" : "Grid";
        if (proof is not null)
        {
            Assert.True(proof.Observe("native-rendered-views-and-owned-session-exit",
                new JsonObject { ["focus"] = focus, ["contents"] = "7", ["value"] = 7 },
                new JsonObject { ["focus"] = id == "APP-terminal-restoration" ? UiPathObservation.Focus(adapter) : gridFocus, ["contents"] = adapter.CurrentCell.Contents, ["value"] = adapter.CurrentCell.Value }).Accepted);
            const string status = "Native framework rendering/input and natural owned session exit; not macOS PTY or human proof.";
            Assert.NotNull(proofDirectory is null
                ? proof.Complete(adapter.GridText, status, artifacts)
                : proof.Complete(proofDirectory, adapter.GridText, status, artifacts));
        }
    }

    internal static async Task Verify(string id, int width, int height, string scenario)
    {
        if (!OperatingSystem.IsMacOS())
        {
            VerifyFramework(id, width, height, scenario, true);
            return;
        }
        var proof = new ExecutedPathProof(id);
        var root = FormulaContractCases.RepositoryRoot;
        var directory = Path.Combine(root, "tests/MicroCalc.Tui.Tests/TestResults/pty", Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        var start = new ProcessStartInfo("/usr/bin/expect") { UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true };
        // DE: Die echte Produktkopie im Testoutput erlaubt dem vorhandenen Collector auch Kindprozess-Hits.
        // EN: The actual product copy in test output lets the existing collector include child-process hits.
        foreach (var argument in new[] { Path.Combine(root, "scripts/tests/tui-contract/capture-terminal.exp"),
            Path.Combine(AppContext.BaseDirectory, "MicroCalc.Tui.dll"), directory,
            width.ToString(System.Globalization.CultureInfo.InvariantCulture), height.ToString(System.Globalization.CultureInfo.InvariantCulture), "dotnet" }) start.ArgumentList.Add(argument);
        proof.BeginExecution();
        using var process = Process.Start(start)!;
        var stdout = process.StandardOutput.ReadToEndAsync();
        var stderr = process.StandardError.ReadToEndAsync();
        using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(25));
        try { await process.WaitForExitAsync(timeout.Token); }
        catch (OperationCanceledException)
        {
            process.Kill(entireProcessTree: true);
            using var cleanup = new CancellationTokenSource(TimeSpan.FromSeconds(5));
            await process.WaitForExitAsync(cleanup.Token);
            throw new TimeoutException("Owned PTY exceeded interaction deadline.");
        }
        Assert.True(process.ExitCode == 0, $"PTY adapter exit {process.ExitCode}: {await stderr}; {await stdout}");
        TerminalScreen Read(string phase)
        {
            var screen = new TerminalScreen(width, height);
            screen.Feed(File.ReadAllText(Path.Combine(directory, phase + ".bin"), new UTF8Encoding(false, true)));
            Assert.True(screen.IsComplete);
            return screen;
        }
        var grid = Read("grid");
        Assert.Contains("MicroCalc .NET 10", grid.Text);
        Assert.Contains("A1  Text  AutoCalc: ON", grid.Text);
        Assert.Contains("File", grid.Text);
        Assert.Contains("01 ", grid.Text);
        Assert.Contains("G", grid.Text.Split('\n')[2]);
        var editor = Read("editor");
        Assert.Contains("Edit A1", editor.Text);
        Assert.Contains("Value:", editor.Text);
        var committed = Read("committed");
        Assert.DoesNotContain("Edit A1", committed.Text);
        Assert.Contains("7.00", committed.Text);
        Assert.Contains("A1  Numeric  AutoCalc: ON", committed.Text);
        var restored = Read("restored");
        Assert.False(restored.AlternateBuffer);
        Assert.True(restored.CursorVisible);
        var marker = restored.Text.Split('\n').Single(line => line.Contains("PTY_RESTORED|", StringComparison.Ordinal)).Trim().Split('|');
        Assert.Equal("0", marker[1]);
        Assert.Equal(TerminalSettings.Configuration(File.ReadAllText(Path.Combine(directory, "stty-before.txt"))),
            TerminalSettings.Configuration(File.ReadAllText(Path.Combine(directory, "stty-after.txt"))));
        if (scenario == "contrast")
        {
            // DE: Explizite Treiberfarben prüfen; menschliche Wahrnehmung/VoiceOver bleibt ein eigener Nachweis.
            // EN: Check explicit driver colors; human perception/VoiceOver remains separate proof.
            foreach (var observedScreen in new[] { grid, editor, committed })
            for (var y = 0; y < height; y++) for (var x = 0; x < width; x++)
            {
                var pixel = observedScreen.At(x, y);
                if (!char.IsWhiteSpace(pixel.Character)) Assert.True(TerminalSettings.Contrast(pixel.Foreground, pixel.Background) >= 4.5,
                    $"Unreadable terminal text at {x},{y}: {pixel.Foreground:x6}/{pixel.Background:x6}");
            }
        }
        var focus = id == "APP-terminal-restoration" ? "Terminal" : "Grid";
        var actualFocus = id == "APP-terminal-restoration" ? (restored.AlternateBuffer ? "Grid" : "Terminal")
            : committed.Text.Contains("Edit A1", StringComparison.Ordinal) ? "Editor" : "Grid";
        Assert.True(proof.Observe("real-terminal-visible-state", new JsonObject { ["focus"] = focus, ["contents"] = "7", ["value"] = 7 },
            new JsonObject { ["focus"] = actualFocus, ["contents"] = committed.Text.Contains("7.00", StringComparison.Ordinal) ? "7" : "", ["value"] = committed.Text.Contains("7.00", StringComparison.Ordinal) ? 7 : 0 }).Accepted);
        var artifacts = new[] { "trace.bin", "grid.bin", "editor.bin", "committed.bin", "restored.bin", "stty-before.txt", "stty-after.txt" }
            .ToDictionary(name => name, name => File.ReadAllBytes(Path.Combine(directory, name)), StringComparer.Ordinal);
        Assert.NotNull(proof.Complete(committed.Text, "Actual PTY: visible grid, editor, committed value, exit and restored configuration.", artifacts));
    }
}
