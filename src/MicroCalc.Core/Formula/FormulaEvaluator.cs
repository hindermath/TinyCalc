using System.Globalization;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Formula;

public sealed class FormulaEvaluator
{
    public EvaluationResult Evaluate(string expression, Spreadsheet sheet)
    {
        if (string.IsNullOrWhiteSpace(expression))
        {
            return EvaluationResult.Failed("Ausdruck ist leer.", 1);
        }

        var normalized = Normalize(expression);
        var stack = new HashSet<CellAddress>();

        try
        {
            var parser = new Parser(normalized, sheet, stack);
            var value = parser.ParseToEnd();
            return EvaluationResult.Ok(value, parser.IsFormula);
        }
        catch (FormulaParseException ex)
        {
            return EvaluationResult.Failed(ex.Message, ex.Position);
        }
    }

    private static string Normalize(string expression)
    {
        var text = expression.Trim();
        if (text.StartsWith(".", StringComparison.Ordinal))
        {
            text = "0" + text;
        }

        if (text.StartsWith("+", StringComparison.Ordinal))
        {
            text = text[1..];
        }

        return text;
    }

    private sealed class Parser
    {
        private readonly string _text;
        private readonly Spreadsheet _sheet;
        private readonly HashSet<CellAddress> _evaluationStack;
        private int _position;

        public Parser(string text, Spreadsheet sheet, HashSet<CellAddress> evaluationStack)
        {
            _text = text;
            _sheet = sheet;
            _evaluationStack = evaluationStack;
        }

        public bool IsFormula { get; private set; }

        public double ParseToEnd()
        {
            var value = ParseExpression();
            SkipWhitespace();
            if (!IsEnd())
            {
                throw Error("Unerwartetes Zeichen.");
            }

            return value;
        }

        private double ParseExpression()
        {
            var value = ParseSimpleExpression();
            while (true)
            {
                SkipWhitespace();
                if (Match('+'))
                {
                    value += ParseSimpleExpression();
                    continue;
                }

                if (Match('-'))
                {
                    value -= ParseSimpleExpression();
                    continue;
                }

                return value;
            }
        }

        private double ParseSimpleExpression()
        {
            var value = ParseTerm();
            while (true)
            {
                SkipWhitespace();
                if (Match('*'))
                {
                    value *= ParseTerm();
                    continue;
                }

                if (Match('/'))
                {
                    var divisor = ParseTerm();
                    if (Math.Abs(divisor) < double.Epsilon)
                    {
                        throw Error("Division durch Null.");
                    }

                    value /= divisor;
                    continue;
                }

                return value;
            }
        }

        private double ParseTerm()
        {
            var value = ParseSignedFactor();
            while (true)
            {
                SkipWhitespace();
                if (!Match('^'))
                {
                    return value;
                }

                var exponent = ParseSignedFactor();
                value = Math.Pow(value, exponent);
            }
        }

        private double ParseSignedFactor()
        {
            SkipWhitespace();
            if (Match('-'))
            {
                return -ParseFactor();
            }

            return ParseFactor();
        }

        private double ParseFactor()
        {
            SkipWhitespace();
            if (IsEnd())
            {
                throw Error("Unerwartetes Ende des Ausdrucks.");
            }

            if (Match('('))
            {
                var grouped = ParseExpression();
                SkipWhitespace();
                Expect(')');
                return grouped;
            }

            if (char.IsDigit(Current()) || Current() == '.')
            {
                return ParseNumber();
            }

            if (char.IsLetter(Current()))
            {
                return ParseIdentifierBasedFactor();
            }

            throw Error("Unbekannter Ausdrucksteil.");
        }

        private double ParseIdentifierBasedFactor()
        {
            var save = _position;
            var letter = char.ToUpperInvariant(Current());
            if (SpreadsheetSpec.IsColumnInRange(letter) && HasDigitAfterColumn())
            {
                var from = ParseCellAddress();
                IsFormula = true;
                SkipWhitespace();
                if (Match('>'))
                {
                    var to = ParseCellAddress();
                    return SumRange(from, to);
                }

                return ResolveCellValue(from);
            }

            _position = save;
            var functionName = ParseName();
            SkipWhitespace();
            Expect('(');
            var argument = ParseExpression();
            SkipWhitespace();
            Expect(')');
            return ApplyFunction(functionName, argument);
        }

        private double ApplyFunction(string name, double argument)
        {
            return name switch
            {
                "ABS" => Math.Abs(argument),
                "SQRT" => argument >= 0
                    ? Math.Sqrt(argument)
                    : throw Error("SQRT erwartet einen Wert >= 0."),
                "SQR" => argument * argument,
                "SIN" => Math.Sin(argument),
                "COS" => Math.Cos(argument),
                "ARCTAN" => Math.Atan(argument),
                "LN" => argument > 0
                    ? Math.Log(argument)
                    : throw Error("LN erwartet einen Wert > 0."),
                "LOG" => argument > 0
                    ? Math.Log10(argument)
                    : throw Error("LOG erwartet einen Wert > 0."),
                "EXP" => Math.Exp(argument),
                "FACT" => Factorial(argument),
                _ => throw Error($"Unbekannte Funktion '{name}'."),
            };
        }

        private static double Factorial(double argument)
        {
            var n = (int)Math.Truncate(argument);
            if (n < 0 || n > 33)
            {
                throw new FormulaParseException("FACT erwartet einen Integer zwischen 0 und 33.", 1);
            }

            double value = 1;
            for (var i = 2; i <= n; i++)
            {
                value *= i;
            }

            return value;
        }

        private double SumRange(CellAddress from, CellAddress to)
        {
            var startColumn = Math.Min(SpreadsheetSpec.ColumnToIndex(from.Column), SpreadsheetSpec.ColumnToIndex(to.Column));
            var endColumn = Math.Max(SpreadsheetSpec.ColumnToIndex(from.Column), SpreadsheetSpec.ColumnToIndex(to.Column));
            var startRow = Math.Min(from.Row, to.Row);
            var endRow = Math.Max(from.Row, to.Row);

            var sum = 0.0;
            for (var row = startRow; row <= endRow; row++)
            {
                for (var column = startColumn; column <= endColumn; column++)
                {
                    sum += ResolveCellValue(new CellAddress(SpreadsheetSpec.IndexToColumn(column), row));
                }
            }

            return sum;
        }

        private double ResolveCellValue(CellAddress address)
        {
            if (!_evaluationStack.Add(address))
            {
                throw Error($"Zyklische Referenz in {address}.");
            }

            try
            {
                var cell = _sheet.GetCell(address);

                if (cell.Status.HasFlag(CellStatusFlags.Text) &&
                    !cell.Status.HasFlag(CellStatusFlags.Constant))
                {
                    return 0;
                }

                if (cell.Status.HasFlag(CellStatusFlags.Constant) && !string.IsNullOrWhiteSpace(cell.Contents))
                {
                    var nested = new Parser(NormalizeCellExpression(cell.Contents), _sheet, _evaluationStack);
                    var nestedValue = nested.ParseToEnd();
                    cell.Value = nestedValue;
                    return nestedValue;
                }

                return cell.Value;
            }
            finally
            {
                _evaluationStack.Remove(address);
            }
        }

        private static string NormalizeCellExpression(string input)
        {
            var value = input.Trim();
            if (value.StartsWith(".", StringComparison.Ordinal))
            {
                value = "0" + value;
            }

            if (value.StartsWith("+", StringComparison.Ordinal))
            {
                value = value[1..];
            }

            return value;
        }

        private CellAddress ParseCellAddress()
        {
            SkipWhitespace();
            if (!char.IsLetter(Current()))
            {
                throw Error("Spalte erwartet.");
            }

            var column = char.ToUpperInvariant(Current());
            if (!SpreadsheetSpec.IsColumnInRange(column))
            {
                throw Error("Ungültige Spalte.");
            }

            _position++;
            var rowStart = _position;
            while (!IsEnd() && char.IsDigit(Current()))
            {
                _position++;
            }

            if (_position == rowStart)
            {
                throw Error("Zeile erwartet.");
            }

            if (!int.TryParse(_text[rowStart.._position], NumberStyles.None, CultureInfo.InvariantCulture, out var row))
            {
                throw Error("Ungültige Zeile.");
            }

            if (!SpreadsheetSpec.IsRowInRange(row))
            {
                throw Error("Zeile außerhalb des gültigen Bereichs.");
            }

            return new CellAddress(column, row);
        }

        private string ParseName()
        {
            var start = _position;
            while (!IsEnd() && char.IsLetter(Current()))
            {
                _position++;
            }

            return _text[start.._position].ToUpperInvariant();
        }

        private double ParseNumber()
        {
            var start = _position;
            while (!IsEnd() && char.IsDigit(Current()))
            {
                _position++;
            }

            if (!IsEnd() && Current() == '.')
            {
                _position++;
                while (!IsEnd() && char.IsDigit(Current()))
                {
                    _position++;
                }
            }

            if (!IsEnd() && (Current() == 'E' || Current() == 'e'))
            {
                _position++;
                if (!IsEnd() && (Current() == '+' || Current() == '-'))
                {
                    _position++;
                }

                var exponentStart = _position;
                while (!IsEnd() && char.IsDigit(Current()))
                {
                    _position++;
                }

                if (_position == exponentStart)
                {
                    throw Error("Exponent erwartet.");
                }
            }

            var slice = _text[start.._position];
            if (!double.TryParse(slice, NumberStyles.Float, CultureInfo.InvariantCulture, out var number))
            {
                throw Error("Ungültige Zahl.");
            }

            return number;
        }

        private bool HasDigitAfterColumn()
        {
            var next = _position + 1;
            return next < _text.Length && char.IsDigit(_text[next]);
        }

        private bool Match(char expected)
        {
            if (IsEnd() || Current() != expected)
            {
                return false;
            }

            _position++;
            return true;
        }

        private void Expect(char expected)
        {
            if (!Match(expected))
            {
                throw Error($"'{expected}' erwartet.");
            }
        }

        private void SkipWhitespace()
        {
            while (!IsEnd() && char.IsWhiteSpace(Current()))
            {
                _position++;
            }
        }

        private char Current()
        {
            return _text[_position];
        }

        private bool IsEnd() => _position >= _text.Length;

        private FormulaParseException Error(string message)
        {
            return new FormulaParseException(message, Math.Max(_position + 1, 1));
        }
    }
}
