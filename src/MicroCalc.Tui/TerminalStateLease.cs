using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MicroCalc.Tui;

internal sealed class TerminalStateLease : IDisposable
{
    private readonly Func<string[], string> _execute;
    private readonly string _snapshot;
    private bool _disposed;

    internal TerminalStateLease(Func<string[], string> execute)
    {
        _execute = execute;
        _snapshot = execute(["-g"]).TrimEnd('\r', '\n');
        if (_snapshot.Length > 4096 || !Regex.IsMatch(_snapshot,
                "^gfmt1:[a-z][a-z0-9]*=[0-9a-f]+(?::[a-z][a-z0-9]*=[0-9a-f]+)*$", RegexOptions.CultureInvariant,
                TimeSpan.FromMilliseconds(100))) throw new InvalidDataException("Invalid terminal-state snapshot.");
    }

    internal static TerminalStateLease? Capture()
    {
        if (!OperatingSystem.IsMacOS()) return null;
        // DE: Auch .NET besitzt eine späte Terminalrücksetzung. Deren Ausgangszustand vor dem Raw-Treiber initialisieren.
        // EN: .NET also owns late terminal restoration. Initialize its baseline before the raw-mode driver starts.
        _ = Console.KeyAvailable;
        return new TerminalStateLease(ExecuteStty);
    }

    internal void RegisterFinalRestore(Action<Action>? register = null)
    {
        // DE: Der Treiber registriert selbst ProcessExit. Danach registrieren, damit dessen späte Rücksetzung nicht gewinnt.
        // EN: The driver registers its own ProcessExit hook. Register later so its late reset cannot overwrite ours.
        register ??= callback => AppDomain.CurrentDomain.ProcessExit += (_, _) => callback();
        register(() =>
        {
            try { _execute([_snapshot]); }
            catch (IOException)
            {
                Console.Error.WriteLine("Terminalzustand nicht wiederhergestellt. / Terminal state was not restored.");
                Environment.ExitCode = 1;
            }
        });
    }

    public void Dispose()
    {
        if (_disposed) return;
        _disposed = true;
        // DE: Nach dem Treiberabbau den vor Init gelesenen Zustand exakt zurückgeben; kein Native-Struct-Layout erraten.
        // EN: After driver disposal, restore the exact pre-init state; never guess native structure layouts.
        _execute([_snapshot]);
    }

    private static string ExecuteStty(string[] arguments)
    {
        var start = new ProcessStartInfo("/bin/stty") { UseShellExecute = false, RedirectStandardOutput = true, RedirectStandardError = true };
        foreach (var argument in arguments) start.ArgumentList.Add(argument);
        using var process = Process.Start(start) ?? throw new IOException("Terminal-state command unavailable.");
        var output = process.StandardOutput.ReadToEndAsync();
        var error = process.StandardError.ReadToEndAsync();
        if (!process.WaitForExit(4000))
        {
            process.Kill(entireProcessTree: true);
            process.WaitForExit(1000);
            throw new IOException("Terminal-state command exceeded deadline.");
        }
        var text = output.GetAwaiter().GetResult();
        if (process.ExitCode != 0 || text.Length > 4096 || error.GetAwaiter().GetResult().Length != 0)
            throw new IOException("Terminal-state command failed.");
        return text;
    }
}
