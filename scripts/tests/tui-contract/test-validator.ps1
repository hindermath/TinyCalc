#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft echte Validator-Dateigrenzen mit synthetischen Daten, keine Produktabnahme.
EN: Exercises actual validator file boundaries with synthetic data, not product acceptance.
#>
[CmdletBinding()]
param([string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$Root = [IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/test-tinycalc-contract.ps1')
. (Join-Path $PSScriptRoot 'fixtures.ps1')
$Owned = [IO.Directory]::CreateTempSubdirectory('tinycalc-validator-fixture-').FullName
function Write-Fixture([string]$Name, $Value) {
    $Path = Join-Path $Owned $Name
    [IO.File]::WriteAllText($Path, (ConvertTo-Json -InputObject $Value -Depth 80) + "`n", [Text.UTF8Encoding]::new($false))
    return $Name + '#sha256=' + (Get-FileHash $Path).Hash.ToLowerInvariant()
}
try {
    $Model = New-Model
    $TreeBefore = Get-TuiWorkingTreeDigest $Root
    $Model.Binding.commit = (& git -C $Root rev-parse HEAD)
    $Model.Binding.workingTreeDigest = $TreeBefore
    $Pin = Read-TuiJsonInput (Join-Path $Root 'specs/006-tui-functional-contract/evidence/pin-decision.json')
    $Impact = Read-TuiJsonInput (Join-Path $Root 'specs/006-tui-functional-contract/evidence/impact-decision.json')
    $Model.Binding.pinDecisionDigest = $Pin.decisionDigest
    foreach ($Capability in $Model.Contract.capabilities) {
        foreach ($Path in $Capability.paths) {
            # DE: Fixture-Referenz, nicht die Behauptung einer Ausführung dieses Produktpfads.
            # EN: Fixture reference, not a claim that this product path was executed.
            $Path.testRefs = @('tests/MicroCalc.Tui.Tests/TuiLifecycleContractTests.cs#synthetic-validator-fixture')
        }
    }
    $Model.Contract.revision++
    $null = Write-Fixture contract.json $Model.Contract
    $Model.Binding.contractDigest = Get-TuiCanonicalDigest ([IO.File]::ReadAllText((Join-Path $Owned 'contract.json')))
    [IO.File]::WriteAllText((Join-Path $Owned 'raw.txt'), 'Synthetic fixture, not native product or review evidence.')
    $RawRef = @{ path='raw.txt'; sha256=(Get-FileHash (Join-Path $Owned 'raw.txt')).Hash.ToLowerInvariant() }
    foreach ($Bundle in $Model.Bundles) {
        foreach ($Key in @('commit','workingTreeDigest','contractDigest','pinDecisionDigest')) { $Bundle[$Key] = $Model.Binding[$Key] }
        foreach ($Result in $Bundle.results) {
            $Result.testRef = 'tests/MicroCalc.Tui.Tests/TuiLifecycleContractTests.cs#synthetic-validator-fixture'
            $Proof = @{}
            foreach ($Key in @('capabilityId','pathId','scenarioKind','testRef','startedAt','finishedAt','assertions')) { $Proof[$Key] = $Result[$Key] }
            $Result.assertionProofRef = Write-Fixture ($Bundle.platform + '-' + $Result.pathId + '.proof.json') $Proof
            $Result.artifactRefs = @($RawRef)
        }
        # DE: Synthetisches TRX nur für Validatorfixtures; keine native Ausführung behaupten.
        # EN: Synthetic TRX for validator fixtures only; never claim native execution.
        $Xml=[Text.StringBuilder]::new('<TestRun><Results>')
        foreach($Result in $Bundle.results){
            $Name='MicroCalc.Tui.Tests.TuiLifecycleContractTests.Synthetic(id: "'+$Result.pathId+'")'
            $null=$Xml.Append('<UnitTestResult testName="'+[Security.SecurityElement]::Escape($Name)+'" outcome="Passed" startTime="2026-10-10T10:00:00Z" endTime="2026-10-10T10:00:03Z"/>')
        }
        $null=$Xml.Append('</Results></TestRun>')
        $TrxName=$Bundle.platform+'.trx'
        [IO.File]::WriteAllText((Join-Path $Owned $TrxName),$Xml.ToString())
        $Bundle.executionProofRef=$TrxName+'#sha256='+(Get-FileHash (Join-Path $Owned $TrxName)).Hash.ToLowerInvariant()
        $Bundle.payloadDigest = Get-TuiCanonicalDigest ($Bundle | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
        $null = Write-Fixture ($Bundle.platform + '.bundle.json') $Bundle
    }
    $GateProofs = @{ schemaVersion='1.0'; commit=$Model.Binding.commit; workingTreeDigest=$TreeBefore
        contractDigest=$Model.Binding.contractDigest; pinDecisionDigest=$Pin.decisionDigest
        impactDecisionDigest=$Impact.decisionDigest; gates=@() }
    $Graph=Get-TuiResolvedPinGraph $Root $Pin
    $Approval=Read-TuiJsonInput (Join-Path $Root $Pin.approvalRef)
    $Comparison=Read-TuiJsonInput (Join-Path $Root $Pin.comparisonEvidence)
    $Comparison.artifactVerified=$true
    $PinPolicy=Get-TuiPinPolicy $Pin $Graph $Approval $Comparison
    $ImpactPolicy=Get-TuiImpactPolicy $Impact $PinPolicy.state
    foreach ($Id in @(@($Pin.requiredGates) + @($Impact.requiredGates) + @($PinPolicy.requiredGates) + @($ImpactPolicy.requiredGates) | Sort-Object -Unique)) {
        $Kind = if ($Id -match 'Human|VoiceOver') { 'HumanSupplement' }
            elseif ($Id -match 'SecurityReview|ArchitectureReview') { 'IndependentReview' } else { 'Automated' }
        $GateProofs.gates += @{ id=$Id; kind=$Kind; outcome='Pass'; reviewer='synthetic fixture, not a human reviewer'
            command='data only: never execute this field'; startedAt='2026-10-10T10:00:00Z'; finishedAt='2026-10-10T10:00:03Z'; artifactRefs=@($RawRef) }
    }
    $GateProofs.payloadDigest = Get-TuiCanonicalDigest ($GateProofs | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
    $null = Write-Fixture gate-proofs.json $GateProofs
    $Parameters = @{ RepositoryRoot=$Root; EvidenceRoot=$Owned; Evidence=$Owned; Contract=(Join-Path $Owned 'contract.json') }
    $Positive = Test-TinyCalcContract @Parameters
    if ($Positive.exitCode -ne 0 -or $Positive.counts.requiredTuples -ne 1092) {
        $Positive | ConvertTo-Json -Depth 12
        throw 'Complete synthetic fixture failed.'
    }
    $Preview = Test-TinyCalcContract @Parameters -WhatIf
    if ((Get-TuiCanonicalDigest ($Positive | ConvertTo-Json -Depth 12)) -cne (Get-TuiCanonicalDigest ($Preview | ConvertTo-Json -Depth 12))) {
        [pscustomobject]@{normal=$Positive;preview=$Preview} | ConvertTo-Json -Depth 15
        throw 'Preview differs.'
    }
    $Bundle = $Model.Bundles[0]
    $Bundle.results[0].outcome = 'Skipped'
    $Bundle.payloadDigest = Get-TuiCanonicalDigest ($Bundle | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
    $null = Write-Fixture ($Bundle.platform + '.bundle.json') $Bundle
    $Negative = Test-TinyCalcContract @Parameters
    if ($Negative.exitCode -ne 1 -or 'UnexecutedObligation' -notin $Negative.findings.code) { throw 'Skipped result accepted.' }
    $Bundle.results[0].outcome='Pass'
    $TrxName=$Bundle.platform+'.trx'
    $TrxPath=Join-Path $Owned $TrxName
    $Text=[IO.File]::ReadAllText($TrxPath).Replace('TuiLifecycleContractTests.Synthetic','EvidenceProducerTests.Synthetic')
    [IO.File]::WriteAllText($TrxPath,$Text)
    $Bundle.executionProofRef=$TrxName+'#sha256='+(Get-FileHash $TrxPath).Hash.ToLowerInvariant()
    $Bundle.payloadDigest=Get-TuiCanonicalDigest ($Bundle | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
    $null=Write-Fixture ($Bundle.platform+'.bundle.json') $Bundle
    $WrongClass=Test-TinyCalcContract @Parameters
    if($WrongClass.exitCode -ne 1 -or 'MissingPassedExecution' -notin $WrongClass.findings.code){throw 'Wrong-class TRX accepted.'}
    $TreeAfter = Get-TuiWorkingTreeDigest $Root
    if ($TreeBefore -cne $TreeAfter) { throw 'Validator changed repository bytes.' }
    Write-Output 'VALIDATOR_PASS: complete synthetic 1092-tuple model, identical zero-write preview, rejected Skip and wrong-class TRX. Not native acceptance.'
}
finally { [IO.Directory]::Delete($Owned, $true) }
