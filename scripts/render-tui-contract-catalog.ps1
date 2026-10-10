<#
.SYNOPSIS
DE: Erzeugt den textfirst Katalog oder prüft ihn lesend auf Drift.
EN: Renders the text-first catalogue or checks drift read-only.
.PARAMETER RepositoryRoot
DE: Explizite Repository-Wurzel. EN: Explicit repository root.
.PARAMETER CheckOnly
DE: Nur vergleichen, niemals schreiben. EN: Compare without writes.
.EXAMPLE
./scripts/render-tui-contract-catalog.ps1 -RepositoryRoot . -WhatIf
#>
#Requires -Version 7
[CmdletBinding(SupportsShouldProcess)]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '..'),[switch]$CheckOnly)
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $PSScriptRoot 'lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/SafeInputs.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/Catalog.ps1')
$Path=Resolve-TuiInputPath -RepositoryRoot $Root -Path 'docs/contracts/tui/product-contract.json' -RelativeOnly
$Contract=Read-TuiJsonInput $Path (Join-Path $Root 'docs/contracts/tui/contract-revision.schema.json')
$Expected=Get-TuiContractCatalog $Contract
$Target=Join-Path $Root 'docs/contracts/tui/catalog.md'
if($CheckOnly) {
    if(-not (Test-Path $Target -PathType Leaf) -or [IO.File]::ReadAllText($Target) -cne $Expected){Write-Output 'Katalogdrift / Catalogue drift';exit 1}
    Write-Output 'Katalog aktuell / Catalogue current';exit 0
}
# DE: Der Renderer schreibt ausschließlich sein abgeleitetes Ziel, niemals Inputs oder Freigaben.
# EN: The renderer writes only its derived target, never inputs or approvals.
if(Test-Path $Target){$null=Resolve-TuiInputPath -RepositoryRoot $Root -Path 'docs/contracts/tui/catalog.md' -RelativeOnly}
if($PSCmdlet.ShouldProcess('docs/contracts/tui/catalog.md','Katalog erzeugen / Render catalogue')){
    [IO.File]::WriteAllText($Target,$Expected,[Text.UTF8Encoding]::new($false))
}
