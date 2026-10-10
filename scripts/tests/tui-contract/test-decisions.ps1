#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft Pin-, Impact- und Historienentscheidungen mit isolierten synthetischen Daten.
EN: Tests pin, impact and history policy using isolated synthetic data.
#>
[CmdletBinding()]
param([string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$Root = [IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $Root 'scripts/lib/tui-contract/Decisions.ps1')
function Copy-Policy($Value) { ConvertFrom-Json -AsHashtable -InputObject (ConvertTo-Json -InputObject $Value -Depth 60) }
function New-PinFixture {
    $Graph = @{ dependency='Terminal.Gui'; resolvedVersion='9.8.7'; declarations=@('a','b','c','d'); locks=@('e','f','g','h'); sourceRefs=@('https://registry.example/v3/index.json'); coherent=$true }
    $Digest = Get-TuiCanonicalDigest ($Graph | ConvertTo-Json -Depth 30)
    return @{ Decision=@{ state='AlreadySatisfied'; resolvedVersion='9.8.7'; sourceRefs=$Graph.sourceRefs; requiredGates=@('FullFunctionalLinuxWindows') }
        Current=$Graph; Approval=@{ graphDigest=$Digest; approvalRef='synthetic-owner-reference' }
        Comparison=@{ graphDigest=$Digest; approvalDigest=(Get-TuiCanonicalDigest ('{"graphDigest":"' + $Digest + '","approvalRef":"synthetic-owner-reference"}')); outcome='Pass'; artifactVerified=$true } }
}
$Failures = [Collections.Generic.List[string]]::new()
$Count=0
function Check([string]$Name, [bool]$Pass) { $script:Count++; if(-not $Pass){$Failures.Add($Name); Write-Output "POLICY_FAIL: $Name"} }
$PinCases=@(
    @{name='same-reviewed'; state='AlreadySatisfied'; mutate={param($m)}},
    @{name='same-without-comparison'; state='Drift'; mutate={param($m) $m.Comparison=$null}},
    @{name='stale-comparison'; state='Drift'; mutate={param($m) $m.Comparison.graphDigest='f'*64}},
    @{name='failed-comparison'; state='Drift'; mutate={param($m) $m.Comparison.outcome='Fail'}},
    @{name='unverified-artifact'; state='Drift'; mutate={param($m) $m.Comparison.artifactVerified=$false}},
    @{name='stale-comparison-approval'; state='Drift'; mutate={param($m) $m.Comparison.approvalDigest='a'*64}},
    @{name='approved-changed-resolution'; state='Drift'; mutate={param($m) $m.Current.resolvedVersion='9.8.8'; $m.Decision.resolvedVersion='9.8.8'; $m.Approval.graphDigest=Get-TuiCanonicalDigest ($m.Current | ConvertTo-Json -Depth 30)}},
    @{name='missing-approval'; state='Blocked'; mutate={param($m) $m.Approval=$null}},
    @{name='unapproved-resolution'; state='Blocked'; mutate={param($m) $m.Current.resolvedVersion='9.9.0'}},
    @{name='missing-declaration'; state='Blocked'; mutate={param($m) $m.Current.declarations=@('a','b','c')}},
    @{name='missing-lock'; state='Blocked'; mutate={param($m) $m.Current.locks=@('e','f','g')}},
    @{name='floating-declaration'; state='Blocked'; mutate={param($m) $m.Current.coherent=$false}},
    @{name='missing-source'; state='Blocked'; mutate={param($m) $m.Current.sourceRefs=@()}},
    @{name='unknown-source'; state='Blocked'; mutate={param($m) $m.Current.sourceRefs=@('https://unapproved.example/v3/index.json')}}
)
foreach($Case in $PinCases) {
    $Model=New-PinFixture; & $Case.mutate $Model; $Result=Get-TuiPinPolicy @Model
    Check $Case.name ($Result.state -eq $Case.state)
    if($Case.state -eq 'Drift'){Check ($Case.name+'-full-matrix') ('HumanVoiceOver' -in $Result.requiredGates -and 'MacOsPty80x24' -in $Result.requiredGates)}
}
$ImpactCases=@(
    @{name='NoFunctionalImpact'; paths=@('docs/notes.md'); voice=$false; extra='ContractDrift'},
    @{name='FunctionalImpact'; paths=@('tests/unit.cs'); voice=$false; extra='FullFunctionalLinuxWindows'},
    @{name='A11yImpact'; paths=@('docs/notes.md'); voice=$true; extra='LinkedAccessibilityGates'},
    @{name='TestInfrastructureImpact'; paths=@('scripts/validator.ps1'); voice=$true; extra='EvidenceStrength'},
    @{name='ReleaseCloseout'; paths=@('docs/notes.md'); voice=$true; extra='DocFxAxeLynx'},
    @{name='unknown'; paths=@('docs/notes.md'); voice=$true; extra='LinkedAccessibilityGates'}
)
foreach($Case in $ImpactCases){
    $Decision=@{classes=@($Case.name);changedPaths=$Case.paths;requiredGates=@()}
    $Result=Get-TuiImpactPolicy $Decision AlreadySatisfied
    Check ('impact-'+$Case.name) ('FullFunctionalLinuxWindows' -in $Result.requiredGates -and $Case.extra -in $Result.requiredGates -and (('HumanVoiceOver' -in $Result.requiredGates) -eq $Case.voice))
}
foreach($Path in @('src/MicroCalc.Tui/TuiSession.cs','src/MicroCalc.Core/Formula/FormulaEvaluator.cs','src/MicroCalc.Core/IO/SpreadsheetJsonStorage.cs','CALC.HLP','src/MicroCalc.Tui/packages.lock.json','Directory.Build.props')){
    $Result=Get-TuiImpactPolicy @{classes=@('NoFunctionalImpact');changedPaths=@($Path);requiredGates=@()} AlreadySatisfied
    Check ('trigger-'+$Path) ('HumanVoiceOver' -in $Result.requiredGates)
}
$Result=Get-TuiImpactPolicy @{classes=@('NoFunctionalImpact');changedPaths=@('docs/notes.md');requiredGates=@()} Drift
Check 'dependency-drift-trigger' ('HumanVoiceOver' -in $Result.requiredGates)
$Result=Get-TuiImpactPolicy @{classes=@('NoFunctionalImpact');changedPaths=@('docfx.json');requiredGates=@()} AlreadySatisfied
Check 'docfx-without-voiceover' ('DocFxAxeLynx' -in $Result.requiredGates -and 'HumanVoiceOver' -notin $Result.requiredGates)
function New-HistoryFixture {
    $Path=@{pathId='APP-open';input='start';context='Grid';focusAfter='Grid';scenarioKind='Success';automatable=$true;testRefs=@('test.cs#Assert');expectedState=@{focus='Grid'}}
    $Cap=@{id='APP-001';family='APP';status='Active';mandatory=$true;platforms=@('linux','windows','macos');paths=@($Path)}
    $Old=@{revision=1;capabilities=@($Cap);requirements=@(@{id='FR-001';description='Existing obligation'})}
    return @{Previous=$Old;Current=(Copy-Policy $Old);Authorities=@();Additions=@()}
}
$HistoryCases=@(
    @{name='new-requirement-without-red';code='MissingTestFirstProof';mutate={param($m) $m.Current.revision=2;$m.Current.requirements+=@{id='FR-018';description='New obligation'}}},
    @{name='new-requirement-unverified-red';code='MissingTestFirstProof';mutate={param($m) $m.Current.revision=2;$m.Current.requirements+=@{id='FR-018';description='New obligation'};$m.Additions=@(@{requirementId='FR-018';proofVerified=$false})}},
    @{name='new-requirement-verified-red';code='';mutate={param($m) $m.Current.revision=2;$m.Current.requirements+=@{id='FR-018';description='New obligation'};$m.Additions=@(@{requirementId='FR-018';proofVerified=$true})}},
    @{name='recycled-requirement';code='RecycledIdentity';mutate={param($m) $m.Current.revision=2;$m.Current.requirements[0].description='Different obligation with old ID'}},
    @{name='focus-outside-approved-paths';code='UnauthorizedOracleChange';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths[0].focusAfter='Terminal';$m.Authorities=@(@{kind='BreakingChange';affectedIds=@('APP-001');affectedPathIds=@('APP-other');approvalVerified=$true})}},
    @{name='focus-without-authority';code='UnauthorizedOracleChange';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths[0].focusAfter='Terminal'}},
    @{name='focus-with-approved-authority';code='';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths[0].focusAfter='Terminal';$m.Authorities=@(@{kind='BreakingChange';affectedIds=@('APP-001');approvalVerified=$true})}},
    @{name='unchanged';code='';mutate={param($m)}},
    @{name='additive';code='';mutate={param($m) $m.Current.revision=2; $cap=Copy-Policy $m.Current.capabilities[0];$cap.id='APP-002';$cap.paths[0].pathId='APP-new';$m.Current.capabilities+= $cap}},
    @{name='deleted-id';code='MissingTombstone';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities=@()}},
    @{name='unapproved-deprecation';code='MissingChangeAuthority';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].status='Deprecated'}},
    @{name='retired-without-authority';code='MissingChangeAuthority';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].status='Retired'}},
    @{name='recycled-id';code='RecycledIdentity';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].family='FILE'}},
    @{name='silent-path-removal';code='RemovedHistoricalPath';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths=@()}},
    @{name='alias-recycled';code='RecycledIdentity';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths[0].input='other'}},
    @{name='weakened-automation';code='WeakenedHistoricalObligation';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths[0].automatable=$false}},
    @{name='weakened-platforms';code='WeakenedHistoricalObligation';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].platforms=@('linux')}},
    @{name='weakened-mandatory';code='WeakenedHistoricalObligation';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].mandatory=$false}},
    @{name='oracle-drift-without-authority';code='UnauthorizedOracleChange';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].paths[0].expectedState.focus='Dialog'}},
    @{name='changed-without-revision';code='NonMonotonicRevision';mutate={param($m) $m.Current.capabilities[0].paths[0].expectedState.focus='Dialog'}},
    @{name='fake-authority';code='MissingChangeAuthority';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].status='Retired';$m.Authorities=@(@{kind='BreakingChange';affectedIds=@('APP-001');approvalVerified=$false})}},
    @{name='approved-deprecated';code='';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].status='Deprecated';$m.Authorities=@(@{kind='Deprecation';affectedIds=@('APP-001');approvalVerified=$true})}},
    @{name='approved-tombstone';code='';mutate={param($m) $m.Current.revision=2;$m.Current.capabilities[0].status='Retired';$m.Authorities=@(@{kind='BreakingChange';affectedIds=@('APP-001');approvalVerified=$true})}},
    @{name='tombstone-reactivation';code='RecycledIdentity';mutate={param($m) $m.Previous.capabilities[0].status='Retired';$m.Current.revision=2}}
)
foreach($Case in $HistoryCases){$Model=New-HistoryFixture;& $Case.mutate $Model;$Result=@(Test-TuiContractHistory @Model);Check ('history-'+$Case.name) $(if($Case.code){$Case.code -in @($Result | ForEach-Object { $_.code })}else{$Result.Count -eq 0})}
Write-Output "POLICY: $Count cases; $($Failures.Count) failed. Synthetic policy tests, not product acceptance."
if($Failures.Count){exit 1}
