#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft die JSON-Lesegrenze am öffentlichen Validator, keine Produktabnahme.
EN: Tests the JSON read boundary through the public validator, not product acceptance.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/test-tinycalc-contract.ps1')
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc-json-boundary-').FullName
try {
    $Small=Join-Path $Owned 'small.json'
    [IO.File]::WriteAllText($Small,'{}')
    $null=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -Contract $Small
    $Large=Join-Path $Owned 'oversized.json'
    $Stream=[IO.File]::Create($Large)
    try{$Stream.SetLength(20971521)}finally{$Stream.Dispose()}
    # DE: Eine Datei knapp über der Grenze genügt; kein OOM oder schädigender Lasttest.
    # EN: Just above the limit is sufficient; no OOM or destructive stress test.
    $Before=[GC]::GetTotalAllocatedBytes($true)
    $Result=Test-TinyCalcContract -RepositoryRoot $Root -EvidenceRoot $Owned -Contract $Large
    $Allocated=[GC]::GetTotalAllocatedBytes($true)-$Before
    Write-Output "JSON_BOUNDARY: allocated=$Allocated; exit=$($Result.exitCode)."
    if($Result.exitCode -ne 2 -or 'InvalidInputSize' -notin $Result.findings.code){throw 'Oversized input was not blocked.'}
    if($Allocated -ge 20971520){throw 'Oversized JSON allocated before the size guard.'}
    $Raw=$null
    $Parsed=Read-TuiJsonInput $Small -RawJson ([ref]$Raw)
    if($Raw -cne '{}' -or $Parsed.Count -ne 0){throw 'Parsed input and digest snapshot differ.'}
    $Invalid=Join-Path $Owned 'invalid-utf8.json'
    [IO.File]::WriteAllBytes($Invalid,[byte[]]@(0xc3,0x28))
    $Rejected=$false
    try{$null=Read-TuiJsonInput $Invalid}catch{$Rejected=$true}
    if(-not $Rejected){throw 'Invalid UTF-8 was accepted.'}
    Write-Output 'JSON_BOUNDARY_PASS: bounded public read, same raw snapshot and strict UTF-8.'
}
finally{[IO.Directory]::Delete($Owned,$true)}
