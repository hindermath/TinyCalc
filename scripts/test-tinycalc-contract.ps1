<#
.SYNOPSIS
DE: Prüft den vollständigen TUI-Vertrag ausschließlich lesend.
EN: Validates the complete TUI contract without writes.
.DESCRIPTION
DE: Keine Installation, Tests, Produktstarts oder Provideraktionen. Exit 0 bestätigt
nur gültige gebundene Nachweise, keine Produktabnahme oder Lieferfreigabe.
EN: Never installs, tests, starts the product or contacts a provider. Exit zero
confirms valid bound evidence, not product acceptance or delivery authority.
.PARAMETER RepositoryRoot
DE: Explizite Repository-Lesewurzel. EN: Explicit repository read boundary.
.PARAMETER Contract
DE: Vertragsdatei innerhalb erlaubter Wurzeln. EN: Contract file within allowed roots.
.PARAMETER SourceMap
DE: Zuordnung der geprüften Quellangebote. EN: Mapping of reviewed source offers.
.PARAMETER Evidence
DE: Verzeichnis gebundener Bundles und Gate-Proofs. EN: Bound bundle and gate-proof directory.
.PARAMETER PinDecision
DE: Paketentscheidung mit Freigabe-/Vergleichsbindung. EN: Package decision with approval/comparison binding.
.PARAMETER ImpactDecision
DE: Änderungsentscheidung; Pflichtgates bleiben erhalten. EN: Change decision; mandatory gates remain required.
.PARAMETER EvidenceRoot
DE: Zusätzliche ausdrücklich erlaubte Lesewurzel. EN: Additional explicitly allowed read boundary.
.PARAMETER GateEvidence
DE: Relativer Gate-Dateiname im Evidenzverzeichnis. EN: Relative gate filename in the evidence directory.
.PARAMETER Json
DE: Maschinenlesbare Ausgabe ohne Farben. EN: Machine-readable output without colours.
.EXAMPLE
./scripts/test-tinycalc-contract.ps1 -RepositoryRoot . -Evidence tests/results -Json -WhatIf
#>
#Requires -Version 7
[CmdletBinding(SupportsShouldProcess)]
param(
    [string]$RepositoryRoot = (Join-Path $PSScriptRoot '..'),
    [string]$Contract = 'docs/contracts/tui/product-contract.json',
    [string]$SourceMap = 'docs/contracts/tui/source-map.json',
    [string]$Evidence = 'specs/006-tui-functional-contract/evidence/runs',
    [string]$PinDecision = 'specs/006-tui-functional-contract/evidence/pin-decision.json',
    [string]$ImpactDecision = 'specs/006-tui-functional-contract/evidence/impact-decision.json',
    [string]$EvidenceRoot = '',
    [string]$GateEvidence = 'gate-proofs.json',
    [switch]$Json
)
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
. (Join-Path $PSScriptRoot 'lib/tui-contract/CanonicalJson.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/SafeInputs.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/Semantics.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/Decisions.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/Catalog.ps1')
. (Join-Path $PSScriptRoot 'lib/tui-contract/Execution.ps1')

<#
.SYNOPSIS
DE: Vollständige lesende Prüfung ohne Freigabe- oder Schreibwirkung.
EN: Complete read-only validation without approval or write effects.
.PARAMETER RepositoryRoot
DE: Explizite Repository-Lesewurzel. EN: Explicit repository read boundary.
.PARAMETER Contract
DE: Vertragsdatei innerhalb erlaubter Wurzeln. EN: Contract file within allowed roots.
.PARAMETER SourceMap
DE: Zuordnung der geprüften Quellangebote. EN: Mapping of reviewed source offers.
.PARAMETER Evidence
DE: Verzeichnis gebundener Bundles und Gate-Proofs. EN: Bound bundle and gate-proof directory.
.PARAMETER PinDecision
DE: Paketentscheidung mit Freigabe-/Vergleichsbindung. EN: Package decision with approval/comparison binding.
.PARAMETER ImpactDecision
DE: Änderungsentscheidung; Pflichtgates bleiben erhalten. EN: Change decision; mandatory gates remain required.
.PARAMETER EvidenceRoot
DE: Zusätzliche ausdrücklich erlaubte Lesewurzel. EN: Additional explicitly allowed read boundary.
.PARAMETER GateEvidence
DE: Relativer Gate-Dateiname im Evidenzverzeichnis. EN: Relative gate filename in the evidence directory.
.EXAMPLE
Test-TinyCalcContract -RepositoryRoot . -Evidence tests/results -WhatIf
#>
function Test-TinyCalcContract {
    [CmdletBinding(SupportsShouldProcess)]
    param(
        [Parameter(Mandatory)][string]$RepositoryRoot,
        [string]$Contract = 'docs/contracts/tui/product-contract.json',
        [string]$SourceMap = 'docs/contracts/tui/source-map.json',
        [string]$Evidence = 'specs/006-tui-functional-contract/evidence/runs',
        [string]$PinDecision = 'specs/006-tui-functional-contract/evidence/pin-decision.json',
        [string]$ImpactDecision = 'specs/006-tui-functional-contract/evidence/impact-decision.json',
        [string]$EvidenceRoot = '',
        [string]$GateEvidence = 'gate-proofs.json'
    )
    $Findings = [Collections.Generic.List[object]]::new()
    $Digests = [ordered]@{}
    $Gates = @('FullFunctionalLinuxWindows')
    $Counts = [ordered]@{ families = 0; requiredPaths = 0; requiredTuples = 0; observedTuples = 0; platforms = 0 }
    $ExitCode = 0
    $InputJson = @{}
    function Add-InputFinding([string]$Code, [string]$Ref) {
        $Findings.Add([pscustomobject]@{ code = $Code; sourceRef = $Ref })
    }
    # DE: Befunde enthalten nur relative logische Referenzen, nie Eingaben/Exceptions mit privaten Pfaden.
    # EN: Findings expose only relative logical references, never raw inputs or exceptions with private paths.
    function Read-Input([string]$Path, [string]$SchemaName = '') {
        $Safe = Resolve-TuiInputPath -Path $Path -RepositoryRoot $Root -EvidenceRoot $EvidenceRoot
        $Schema = if ($SchemaName) { Join-Path $Root "docs/contracts/tui/$SchemaName.schema.json" } else { '' }
        $InputJson[$Path] = [IO.File]::ReadAllText($Safe, [Text.UTF8Encoding]::new($false, $true))
        return Read-TuiJsonInput -Path $Safe -SchemaPath $Schema
    }
    function Check-Artifact($Reference) {
        if ($Reference -is [Collections.IDictionary]) { $Reference = $Reference.path + '#sha256=' + $Reference.sha256 }
        if ($Reference -isnot [string]) { throw 'InvalidArtifactReference' }
        $Parts = $Reference -split '#sha256=', 2
        if ($Parts.Count -ne 2 -or $Parts[1] -cnotmatch '^[a-f0-9]{64}$') { throw 'InvalidArtifactReference' }
        $Path = Resolve-TuiInputPath -Path $Parts[0] -RepositoryRoot $Root -EvidenceRoot $EvidenceRoot -RelativeOnly
        if ((Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant() -cne $Parts[1]) { throw 'ArtifactDigestMismatch' }
        return $Path
    }
    try {
        $Root = [IO.Path]::GetFullPath($RepositoryRoot)
        $Head = @(& git -C $Root rev-parse HEAD 2>$null)
        if ($LASTEXITCODE -ne 0 -or $Head.Count -ne 1 -or $Head[0] -cnotmatch '^[a-f0-9]{40}$') { throw 'InvalidRepository' }
        $C = Read-Input $Contract contract-revision
        $S = Read-Input $SourceMap
        $P = Read-Input $PinDecision pin-decision
        $I = Read-Input $ImpactDecision impact-decision
        $B = Read-Input 'docs/contracts/tui/baseline-inventory.json'
        $Active = @($C.capabilities | Where-Object { $_.mandatory -and $_.status -in @('Active','Deprecated') })
        $Counts.families = @($Active.family | Sort-Object -Unique).Count
        $Counts.requiredPaths = @($Active.paths).Count
        $Counts.requiredTuples = [int](($Active | ForEach-Object { $Cap=$_; @($Cap.paths | Where-Object automatable).Count * $Cap.platforms.Count } | Measure-Object -Sum).Sum)
        $Digests.contract = Get-TuiCanonicalDigest $InputJson[$Contract]
        $Digests.baseline = Get-TuiCanonicalDigest $InputJson['docs/contracts/tui/baseline-inventory.json']
        $Digests.sourceMap = Get-TuiCanonicalDigest $InputJson[$SourceMap]
        $Digests.pin = Get-TuiCanonicalDigest $InputJson[$PinDecision] -ExcludeRootProperty decisionDigest
        $Digests.impact = Get-TuiCanonicalDigest $InputJson[$ImpactDecision] -ExcludeRootProperty decisionDigest
        $Digests.workingTree = Get-TuiWorkingTreeDigest $Root
        $Digests.commit = $Head[0]
        if ($C.baselineDigest -cne $Digests.baseline -or $C.sourceMapDigest -cne $Digests.sourceMap -or
            $P.decisionDigest -cne $Digests.pin -or $I.decisionDigest -cne $Digests.impact) { Add-InputFinding DigestMismatch 'input-bindings' }
        $Intake = Resolve-TuiInputPath -Path 'requirements/intakes/active/Lastenheft_TUI-Funktionsabnahme-und-Regressionsvertrag.md' -RepositoryRoot $Root -RelativeOnly
        $Spec = Resolve-TuiInputPath -Path $B.semanticsRef -RepositoryRoot $Root -RelativeOnly
        if ($C.intakeHash -cne $B.intakeHash -or $C.intakeHash -cne (Get-FileHash $Intake).Hash.ToLowerInvariant() -or
            $B.semanticsHash -cne (Get-FileHash $Spec).Hash.ToLowerInvariant()) { Add-InputFinding SourceDrift 'binding-intake-spec' }
        foreach ($Key in $S.Keys) { if ($Key -notin @('schemaVersion','revision','mappings','defects','decisions','unresolvedFindings')) { throw 'InvalidSchema' } }
        if ($S.schemaVersion -ne '1.0' -or $S.unresolvedFindings.Count) { Add-InputFinding SourceDrift 'source-map' }
        foreach ($Mapping in $S.mappings) {
            if (-not (Test-Json -Json ($Mapping | ConvertTo-Json -Depth 15) -SchemaFile (Join-Path $Root 'docs/contracts/tui/source-mapping.schema.json') -ErrorAction SilentlyContinue)) { throw 'InvalidSchema' }
            $Path = Resolve-TuiInputPath -Path $Mapping.sourcePath -RepositoryRoot $Root -RelativeOnly
            if ((Get-FileHash $Path).Hash.ToLowerInvariant() -cne $Mapping.sourceHash -or
                -not [IO.File]::ReadAllText($Path).Contains($Mapping.anchor, [StringComparison]::Ordinal)) {
                Add-InputFinding SourceDrift $Mapping.sourcePath
            }
            foreach ($Id in $Mapping.capabilityRefs) { if ($Id -cnotin $C.capabilities.id) { Add-InputFinding MissingObligation 'source-map-reference' } }
        }
        $Graph = Get-TuiResolvedPinGraph $Root $P
        $null = Resolve-TuiInputPath -Path $P.approvalRef -RepositoryRoot $Root -EvidenceRoot $EvidenceRoot -RelativeOnly
        $Approval = Read-Input $P.approvalRef pin-approval
        $null = Check-Artifact $Approval.approvalRef
        $Comparison = $null
        if ($P.comparisonEvidence) {
            if ([IO.Path]::IsPathRooted($P.comparisonEvidence) -or '..' -in ($P.comparisonEvidence -split '[/\\]')) { throw 'UnsafePath' }
            if (Test-Path -LiteralPath (Join-Path $Root $P.comparisonEvidence) -PathType Leaf) {
                $Comparison = Read-Input $P.comparisonEvidence pin-comparison
                $null = Check-Artifact $Comparison.artifactRef
                $Comparison.artifactVerified = $true
            }
        }
        $PinPolicy = Get-TuiPinPolicy $P $Graph $Approval $Comparison
        $ImpactPolicy = Get-TuiImpactPolicy $I $PinPolicy.state
        $Gates = @(@($PinPolicy.requiredGates) + @($ImpactPolicy.requiredGates) + @($P.requiredGates) + @($I.requiredGates) | Sort-Object -Unique)
        if ($PinPolicy.state -eq 'Blocked') { throw 'BlockedPreflight' }
        if ($P.state -cne $PinPolicy.state) { Add-InputFinding PinStateMismatch 'pin-decision' }
        $History = Read-Input 'docs/contracts/tui/history.json' contract-history
        $HistoricalJson = @(& git -C $Root show ($History.commit + ':docs/contracts/tui/product-contract.json') 2>$null) -join "`n"
        if ($LASTEXITCODE -ne 0 -or (Get-TuiCanonicalDigest $HistoricalJson) -cne $History.contractDigest) { throw 'InvalidHistory' }
        $Previous = ConvertFrom-Json -AsHashtable -InputObject $HistoricalJson
        $Authorities = @()
        foreach ($Authority in $History.authorities) {
            $null = Check-Artifact $Authority.approvalRef
            $Authority.approvalVerified = $true
            $Authorities += $Authority
        }
        $Additions=@()
        if($History.Contains('additions')){
            foreach($Addition in $History.additions){
                $RedPath=Check-Artifact $Addition.redExecutionRef
                $TestSourcePath=Check-Artifact $Addition.testSourceRef
                $Addition.proofVerified=Test-TuiAdditionExecutionProof $Root $History.commit $Addition $RedPath $TestSourcePath
                $Additions+=$Addition
            }
        }
        foreach ($Finding in @(Test-TuiContractHistory $Previous $C $Authorities $Additions)) { $Findings.Add($Finding) }
        foreach ($Finding in @(Test-TuiSourceOffers $B $C $S)) { $Findings.Add($Finding) }
        $CatalogPath = Resolve-TuiInputPath -Path 'docs/contracts/tui/catalog.md' -RepositoryRoot $Root -RelativeOnly
        if ([IO.File]::ReadAllText($CatalogPath) -cne (Get-TuiContractCatalog $C)) { Add-InputFinding CatalogDrift 'docs/contracts/tui/catalog.md' }
        if ($Findings.Count) { throw 'ContractPreflightViolation' }
        $EvidencePath = Resolve-TuiInputPath -Path $Evidence -RepositoryRoot $Root -EvidenceRoot $EvidenceRoot
        if (-not (Get-Item $EvidencePath).PSIsContainer) { throw 'InvalidEvidenceDirectory' }
        $PayloadDigests = @{}
        $Bundles = @(Get-ChildItem -LiteralPath $EvidencePath -File -Filter '*.bundle.json' | Sort-Object Name | ForEach-Object {
            $Safe = Resolve-TuiInputPath -Path $_.FullName -RepositoryRoot $Root -EvidenceRoot $EvidenceRoot
            $Bundle = Read-TuiJsonInput $Safe (Join-Path $Root 'docs/contracts/tui/evidence-bundle.schema.json')
            $PayloadDigests[$Bundle.runId] = Get-TuiCanonicalDigest ([IO.File]::ReadAllText($Safe)) -ExcludeRootProperty payloadDigest
            $Bundle
        })
        $Binding = @{ commit = $Head[0]; workingTreeDigest = $Digests.workingTree; contractDigest = $Digests.contract; pinDecisionDigest = $Digests.pin; payloadDigests = $PayloadDigests }
        foreach ($Finding in @(Test-TuiEvidenceModel -Baseline $B -Contract $C -Bundles $Bundles -Binding $Binding)) { $Findings.Add($Finding) }
        foreach ($Bundle in $Bundles) {
            $ExecutionPath = Check-Artifact $Bundle.executionProofRef
            $Executions = @(Read-TuiTrxExecution $ExecutionPath)
            foreach ($Result in $Bundle.results) {
                $ExecutionFailure = Test-TuiExecutedResult $Result $Executions
                if ($ExecutionFailure) { Add-InputFinding $ExecutionFailure $Result.pathId }
                $ProofPath = Check-Artifact $Result.assertionProofRef
                $Proof = Read-TuiJsonInput $ProofPath
                foreach ($Key in @('capabilityId','pathId','scenarioKind','testRef','startedAt','finishedAt','assertions')) {
                    if (-not $Proof.Contains($Key) -or (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Proof[$Key] -Depth 40)) -cne
                        (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Result[$Key] -Depth 40))) { Add-InputFinding AssertionProofMismatch $Result.pathId }
                }
                foreach ($Artifact in $Result.artifactRefs) { $null = Check-Artifact $Artifact }
                $TestFile = ($Result.testRef -split '#', 2)[0]
                $TestPath = Resolve-TuiInputPath -Path $TestFile -RepositoryRoot $Root -RelativeOnly
                if (-not [IO.File]::ReadAllText($TestPath).Contains('Assert.', [StringComparison]::Ordinal)) { Add-InputFinding TestWeakening $Result.pathId }
            }
        }
        if ([IO.Path]::IsPathRooted($GateEvidence) -or '..' -in ($GateEvidence -split '[/\\]')) { throw 'UnsafePath' }
        $GatePath = Join-Path $EvidencePath $GateEvidence
        $Proofs = Read-Input $GatePath gate-proofs
        foreach ($Key in @('commit','workingTreeDigest','contractDigest','pinDecisionDigest')) {
            if ($Proofs[$Key] -cne $Binding[$Key]) { Add-InputFinding GateBindingMismatch 'gate-proofs' }
        }
        if ($Proofs.impactDecisionDigest -cne $Digests.impact -or
            (Get-TuiCanonicalDigest $InputJson[$GatePath] -ExcludeRootProperty payloadDigest) -cne $Proofs.payloadDigest) { Add-InputFinding DigestMismatch 'gate-proofs' }
        $SeenGates = [Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal)
        foreach ($Gate in $Proofs.gates) {
            if (-not $SeenGates.Add($Gate.id)) { Add-InputFinding DuplicateResult 'gate-proofs' }
            if ($Gate.outcome -ne 'Pass') { Add-InputFinding UnexecutedGate $Gate.id }
            if ($Gate.id -match 'Human|VoiceOver' -and $Gate.kind -ne 'HumanSupplement') { Add-InputFinding WrongEvidenceKind $Gate.id }
            if ($Gate.id -match 'SecurityReview|ArchitectureReview' -and $Gate.kind -ne 'IndependentReview') { Add-InputFinding WrongEvidenceKind $Gate.id }
            foreach ($Artifact in $Gate.artifactRefs) { $null = Check-Artifact $Artifact }
        }
        foreach ($Gate in $Gates) { if (-not $SeenGates.Contains($Gate)) { Add-InputFinding MissingGate $Gate } }
        $Active = @($C.capabilities | Where-Object { $_.mandatory -and $_.status -in @('Active','Deprecated') })
        $Counts.families = @($Active.family | Sort-Object -Unique).Count
        $Counts.requiredPaths = @($Active.paths).Count
        $Counts.requiredTuples = [int](($Active | ForEach-Object { $Cap=$_; @($Cap.paths | Where-Object automatable).Count * $Cap.platforms.Count } | Measure-Object -Sum).Sum)
        $Counts.observedTuples = @($Bundles.results | Where-Object kind -eq Automated).Count
        $Counts.platforms = @($Bundles.platform | Sort-Object -Unique).Count
        if ($Findings.Count) { $ExitCode = 1 }
    }
    catch {
        $Code = [string]$_.Exception.Message
        if ($Code -ceq 'ContractPreflightViolation') { $ExitCode = 1 }
        else {
            if ($Code -notin @('UnsafePath','InvalidInputSize','InvalidSchema','InvalidRepository','InvalidHistory','BlockedPreflight','InvalidEvidenceDirectory','InvalidArtifactReference','ArtifactDigestMismatch')) { $Code = 'InvalidInput' }
            $Findings.Add([pscustomobject]@{ code = $Code; sourceRef = 'inputs' })
            $ExitCode = 2
        }
    }
    # DE: Auch schema-valide IDs können fremden Text tragen. Die Ausgabe erlaubt deshalb nur
    # logische IDs/Tupel und relative Repo-Referenzen, keine ungeprüften Diagnosetexte.
    # EN: Even schema-valid IDs can carry hostile text. Output therefore permits only logical
    # IDs/tuples and relative repository references, never unchecked diagnostic text.
    $PublicFindings = foreach ($Finding in $Findings) {
        $Ref = [string]$Finding.sourceRef
        $Logical = $Ref -cmatch '^[A-Za-z0-9_.:-]+(?:\|[A-Za-z0-9_.:-]+)*$' -and $Ref -notmatch '^[A-Za-z]:'
        $Relative = $Ref -cmatch '^(?:docs|src|tests|scripts|requirements|specs)/[A-Za-z0-9_./-]+$' -and '..' -notin ($Ref -split '/')
        if ($Ref.Length -gt 512 -or (-not $Logical -and -not $Relative)) { $Ref = 'inputs' }
        [pscustomobject]@{ code = $Finding.code; sourceRef = $Ref }
    }
    $PublicGates = foreach ($Gate in $Gates) {
        if ($Gate.Length -le 128 -and $Gate -cmatch '^[A-Za-z][A-Za-z0-9]+$') { $Gate }
        else { 'InvalidGateReference' }
    }
    return [pscustomobject][ordered]@{
        status = if ($ExitCode -eq 0) { 'Valid' } elseif ($ExitCode -eq 1) { 'Violation' } else { 'Blocked' }
        exitCode = $ExitCode; findings = @($PublicFindings | Sort-Object code, sourceRef -Unique)
        requiredGates = @($PublicGates | Sort-Object -Unique); counts = $Counts; inputDigests = $Digests
    }
}

if ($MyInvocation.InvocationName -ne '.') {
    $Parameters = @{}
    foreach ($Name in @('RepositoryRoot','Contract','SourceMap','Evidence','PinDecision','ImpactDecision','EvidenceRoot','GateEvidence')) { $Parameters[$Name] = Get-Variable -Name $Name -ValueOnly }
    $Result = Test-TinyCalcContract @Parameters -WhatIf:$WhatIfPreference
    if ($Json) { $Result | ConvertTo-Json -Depth 12 -Compress }
    else {
        Write-Output "TUI-Vertrag / TUI contract: $($Result.status); Exit $($Result.exitCode)"
        foreach ($Finding in $Result.findings) { Write-Output "$($Finding.code): $($Finding.sourceRef)" }
        Write-Output "Pflichttupel / Required tuples: $($Result.counts.requiredTuples); beobachtet / observed: $($Result.counts.observedTuples)"
        Write-Output 'Gültig ist keine Abnahme oder Lieferfreigabe. / Valid does not mean accepted or authorised for delivery.'
    }
    exit $Result.exitCode
}
