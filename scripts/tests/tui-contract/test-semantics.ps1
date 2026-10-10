#Requires -Version 7
<#!
.SYNOPSIS
DE: Prüft synthetische vollständige Modelle und jede einzelne semantische Beschädigung.
EN: Tests synthetic complete models and each individual semantic corruption.
!#>
[CmdletBinding()]
param([string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$Root = [IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $Root 'scripts/lib/tui-contract/Semantics.ps1')

. (Join-Path $PSScriptRoot 'fixtures.ps1')

$Cases = @(
    @{ name = 'missing-id'; code = 'MissingObligation'; mutate = { param($m) $m.Contract.capabilities = @($m.Contract.capabilities | Select-Object -Skip 1) } },
    @{ name = 'duplicate-id'; code = 'DuplicateObligation'; mutate = { param($m) $m.Contract.capabilities += Copy-Model $m.Contract.capabilities[0] } },
    @{ name = 'coordinated-deletion'; code = 'MissingObligation'; mutate = { param($m) $id = $m.Contract.capabilities[2].paths[0].pathId; $m.Contract.capabilities[2].paths = @($m.Contract.capabilities[2].paths | Where-Object pathId -ne $id); foreach($b in $m.Bundles){$b.results = @($b.results | Where-Object pathId -ne $id)} } },
    @{ name = 'duplicate-alias'; code = 'DuplicateObligation'; mutate = { param($m) $m.Contract.capabilities[2].paths += Copy-Model $m.Contract.capabilities[2].paths[0] } },
    @{ name = 'changed-alias-input'; code = 'OracleDrift'; mutate = { param($m) $m.Contract.capabilities[2].paths[0].input = 'different key' } },
    @{ name = 'skip'; code = 'UnexecutedObligation'; mutate = { param($m) $m.Bundles[0].results[0].outcome = 'Skipped' } },
    @{ name = 'filter-gap'; code = 'MissingResult'; mutate = { param($m) $m.Bundles[0].results = @($m.Bundles[0].results | Select-Object -Skip 1) } },
    @{ name = 'timeout'; code = 'RunFailure'; mutate = { param($m) $m.Bundles[0].exitCode = 124 } },
    @{ name = 'weakened-assertion'; code = 'MissingAssertions'; mutate = { param($m) $m.Bundles[0].results[0].assertions = @() } },
    @{ name = 'unconditional-pass'; code = 'MissingObservation'; mutate = { param($m) $r=$m.Bundles[0].results[0]; $r.assertions[0].expected=@{descriptionEn='Pass'}; $r.assertions[0].actual=@{descriptionEn='Pass'} } },
    @{ name = 'false-pass-flag'; code = 'FailedAssertion'; mutate = { param($m) $m.Bundles[0].results[0].assertions[0].passed=$false } },
    @{ name = 'different-actual'; code = 'FailedAssertion'; mutate = { param($m) $m.Bundles[0].results[0].assertions[0].actual.focus='wrong view' } },
    @{ name = 'duplicate-assertion-id'; code = 'DuplicateAssertion'; mutate = { param($m) $r=$m.Bundles[0].results[0]; $r.assertions += Copy-Model $r.assertions[0] } },
    @{ name = 'lost-independent-observation'; code = 'MissingObservation'; mutate = { param($m) $r=$m.Bundles[0].results[0]; $r.assertions += @{id='extra-selection'; expected=@{selection='A1'}; actual=@{selection='A1'}; passed=$true} } },
    @{ name = 'contradicted-independent-observation'; code = 'FailedAssertion'; mutate = { param($m) $r=$m.Bundles[0].results[0]; $r.assertions += @{id='extra-selection'; expected=@{selection='A1'}; actual=@{selection='A1'}; passed=$true}; $r.observedState.selection='B1' } },
    @{ name = 'wrong-oracle'; code = 'OracleDrift'; mutate = { param($m) $r=$m.Bundles[0].results | Where-Object pathId -eq OP-power-right; $r.assertions[0].expected.value=64; $r.assertions[0].actual.value=64 } },
    @{ name = 'wrong-test-ref'; code = 'TestReferenceMismatch'; mutate = { param($m) $m.Bundles[0].results[0].testRef='not-the-declared-test' } },
    @{ name = 'missing-proof'; code = 'MissingProof'; mutate = { param($m) $m.Bundles[0].results[0].assertionProofRef='' } },
    @{ name = 'foreign-head'; code = 'StaleCommit'; mutate = { param($m) $m.Bundles[0].commit=('f'*40) } },
    @{ name = 'foreign-tree'; code = 'StaleWorkingTree'; mutate = { param($m) $m.Bundles[0].workingTreeDigest=('f'*64) } },
    @{ name = 'wrong-pin'; code = 'DigestMismatch'; mutate = { param($m) $m.Bundles[0].pinDecisionDigest=('f'*64) } },
    @{ name = 'mixed-revision'; code = 'DigestMismatch'; mutate = { param($m) $m.Bundles[0].contractDigest=('f'*64) }; after = $true },
    @{ name = 'payload-tamper'; code = 'DigestMismatch'; mutate = { param($m) $m.Bundles[0].payloadDigest=('f'*64) }; after = $true },
    @{ name = 'duplicate-tuple'; code = 'DuplicateResult'; mutate = { param($m) $m.Bundles[0].results += Copy-Model $m.Bundles[0].results[0] } },
    @{ name = 'human-instead-automated'; code = 'WrongEvidenceKind'; mutate = { param($m) $m.Bundles[0].results[0].kind='HumanSupplement' } },
    @{ name = 'missing-platform'; code = 'MissingResult'; mutate = { param($m) $m.Bundles=@($m.Bundles | Select-Object -First 2) } },
    @{ name = 'smoke-only'; code = 'MissingResult'; mutate = { param($m) foreach($b in $m.Bundles){$b.results=@($b.results | Where-Object pathId -eq APP-smoke-ok)} } },
    @{ name = 'unit-only'; code = 'MissingResult'; mutate = { param($m) foreach($b in $m.Bundles){$b.results=@($b.results | Where-Object capabilityId -eq FUNC-LEGACY-001)} } },
    @{ name = 'bad-timestamp'; code = 'InvalidTiming'; mutate = { param($m) $m.Bundles[0].results[0].finishedAt='2026-10-10T09:59:00Z' } },
    @{ name = 'interaction-overrun'; code = 'InvalidTiming'; mutate = { param($m) $m.Bundles[0].results[0].finishedAt='2026-10-10T10:00:32Z';$m.Bundles[0].finishedAt='2026-10-10T10:00:33Z' } }
)

$Failures = [Collections.Generic.List[string]]::new()
$Model = New-Model
$Positive = @(Test-TuiEvidenceModel @Model)
if ($Positive.Count -ne 0) { $Failures.Add('complete-positive: ' + (($Positive | ForEach-Object { $_.code + ':' + $_.sourceRef }) -join ',')) }
$Aggregate=New-Model
# DE: Viele isolierte, kurze Sitzungen sind kein einzelner 180-Sekunden-Prozess.
# EN: Many isolated short sessions are not one 180-second process.
$Aggregate.Bundles[0].finishedAt='2026-10-10T10:04:00Z'
Update-Model $Aggregate
if(@(Test-TuiEvidenceModel @Aggregate).Count){$Failures.Add('aggregate-is-not-an-isolated-session')}
foreach ($Case in $Cases) {
    $Model = New-Model
    if ($Case.ContainsKey('after')) { Update-Model $Model; & $Case.mutate $Model }
    else { & $Case.mutate $Model; Update-Model $Model }
    $Findings = @(Test-TuiEvidenceModel @Model)
    if ($Case.code -notin @($Findings | ForEach-Object code)) { $Failures.Add($Case.name + ': expected ' + $Case.code) }
}
foreach ($Failure in $Failures) { Write-Output ('FIXTURE_FAIL: ' + $Failure) }
Write-Output "SEMANTICS: $($Cases.Count + 2) cases; $($Failures.Count) failed. Synthetic validator fixtures only / Nur synthetische Validator-Fixtures."
if ($Failures.Count) { exit 1 }
