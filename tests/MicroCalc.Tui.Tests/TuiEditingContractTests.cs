using Terminal.Gui.Input;
using Terminal.Gui.Views;
using System.Text.Json.Nodes;

namespace MicroCalc.Tui.Tests;

[Collection("Terminal.Gui contract")]
public sealed class TuiEditingContractTests
{
    public static IEnumerable<object[]> PrintableAscii() => Enumerable.Range(32, 95).Select(code => new object[] { $"EDIT-ascii-{code}", code });

    [Theory]
    [MemberData(nameof(PrintableAscii))]
    [Trait("Contract", "Editing")]
    public void EveryAsciiCharacter_HasItsOwnGridContext(string id, int code)
    {
        var proof = new ExecutedPathProof(id);
        var grid = string.Empty;
        var status = string.Empty;
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => { proof.BeginExecution(); ui.Send(new Key((char)code)); }, ui =>
        {
            var dialog = Assert.IsType<Dialog>(ui.CurrentView);
            if (code == '/')
            {
                Assert.Equal("Commands", dialog.Title.ToString());
                Assert.Empty(LegacyProgramUiAdapter.Descendants(dialog).OfType<TextField>());
                Assert.True(proof.Observe("slash-command-context", new JsonObject { ["focus"] = "Palette", ["dialog"] = "Commands" },
                    new JsonObject { ["focus"] = dialog.Title.ToString() == "Commands" ? "Palette" : "Other", ["dialog"] = dialog.Title.ToString() }).Accepted);
            }
            else
            {
                Assert.Equal("Edit A1", dialog.Title.ToString());
                var input = UiContractActions.Input(ui);
                Assert.Equal(((char)code).ToString(), input.Text.ToString());
                Assert.True(input.HasFocus);
                Assert.True(proof.Observe("exact-printable-editor-seed", new JsonObject
                {
                    ["focus"] = "Editor", ["contents"] = ((char)code).ToString(), ["dialog"] = "Edit A1",
                }, new JsonObject
                {
                    ["focus"] = input.HasFocus ? "Editor" : "Other", ["contents"] = input.Text.ToString(), ["dialog"] = dialog.Title.ToString(),
                }).Accepted);
            }
            // DE: Den geprüften Dialogzustand vor eigener Testbereinigung festhalten; erst nach allen Assertions publizieren.
            // EN: Capture the tested dialog state before owned cleanup; publish only after all assertions finish.
            grid = ui.GridText;
            status = ui.StatusText;
            ui.Send(Key.Esc);
        }, ui =>
        {
            Assert.Same(ui.Root, ui.CurrentView);
            Assert.Equal(string.Empty, ui.CurrentCell.Contents);
        });
        Assert.NotNull(proof.Complete(grid, status));
    }

    [Theory]
    [InlineData("8/2", 4)]
    [InlineData("hello/world", 0)]
    [Trait("Contract", "Editing")]
    public void EditorSlash_IsLiteralAndNeverOpensPalette(string text, double value)
    {
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => ui.Send(new Key(text[0])), ui =>
        {
            UiContractActions.FinishTyping(ui, text);
            Assert.Equal("Edit A1", ui.CurrentView!.Title.ToString());
            ui.Send(Key.Enter);
        }, ui =>
        {
            Assert.Equal(text, ui.CurrentCell.Contents);
            Assert.Equal(value, ui.CurrentCell.Value);
            Assert.Same(ui.Root, ui.CurrentView);
        });
    }

    [Theory]
    [InlineData("EDIT-existing", "existing")]
    [InlineData("EDIT-slash-literal", "literal")]
    [InlineData("EDIT-slash-division", "division")]
    [InlineData("EDIT-accept", "accept")]
    [InlineData("EDIT-cancel", "cancel")]
    [Trait("Contract", "RemainingEditing")]
    public void RemainingEditorPaths_BindActualInputAndOutcome(string id, string action)
    {
        var proof = new ExecutedPathProof(id);
        using var adapter = new LegacyProgramUiAdapter();
        string? before = null;
        var grid = string.Empty;
        var status = string.Empty;
        var text = action == "division" ? "(8/2)" : action == "literal" ? "hello/world" : "9";
        adapter.Run(ui => { proof.BeginExecution(); ui.Send(new Key('7')); }, ui => ui.Send(Key.Enter),
            ui => { before = ui.Snapshot; ui.Send(Key.Esc); }, ui =>
            {
                Assert.Equal("7", UiContractActions.Input(ui).Text.ToString());
                Assert.True(UiContractActions.Input(ui).HasFocus);
                if (action != "existing") UiContractActions.ReplacePrompt(ui, text);
                Assert.Equal("Edit A1", ui.CurrentView!.Title.ToString());
                if (action is "existing" or "literal")
                {
                    Assert.True(proof.Observe("editor-input", new JsonObject { ["focus"] = "Editor", ["contents"] = action == "existing" ? "7" : text },
                        new JsonObject { ["focus"] = UiPathObservation.Focus(ui), ["contents"] = UiContractActions.Input(ui).Text.ToString() }).Accepted);
                    grid = ui.GridText; status = ui.StatusText;
                }
                ui.Send(action is "existing" or "literal" or "cancel" ? Key.Esc : Key.Enter);
            }, ui =>
            {
                Assert.Same(ui.Root, ui.CurrentView);
                if (action is "existing" or "literal" or "cancel") Assert.Equal(before, ui.Snapshot);
                else { Assert.Equal(text, ui.CurrentCell.Contents); Assert.Equal(action == "division" ? 4 : 9, ui.CurrentCell.Value); }
                if (action == "cancel") UiPathObservation.Record(proof, ui, "Grid", before: before, after: ui.Snapshot);
                if (action is "accept" or "division") UiPathObservation.Record(proof, ui, "Grid", text, action == "division" ? 4 : 9);
                if (action is not ("existing" or "literal")) { grid = ui.GridText; status = ui.StatusText; }
            });
        Assert.NotNull(proof.Complete(grid, status));
    }

    public static IEnumerable<object[]> EditorAliases()
    {
        foreach (var name in new[] { "Ctrl-S", "Ctrl-D", "Ctrl-A", "Ctrl-F", "DEL", "Ctrl-G", "Ctrl-V", "Ins" })
            foreach (var edge in new[] { false, true })
                yield return [$"EDIT-{name.ToLowerInvariant()}-{(edge ? "edge" : "interior")}", name, edge];
    }

    [Theory]
    [MemberData(nameof(EditorAliases))]
    [Trait("Contract", "EditorAlias")]
    public void EveryHistoricalAlias_PreservesCaretContentsAndMode(string id, string name, bool edge)
    {
        var proof = new ExecutedPathProof(id);
        var grid = string.Empty;
        var status = string.Empty;
        using var adapter = new LegacyProgramUiAdapter();
        adapter.Run(ui => { proof.BeginExecution(); ui.Send(new Key('a')); }, ui =>
        {
            UiContractActions.FinishTyping(ui, "abc");
            ui.Send(Key.Home);
            var start = edge ? name is "Ctrl-D" or "Ctrl-F" or "Ctrl-G" or "Ctrl-V" or "Ins" ? 3 : 0 : 1;
            for (var i = 0; i < start; i++) ui.Send(Key.CursorRight);
            var input = UiContractActions.Input(ui);
            Assert.Equal(start, input.InsertionPoint);
            ui.Send(UiContractActions.KeyNamed(name));
            var expectedCaret = name switch
            {
                "Ctrl-S" or "DEL" => Math.Max(0, start - 1),
                "Ctrl-D" => Math.Min(3, start + 1), "Ctrl-A" => 0, "Ctrl-F" => 3, _ => start,
            };
            Assert.Equal(expectedCaret, input.InsertionPoint);
            var expectedText = name switch
            {
                "DEL" when !edge => "bc", "Ctrl-G" when !edge => "ac", _ => "abc",
            };
            if (name is "Ctrl-V" or "Ins")
            {
                ui.Send(new Key('Z'));
                expectedText = edge ? "abcZ" : "aZc";
            }
            Assert.Equal(expectedText, input.Text.ToString());
            Assert.True(input.HasFocus);
            Assert.True(proof.Observe("historical-editor-oracle", new JsonObject
            {
                ["focus"] = "Editor", ["contents"] = expectedText, ["selection"] = "A1",
            }, new JsonObject
            {
                ["focus"] = input.HasFocus ? "Editor" : "Other", ["contents"] = input.Text.ToString(), ["selection"] = ui.Address.ToString(),
            }).Accepted);
            grid = ui.GridText;
            status = ui.StatusText;
            ui.Send(Key.Esc);
        }, ui => Assert.Equal(string.Empty, ui.CurrentCell.Contents));
        Assert.NotNull(proof.Complete(grid, status));
    }
}
