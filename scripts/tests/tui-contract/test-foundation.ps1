#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft Vertragsschema, unabhängigen Nenner und Digest-Fixtures ohne Schreibzugriff.
EN: Checks contract schema, independent denominator and digest fixtures without writes.
#>
[CmdletBinding()]
param([string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$Root = [IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/CanonicalJson.ps1')

function Assert-Foundation([bool]$Condition, [string]$Message) {
    if (-not $Condition) { throw $Message }
}

$ContractPath = Join-Path $Root 'docs/contracts/tui/product-contract.json'
$Contract = Get-Content $ContractPath -Raw | ConvertFrom-Json
$BaselinePath = Join-Path $Root 'docs/contracts/tui/baseline-inventory.json'
$Baseline = Get-Content $BaselinePath -Raw | ConvertFrom-Json
Assert-Foundation (Test-Json -Json (Get-Content $ContractPath -Raw) -SchemaFile (Join-Path $Root 'docs/contracts/tui/contract-revision.schema.json')) 'Contract schema / Vertragsschema'
Assert-Foundation ($Baseline.families.Count -eq 17) 'Seventeen families required / 17 Familien erforderlich'
$Paths = @($Contract.capabilities | ForEach-Object { $_.paths } | ForEach-Object { $_.pathId })
Assert-Foundation (@($Paths | Sort-Object -Unique).Count -eq $Paths.Count) 'Duplicate paths / Doppelte Pfade'
Assert-Foundation ($Paths.Count -eq $Baseline.offers.Count) 'Independent denominator / Unabhängiger Nenner'
Assert-Foundation (@(Compare-Object @($Baseline.offers.id | Sort-Object) @($Paths | Sort-Object)).Count -eq 0) 'Missing obligation / Fehlende Pflicht'
Assert-Foundation ((Get-TuiCanonicalDigest -Json (Get-Content $BaselinePath -Raw)) -ceq $Contract.baselineDigest) 'Baseline digest'
Assert-Foundation ((Get-TuiCanonicalDigest -Json (Get-Content (Join-Path $Root 'docs/contracts/tui/source-map.json') -Raw)) -ceq $Contract.sourceMapDigest) 'Source map digest'
$SourceMap = Get-Content (Join-Path $Root 'docs/contracts/tui/source-map.json') -Raw | ConvertFrom-Json
foreach ($Mapping in $SourceMap.mappings) {
    $Path = Join-Path $Root $Mapping.sourcePath
    Assert-Foundation ((Get-FileHash $Path -Algorithm SHA256).Hash.ToLowerInvariant() -ceq $Mapping.sourceHash) 'Source bytes changed / Quellbytes verändert'
    Assert-Foundation ((Get-Content $Path -Raw).Contains($Mapping.anchor, [StringComparison]::Ordinal)) 'Source anchor absent / Quellenanker fehlt'
}
Assert-Foundation ($Contract.requirements.Count -eq 17 -and $Contract.acceptanceCriteria.Count -eq 6) 'Requirement/acceptance inventory / Anforderungsinventar'

# DE: Konkrete negative Schemakandidaten müssen bereits vor dem vollständigen Validator scheitern.
# EN: Concrete negative schema candidates must fail even before the full validator exists.
foreach ($Mutation in @('unknown-field', 'unknown-version', 'missing-revision')) {
    $Candidate = Get-Content $ContractPath -Raw | ConvertFrom-Json -AsHashtable
    switch ($Mutation) {
        'unknown-field' { $Candidate['unexpected'] = $true }
        'unknown-version' { $Candidate['schemaVersion'] = '999.0' }
        'missing-revision' { $Candidate.Remove('revision') }
    }
    $Valid = Test-Json -Json ($Candidate | ConvertTo-Json -Depth 40) -SchemaFile (Join-Path $Root 'docs/contracts/tui/contract-revision.schema.json') -ErrorAction SilentlyContinue
    Assert-Foundation (-not $Valid) "Negative schema fixture accepted / Negative Schema-Fixture akzeptiert: $Mutation"
}

$Cases = Get-Content (Join-Path $PSScriptRoot 'canonical-cases.json') -Raw | ConvertFrom-Json
foreach ($Case in $Cases.equivalent) {
    Assert-Foundation ((Get-TuiCanonicalDigest $Case.left) -ceq (Get-TuiCanonicalDigest $Case.right)) 'Canonical equivalence / Kanonische Gleichheit'
}
foreach ($Case in $Cases.different) {
    Assert-Foundation ((Get-TuiCanonicalDigest $Case.left) -cne (Get-TuiCanonicalDigest $Case.right)) 'Canonical distinction / Kanonische Unterscheidung'
}
foreach ($Case in $Cases.invalid) {
    $Rejected = $false
    try { $null = Get-TuiCanonicalDigest -Json $Case -ExcludeRootProperty decisionDigest }
    catch { $Rejected = $true }
    Assert-Foundation $Rejected 'Duplicate keys accepted / Doppelte Felder akzeptiert'
}
foreach ($Name in @('pin', 'impact')) {
    $Path = Join-Path $Root "specs/006-tui-functional-contract/evidence/$Name-decision.json"
    $Json = Get-Content $Path -Raw
    $Decision = $Json | ConvertFrom-Json
    Assert-Foundation (Test-Json -Json $Json -SchemaFile (Join-Path $Root "docs/contracts/tui/$Name-decision.schema.json")) "$Name schema"
    Assert-Foundation ((Get-TuiCanonicalDigest -Json $Json -ExcludeRootProperty decisionDigest) -ceq $Decision.decisionDigest) "$Name digest"
}
Write-Output "FOUNDATION_PASS: 17 families / Familien; $($Paths.Count) independent paths / unabhängige Pfade; canonical fixtures / Digest-Fixtures"
