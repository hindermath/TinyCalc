using MicroCalc.Core.Engine;
using MicroCalc.Core.IO;
using MicroCalc.Core.Model;
using MicroCalc.Tui.Help;
using Terminal.Gui.App;
using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace MicroCalc.Tui;

internal sealed class TuiSession : IDisposable
{
    private readonly MicroCalcEngine _engine = new();
    // Terminal.Gui v2 behält TextView für Kompatibilität; EditorView würde eine neue Abhängigkeit einführen.
    // Terminal.Gui v2 keeps TextView for compatibility; EditorView would add a new dependency.
#pragma warning disable CS0618
    private TextView _gridView = null!;
#pragma warning restore CS0618
    private Label _statusLine = null!;
    private Label _messageLine = null!;
    private string _message = "Type '/' for commands.";

    private bool _disposed;

    // DE: Der Aufrufer besitzt die App; die Session besitzt genau ihre Views und ihren Tabellenzustand.
    // EN: The caller owns the app; the session owns only its views and spreadsheet state.
    internal TuiSession(IApplication app)
    {
        Root = BuildWindow(app);
        RefreshUi();
    }

    internal Window Root { get; }
    internal CellAddress Address => _engine.CurrentCell;
    internal Cell CellSnapshot => _engine.Sheet.GetCell(_engine.CurrentCell).Clone();
    internal Cell SnapshotAt(CellAddress address) => _engine.Sheet.GetCell(address).Clone();
    internal bool AutoCalc => _engine.AutoCalc;
    internal string GridText => _gridView.Text.ToString();
    internal string StatusText => _statusLine.Text.ToString();
    internal string MessageText => _messageLine.Text.ToString();

    public void Dispose()
    {
        if (_disposed)
            return;
        _disposed = true;
        try { Root.Dispose(); }
        finally { _engine.Clear(); }
    }

    private MenuBar BuildMenu(IApplication app)
    {
        return new MenuBar(
        [
            new MenuBarItem("_File", [
                new MenuItem("_Load", string.Empty, () => ExecuteSafe(() => LoadSheet(app))),
                new MenuItem("_Save", string.Empty, () => ExecuteSafe(() => SaveSheet(app))),
                new MenuItem("_Print", string.Empty, () => ExecuteSafe(() => PrintSheet(app))),
                new MenuItem("_Quit", string.Empty, app.RequestStop),
            ]),
            new MenuBarItem("_Sheet", [
                new MenuItem("_Recalculate", string.Empty, () => ExecuteSafe(RecalculateSheet)),
                new MenuItem("_Format", string.Empty, () => ExecuteSafe(() => FormatRange(app))),
                new MenuItem("_AutoCalc", string.Empty, () => ExecuteSafe(ToggleAutoCalc)),
                new MenuItem("_Clear", string.Empty, () => ExecuteSafe(() => ClearSheet(app))),
            ]),
            new MenuBarItem("_Help", [
                new MenuItem("_Help", string.Empty, () => ExecuteSafe(() => ShowHelp(app))),
            ]),
        ]);
    }

    private Window BuildWindow(IApplication app)
    {
        var window = new Window
        {
            Title = "MicroCalc .NET 10",
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        var menu = BuildMenu(app);

        // Diese Migration bewahrt den bestehenden Nur-Lese-Textvertrag ohne zusätzliches Editor-Paket.
        // This migration preserves the existing read-only text contract without an extra editor package.
#pragma warning disable CS0618
        _gridView = new TextView
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill(2),
            ReadOnly = true,
            WordWrap = false,
            Multiline = true,
            CanFocus = false,
        };
        _gridView.SetScheme(GridColorScheme.Create());
#pragma warning restore CS0618

        _statusLine = new Label
        {
            Text = string.Empty,
            X = 0,
            Y = Pos.Bottom(_gridView),
            Width = Dim.Fill(),
            Height = 1,
        };

        _messageLine = new Label
        {
            Text = string.Empty,
            X = 0,
            Y = Pos.Bottom(_statusLine),
            Width = Dim.Fill(),
            Height = 1,
        };

        window.Add(menu, _gridView, _statusLine, _messageLine);
        window.KeyDown += (_, key) => HandleKey(app, key);
        return window;
    }

    private void HandleKey(IApplication app, Key key)
    {
        // DE: Ein geöffnetes Menü besitzt seine Pfeil-/Buchstabentasten; das Raster darf sie nicht vorab verbrauchen.
        // EN: An open menu owns its arrow/letter keys; the grid must not consume them first.
        if (Root.SubViews.OfType<MenuBar>().Any(menu => menu.Active))
            return;
        // Nur erkannte historische Eingaben werden behandelt; unbekannte Tasten erhalten keine neue Tabellenwirkung.
        // Only recognized historical inputs are handled; unknown keys gain no new spreadsheet effect.
        if (key == Key.CursorUp || key == Key.E.WithCtrl)
        {
            _engine.CurrentCell = _engine.Move(_engine.CurrentCell, Direction.Up);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorDown || key == Key.X.WithCtrl || key == Key.J.WithCtrl)
        {
            _engine.CurrentCell = _engine.Move(_engine.CurrentCell, Direction.Down);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorRight || key == Key.D.WithCtrl || key == Key.M.WithCtrl || key == Key.Enter || key == Key.G.WithCtrl)
        {
            _engine.CurrentCell = _engine.Move(_engine.CurrentCell, Direction.Right);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorLeft || key == Key.S.WithCtrl || key == Key.A.WithCtrl)
        {
            _engine.CurrentCell = _engine.Move(_engine.CurrentCell, Direction.Left);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.Q.WithCtrl)
        {
            app.RequestStop();
            key.Handled = true;
            return;
        }

        if (key == new Key('/'))
        {
            ExecuteSafe(() => OpenCommandPalette(app));
            key.Handled = true;
            return;
        }

        if (key == Key.Esc)
        {
            ExecuteSafe(() => OpenEditor(app, useCurrentContents: true, initialText: null));
            key.Handled = true;
            return;
        }

        if (key.TryGetPrintableRune(out var rune) && IsPrintableAscii(rune.Value))
        {
            ExecuteSafe(() => OpenEditor(app, useCurrentContents: false, initialText: rune.ToString()));
            key.Handled = true;
            return;
        }
    }

    private static bool IsPrintableAscii(int keyValue)
    {
        return keyValue is >= 32 and <= 126;
    }

    private void ExecuteSafe(Action action)
    {
        try
        {
            action();
            RefreshUi();
        }
        catch (Exception ex)
        {
            _message = ex.Message;
            RefreshUi();
        }
    }

    private void RefreshUi()
    {
        _gridView.Text = _engine.RenderGridText();
        _statusLine.Text = _engine.GetStatusLine();
        _messageLine.Text = _message;
    }

    private void OpenEditor(IApplication app, bool useCurrentContents, string? initialText)
    {
        var currentCell = _engine.Sheet.GetCell(_engine.CurrentCell);
        var seed = useCurrentContents ? currentCell.Contents : (initialText ?? string.Empty);
        var input = PromptText(app, $"Edit {_engine.CurrentCell}", "Value:", seed);

        if (input is null)
        {
            _message = "Bearbeitung abgebrochen.";
            RefreshUi();
            return;
        }

        var result = _engine.EditCell(_engine.CurrentCell, input);
        _message = result.Success
            ? result.Message
            : $"Fehler an Position {result.ErrorPosition}: {result.Message}";

        RefreshUi();
    }

    private void OpenCommandPalette(IApplication app)
    {
        var choice = MessageBox.Query(
            app,
            "Commands",
            "Select command",
            "_Load",
            "_Save",
            "_Recalc",
            "_Print",
            "_Format",
            "_Auto",
            "Help",
            "Clear",
            "_Quit",
            "Cancel");

        switch (choice)
        {
            case 0:
                LoadSheet(app);
                break;
            case 1:
                SaveSheet(app);
                break;
            case 2:
                RecalculateSheet();
                break;
            case 3:
                PrintSheet(app);
                break;
            case 4:
                FormatRange(app);
                break;
            case 5:
                ToggleAutoCalc();
                break;
            case 6:
                ShowHelp(app);
                break;
            case 7:
                ClearSheet(app);
                break;
            case 8:
                app.RequestStop();
                break;
        }

        RefreshUi();
    }

    private void LoadSheet(IApplication app)
    {
        var path = PromptText(app, "Load", "Datei:", "sheet.mcalc.json");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Load abgebrochen.";
            return;
        }

        SpreadsheetJsonStorage.Load(path, _engine);
        _message = $"Geladen: {path}";
    }

    private void SaveSheet(IApplication app)
    {
        var path = PromptText(app, "Save", "Datei:", "sheet.mcalc.json");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Save abgebrochen.";
            return;
        }

        SpreadsheetJsonStorage.Save(path, _engine);
        _message = $"Gespeichert: {path}";
    }

    private void PrintSheet(IApplication app)
    {
        var path = PromptText(app, "Print", "Datei:", "sheet.lst");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Print abgebrochen.";
            return;
        }

        var marginText = PromptText(app, "Print", "Left Margin:", "0");
        if (marginText is null)
        {
            _message = "Print abgebrochen.";
            return;
        }

        if (!int.TryParse(marginText, out var margin))
        {
            margin = 0;
        }

        SpreadsheetPrinter.ExportText(_engine.Sheet, path, margin);
        _message = $"Exportiert: {path}";
    }

    private void RecalculateSheet()
    {
        var result = _engine.Recalculate();
        _message = result.Success
            ? "Recalculate abgeschlossen."
            : string.Join(" | ", result.Errors);
    }

    private void ToggleAutoCalc()
    {
        _engine.ToggleAutoCalc();
        _message = $"AutoCalc: {(_engine.AutoCalc ? "ON" : "OFF")}";
    }

    private void ClearSheet(IApplication app)
    {
        var answer = MessageBox.Query(app, "Clear", "Clear worksheet?", "Yes", "No");
        if (answer != 0)
        {
            _message = "Clear abgebrochen.";
            return;
        }

        _engine.Clear();
        _message = "Worksheet geleert.";
    }

    private void FormatRange(IApplication app)
    {
        var decimalsText = PromptText(app, "Format", "Decimals (-1..11):", "2");
        if (decimalsText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var widthText = PromptText(app, "Format", "Field Width (1..20):", "10");
        if (widthText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var fromText = PromptText(app, "Format", "From Row:", _engine.CurrentCell.Row.ToString());
        if (fromText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var toText = PromptText(app, "Format", "To Row:", _engine.CurrentCell.Row.ToString());
        if (toText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var decimals = ParseInt(decimalsText, 2);
        var width = ParseInt(widthText, 10);
        var from = ParseInt(fromText, _engine.CurrentCell.Row);
        var to = ParseInt(toText, _engine.CurrentCell.Row);

        _engine.FormatRange(_engine.CurrentCell.Column, from, to, decimals, width);
        _message = "Format angewendet.";
    }

    private static int ParseInt(string value, int fallback)
    {
        return int.TryParse(value, out var parsed) ? parsed : fallback;
    }

    private void ShowHelp(IApplication app)
    {
        var helpPath = HelpDocument.ResolveBundledPath(AppContext.BaseDirectory);
        var help = HelpDocument.Load(helpPath);

        var page = 0;
        using var dialog = new Dialog
        {
            Title = "Help",
            Width = 90,
            Height = 28,
        };

        // Die Hilfe bleibt absichtlich eine einfache Nur-Lese-Ansicht innerhalb des genehmigten Paketumfangs.
        // Help intentionally remains a simple read-only view within the approved package scope.
#pragma warning disable CS0618
        var textView = new TextView
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(1),
            ReadOnly = true,
            WordWrap = false,
            Multiline = true,
            Text = help[page],
            CanFocus = false,
        };
#pragma warning restore CS0618

        var footer = new Label
        {
            Text = string.Empty,
            X = 0,
            Y = Pos.Bottom(textView),
            Width = Dim.Fill(),
            Height = 1,
        };

        dialog.Add(textView, footer);

        void UpdatePage()
        {
            textView.Text = help[page];
            footer.Text = $"Page {page + 1}/{help.Count}  (P/N oder Buttons)";
        }

        var prevButton = new Button { Text = "Prev", IsDefault = false };
        prevButton.Accepting += (_, args) =>
        {
            if (page > 0)
            {
                page--;
                UpdatePage();
            }

            args.Handled = true;
        };

        var nextButton = new Button { Text = "Next", IsDefault = false };
        nextButton.Accepting += (_, args) =>
        {
            if (page < help.Count - 1)
            {
                page++;
                UpdatePage();
            }

            args.Handled = true;
        };

        var closeButton = new Button { Text = "Close", IsDefault = true };
        closeButton.Accepting += (_, args) =>
        {
            app.RequestStop();
            args.Handled = true;
        };

        dialog.AddButton(prevButton);
        dialog.AddButton(nextButton);
        dialog.AddButton(closeButton);

        dialog.KeyDown += (_, key) =>
        {
            if (key == Key.Esc)
            {
                app.RequestStop();
                key.Handled = true;
                return;
            }

            if (key == new Key('p') || key == new Key('P'))
            {
                if (page > 0)
                {
                    page--;
                    UpdatePage();
                }

                key.Handled = true;
                return;
            }

            if (key == new Key('n') || key == new Key('N'))
            {
                if (page < help.Count - 1)
                {
                    page++;
                    UpdatePage();
                }

                key.Handled = true;
            }
        };

        UpdatePage();
        app.Run(dialog);
        _message = "Help geschlossen.";
    }

    private string? PromptText(IApplication app, string title, string label, string initial)
    {
        using var dialog = new Dialog
        {
            Title = title,
            Width = 70,
            Height = 8,
        };

        var prompt = new Label
        {
            Text = label,
            X = 1,
            Y = 1,
            Width = 20,
        };

        var textField = new TextField
        {
            Text = initial,
            X = Pos.Right(prompt) + 1,
            Y = 1,
            Width = Dim.Fill(2),
        };

        if (title.StartsWith("Edit ", StringComparison.Ordinal))
        {
            // DE: Historische Editoraliase ersetzen nur in Zell-Editoren kollidierende Framework-Defaults.
            // EN: Historical editing aliases replace conflicting framework defaults only in cell editors.
            foreach (var alias in new[] { Key.S.WithCtrl, Key.D.WithCtrl, Key.A.WithCtrl, Key.F.WithCtrl, Key.G.WithCtrl, Key.V.WithCtrl })
                textField.KeyBindings.Remove(alias);
            textField.KeyBindings.Add(Key.S.WithCtrl, textField.KeyBindings.GetCommands(Key.CursorLeft));
            textField.KeyBindings.Add(Key.D.WithCtrl, textField.KeyBindings.GetCommands(Key.CursorRight));
            textField.KeyBindings.Add(Key.A.WithCtrl, textField.KeyBindings.GetCommands(Key.Home));
            textField.KeyBindings.Add(Key.F.WithCtrl, textField.KeyBindings.GetCommands(Key.End));
            textField.KeyBindings.Add(Key.G.WithCtrl, Command.DeleteCharRight);
            textField.KeyBindings.Add(Key.V.WithCtrl, Command.ToggleOverwrite);
        }

        string? result = null;

        var ok = new Button { Text = "OK", IsDefault = true };
        ok.Accepting += (_, args) =>
        {
            result = textField.Text.ToString();
            app.RequestStop();
            args.Handled = true;
        };

        var cancel = new Button { Text = "Cancel", IsDefault = false };
        cancel.Accepting += (_, args) =>
        {
            result = null;
            app.RequestStop();
            args.Handled = true;
        };

        dialog.Add(prompt, textField);
        dialog.AddButton(ok);
        dialog.AddButton(cancel);
        SetPromptButtonDefaults(dialog, ok, cancel);

        app.Run(dialog);
        return result;
    }

    internal static void SetPromptButtonDefaults(Dialog dialog, Button ok, Button cancel)
    {
        // AddButton macht den zuletzt hinzugefuegten Button automatisch zum Default. Die sichtbare
        // Reihenfolge bleibt OK/Cancel; Buttonrolle und Enter-Ziel werden danach auf OK zurueckgesetzt.
        // AddButton automatically makes the last added button the default. The visible order remains
        // OK/Cancel; afterwards both the button role and Enter target are reset to OK.
        ok.IsDefault = true;
        cancel.IsDefault = false;
        dialog.DefaultAcceptView = ok;
    }
}
