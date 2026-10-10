#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft Quellangebote, reine Textkorrekturen und den vollständigen lesbaren Nenner.
EN: Tests source offers, text-only corrections and the full readable denominator.
#>
[CmdletBinding()]
param([string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $Root 'scripts/lib/tui-contract/Catalog.ps1')
. (Join-Path $PSScriptRoot 'fixtures.ps1')
$SourceMap=Get-Content (Join-Path $Root 'docs/contracts/tui/source-map.json') -Raw | ConvertFrom-Json -AsHashtable
$Failures=[Collections.Generic.List[string]]::new();$Count=0
function Check([string]$Name,[bool]$Pass){$script:Count++;if(-not $Pass){$Failures.Add($Name);Write-Output "CATALOG_FAIL: $Name"}}
$Cases=@(
    @{name='complete-offers';code='';mutate={param($b,$c,$s)}},
    @{name='readme-mapping-removed';code='MissingSourceSurface';mutate={param($b,$c,$s) $s.mappings=@($s.mappings | Where-Object { $_.sourcePath -cne 'README.md' })}},
    @{name='coordinated-offer-removal';code='MissingObligation';mutate={param($b,$c,$s) $c.capabilities[0].paths=@()}},
    @{name='unmapped-capability';code='UnmappedCapability';mutate={param($b,$c,$s) foreach($m in $s.mappings){$m.capabilityRefs=@($m.capabilityRefs | Where-Object { $_ -cne 'TERM-001' })}}},
    @{name='new-offer-unimplemented';code='MissingObligation';mutate={param($b,$c,$s) $o=Copy-Model $b.offers[0];$o.id='APP-new-offer';$b.offers+=$o}},
    @{name='count-typo-only';code='';mutate={param($b,$c,$s) $s.defects[0].correction='COUNT(A1>A1)'}},
    @{name='grid-example-only';code='';mutate={param($b,$c,$s) $s.defects[1].correction='A21'}},
    @{name='defect-masquerades-as-offer';code='InvalidDocumentationDefect';mutate={param($b,$c,$s) $s.mappings[0].offerKind='DocumentationDefect';$s.mappings[0].defectRef='unreviewed'}}
)
foreach($Case in $Cases){
    $Model=New-Model;$Map=Copy-Model $SourceMap;& $Case.mutate $Model.Baseline $Model.Contract $Map
    $Findings=@(Test-TuiSourceOffers $Model.Baseline $Model.Contract $Map)
    Check $Case.name $(if($Case.code){$Case.code -in @($Findings | ForEach-Object { $_.code })}else{$Findings.Count -eq 0})
}
$Model=New-Model;$Catalog=Get-TuiContractCatalog $Model.Contract
$Rows=@($Catalog -split "`n" | Where-Object { $_ -match '^\| (linux|windows|macos) \|' })
Check 'all-1092-tuples' ($Rows.Count -eq 1092)
Check 'unique-tuples' (@($Rows | Sort-Object -Unique).Count -eq 1092)
foreach($Platform in @('linux','windows','macos')){Check ('platform-'+$Platform) (@($Rows | Where-Object { $_.StartsWith('| '+$Platform+' |') }).Count -eq 364)}
Check 'human-separate-from-automation' ($Catalog.Contains('HumanVoiceOver') -and $Catalog.Contains('ersetzt keine Automation'))
$Changed=Copy-Model $Model.Contract;$Changed.capabilities[0].paths[0].input='changed-key'
Check 'catalog-change-detected' ((Get-TuiContractCatalog $Changed) -cne $Catalog)
Write-Output "CATALOG: $Count cases; $($Failures.Count) failed. No product acceptance."
if($Failures.Count){exit 1}
