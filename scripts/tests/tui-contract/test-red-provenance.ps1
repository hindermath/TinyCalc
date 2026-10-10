#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft lokale Git-Blob-Bindungen; Produktkopie nur lesend, Änderungen nur in eigener synthetischer Git-Fixture.
EN: Checks local Git blob bindings; product checkout read-only, writes only in an owned synthetic Git fixture.
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
    @{name='revision-expression';commit='HEAD';path='LICENSE';accepted=$false}
)
$Failures=0
foreach($Case in $Cases){
    $Actual=Test-TuiHistoricalArtifact $RepositoryRoot $Case.commit $Case.path
    if($Actual -ne $Case.accepted){$Failures++;Write-Output ('RED_PROVENANCE_FAIL: '+$Case.name)}
}
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc-historical-blob-fixture-').FullName
try{
    # DE: Eine saubere Produktkopie ist kein manipuliertes Blob. Nur eigene Fixture-Bytes verändern.
    # EN: A clean product checkout is not a tampered blob. Change only owned fixture bytes.
    $null=& git -C $Owned -c init.defaultBranch=fixture init -q
    if($LASTEXITCODE){throw 'Fixture init failed.'}
    $Fixture=Join-Path $Owned 'LICENSE'
    [IO.File]::WriteAllText($Fixture,'Synthetic original, not product evidence.')
    $null=& git -C $Owned add -- LICENSE
    if($LASTEXITCODE){throw 'Fixture staging failed.'}
    $null=& git -C $Owned -c user.name=Fixture -c user.email=fixture@example.invalid -c commit.gpgsign=false -c core.hooksPath=disabled-hooks commit -qm 'fixture: original blob'
    if($LASTEXITCODE){throw 'Fixture commit failed.'}
    $FixtureHead=(& git -C $Owned rev-parse HEAD)
    [IO.File]::WriteAllText($Fixture,'Synthetic tampered content, not product evidence.')
    if(Test-TuiHistoricalArtifact $Owned $FixtureHead 'LICENSE'){$Failures++;Write-Output 'RED_PROVENANCE_FAIL: changed-owned-blob'}
}
finally{[IO.Directory]::Delete($Owned,$true)}
Write-Output "RED_PROVENANCE: $($Cases.Count+1) cases; $Failures failed. Product repository remains read-only; synthetic owned Git fixture only."
if($Failures){exit 1}
