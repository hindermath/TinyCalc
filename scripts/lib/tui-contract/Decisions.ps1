#Requires -Version 7
Set-StrictMode -Version Latest

# DE: Nur Paketdeklarationen und Lockbytes bilden den Graph; UI-Dateien erteilen keine Paketfreigabe.
# EN: Only package declarations and lock bytes form the graph; UI files cannot grant package approval.
function Get-TuiResolvedPinGraph {
    param([string]$RepositoryRoot, $Decision)
    $Projects=@('src/MicroCalc.Core/MicroCalc.Core.csproj','src/MicroCalc.Tui/MicroCalc.Tui.csproj',
        'tests/MicroCalc.Core.Tests/MicroCalc.Core.Tests.csproj','tests/MicroCalc.Tui.Tests/MicroCalc.Tui.Tests.csproj')
    $Graph=@{dependency=$Decision.dependency;resolvedVersion='';declarations=@();locks=@();references=@();sourceRefs=@($Decision.sourceRefs);coherent=$true}
    if($Decision.dependency -cne 'Terminal.Gui' -or @($Decision.declarationRefs).Count -ne 4 -or @($Decision.lockRefs).Count -ne 4){$Graph.coherent=$false}
    foreach($Project in $Projects) {
        if($Project -cnotin $Decision.declarationRefs){$Graph.coherent=$false}
        $Path=Resolve-TuiInputPath -Path $Project -RepositoryRoot $RepositoryRoot -RelativeOnly
        $Settings=[Xml.XmlReaderSettings]::new();$Settings.DtdProcessing=[Xml.DtdProcessing]::Prohibit;$Settings.XmlResolver=$null
        $Reader=[Xml.XmlReader]::Create($Path,$Settings)
        try{$Xml=[Xml.XmlDocument]::new();$Xml.XmlResolver=$null;$Xml.Load($Reader)}finally{$Reader.Dispose()}
        $Graph.declarations+=$Project
        $LockPath=([IO.Path]::GetDirectoryName($Project).Replace('\','/')+'/packages.lock.json')
        $Lock=Read-TuiJsonInput (Resolve-TuiInputPath -Path $LockPath -RepositoryRoot $RepositoryRoot -RelativeOnly)
        $Hash=(Get-FileHash (Join-Path $RepositoryRoot $LockPath)).Hash.ToLowerInvariant()
        $Graph.locks+=($LockPath+'|'+$Hash)
        $Expected=@($Decision.lockRefs | Where-Object { $_.path -ceq $LockPath })
        if($Expected.Count -ne 1 -or $Expected[0].sha256 -cne $Hash){$Graph.coherent=$false}
        foreach($Reference in $Xml.SelectNodes('//PackageReference')) {
            $Name=$Reference.GetAttribute('Include');$Version=$Reference.GetAttribute('Version')
            if(-not $Name -or $Version -notmatch '^\d+\.\d+\.\d+(?:-[0-9A-Za-z.-]+)?$'){$Graph.coherent=$false}
            $Graph.references+=($Project+'|'+$Name+'|'+$Version)
            foreach($Target in $Lock.dependencies.Values) {
                if(-not $Target.Contains($Name) -or $Target[$Name].resolved -cne $Version){$Graph.coherent=$false}
                if($Name -ceq 'Terminal.Gui') {
                    if($Graph.resolvedVersion -and $Graph.resolvedVersion -cne $Version){$Graph.coherent=$false}
                    $Graph.resolvedVersion=$Version
                }
            }
        }
    }
    if(-not $Graph.resolvedVersion){$Graph.coherent=$false}
    $Graph.references=@($Graph.references | Sort-Object)
    return $Graph
}

function Get-TuiPinPolicy {
    param($Decision, $Current, $Approval, $Comparison)
    $State = 'Blocked'
    $Gates = @('FullFunctionalLinuxWindows')
    $Digest = Get-TuiCanonicalDigest ($Current | ConvertTo-Json -Depth 60)
    $Valid = $null -ne $Approval -and $Current.coherent -and
        $Current.declarations.Count -eq 4 -and $Current.locks.Count -eq 4 -and
        @($Current.declarations | Sort-Object -Unique).Count -eq 4 -and
        @($Current.locks | Sort-Object -Unique).Count -eq 4 -and
        $Current.sourceRefs.Count -gt 0 -and $Approval.approvalRef -and
        $Decision.resolvedVersion -ceq $Current.resolvedVersion -and
        (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Decision.sourceRefs -Compress)) -ceq
            (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Current.sourceRefs -Compress)) -and
        $Approval.graphDigest -ceq $Digest
    if ($Valid) {
        # DE: Ein gleiches Versionslabel reicht nicht: Paketgraph, Freigabe und belegter Vergleich müssen passen.
        # EN: A version label is insufficient: graph, approval and verified comparison must all match.
        $ApprovalDigest = Get-TuiCanonicalDigest ($Approval | ConvertTo-Json -Depth 60)
        $Reuse = $null -ne $Comparison -and $Comparison.graphDigest -ceq $Digest -and
            $Comparison.approvalDigest -ceq $ApprovalDigest -and $Comparison.outcome -ceq 'Pass' -and
            $Comparison.artifactVerified -eq $true
        $State = if ($Reuse) { 'AlreadySatisfied' } else { 'Drift' }
    }
    if ($State -ne 'AlreadySatisfied') {
        $Gates += @('MacOsPty80x24','MacOsPty120x40','HumanVoiceOver','LinkedAccessibilityGates','SecurityReview')
    }
    return @{ state=$State; graphDigest=$Digest; requiredGates=$Gates; findings=@() }
}

function Get-TuiImpactPolicy {
    param($Decision, [string]$PinState)
    $Known = @('NoFunctionalImpact','FunctionalImpact','A11yImpact','TestInfrastructureImpact','ReleaseCloseout')
    $Classes = @($Decision.classes)
    if (-not $Classes.Count -or @($Classes | Where-Object { $_ -notin $Known }).Count) {
        $Classes = @('FunctionalImpact','A11yImpact')
    }
    $Major = @($Decision.changedPaths | Where-Object {
        $_ -match '^(src/|CALC\.HLP$|Directory\.Build\.props$|.*packages\.lock\.json$|.*\.(?:csproj|sln)$)' -or
        $_ -match '(?i)(rename|release|docs/help/|docs/contracts/tui/)'
    }).Count -gt 0
    if ($Major -or $PinState -ne 'AlreadySatisfied') { $Classes += @('FunctionalImpact','A11yImpact') }
    $Gates = @('FullFunctionalLinuxWindows','ContractDrift','DocumentationAlignment')
    if (@($Classes | Where-Object { $_ -in @('A11yImpact','TestInfrastructureImpact','ReleaseCloseout') }).Count) {
        $Gates += @('MacOsPty80x24','MacOsPty120x40','HumanVoiceOver','LinkedAccessibilityGates',
            'SecurityReview','ArchitectureReview','ChangedProductCoverage70Percent')
    }
    if ('TestInfrastructureImpact' -in $Classes) { $Gates += 'EvidenceStrength' }
    if ('ReleaseCloseout' -in $Classes -or @($Decision.changedPaths | Where-Object { $_ -match '^(docfx\.json|docs/help/|README\.md$)' }).Count) {
        $Gates += 'DocFxAxeLynx'
    }
    return @{ classes=@($Classes | Sort-Object -Unique); requiredGates=@($Gates | Sort-Object -Unique); findings=@() }
}

function Test-TuiContractHistory {
    param($Previous, $Current, $Authorities = @(), $Additions = @())
    $Findings = [Collections.Generic.List[object]]::new()
    function Add-HistoryFinding([string]$Code,[string]$Id) { $Findings.Add(@{code=$Code;sourceRef=$Id}) }
    function Has-Authority([string]$Id,[string]$Kind,[string]$PathId='') {
        return @($Authorities | Where-Object { $_.kind -eq $Kind -and $Id -cin $_.affectedIds -and $_.approvalVerified -eq $true -and
            (-not $_.Contains('affectedPathIds') -or $PathId -cin $_.affectedPathIds) }).Count -gt 0
    }
    $OldRequirements=@{}
    if($Previous.Contains('requirements')){foreach($Requirement in $Previous.requirements){$OldRequirements[$Requirement.id]=$Requirement}}
    $NewRequirements=@{}
    if($Current.Contains('requirements')){
        foreach($Requirement in $Current.requirements){
            if($NewRequirements.ContainsKey($Requirement.id)){Add-HistoryFinding DuplicateObligation $Requirement.id}
            $NewRequirements[$Requirement.id]=$Requirement
            if($OldRequirements.ContainsKey($Requirement.id)){
                if((Get-TuiCanonicalDigest ($Requirement|ConvertTo-Json -Depth 40)) -cne
                    (Get-TuiCanonicalDigest ($OldRequirements[$Requirement.id]|ConvertTo-Json -Depth 40))){Add-HistoryFinding RecycledIdentity $Requirement.id}
            }else{
                # DE: Neue Pflichten brauchen echte rote Ausführung vor der ersten betroffenen Produktänderung.
                # EN: New obligations need actual red execution before the first affected product change.
                if(@($Additions|Where-Object{$_.requirementId -ceq $Requirement.id -and $_.proofVerified -eq $true}).Count -ne 1){Add-HistoryFinding MissingTestFirstProof $Requirement.id}
            }
        }
    }
    foreach($Id in $OldRequirements.Keys){if(-not $NewRequirements.ContainsKey($Id)){Add-HistoryFinding MissingTombstone $Id}}
    $OldDigest = Get-TuiCanonicalDigest ($Previous | ConvertTo-Json -Depth 80)
    $NewDigest = Get-TuiCanonicalDigest ($Current | ConvertTo-Json -Depth 80)
    if ($Current.revision -lt $Previous.revision -or ($OldDigest -cne $NewDigest -and $Current.revision -le $Previous.revision)) {
        Add-HistoryFinding NonMonotonicRevision 'history'
    }
    $NewCaps = @{}
    foreach($Cap in $Current.capabilities) {
        if($NewCaps.ContainsKey($Cap.id)){Add-HistoryFinding DuplicateObligation $Cap.id}
        $NewCaps[$Cap.id]=$Cap
    }
    foreach($Old in $Previous.capabilities) {
        if(-not $NewCaps.ContainsKey($Old.id)){Add-HistoryFinding MissingTombstone $Old.id;continue}
        $New=$NewCaps[$Old.id]
        if($New.family -cne $Old.family -or ($Old.status -eq 'Retired' -and $New.status -ne 'Retired')) {
            Add-HistoryFinding RecycledIdentity $Old.id
        }
        if($New.status -cne $Old.status) {
            $Kind=if($New.status -eq 'Deprecated'){'Deprecation'}else{'BreakingChange'}
            if(-not (Has-Authority $Old.id $Kind)){Add-HistoryFinding MissingChangeAuthority $Old.id}
        }
        # DE: Deprecation behält Regression; nur autorisiert stillgelegte Tombstones verlassen den aktiven Nenner.
        # EN: Deprecation retains regression; only authorised retired tombstones leave the active denominator.
        $Retired = $New.status -eq 'Retired' -and ($Old.status -eq 'Retired' -or (Has-Authority $Old.id BreakingChange))
        if(-not $Retired -and (($Old.mandatory -and -not $New.mandatory) -or
            @($Old.platforms | Where-Object { $_ -cnotin $New.platforms }).Count)) {Add-HistoryFinding WeakenedHistoricalObligation $Old.id}
        $NewPaths=@{}
        foreach($Path in $New.paths){$NewPaths[$Path.pathId]=$Path}
        foreach($OldPath in $Old.paths) {
            if(-not $NewPaths.ContainsKey($OldPath.pathId)){if(-not $Retired){Add-HistoryFinding RemovedHistoricalPath $OldPath.pathId};continue}
            $NewPath=$NewPaths[$OldPath.pathId]
            foreach($Key in @('input','context','scenarioKind')) {
                if($NewPath[$Key] -cne $OldPath[$Key]){Add-HistoryFinding RecycledIdentity $OldPath.pathId}
            }
            # DE: Fokus ist ebenfalls ein Orakel; eine Korrektur braucht dieselbe explizite Freigabe wie Fachwerte.
            # EN: Focus is an oracle too; correcting it needs the same explicit approval as business values.
            if(($NewPath.focusAfter -cne $OldPath.focusAfter -or
                (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $NewPath.expectedState -Depth 40)) -cne
                (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $OldPath.expectedState -Depth 40))) -and
                -not (Has-Authority $Old.id BreakingChange $OldPath.pathId)) {Add-HistoryFinding UnauthorizedOracleChange $OldPath.pathId}
            if(-not $Retired -and $OldPath.automatable -and -not $NewPath.automatable){Add-HistoryFinding WeakenedHistoricalObligation $OldPath.pathId}
        }
    }
    return @($Findings | Sort-Object code,sourceRef -Unique)
}
