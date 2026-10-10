<#
.SYNOPSIS
DE: Prüft echte Formel-/Navigations-Teilbelege gegen TRX, Schema, Orakel und Hashes; keine Vollabnahme.
EN: Checks real formula/navigation partial proof against TRX, schemas, oracles and hashes; not full acceptance.
.PARAMETER EvidenceDirectory
DE: Explizites Verzeichnis eines abgeschlossenen Testprozesses. EN: Explicit directory from one finished test process.
.PARAMETER TrxPath
DE: Tatsächliches TRX dieses Prozesses. EN: Actual TRX from that process.
.PARAMETER RepositoryRoot
DE: Explizite lokale Vertrauenswurzel. EN: Explicit local trust root.
.PARAMETER Slice
DE: Fester Teilnenner, niemals Vollabnahme. EN: Fixed partial denominator, never full acceptance.
#>
#Requires -Version 7
[CmdletBinding()]
param(
    [Parameter(Mandatory)][string]$EvidenceDirectory,
    [Parameter(Mandatory)][string]$TrxPath,
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'),
    [ValidateSet('FormulaNavigation','PrintableEditing','RemainingInProcess','Terminal','TerminalLifecycle')][string]$Slice = 'FormulaNavigation'
)
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$Root = [IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $Root 'scripts/lib/tui-contract/SafeInputs.ps1')
. (Join-Path $Root 'scripts/lib/tui-contract/Semantics.ps1')
$Directory = Resolve-TuiInputPath $EvidenceDirectory $Root
$Trx = Resolve-TuiInputPath $TrxPath $Root
if ((Get-Item -LiteralPath $Trx).Length -gt 20971520) { throw 'InvalidInputSize' }
$Settings = [Xml.XmlReaderSettings]::new()
$Settings.DtdProcessing = [Xml.DtdProcessing]::Prohibit
$Settings.XmlResolver = $null
$Reader = [Xml.XmlReader]::Create($Trx, $Settings)
try {
    $Document = [Xml.XmlDocument]::new()
    $Document.XmlResolver = $null
    $Document.Load($Reader)
}
finally { $Reader.Dispose() }
$Runs = @($Document.SelectNodes("//*[local-name()='UnitTestResult']"))
$Baseline = Read-TuiJsonInput (Join-Path $Root 'docs/contracts/tui/baseline-inventory.json')
$ContractModel = Read-TuiJsonInput (Join-Path $Root 'docs/contracts/tui/product-contract.json')
$Records = @(Get-ChildItem -LiteralPath $Directory -Recurse -File -Filter 'path-result.json' | ForEach-Object {
    Read-TuiJsonInput (Resolve-TuiInputPath $_.FullName $Root) (Join-Path $Root 'docs/contracts/tui/path-result.schema.json')
})
$Required = if ($Slice -eq 'FormulaNavigation') {
    @($Baseline.offers | Where-Object { $_.family -in @('OP','REF','FUNC-LEGACY','FUNC-EXT','NAV-UP','NAV-DOWN','NAV-RIGHT','NAV-LEFT') })
}
elseif ($Slice -eq 'PrintableEditing') { @($Baseline.offers | Where-Object { $_.id -cmatch '^EDIT-(?:ascii-[0-9]+|(?:ctrl-[sdafgv]|del|ins)-(?:interior|edge))$' }) }
elseif ($Slice -eq 'Terminal') { @($Baseline.offers | Where-Object family -CEQ TERM) }
elseif ($Slice -eq 'TerminalLifecycle') { @($Baseline.offers | Where-Object { $_.family -ceq 'TERM' -or $_.id -ceq 'APP-terminal-restoration' }) }
else { @($Baseline.offers | Where-Object { $_.family -in @('APP','GRID','CELL','CMD','FILE','HELP','DIALOG') -or
    $_.id -cin @('EDIT-existing','EDIT-slash-literal','EDIT-slash-division','EDIT-accept','EDIT-cancel') }) }
$Failures = [Collections.Generic.List[string]]::new()
if ($Records.Count -ne $Required.Count) { $Failures.Add('IncompleteSlice') }
$Seen = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
foreach ($Record in $Records) {
    if (-not $Seen.Add($Record.pathId)) { $Failures.Add('DuplicatePath'); continue }
    $Obligation = @($Required | Where-Object id -CEQ $Record.pathId)
    if ($Obligation.Count -ne 1) { $Failures.Add('UnexpectedPath'); continue }
    $ClassPrefix = 'MicroCalc.Tui.Tests.' + [IO.Path]::GetFileNameWithoutExtension(($Record.testRef -split '#', 2)[0]) + '.'
    $TestRuns = @($Runs | Where-Object { $_.testName.StartsWith($ClassPrefix, [StringComparison]::Ordinal) -and
        $_.testName.Contains('id: "' + $Record.pathId + '"', [StringComparison]::Ordinal) })
    if ($TestRuns.Count -ne 1 -or $TestRuns[0].outcome -cne 'Passed') { $Failures.Add('MissingPassedExecution'); continue }
    $Start = [DateTimeOffset]::Parse($Record.startedAt, [Globalization.CultureInfo]::InvariantCulture)
    $End = [DateTimeOffset]::Parse($Record.finishedAt, [Globalization.CultureInfo]::InvariantCulture)
    if ($Start -lt [DateTimeOffset]::Parse($TestRuns[0].startTime) -or
        $End -gt [DateTimeOffset]::Parse($TestRuns[0].endTime)) { $Failures.Add('ExecutionTimingMismatch') }
    $Proof = $null
    foreach ($Reference in @($Record.assertionProofRef) + @($Record.artifactRefs | ForEach-Object { $_.path + '#sha256=' + $_.sha256 })) {
        if ($Reference -cnotmatch '^(.+)#sha256=([a-f0-9]{64})$') { $Failures.Add('MissingArtifactDigest'); continue }
        $ArtifactPath = Resolve-TuiInputPath -Path $Matches[1] -RepositoryRoot $Root -RelativeOnly
        if ((Get-FileHash -LiteralPath $ArtifactPath -Algorithm SHA256).Hash.ToLowerInvariant() -cne $Matches[2]) {
            $Failures.Add('ArtifactDigestMismatch')
        }
        if ($Reference -ceq $Record.assertionProofRef) { $Proof = Read-TuiJsonInput $ArtifactPath }
    }
    if ($null -eq $Proof) { $Failures.Add('MissingAssertionProof'); continue }
    foreach ($Key in @('capabilityId','pathId','scenarioKind','testRef','startedAt','finishedAt','assertions')) {
        if (-not $Proof.Contains($Key) -or (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Proof[$Key] -Depth 40)) -cne
            (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Record[$Key] -Depth 40))) { $Failures.Add('AssertionProofMismatch') }
    }
}
foreach ($Offer in $Required) { if (-not $Seen.Contains($Offer.id)) { $Failures.Add('MissingSlicePath') } }
# DE: Nur eine Prüfhülle für echte Teilresultate, niemals speichern oder als natives Voll-Bundle ausgeben.
# EN: This is only a checking envelope for real partial results; never save or present it as a native full bundle.
$RunStart = @($Records | ForEach-Object { $_.startedAt } | Sort-Object)[0]
$RunEnd = @($Records | ForEach-Object { $_.finishedAt } | Sort-Object)[-1]
$Binding = @{commit=('c'*40);workingTreeDigest=('d'*64);contractDigest=Get-TuiCanonicalDigest ([IO.File]::ReadAllText((Join-Path $Root 'docs/contracts/tui/product-contract.json')));pinDecisionDigest=('e'*64)}
$CheckPlatform = if ($IsMacOS) { 'macos' } elseif ($IsWindows) { 'windows' } else { 'linux' }
$Envelope = @{runId='partial-record-check-not-acceptance';platform=$CheckPlatform;commit=$Binding.commit;workingTreeDigest=$Binding.workingTreeDigest
    contractDigest=$Binding.contractDigest;pinDecisionDigest=$Binding.pinDecisionDigest;exitCode=0;startedAt=$RunStart;finishedAt=$RunEnd;results=$Records}
$Envelope.payloadDigest = Get-TuiCanonicalDigest ($Envelope | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
$Findings = @(Test-TuiEvidenceModel -Baseline $Baseline -Contract $ContractModel -Bundles @($Envelope) -Binding $Binding)
foreach ($Finding in $Findings) { if ($Finding.code -ne 'MissingResult') { $Failures.Add($Finding.code) } }
$Report = [ordered]@{
    disposition = 'PartialProofNotAcceptance'; executedPaths = $Records.Count; requiredSlicePaths = $Required.Count
    totalContractPaths = $Baseline.offers.Count; assertions = @($Records | ForEach-Object { $_.assertions }).Count
    fullContractMissingTuples = @($Findings | Where-Object code -eq MissingResult).Count
    trxSha256 = (Get-FileHash -LiteralPath $Trx -Algorithm SHA256).Hash.ToLowerInvariant()
    failures = @($Failures | Sort-Object -Unique)
}
$Report | ConvertTo-Json -Depth 6
if ($Failures.Count) { exit 1 }
