<#
.SYNOPSIS
Prueft die TinyCalc-RL-SE-Selbstbewertung. / Validates the TinyCalc RL-SE self-assessment.

.DESCRIPTION
DE: Der Validator bindet die Matrix an das aktuelle Baseline-Manifest und verlangt alle 157
kanonischen Checklisten-IDs genau einmal. Er prueft Statuskombinationen,
Pflichtfelder, Human-only-Grenzen und sichere repository-relative Pfade.

EN: The validator binds the matrix to the current baseline manifest and requires all 157
canonical checklist IDs exactly once. It checks status combinations, required
fields, human-only boundaries, and safe repository-relative paths.

.PARAMETER Assessment
Pfad zur vollstaendigen Matrix. / Path to the complete matrix.

.PARAMETER RepositoryRoot
Repository-Wurzel fuer Quellen und Evidenz. / Repository root for sources and evidence.

.PARAMETER Action
Validate prueft die vollstaendige Matrix; ValidateRow prueft eine isolierte
Row-Fixture. / Validate checks the full matrix; ValidateRow checks one isolated row fixture.

.PARAMETER RowFixture
JSON-Datei mit genau einem Row-Objekt fuer Vertragstests. / JSON file containing one row object for contract tests.
#>
[CmdletBinding()]
param(
    [Alias('Matrix')]
    [string] $Assessment = 'docs/security/secure-development/2026-09-05-rl-se-self-assessment/assessment-matrix.json',
    [string] $RepositoryRoot = '.',
    [ValidateSet('Validate', 'ValidateRow', 'ValidateRows')]
    [string] $Action = 'Validate',
    [string] $RowFixture = ''
)

Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

function Stop-RlSeValidation {
    param([Parameter(Mandatory)][string] $Message)
    throw "RLSE_VALIDATION_BLOCKED: $Message"
}

function Get-RlSeProperty {
    param(
        [Parameter(Mandatory)][object] $Object,
        [Parameter(Mandatory)][string] $Name,
        [Parameter(Mandatory)][string] $Label
    )
    $property = $Object.PSObject.Properties[$Name]
    if (-not $property) {
        Stop-RlSeValidation "$Label fehlt."
    }
    return $property.Value
}

function Get-RlSeText {
    param(
        [Parameter(Mandatory)][object] $Object,
        [Parameter(Mandatory)][string] $Name,
        [Parameter(Mandatory)][string] $Label
    )
    $value = Get-RlSeProperty $Object $Name $Label
    if ($value -isnot [string] -or [string]::IsNullOrWhiteSpace($value)) {
        Stop-RlSeValidation "$Label muss nicht-leerer Text sein."
    }
    return [string] $value
}

function Read-RlSeJson {
    param([Parameter(Mandatory)][string] $Path)
    if (-not (Test-Path -LiteralPath $Path -PathType Leaf)) {
        Stop-RlSeValidation "JSON-Datei fehlt: $Path"
    }
    try {
        return Get-Content -LiteralPath $Path -Raw -Encoding utf8 | ConvertFrom-Json -Depth 100
    } catch {
        Stop-RlSeValidation "Ungueltiges UTF-8-JSON in $($Path): $($_.Exception.Message)"
    }
}

function Test-RlSeJsonSchema {
    param(
        [Parameter(Mandatory)][string] $DocumentPath,
        [Parameter(Mandatory)][string] $SchemaPath
    )
    try {
        $json = Get-Content -LiteralPath $DocumentPath -Raw -Encoding utf8
        $valid = Test-Json -Json $json -SchemaFile $SchemaPath -ErrorAction Stop
    } catch {
        Stop-RlSeValidation "Matrix verletzt das JSON-Schema: $($_.Exception.Message)"
    }
    if (-not $valid) {
        Stop-RlSeValidation 'Matrix verletzt das JSON-Schema.'
    }
}

function Get-RlSeNormalizedSha256 {
    param([Parameter(Mandatory)][string] $Path)
    $utf8 = [Text.UTF8Encoding]::new($false, $true)
    try {
        $text = $utf8.GetString([IO.File]::ReadAllBytes($Path))
    } catch {
        Stop-RlSeValidation "Datei ist kein gueltiges UTF-8: $Path"
    }
    if ($text.Length -gt 0 -and $text[0] -eq [char]0xFEFF) {
        $text = $text.Substring(1)
    }
    $crlf = [string][char]13 + [char]10
    $lf = [string][char]10
    $text = $text.Replace($crlf, $lf).Replace([string][char]13, $lf)
    return [Convert]::ToHexString(
        [Security.Cryptography.SHA256]::HashData($utf8.GetBytes($text))
    ).ToLowerInvariant()
}

function Test-RlSeRelativePath {
    param(
        [Parameter(Mandatory)][string] $Path,
        [Parameter(Mandatory)][string] $Label,
        [Parameter(Mandatory)][string] $Root,
        [switch] $MustExist
    )
    if ([string]::IsNullOrWhiteSpace($Path) -or
        $Path -match '^[\\/]' -or
        $Path -match '^[A-Za-z]:' -or
        ([IO.Path]::IsPathRooted($Path)) -or
        (@($Path -split '[\\/]') -contains '..')) {
        Stop-RlSeValidation "$Label ist kein sicherer repository-relativer Pfad: $Path"
    }
    $rootFull = [IO.Path]::GetFullPath($Root).TrimEnd(
        [IO.Path]::DirectorySeparatorChar,
        [IO.Path]::AltDirectorySeparatorChar
    )
    $candidate = [IO.Path]::GetFullPath((Join-Path $rootFull $Path))
    $prefix = $rootFull + [IO.Path]::DirectorySeparatorChar
    if (-not $candidate.StartsWith($prefix, [StringComparison]::Ordinal)) {
        Stop-RlSeValidation "$Label verlaesst das Repository: $Path"
    }
    if ($MustExist -and -not (Test-Path -LiteralPath $candidate -PathType Leaf)) {
        Stop-RlSeValidation "$Label verweist nicht auf eine vorhandene Datei: $Path"
    }
}

function Test-RlSeAssessmentRow {
    param(
        [Parameter(Mandatory)][object] $Row,
        [Parameter(Mandatory)][string] $Root,
        [string[]] $ExpectedIds = @(),
        [hashtable] $ExpectedSourceByFamily = @{}
    )
    $id = Get-RlSeText $Row 'id' 'row.id'
    if ($id -notmatch '^CL-(0[1-9]|1[0-2])-[0-9]{2}$') {
        Stop-RlSeValidation "Ungueltige Checklisten-ID: $id"
    }
    if ($ExpectedIds.Count -gt 0 -and $id -notin $ExpectedIds) {
        Stop-RlSeValidation "Unbekannte Checklisten-ID: $id"
    }
    $sourcePath = Get-RlSeText $Row 'sourcePath' "rows[$id].sourcePath"
    Test-RlSeRelativePath $sourcePath "rows[$id].sourcePath" $Root -MustExist
    $family = $id.Substring(0, 5)
    if ($ExpectedSourceByFamily.Count -gt 0 -and
        (-not $ExpectedSourceByFamily.ContainsKey($family) -or
         $ExpectedSourceByFamily[$family] -cne $sourcePath)) {
        Stop-RlSeValidation "Quellpfad passt nicht zur Familie $($family): $sourcePath"
    }

    $disposition = Get-RlSeText $Row 'disposition' "rows[$id].disposition"
    $applicability = Get-RlSeText $Row 'applicability' "rows[$id].applicability"
    $implementation = Get-RlSeText $Row 'implementationStatus' "rows[$id].implementationStatus"
    if ($disposition -notin @('Applicable', 'AlreadySatisfied', 'N/A', 'Open', 'FollowUp')) {
        Stop-RlSeValidation "Ungueltige Disposition fuer $($id): $disposition"
    }
    if ($applicability -notin @('Applicable', 'N/A', 'Open')) {
        Stop-RlSeValidation "Ungueltige Anwendbarkeit fuer $($id): $applicability"
    }
    if ($implementation -notin @('Fulfilled', 'Partly Fulfilled', 'Not Fulfilled', 'Not Assessed')) {
        Stop-RlSeValidation "Ungueltiger Umsetzungsstand fuer $($id): $implementation"
    }
    foreach ($name in @('rationale', 'owner', 'followUp', 'risk', 'reevaluationTrigger', 'residualRisk')) {
        $null = Get-RlSeText $Row $name "rows[$id].$name"
    }
    $priority = Get-RlSeText $Row 'priority' "rows[$id].priority"
    if ($priority -notin @('Critical', 'High', 'Medium', 'Low', 'None')) {
        Stop-RlSeValidation "Ungueltige Prioritaet fuer $($id): $priority"
    }

    $evidence = @(Get-RlSeProperty $Row 'evidence' "rows[$id].evidence")
    foreach ($evidencePath in $evidence) {
        if ($evidencePath -isnot [string]) {
            Stop-RlSeValidation "Evidenzpfad fuer $id muss Text sein."
        }
        Test-RlSeRelativePath ([string] $evidencePath) "rows[$id].evidence" $Root -MustExist
    }
    if (@($evidence | Sort-Object -Unique).Count -ne $evidence.Count) {
        Stop-RlSeValidation "Doppelte Evidenzpfade fuer $id."
    }

    $openMarker = Get-RlSeProperty $Row 'openMarker' "rows[$id].openMarker"
    $humanOnly = Get-RlSeProperty $Row 'humanOnly' "rows[$id].humanOnly"
    if ($openMarker -isnot [bool] -or $humanOnly -isnot [bool]) {
        Stop-RlSeValidation "openMarker und humanOnly muessen Boolean sein: $id"
    }
    if ((Get-RlSeText $Row 'humanDecisionEvidence' "rows[$id].humanDecisionEvidence") -cne 'NotProvided') {
        Stop-RlSeValidation "Human-only-Evidenz darf nicht erfunden werden: $id"
    }

    switch ($disposition) {
        'AlreadySatisfied' {
            if ($applicability -ne 'Applicable' -or $implementation -ne 'Fulfilled' -or
                $openMarker -or $evidence.Count -eq 0) {
                Stop-RlSeValidation "AlreadySatisfied-Kombination ist unzulaessig: $id"
            }
        }
        'Applicable' {
            if ($applicability -ne 'Applicable' -or $implementation -eq 'Fulfilled' -or
                -not $openMarker -or $evidence.Count -eq 0) {
                Stop-RlSeValidation "Applicable-Kombination ist unzulaessig: $id"
            }
        }
        'N/A' {
            if ($applicability -ne 'N/A' -or $implementation -ne 'Not Assessed' -or $openMarker) {
                Stop-RlSeValidation "N/A-Kombination ist unzulaessig: $id"
            }
        }
        'Open' {
            if ($applicability -ne 'Open' -or $implementation -ne 'Not Assessed' -or
                -not $openMarker -or $priority -eq 'None') {
                Stop-RlSeValidation "Open-Kombination ist unzulaessig: $id"
            }
        }
        'FollowUp' {
            if ($applicability -ne 'Applicable' -or $implementation -eq 'Fulfilled' -or
                -not $openMarker -or $priority -eq 'None') {
                Stop-RlSeValidation "FollowUp-Kombination ist unzulaessig: $id"
            }
        }
    }
    if ($humanOnly -and
        ($disposition -notin @('Open', 'FollowUp') -or $implementation -eq 'Fulfilled')) {
        Stop-RlSeValidation "Human-only-Grenze verletzt: $id"
    }
}

function Test-RlSeAssessment {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string] $AssessmentPath,
        [Parameter(Mandatory)][string] $Root
    )
    $rootFull = (Resolve-Path -LiteralPath $Root).Path
    $schemaPath = Join-Path $rootFull 'specs/004-rl-se-self-assessment/contracts/assessment-matrix.schema.json'
    $schema = Read-RlSeJson $schemaPath
    if ([int] $schema.properties.rows.minItems -ne 157 -or
        [int] $schema.properties.rows.maxItems -ne 157) {
        Stop-RlSeValidation 'Vertragsschema verlangt nicht exakt 157 Zeilen.'
    }

    $fullAssessment = if ([IO.Path]::IsPathRooted($AssessmentPath)) {
        [IO.Path]::GetFullPath($AssessmentPath)
    } else {
        [IO.Path]::GetFullPath((Join-Path $rootFull $AssessmentPath))
    }
    Test-RlSeJsonSchema $fullAssessment $schemaPath
    $document = Read-RlSeJson $fullAssessment
    if ((Get-RlSeText $document 'schemaVersion' 'schemaVersion') -cne '1.0' -or
        (Get-RlSeText $document 'assessmentId' 'assessmentId') -cne 'rl-se-self-assessment-2026-09-05') {
        Stop-RlSeValidation 'Matrixidentitaet oder Schema-Version ist ungueltig.'
    }

    $manifestRelative = 'docs/secure-development/baseline-manifest.json'
    $manifestPath = Join-Path $rootFull $manifestRelative
    $manifest = Read-RlSeJson $manifestPath
    $baseline = Get-RlSeProperty $document 'baseline' 'baseline'
    if ((Get-RlSeText $baseline 'manifestPath' 'baseline.manifestPath') -cne $manifestRelative -or
        (Get-RlSeText $baseline 'baselineVersion' 'baseline.baselineVersion') -cne [string] $manifest.baselineVersion -or
        (Get-RlSeText $baseline 'manifestNormalizedSha256' 'baseline.manifestNormalizedSha256') -cne
            (Get-RlSeNormalizedSha256 $manifestPath)) {
        Stop-RlSeValidation 'Baseline-Bindung stimmt nicht mit dem aktuellen Manifest ueberein.'
    }

    $docRoot = Split-Path -Parent $manifestPath
    $controlled = @(
        [pscustomobject]@{ path = $manifest.guideline.path; version = $manifest.guideline.version },
        [pscustomobject]@{ path = $manifest.compendium.path; version = $manifest.compendium.version }
    )
    $controlled += @($manifest.checklists | ForEach-Object {
        [pscustomobject]@{ path = $_.path; version = $_.version }
    })
    $controlled += @($manifest.relatedDocuments | ForEach-Object {
        [pscustomobject]@{ path = $_.path; version = $_.version }
    })
    $controlled += @($manifest.learningDocuments | ForEach-Object {
        [pscustomobject]@{ path = $_.path; version = $_.version }
    })
    $bindings = @(Get-RlSeProperty $baseline 'documentBindings' 'baseline.documentBindings')
    if ($bindings.Count -ne $controlled.Count -or
        @($bindings.path | Sort-Object -Unique).Count -ne $bindings.Count) {
        Stop-RlSeValidation "Dokumentbindungen unvollstaendig oder doppelt: erwartet $($controlled.Count)."
    }
    foreach ($item in $controlled) {
        $bindingMatches = @($bindings | Where-Object path -CEQ $item.path)
        if ($bindingMatches.Count -ne 1 -or
            (Get-RlSeText $bindingMatches[0] 'version' "binding[$($item.path)].version") -cne [string] $item.version -or
            (Get-RlSeText $bindingMatches[0] 'normalizedSha256' "binding[$($item.path)].hash") -cne
                (Get-RlSeNormalizedSha256 (Join-Path $docRoot $item.path))) {
            Stop-RlSeValidation "Dokumentbindung stimmt nicht: $($item.path)"
        }
    }

    $expectedSources = @($manifest.checklists | ForEach-Object {
        'docs/secure-development/' + ([string] $_.path).Replace('\', '/')
    })
    $sources = @(Get-RlSeProperty $document 'sourceFiles' 'sourceFiles')
    if ($sources.Count -ne 12 -or ($sources -join '|') -cne ($expectedSources -join '|')) {
        Stop-RlSeValidation 'sourceFiles muessen den 12 Manifest-Checklisten in Reihenfolge entsprechen.'
    }
    foreach ($source in $sources) {
        Test-RlSeRelativePath ([string] $source) 'sourceFiles' $rootFull -MustExist
    }

    $expectedIds = [Collections.Generic.List[string]]::new()
    $sourceByFamily = @{}
    foreach ($index in 0..($manifest.checklists.Count - 1)) {
        $checklist = $manifest.checklists[$index]
        $family = [string] $checklist.id
        $sourceByFamily[$family] = $expectedSources[$index]
        $content = Get-Content -LiteralPath (Join-Path $docRoot $checklist.path) -Raw -Encoding utf8
        foreach ($match in [regex]::Matches($content, '(?m)^#### (CL-[0-9]{2}-[0-9]{2}):')) {
            $expectedIds.Add($match.Groups[1].Value)
        }
    }
    if ($expectedIds.Count -ne 157 -or @($expectedIds | Sort-Object -Unique).Count -ne 157) {
        Stop-RlSeValidation 'Kanonische Quelle enthaelt nicht genau 157 eindeutige IDs.'
    }

    $rows = @(Get-RlSeProperty $document 'rows' 'rows')
    if ($rows.Count -ne 157) {
        Stop-RlSeValidation "Matrix muss genau 157 Zeilen enthalten; gefunden: $($rows.Count)."
    }
    foreach ($row in $rows) {
        Test-RlSeAssessmentRow $row $rootFull $expectedIds.ToArray() $sourceByFamily
    }
    $actualIds = @($rows.id)
    if (@($actualIds | Sort-Object -Unique).Count -ne 157 -or
        (($actualIds | Sort-Object) -join '|') -cne (($expectedIds | Sort-Object) -join '|')) {
        Stop-RlSeValidation 'IDs sind doppelt, fehlen oder sind unbekannt.'
    }

    $summary = Get-RlSeProperty $document 'summary' 'summary'
    if ([int](Get-RlSeProperty $summary 'total' 'summary.total') -ne 157) {
        Stop-RlSeValidation 'summary.total muss 157 sein.'
    }
    $byDisposition = Get-RlSeProperty $summary 'byDisposition' 'summary.byDisposition'
    foreach ($name in @('Applicable', 'AlreadySatisfied', 'N/A', 'Open', 'FollowUp')) {
        $expected = @($rows | Where-Object disposition -CEQ $name).Count
        if ([int](Get-RlSeProperty $byDisposition $name "summary.byDisposition.$name") -ne $expected) {
            Stop-RlSeValidation "Disposition-Summe stimmt nicht: $name"
        }
    }
    $byFamily = Get-RlSeProperty $summary 'byFamily' 'summary.byFamily'
    foreach ($family in 1..12 | ForEach-Object { 'CL-{0:D2}' -f $_ }) {
        $expected = @($rows | Where-Object { $_.id.StartsWith("$family-", [StringComparison]::Ordinal) }).Count
        if ([int](Get-RlSeProperty $byFamily $family "summary.byFamily.$family") -ne $expected) {
            Stop-RlSeValidation "Familien-Summe stimmt nicht: $family"
        }
    }

    $openCount = @($rows | Where-Object openMarker).Count
    Write-Output "RLSE_VALIDATION_OK: 157/157 canonical IDs; open-or-follow-up markers: $openCount"
}

try {
    $root = (Resolve-Path -LiteralPath $RepositoryRoot).Path
    if ($Action -eq 'ValidateRow') {
        if ([string]::IsNullOrWhiteSpace($RowFixture)) {
            Stop-RlSeValidation 'RowFixture fehlt fuer ValidateRow.'
        }
        $row = Read-RlSeJson $RowFixture
        Test-RlSeAssessmentRow $row $root
        Write-Output 'RLSE_ROW_OK: isolated row contract passed.'
    } elseif ($Action -eq 'ValidateRows') {
        if ([string]::IsNullOrWhiteSpace($RowFixture)) {
            Stop-RlSeValidation 'RowFixture fehlt fuer ValidateRows.'
        }
        $rows = @(Read-RlSeJson $RowFixture)
        if ($rows.Count -eq 0) {
            Stop-RlSeValidation 'RowFixture enthaelt keine Zeile.'
        }
        foreach ($row in $rows) {
            Test-RlSeAssessmentRow $row $root
        }
        if (@($rows.id | Sort-Object -Unique).Count -ne $rows.Count) {
            Stop-RlSeValidation 'Doppelte Checklisten-ID in isolierter Row-Fixture.'
        }
        Write-Output "RLSE_ROWS_OK: $($rows.Count) isolated row contracts passed."
    } else {
        Test-RlSeAssessment $Assessment $root
    }
    exit 0
} catch {
    [Console]::Error.WriteLine($_.Exception.Message)
    exit 2
}
