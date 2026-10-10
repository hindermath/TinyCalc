using Terminal.Gui.Input;
using Terminal.Gui.Views;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiHelpContractTests
{
    [Theory]
    [InlineData('n')]
    [InlineData('N')]
    [InlineData('p')]
    [InlineData('P')]
    [Trait("Contract", "Help")]
    public void ActualBundledHelp_PagesAndRespectsFirstLastBoundaries(char key)
    {
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        adapter.Run(ui => { before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Help"),
            ui =>
            {
                Assert.Equal("Help", ui.CurrentView!.Title.ToString());
                Assert.Contains("INTRODUCTION", Text(ui));
                Assert.Contains("Page 1/", Text(ui));
                if (char.ToLowerInvariant(key) == 'p')
                {
                    ui.Send(new Key(key));
                    Assert.Contains("Page 1/", Text(ui));
                    UiContractActions.SelectButton(ui, "Next");
                    Assert.Contains("Page 2/", Text(ui));
                    ui.Send(new Key(key));
                    Assert.Contains("Page 1/", Text(ui));
                }
                else
                {
                    ui.Send(new Key(key));
                    Assert.Contains("Page 2/", Text(ui));
                    UiContractActions.SelectButton(ui, "Prev");
                    Assert.Contains("Page 1/", Text(ui));
                    var footer = LegacyProgramUiAdapter.Descendants(ui.CurrentView).OfType<Label>().Single(label => label.Text.ToString().Contains("Page 1/", StringComparison.Ordinal));
                    var count = int.Parse(footer.Text.ToString().Split('/')[1].Split(' ')[0], System.Globalization.CultureInfo.InvariantCulture);
                    for (var i = 0; i <= count; i++) ui.Send(new Key(key));
                    Assert.Contains($"Page {count}/{count}", Text(ui));
                }
                ui.Send(Key.Esc);
            }, ui => { Assert.Same(ui.Root, ui.CurrentView); Assert.Equal(before, ui.Snapshot); });
    }

    [Theory]
    [InlineData("missing")]
    [InlineData("empty")]
    [Trait("Contract", "Help")]
    public void ResourceFailure_IsExplainedAndCloseReturnsToWorksheet(string fault)
    {
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
            adapter.Run(ui => { before = ui.Snapshot; ui.Send(new Key('/')); }, ui => UiContractActions.SelectButton(ui, "Help"),
                ui =>
                {
                    Assert.Contains(fault == "missing" ? "nicht gefunden" : "ist leer", Text(ui));
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
    }

    private static string Text(LegacyProgramUiAdapter ui) => string.Join("\n", LegacyProgramUiAdapter.Descendants(Assert.IsType<Dialog>(ui.CurrentView)).Select(view => view.Text.ToString()));
}
