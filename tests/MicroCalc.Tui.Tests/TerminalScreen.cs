using System.Globalization;
using System.Text;

namespace MicroCalc.Tui.Tests;

internal sealed class TerminalScreen(int width, int height)
{
    internal readonly record struct Pixel(char Character, int Foreground, int Background);
    private Pixel[,] _pixels = new Pixel[height, width];
    private Pixel[,]? _primary;
    private int _x, _y, _savedX, _savedY;
    private int _foreground = 0xffffff, _background;
    private bool _reverse;
    private string _pending = string.Empty;
    internal string Text => string.Join("\n", Enumerable.Range(0, height)
        .Select(row => new string(Enumerable.Range(0, width).Select(column => At(column, row).Character).ToArray())));
    internal bool AlternateBuffer { get; private set; }
    internal bool CursorVisible { get; private set; } = true;
    internal bool IsComplete => _pending.Length == 0;
    internal Pixel At(int x, int y) => _pixels[y, x].Character == '\0' ? new Pixel(' ', 0xffffff, 0) : _pixels[y, x];

    internal void Feed(string text)
    {
        if (text.Length + _pending.Length > 20971520) throw new InvalidDataException("Terminal trace exceeds limit.");
        text = _pending + text;
        _pending = string.Empty;
        for (var i = 0; i < text.Length; i++)
        {
            var character = text[i];
            if (character == '\u001b')
            {
                var start = i;
                if (++i == text.Length) { _pending = text[start..]; break; }
                if (text[i] == '[')
                {
                    var parameters = ++i;
                    while (i < text.Length && text[i] is not (>= '@' and <= '~')) i++;
                    if (i == text.Length) { _pending = text[start..]; break; }
                    ApplyCsi(text[parameters..i], text[i]);
                }
                else if (text[i] is ']' or 'P')
                {
                    // DE: Titel- und Fähigkeitsabfragen schreiben keine Rasterzeichen. Unvollständiges bleibt offen.
                    // EN: Title and capability queries do not write screen characters. Incomplete input stays pending.
                    var end = text.IndexOf('\a', i + 1);
                    var st = text.IndexOf("\u001b\\", i + 1, StringComparison.Ordinal);
                    if (st >= 0 && (end < 0 || st < end)) { i = st + 1; }
                    else if (end >= 0) i = end;
                    else { _pending = text[start..]; break; }
                }
                else if (text[i] is '(' or ')')
                {
                    if (++i == text.Length) { _pending = text[start..]; break; }
                    if (text[i] != 'B') throw new InvalidDataException("Unsupported terminal character set.");
                }
                else if (text[i] == '7') { _savedX = _x; _savedY = _y; }
                else if (text[i] == '8') { _x = _savedX; _y = _savedY; }
                else if (text[i] is not ('=' or '>')) throw new InvalidDataException("Unsupported terminal escape.");
                continue;
            }
            switch (character)
            {
                case '\r': _x = 0; break;
                case '\n': _y = Math.Min(height - 1, _y + 1); break;
                case '\b': _x = Math.Max(0, _x - 1); break;
                case '\t': _x = Math.Min(width - 1, (_x / 8 + 1) * 8); break;
                case '\a': break;
                default:
                    if (char.IsControl(character)) throw new InvalidDataException("Unsupported terminal control.");
                    if (_x >= width) { _x = 0; _y = Math.Min(height - 1, _y + 1); }
                    _pixels[_y, _x++] = new Pixel(character, _reverse ? _background : _foreground, _reverse ? _foreground : _background);
                    break;
            }
        }
    }

    private void ApplyCsi(string raw, char command)
    {
        var privateMode = raw.StartsWith('?');
        var clean = raw.TrimStart('?', '>', '<').TrimEnd(' ', '$', '!', '"');
        if (clean.Length > 1024) throw new InvalidDataException("Terminal parameter limit.");
        var args = clean.Split(';').Select(item => item.Length == 0 ? 0 : int.Parse(item, CultureInfo.InvariantCulture)).ToArray();
        var n = args[0] == 0 ? 1 : args[0];
        switch (command)
        {
            case 'H': case 'f': _y = Math.Clamp(n - 1, 0, height - 1); _x = Math.Clamp((args.Length > 1 && args[1] != 0 ? args[1] : 1) - 1, 0, width - 1); break;
            case 'A': _y = Math.Max(0, _y - n); break;
            case 'B': _y = Math.Min(height - 1, _y + n); break;
            case 'C': _x = Math.Min(width - 1, _x + n); break;
            case 'D': _x = Math.Max(0, _x - n); break;
            case 'G': _x = Math.Clamp(n - 1, 0, width - 1); break;
            case 'd': _y = Math.Clamp(n - 1, 0, height - 1); break;
            case 'J':
                if (args[0] is 2 or 3) Array.Clear(_pixels);
                else if (args[0] == 0) { for (var y = _y; y < height; y++) for (var x = y == _y ? _x : 0; x < width; x++) Erase(x, y); }
                else throw new InvalidDataException("Unsupported erase mode.");
                break;
            case 'K':
                for (var x = args[0] is 1 or 2 ? 0 : _x; x < (args[0] == 1 ? _x + 1 : width); x++) Erase(x, _y);
                break;
            case 'm': SetColors(args); break;
            case 'h': case 'l':
                foreach (var mode in args)
                {
                    if (privateMode && mode == 25) CursorVisible = command == 'h';
                    else if (privateMode && mode == 1049)
                    {
                        if (command == 'h' && !AlternateBuffer) { _primary = _pixels; _pixels = new Pixel[height, width]; AlternateBuffer = true; }
                        else if (command == 'l' && AlternateBuffer) { _pixels = _primary!; _primary = null; AlternateBuffer = false; }
                        _x = _y = 0;
                    }
                    else if (mode is not (1 or 7 or 12 or 1000 or 1002 or 1003 or 1004 or 1006 or 1015 or 2004))
                        throw new InvalidDataException("Unsupported terminal mode.");
                }
                break;
            case 's': _savedX = _x; _savedY = _y; break;
            case 'u': if (!privateMode && !raw.StartsWith('>') && !raw.StartsWith('<')) { _x = _savedX; _y = _savedY; } break;
            case 'c': case 'n': case 't': case 'q': case 'p': break; // DE: Abfragen/Zeigerform ohne Textwirkung. EN: Queries/cursor shape do not alter text.
            default: throw new InvalidDataException($"Unsupported terminal screen operation: {command}.");
        }
    }

    private void Erase(int x, int y) => _pixels[y, x] = new Pixel(' ', _foreground, _background);

    private void SetColors(int[] args)
    {
        for (var i = 0; i < args.Length; i++)
        {
            var code = args[i];
            if (code == 0) { _foreground = 0xffffff; _background = 0; _reverse = false; }
            else if (code is 7 or 27) _reverse = code == 7;
            else if (code is 39 or 49) { if (code == 39) _foreground = 0xffffff; else _background = 0; }
            else if (code is >= 30 and <= 37 or >= 90 and <= 97) _foreground = Palette(code < 90 ? code - 30 : code - 90 + 8);
            else if (code is >= 40 and <= 47 or >= 100 and <= 107) _background = Palette(code < 100 ? code - 40 : code - 100 + 8);
            else if (code is 38 or 48)
            {
                if (++i >= args.Length) throw new InvalidDataException("Incomplete color.");
                int color;
                if (args[i] == 2 && i + 3 < args.Length)
                {
                    var rgb = args.Skip(i + 1).Take(3).ToArray();
                    if (rgb.Any(value => value is < 0 or > 255)) throw new InvalidDataException("Invalid RGB.");
                    color = (rgb[0] << 16) | (rgb[1] << 8) | rgb[2]; i += 3;
                }
                else if (args[i] == 5 && i + 1 < args.Length) color = Palette(args[++i]);
                else throw new InvalidDataException("Unsupported color.");
                if (code == 38) _foreground = color; else _background = color;
            }
            else if (code is not (1 or 2 or 3 or 4 or 22 or 23 or 24)) throw new InvalidDataException("Unsupported rendition.");
        }
    }

    private static int Palette(int index)
    {
        int[] basic = [0, 0x800000, 0x008000, 0x808000, 0x000080, 0x800080, 0x008080, 0xc0c0c0,
            0x808080, 0xff0000, 0x00ff00, 0xffff00, 0x0000ff, 0xff00ff, 0x00ffff, 0xffffff];
        if (index is < 0 or > 255) throw new InvalidDataException("Invalid palette index.");
        if (index < 16) return basic[index];
        if (index >= 232) { var gray = 8 + (index - 232) * 10; return gray * 0x010101; }
        int[] levels = [0, 95, 135, 175, 215, 255];
        var cube = index - 16;
        return (levels[cube / 36] << 16) | (levels[cube / 6 % 6] << 8) | levels[cube % 6];
    }
}
