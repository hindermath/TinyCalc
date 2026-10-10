#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft lokale Git-Blob-Bindungen für Test-first-Belege, ohne Git- oder Repository-Schreibzugriffe.
EN: Checks local Git blob bindings for test-first proof without Git or repository writes.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
. (Join-Path $RepositoryRoot 'scripts/lib/tui-contract/SafeInputs.ps1')
$Head=(& git -C $RepositoryRoot rev-parse HEAD)
$Cases=@(
    @{name='existing-identical-blob';commit=$Head;path='LICENSE';accepted=$true},
    @{name='foreign-commit';commit=('f'*40);path='LICENSE';accepted=$false},
    @{name='missing-blob';commit=$Head;path='tests/not-present.trx';accepted=$false},
    @{name='traversal';commit=$Head;path='../LICENSE';accepted=$false},
    @{name='absolute-path';commit=$Head;path='/LICENSE';accepted=$false},
    @{name='revision-expression';commit='HEAD';path='LICENSE';accepted=$false},
    @{name='changed-product-bytes';commit=$Head;path='src/MicroCalc.Tui/TuiSession.cs';accepted=$false}
)
$Failures=0
foreach($Case in $Cases){
    $Actual=Test-TuiHistoricalArtifact $RepositoryRoot $Case.commit $Case.path
    if($Actual -ne $Case.accepted){$Failures++;Write-Output ('RED_PROVENANCE_FAIL: '+$Case.name)}
}
Write-Output "RED_PROVENANCE: $($Cases.Count) read-only cases; $Failures failed."
if($Failures){exit 1}
