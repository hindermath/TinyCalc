namespace MicroCalc.Core.Formula;

internal sealed class FormulaParseException : Exception
{
    public FormulaParseException(string message, int position)
        : base(message)
    {
        Position = position;
    }

    public int Position { get; }
}
