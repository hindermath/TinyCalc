namespace MicroCalc.Core.Model;

/// <summary>
/// DE: Zustandsflags fuer Typ, Berechnung und Anzeige einer Zelle.
/// EN: State flags for cell type, calculation, and rendering.
/// </summary>
[Flags]
public enum CellStatusFlags
{
    /// <summary>
    /// DE: Kein gesetztes Flag.
    /// EN: No flag set.
    /// </summary>
    None = 0,
    /// <summary>
    /// DE: Zelle enthaelt einen numerischen oder auswertbaren Inhalt.
    /// EN: Cell contains numeric or evaluable content.
    /// </summary>
    Constant = 1,
    /// <summary>
    /// DE: Inhalt ist als Formel zu behandeln.
    /// EN: Content is treated as a formula.
    /// </summary>
    Formula = 2,
    /// <summary>
    /// DE: Zelle wird als Text interpretiert.
    /// EN: Cell is interpreted as text.
    /// </summary>
    Text = 4,
    /// <summary>
    /// DE: Zelle wird visuell vom linken Text ueberdeckt.
    /// EN: Cell is visually overwritten by text from the left.
    /// </summary>
    OverWritten = 8,
    /// <summary>
    /// DE: Zelle ist fuer direkte Eingabe gesperrt.
    /// EN: Cell is locked for direct input.
    /// </summary>
    Locked = 16,
    /// <summary>
    /// DE: Formelwert wurde erfolgreich berechnet.
    /// EN: Formula value was calculated successfully.
    /// </summary>
    Calculated = 32,
}
