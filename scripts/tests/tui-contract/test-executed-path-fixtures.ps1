<#
.SYNOPSIS
DE: Prüft manipulierte Kopien echter Teilbelege, ohne Produktpfade erneut auszuführen.
EN: Checks tampered copies of real partial proof without repeating product execution.
.PARAMETER EvidenceDirectory
DE: Unveränderte Teilbelege eines abgeschlossenen Prozesses. EN: Unchanged partial proof from one completed process.
.PARAMETER TrxPath
DE: Zugehöriges echtes TRX. EN: Matching actual TRX.
.PARAMETER RepositoryRoot
DE: Lokale Vertrauenswurzel. EN: Local trust root.
.PARAMETER WrongClassOnly
DE: Nur die neue Testklassen-Grenze prüfen. EN: Check only the new test-class boundary.
#>
#Requires -Version 7
[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$EvidenceDirectory,
    [Parameter(Mandatory)][string]$TrxPath,
    [string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'),
    [switch]$WrongClassOnly
)
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $Root 'scripts/lib/tui-contract/SafeInputs.ps1')
$Source=Resolve-TuiInputPath $EvidenceDirectory $Root
$Trx=Resolve-TuiInputPath $TrxPath $Root
$Owned=Join-Path $Root ('tests/MicroCalc.Tui.Tests/TestResults/proof-check-fixture-'+[Guid]::NewGuid().ToString('N'))
$null=[IO.Directory]::CreateDirectory($Owned)
$Failures=[Collections.Generic.List[string]]::new()
$Count=0
$TreeBefore=Get-TuiWorkingTreeDigest $Root
try {
    foreach($Case in @(
        @{name='missing-record';expected='IncompleteSlice'},
        @{name='duplicate-record';expected='DuplicatePath'},
        @{name='tampered-assertion';expected='AssertionProofMismatch'},
        @{name='tampered-artifact-hash';expected='ArtifactDigestMismatch'},
        @{name='skipped-trx';expected='MissingPassedExecution'},
        @{name='wrong-test-class';expected='MissingPassedExecution'}
    ) | Where-Object { -not $WrongClassOnly -or $_.name -eq 'wrong-test-class' }) {
        $Count++
        $CaseDirectory=Join-Path $Owned $Case.name
        Copy-Item -LiteralPath $Source -Destination $CaseDirectory -Recurse
        $Records=@(Get-ChildItem -LiteralPath $CaseDirectory -Recurse -File -Filter path-result.json|Sort-Object FullName)
        $Record=Read-TuiJsonInput $Records[0].FullName
        $CaseTrx=$Trx
        switch($Case.name) {
            'missing-record' { [IO.File]::Delete($Records[0].FullName) }
            'duplicate-record' { [IO.File]::Copy($Records[0].FullName,(Join-Path $CaseDirectory 'path-result.json')) }
            'tampered-assertion' {
                $Record.assertions[0].id='tampered-independent-assertion'
                [IO.File]::WriteAllText($Records[0].FullName,($Record|ConvertTo-Json -Depth 40),[Text.UTF8Encoding]::new($false))
            }
            'tampered-artifact-hash' {
                $Record.artifactRefs[0].sha256='0'*64
                [IO.File]::WriteAllText($Records[0].FullName,($Record|ConvertTo-Json -Depth 40),[Text.UTF8Encoding]::new($false))
            }
            'skipped-trx' {
                $CaseTrx=Join-Path $CaseDirectory 'skipped.trx'
                $Text=[IO.File]::ReadAllText($Trx).Replace('outcome="Passed"','outcome="NotExecuted"')
                [IO.File]::WriteAllText($CaseTrx,$Text,[Text.UTF8Encoding]::new($false))
            }
            'wrong-test-class' {
                $CaseTrx=Join-Path $CaseDirectory 'wrong-class.trx'
                $Text=[IO.File]::ReadAllText($Trx).Replace('MicroCalc.Tui.Tests.','MicroCalc.Core.Tests.')
                [IO.File]::WriteAllText($CaseTrx,$Text,[Text.UTF8Encoding]::new($false))
            }
        }
        $Before=@(Get-ChildItem -LiteralPath $CaseDirectory -Recurse -File|ForEach-Object {(Get-FileHash -LiteralPath $_.FullName -Algorithm SHA256).Hash}) -join '|'
        $Output=@(& pwsh -NoProfile -File (Join-Path $PSScriptRoot 'test-executed-paths.ps1') -RepositoryRoot $Root -EvidenceDirectory $CaseDirectory -TrxPath $CaseTrx)
        $Code=$LASTEXITCODE
        $Report=ConvertFrom-Json -AsHashtable -InputObject ($Output -join "`n")
        if($Code -ne 1 -or $Case.expected -notin $Report.failures){$Failures.Add($Case.name)}
        $After=@(Get-ChildItem -LiteralPath $CaseDirectory -Recurse -File|ForEach-Object {(Get-FileHash -LiteralPath $_.FullName -Algorithm SHA256).Hash}) -join '|'
        if($Before -cne $After){$Failures.Add($Case.name+'-changed-inputs')}
    }
    if($TreeBefore -cne (Get-TuiWorkingTreeDigest $Root)){$Failures.Add('changed-repository')}
    Write-Output "EXECUTED_PROOF_FIXTURES: $Count cases; $($Failures.Count) failed. Real-proof tampering only; no product rerun or acceptance."
    foreach($Failure in $Failures){Write-Output ('FIXTURE_FAIL: '+$Failure)}
    if($Failures.Count){exit 1}
}
finally {
    # DE: Nur diese selbst angelegten Kopien entfernen; Originalbelege bleiben unverändert.
    # EN: Remove only copies owned by this fixture; original proof remains unchanged.
    [IO.Directory]::Delete($Owned,$true)
}
