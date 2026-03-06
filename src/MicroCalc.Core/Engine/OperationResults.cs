namespace MicroCalc.Core.Engine;

/// <summary>
/// DE: Ergebnis einer Zellbearbeitung.
/// EN: Result of a cell edit operation.
/// </summary>
/// <param name="Success">
/// DE: True bei erfolgreicher Bearbeitung.
/// EN: True when the edit succeeded.
/// </param>
/// <param name="Message">
/// DE: Benutzernahe Rueckmeldung zur Operation.
/// EN: User-facing feedback message for the operation.
/// </param>
/// <param name="ErrorPosition">
/// DE: Fehlerposition im Ausdruck, 0 wenn nicht relevant.
/// EN: Error position in expression; 0 when not relevant.
/// </param>
public sealed record EditResult(bool Success, string Message, int ErrorPosition = 0);

/// <summary>
/// DE: Ergebnis einer Gesamtrechnung ueber alle Formelzellen.
/// EN: Result of a full recalculation across all formula cells.
/// </summary>
/// <param name="Success">
/// DE: True, wenn keine Berechnungsfehler auftraten.
/// EN: True if no calculation errors occurred.
/// </param>
/// <param name="Errors">
/// DE: Liste der Fehlertexte pro betroffener Zelle.
/// EN: List of error messages per affected cell.
/// </param>
public sealed record RecalculateResult(bool Success, IReadOnlyList<string> Errors)
{
    /// <summary>
    /// DE: Erzeugt ein erfolgreiches Recalculate-Ergebnis ohne Fehlerliste.
    /// EN: Creates a successful recalculation result with no errors.
    /// </summary>
    /// <returns>
    /// DE: Erfolgreiches Ergebnisobjekt.
    /// EN: Successful result object.
    /// </returns>
    public static RecalculateResult Ok() => new(true, Array.Empty<string>());
}
