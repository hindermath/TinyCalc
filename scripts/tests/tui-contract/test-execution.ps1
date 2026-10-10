#Requires -Version 7
<#
.SYNOPSIS
DE: Synthetische TRX-Bindungsfixtures, keine Produktabnahme.
EN: Synthetic TRX binding fixtures, not product acceptance.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
. (Join-Path $RepositoryRoot 'scripts/lib/tui-contract/Execution.ps1')
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc-trx-fixtures-').FullName
try {
    $Record=@{pathId='APP-interactive';testRef='tests/MicroCalc.Tui.Tests/TuiLifecycleContractTests.cs#APP-interactive';startedAt='2026-10-10T10:00:01Z';finishedAt='2026-10-10T10:00:02Z'}
    $Execution=@{testName='MicroCalc.Tui.Tests.TuiLifecycleContractTests.Example(id: "APP-interactive")';outcome='Passed';startTime='2026-10-10T10:00:00Z';endTime='2026-10-10T10:00:03Z'}
    $Cases=@(
        @{name='actual-pass';code='';mutate={param($r,$e)}},
        @{name='skip';code='MissingPassedExecution';mutate={param($r,$e)$e.outcome='NotExecuted'}},
        @{name='wrong-class';code='MissingPassedExecution';mutate={param($r,$e)$e.testName=$e.testName.Replace('TuiLifecycleContractTests','EvidenceProducerTests')}},
        @{name='wrong-id';code='MissingPassedExecution';mutate={param($r,$e)$e.testName=$e.testName.Replace('APP-interactive','APP-other')}},
        @{name='started-before-test';code='ExecutionTimingMismatch';mutate={param($r,$e)$r.startedAt='2026-10-10T09:59:59Z'}},
        @{name='finished-after-test';code='ExecutionTimingMismatch';mutate={param($r,$e)$r.finishedAt='2026-10-10T10:00:04Z'}}
    )
    $Failures=0
    foreach($Case in $Cases){
        $R=$Record.Clone();$E=$Execution.Clone();& $Case.mutate $R $E
        $Result=Test-TuiExecutedResult $R @($E)
        if($Result -cne $Case.code){$Failures++;Write-Output ('EXECUTION_FAIL: '+$Case.name)}
    }
    if((Test-TuiExecutedResult $Record @($Execution,$Execution)) -cne 'MissingPassedExecution'){$Failures++}
    $Trx=Join-Path $Owned 'dtd.trx'
    [IO.File]::WriteAllText($Trx,'<!DOCTYPE TestRun [<!ENTITY fake SYSTEM "file:///not-allowed">]><TestRun>&fake;</TestRun>')
    $Rejected=$false
    try{$null=Read-TuiTrxExecution $Trx}catch{$Rejected=$true}
    if(-not $Rejected){$Failures++}
    Write-Output "EXECUTION: 8 synthetic cases; $Failures failed."
    if($Failures){exit 1}
}
finally{[IO.Directory]::Delete($Owned,$true)}
