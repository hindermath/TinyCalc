#Requires -Version 7
# DE: Ausschließlich synthetische Validator-Fixtures, niemals Produkt- oder Plattformnachweise.
# EN: Synthetic validator fixtures only, never product or platform evidence.
Set-StrictMode -Version Latest
function Copy-Model($Value) { ConvertFrom-Json -AsHashtable -InputObject (ConvertTo-Json -InputObject $Value -Depth 80) }
function New-Model {
    $Baseline = Get-Content (Join-Path $Root 'docs/contracts/tui/baseline-inventory.json') -Raw | ConvertFrom-Json -AsHashtable
    $Contract = Get-Content (Join-Path $Root 'docs/contracts/tui/product-contract.json') -Raw | ConvertFrom-Json -AsHashtable
    $ContractDigest = Get-TuiCanonicalDigest ($Contract | ConvertTo-Json -Depth 80)
    $Binding = @{ commit = ('c' * 40); workingTreeDigest = ('d' * 64); contractDigest = $ContractDigest; pinDecisionDigest = ('e' * 64) }
    $Bundles = foreach ($Platform in @('linux', 'windows', 'macos')) {
        $Results = foreach ($Capability in $Contract.capabilities) {
            foreach ($Path in $Capability.paths) {
                $Expected = @{}
                foreach ($Key in $Path.expectedState.Keys) {
                    if ($Key -notin @('descriptionDe', 'descriptionEn')) { $Expected[$Key] = $Path.expectedState[$Key] }
                }
                $Expected.focus = $Path.focusAfter
                @{ capabilityId = $Capability.id; pathId = $Path.pathId; scenarioKind = $Path.scenarioKind
                   kind = 'Automated'; outcome = 'Pass'; testRef = $Path.testRefs[0]; assertionProofRef = 'fixture-only/assertions.json'
                   assertions = @(@{ id = 'synthetic-observation'; expected = $Expected; actual = Copy-Model $Expected; passed = $true })
                   startedAt = '2026-10-10T10:00:01Z'; finishedAt = '2026-10-10T10:00:02Z'
                   observedState = Copy-Model $Expected; artifactRefs = @('fixture-only/raw-trace.txt') }
            }
        }
        $Bundle = @{ schemaVersion = '1.0'; runId = [Guid]::NewGuid().ToString(); commit = $Binding.commit
            workingTreeDigest = $Binding.workingTreeDigest; contractDigest = $Binding.contractDigest
            pinDecisionDigest = $Binding.pinDecisionDigest; platform = $Platform
            runner = 'synthetic-fixture-not-native-proof'; job = 'isolated-validator-fixture'; command = 'fixture data, never executed'
            toolVersions = @{ fixture = '1' }; startedAt = '2026-10-10T10:00:00Z'; finishedAt = '2026-10-10T10:00:03Z'
            exitCode = 0; results = @($Results) }
        $Bundle.payloadDigest = Get-TuiCanonicalDigest ($Bundle | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
        $Bundle
    }
    return @{ Baseline = $Baseline; Contract = $Contract; Bundles = @($Bundles); Binding = $Binding }
}

# DE: Nur der Fehler unter Test bleibt stale; andere Bindungen werden nach Mutationen kohärent gesetzt.
# EN: Keep only the defect under test stale; refresh unrelated bindings after each mutation.
function Update-Model($Model) {
    $Model.Binding.contractDigest = Get-TuiCanonicalDigest ($Model.Contract | ConvertTo-Json -Depth 80)
    foreach ($Bundle in $Model.Bundles) {
        $Bundle.contractDigest = $Model.Binding.contractDigest
        $Bundle.payloadDigest = Get-TuiCanonicalDigest ($Bundle | ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
    }
}
