using Terminal.Gui.Drawing;
using TerminalAttribute = Terminal.Gui.Drawing.Attribute;

namespace MicroCalc.Tui;

internal static class GridColorScheme
{
    internal static Scheme Create()
    {
        var canvas = new TerminalAttribute(Color.Black, Color.Gray);
        var emphasis = new TerminalAttribute(Color.White, Color.Blue);

        // TextView verwendet im Nur-Lese-Modus nicht Normal, sondern ReadOnly. Eine explizite
        // Rolle verhindert, dass Terminal.Gui den Text auf hellem Grund bis zur Unsichtbarkeit dimmt.
        // In read-only mode TextView uses ReadOnly rather than Normal. An explicit role prevents
        // Terminal.Gui from dimming text on a light background until it becomes invisible.
        return new Scheme(canvas)
        {
            Normal = canvas,
            ReadOnly = canvas,
            Disabled = canvas,
            Focus = emphasis,
            Active = emphasis,
        };
    }
}
