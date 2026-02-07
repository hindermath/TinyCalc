using System.Diagnostics;
using MicroCalc.Tui.Smoke;

namespace MicroCalc.Tui.Tests;

public sealed class TuiSmokeTests
{
    [Fact]
    public void SmokeRunner_WithSourceHelpFile_Succeeds()
    {
        var repoRoot = FindRepositoryRoot();
        var helpPath = Path.Combine(repoRoot, "src", "MicroCalc.Tui", "Resources", "CALC.HLP");

        var result = TuiSmokeRunner.Run(repoRoot, helpPath);

        Assert.True(result.Success, string.Join(Environment.NewLine, result.Errors));
    }

    [Fact]
    public void SmokeRunner_WithMissingHelpFile_Fails()
    {
        var repoRoot = FindRepositoryRoot();
        var missingHelp = Path.Combine(repoRoot, "does-not-exist", "CALC.HLP");

        var result = TuiSmokeRunner.Run(repoRoot, missingHelp);

        Assert.False(result.Success);
        Assert.Contains(result.Errors, e => e.Contains("file not found", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task SmokeCliFlag_ExitsSuccessfully()
    {
        var repoRoot = FindRepositoryRoot();
        var projectPath = Path.Combine(repoRoot, "src", "MicroCalc.Tui", "MicroCalc.Tui.csproj");
        var configuration = ResolveCurrentTestConfiguration();

        var startInfo = new ProcessStartInfo
        {
            FileName = "dotnet",
            Arguments = $"run --no-build --configuration {configuration} --project \"{projectPath}\" -- --smoke",
            WorkingDirectory = repoRoot,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true,
        };

        using var process = Process.Start(startInfo);
        Assert.NotNull(process);

        var outputTask = process!.StandardOutput.ReadToEndAsync();
        var errorTask = process.StandardError.ReadToEndAsync();
        await process.WaitForExitAsync();

        var output = await outputTask;
        var error = await errorTask;

        Assert.Equal(0, process.ExitCode);
        Assert.Contains("SMOKE_OK", output + error, StringComparison.Ordinal);
    }

    private static string ResolveCurrentTestConfiguration()
    {
        var marker = $"{Path.DirectorySeparatorChar}Release{Path.DirectorySeparatorChar}";
        return AppContext.BaseDirectory.Contains(marker, StringComparison.OrdinalIgnoreCase)
            ? "Release"
            : "Debug";
    }

    private static string FindRepositoryRoot()
    {
        var current = new DirectoryInfo(AppContext.BaseDirectory);
        while (current is not null)
        {
            if (File.Exists(Path.Combine(current.FullName, "MicroCalc.sln")))
            {
                return current.FullName;
            }

            current = current.Parent;
        }

        throw new InvalidOperationException("Repository root not found.");
    }
}
