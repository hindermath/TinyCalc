using MicroCalc.Core.Engine;
using MicroCalc.Core.Model;
using MicroCalc.Tui.Help;

namespace MicroCalc.Tui.Smoke;

/// <summary>
/// DE: Ergebnis eines nicht-interaktiven TUI-Smoke-Laufs.
/// EN: Result of a non-interactive TUI smoke run.
/// </summary>
/// <param name="Success">
/// DE: True, wenn alle Smoke-Pruefungen erfolgreich waren.
/// EN: True when all smoke checks passed.
/// </param>
/// <param name="Errors">
/// DE: Liste der fehlgeschlagenen Checks.
/// EN: List of failed checks.
/// </param>
public sealed record TuiSmokeResult(bool Success, IReadOnlyList<string> Errors);

/// <summary>
/// DE: Fuehrt Basis-Smoke-Checks fuer Engine und Hilfedatei aus.
/// EN: Executes baseline smoke checks for engine and help file.
/// </summary>
public static class TuiSmokeRunner
{
    /// <summary>
    /// DE: Startet den Smoke-Lauf und liefert ein zusammengefasstes Ergebnis.
    /// EN: Starts the smoke run and returns an aggregated result.
    /// </summary>
    /// <param name="baseDirectory">
    /// DE: Basisverzeichnis fuer die Suche nach CALC.HLP.
    /// EN: Base directory used to locate CALC.HLP.
    /// </param>
    /// <param name="helpPathOverride">
    /// DE: Optionaler expliziter Pfad zur Hilfedatei.
    /// EN: Optional explicit path to the help file.
    /// </param>
    /// <returns>
    /// DE: Ergebnisobjekt mit Erfolgsstatus und Fehlerliste.
    /// EN: Result object with success state and error list.
    /// </returns>
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
