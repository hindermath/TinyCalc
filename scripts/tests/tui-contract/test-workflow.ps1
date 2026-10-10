#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft den begrenzten CI-Vertragsaufbau und absichtliche Abschwächungen; kein Providerlauf.
EN: Tests the bounded CI contract structure and deliberate weakening; not a provider run.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
. (Join-Path $RepositoryRoot 'scripts/lib/tui-contract/Workflow.ps1')
$Text=[IO.File]::ReadAllText((Join-Path $RepositoryRoot '.github/workflows/ci.yml'))
$Failures=@(Test-TuiWorkflowContract $Text)
foreach($Failure in $Failures){Write-Output ('WORKFLOW_FAIL: '+$Failure)}
if($Failures.Count){exit 1}
foreach($Mutation in @(
    @{from="  push:`n  pull_request:";to="  push:`n    branches: [main]`n  pull_request:";code='FilteredPush'},
    @{from='windows-latest';to='ubuntu-latest';code='MissingNativePlatform'},
    @{from='dotnet test MicroCalc.sln';to='dotnet test MicroCalc.sln --filter Contract=Formula';code='MissingFullExecution'},
    @{from='collect-tui-contract-evidence.ps1';to='not-the-collector.ps1';code='MissingUnconditionalBinding'},
    @{from='if-no-files-found: error';to='if-no-files-found: ignore';code='MissingProofUpload'},
    @{from='test-launchers.ps1';to='not-the-launchers.ps1';code='MissingNativeLauncherParity'}
)){
    if($Mutation.code -notin @(Test-TuiWorkflowContract ($Text.Replace($Mutation.from,$Mutation.to)))){throw ('Weakening accepted: '+$Mutation.code)}
}
Write-Output 'WORKFLOW_PASS: unconditional push/PR, native matrix, full execution, binding/upload/parity and six rejected weakenings. No CI acceptance.'
