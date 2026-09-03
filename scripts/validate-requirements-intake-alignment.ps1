[CmdletBinding()]
param(
    [string]$RepositoryRoot = (Split-Path -Parent $PSScriptRoot)
)

$ErrorActionPreference = 'Stop'
Push-Location $RepositoryRoot
try {
    & node scripts/render-requirements-intake-governance.mjs
    if ($LASTEXITCODE -ne 0) { throw 'Generated intake-governance validation failed.' }
    & node scripts/validate-requirements-intake-alignment.mjs
    if ($LASTEXITCODE -ne 0) { throw 'Requirements alignment validation failed.' }

    Get-ChildItem specs/intake-authoring-receipts/*.json | ForEach-Object {
        & pwsh -NoProfile -File .specify/presets/intake-authoring-governance/scripts/validate-intake-authoring-receipt.ps1 `
            -Receipt $_.FullName -Repo $RepositoryRoot
        if ($LASTEXITCODE -ne 0) { throw "Intake receipt validation failed: $($_.Name)" }
    }

    & pwsh -NoProfile -File .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-manifest.ps1 `
        -File requirements/intakes/series/tinycalc-delivery/manifest.json -Repo $RepositoryRoot
    if ($LASTEXITCODE -ne 0) { throw 'Series manifest validation failed.' }
    & pwsh -NoProfile -File .specify/presets/intake-sequencing-governance/scripts/validate-intake-series-receipt.ps1 `
        -File requirements/intakes/series/tinycalc-delivery/receipt.json -Repo $RepositoryRoot
    if ($LASTEXITCODE -ne 0) { throw 'Series receipt validation failed.' }
    $ReviewResult = 'requirements/intakes/series/tinycalc-delivery/intake-review-result.json'
    if (Test-Path -LiteralPath $ReviewResult -PathType Leaf) {
        & pwsh -NoProfile -File .specify/presets/intake-review-governance/scripts/validate-intake-review-result.ps1 `
            -Result $ReviewResult -Repo $RepositoryRoot
        if ($LASTEXITCODE -ne 0) { throw 'Intake review validation failed.' }
    }
    else {
        Write-Output 'PASS: intake review is explicitly pending after a hash-bound governance update'
    }
}
finally {
    Pop-Location
}
