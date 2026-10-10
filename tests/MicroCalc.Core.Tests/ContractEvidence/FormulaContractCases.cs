using System.Text.Json;

namespace MicroCalc.ContractEvidence;

internal static class FormulaContractCases
{
    internal static string RepositoryRoot
    {
        get
        {
            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            while (directory is not null && !File.Exists(Path.Combine(directory.FullName, "MicroCalc.sln")))
                directory = directory.Parent;
            return directory?.FullName ?? throw new DirectoryNotFoundException("Contract repository root absent.");
        }
    }

    internal static IEnumerable<JsonElement> Read()
    {
        using var document = JsonDocument.Parse(File.ReadAllText(Path.Combine(RepositoryRoot, "docs/contracts/tui/baseline-inventory.json")));
        // DE: Sollwerte kommen aus dem unabhängigen Quellinventar, niemals aus Evaluator- oder Ergebnis-Ausgaben.
        // EN: Expected values come from the independent source inventory, never evaluator or result output.
        return document.RootElement.GetProperty("offers").EnumerateArray()
            .Where(offer => offer.GetProperty("family").GetString() is "OP" or "REF" or "FUNC-LEGACY" or "FUNC-EXT")
            .Select(offer => offer.Clone()).ToArray();
    }

    internal static string Expression(JsonElement offer) => offer.GetProperty("input").GetString()![..^6];
    internal static JsonElement Find(string id) => Read().Single(offer => offer.GetProperty("id").GetString() == id);

    internal static void AssertNumeric(string id, double expected, double actual)
    {
        Assert.True(double.IsFinite(actual), $"{id}: non-finite successful result");
        var tolerance = id == "FUNC-LEGACY-fact-upper" ? Math.Abs(expected) * 1e-14
            : id.Contains("sin-", StringComparison.Ordinal) || id.Contains("cos-", StringComparison.Ordinal)
              || id.Contains("arctan-", StringComparison.Ordinal) || id.Contains("ln-", StringComparison.Ordinal)
              || id.Contains("exp-", StringComparison.Ordinal) || id.Contains("average-", StringComparison.Ordinal)
              || id.Contains("round-", StringComparison.Ordinal) ? 1e-12 : 0;
        Assert.True(Math.Abs(expected - actual) <= tolerance, $"{id}: expected {expected:R}, actual {actual:R}, tolerance {tolerance:R}");
    }
}
