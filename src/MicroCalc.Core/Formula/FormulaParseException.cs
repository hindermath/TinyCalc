namespace MicroCalc.Core.Formula;

internal sealed class FormulaParseException : Exception
{
    /// <summary>
    /// DE: Erzeugt eine parsebezogene Ausnahme mit Fehlerposition.
    /// EN: Creates a parse-related exception with an error position.
    /// </summary>
    /// <param name="message">
    /// DE: Beschreibung des Parse-Fehlers.
    /// EN: Description of the parse failure.
    /// </param>
    /// <param name="position">
    /// DE: 1-basierte Position im Ausdruck.
    /// EN: 1-based position in the expression.
    /// </param>
    public FormulaParseException(string message, int position)
        : base(message)
    {
        Position = position;
    }

    /// <summary>
    /// DE: 1-basierte Position des Fehlers im Ausdruck.
    /// EN: 1-based position of the error in the expression.
    /// </summary>
    public int Position { get; }
}
