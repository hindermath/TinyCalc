using MicroCalc.Core.Engine;
using MicroCalc.Core.IO;
using MicroCalc.Core.Model;
using MicroCalc.Tui.Help;
using MicroCalc.Tui.Smoke;
using Terminal.Gui.App;
using Terminal.Gui.Input;
using Terminal.Gui.ViewBase;
using Terminal.Gui.Views;

namespace MicroCalc.Tui;

internal static class Program
{
    private static readonly MicroCalcEngine Engine = new();
    // Terminal.Gui v2 behält TextView für Kompatibilität; EditorView würde eine neue Abhängigkeit einführen.
    // Terminal.Gui v2 keeps TextView for compatibility; EditorView would add a new dependency.
#pragma warning disable CS0618
    private static TextView _gridView = null!;
#pragma warning restore CS0618
    private static Label _statusLine = null!;
    private static Label _messageLine = null!;
    private static string _message = "Type '/' for commands.";

    private static void Main(string[] args)
    {
        if (args.Any(a => string.Equals(a, "--smoke", StringComparison.OrdinalIgnoreCase)))
        {
            RunSmokeMode();
            return;
        }

        // Der Erzeuger besitzt App und Root; alle Dialoge verwenden dieselbe laufende Instanz.
        // The creator owns app and root; every dialog reuses the same running instance.
        using IApplication app = Application.Create().Init();
        using Window root = BuildWindow(app);
        RefreshUi();
        app.Run(root);
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
        {
            Console.Error.WriteLine(error);
        }

        Environment.ExitCode = 1;
    }

    private static MenuBar BuildMenu(IApplication app)
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

    private static Window BuildWindow(IApplication app)
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

    private static void HandleKey(IApplication app, Key key)
    {
        // Nur erkannte historische Eingaben werden behandelt; unbekannte Tasten erhalten keine neue Tabellenwirkung.
        // Only recognized historical inputs are handled; unknown keys gain no new spreadsheet effect.
        if (key == Key.CursorUp || key == Key.E.WithCtrl)
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Up);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorDown || key == Key.X.WithCtrl || key == Key.J.WithCtrl)
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Down);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorRight || key == Key.D.WithCtrl || key == Key.M.WithCtrl || key == Key.Enter)
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Right);
            key.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorLeft || key == Key.S.WithCtrl || key == Key.A.WithCtrl)
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Left);
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

    private static void ExecuteSafe(Action action)
    {
        try
        {
            action();
        }
        catch (Exception ex)
        {
            _message = ex.Message;
            RefreshUi();
        }
    }

    private static void RefreshUi()
    {
        _gridView.Text = Engine.RenderGridText();
        _statusLine.Text = Engine.GetStatusLine();
        _messageLine.Text = _message;
    }

    private static void OpenEditor(IApplication app, bool useCurrentContents, string? initialText)
    {
        var currentCell = Engine.Sheet.GetCell(Engine.CurrentCell);
        var seed = useCurrentContents ? currentCell.Contents : (initialText ?? string.Empty);
        var input = PromptText(app, $"Edit {Engine.CurrentCell}", "Value:", seed);

        if (input is null)
        {
            _message = "Bearbeitung abgebrochen.";
            RefreshUi();
            return;
        }

        var result = Engine.EditCell(Engine.CurrentCell, input);
        _message = result.Success
            ? result.Message
            : $"Fehler an Position {result.ErrorPosition}: {result.Message}";

        RefreshUi();
    }

    private static void OpenCommandPalette(IApplication app)
    {
        var choice = MessageBox.Query(
            app,
            "Commands",
            "Select command",
            "Load",
            "Save",
            "Recalc",
            "Print",
            "Format",
            "Auto",
            "Help",
            "Clear",
            "Quit",
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

    private static void LoadSheet(IApplication app)
    {
        var path = PromptText(app, "Load", "Datei:", "sheet.mcalc.json");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Load abgebrochen.";
            return;
        }

        SpreadsheetJsonStorage.Load(path, Engine);
        _message = $"Geladen: {path}";
    }

    private static void SaveSheet(IApplication app)
    {
        var path = PromptText(app, "Save", "Datei:", "sheet.mcalc.json");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Save abgebrochen.";
            return;
        }

        SpreadsheetJsonStorage.Save(path, Engine);
        _message = $"Gespeichert: {path}";
    }

    private static void PrintSheet(IApplication app)
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

        SpreadsheetPrinter.ExportText(Engine.Sheet, path, margin);
        _message = $"Exportiert: {path}";
    }

    private static void RecalculateSheet()
    {
        var result = Engine.Recalculate();
        _message = result.Success
            ? "Recalculate abgeschlossen."
            : string.Join(" | ", result.Errors);
    }

    private static void ToggleAutoCalc()
    {
        Engine.ToggleAutoCalc();
        _message = $"AutoCalc: {(Engine.AutoCalc ? "ON" : "OFF")}";
    }

    private static void ClearSheet(IApplication app)
    {
        var answer = MessageBox.Query(app, "Clear", "Clear worksheet?", "Yes", "No");
        if (answer != 0)
        {
            _message = "Clear abgebrochen.";
            return;
        }

        Engine.Clear();
        _message = "Worksheet geleert.";
    }

    private static void FormatRange(IApplication app)
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

        var fromText = PromptText(app, "Format", "From Row:", Engine.CurrentCell.Row.ToString());
        if (fromText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var toText = PromptText(app, "Format", "To Row:", Engine.CurrentCell.Row.ToString());
        if (toText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var decimals = ParseInt(decimalsText, 2);
        var width = ParseInt(widthText, 10);
        var from = ParseInt(fromText, Engine.CurrentCell.Row);
        var to = ParseInt(toText, Engine.CurrentCell.Row);

        Engine.FormatRange(Engine.CurrentCell.Column, from, to, decimals, width);
        _message = "Format angewendet.";
    }

    private static int ParseInt(string value, int fallback)
    {
        return int.TryParse(value, out var parsed) ? parsed : fallback;
    }

    private static void ShowHelp(IApplication app)
    {
        var helpPath = Path.Combine(AppContext.BaseDirectory, "CALC.HLP");
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

    private static string? PromptText(IApplication app, string title, string label, string initial)
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
