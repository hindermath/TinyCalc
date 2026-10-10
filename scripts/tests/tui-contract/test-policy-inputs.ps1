#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft die öffentliche Policy-Integration ohne Produkt- oder Providerstart.
EN: Tests public policy integration without product or provider execution.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'),[switch]$DiagnosticOnly)
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/test-tinycalc-contract.ps1')
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc-policy-inputs-').FullName
$Before=Get-TuiWorkingTreeDigest $Root
$Failures=[Collections.Generic.List[string]]::new()
function Write-Decision([string]$Name,$Value) {
    $Value.decisionDigest=Get-TuiCanonicalDigest ($Value | ConvertTo-Json -Depth 40) -ExcludeRootProperty decisionDigest
    $Path=Join-Path $Owned $Name
    [IO.File]::WriteAllText($Path,($Value | ConvertTo-Json -Depth 40)+"`n",[Text.UTF8Encoding]::new($false))
    return $Path
}
try {
    if(-not $DiagnosticOnly) {
    foreach($Case in @(
        @{name='unknown';classes=@('unknown-impact');paths=@('docs/notes.md');voice=$true;docfx=$false},
        @{name='text-only';classes=@('NoFunctionalImpact');paths=@('docs/notes.md');voice=$false;docfx=$false},
        @{name='docfx';classes=@('NoFunctionalImpact');paths=@('docfx.json');voice=$false;docfx=$true},
        @{name='major';classes=@('NoFunctionalImpact');paths=@('src/MicroCalc.Tui/TuiSession.cs');voice=$true;docfx=$false}
    )) {
        $Impact=Read-TuiJsonInput (Join-Path $Root 'specs/006-tui-functional-contract/evidence/impact-decision.json')
        $Impact.classes=$Case.classes;$Impact.changedPaths=$Case.paths;$Impact.requiredGates=@()
        $Path=Write-Decision ($Case.name+'.json') $Impact
        $Result=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -ImpactDecision $Path -Evidence (Join-Path $Owned 'absent-runs')
        if($Result.exitCode -ne 2 -or (('HumanVoiceOver' -in $Result.requiredGates) -ne $Case.voice) -or
            (('DocFxAxeLynx' -in $Result.requiredGates) -ne $Case.docfx) -or 'FullFunctionalLinuxWindows' -notin $Result.requiredGates){$Failures.Add($Case.name)}
    }
    $Pin=Read-TuiJsonInput (Join-Path $Root 'specs/006-tui-functional-contract/evidence/pin-decision.json')
    $Pin.comparisonEvidence='specs/006-tui-functional-contract/evidence/absent-comparison.json'
    $Path=Write-Decision 'missing-comparison.json' $Pin
    $Result=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -PinDecision $Path -Evidence (Join-Path $Owned 'absent-runs')
    if('PinStateMismatch' -notin $Result.findings.code -or 'HumanVoiceOver' -notin $Result.requiredGates){$Failures.Add('missing-comparison-must-not-reuse')}
    $Pin.approvalRef=[IO.Path]::GetFullPath((Join-Path $Root 'specs/006-tui-functional-contract/evidence/pin-approval.json'))
    $Path=Write-Decision 'absolute-approval.json' $Pin
    $Result=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -PinDecision $Path
    if($Result.exitCode -ne 2 -or 'UnsafePath' -notin $Result.findings.code){$Failures.Add('absolute-json-approval')}
    foreach($Kind in @('pin','impact','source')) {
        $Value=Read-TuiJsonInput (Join-Path $Root $(if($Kind -eq 'source'){'docs/contracts/tui/source-map.json'}else{"specs/006-tui-functional-contract/evidence/$Kind-decision.json"}))
        if($Kind -eq 'source'){$Value.mappings[0].sourceHash='f'*64}else{$Value.decisionDigest='f'*64}
        $Path=Join-Path $Owned ($Kind+'-tampered.json')
        [IO.File]::WriteAllText($Path,($Value | ConvertTo-Json -Depth 60)+"`n",[Text.UTF8Encoding]::new($false))
        $Parameters=@{RepositoryRoot=$Root;EvidenceRoot=$Owned;Evidence=(Join-Path $Owned 'absent-runs')}
        $Parameters[$(if($Kind -eq 'source'){'SourceMap'}elseif($Kind -eq 'pin'){'PinDecision'}else{'ImpactDecision'})]=$Path
        $Result=Test-TinyCalcContract @Parameters
        $Expected=if($Kind -eq 'source'){'SourceDrift'}else{'DigestMismatch'}
        if($Result.exitCode -ne 1 -or $Expected -notin $Result.findings.code){$Failures.Add($Kind+'-tamper')}
    }
    }
    $ContractFixture=Read-TuiJsonInput (Join-Path $Root 'docs/contracts/tui/product-contract.json')
    $PrivateMarker='/Users/private-fixture-owner/workbook'+[char]27+'[31m'
    $ContractFixture.capabilities[0].id=$PrivateMarker
    $ContractFixture.revision++
    $Path=Join-Path $Owned 'unsafe-diagnostic.json'
    [IO.File]::WriteAllText($Path,($ContractFixture | ConvertTo-Json -Depth 80)+"`n",[Text.UTF8Encoding]::new($false))
    $Result=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -Contract $Path
    $Output=$Result | ConvertTo-Json -Depth 15 -Compress
    if($Result.exitCode -ne 1 -or $Output.Contains('private-fixture-owner') -or $Output.Contains('\u001b')){$Failures.Add('private-or-ansi-diagnostic')}
    $Impact=Read-TuiJsonInput (Join-Path $Root 'specs/006-tui-functional-contract/evidence/impact-decision.json')
    $Impact.requiredGates=@($PrivateMarker)
    $Path=Write-Decision 'unsafe-gate-diagnostic.json' $Impact
    $Result=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -ImpactDecision $Path -Evidence (Join-Path $Owned 'absent-runs')
    $Output=$Result | ConvertTo-Json -Depth 15 -Compress
    if($Result.exitCode -ne 2 -or $Output.Contains('private-fixture-owner') -or $Output.Contains('\u001b')){$Failures.Add('private-or-ansi-gate')}
    if((Get-TuiWorkingTreeDigest $Root) -cne $Before){$Failures.Add('repository-written')}
    foreach($Failure in $Failures){Write-Output "PUBLIC_POLICY_FAIL: $Failure"}
    $Checks=if($DiagnosticOnly){3}else{12}
    Write-Output "PUBLIC_POLICY: $Checks checks; $($Failures.Count) failed. Missing run evidence remains Blocked, not accepted."
    if($Failures.Count){exit 1}
}
finally{[IO.Directory]::Delete($Owned,$true)}
