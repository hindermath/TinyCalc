#Requires -Version 7
Set-StrictMode -Version Latest

# DE: Diese pure Prüfung startet nichts; unabhängiger Nenner und Sollwerte bleiben getrennt von Resultaten.
# EN: This pure check starts nothing; the independent denominator and oracles stay separate from results.
function Test-TuiEvidenceModel {
    param($Baseline, $Contract, $Bundles, $Binding)
    $Findings = [Collections.Generic.List[object]]::new()
    function Add-Finding([string]$Code, [string]$Ref) {
        $Findings.Add([pscustomobject]@{ code = $Code; sourceRef = $Ref })
    }
    function Same-Observation($Expected, $Actual, [string]$PathId) {
        foreach ($Key in $Expected.Keys) {
            if (-not $Actual.Contains($Key)) { return $false }
            if ($Key -eq 'value') {
                $Left = [double]$Expected[$Key]; $Right = [double]$Actual[$Key]
                if (-not [double]::IsFinite($Left) -or -not [double]::IsFinite($Right)) { return $false }
                $Tolerance = 0.0
                if ($PathId -eq 'FUNC-LEGACY-fact-upper') { $Tolerance = [Math]::Abs($Left) * 1e-14 }
                elseif ($PathId -match '(?:sin|cos|arctan|ln|exp|average|round)-') { $Tolerance = 1e-12 }
                if ([Math]::Abs($Left - $Right) -gt $Tolerance) { return $false }
            }
            elseif ((Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Expected[$Key] -Depth 40 -Compress)) -cne
                    (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Actual[$Key] -Depth 40 -Compress))) { return $false }
        }
        return $true
    }
    function Read-Time([string]$Text) {
        $Time = [DateTimeOffset]::MinValue
        if ($Text -notmatch '(?:Z|\+00:00)$' -or
            -not [DateTimeOffset]::TryParse($Text, [Globalization.CultureInfo]::InvariantCulture,
                [Globalization.DateTimeStyles]::RoundtripKind, [ref]$Time)) { return $null }
        return $Time
    }

    $Offers = @{}
    foreach ($Offer in $Baseline.offers) {
        if ($Offers.ContainsKey($Offer.id)) { Add-Finding DuplicateObligation $Offer.id }
        $Offers[$Offer.id] = $Offer
    }
    $Capabilities = @{}; $Paths = @{}; $Required = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($Capability in $Contract.capabilities) {
        if ($Capabilities.ContainsKey($Capability.id)) { Add-Finding DuplicateObligation $Capability.id }
        $Capabilities[$Capability.id] = $Capability
        $Active = $Capability.mandatory -and $Capability.status -in @('Active', 'Deprecated')
        if ($Active -and @(Compare-Object @('linux','windows','macos') @($Capability.platforms)).Count -ne 0) { Add-Finding MissingObligation ($Capability.id + ':platforms') }
        foreach ($Path in $Capability.paths) {
            if ($Paths.ContainsKey($Path.pathId)) { Add-Finding DuplicateObligation $Path.pathId }
            $Paths[$Path.pathId] = @{ capability = $Capability; path = $Path }
            if ($Offers.ContainsKey($Path.pathId)) {
                $Offer = $Offers[$Path.pathId]
                if ($Capability.family -cne $Offer.family -or $Path.input -cne $Offer.input -or
                    $Path.context -cne $Offer.context -or $Path.scenarioKind -cne $Offer.scenarioKind) {
                    Add-Finding OracleDrift $Path.pathId
                }
                # DE: Numerische Sollwerte sind zusätzlich an das Ergebnis-unabhängige Quellinventar gebunden.
                # EN: Numeric expectations also bind to the result-independent source inventory.
                $Number = 0.0
                $NumericOracle = if ($Offer.oracle -is [string]) {
                    [double]::TryParse($Offer.oracle, [Globalization.NumberStyles]::Float, [Globalization.CultureInfo]::InvariantCulture, [ref]$Number)
                }
                elseif ($Offer.oracle -is [ValueType] -and $Offer.oracle -isnot [bool]) { $Number = [double]$Offer.oracle; $true }
                else { $false }
                if ($Offer.family -in @('OP', 'REF', 'FUNC-LEGACY', 'FUNC-EXT') -and
                    $NumericOracle) {
                    if (-not (Same-Observation @{value=$Number} $Path.expectedState $Path.pathId)) {
                        Add-Finding OracleDrift $Path.pathId
                    }
                }
            }
            foreach ($Platform in $Capability.platforms) {
                if ($Active -and $Path.automatable) { $null = $Required.Add("$($Capability.id)|$($Path.pathId)|$Platform|$($Path.scenarioKind)") }
            }
        }
    }
    foreach ($Id in $Offers.Keys) { if (-not $Paths.ContainsKey($Id)) { Add-Finding MissingObligation $Id } }
    foreach ($Family in $Baseline.families) {
        if ($Family -notin @($Capabilities.Values | ForEach-Object { $_.family })) { Add-Finding MissingObligation $Family }
    }
    foreach ($N in 1..17) {
        $Id = 'FR-{0:000}' -f $N
        if ($Id -notin $Contract.requirements.id) { Add-Finding MissingObligation $Id }
    }
    foreach ($N in 1..6) {
        $Id = 'SC-{0:000}' -f $N
        if ($Id -notin $Contract.acceptanceCriteria) { Add-Finding MissingObligation $Id }
    }
    $Seen = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    $SeenRuns = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
    foreach ($Bundle in $Bundles) {
        if (-not $SeenRuns.Add($Bundle.runId)) { Add-Finding DuplicateResult 'runId' }
        if ($Bundle.commit -cne $Binding.commit) { Add-Finding StaleCommit $Bundle.platform }
        if ($Bundle.workingTreeDigest -cne $Binding.workingTreeDigest) { Add-Finding StaleWorkingTree $Bundle.platform }
        $PayloadDigest = if ($Binding.Contains('payloadDigests')) { $Binding.payloadDigests[$Bundle.runId] }
            else { Get-TuiCanonicalDigest ($Bundle | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest }
        if ($Bundle.contractDigest -cne $Binding.contractDigest -or $Bundle.pinDecisionDigest -cne $Binding.pinDecisionDigest -or
            $PayloadDigest -cne $Bundle.payloadDigest) {
            Add-Finding DigestMismatch $Bundle.platform
        }
        if ($Bundle.exitCode -ne 0) { Add-Finding RunFailure $Bundle.platform }
        $RunStart = Read-Time $Bundle.startedAt; $RunEnd = Read-Time $Bundle.finishedAt
        # DE: Ein Plattformbundle enthält viele isolierte Sitzungen, nicht eine einzige 180-Sekunden-Sitzung.
        # EN: A platform bundle contains many isolated sessions, not one single 180-second session.
        # DE: Adapter begrenzen jede Sitzung auf 180 Sekunden; jede gebundene Pfadausführung unten auf 30.
        # EN: Adapters bound each session to 180 seconds; each bound path execution below remains limited to 30.
        if ($null -eq $RunStart -or $null -eq $RunEnd -or $RunEnd -lt $RunStart) {
            Add-Finding InvalidTiming $Bundle.platform
        }
        foreach ($Result in $Bundle.results) {
            $Tuple = "$($Result.capabilityId)|$($Result.pathId)|$($Bundle.platform)|$($Result.scenarioKind)"
            if (-not $Required.Contains($Tuple)) { Add-Finding UnknownResult $Result.pathId; continue }
            if (-not $Paths.ContainsKey($Result.pathId)) { Add-Finding MissingObligation $Result.pathId; continue }
            $Path = $Paths[$Result.pathId].path
            if ($Result.kind -ne 'Automated') { Add-Finding WrongEvidenceKind $Result.pathId; continue }
            if (-not $Seen.Add($Tuple)) { Add-Finding DuplicateResult $Result.pathId }
            if ($Result.outcome -ne 'Pass') { Add-Finding UnexecutedObligation $Result.pathId }
            if ($Result.testRef -cnotin $Path.testRefs) { Add-Finding TestReferenceMismatch $Result.pathId }
            if ([string]::IsNullOrWhiteSpace($Result.assertionProofRef) -or $Result.artifactRefs.Count -eq 0) {
                Add-Finding MissingProof $Result.pathId
            }
            $Start = Read-Time $Result.startedAt; $End = Read-Time $Result.finishedAt
            if ($null -eq $Start -or $null -eq $End -or $null -eq $RunStart -or $null -eq $RunEnd -or
                $End -lt $Start -or $Start -lt $RunStart -or $End -gt $RunEnd -or ($End - $Start).TotalSeconds -gt 30) {
                Add-Finding InvalidTiming $Result.pathId
            }
            if ($Result.assertions.Count -eq 0) { Add-Finding MissingAssertions $Result.pathId; continue }
            $Expected = @{}; $Observed = @{}
            $AssertionIds = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
            foreach ($Assertion in $Result.assertions) {
                if (-not $AssertionIds.Add($Assertion.id)) { Add-Finding DuplicateAssertion $Result.pathId }
                if ($Assertion.passed -ne $true -or -not (Same-Observation $Assertion.expected $Assertion.actual $Result.pathId)) {
                    Add-Finding FailedAssertion $Result.pathId
                }
                $TypedKeys = @($Assertion.expected.Keys | Where-Object { $_ -notin @('descriptionDe', 'descriptionEn') })
                if ($TypedKeys.Count -eq 0) { Add-Finding MissingObservation $Result.pathId }
                foreach ($Key in $TypedKeys) {
                    if ($Expected.ContainsKey($Key) -and -not (Same-Observation @{ $Key = $Expected[$Key] } @{ $Key = $Assertion.expected[$Key] } $Result.pathId)) {
                        Add-Finding OracleDrift $Result.pathId
                    }
                    $Expected[$Key] = $Assertion.expected[$Key]
                    if ($Observed.ContainsKey($Key) -and (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Observed[$Key] -Depth 40)) -cne
                        (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Assertion.actual[$Key] -Depth 40))) { Add-Finding FailedAssertion $Result.pathId }
                    if ($Assertion.actual.Contains($Key)) { $Observed[$Key] = $Assertion.actual[$Key] }
                }
            }
            # DE: Jede zusätzliche echte Assertion muss im Gesamtzustand erhalten bleiben, nicht nur das Minimalorakel.
            # EN: Preserve every additional real assertion in the merged state, not only the minimum contract oracle.
            foreach ($Key in $Observed.Keys) {
                if (-not $Result.observedState.Contains($Key)) { Add-Finding MissingObservation $Result.pathId }
                elseif ((Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Observed[$Key] -Depth 40)) -cne
                    (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Result.observedState[$Key] -Depth 40))) { Add-Finding FailedAssertion $Result.pathId }
            }
            $RequiredState = @{ focus = $Path.focusAfter }
            foreach ($Key in $Path.expectedState.Keys) {
                if ($Key -notin @('descriptionDe', 'descriptionEn')) { $RequiredState[$Key] = $Path.expectedState[$Key] }
            }
            if (-not (Same-Observation $RequiredState $Expected $Result.pathId)) { Add-Finding OracleDrift $Result.pathId }
            if (-not (Same-Observation $RequiredState $Result.observedState $Result.pathId)) { Add-Finding FailedAssertion $Result.pathId }
        }
    }
    foreach ($Tuple in $Required) { if (-not $Seen.Contains($Tuple)) { Add-Finding MissingResult $Tuple } }
    return @($Findings | Sort-Object code, sourceRef -Unique)
}
