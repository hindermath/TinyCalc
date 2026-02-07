namespace MicroCalc.Core.Engine;

public sealed record EditResult(bool Success, string Message, int ErrorPosition = 0);

public sealed record RecalculateResult(bool Success, IReadOnlyList<string> Errors)
{
    public static RecalculateResult Ok() => new(true, Array.Empty<string>());
}
