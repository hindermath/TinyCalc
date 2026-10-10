using MicroCalc.ContractEvidence;
using System.Text.Json.Nodes;

namespace MicroCalc.Tui.Tests;

public sealed class EvidenceProducerTests
{
    [Theory]
    [Trait("Contract", "Producer")]
    [InlineData("MissingAssertions")]
    [InlineData("MissingResult")]
    [InlineData("DuplicateResult")]
    [InlineData("Skipped")]
    [InlineData("Timeout")]
    [InlineData("DigestMismatch")]
    [InlineData("FailedAssertion")]
    [InlineData("ForgedExpectedDigest")]
    [InlineData("UnexecutedAssertions")]
    public void ConcreteMalformedCandidate_IsRejected(string fault) => ProducerTestCases.AssertRejected(fault);

    [Fact]
    [Trait("Contract", "Producer")]
    public void PositiveCandidate_ProducesCompleteOutput() => ProducerTestCases.AssertCompleteOutput();

    [Fact]
    [Trait("Contract", "Producer")]
    public void InterruptedPublication_NeverReleasesPartialBundle() => ProducerTestCases.AssertInterruptedPublicationRejected();

    [Fact]
    [Trait("Contract", "Producer")]
    public void CanonicalBytes_MatchSharedFixtures() => ProducerTestCases.AssertCanonicalFixtures();

    [Fact]
    [Trait("Contract", "Producer")]
    public void AtomicPublication_PreservesOldProofUntilComplete() => ProducerTestCases.AssertAtomicPublication();

    [Theory]
    [InlineData("description", "MissingObservation")]
    [InlineData("duplicate", "DuplicateAssertion")]
    [InlineData("conflict", "ConflictingObservation")]
    public void ExecutedObservationDamage_IsRejected(string fault, string code)
    {
        var candidate = ProducerTestCases.Candidate();
        var assertions = candidate["results"]![0]!["assertions"]!.AsArray();
        assertions[0]!["expected"] = new JsonObject { ["focus"] = "Grid" };
        assertions[0]!["actual"] = new JsonObject { ["focus"] = "Grid" };
        if (fault == "description")
        {
            assertions[0]!["expected"] = new JsonObject { ["descriptionEn"] = "pass" };
            assertions[0]!["actual"] = new JsonObject { ["descriptionEn"] = "pass" };
        }
        else
        {
            assertions.Add(assertions[0]!.DeepClone());
            if (fault == "conflict")
            {
                assertions[1]!["id"] = "contradicting-state";
                assertions[1]!["expected"]!["focus"] = "Help";
                assertions[1]!["actual"]!["focus"] = "Help";
            }
        }
        var decision = EvidenceProducer.Validate(candidate, ProducerTestCases.RequiredTuples, ProducerTestCases.Context);
        Assert.False(decision.Accepted);
        Assert.Equal(code, decision.Code);
    }

    [Fact]
    public void BundleCreation_PreservesAllIndependentActualObservations()
    {
        var candidate = ProducerTestCases.Candidate();
        var assertions = candidate["results"]![0]!["assertions"]!.AsArray();
        assertions[0]!["expected"] = new JsonObject { ["focus"] = "Grid" };
        assertions[0]!["actual"] = new JsonObject { ["focus"] = "Grid" };
        assertions.Add(new JsonObject
        {
            ["id"] = "separate-cell-observation", ["expected"] = new JsonObject { ["value"] = 512 },
            ["actual"] = new JsonObject { ["value"] = 512 }, ["passed"] = true,
        });
        var bundle = EvidenceProducer.Create(candidate, ProducerTestCases.RequiredTuples, ProducerTestCases.Context);
        Assert.NotNull(bundle);
        Assert.Equal(512, bundle["results"]![0]!["observedState"]!["value"]?.GetValue<int>());
        Assert.Equal("Grid", bundle["results"]![0]!["observedState"]!["focus"]?.GetValue<string>());
    }

    [Fact]
    public void ApprovedNumericTolerance_DoesNotRoundAwayTheObservedNumber()
    {
        var candidate = ProducerTestCases.Candidate();
        const string tuple = "FUNC-LEGACY-001|FUNC-LEGACY-sin-half-pi|linux|Success";
        candidate["results"]![0]!["tuple"] = tuple;
        candidate["results"]![0]!["assertions"]![0]!["expected"] = new JsonObject { ["value"] = 1.0 };
        candidate["results"]![0]!["assertions"]![0]!["actual"] = new JsonObject { ["value"] = 1.0 + 1e-14 };
        var required = new[] { tuple, ProducerTestCases.RequiredTuples[1] };
        var bundle = EvidenceProducer.Create(candidate, required, ProducerTestCases.Context);
        Assert.NotNull(bundle);
        Assert.Equal(1.0 + 1e-14, bundle["results"]![0]!["observedState"]!["value"]!.GetValue<double>());
    }
}
