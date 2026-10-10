using System.Text.Json.Nodes;

namespace MicroCalc.ContractEvidence;

internal static class ProducerTestCases
{
    internal static readonly string[] RequiredTuples = ["EDIT-001|accept|linux|Success", "EDIT-001|cancel|linux|Cancel"];
    internal static readonly EvidenceProducer.Context Context = new(new string('c', 40), new string('d', 64),
        new string('a', 64), new string('e', 64), "linux", "isolated-fixture", "isolated-fixture-not-acceptance",
        "producer-unit-fixture", new Dictionary<string, string> { ["dotnet"] = Environment.Version.ToString() },
        "fixture-only/execution.trx#sha256=" + new string('a', 64));

    internal static JsonObject Candidate()
    {
        var candidate = new JsonObject
        {
        ["contractDigest"] = new string('a', 64),
        ["startedAt"] = DateTimeOffset.UtcNow.ToString("O"),
        ["finishedAt"] = DateTimeOffset.UtcNow.ToString("O"),
        ["exitCode"] = 0,
        ["results"] = new JsonArray(RequiredTuples.Select(tuple => (JsonNode)new JsonObject
        {
            ["tuple"] = tuple,
            ["outcome"] = "Pass",
            ["testRef"] = "tests/MicroCalc.Core.Tests/EvidenceProducerTests.cs",
            ["assertionProofRef"] = "tests/MicroCalc.Core.Tests/ContractEvidence/ProducerTestCases.cs",
            ["startedAt"] = DateTimeOffset.UtcNow.ToString("O"),
            ["finishedAt"] = DateTimeOffset.UtcNow.ToString("O"),
            ["artifactRefs"] = new JsonArray(),
            ["assertions"] = new JsonArray(new JsonObject
            {
                ["id"] = "independent-state-comparison",
                ["expected"] = new JsonObject { ["focus"] = "Grid" },
                ["actual"] = new JsonObject { ["focus"] = "Grid" },
                ["passed"] = true,
            }),
        }).ToArray()),
        };
        candidate["finishedAt"] = DateTimeOffset.UtcNow.ToString("O");
        return candidate;
    }

    // DE: Konkrete fehlerhafte Kandidaten prüfen Ablehnung statt bloß fehlender Ausgabe.
    // EN: Concrete malformed candidates test rejection, not merely absent output.
    internal static JsonObject Malformed(string fault)
    {
        var candidate = Candidate();
        var results = candidate["results"]!.AsArray();
        switch (fault)
        {
            case "MissingAssertions": results[0]!["assertions"] = new JsonArray(); break;
            case "MissingResult": results.RemoveAt(0); break;
            case "DuplicateResult": results.Add(results[0]!.DeepClone()); break;
            case "Skipped": results[0]!["outcome"] = "Skipped"; break;
            case "Timeout": candidate["exitCode"] = 124; break;
            case "DigestMismatch": candidate["contractDigest"] = new string('b', 64); break;
            case "FailedAssertion": results[0]!["assertions"]![0]!["actual"]!["focus"] = "Help"; break;
            case "ForgedExpectedDigest": candidate["contractDigest"] = new string('b', 64); candidate["expectedContractDigest"] = new string('b', 64); break;
            case "UnexecutedAssertions": results[0]!["assertions"]![0]!["expected"] = null; results[0]!["assertions"]![0]!["actual"] = null; break;
            default: throw new ArgumentException("Unknown isolated fixture", nameof(fault));
        }
        return candidate;
    }

    internal static void AssertRejected(string fault)
    {
        var concreteCandidate = Malformed(fault);
        Assert.NotNull(concreteCandidate["results"]);
        var decision = EvidenceProducer.Validate(concreteCandidate, RequiredTuples, Context);
        Assert.False(decision.Accepted, $"Malformed candidate accepted: {fault}");
        Assert.Equal(fault == "ForgedExpectedDigest" ? "DigestMismatch" : fault == "UnexecutedAssertions" ? "FailedAssertion" : fault, decision.Code);
    }

    internal static void AssertCompleteOutput()
    {
        var output = EvidenceProducer.Create(Candidate(), RequiredTuples, Context);
        Assert.NotNull(output);
        Assert.Equal(RequiredTuples.Length, output["results"]!.AsArray().Count);
        Assert.Equal("1.0", output["schemaVersion"]!.GetValue<string>());
        Assert.Equal(Context.Commit, output["commit"]!.GetValue<string>());
        Assert.Equal(EvidenceProducer.CanonicalDigest(output, "payloadDigest"), output["payloadDigest"]!.GetValue<string>());
        var directory = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "TestResults"));
        Directory.CreateDirectory(directory);
        File.WriteAllText(Path.Combine(directory, "producer-fixture.json"), output.ToJsonString() + "\n");
    }

    internal static void AssertCanonicalFixtures()
    {
        var root = new DirectoryInfo(AppContext.BaseDirectory);
        while (root is not null && !File.Exists(Path.Combine(root.FullName, "MicroCalc.sln")))
            root = root.Parent;
        Assert.NotNull(root);
        var cases = JsonNode.Parse(File.ReadAllText(Path.Combine(root.FullName,
            "scripts", "tests", "tui-contract", "canonical-cases.json")))!;
        foreach (var pair in cases["equivalent"]!.AsArray())
            Assert.Equal(EvidenceProducer.CanonicalDigest(JsonNode.Parse(pair!["left"]!.GetValue<string>())!.AsObject()),
                EvidenceProducer.CanonicalDigest(JsonNode.Parse(pair["right"]!.GetValue<string>())!.AsObject()));
        foreach (var pair in cases["different"]!.AsArray())
            Assert.NotEqual(EvidenceProducer.CanonicalDigest(JsonNode.Parse(pair!["left"]!.GetValue<string>())!.AsObject()),
                EvidenceProducer.CanonicalDigest(JsonNode.Parse(pair["right"]!.GetValue<string>())!.AsObject()));
        foreach (var invalid in cases["invalid"]!.AsArray())
            Assert.Throws<ArgumentException>(() => EvidenceProducer.CanonicalDigest(JsonNode.Parse(invalid!.GetValue<string>())!.AsObject(), "decisionDigest"));
    }

    internal static void AssertInterruptedPublicationRejected()
    {
        var directory = Path.Combine(Path.GetTempPath(), "tinycalc-producer-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, "bundle.json");
        try
        {
            var decision = EvidenceProducer.Publish(Candidate(), RequiredTuples, Context, path, interrupt: true);
            Assert.False(decision.Accepted, $"Interrupted publication accepted; partialVisible={File.Exists(path)}");
            Assert.Equal("Interrupted", decision.Code);
            Assert.False(File.Exists(path));
        }
        finally
        {
            // DE: Nur die selbst angelegte temporäre Sitzung entfernen.
            // EN: Remove only the temporary session owned by this test.
            Directory.Delete(directory, recursive: true);
        }
    }

    internal static void AssertAtomicPublication()
    {
        var directory = Path.Combine(Path.GetTempPath(), "tinycalc-producer-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        var path = Path.Combine(directory, "bundle.json");
        try
        {
            File.WriteAllText(path, "existing-proof");
            var interrupted = EvidenceProducer.Publish(Candidate(), RequiredTuples, Context, path, interrupt: true);
            Assert.False(interrupted.Accepted);
            Assert.Equal("existing-proof", File.ReadAllText(path));
            var published = EvidenceProducer.Publish(Candidate(), RequiredTuples, Context, path, interrupt: false);
            Assert.True(published.Accepted);
            var bundle = JsonNode.Parse(File.ReadAllText(path))!.AsObject();
            Assert.Equal(RequiredTuples.Length, bundle["results"]!.AsArray().Count);
            Assert.Equal(EvidenceProducer.CanonicalDigest(bundle, "payloadDigest"), bundle["payloadDigest"]!.GetValue<string>());
            Assert.Single(Directory.GetFiles(directory));
        }
        finally { Directory.Delete(directory, recursive: true); }
    }
}
