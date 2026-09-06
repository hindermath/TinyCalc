<#
.SYNOPSIS
Prüft die GSDB-Intensivbewertung ohne Schreibzugriff.

Validates the intensive GSDB assessment without modifying files.

.DESCRIPTION
Der Validator bindet Schema, Quellen, 157 kanonische IDs, Sammelband,
Statusachsen, Presets, Befunde und abgeleitete Summen. Er schreibt keine Datei
und gibt nur stabile Fehlerklassen ohne interne Zustände oder Geheimnisse aus.

The validator binds the schema, sources, 157 canonical IDs, compendium,
status axes, presets, findings, and derived summaries. It writes no file and
emits only stable failure classes without internal state or secrets.

.PARAMETER Action
Wählt die vollständige Prüfung, die Fixture-Suite oder einen Teilvertrag.

Selects full validation, the fixture suite, or one bounded contract.

.PARAMETER Assessment
Pfad zur Bewertungsdatei. Temporäre Fixture-Pfade dürfen außerhalb des
Repositories liegen; referenzierte Evidenzpfade müssen sicher und relativ sein.

Path to the assessment. Temporary fixture paths may be outside the repository;
referenced evidence paths must remain safe and relative.

.PARAMETER RepositoryRoot
Repository-Wurzel für kanonische Quellen und sichere Pfadauflösung.

Repository root used for canonical sources and safe path resolution.

.EXAMPLE
pwsh -NoProfile -File scripts/validate-gsdb-intensive-review.ps1 -Action Validate -Assessment docs/security/gsdb-intensive-review/evidence-matrix.json -RepositoryRoot .

.NOTES
Fehlerklassen: GSDB001 bis GSDB010. Exitcode 0 bedeutet Erfolg; Exitcode 1
bedeutet eine fehlgeschlagene Prüfung. Der Validator arbeitet ausschließlich
read-only und verändert weder Dateien noch Git- oder Provider-Zustand.

Failure classes: GSDB001 through GSDB010. Exit code 0 means success; exit code
1 means validation failed. The validator is read-only and changes neither
files nor Git or provider state.
#>
[CmdletBinding()]
param(
    [string]$Action = 'Validate',
    [string]$Assessment = 'docs/security/gsdb-intensive-review/evidence-matrix.json',
    [string]$RepositoryRoot = '.'
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$script:ExpectedFamilyCounts = [ordered]@{
    'CL-01' = 12
    'CL-02' = 13
    'CL-03' = 15
    'CL-04' = 10
    'CL-05' = 13
    'CL-06' = 11
    'CL-07' = 12
    'CL-08' = 13
    'CL-09' = 17
    'CL-10' = 17
    'CL-11' = 12
    'CL-12' = 12
}

$script:ExpectedPresets = [ordered]@{
    'a11y-governance' = @{ Version = '0.4.3'; Priority = 40; Standard = $true; Families = @('CL-01'); Gates = @('019', '020', '025') }
    'agent-parity-governance' = @{ Version = '0.4.2'; Priority = 60; Standard = $true; Families = @('CL-09', 'CL-10', 'CL-12'); Gates = @('025', '026') }
    'architecture-governance' = @{ Version = '0.5.2'; Priority = 20; Standard = $true; Families = @('CL-02', 'CL-04'); Gates = @('010', '015', '016', '017', '018') }
    'autonomous-run-governance' = @{ Version = '0.4.1'; Priority = 70; Standard = $true; Families = @('CL-05', 'CL-09', 'CL-12'); Gates = @('001', '002', '027', '028', '029', '030', '031', '032', '033') }
    'cross-platform-governance' = @{ Version = '0.2.2'; Priority = 50; Standard = $true; Families = @('CL-05', 'CL-10'); Gates = @('021', '023', '026') }
    'intake-authoring-governance' = @{ Version = '0.3.1'; Priority = 'NotInStandardMatrix'; Standard = $false; Families = @('CL-09', 'CL-12'); Gates = @('001', '032', '033') }
    'intake-review-governance' = @{ Version = '0.2.1'; Priority = 'NotInStandardMatrix'; Standard = $false; Families = @('CL-08', 'CL-09', 'CL-12'); Gates = @('001', '028', '032') }
    'intake-sequencing-governance' = @{ Version = '0.2.3'; Priority = 'NotInStandardMatrix'; Standard = $false; Families = @('CL-09', 'CL-12'); Gates = @('001', '032', '033') }
    'isaqb-architecture-governance' = @{ Version = '0.2.2'; Priority = 30; Standard = $true; Families = @('CL-02', 'CL-04'); Gates = @('010') }
    'model-routing-governance' = @{ Version = '0.1.4'; Priority = 'NotInStandardMatrix'; Standard = $false; Families = @('CL-09', 'CL-12'); Gates = @('001', '002') }
    'parallel-autonomous-run-governance' = @{ Version = '0.2.6'; Priority = 80; Standard = $true; Families = @('CL-09', 'CL-12'); Gates = @('033') }
    'secure-development-assurance-governance' = @{ Version = '0.1.2'; Priority = 'NotInStandardMatrix'; Standard = $false; Families = @('CL-01', 'CL-02', 'CL-03', 'CL-04', 'CL-05', 'CL-06', 'CL-07', 'CL-08', 'CL-09', 'CL-10', 'CL-11', 'CL-12'); Gates = @('003', '004', '005', '006', '007', '008', '009', '010', '011', '012', '013', '014', '015', '016', '017', '018', '026') }
    'security-governance' = @{ Version = '0.6.2'; Priority = 10; Standard = $true; Families = @('CL-01', 'CL-03', 'CL-05', 'CL-07', 'CL-08'); Gates = @('008', '009', '010', '011', '012', '013', '014', '015', '016', '017', '018', '024') }
}

function Stop-GsdbValidation {
    param(
        [Parameter(Mandatory)][ValidatePattern('^GSDB[0-9]{3}$')][string]$Code,
        [Parameter(Mandatory)][string]$Message
    )

    throw [System.IO.InvalidDataException]::new("${Code}|${Message}")
}

function Write-GsdbFailure {
    param(
        [Parameter(Mandatory)][string]$Code,
        [Parameter(Mandatory)][string]$Message
    )

    [Console]::Error.WriteLine("${Code}: ${Message}")
}

function Test-GsdbSafeRelativePath {
    param([Parameter(Mandatory)][string]$PathValue)

    if ([string]::IsNullOrWhiteSpace($PathValue) -or
        [IO.Path]::IsPathRooted($PathValue) -or
        $PathValue.Contains('\') -or
        $PathValue -match '(^|/)\.\.(/|$)' -or
        $PathValue -match '^[A-Za-z]:') {
        return $false
    }
    return $true
}

function Resolve-GsdbRepositoryFile {
    param(
        [Parameter(Mandatory)][string]$RepoRoot,
        [Parameter(Mandatory)][string]$RelativePath,
        [Parameter(Mandatory)][string]$FailureCode
    )

    if (-not (Test-GsdbSafeRelativePath -PathValue $RelativePath)) {
        Stop-GsdbValidation -Code $FailureCode -Message 'a repository path is unsafe.'
    }

    $Root = [IO.Path]::GetFullPath($RepoRoot).TrimEnd(
        [IO.Path]::DirectorySeparatorChar, [IO.Path]::AltDirectorySeparatorChar)
    $Candidate = [IO.Path]::GetFullPath((Join-Path $Root $RelativePath))
    $RootPrefix = $Root + [IO.Path]::DirectorySeparatorChar
    if (-not $Candidate.StartsWith($RootPrefix, [StringComparison]::Ordinal)) {
        Stop-GsdbValidation -Code $FailureCode -Message 'a repository path escapes its root.'
    }

    # DE: Jeder vorhandene Pfadteil wird geprüft, damit ein Symlink die zuvor
    # geprüfte Textgrenze nicht nachträglich außerhalb des Repositories auflöst.
    # EN: Check every existing path segment so a symlink cannot resolve beyond
    # the repository after the textual boundary check has passed.
    $Current = $Root
    foreach ($Segment in $RelativePath.Split('/')) {
        $Current = Join-Path $Current $Segment
        if (Test-Path -LiteralPath $Current) {
            $Info = Get-Item -LiteralPath $Current -Force
            if ($null -ne $Info.LinkType -or
                ($Info.Attributes -band [IO.FileAttributes]::ReparsePoint) -ne 0) {
                Stop-GsdbValidation -Code $FailureCode -Message 'repository symlinks are not accepted as evidence boundaries.'
            }
        }
    }
    if (-not (Test-Path -LiteralPath $Candidate -PathType Leaf)) {
        Stop-GsdbValidation -Code $FailureCode -Message 'a bound repository file is missing.'
    }
    return $Candidate
}

function Test-GsdbExactLocator {
    param(
        [Parameter(Mandatory)][string]$File,
        [Parameter(Mandatory)][string]$Locator
    )

    if ([string]::IsNullOrWhiteSpace($Locator) -or
        $Locator -match '^(Evidence for|Controlled related-document duties|JSON root|Read-only (script|shell)|Bound repository evidence|id, version|.* entry point$)') {
        return $false
    }
    try {
        $Bytes = [IO.File]::ReadAllBytes($File)
        $Utf8 = [Text.UTF8Encoding]::new($false, $true)
        $Text = $Utf8.GetString($Bytes).Replace("`r`n", "`n").Replace("`r", "`n")
        return $Text.Contains($Locator, [StringComparison]::Ordinal)
    }
    catch {
        return $false
    }
}

function Get-GsdbNormalizedHash {
    param(
        [Parameter(Mandatory)][string]$File,
        [switch]$Binary
    )

    $Bytes = [IO.File]::ReadAllBytes($File)
    if (-not $Binary) {
        $Utf8 = [Text.UTF8Encoding]::new($false, $true)
        $Text = $Utf8.GetString($Bytes).Replace("`r`n", "`n").Replace("`r", "`n")
        $Bytes = [Text.UTF8Encoding]::new($false).GetBytes($Text)
    }
    $Sha = [Security.Cryptography.SHA256]::Create()
    try {
        return ([Convert]::ToHexString($Sha.ComputeHash($Bytes))).ToLowerInvariant()
    }
    finally {
        $Sha.Dispose()
    }
}

function Read-GsdbDocument {
    param([Parameter(Mandatory)][string]$File)

    if (-not (Test-Path -LiteralPath $File -PathType Leaf)) {
        Stop-GsdbValidation -Code 'GSDB001' -Message 'assessment file is missing.'
    }

    try {
        $Bytes = [IO.File]::ReadAllBytes($File)
        if ($Bytes.Length -ge 3 -and $Bytes[0] -eq 0xEF -and
            $Bytes[1] -eq 0xBB -and $Bytes[2] -eq 0xBF) {
            Stop-GsdbValidation -Code 'GSDB001' -Message 'UTF-8 BOM is not allowed.'
        }
        $Utf8 = [Text.UTF8Encoding]::new($false, $true)
        $Text = $Utf8.GetString($Bytes)
        if ($Text.Contains("`r")) {
            Stop-GsdbValidation -Code 'GSDB001' -Message 'assessment must use LF line endings.'
        }
        $Data = $Text | ConvertFrom-Json -AsHashtable -Depth 100
        if ($Data -isnot [hashtable]) {
            Stop-GsdbValidation -Code 'GSDB001' -Message 'assessment root must be an object.'
        }
        return @{ Text = $Text; Data = $Data }
    }
    catch [System.IO.InvalidDataException] {
        throw
    }
    catch {
        Stop-GsdbValidation -Code 'GSDB001' -Message 'assessment is not valid UTF-8 JSON.'
    }
}

function Get-GsdbCanonicalRows {
    param([Parameter(Mandatory)][string]$RepoRoot)

    $ManifestFile = Join-Path $RepoRoot 'docs/secure-development/baseline-manifest.json'
    $Manifest = Get-Content -LiteralPath $ManifestFile -Raw |
        ConvertFrom-Json -AsHashtable -Depth 100
    $Rows = [System.Collections.Generic.List[object]]::new()
    foreach ($Checklist in $Manifest.checklists) {
        $Relative = "docs/secure-development/$($Checklist.path)"
        $File = Join-Path $RepoRoot $Relative
        $Text = [IO.File]::ReadAllText($File).Replace("`r`n", "`n").Replace("`r", "`n")
        $ControlMatches = [regex]::Matches($Text, '(?m)^#### (?<id>CL-(?:0[1-9]|1[0-2])-[0-9]{2}):')
        foreach ($Match in $ControlMatches) {
            $Rows.Add([pscustomobject]@{ Id = $Match.Groups['id'].Value; SourcePath = $Relative })
        }
    }
    return @($Rows)
}

function Get-GsdbControlBlocks {
    param([Parameter(Mandatory)][string]$File)

    $Text = [IO.File]::ReadAllText($File).Replace("`r`n", "`n").Replace("`r", "`n")
    $Heading = [regex]::new('(?m)^#### (?<id>CL-(?:0[1-9]|1[0-2])-[0-9]{2}):.*$')
    $ControlMatches = $Heading.Matches($Text)
    $Blocks = @{}
    foreach ($Match in $ControlMatches) {
        $Tail = $Text.Substring($Match.Index)
        $Boundary = [regex]::Match($Tail.Substring($Match.Length), '(?m)^### [^#]')
        $NextControl = $Heading.Match($Text, $Match.Index + $Match.Length)
        $End = $Text.Length
        if ($NextControl.Success) { $End = $NextControl.Index }
        if ($Boundary.Success) {
            $BoundaryIndex = $Match.Index + $Match.Length + $Boundary.Index
            if ($BoundaryIndex -lt $End) { $End = $BoundaryIndex }
        }
        $Block = $Text.Substring($Match.Index, $End - $Match.Index).Trim()
        $Blocks[$Match.Groups['id'].Value] = $Block
    }
    return $Blocks
}

function Assert-GsdbFixture {
    param(
        [Parameter(Mandatory)][hashtable]$Document,
        [Parameter(Mandatory)][string]$RepoRoot
    )

    foreach ($Name in @('schemaVersion', 'sourceInventory', 'checklistRows')) {
        if (-not $Document.ContainsKey($Name)) {
            Stop-GsdbValidation -Code 'GSDB001' -Message 'fixture shape is incomplete.'
        }
    }
    if (@($Document.sourceInventory).Count -ne 1 -or @($Document.checklistRows).Count -ne 1) {
        Stop-GsdbValidation -Code 'GSDB001' -Message 'fixture must contain one source and one row.'
    }

    $Source = $Document.sourceInventory[0]
    if (-not (Test-GsdbSafeRelativePath -PathValue ([string]$Source.path)) -or
        [string]$Source.normalizedSha256 -cnotmatch '^[0-9a-f]{64}$') {
        Stop-GsdbValidation -Code 'GSDB002' -Message 'fixture source binding is unsafe or stale.'
    }
    $FixtureSource = Resolve-GsdbRepositoryFile -RepoRoot $RepoRoot `
        -RelativePath ([string]$Source.path) -FailureCode 'GSDB002'
    if ((Get-GsdbNormalizedHash -File $FixtureSource) -cne [string]$Source.normalizedSha256) {
        Stop-GsdbValidation -Code 'GSDB002' -Message 'fixture source binding is unsafe or stale.'
    }

    $Row = $Document.checklistRows[0]
    if ([string]$Row.id -cnotmatch '^CL-(0[1-9]|1[0-2])-[0-9]{2}$') {
        Stop-GsdbValidation -Code 'GSDB003' -Message 'fixture checklist ID is not canonical.'
    }
    if ($Document.ContainsKey('fixtureCanonicalBlock') -and
        [string]$Document.fixtureCanonicalBlock -cne [string]$Document.fixtureCompendiumBlock) {
        Stop-GsdbValidation -Code 'GSDB004' -Message 'fixture compendium block differs.'
    }

    $RequiredFields = @(
        'applicability', 'implementationStatus', 'learningStage', 'rationale',
        'evidence', 'owner', 'reviewer', 'followUp', 'expectedEvidence',
        'targetDueAt', 'reevaluationTrigger', 'residualRisk', 'severity',
        'humanOnly', 'humanDecisionEvidence', 'findingIds'
    )
    foreach ($Name in $RequiredFields) {
        if (-not $Row.ContainsKey($Name)) {
            Stop-GsdbValidation -Code 'GSDB005' -Message 'fixture assessment fields are incomplete.'
        }
    }
    if (($Row.applicability -eq 'N/A' -and $Row.implementationStatus -ne 'Not Assessed') -or
        ($Row.applicability -eq 'Open' -and $Row.implementationStatus -ne 'Not Assessed') -or
        ($Row.applicability -eq 'Applicable' -and $Row.implementationStatus -eq 'Not Assessed')) {
        Stop-GsdbValidation -Code 'GSDB005' -Message 'fixture status axes are inconsistent.'
    }
    if ($Row.implementationStatus -eq 'Fulfilled' -and @($Row.evidence).Count -eq 0) {
        Stop-GsdbValidation -Code 'GSDB006' -Message 'fixture positive claim has no evidence.'
    }
    if ($Row.humanOnly -eq $true -and $Row.implementationStatus -eq 'Fulfilled') {
        Stop-GsdbValidation -Code 'GSDB007' -Message 'fixture fabricates a Human-only approval.'
    }
    if ($Document.ContainsKey('fixtureExpectedPresetIds')) {
        $Expected = @($Document.fixtureExpectedPresetIds | Sort-Object)
        $Actual = @($Document.presetAssessments | ForEach-Object { $_.presetId } | Sort-Object)
        if (($Expected -join "`n") -cne ($Actual -join "`n")) {
            Stop-GsdbValidation -Code 'GSDB008' -Message 'fixture preset coverage is incomplete.'
        }
    }
    if (@($Row.findingIds).Count -gt 0) {
        $FindingIds = @($Document.findings | ForEach-Object { $_.id })
        foreach ($FindingId in $Row.findingIds) {
            if ($FindingId -notin $FindingIds) {
                Stop-GsdbValidation -Code 'GSDB009' -Message 'fixture finding linkage is incomplete.'
            }
        }
    }
    if ($Document.ContainsKey('summary') -and
        [int]$Document.summary.checklistTotal -ne @($Document.checklistRows).Count) {
        Stop-GsdbValidation -Code 'GSDB010' -Message 'fixture summary differs from row data.'
    }
}

function Assert-GsdbSchema {
    param(
        [Parameter(Mandatory)][string]$JsonText,
        [Parameter(Mandatory)][string]$RepoRoot
    )

    try {
        $Schema = Get-Content -LiteralPath (
            Join-Path $RepoRoot 'specs/005-gsdb-intensive-review/contracts/evidence-matrix.schema.json') -Raw
        $Valid = Test-Json -Json $JsonText -Schema $Schema -ErrorAction Stop
        if (-not $Valid) {
            Stop-GsdbValidation -Code 'GSDB001' -Message 'assessment violates the accepted JSON schema.'
        }
    }
    catch [System.IO.InvalidDataException] {
        throw
    }
    catch {
        Stop-GsdbValidation -Code 'GSDB001' -Message 'assessment violates the accepted JSON schema.'
    }
}

function Assert-GsdbSources {
    param(
        [Parameter(Mandatory)][hashtable]$Document,
        [Parameter(Mandatory)][string]$RepoRoot
    )

    $ManifestRelative = 'docs/secure-development/baseline-manifest.json'
    $ManifestFile = Join-Path $RepoRoot $ManifestRelative
    $Manifest = Get-Content -LiteralPath $ManifestFile -Raw |
        ConvertFrom-Json -AsHashtable -Depth 100
    $ManifestHash = Get-GsdbNormalizedHash -File $ManifestFile
    if ($Document.baseline.manifestPath -cne $ManifestRelative -or
        $Document.baseline.baselineVersion -cne [string]$Manifest.baselineVersion -or
        $Document.baseline.manifestNormalizedSha256 -cne $ManifestHash -or
        [int]$Document.baseline.declaredChecklistItemCount -ne 157 -or
        [int]$Document.baseline.observedChecklistItemCount -ne 157) {
        Stop-GsdbValidation -Code 'GSDB002' -Message 'baseline binding is missing or stale.'
    }

    $Ids = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    $Paths = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($Source in $Document.sourceInventory) {
        if (-not $Ids.Add([string]$Source.sourceId) -or
            -not $Paths.Add([string]$Source.path) -or
            -not (Test-GsdbSafeRelativePath -PathValue ([string]$Source.path)) -or
            [string]$Source.normalizedSha256 -cnotmatch '^[0-9a-f]{64}$') {
            Stop-GsdbValidation -Code 'GSDB002' -Message 'source IDs, paths, or hashes are unsafe or duplicated.'
        }
        $File = Resolve-GsdbRepositoryFile -RepoRoot $RepoRoot `
            -RelativePath ([string]$Source.path) -FailureCode 'GSDB002'
        $ActualHash = Get-GsdbNormalizedHash -File $File -Binary:($Source.sourceClass -eq 'ManagedBinary')
        if ($ActualHash -cne [string]$Source.normalizedSha256) {
            Stop-GsdbValidation -Code 'GSDB002' -Message 'a bound source hash is stale.'
        }
        if ($Source.sourceClass -ne 'ManagedBinary' -and
            -not (Test-GsdbExactLocator -File $File -Locator ([string]$Source.locator))) {
            Stop-GsdbValidation -Code 'GSDB002' -Message 'a source locator is generic or unresolved.'
        }
    }

    $RequiredPaths = [Collections.Generic.List[string]]::new()
    $RequiredPaths.Add($ManifestRelative)
    $RequiredPaths.Add("docs/secure-development/$($Manifest.guideline.path)")
    $RequiredPaths.Add("docs/secure-development/$($Manifest.compendium.path)")
    foreach ($Entry in $Manifest.checklists) { $RequiredPaths.Add("docs/secure-development/$($Entry.path)") }
    foreach ($Entry in $Manifest.relatedDocuments) { $RequiredPaths.Add("docs/secure-development/$($Entry.path)") }
    foreach ($Entry in $Manifest.learningDocuments) { $RequiredPaths.Add("docs/secure-development/$($Entry.path)") }
    foreach ($Entry in $Manifest.managedReferenceFiles) { $RequiredPaths.Add("docs/secure-development/$Entry") }
    foreach ($Entry in $Manifest.managedBinaryFiles) { $RequiredPaths.Add("docs/secure-development/$Entry") }
    foreach ($RequiredPath in $RequiredPaths) {
        if (-not $Paths.Contains($RequiredPath)) {
            Stop-GsdbValidation -Code 'GSDB002' -Message 'controlled source inventory is incomplete.'
        }
    }
}

function Assert-GsdbCanonicalIds {
    param(
        [Parameter(Mandatory)][hashtable]$Document,
        [Parameter(Mandatory)][string]$RepoRoot
    )

    $Canonical = @(Get-GsdbCanonicalRows -RepoRoot $RepoRoot)
    $CanonicalIds = @($Canonical.Id | Sort-Object)
    $ActualIds = @($Document.checklistRows.id)
    if ($CanonicalIds.Count -ne 157 -or @($CanonicalIds | Select-Object -Unique).Count -ne 157 -or
        $ActualIds.Count -ne 157 -or @($ActualIds | Select-Object -Unique).Count -ne 157 -or
        (($ActualIds | Sort-Object) -join "`n") -cne ($CanonicalIds -join "`n")) {
        Stop-GsdbValidation -Code 'GSDB003' -Message 'canonical checklist ID set is missing, duplicated, or unknown.'
    }
    if (($ActualIds -join "`n") -cne (($ActualIds | Sort-Object) -join "`n")) {
        Stop-GsdbValidation -Code 'GSDB010' -Message 'checklist rows are not deterministically ordered.'
    }
    $CanonicalPaths = @{}
    foreach ($Entry in $Canonical) { $CanonicalPaths[$Entry.Id] = $Entry.SourcePath }
    foreach ($Row in $Document.checklistRows) {
        if ([string]$Row.sourcePath -cne [string]$CanonicalPaths[$Row.id] -or
            [string]$Row.sourceLocator -notmatch [regex]::Escape([string]$Row.id)) {
            Stop-GsdbValidation -Code 'GSDB003' -Message 'checklist row family or locator is incorrect.'
        }
    }
}

function Assert-GsdbCompendium {
    param(
        [Parameter(Mandatory)][hashtable]$Document,
        [Parameter(Mandatory)][string]$RepoRoot
    )

    $Manifest = Get-Content -LiteralPath (
        Join-Path $RepoRoot 'docs/secure-development/baseline-manifest.json') -Raw |
        ConvertFrom-Json -AsHashtable -Depth 100
    $Compendium = Get-GsdbControlBlocks -File (
        Join-Path $RepoRoot "docs/secure-development/$($Manifest.compendium.path)")
    $Individual = @{}
    foreach ($Checklist in $Manifest.checklists) {
        $Blocks = Get-GsdbControlBlocks -File (
            Join-Path $RepoRoot "docs/secure-development/$($Checklist.path)")
        foreach ($Entry in $Blocks.GetEnumerator()) { $Individual[$Entry.Key] = $Entry.Value }
    }
    if ($Compendium.Count -ne 157 -or $Individual.Count -ne 157 -or
        $Document.baseline.compendiumParity -cne 'Matched') {
        Stop-GsdbValidation -Code 'GSDB004' -Message 'compendium identity or declared parity is incomplete.'
    }
    foreach ($Id in $Individual.Keys) {
        if (-not $Compendium.ContainsKey($Id) -or $Compendium[$Id] -cne $Individual[$Id]) {
            Stop-GsdbValidation -Code 'GSDB004' -Message 'compendium content differs from a canonical checklist block.'
        }
    }
}

function Assert-GsdbAssessmentFields {
    param(
        [Parameter(Mandatory)][hashtable]$Document,
        [Parameter(Mandatory)][string]$RepoRoot
    )

    $Rows = @($Document.checklistRows) + @($Document.externalDuties)
    $BoundEvidencePaths = @($Document.sourceInventory.path)
    foreach ($Row in $Rows) {
        $EntityId = [string]$Row.id
        foreach ($Name in @('rationale', 'owner', 'reviewer', 'followUp', 'expectedEvidence', 'targetDueAt', 'reevaluationTrigger', 'residualRisk')) {
            if ([string]::IsNullOrWhiteSpace([string]$Row[$Name])) {
                Stop-GsdbValidation -Code 'GSDB005' -Message 'an assessment field is missing.'
            }
        }
        foreach ($Name in @('rationale', 'followUp', 'expectedEvidence', 'reevaluationTrigger', 'residualRisk')) {
            $TextPair = $Row[$Name]
            if ($TextPair -isnot [hashtable] -or
                [string]::IsNullOrWhiteSpace([string]$TextPair.de) -or
                [string]::IsNullOrWhiteSpace([string]$TextPair.en) -or
                [string]$TextPair.de -ceq [string]$TextPair.en) {
                Stop-GsdbValidation -Code 'GSDB005' -Message 'bilingual assessment text is missing or duplicated.'
            }
        }
        if (-not ([string]$Row.rationale.de).Contains($EntityId, [StringComparison]::Ordinal) -or
            -not ([string]$Row.rationale.en).Contains($EntityId, [StringComparison]::Ordinal) -or
            [string]$Row.rationale.de -match '^Der Kontrollpunkt ' -or
            [string]$Row.rationale.en -match '^The control ') {
            Stop-GsdbValidation -Code 'GSDB005' -Message 'a rationale is generic instead of control-specific.'
        }
        if ([string]$Row.sourceLocator -match '^(Evidence for|Controlled related-document duties)') {
            Stop-GsdbValidation -Code 'GSDB005' -Message 'an assessment locator is generic or unresolved.'
        }
        if (($Row.applicability -eq 'N/A' -and $Row.implementationStatus -ne 'Not Assessed') -or
            ($Row.applicability -eq 'Open' -and $Row.implementationStatus -ne 'Not Assessed') -or
            ($Row.applicability -eq 'Applicable' -and $Row.implementationStatus -eq 'Not Assessed')) {
            Stop-GsdbValidation -Code 'GSDB005' -Message 'applicability and implementation status conflict.'
        }
        if (($Row.implementationStatus -eq 'Fulfilled' -and
                ($Row.severity -ne 'None' -or @($Row.findingIds).Count -ne 0 -or $Row.targetDueAt -ne 'N/A')) -or
            ($Row.implementationStatus -eq 'Partly Fulfilled' -and
                ($Row.severity -eq 'None' -or @($Row.findingIds).Count -eq 0)) -or
            ($Row.applicability -eq 'Open' -and
                (-not $Row.humanOnly -or $Row.severity -eq 'None' -or @($Row.findingIds).Count -eq 0)) -or
            ($Row.applicability -eq 'N/A' -and
                ($Row.humanOnly -or $Row.severity -ne 'None' -or @($Row.findingIds).Count -ne 0))) {
            Stop-GsdbValidation -Code 'GSDB005' -Message 'status and follow-up metadata are inconsistent.'
        }
        if ($Row.implementationStatus -in @('Partly Fulfilled', 'Not Fulfilled', 'Not Assessed') -and
            $Row.targetDueAt -cnotmatch '^\d{4}-\d{2}-\d{2}$') {
            Stop-GsdbValidation -Code 'GSDB005' -Message 'open follow-up requires an ISO target date.'
        }
        if ($Row.implementationStatus -eq 'Fulfilled') {
            $CurrentEvidence = @($Row.evidence | Where-Object {
                $_.availability -eq 'Existing' -and $_.freshness -in @('Current', 'Revalidated') -and
                -not [string]::IsNullOrWhiteSpace([string]$_.locator)
            })
            if ($CurrentEvidence.Count -eq 0) {
                Stop-GsdbValidation -Code 'GSDB006' -Message 'a positive claim lacks current concrete evidence.'
            }
        }
        foreach ($Evidence in $Row.evidence) {
            if (-not (Test-GsdbSafeRelativePath -PathValue ([string]$Evidence.path))) {
                Stop-GsdbValidation -Code 'GSDB006' -Message 'an evidence path is unsafe.'
            }
            if ([string]$Evidence.path -notin $BoundEvidencePaths -or
                [string]::IsNullOrWhiteSpace([string]$Evidence.locator) -or
                [string]$Evidence.locator -match '^Evidence for\s' -or
                $Evidence.supports -isnot [hashtable] -or
                [string]::IsNullOrWhiteSpace([string]$Evidence.supports.de) -or
                [string]::IsNullOrWhiteSpace([string]$Evidence.supports.en) -or
                [string]$Evidence.supports.de -ceq [string]$Evidence.supports.en -or
                [string]$Evidence.supports.de -match '^(Der konkrete Pfad|Der Locator)' -or
                [string]$Evidence.supports.en -match '^(The concrete path|The locator)' -or
                -not ([string]$Evidence.supports.de).Contains($EntityId, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.en).Contains($EntityId, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.de).Contains([string]$Evidence.path, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.en).Contains([string]$Evidence.path, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.de).Contains([string]$Evidence.locator, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.en).Contains([string]$Evidence.locator, [StringComparison]::Ordinal)) {
                Stop-GsdbValidation -Code 'GSDB006' -Message 'evidence is unbound, generic, or not bilingual.'
            }
            if (($Evidence.availability -eq 'Existing' -and $Evidence.freshness -eq 'Planned') -or
                ($Evidence.availability -eq 'Planned' -and $Evidence.freshness -ne 'Planned')) {
                Stop-GsdbValidation -Code 'GSDB006' -Message 'evidence availability and freshness conflict.'
            }
            if ($Evidence.availability -eq 'Existing') {
                $EvidenceFile = Resolve-GsdbRepositoryFile -RepoRoot $RepoRoot `
                    -RelativePath ([string]$Evidence.path) -FailureCode 'GSDB006'
                if (-not (Test-GsdbExactLocator -File $EvidenceFile -Locator ([string]$Evidence.locator))) {
                    Stop-GsdbValidation -Code 'GSDB006' -Message 'an evidence locator does not resolve exactly.'
                }
                $SourceBinding = $Document.sourceInventory |
                    Where-Object path -CEQ ([string]$Evidence.path) | Select-Object -First 1
                if ($null -eq $SourceBinding -or
                    $SourceBinding.freshness -notin @('Current', 'Revalidated')) {
                    Stop-GsdbValidation -Code 'GSDB006' -Message 'evidence source binding is absent or stale.'
                }
            }
        }
        if ($Row.humanOnly -eq $true -and $Row.implementationStatus -eq 'Fulfilled') {
            Stop-GsdbValidation -Code 'GSDB007' -Message 'Human-only evidence cannot be inferred as fulfilled.'
        }
        if ($Row.humanDecisionEvidence -cne 'NotProvided') {
            Stop-GsdbValidation -Code 'GSDB007' -Message 'unsupported Human-only decision evidence is present.'
        }
    }

    $RequiredFeatureEvidence = [ordered]@{
        'CL-01-02' = @('docs/security/asvs-verification.md', '## Feature 005 review / Prüfung für Feature 005')
        'CL-01-06' = @('docs/security/zero-trust-applicability.md', '## Feature 005: Produkt und Lieferung / Product and delivery')
        'CL-01-12' = @('docs/security/regulatory-applicability.md', '## Feature 005 technical screening / Technische Vorprüfung Feature 005')
        'CL-02-12' = @('docs/security/cloud-autonomy-applicability.md', '## Feature 005 C3A assessment / Feature-005-C3A-Bewertung')
        'CL-02-13' = @('docs/security/cloud-compliance-assurance.md', '## Feature 005 C5 assessment / Feature-005-C5-Bewertung')
        'CL-04-01' = @('docs/security/security-quality-scenarios.md', '## GSDB-Szenarien 2026-09-06 / GSDB Scenarios 2026-09-06')
        'CL-05-01' = @('docs/security/supply-chain-evidence.md', '### Feature-005-Lieferkettenlauf / Feature 005 supply-chain run')
        'CL-05-03' = @('docs/security/dependency-audit.md', '## Feature-005-Prüfung 2026-09-06 / Feature 005 Review 2026-09-06')
    }
    foreach ($Pair in $RequiredFeatureEvidence.GetEnumerator()) {
        $RequiredRow = $Document.checklistRows | Where-Object id -ceq $Pair.Key | Select-Object -First 1
        $RequiredEvidence = @($RequiredRow.evidence | Where-Object {
            $_.path -ceq $Pair.Value[0] -and $_.locator -ceq $Pair.Value[1]
        })
        if ($null -eq $RequiredRow -or $RequiredEvidence.Count -ne 1) {
            Stop-GsdbValidation -Code 'GSDB006' -Message 'a required Feature 005 disposition is not integrated.'
        }
    }
}

function Assert-GsdbMappings {
    param([Parameter(Mandatory)][hashtable]$Document)

    $PresetIds = @($Document.presetAssessments.presetId)
    $ExpectedIds = @($script:ExpectedPresets.Keys | Sort-Object)
    if ($PresetIds.Count -ne 13 -or @($PresetIds | Select-Object -Unique).Count -ne 13 -or
        (($PresetIds | Sort-Object) -join "`n") -cne ($ExpectedIds -join "`n")) {
        Stop-GsdbValidation -Code 'GSDB008' -Message 'installed preset coverage is incomplete.'
    }
    if (($PresetIds -join "`n") -cne (($PresetIds | Sort-Object) -join "`n")) {
        Stop-GsdbValidation -Code 'GSDB010' -Message 'preset assessments are not deterministically ordered.'
    }
    foreach ($Preset in $Document.presetAssessments) {
        $Expected = $script:ExpectedPresets[$Preset.presetId]
        $ExpectedChecklistIds = @($Document.checklistRows |
            Where-Object { $_.id.Substring(0, 5) -in $Expected.Families } |
            ForEach-Object id)
        $ExpectedGateIds = @($Expected.Gates | ForEach-Object { "GSDB-GATE-$_" })
        if ($Preset.version -cne $Expected.Version -or
            [string]$Preset.priority -cne [string]$Expected.Priority -or
            [bool]$Preset.standardMatrixMember -ne [bool]$Expected.Standard -or
            (@($Preset.mappedChecklistIds) -join "`n") -cne ($ExpectedChecklistIds -join "`n") -or
            (@($Preset.mappedGateIds) -join "`n") -cne ($ExpectedGateIds -join "`n") -or
            @($Preset.evidence).Count -eq 0) {
            Stop-GsdbValidation -Code 'GSDB008' -Message 'a preset version, matrix status, or mapping is incomplete.'
        }
        foreach ($Evidence in $Preset.evidence) {
            $EntityId = [string]$Preset.presetId
            if ([string]$Evidence.path -notin @($Document.sourceInventory.path) -or
                -not ([string]$Evidence.supports.de).Contains($EntityId, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.en).Contains($EntityId, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.de).Contains([string]$Evidence.locator, [StringComparison]::Ordinal) -or
                -not ([string]$Evidence.supports.en).Contains([string]$Evidence.locator, [StringComparison]::Ordinal)) {
                Stop-GsdbValidation -Code 'GSDB008' -Message 'preset evidence is generic or unbound.'
            }
        }
    }
    if (@($Document.externalDuties).Count -lt 16) {
        Stop-GsdbValidation -Code 'GSDB008' -Message 'external guideline and related-document duties are incomplete.'
    }
    $DutyIds = @($Document.externalDuties.id)
    if (@($DutyIds | Select-Object -Unique).Count -ne $DutyIds.Count -or
        ($DutyIds -join "`n") -cne (($DutyIds | Sort-Object) -join "`n")) {
        Stop-GsdbValidation -Code 'GSDB008' -Message 'external duties are duplicated or unordered.'
    }
    if (@($Document.sourceInventory | Where-Object sourceClass -eq 'Workflow').Count -lt 6 -or
        @($Document.sourceInventory | Where-Object sourceClass -eq 'Validator').Count -lt 4) {
        Stop-GsdbValidation -Code 'GSDB008' -Message 'workflow or validator source coverage is incomplete.'
    }
}

function Assert-GsdbFindings {
    param([Parameter(Mandatory)][hashtable]$Document)

    $FindingIds = @($Document.findings.id)
    if (@($FindingIds | Select-Object -Unique).Count -ne $FindingIds.Count -or
        ($FindingIds -join "`n") -cne (($FindingIds | Sort-Object) -join "`n")) {
        Stop-GsdbValidation -Code 'GSDB009' -Message 'findings are duplicated or not deterministically ordered.'
    }
    $KnownReferences = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($Value in @($Document.checklistRows.id) + @($Document.externalDuties.id) +
        @($Document.presetAssessments.presetId) + @($Document.sourceInventory.sourceId)) {
        [void]$KnownReferences.Add([string]$Value)
    }
    $LinkedEntities = @($Document.checklistRows) + @($Document.externalDuties) + @($Document.sourceInventory)
    $SeverityRank = @{ None = 0; Low = 1; Medium = 2; High = 3; Critical = 4 }
    foreach ($Finding in $Document.findings) {
        foreach ($Reference in $Finding.sourceReferences) {
            if (-not $KnownReferences.Contains([string]$Reference)) {
                Stop-GsdbValidation -Code 'GSDB009' -Message 'a finding references an unknown source or row.'
            }
        }
        $ExpectedReferences = @($LinkedEntities | Where-Object {
            $Finding.id -in @($_.findingIds)
        } | ForEach-Object {
            if ($_.ContainsKey('id')) { [string]$_.id } else { [string]$_.sourceId }
        } | Sort-Object -Unique)
        $ActualReferences = @($Finding.sourceReferences | Sort-Object -Unique)
        if ($ExpectedReferences.Count -eq 0 -or
            ($ExpectedReferences -join "`n") -cne ($ActualReferences -join "`n")) {
            Stop-GsdbValidation -Code 'GSDB009' -Message 'finding linkage is not reciprocal and complete.'
        }
        $MaximumLinkedSeverity = 0
        foreach ($Entity in $LinkedEntities | Where-Object { $Finding.id -in @($_.findingIds) }) {
            if ($Entity.ContainsKey('severity')) {
                $MaximumLinkedSeverity = [Math]::Max($MaximumLinkedSeverity, [int]$SeverityRank[[string]$Entity.severity])
            }
        }
        if ([int]$SeverityRank[[string]$Finding.severity] -lt $MaximumLinkedSeverity) {
            Stop-GsdbValidation -Code 'GSDB009' -Message 'a finding severity is below its linked evidence.'
        }
        if ($Finding.status -eq 'Open' -and $Finding.deliveryImpact -in @('BlocksReview', 'BlocksDelivery')) {
            Stop-GsdbValidation -Code 'GSDB009' -Message 'an unresolved finding blocks review or delivery.'
        }
    }
    foreach ($Row in @($Document.checklistRows) + @($Document.externalDuties)) {
        foreach ($FindingId in $Row.findingIds) {
            if ($FindingId -notin $FindingIds) {
                Stop-GsdbValidation -Code 'GSDB009' -Message 'a row links to an unknown finding.'
            }
        }
        if ($Row.applicability -ne 'N/A' -and $Row.implementationStatus -ne 'Fulfilled' -and
            @($Row.findingIds).Count -eq 0) {
            Stop-GsdbValidation -Code 'GSDB009' -Message 'a non-fulfilled row lacks a finding.'
        }
    }
}

function Get-GsdbCountMap {
    param(
        [Parameter(Mandatory)][object[]]$Items,
        [Parameter(Mandatory)][string]$Property
    )

    $Result = [ordered]@{}
    foreach ($Group in @($Items | Group-Object -Property $Property | Sort-Object Name)) {
        $Result[$Group.Name] = $Group.Count
    }
    return $Result
}

function Assert-GsdbMapEquals {
    param(
        [Parameter(Mandatory)][hashtable]$Actual,
        [Parameter(Mandatory)][System.Collections.IDictionary]$Expected
    )

    $ActualJson = $Actual | ConvertTo-Json -Compress
    $ExpectedJson = $Expected | ConvertTo-Json -Compress
    return $ActualJson -ceq $ExpectedJson
}

function Assert-GsdbSummary {
    param([Parameter(Mandatory)][hashtable]$Document)

    $ParsedDate = [datetime]::MinValue
    if (-not [datetime]::TryParseExact([string]$Document.reviewedAt, 'yyyy-MM-dd',
        [Globalization.CultureInfo]::InvariantCulture,
        [Globalization.DateTimeStyles]::None, [ref]$ParsedDate)) {
        Stop-GsdbValidation -Code 'GSDB010' -Message 'review date is not an ISO calendar date.'
    }
    $Summary = $Document.summary
    $Rows = @($Document.checklistRows)
    $OpenFindings = @($Document.findings | Where-Object status -eq 'Open')
    $ExpectedApplicability = Get-GsdbCountMap -Items $Rows -Property 'applicability'
    $ExpectedImplementation = Get-GsdbCountMap -Items $Rows -Property 'implementationStatus'
    $ExpectedSeverity = Get-GsdbCountMap -Items @($Document.findings) -Property 'severity'
    $BoundCurrentPaths = @($Document.sourceInventory | Where-Object {
        $_.freshness -in @('Current', 'Revalidated')
    } | ForEach-Object path)
    $ExpectedUnsupportedClaims = @(@($Document.checklistRows) + @($Document.externalDuties) |
        Where-Object {
            if ($_.implementationStatus -ne 'Fulfilled') { return $false }
            $SupportingEvidence = @($_.evidence | Where-Object {
                $_.availability -eq 'Existing' -and $_.freshness -in @('Current', 'Revalidated') -and
                $_.path -in $BoundCurrentPaths -and -not [string]::IsNullOrWhiteSpace([string]$_.locator)
            })
            return $_.humanOnly -or $_.humanDecisionEvidence -ne 'NotProvided' -or
                $SupportingEvidence.Count -eq 0
        }).Count
    if ([int]$Summary.checklistTotal -ne 157 -or
        -not (Assert-GsdbMapEquals -Actual $Summary.familyCounts -Expected $script:ExpectedFamilyCounts) -or
        -not (Assert-GsdbMapEquals -Actual $Summary.byApplicability -Expected $ExpectedApplicability) -or
        -not (Assert-GsdbMapEquals -Actual $Summary.byImplementationStatus -Expected $ExpectedImplementation) -or
        [int]$Summary.humanOnlyTotal -ne @($Rows | Where-Object humanOnly -eq $true).Count -or
        [int]$Summary.openFindingTotal -ne $OpenFindings.Count -or
        -not (Assert-GsdbMapEquals -Actual $Summary.findingsBySeverity -Expected $ExpectedSeverity) -or
        [int]$Summary.sourceInventoryTotal -ne @($Document.sourceInventory).Count -or
        [int]$Summary.presetTotal -ne 13 -or
        [int]$Summary.standardPresetTotal -ne 8 -or
        [int]$Summary.externalDutyTotal -ne @($Document.externalDuties).Count -or
        [int]$Summary.missingIds -ne 0 -or [int]$Summary.duplicateIds -ne 0 -or
        [int]$Summary.unknownIds -ne 0 -or
        [int]$Summary.unsupportedClaims -ne $ExpectedUnsupportedClaims) {
        Stop-GsdbValidation -Code 'GSDB010' -Message 'derived summary differs from assessment data.'
    }
}

function Invoke-GsdbProductionValidation {
    param(
        [Parameter(Mandatory)][hashtable]$Document,
        [Parameter(Mandatory)][string]$JsonText,
        [Parameter(Mandatory)][string]$RepoRoot,
        [Parameter(Mandatory)][string]$SelectedAction
    )

    Assert-GsdbSchema -JsonText $JsonText -RepoRoot $RepoRoot
    switch ($SelectedAction) {
        'ValidateSources' {
            Assert-GsdbSources -Document $Document -RepoRoot $RepoRoot
        }
        'ValidateCompendium' {
            Assert-GsdbCanonicalIds -Document $Document -RepoRoot $RepoRoot
            Assert-GsdbCompendium -Document $Document -RepoRoot $RepoRoot
        }
        'ValidateMappings' {
            Assert-GsdbMappings -Document $Document
            Assert-GsdbFindings -Document $Document
        }
        default {
            Assert-GsdbSources -Document $Document -RepoRoot $RepoRoot
            Assert-GsdbCanonicalIds -Document $Document -RepoRoot $RepoRoot
            Assert-GsdbCompendium -Document $Document -RepoRoot $RepoRoot
            Assert-GsdbAssessmentFields -Document $Document -RepoRoot $RepoRoot
            Assert-GsdbMappings -Document $Document
            Assert-GsdbFindings -Document $Document
            Assert-GsdbSummary -Document $Document
        }
    }
}

function Test-GsdbIntensiveReview {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$AssessmentPath,
        [Parameter(Mandatory)][string]$RepoRoot,
        [Parameter(Mandatory)][string]$SelectedAction
    )

    $ResolvedRoot = [IO.Path]::GetFullPath($RepoRoot)
    if (-not (Test-Path -LiteralPath $ResolvedRoot -PathType Container)) {
        Stop-GsdbValidation -Code 'GSDB001' -Message 'repository root is missing.'
    }
    if ($SelectedAction -eq 'ValidateFixtures') {
        $FixtureTest = Join-Path $ResolvedRoot 'scripts/tests/gsdb-intensive-review/test-validate-gsdb-intensive-review.ps1'
        & pwsh -NoProfile -File $FixtureTest
        if ($LASTEXITCODE -ne 0) {
            Stop-GsdbValidation -Code 'GSDB001' -Message 'PowerShell fixture suite failed.'
        }
        return
    }

    $ResolvedAssessment = if ([IO.Path]::IsPathRooted($AssessmentPath)) {
        [IO.Path]::GetFullPath($AssessmentPath)
    }
    else {
        [IO.Path]::GetFullPath((Join-Path $ResolvedRoot $AssessmentPath))
    }
    $Loaded = Read-GsdbDocument -File $ResolvedAssessment
    $Document = $Loaded.Data
    if ($Document.ContainsKey('fixtureMode') -and $Document.fixtureMode -eq $true) {
        Assert-GsdbFixture -Document $Document -RepoRoot $ResolvedRoot
        return
    }
    Invoke-GsdbProductionValidation -Document $Document -JsonText $Loaded.Text `
        -RepoRoot $ResolvedRoot -SelectedAction $SelectedAction
}

try {
    if ($Action -notin @('Validate', 'ValidateFixtures', 'ValidateSources', 'ValidateCompendium', 'ValidateMappings')) {
        Stop-GsdbValidation -Code 'GSDB001' -Message 'unsupported action.'
    }
    Test-GsdbIntensiveReview -AssessmentPath $Assessment -RepoRoot $RepositoryRoot `
        -SelectedAction $Action
    Write-Output "PASS: GSDB ${Action} completed."
    exit 0
}
catch {
    $Failure = [string]$_.Exception.Message
    if ($Failure -match '^(GSDB[0-9]{3})\|(.+)$') {
        Write-GsdbFailure -Code $Matches[1] -Message $Matches[2]
    }
    else {
        Write-GsdbFailure -Code 'GSDB001' -Message 'validation failed without exposing internal details.'
    }
    exit 1
}
