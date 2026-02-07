using MicroCalc.Core.Engine;
using MicroCalc.Core.IO;
using MicroCalc.Core.Model;
using MicroCalc.Tui.Help;
using Terminal.Gui;

namespace MicroCalc.Tui;

internal static class Program
{
    private static readonly MicroCalcEngine Engine = new();
    private static TextView _gridView = null!;
    private static Label _statusLine = null!;
    private static Label _messageLine = null!;
    private static string _message = "Type '/' for commands.";

    private static void Main()
    {
        Application.Init();
        var top = Application.Top;

        var menu = BuildMenu();
        var window = BuildWindow();
        top.Add(menu, window);

        RefreshUi();
        Application.Run();
        Application.Shutdown();
    }

    private static MenuBar BuildMenu()
    {
        return new MenuBar(
        [
            new MenuBarItem("_File", [
                new MenuItem("_Load", string.Empty, () => ExecuteSafe(LoadSheet)),
                new MenuItem("_Save", string.Empty, () => ExecuteSafe(SaveSheet)),
                new MenuItem("_Print", string.Empty, () => ExecuteSafe(PrintSheet)),
                new MenuItem("_Quit", string.Empty, () => Application.RequestStop()),
            ]),
            new MenuBarItem("_Sheet", [
                new MenuItem("_Recalculate", string.Empty, () => ExecuteSafe(RecalculateSheet)),
                new MenuItem("_Format", string.Empty, () => ExecuteSafe(FormatRange)),
                new MenuItem("_AutoCalc", string.Empty, () => ExecuteSafe(ToggleAutoCalc)),
                new MenuItem("_Clear", string.Empty, () => ExecuteSafe(ClearSheet)),
            ]),
            new MenuBarItem("_Help", [
                new MenuItem("_Help", string.Empty, () => ExecuteSafe(ShowHelp)),
            ]),
        ]);
    }

    private static Window BuildWindow()
    {
        var window = new Window("MicroCalc .NET 10")
        {
            X = 0,
            Y = 1,
            Width = Dim.Fill(),
            Height = Dim.Fill(),
        };

        _gridView = new TextView
        {
            X = 0,
            Y = 0,
            Width = Dim.Fill(),
            Height = Dim.Fill(2),
            ReadOnly = true,
            WordWrap = false,
            Multiline = true,
            CanFocus = false,
        };

        _statusLine = new Label(string.Empty)
        {
            X = 0,
            Y = Pos.Bottom(_gridView),
            Width = Dim.Fill(),
            Height = 1,
        };

        _messageLine = new Label(string.Empty)
        {
            X = 0,
            Y = Pos.Bottom(_statusLine),
            Width = Dim.Fill(),
            Height = 1,
        };

        window.Add(_gridView, _statusLine, _messageLine);
        window.KeyPress += args => HandleKey(args);
        return window;
    }

    private static void HandleKey(View.KeyEventEventArgs args)
    {
        var key = args.KeyEvent.Key;

        if (key == Key.CursorUp || key == (Key.CtrlMask | Key.E))
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Up);
            args.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorDown || key == (Key.CtrlMask | Key.X) || key == (Key.CtrlMask | Key.J))
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Down);
            args.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorRight || key == (Key.CtrlMask | Key.D) || key == (Key.CtrlMask | Key.M) || key == Key.Enter)
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Right);
            args.Handled = true;
            RefreshUi();
            return;
        }

        if (key == Key.CursorLeft || key == (Key.CtrlMask | Key.S) || key == (Key.CtrlMask | Key.A))
        {
            Engine.CurrentCell = Engine.Move(Engine.CurrentCell, Direction.Left);
            args.Handled = true;
            RefreshUi();
            return;
        }

        if (key == (Key.CtrlMask | Key.Q))
        {
            Application.RequestStop();
            args.Handled = true;
            return;
        }

        if (args.KeyEvent.KeyValue == '/')
        {
            ExecuteSafe(OpenCommandPalette);
            args.Handled = true;
            return;
        }

        if (key == Key.Esc)
        {
            ExecuteSafe(() => OpenEditor(useCurrentContents: true, initialText: null));
            args.Handled = true;
            return;
        }

        if (IsPrintableAscii(args.KeyEvent.KeyValue))
        {
            ExecuteSafe(() => OpenEditor(useCurrentContents: false, initialText: ((char)args.KeyEvent.KeyValue).ToString()));
            args.Handled = true;
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

    private static void OpenEditor(bool useCurrentContents, string? initialText)
    {
        var currentCell = Engine.Sheet.GetCell(Engine.CurrentCell);
        var seed = useCurrentContents ? currentCell.Contents : (initialText ?? string.Empty);
        var input = PromptText($"Edit {Engine.CurrentCell}", "Value:", seed);

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

    private static void OpenCommandPalette()
    {
        var choice = MessageBox.Query(
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
                LoadSheet();
                break;
            case 1:
                SaveSheet();
                break;
            case 2:
                RecalculateSheet();
                break;
            case 3:
                PrintSheet();
                break;
            case 4:
                FormatRange();
                break;
            case 5:
                ToggleAutoCalc();
                break;
            case 6:
                ShowHelp();
                break;
            case 7:
                ClearSheet();
                break;
            case 8:
                Application.RequestStop();
                break;
        }

        RefreshUi();
    }

    private static void LoadSheet()
    {
        var path = PromptText("Load", "Datei:", "sheet.mcalc.json");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Load abgebrochen.";
            return;
        }

        SpreadsheetJsonStorage.Load(path, Engine);
        _message = $"Geladen: {path}";
    }

    private static void SaveSheet()
    {
        var path = PromptText("Save", "Datei:", "sheet.mcalc.json");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Save abgebrochen.";
            return;
        }

        SpreadsheetJsonStorage.Save(path, Engine);
        _message = $"Gespeichert: {path}";
    }

    private static void PrintSheet()
    {
        var path = PromptText("Print", "Datei:", "sheet.lst");
        if (string.IsNullOrWhiteSpace(path))
        {
            _message = "Print abgebrochen.";
            return;
        }

        var marginText = PromptText("Print", "Left Margin:", "0");
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

    private static void ClearSheet()
    {
        var answer = MessageBox.Query("Clear", "Clear worksheet?", "Yes", "No");
        if (answer != 0)
        {
            _message = "Clear abgebrochen.";
            return;
        }

        Engine.Clear();
        _message = "Worksheet geleert.";
    }

    private static void FormatRange()
    {
        var decimalsText = PromptText("Format", "Decimals (-1..11):", "2");
        if (decimalsText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var widthText = PromptText("Format", "Field Width (1..20):", "10");
        if (widthText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var fromText = PromptText("Format", "From Row:", Engine.CurrentCell.Row.ToString());
        if (fromText is null)
        {
            _message = "Format abgebrochen.";
            return;
        }

        var toText = PromptText("Format", "To Row:", Engine.CurrentCell.Row.ToString());
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

    private static void ShowHelp()
    {
        var helpPath = Path.Combine(AppContext.BaseDirectory, "CALC.HLP");
        var help = HelpDocument.Load(helpPath);

        var page = 0;
        var dialog = new Dialog("Help", 90, 28);

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

        var footer = new Label(string.Empty)
        {
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

        var prevButton = new Button("Prev", is_default: false);
        prevButton.Clicked += () =>
        {
            if (page > 0)
            {
                page--;
                UpdatePage();
            }
        };

        var nextButton = new Button("Next", is_default: false);
        nextButton.Clicked += () =>
        {
            if (page < help.Count - 1)
            {
                page++;
                UpdatePage();
            }
        };

        var closeButton = new Button("Close", is_default: true);
        closeButton.Clicked += () => Application.RequestStop();

        dialog.AddButton(prevButton);
        dialog.AddButton(nextButton);
        dialog.AddButton(closeButton);

        dialog.KeyPress += args =>
        {
            if (args.KeyEvent.Key == Key.Esc)
            {
                Application.RequestStop();
                args.Handled = true;
                return;
            }

            if (args.KeyEvent.KeyValue == 'p' || args.KeyEvent.KeyValue == 'P')
            {
                if (page > 0)
                {
                    page--;
                    UpdatePage();
                }

                args.Handled = true;
                return;
            }

            if (args.KeyEvent.KeyValue == 'n' || args.KeyEvent.KeyValue == 'N')
            {
                if (page < help.Count - 1)
                {
                    page++;
                    UpdatePage();
                }

                args.Handled = true;
            }
        };

        UpdatePage();
        Application.Run(dialog);
        _message = "Help geschlossen.";
    }

    private static string? PromptText(string title, string label, string initial)
    {
        var dialog = new Dialog(title, 70, 8);

        var prompt = new Label(label)
        {
            X = 1,
            Y = 1,
            Width = 20,
        };

        var textField = new TextField(initial)
        {
            X = Pos.Right(prompt) + 1,
            Y = 1,
            Width = Dim.Fill(2),
        };

        string? result = null;

        var ok = new Button("OK", is_default: true);
        ok.Clicked += () =>
        {
            result = textField.Text.ToString();
            Application.RequestStop();
        };

        var cancel = new Button("Cancel", is_default: false);
        cancel.Clicked += () =>
        {
            result = null;
            Application.RequestStop();
        };

        dialog.Add(prompt, textField);
        dialog.AddButton(ok);
        dialog.AddButton(cancel);

        Application.Run(dialog);
        return result;
    }
}
