using System.Text.Json.Nodes;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

internal static class UiPathObservation
{
    internal static string Focus(LegacyProgramUiAdapter ui)
    {
        if (ui.App.SessionStack is { Count: 0 }) return "Terminal";
        if (ReferenceEquals(ui.CurrentView, ui.Root)) return "Grid";
        if (ui.CurrentView is not Dialog dialog) return "Other";
        var title = dialog.Title.ToString();
        if (title.StartsWith("Edit ", StringComparison.Ordinal)) return "Editor";
        if (title == "Commands") return "Palette";
        var labels = string.Join(" ", LegacyProgramUiAdapter.Descendants(dialog).OfType<Label>().Select(label => label.Text.ToString()));
        if (title == "Print") return labels.Contains("Left Margin:", StringComparison.Ordinal) ? "PrintMargin" : "PrintFile";
        if (title == "Format") return labels.Contains("Decimals", StringComparison.Ordinal) ? "FormatDecimals"
            : labels.Contains("Field Width", StringComparison.Ordinal) ? "FormatWidth"
            : labels.Contains("From Row", StringComparison.Ordinal) ? "FormatFrom" : labels.Contains("To Row", StringComparison.Ordinal) ? "FormatTo" : "Other";
        return title;
    }

    internal static void Record(ExecutedPathProof proof, LegacyProgramUiAdapter ui, string expectedFocus,
        string? expectedContents = null, double? expectedValue = null, string? before = null, string? after = null)
    {
        var expected = new JsonObject { ["focus"] = expectedFocus };
        var actual = new JsonObject { ["focus"] = Focus(ui) };
        if (expectedContents is not null)
        {
            expected["contents"] = expectedContents;
            actual["contents"] = ui.CurrentCell.Contents;
        }
        if (expectedValue is not null)
        {
            expected["value"] = expectedValue.Value;
            actual["value"] = ui.CurrentCell.Value;
        }
        if (before is not null)
        {
            // DE: Die Erhaltungsbehauptung folgt erst aus dem vollständigen Zustands- und Dateivergleich.
            // EN: Claim preservation only after comparing the complete worksheet and owned files.
            Assert.Equal(before, after);
            string[] fields = ["cells.contents", "cells.value", "cells.status", "cells.decimals", "cells.fieldWidth", "selection", "autoCalc", "existingFiles"];
            expected["preservedFields"] = new JsonArray(fields.Select(item => (JsonNode?)JsonValue.Create(item)).ToArray());
            actual["preservedFields"] = expected["preservedFields"]!.DeepClone();
        }
        Assert.True(proof.Observe("actual-ui-state", expected, actual).Accepted);
    }
}
