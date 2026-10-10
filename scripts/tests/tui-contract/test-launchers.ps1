#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft echte CLI-/Cmdlet-/Hilfepfade und die schreibfreie Vorschau.
EN: Tests real CLI, cmdlet, help paths and zero-write preview.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/test-tinycalc-contract.ps1')
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc-launcher-parity-').FullName
$Before=Get-TuiWorkingTreeDigest $Root
function Invoke-Launcher([string]$Executable,[string[]]$Arguments) {
    $Info=[Diagnostics.ProcessStartInfo]::new($Executable)
    $Info.UseShellExecute=$false;$Info.RedirectStandardOutput=$true;$Info.RedirectStandardError=$true
    foreach($Argument in $Arguments){$Info.ArgumentList.Add($Argument)}
    $Process=[Diagnostics.Process]::Start($Info)
    try {
        $Out=$Process.StandardOutput.ReadToEndAsync();$Err=$Process.StandardError.ReadToEndAsync()
        if(-not $Process.WaitForExit(60000)){$Process.Kill($true);throw 'Launcher timeout.'}
        $Output=$Out.GetAwaiter().GetResult();$ErrorOutput=$Err.GetAwaiter().GetResult()
        if($Process.ExitCode -ne 2 -or $ErrorOutput -or $Output.Contains([char]27)){throw 'Unexpected launcher exit or output.'}
        return $Output | ConvertFrom-Json -AsHashtable
    }
    finally{$Process.Dispose()}
}
try {
    $Arguments=@('-NoProfile','-File',(Join-Path $Root 'scripts/test-tinycalc-contract.ps1'),'-RepositoryRoot',$Root,
        '-EvidenceRoot',$Owned,'-Evidence',(Join-Path $Owned 'absent-runs'),'-Json')
    $Normal=Invoke-Launcher (Get-Command pwsh).Source $Arguments
    $Preview=Invoke-Launcher (Get-Command pwsh).Source ($Arguments+@('-WhatIf'))
    $Expected=Get-TuiCanonicalDigest ($Normal | ConvertTo-Json -Depth 20)
    if((Get-TuiCanonicalDigest ($Preview | ConvertTo-Json -Depth 20)) -cne $Expected){throw 'PowerShell preview differs.'}
    $Cmdlet=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -Evidence (Join-Path $Owned 'absent-runs')
    if((Get-TuiCanonicalDigest ($Cmdlet | ConvertTo-Json -Depth 20)) -cne $Expected){throw 'Cmdlet differs.'}
    # DE: Bash wird nur auf seinen Zielplattformen geprüft. Windows-Nachweis wird nicht erfunden.
    # EN: Exercise Bash only on its target platforms. Do not invent Windows proof.
    if(-not $IsWindows) {
        $Arguments=@((Join-Path $Root 'scripts/test-tinycalc-contract.sh'),'--repository-root',$Root,
            '--evidence-root',$Owned,'--evidence',(Join-Path $Owned 'absent-runs'),'--json')
        foreach($Options in @(@{extra=@()},@{extra=@('--dry-run')})) {
            $Actual=Invoke-Launcher (Get-Command bash).Source ($Arguments+$Options.extra)
            if((Get-TuiCanonicalDigest ($Actual | ConvertTo-Json -Depth 20)) -cne $Expected){throw 'Bash output differs.'}
        }
    }
    foreach($Target in @('Test-TinyCalcContract',(Join-Path $Root 'scripts/test-tinycalc-contract.ps1'))) {
        $Help=Get-Help $Target -Full
        foreach($Name in @('RepositoryRoot','Contract','SourceMap','Evidence','PinDecision','ImpactDecision','EvidenceRoot','GateEvidence')) {
            $Parameter=@($Help.parameters.parameter | Where-Object name -eq $Name)
            if($Parameter.Count -ne 1 -or ($Parameter.description | Out-String) -notmatch 'DE:.*EN:'){throw 'Missing bilingual parameter help.'}
        }
    }
    if((Get-TuiWorkingTreeDigest $Root) -cne $Before){throw 'Launchers changed repository bytes.'}
    Write-Output 'LAUNCHERS_PASS: CLI/cmdlet JSON, normal/preview, bilingual parameter help and zero writes. Missing evidence remains Blocked.'
}
finally{[IO.Directory]::Delete($Owned,$true)}
