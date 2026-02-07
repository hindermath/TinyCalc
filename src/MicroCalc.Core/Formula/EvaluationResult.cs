namespace MicroCalc.Core.Formula;

public sealed record EvaluationResult(
    bool Success,
    double Value,
    bool IsFormula,
    int ErrorPosition,
    string ErrorMessage)
{
    public static EvaluationResult Failed(string message, int errorPosition) =>
        new(false, 0, false, errorPosition, message);

    public static EvaluationResult Ok(double value, bool isFormula) =>
        new(true, value, isFormula, 0, string.Empty);
}
