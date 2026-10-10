using System.Text.Json.Nodes;
using MicroCalc.ContractEvidence;

namespace MicroCalc.Tui.Tests;

public sealed class ExecutedPathProofTests
{
    [Fact]
    public void RawTerminalArtifacts_AreCopiedAndHashBoundBeforePublication()
    {
        using var owned = new OwnedProofDirectory();
        var proof = new ExecutedPathProof("OP-power-right");
        var expected = new JsonObject { ["focus"] = "Grid", ["value"] = 512, ["error"] = false };
        Assert.True(proof.Observe("valid", expected, expected).Accepted);
        var raw = new byte[] { 27, 91, 72, 65 };
        var record = proof.Complete(owned.Path, "grid", "status", new Dictionary<string, byte[]> { ["raw-trace.bin"] = raw });
        Assert.NotNull(record);
        var artifact = Assert.Single(record["artifactRefs"]!.AsArray(), item => item!["path"]!.GetValue<string>().EndsWith("raw-trace.bin", StringComparison.Ordinal))!;
        raw[0] = 0;
        var copied = File.ReadAllBytes(System.IO.Path.Combine(FormulaContractCases.RepositoryRoot, artifact["path"]!.GetValue<string>()));
        Assert.Equal(27, copied[0]);
        Assert.Equal(Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(copied)).ToLowerInvariant(), artifact["sha256"]!.GetValue<string>());
    }

    [Theory]
    [InlineData("../escape.bin")]
    [InlineData("grid.txt")]
    [InlineData("raw.json")]
    public void InvalidRawArtifactName_CannotPublish(string name)
    {
        using var owned = new OwnedProofDirectory();
        var proof = new ExecutedPathProof("OP-power-right");
        var expected = new JsonObject { ["focus"] = "Grid", ["value"] = 512, ["error"] = false };
        Assert.True(proof.Observe("valid", expected, expected).Accepted);
        Assert.Throws<ArgumentException>(() => proof.Complete(owned.Path, "grid", "status", new Dictionary<string, byte[]> { [name] = [1] }));
        Assert.Empty(Directory.GetFiles(owned.Path, "*", SearchOption.AllDirectories));
    }
    [Theory]
    [InlineData("different-actual", "FailedAssertion")]
    [InlineData("description-only", "MissingObservation")]
    [InlineData("duplicate-assertion", "DuplicateAssertion")]
    [InlineData("conflicting-observation", "ConflictingObservation")]
    [InlineData("outside-tolerance", "FailedAssertion")]
    public void MalformedExecutedObservation_IsRejected(string fault, string code)
    {
        var proof = new ExecutedPathProof("FUNC-LEGACY-sin-half-pi");
        var expected = new JsonObject { ["focus"] = "Grid" };
        var actual = (JsonObject)expected.DeepClone();
        if (fault == "different-actual") actual["focus"] = "Editor";
        if (fault == "description-only") expected = actual = new JsonObject { ["descriptionEn"] = "pass" };
        if (fault is "duplicate-assertion" or "conflicting-observation")
            Assert.True(proof.Observe("first", expected, actual).Accepted);
        if (fault == "conflicting-observation") expected = actual = new JsonObject { ["focus"] = "Help" };
        if (fault == "outside-tolerance")
        {
            expected = new JsonObject { ["value"] = 0.5 };
            actual = new JsonObject { ["value"] = 0.500001 };
        }
        var result = proof.Observe(fault == "duplicate-assertion" ? "first" : "second", expected, actual);
        Assert.False(result.Accepted);
        Assert.Equal(code, result.Code);
    }

    [Fact]
    public void SuccessfulExecution_PreservesEveryIndependentObservationAndActualNumber()
    {
        using var owned = new OwnedProofDirectory();
        var proof = new ExecutedPathProof("FUNC-LEGACY-sin-half-pi");
        var expected = 1.0;
        var actual = expected + 1e-14;
        Assert.True(proof.Observe("value", new JsonObject { ["value"] = expected, ["error"] = false },
            new JsonObject { ["value"] = actual, ["error"] = false }).Accepted);
        Assert.True(proof.Observe("ui", new JsonObject { ["focus"] = "Grid", ["selection"] = "A1" },
            new JsonObject { ["focus"] = "Grid", ["selection"] = "A1" }).Accepted);
        var record = proof.Complete(owned.Path, "A B C D E F G", "A1 Formula AutoCalc: ON");
        Assert.NotNull(record);
        Assert.Equal(actual, record["observedState"]!["value"]!.GetValue<double>());
        Assert.Equal("A1", record["observedState"]!["selection"]!.GetValue<string>());
        Assert.Equal(2, record["assertions"]!.AsArray().Count);
        Assert.Contains("#sha256=", record["assertionProofRef"]!.GetValue<string>());
        Assert.All(record["artifactRefs"]!.AsArray(), artifact =>
        {
            Assert.NotNull(artifact!["path"]);
            Assert.Equal(64, artifact["sha256"]!.GetValue<string>().Length);
        });
        Assert.Equal(4, Directory.GetFiles(owned.Path, "*", SearchOption.AllDirectories).Length);
        var proofFile = record["assertionProofRef"]!.GetValue<string>().Split("#sha256=");
        Assert.Contains("/path-", proofFile[0]);
        var bytes = File.ReadAllBytes(System.IO.Path.Combine(FormulaContractCases.RepositoryRoot, proofFile[0]));
        Assert.Equal(proofFile[1], Convert.ToHexString(System.Security.Cryptography.SHA256.HashData(bytes)).ToLowerInvariant());
        var envelope = JsonNode.Parse(bytes)!;
        foreach (var key in new[] { "capabilityId", "pathId", "scenarioKind", "testRef", "startedAt", "finishedAt", "assertions" })
            Assert.True(JsonNode.DeepEquals(record[key], envelope[key]), key);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public void IncompleteOrFailedExecution_NeverPublishes(bool failed)
    {
        using var owned = new OwnedProofDirectory();
        var proof = new ExecutedPathProof("OP-power-right");
        if (failed)
            proof.Observe("bad-value", new JsonObject { ["value"] = 512 }, new JsonObject { ["value"] = 64 });
        Assert.Null(proof.Complete(owned.Path, "grid", "status"));
        Assert.Empty(Directory.GetFiles(owned.Path));
    }

    [Fact]
    public void MissingContractObservation_NeverPublishes()
    {
        using var owned = new OwnedProofDirectory();
        var proof = new ExecutedPathProof("OP-power-right");
        Assert.True(proof.Observe("focus", new JsonObject { ["focus"] = "Grid" }, new JsonObject { ["focus"] = "Grid" }).Accepted);
        Assert.Null(proof.Complete(owned.Path, "grid", "status"));
        Assert.Empty(Directory.GetFiles(owned.Path));
    }

    [Fact]
    public void ConsistentButWrongIndependentOracle_CannotPublish()
    {
        using var owned = new OwnedProofDirectory();
        var proof = new ExecutedPathProof("OP-power-right");
        var wrong = new JsonObject { ["focus"] = "Grid", ["value"] = 64, ["error"] = false };
        Assert.True(proof.Observe("wrong-oracle", wrong, wrong).Accepted);
        Assert.Null(proof.Complete(owned.Path, "grid", "status"));
        Assert.Empty(Directory.GetFiles(owned.Path));
    }

    [Theory]
    [InlineData("unknown")]
    [InlineData("descriptionEn")]
    [InlineData("value")]
    [InlineData("error")]
    public void UntypedOrUnknownProperties_AreRejected(string key)
    {
        var proof = new ExecutedPathProof("OP-power-right");
        var untyped = new JsonObject { [key] = "true" };
        Assert.False(proof.Observe("untyped", untyped, untyped).Accepted);
    }

    [Fact]
    public void OutputOutsideOwnedTestResults_IsRejectedWithoutWrites()
    {
        var proof = new ExecutedPathProof("OP-power-right");
        var expected = new JsonObject { ["focus"] = "Grid", ["value"] = 512, ["error"] = false };
        Assert.True(proof.Observe("valid", expected, expected).Accepted);
        Assert.Throws<ArgumentException>(() => proof.Complete(FormulaContractCases.RepositoryRoot, "grid", "status"));
    }

    [Fact]
    public void ExecutionClock_CannotRestartOrDiscardEarlierAssertions()
    {
        var proof = new ExecutedPathProof("OP-power-right");
        proof.BeginExecution();
        Assert.Throws<InvalidOperationException>(() => proof.BeginExecution());
        var alreadyObserved = new ExecutedPathProof("OP-power-right");
        var observation = new JsonObject { ["focus"] = "Grid" };
        Assert.True(alreadyObserved.Observe("focus", observation, observation).Accepted);
        Assert.Throws<InvalidOperationException>(() => alreadyObserved.BeginExecution());
    }

    private sealed class OwnedProofDirectory : IDisposable
    {
        internal string Path { get; } = System.IO.Path.Combine(FormulaContractCases.RepositoryRoot,
            "tests/MicroCalc.Tui.Tests/TestResults", "proof-fixture-" + Guid.NewGuid().ToString("N"));
        internal OwnedProofDirectory() => Directory.CreateDirectory(Path);
        public void Dispose() => Directory.Delete(Path, recursive: true);
    }
}
