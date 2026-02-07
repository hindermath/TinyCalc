namespace MicroCalc.Core.Model;

[Flags]
public enum CellStatusFlags
{
    None = 0,
    Constant = 1,
    Formula = 2,
    Text = 4,
    OverWritten = 8,
    Locked = 16,
    Calculated = 32,
}
