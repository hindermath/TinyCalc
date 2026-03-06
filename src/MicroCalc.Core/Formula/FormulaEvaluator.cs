using System.Globalization;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Formula;

/// <summary>
/// DE: Wertet MicroCalc-Formelausdruecke gegen ein Arbeitsblatt aus.
/// EN: Evaluates MicroCalc formula expressions against a worksheet.
/// </summary>
public sealed class FormulaEvaluator
{
    /// <summary>
    /// DE: Parst und berechnet einen Ausdruck fuer das angegebene Blatt.
    /// EN: Parses and computes one expression for the provided sheet.
    /// </summary>
    /// <param name="expression">
    /// DE: Ausdruck aus Zellinhalt oder Benutzereingabe.
    /// EN: Expression from cell content or user input.
    /// </param>
    /// <param name="sheet">
    /// DE: Blattkontext fuer Zellreferenzen und Bereiche.
    /// EN: Sheet context for cell references and ranges.
    /// </param>
    /// <returns>
    /// DE: Bewertungsergebnis mit Wert oder Fehlerinformationen.
    /// EN: Evaluation result with value or error details.
    /// </returns>
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
                if (!IsEnd() && Current() == '>' && IsRangeOperatorStart())
                {
                    _position++; // consume '>'
                    var to = ParseCellAddress();
                    return SumRange(from, to);
                }

                return ResolveCellValue(from);
            }

            _position = save;
            var functionName = ParseName();
            SkipWhitespace();
            Expect('(');
            switch (functionName)
            {
                case "MIN":
                case "MAX":
                case "AVERAGE":
                case "COUNT":
                    return ParseRangeAggregateFunction(functionName);
                case "IF":
                    return ParseIfExpression();
                case "ROUND":
                    return ParseRoundExpression();
                default:
                    var argument = ParseExpression();
                    SkipWhitespace();
                    Expect(')');
                    return ApplyFunction(functionName, argument);
            }
        }

        private bool IsRangeOperatorStart()
        {
            // Precondition: Current() == '>'
            // Returns true iff _text[_position+1] is a valid column letter (A–G)
            // AND _text[_position+2] is a digit (0–9)
            var p1 = _position + 1;
            var p2 = _position + 2;
            if (p2 >= _text.Length)
            {
                return false;
            }

            var col = char.ToUpperInvariant(_text[p1]);
            return SpreadsheetSpec.IsColumnInRange(col) && char.IsDigit(_text[p2]);
        }

        private double ParseRangeAggregateFunction(string name)
        {
            // Precondition: '(' already consumed by caller.
            // Expects: range_arg ')' where range_arg is cell_address '>' cell_address OR expression.
            IsFormula = true;
            SkipWhitespace();
            var letter = char.ToUpperInvariant(Current());
            if (!IsEnd() && char.IsLetter(Current()) && SpreadsheetSpec.IsColumnInRange(letter) && HasDigitAfterColumn())
            {
                var from = ParseCellAddress();
                SkipWhitespace();
                if (!IsEnd() && Current() == '>' && IsRangeOperatorStart())
                {
                    _position++; // consume '>'
                    var to = ParseCellAddress();
                    SkipWhitespace();
                    Expect(')');
                    var values = CollectRangeValues(from, to);
                    return ApplyAggregate(name, values);
                }

                // Single cell reference — use CollectRangeValues so COUNT excludes empty/text cells
                SkipWhitespace();
                Expect(')');
                var singleCellValues = CollectRangeValues(from, from);
                return ApplyAggregate(name, singleCellValues);
            }

            // General expression (e.g., literal)
            var exprValue = ParseExpression();
            SkipWhitespace();
            Expect(')');
            return ApplyAggregate(name, new[] { exprValue });
        }

        private static double ApplyAggregate(string name, IReadOnlyList<double> values)
        {
            return name switch
            {
                "MIN" => values.Count == 0 ? 0 : values.Min(),
                "MAX" => values.Count == 0 ? 0 : values.Max(),
                "AVERAGE" => values.Count == 0 ? 0 : values.Sum() / values.Count,
                "COUNT" => values.Count,
                _ => throw new FormulaParseException($"Unbekannte Aggregatfunktion '{name}'.", 1),
            };
        }

        private double ParseRoundExpression()
        {
            // Precondition: '(' already consumed by caller.
            IsFormula = true;
            var value = ParseExpression();
            SkipWhitespace();
            Expect(',');
            var decimalsRaw = ParseExpression();
            var decimals = (int)Math.Truncate(decimalsRaw);
            if (decimals < 0)
            {
                throw Error("ROUND: Negative Nachkommastellen sind nicht erlaubt.");
            }

            SkipWhitespace();
            Expect(')');
            return Math.Round(value, decimals, MidpointRounding.AwayFromZero);
        }

        private double ParseIfExpression()
        {
            // Precondition: '(' already consumed by caller.
            IsFormula = true;
            var left = ParseExpression();
            SkipWhitespace();
            var relOp = ParseRelationalOperator();
            if (relOp is null)
            {
                throw Error("IF: Bedingung muss einen Vergleichsoperator enthalten (=, <>, <, <=, >=, >).");
            }

            var right = ParseExpression();
            SkipWhitespace();
            if (!Match(','))
            {
                throw Error("IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert.");
            }

            var trueExpr = ParseExpression();
            SkipWhitespace();
            if (!Match(','))
            {
                throw Error("IF erwartet 3 Argumente: Bedingung, Wahr-Wert, Falsch-Wert.");
            }

            var falseExpr = ParseExpression();
            SkipWhitespace();
            Expect(')');
            var condition = EvaluateCondition(left, relOp, right);
            return condition ? trueExpr : falseExpr;
        }

        private string? ParseRelationalOperator()
        {
            SkipWhitespace();
            if (IsEnd())
            {
                return null;
            }

            // Check multi-character operators first
            if (_position + 1 < _text.Length)
            {
                var two = _text.Substring(_position, 2);
                if (two == "<>" || two == "<=" || two == ">=")
                {
                    _position += 2;
                    return two;
                }
            }

            // Single-character operators
            var ch = Current();
            if (ch == '<' || ch == '>' || ch == '=')
            {
                _position++;
                return ch.ToString();
            }

            return null;
        }

        private static bool EvaluateCondition(double left, string relOp, double right)
        {
            return relOp switch
            {
                "=" => Math.Abs(left - right) < 1e-9,
                "<>" => Math.Abs(left - right) >= 1e-9,
                "<" => left < right,
                "<=" => left <= right,
                ">=" => left >= right,
                ">" => left > right,
                _ => throw new FormulaParseException($"Unbekannter Vergleichsoperator '{relOp}'.", 1),
            };
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
            return CollectRangeValues(from, to).Sum();
        }

        private IReadOnlyList<double> CollectRangeValues(CellAddress from, CellAddress to)
        {
            var startColumn = Math.Min(SpreadsheetSpec.ColumnToIndex(from.Column), SpreadsheetSpec.ColumnToIndex(to.Column));
            var endColumn = Math.Max(SpreadsheetSpec.ColumnToIndex(from.Column), SpreadsheetSpec.ColumnToIndex(to.Column));
            var startRow = Math.Min(from.Row, to.Row);
            var endRow = Math.Max(from.Row, to.Row);

            var values = new List<double>();
            for (var row = startRow; row <= endRow; row++)
            {
                for (var column = startColumn; column <= endColumn; column++)
                {
                    var address = new CellAddress(SpreadsheetSpec.IndexToColumn(column), row);
                    var cell = _sheet.GetCell(address);
                    if (cell.Status.HasFlag(CellStatusFlags.Constant) || cell.Status.HasFlag(CellStatusFlags.Calculated))
                    {
                        values.Add(ResolveCellValue(address));
                    }
                }
            }

            return values;
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
