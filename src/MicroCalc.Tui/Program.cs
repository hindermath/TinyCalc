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

        // DE: Eine App und eine Session bilden den Lebenszyklus; Dialoge teilen dieselbe App.
        // EN: One app and one session form the lifecycle; dialogs share that same app.
        using IApplication app = Application.Create().Init();
        using var session = new TuiSession(app);
        app.Run(session.Root);
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
