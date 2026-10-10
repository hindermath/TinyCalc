#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft Test-first-Historienbindung in einem eigenen synthetischen Git-Repository.
EN: Tests test-first history bindings in an owned synthetic Git repository.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
. (Join-Path $RepositoryRoot 'scripts/lib/tui-contract/SafeInputs.ps1')
. (Join-Path $RepositoryRoot 'scripts/lib/tui-contract/Execution.ps1')
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc-addition-fixture-').FullName
function Write-Owned([string]$Relative,[string]$Text){
    $Target=Join-Path $Owned $Relative
    $null=[IO.Directory]::CreateDirectory([IO.Path]::GetDirectoryName($Target))
    [IO.File]::WriteAllText($Target,$Text,[Text.UTF8Encoding]::new($false))
}
function Commit-Owned([string]$Subject){
    & git -C $Owned add -- .
    if($LASTEXITCODE){throw 'Fixture staging failed.'}
    $null=& git -C $Owned -c user.name=Fixture -c user.email=fixture@example.invalid -c commit.gpgsign=false -c core.hooksPath=disabled-hooks commit -qm $Subject
    if($LASTEXITCODE){throw 'Fixture commit failed.'}
    return (& git -C $Owned rev-parse HEAD)
}
try{
    $null=& git -C $Owned -c init.defaultBranch=fixture init -q
    if($LASTEXITCODE){throw 'Fixture init failed.'}
    Write-Owned README.md 'Synthetic provenance fixture, never product execution or human acceptance.'
    $BeforeProduct=Commit-Owned 'fixture: initial data'
    $Product='src/MicroCalc.Core/Fixture.cs'
    Write-Owned $Product 'internal static class Fixture { internal const int Value = 1; }'
    $Baseline=Commit-Owned 'fixture: baseline'
    $Test='tests/MicroCalc.Tui.Tests/NewRequirementTests.cs'
    $Trx='tests/fixture-red.trx'
    $Name='MicroCalc.Tui.Tests.NewRequirementTests.NewObligation'
    Write-Owned $Test 'namespace MicroCalc.Tui.Tests; public class NewRequirementTests { } // Synthetic source, not an executed test.'
    $RedXml='<TestRun><Results><UnitTestResult testName="'+$Name+'" outcome="Failed"/></Results></TestRun>'
    Write-Owned $Trx $RedXml
    $Red=Commit-Owned 'fixture: synthetic failed record before product change'
    Write-Owned $Product 'internal static class Fixture { internal const int Value = 2; }'
    $Implementation=Commit-Owned 'fixture: product change'
    $Addition=@{testName=$Name;redCommit=$Red;implementationCommit=$Implementation;productPaths=@($Product)}
    $Cases=@(
        @{name='ordered-bound-proof';expected=$true;baseline=$Baseline;mutate={param($a)}},
        @{name='same-commit';expected=$false;baseline=$Baseline;mutate={param($a)$a.implementationCommit=$a.redCommit}},
        @{name='reverse-order';expected=$false;baseline=$Baseline;mutate={param($a)$a.redCommit=$Implementation;$a.implementationCommit=$Red}},
        @{name='foreign-implementation';expected=$false;baseline=$Baseline;mutate={param($a)$a.implementationCommit='f'*40}},
        @{name='wrong-test-class';expected=$false;baseline=$Baseline;mutate={param($a)$a.testName='MicroCalc.Tui.Tests.OtherTests.NewObligation'}},
        @{name='unchanged-test';expected=$false;baseline=$Red;mutate={param($a)}},
        @{name='premature-product-change';expected=$false;baseline=$BeforeProduct;mutate={param($a)}},
        @{name='no-product-change';expected=$false;baseline=$Baseline;mutate={param($a)$a.productPaths=@('src/MicroCalc.Core/Absent.cs')}},
        @{name='traversal';expected=$false;baseline=$Baseline;mutate={param($a)$a.productPaths=@('../outside.cs')}}
    )
    $Failures=0
    foreach($Case in $Cases){
        $A=$Addition.Clone();& $Case.mutate $A
        $Actual=Test-TuiAdditionExecutionProof $Owned $Case.baseline $A (Join-Path $Owned $Trx) (Join-Path $Owned $Test)
        if($Actual -ne $Case.expected){$Failures++;Write-Output ('ADDITION_FAIL: '+$Case.name)}
    }
    Write-Owned $Trx ($RedXml.Replace('Failed','Passed'))
    if(Test-TuiAdditionExecutionProof $Owned $Baseline $Addition (Join-Path $Owned $Trx) (Join-Path $Owned $Test)){$Failures++;Write-Output 'ADDITION_FAIL: changed-or-green-red-record'}
    Write-Owned $Trx $RedXml
    Write-Owned $Test 'tampered current source'
    if(Test-TuiAdditionExecutionProof $Owned $Baseline $Addition (Join-Path $Owned $Trx) (Join-Path $Owned $Test)){$Failures++;Write-Output 'ADDITION_FAIL: changed-test-source'}
    Write-Output "ADDITION_PROVENANCE: 11 synthetic cases; $Failures failed. No real requirement execution or acceptance."
    if($Failures){exit 1}
}
finally{
    # DE: Nur das von diesem Test erzeugte eigene Verzeichnis entfernen, niemals die Produkt-Arbeitskopie.
    # EN: Remove only this test's owned directory, never the product checkout.
    [IO.Directory]::Delete($Owned,$true)
}
