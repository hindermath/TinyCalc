using MicroCalc.ContractEvidence;

namespace MicroCalc.Core.Tests;

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
}
