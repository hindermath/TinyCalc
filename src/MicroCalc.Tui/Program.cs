using MicroCalc.Tui.Smoke;
using Terminal.Gui.App;

namespace MicroCalc.Tui;

internal static class Program
{
    private static void Main(string[] args)
    {
        if (args.Any(a => string.Equals(a, "--smoke", StringComparison.OrdinalIgnoreCase)))
        {
            RunSmokeMode();
            return;
        }

        try
        {
            // DE: Die äußere Lease überlebt App und Session, damit macOS seinen Zustand zuletzt zurückerhält.
            // EN: The outer lease outlives app and session so macOS receives its original state last.
            using var terminal = TerminalStateLease.Capture();
            using IApplication app = Application.Create().Init();
            using var session = new TuiSession(app);
            try { app.Run(session.Root); }
            finally { terminal?.RegisterFinalRestore(); }
        }
        catch (Exception error) when (error is IOException or InvalidDataException)
        {
            Console.Error.WriteLine("Terminalzustand konnte nicht sicher wiederhergestellt werden. / Could not safely restore terminal state.");
            Environment.ExitCode = 1;
        }
    }

    private static void RunSmokeMode()
    {
        var result = TuiSmokeRunner.Run(AppContext.BaseDirectory);
        if (result.Success)
        {
            Console.WriteLine("SMOKE_OK");
            return;
        }

        Console.Error.WriteLine("SMOKE_FAIL");
        foreach (var error in result.Errors)
            Console.Error.WriteLine(error);
        Environment.ExitCode = 1;
    }
}
