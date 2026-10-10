using MicroCalc.ContractEvidence;
using MicroCalc.Core.Engine;
using MicroCalc.Core.Formula;
using MicroCalc.Core.Model;

namespace MicroCalc.Core.Tests;

public sealed class FormulaContractTests
{
    public static IEnumerable<object[]> Cases() => FormulaContractCases.Read().Select(offer => new object[] { offer.GetProperty("id").GetString()! });

    [Theory]
    [MemberData(nameof(Cases))]
    [Trait("Contract", "Formula")]
    public void EveryIndependentFormulaOracle_IsEnforced(string id)
    {
        var offer = FormulaContractCases.Find(id);
        var engine = new MicroCalcEngine();
        foreach (var cell in offer.GetProperty("setup").GetProperty("cells").EnumerateObject())
        {
            Assert.True(CellAddress.TryParse(cell.Name, out var address));
            Assert.True(engine.EditCell(address, cell.Value.GetString()!).Success);
        }
        if (id == "REF-cycle")
        {
            var cyclic = engine.Sheet.GetCell('A', 1);
            cyclic.Contents = "A1";
            cyclic.Status = CellStatusFlags.Constant | CellStatusFlags.Formula;
        }
        var result = new FormulaEvaluator().Evaluate(FormulaContractCases.Expression(offer), engine.Sheet);
        if (offer.GetProperty("scenarioKind").GetString() == "Error")
        {
            Assert.False(result.Success, $"{id}: invalid formula accepted with value {result.Value:R}");
            Assert.NotEmpty(result.ErrorMessage);
            Assert.True(result.ErrorPosition > 0);
        }
        else
        {
            Assert.True(result.Success, $"{id}: {result.ErrorMessage}");
            FormulaContractCases.AssertNumeric(id, offer.GetProperty("oracle").GetDouble(), result.Value);
        }
    }
}
