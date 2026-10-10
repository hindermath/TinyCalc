using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiHelpContractTests
{
    [Theory]
    [InlineData("HELP-resource", "resource")]
    [InlineData("HELP-prev-p", "p")]
    [InlineData("HELP-prev-uppercase-p", "P")]
    [InlineData("HELP-next-n", "n")]
    [InlineData("HELP-next-uppercase-n", "N")]
    [InlineData("HELP-prev-button", "Prev")]
    [InlineData("HELP-next-button", "Next")]
    [InlineData("HELP-first-boundary", "first")]
    [InlineData("HELP-last-boundary", "last")]
    [InlineData("HELP-esc-close", "Esc")]
    [InlineData("HELP-close-button", "Close")]
    [Trait("Contract", "Help")]
    public void ActualBundledHelp_PagesAndRespectsFirstLastBoundaries(string id, string action)
    {
        var proof = new ExecutedPathProof(id);
        var grid = string.Empty;
        var status = string.Empty;
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        adapter.Run(ui => { proof.BeginExecution(); before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Help"),
            ui =>
            {
                Assert.Equal("Help", ui.CurrentView!.Title.ToString());
                Assert.Contains("INTRODUCTION", Text(ui));
                Assert.Contains("Page 1/", Text(ui));
                if (action is "p" or "P" or "Prev")
                {
                    UiContractActions.SelectButton(ui, "Next");
                    Assert.Contains("Page 2/", Text(ui));
                    if (action == "Prev") UiContractActions.SelectButton(ui, action);
                    else ui.Send(new Key(action[0]));
                    Assert.Contains("Page 1/", Text(ui));
                }
                else if (action is "n" or "N" or "Next")
                {
                    if (action == "Next") UiContractActions.SelectButton(ui, action);
                    else ui.Send(new Key(action[0]));
                    Assert.Contains("Page 2/", Text(ui));
                }
                else if (action == "first")
                {
                    UiContractActions.SelectButton(ui, "Prev");
                    Assert.Contains("Page 1/", Text(ui));
                }
                else if (action == "last")
                {
                    var footer = LegacyProgramUiAdapter.Descendants(ui.CurrentView).OfType<Label>().Single(label => label.Text.ToString().Contains("Page 1/", StringComparison.Ordinal));
                    var count = int.Parse(footer.Text.ToString().Split('/')[1].Split(' ')[0], System.Globalization.CultureInfo.InvariantCulture);
                    for (var i = 0; i <= count; i++) ui.Send(new Key('n'));
                    Assert.Contains($"Page {count}/{count}", Text(ui));
                }
                if (action is not ("Esc" or "Close"))
                {
                    UiPathObservation.Record(proof, ui, "Help");
                    grid = Text(ui); status = ui.StatusText;
                }
                if (action == "Close") UiContractActions.SelectButton(ui, "Close");
                else ui.Send(Key.Esc);
            }, ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView); Assert.Equal(before, ui.Snapshot);
                if (action is "Esc" or "Close")
                {
                    UiPathObservation.Record(proof, ui, "Grid", before: before, after: ui.Snapshot);
                    grid = ui.GridText; status = ui.StatusText;
                }
            });
        Assert.NotNull(proof.Complete(grid, status));
    }

    [Theory]
    [InlineData("HELP-missing-resource", "missing")]
    [InlineData("HELP-damaged-resource", "empty")]
    [Trait("Contract", "Help")]
    public void ResourceFailure_IsExplainedAndCloseReturnsToWorksheet(string id, string fault)
    {
        var proof = new ExecutedPathProof(id);
        var grid = string.Empty;
        var status = string.Empty;
        var paths = new[] { Path.Combine(AppContext.BaseDirectory, "CALC.HLP"), Path.Combine(AppContext.BaseDirectory, "Resources", "CALC.HLP") };
        var backups = paths.Select(path => new { Path = path, Bytes = File.Exists(path) ? File.ReadAllBytes(path) : null, Time = File.Exists(path) ? File.GetLastWriteTimeUtc(path) : default }).ToArray();
        try
        {
            // DE: Nur ignorierte Assets der eigenen Testausgabe ändern; Quell- und Produktdateien bleiben unberührt.
            // EN: Change only ignored assets in this test output; source and product files remain untouched.
            foreach (var path in paths) if (File.Exists(path)) File.Delete(path);
            if (fault == "empty") File.WriteAllText(paths[0], string.Empty);
            using var adapter = new LegacyProgramUiAdapter();
            string? before = null;
            adapter.Run(ui => { proof.BeginExecution(); before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Help"),
                ui =>
                {
                    Assert.Contains(fault == "missing" ? "nicht gefunden" : "ist leer", Text(ui));
                    UiPathObservation.Record(proof, ui, "Help");
                    grid = Text(ui); status = ui.StatusText;
                    UiContractActions.SelectButton(ui, "Close");
                }, ui => { Assert.Same(ui.Root, ui.CurrentView); Assert.Equal(before, ui.Snapshot); });
        }
        finally
        {
            foreach (var backup in backups)
            {
                if (backup.Bytes is null) { if (File.Exists(backup.Path)) File.Delete(backup.Path); }
                else { File.WriteAllBytes(backup.Path, backup.Bytes); File.SetLastWriteTimeUtc(backup.Path, backup.Time); }
            }
        }
        Assert.NotNull(proof.Complete(grid, status));
    }

    private static string Text(LegacyProgramUiAdapter ui) => string.Join("\n", LegacyProgramUiAdapter.Descendants(Assert.IsType<Dialog>(ui.CurrentView)).Select(view => view.Text.ToString()));
}
