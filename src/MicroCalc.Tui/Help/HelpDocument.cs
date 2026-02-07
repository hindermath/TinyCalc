namespace MicroCalc.Tui.Help;

internal sealed class HelpDocument
{
    private readonly List<string> _pages;

    private HelpDocument(List<string> pages)
    {
        _pages = pages;
    }

    public int Count => _pages.Count;

    public string this[int index] => _pages[index];

    public static HelpDocument Load(string path)
    {
        if (!File.Exists(path))
        {
            return new HelpDocument([
                "Hilfedatei nicht gefunden. Erwartet: CALC.HLP"
            ]);
        }

        var raw = File.ReadAllText(path)
            .Replace("\u001a", string.Empty, StringComparison.Ordinal)
            .Replace("\r\n", "\n", StringComparison.Ordinal)
            .Replace('\u0002', '\0');

        var chunks = raw.Split(".PA", StringSplitOptions.None)
            .Select(p => p.Replace('\0', ' ').Trim('\n', '\r'))
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .ToList();

        if (chunks.Count == 0)
        {
            chunks.Add("Hilfedatei ist leer.");
        }

        return new HelpDocument(chunks);
    }
}
