Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'

$RepositoryRoot = [IO.Path]::GetFullPath((Join-Path $PSScriptRoot '../../..'))
$Validator = Join-Path $RepositoryRoot 'scripts/validate-gsdb-intensive-review.ps1'
$ValidFixture = Join-Path $PSScriptRoot 'valid-assessment.json'
$ProductionAssessment = Join-Path $RepositoryRoot 'docs/security/gsdb-intensive-review/evidence-matrix.json'
$FixtureRoot = Join-Path ([IO.Path]::GetTempPath()) (
    'tinycalc-gsdb-fixtures-{0}' -f [guid]::NewGuid())
$Utf8NoBom = [Text.UTF8Encoding]::new($false)

function Copy-GsdbFixture {
    param(
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory)][scriptblock]$Mutate
    )

    $Document = Get-Content -LiteralPath $ValidFixture -Raw |
        ConvertFrom-Json -AsHashtable -Depth 100
    & $Mutate $Document
    $Target = Join-Path $FixtureRoot "${Name}.json"
    # ConvertTo-Json folgt auf Windows der Plattform-Zeilenendung. Fixtures
    # müssen den produktiven LF-Vertrag trotzdem auf jedem Runner erfüllen.
    # ConvertTo-Json follows the platform newline on Windows. Fixtures must
    # still meet the production LF contract on every runner.
    $Json = ($Document | ConvertTo-Json -Depth 100).Replace("`r`n", "`n").Replace("`r", "`n")
    [IO.File]::WriteAllText($Target, ($Json + "`n"), $Utf8NoBom)
    return $Target
}

function Copy-GsdbProductionAssessment {
    param(
        [Parameter(Mandatory)][string]$Name,
        [Parameter(Mandatory)][scriptblock]$Mutate
    )

    $Document = Get-Content -LiteralPath $ProductionAssessment -Raw |
        ConvertFrom-Json -AsHashtable -Depth 100
    & $Mutate $Document
    $Target = Join-Path $FixtureRoot "production-${Name}.json"
    $Json = ($Document | ConvertTo-Json -Depth 100).Replace("`r`n", "`n").Replace("`r", "`n")
    [IO.File]::WriteAllText($Target, ($Json + "`n"), $Utf8NoBom)
    return $Target
}

function Assert-GsdbFailure {
    param(
        [Parameter(Mandatory)][string]$Assessment,
        [Parameter(Mandatory)][string]$ExpectedCode,
        [string]$ValidationRoot = $RepositoryRoot
    )

    $Output = @(
        & pwsh -NoProfile -File $Validator -Action Validate `
            -Assessment $Assessment -RepositoryRoot $ValidationRoot 2>&1
    )
    $ExitCode = $LASTEXITCODE
    if ($ExitCode -eq 0) {
        throw "Expected non-zero for ${ExpectedCode}."
    }
    $Text = $Output -join "`n"
    if ($Text -notmatch "^${ExpectedCode}:") {
        throw "Expected ${ExpectedCode}; output was: $Text"
    }
    $OtherCode = [regex]::Match($Text, 'GSDB[0-9]{3}').Value
    if ($OtherCode -cne $ExpectedCode) {
        throw "Expected only ${ExpectedCode}; observed ${OtherCode}."
    }
}

New-Item -ItemType Directory -Path $FixtureRoot | Out-Null
try {
    $Missing = Join-Path $FixtureRoot 'missing.json'
    Assert-GsdbFailure -Assessment $Missing -ExpectedCode 'GSDB001'

    $Fixtures = [ordered]@{}
    $Fixtures.GSDB002 = Copy-GsdbFixture -Name 'unsafe-source' -Mutate {
        param($Document)
        $Document.sourceInventory[0].normalizedSha256 =
            ([string]$Document.sourceInventory[0].normalizedSha256).ToUpperInvariant()
    }
    $Fixtures.GSDB003 = Copy-GsdbFixture -Name 'unknown-id' -Mutate {
        param($Document)
        $Document.checklistRows[0].id = 'CL-99-99'
    }
    $Fixtures.GSDB004 = Copy-GsdbFixture -Name 'compendium-mismatch' -Mutate {
        param($Document)
        $Document.fixtureCanonicalBlock = 'canonical'
        $Document.fixtureCompendiumBlock = 'different'
    }
    $Fixtures.GSDB005 = Copy-GsdbFixture -Name 'missing-learning-stage' -Mutate {
        param($Document)
        $Document.checklistRows[0].Remove('learningStage')
    }
    $Fixtures.GSDB006 = Copy-GsdbFixture -Name 'unsupported-positive' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence = @()
    }
    $Fixtures.GSDB007 = Copy-GsdbFixture -Name 'fabricated-human-approval' -Mutate {
        param($Document)
        $Document.checklistRows[0].humanOnly = $true
    }
    $Fixtures.GSDB008 = Copy-GsdbFixture -Name 'missing-preset' -Mutate {
        param($Document)
        $Document.presetAssessments = @()
        $Document.fixtureExpectedPresetIds = @('security-governance')
    }
    $Fixtures.GSDB009 = Copy-GsdbFixture -Name 'missing-finding-link' -Mutate {
        param($Document)
        $Document.checklistRows[0].findingIds = @('GSDB-FINDING-001')
        $Document.findings = @()
    }
    $Fixtures.GSDB010 = Copy-GsdbFixture -Name 'summary-drift' -Mutate {
        param($Document)
        $Document.summary = @{ checklistTotal = 2 }
    }

    foreach ($Pair in $Fixtures.GetEnumerator()) {
        Assert-GsdbFailure -Assessment $Pair.Value -ExpectedCode $Pair.Key
    }

    $UnsafeEvidence = Copy-GsdbProductionAssessment -Name 'absolute-evidence' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence[0].path = '/tmp/not-repository-evidence'
    }
    Assert-GsdbFailure -Assessment $UnsafeEvidence -ExpectedCode 'GSDB001'

    foreach ($UnsafePath in @('../outside.json', 'C:/outside.json', 'docs\outside.json')) {
        $UnsafeSource = Copy-GsdbFixture -Name ('unsafe-path-' + [guid]::NewGuid()) -Mutate {
            param($Document)
            $Document.sourceInventory[0].path = $UnsafePath
        }
        Assert-GsdbFailure -Assessment $UnsafeSource -ExpectedCode 'GSDB002'
    }

    $SymlinkRoot = Join-Path $FixtureRoot 'symlink-root'
    New-Item -ItemType Directory -Path $SymlinkRoot | Out-Null
    New-Item -ItemType SymbolicLink -Path (Join-Path $SymlinkRoot 'linked-source.json') `
        -Target (Join-Path $RepositoryRoot 'docs/secure-development/baseline-manifest.json') | Out-Null
    $SymlinkSource = Copy-GsdbFixture -Name 'symlink-boundary' -Mutate {
        param($Document)
        $Document.sourceInventory[0].path = 'linked-source.json'
    }
    Assert-GsdbFailure -Assessment $SymlinkSource -ExpectedCode 'GSDB002' `
        -ValidationRoot $SymlinkRoot

    $PlaceholderLocator = Copy-GsdbProductionAssessment -Name 'placeholder-locator' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence[0].locator = 'Evidence for CL-01-01'
    }
    Assert-GsdbFailure -Assessment $PlaceholderLocator -ExpectedCode 'GSDB006'

    $MissingLocator = Copy-GsdbProductionAssessment -Name 'missing-locator-target' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence[0].locator = 'definitely-missing-locator-target'
    }
    Assert-GsdbFailure -Assessment $MissingLocator -ExpectedCode 'GSDB006'

    foreach ($LocatorCase in @(
        @{ Name = 'json-locator'; Row = 'CL-01-03'; Path = 'docs/security/sbom/tinycalc-terminalgui.spdx.json' },
        @{ Name = 'script-locator'; Row = 'CL-10-06'; Path = 'scripts/scan-agent-secrets.ps1' },
        @{ Name = 'registry-locator'; Row = 'CL-12-06'; Path = '.specify/presets/.registry' }
    )) {
        $InvalidLocator = Copy-GsdbProductionAssessment -Name $LocatorCase.Name -Mutate {
            param($Document)
            $TargetRow = $Document.checklistRows | Where-Object id -CEQ $LocatorCase.Row | Select-Object -First 1
            $TargetEvidence = $TargetRow.evidence | Where-Object path -CEQ $LocatorCase.Path | Select-Object -First 1
            $TargetEvidence.locator = 'definitely-missing-exact-locator'
            $TargetEvidence.supports.de = "$($TargetRow.id) bindet $($TargetEvidence.path) an definitely-missing-exact-locator."
            $TargetEvidence.supports.en = "$($TargetRow.id) binds $($TargetEvidence.path) at definitely-missing-exact-locator."
        }
        Assert-GsdbFailure -Assessment $InvalidLocator -ExpectedCode 'GSDB006'
    }

    $UnboundEvidence = Copy-GsdbProductionAssessment -Name 'unbound-evidence' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence[0].path = 'README.md'
        $Document.checklistRows[0].evidence[0].locator = '# TinyCalc'
        $Document.checklistRows[0].evidence[0].supports.de = 'CL-01-01 bindet README.md an # TinyCalc.'
        $Document.checklistRows[0].evidence[0].supports.en = 'CL-01-01 binds README.md at # TinyCalc.'
    }
    Assert-GsdbFailure -Assessment $UnboundEvidence -ExpectedCode 'GSDB006'

    $StaleEvidence = Copy-GsdbProductionAssessment -Name 'stale-positive-evidence' -Mutate {
        param($Document)
        $ThreatSource = $Document.sourceInventory | Where-Object path -CEQ 'docs/security/threat-model.md' | Select-Object -First 1
        $ThreatSource.freshness = 'Stale'
    }
    Assert-GsdbFailure -Assessment $StaleEvidence -ExpectedCode 'GSDB006'

    $AvailabilityDrift = Copy-GsdbProductionAssessment -Name 'availability-freshness-drift' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence[0].freshness = 'Planned'
    }
    Assert-GsdbFailure -Assessment $AvailabilityDrift -ExpectedCode 'GSDB006'

    $StaleFeatureBinding = Copy-GsdbProductionAssessment -Name 'stale-feature-heading' -Mutate {
        param($Document)
        $TargetRow = $Document.checklistRows | Where-Object id -CEQ 'CL-01-02' | Select-Object -First 1
        $TargetEvidence = $TargetRow.evidence | Where-Object path -CEQ 'docs/security/asvs-verification.md' | Select-Object -First 1
        $TargetEvidence.locator = 'ASVS-Anwendbarkeit: TinyCalc Feature 003'
        $TargetEvidence.supports.de = 'CL-01-02 bindet docs/security/asvs-verification.md an ASVS-Anwendbarkeit: TinyCalc Feature 003.'
        $TargetEvidence.supports.en = 'CL-01-02 binds docs/security/asvs-verification.md at ASVS-Anwendbarkeit: TinyCalc Feature 003.'
    }
    Assert-GsdbFailure -Assessment $StaleFeatureBinding -ExpectedCode 'GSDB006'

    $GenericRationale = Copy-GsdbProductionAssessment -Name 'generic-rationale' -Mutate {
        param($Document)
        $Document.checklistRows[0].rationale.de = 'Der Kontrollpunkt CL-01-01 ist allgemein bewertet.'
        $Document.checklistRows[0].rationale.en = 'The control CL-01-01 is assessed generically.'
    }
    Assert-GsdbFailure -Assessment $GenericRationale -ExpectedCode 'GSDB005'

    $GenericSupport = Copy-GsdbProductionAssessment -Name 'generic-support' -Mutate {
        param($Document)
        $Document.checklistRows[0].evidence[0].supports.de = 'Der Locator CL-01-01 in constitution.md dokumentiert den aktuellen Teilnachweis.'
        $Document.checklistRows[0].evidence[0].supports.en = 'The locator CL-01-01 in constitution.md records the current evidence.'
    }
    Assert-GsdbFailure -Assessment $GenericSupport -ExpectedCode 'GSDB006'

    $PresetDrift = Copy-GsdbProductionAssessment -Name 'preset-semantic-drift' -Mutate {
        param($Document)
        $Document.presetAssessments[0].mappedGateIds = @('GSDB-GATE-001')
    }
    Assert-GsdbFailure -Assessment $PresetDrift -ExpectedCode 'GSDB008'

    $PresetChecklistDrift = Copy-GsdbProductionAssessment -Name 'preset-checklist-drift' -Mutate {
        param($Document)
        $Document.presetAssessments[0].mappedChecklistIds = @($Document.presetAssessments[0].mappedChecklistIds | Select-Object -Skip 1)
    }
    Assert-GsdbFailure -Assessment $PresetChecklistDrift -ExpectedCode 'GSDB008'

    # DE: Der optionale Pilot darf weder fehlen noch Sicherheitswirkung vortäuschen.
    # EN: The optional pilot must neither disappear nor imply security effectiveness.
    $MissingStatistics = Copy-GsdbProductionAssessment -Name 'missing-statistics-preset' -Mutate {
        param($Document)
        $Document.presetAssessments = @($Document.presetAssessments | Where-Object presetId -ne 'project-statistics-governance')
    }
    Assert-GsdbFailure -Assessment $MissingStatistics -ExpectedCode 'GSDB001'
    foreach ($Mutation in @('Version', 'Priority', 'ControlClaim', 'StandardMatrix')) {
        $StatisticsDrift = Copy-GsdbProductionAssessment -Name "statistics-$Mutation" -Mutate {
            param($Document)
            $Preset = $Document.presetAssessments | Where-Object presetId -eq 'project-statistics-governance'
            switch ($Mutation) {
                'Version' { $Preset.version = '0.0.0' }
                'Priority' { $Preset.priority = 90 }
                'ControlClaim' { $Preset.mappedChecklistIds = @('CL-01-01') }
                'StandardMatrix' { $Preset.standardMatrixMember = $true }
            }
        }
        Assert-GsdbFailure -Assessment $StatisticsDrift -ExpectedCode 'GSDB008'
    }

    # DE: Ein Patch-Upgrade erneuert konkrete Bindungen, nicht die Fehlertoleranz.
    # EN: A patch upgrade refreshes exact bindings, not validation tolerance.
    foreach ($OldSource in @(
        @{ Path = '.specify/presets/intake-authoring-governance/preset.yml'; Hash = '647920968d4f49290b0b04ed3a7cd3381f0303d21de224c02ed8351c961441ff' },
        @{ Path = '.specify/presets/intake-authoring-governance/preset.yml'; Hash = '3c934d29268fd284aa8641b491d6725cda54480c19065482dc7d270bf27f0186' },
        @{ Path = '.specify/presets/.registry'; Hash = '2186bf44b3ef1f7f425b9c4da9d53133a66099af11b8818bbcedb7a0152429d6' }
    )) {
        $StaleAuthoringSource = Copy-GsdbProductionAssessment -Name ('authoring-source-' + [guid]::NewGuid()) -Mutate {
            param($Document)
            $Source = $Document.sourceInventory | Where-Object path -CEQ $OldSource.Path
            $Source.normalizedSha256 = $OldSource.Hash
        }
        Assert-GsdbFailure -Assessment $StaleAuthoringSource -ExpectedCode 'GSDB002'
    }
    foreach ($WrongVersion in @('0.3.4', '0.3.6', '99.0.0')) {
        $AuthoringVersionDrift = Copy-GsdbProductionAssessment -Name "authoring-version-$WrongVersion" -Mutate {
            param($Document)
            $Preset = $Document.presetAssessments | Where-Object presetId -CEQ 'intake-authoring-governance'
            $Preset.version = $WrongVersion
        }
        Assert-GsdbFailure -Assessment $AuthoringVersionDrift -ExpectedCode 'GSDB008'
    }

    # DE: Die drei vorigen Patch-Bindungen muessen jeweils geschlossen scheitern.
    # EN: Reject each preceding patch hash and version independently.
    foreach ($OldPatch in @(
        @{ Id = 'architecture-governance'; Version = '0.6.1'; Hash = '860931928acf952882491f933f2498b4be7bf3a31cc07b4c649c23396b6a0988' },
        @{ Id = 'security-governance'; Version = '0.7.0'; Hash = '68214a39f7ebbbd949f1965dfe2ba98f960529662339abd106fa8eb366d97c4b' },
        @{ Id = 'intake-sequencing-governance'; Version = '0.2.7'; Hash = '172de02fac9360821550e719771efa419127b3b14dfae26a32a664a9607e3cbe' }
    )) {
        $StalePatchSource = Copy-GsdbProductionAssessment -Name ($OldPatch.Id + '-previous-patch-hash') -Mutate {
            param($Document)
            $Source = $Document.sourceInventory | Where-Object sourceId -CEQ ('PRESET-' + $OldPatch.Id)
            $Source.normalizedSha256 = $OldPatch.Hash
        }
        Assert-GsdbFailure -Assessment $StalePatchSource -ExpectedCode 'GSDB002'
        $StalePatchVersion = Copy-GsdbProductionAssessment -Name ($OldPatch.Id + '-previous-patch-version') -Mutate {
            param($Document)
            $Preset = $Document.presetAssessments | Where-Object presetId -CEQ $OldPatch.Id
            $Preset.version = $OldPatch.Version
        }
        Assert-GsdbFailure -Assessment $StalePatchVersion -ExpectedCode 'GSDB008'
    }

    # DE: Alle fuenf alten Release-Bindungen bleiben gesondert blockiert.
    # EN: Reject each previous release binding independently.
    foreach ($OldPreset in @(
        @{ Id = 'architecture-governance'; Version = '0.5.2'; Hash = 'e2dc16bd0a566424dadbdb14a32cae5805d23d5f72e57a3bb3b5e47821882293' },
        @{ Id = 'intake-authoring-governance'; Version = '0.3.5'; Hash = '74a5bd0afc28ab4b3a997b2831278dcd215171552cac9877095fd08176a4591f' },
        @{ Id = 'intake-review-governance'; Version = '0.2.3'; Hash = '0fe3aedc8ed9b27a9874eabe28b2f457e2de68610e80e72007871249d62327ce' },
        @{ Id = 'intake-sequencing-governance'; Version = '0.2.6'; Hash = '8b517455df03fcb23f5e05e4a569a751fe72bedaa6932e669bbe368d00353e48' },
        @{ Id = 'security-governance'; Version = '0.6.2'; Hash = '356daaedfb3b0275c093d7e522b3e616091c1249a2622e071ae4ff690b5a239d' }
    )) {
        $StaleSource = Copy-GsdbProductionAssessment -Name ($OldPreset.Id + '-old-hash') -Mutate {
            param($Document)
            $Source = $Document.sourceInventory | Where-Object sourceId -CEQ ('PRESET-' + $OldPreset.Id)
            $Source.normalizedSha256 = $OldPreset.Hash
        }
        Assert-GsdbFailure -Assessment $StaleSource -ExpectedCode 'GSDB002'
        $StaleVersion = Copy-GsdbProductionAssessment -Name ($OldPreset.Id + '-old-version') -Mutate {
            param($Document)
            $Preset = $Document.presetAssessments | Where-Object presetId -CEQ $OldPreset.Id
            $Preset.version = $OldPreset.Version
        }
        Assert-GsdbFailure -Assessment $StaleVersion -ExpectedCode 'GSDB008'
    }
    $OldBaseline = Copy-GsdbProductionAssessment -Name 'old-baseline-version' -Mutate {
        param($Document)
        $Document.baseline.baselineVersion = '3.2.0'
    }
    Assert-GsdbFailure -Assessment $OldBaseline -ExpectedCode 'GSDB001'

    $FindingDrift = Copy-GsdbProductionAssessment -Name 'finding-reciprocity' -Mutate {
        param($Document)
        $Document.findings[0].sourceReferences = @($Document.findings[0].sourceReferences | Select-Object -Skip 1)
    }
    Assert-GsdbFailure -Assessment $FindingDrift -ExpectedCode 'GSDB009'

    $OrphanedFinding = Copy-GsdbProductionAssessment -Name 'orphaned-finding' -Mutate {
        param($Document)
        $Clone = $Document.findings[0].Clone()
        $Clone.id = 'GSDB-FINDING-999'
        $Document.findings += $Clone
    }
    Assert-GsdbFailure -Assessment $OrphanedFinding -ExpectedCode 'GSDB009'

    $DowngradedFinding = Copy-GsdbProductionAssessment -Name 'downgraded-finding' -Mutate {
        param($Document)
        $Document.findings[0].severity = 'Low'
    }
    Assert-GsdbFailure -Assessment $DowngradedFinding -ExpectedCode 'GSDB009'

    foreach ($StatusCase in @('fulfilled-severity', 'open-without-human', 'na-with-severity')) {
        $InvalidStatus = Copy-GsdbProductionAssessment -Name $StatusCase -Mutate {
            param($Document)
            switch ($StatusCase) {
                'fulfilled-severity' { $Document.checklistRows[0].severity = 'Medium' }
                'open-without-human' {
                    $OpenRow = $Document.checklistRows | Where-Object applicability -CEQ 'Open' | Select-Object -First 1
                    $OpenRow.humanOnly = $false
                }
                'na-with-severity' {
                    $NaRow = $Document.checklistRows | Where-Object applicability -CEQ 'N/A' | Select-Object -First 1
                    $NaRow.severity = 'Medium'
                }
            }
        }
        Assert-GsdbFailure -Assessment $InvalidStatus -ExpectedCode 'GSDB005'
    }

    $SensitiveSentinel = 'sentinel-secret-value'
    $InvalidActionOutput = @(
        & pwsh -NoProfile -File $Validator -Action $SensitiveSentinel `
            -Assessment $ValidFixture -RepositoryRoot $RepositoryRoot 2>&1
    )
    if ($LASTEXITCODE -eq 0 -or
        ($InvalidActionOutput -join "`n") -cne 'GSDB001: unsupported action.' -or
        ($InvalidActionOutput -join "`n").Contains($SensitiveSentinel)) {
        throw 'Invalid action handling is not stable and redacted.'
    }

    & pwsh -NoProfile -File $Validator -Action Validate `
        -Assessment $ValidFixture -RepositoryRoot $RepositoryRoot
    if ($LASTEXITCODE -ne 0) {
        throw 'The smallest valid helper fixture did not pass.'
    }
}
finally {
    Remove-Item -LiteralPath $FixtureRoot -Recurse -Force -ErrorAction SilentlyContinue
}

Write-Output 'PASS: PowerShell fixtures cover GSDB001 through GSDB010.'
