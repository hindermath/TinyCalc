using MicroCalc.Core.Engine;
using MicroCalc.Core.Model;
using MicroCalc.Tui.Help;

namespace MicroCalc.Tui.Smoke;

public sealed record TuiSmokeResult(bool Success, IReadOnlyList<string> Errors);

public static class TuiSmokeRunner
{
    public static TuiSmokeResult Run(string baseDirectory, string? helpPathOverride = null)
    {
        var errors = new List<string>();

        try
        {
            var engine = new MicroCalcEngine();
            var grid = engine.RenderGridText();
            if (!grid.Contains("A", StringComparison.Ordinal))
            {
                errors.Add("Grid render smoke check failed.");
            }

            var edit = engine.EditCell(new CellAddress('A', 1), "2+3*4");
            if (!edit.Success)
            {
                errors.Add($"Engine edit smoke check failed: {edit.Message}");
            }
            else if (Math.Abs(engine.Sheet.GetCell('A', 1).Value - 14.0) > 1e-9)
            {
                errors.Add("Engine arithmetic smoke check failed.");
            }
        }
        catch (Exception ex)
        {
            errors.Add($"Engine smoke check exception: {ex.Message}");
        }

        var helpPath = ResolveHelpPath(baseDirectory, helpPathOverride);
        try
        {
            if (!File.Exists(helpPath))
            {
                errors.Add($"Help smoke check failed: file not found at '{helpPath}'.");
                return new TuiSmokeResult(false, errors);
            }

            var help = HelpDocument.Load(helpPath);
            if (help.Count <= 0)
            {
                errors.Add("Help smoke check failed: no pages loaded.");
            }
        }
        catch (Exception ex)
        {
            errors.Add($"Help smoke check exception: {ex.Message}");
        }

        return new TuiSmokeResult(errors.Count == 0, errors);
    }

    private static string ResolveHelpPath(string baseDirectory, string? helpPathOverride)
    {
        if (!string.IsNullOrWhiteSpace(helpPathOverride))
        {
            return helpPathOverride;
        }

        var direct = Path.Combine(baseDirectory, "CALC.HLP");
        if (File.Exists(direct))
        {
            return direct;
        }

        return Path.Combine(baseDirectory, "Resources", "CALC.HLP");
    }
}
