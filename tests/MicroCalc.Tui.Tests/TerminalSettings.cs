namespace MicroCalc.Tui.Tests;

internal static class TerminalSettings
{
    internal static string Configuration(string state)
    {
        var fields = state.TrimEnd('\r', '\n').Split(':');
        if (fields.Length < 2 || fields[0] != "gfmt1") throw new InvalidDataException("Invalid Darwin terminal state.");
        var names = new HashSet<string>(StringComparer.Ordinal);
        for (var i = 1; i < fields.Length; i++)
        {
            var pair = fields[i].Split('=');
            if (pair.Length != 2 || !names.Add(pair[0]) || !ulong.TryParse(pair[1], System.Globalization.NumberStyles.AllowHexSpecifier,
                    System.Globalization.CultureInfo.InvariantCulture, out var value)) throw new InvalidDataException("Invalid terminal field.");
            // DE: Darwin PENDIN (sys/termios.h) ist Kernel-Eingabestatus, keine Benutzereinstellung. Alle anderen Bits bleiben Pflicht.
            // EN: Darwin PENDIN (sys/termios.h) is kernel input state, not configuration. Every other bit remains mandatory.
            if (pair[0] == "lflag") fields[i] = "lflag=" + (value & ~0x20000000UL).ToString("x", System.Globalization.CultureInfo.InvariantCulture);
        }
        if (!names.Contains("lflag")) throw new InvalidDataException("Missing terminal local flags.");
        return string.Join(':', fields);
    }

    internal static double Contrast(int foreground, int background)
    {
        static double Luminance(int rgb)
        {
            static double Channel(int value) { var v = value / 255.0; return v <= 0.04045 ? v / 12.92 : Math.Pow((v + 0.055) / 1.055, 2.4); }
            return 0.2126 * Channel((rgb >> 16) & 255) + 0.7152 * Channel((rgb >> 8) & 255) + 0.0722 * Channel(rgb & 255);
        }
        var first = Luminance(foreground); var second = Luminance(background);
        return (Math.Max(first, second) + 0.05) / (Math.Min(first, second) + 0.05);
    }
}
