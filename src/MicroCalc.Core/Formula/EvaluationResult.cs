namespace MicroCalc.Core.Formula;

/// <summary>
/// DE: Ergebnis der Auswertung eines Ausdrucks.
/// EN: Result of evaluating one expression.
/// </summary>
/// <param name="Success">
/// DE: True bei erfolgreicher Auswertung.
/// EN: True when evaluation succeeded.
/// </param>
/// <param name="Value">
/// DE: Berechneter Zahlenwert.
/// EN: Computed numeric value.
/// </param>
/// <param name="IsFormula">
/// DE: True, wenn der Ausdruck als Formel erkannt wurde.
/// EN: True when the expression was recognized as a formula.
/// </param>
/// <param name="ErrorPosition">
/// DE: Fehlerposition im Ausdruck; 0 bei Erfolg.
/// EN: Error position in expression; 0 on success.
/// </param>
/// <param name="ErrorMessage">
/// DE: Fehlermeldung; leer bei Erfolg.
/// EN: Error message; empty on success.
/// </param>
public sealed record EvaluationResult(
    bool Success,
    double Value,
    bool IsFormula,
    int ErrorPosition,
    string ErrorMessage)
{
    /// <summary>
    /// DE: Erzeugt ein fehlgeschlagenes Auswertungsergebnis.
    /// EN: Creates a failed evaluation result.
    /// </summary>
    /// <param name="message">
    /// DE: Fehlermeldung.
    /// EN: Error message.
    /// </param>
    /// <param name="errorPosition">
    /// DE: Position des Fehlers im Ausdruck.
    /// EN: Position of the error in the expression.
    /// </param>
    /// <returns>
    /// DE: Fehlerergebnis.
    /// EN: Failed result.
    /// </returns>
    public static EvaluationResult Failed(string message, int errorPosition) =>
        new(false, 0, false, errorPosition, message);

    /// <summary>
    /// DE: Erzeugt ein erfolgreiches Auswertungsergebnis.
    /// EN: Creates a successful evaluation result.
    /// </summary>
    /// <param name="value">
    /// DE: Berechneter Wert.
    /// EN: Computed value.
    /// </param>
    /// <param name="isFormula">
    /// DE: Kennzeichen, ob es eine Formel war.
    /// EN: Flag indicating whether it was a formula.
    /// </param>
    /// <returns>
    /// DE: Erfolgsobjekt.
    /// EN: Successful result object.
    /// </returns>
    public static EvaluationResult Ok(double value, bool isFormula) =>
        new(true, value, isFormula, 0, string.Empty);
}
