#Requires -Version 7
Set-StrictMode -Version Latest

function Test-TuiSourceOffers {
    param($Baseline, $Contract, $SourceMap)
    $Findings=[Collections.Generic.List[object]]::new()
    foreach($Source in $Baseline.sources) {
        if($Source.path -cnotin @($SourceMap.mappings | ForEach-Object { $_.sourcePath })) {
            $Findings.Add(@{code='MissingSourceSurface';sourceRef=$Source.path})
        }
    }
    $Paths=@($Contract.capabilities | ForEach-Object { $_.paths } | ForEach-Object { $_.pathId })
    foreach($Offer in $Baseline.offers) {
        if($Offer.id -cnotin $Paths){$Findings.Add(@{code='MissingObligation';sourceRef=$Offer.id})}
    }
    foreach($Cap in $Contract.capabilities) {
        if($Cap.status -eq 'Retired'){continue}
        if($Cap.id -cnotin @($SourceMap.mappings | Where-Object { $_.offerKind -ceq 'Substantive' } | ForEach-Object { $_.capabilityRefs })) {
            $Findings.Add(@{code='UnmappedCapability';sourceRef=$Cap.id})
        }
    }
    foreach($Mapping in $SourceMap.mappings) {
        if($Mapping.offerKind -ceq 'DocumentationDefect' -and $Mapping.defectRef -cnotin @($SourceMap.defects | ForEach-Object { $_.code })) {
            $Findings.Add(@{code='InvalidDocumentationDefect';sourceRef=$Mapping.sourcePath})
        }
    }
    return @($Findings | Sort-Object code,sourceRef -Unique)
}

function Get-TuiContractCatalog {
    param($Contract)
    function Escape-Cell([string]$Text) { return ($Text.Replace('|','&#124;') -replace '[\r\n]+',' ') }
    $Text=[Text.StringBuilder]::new()
    $null=$Text.AppendLine('# Vollständiger TUI-Katalog / Complete TUI catalogue')
    $null=$Text.AppendLine()
    $null=$Text.AppendLine('Deutsch: Dieser abgeleitete Katalog zeigt jede aktive automatisierbare Pflicht je Plattform, ID, Pfad und Szenario. Ein Eintrag ist kein bestandener Test. HumanVoiceOver und LinkedAccessibilityGates sind zusätzliche menschliche Pflichten; ein menschlicher Nachweis ersetzt keine Automation. MacOsPty80x24 und MacOsPty120x40 verlangen reale Terminalbeobachtungen.')
    $null=$Text.AppendLine()
    $null=$Text.AppendLine('English: This derived catalogue lists every active automated obligation by platform, ID, path and scenario. A row is not a passed test. HumanVoiceOver and LinkedAccessibilityGates are additional human obligations, never substitutes for automation. Both MacOsPty sizes require real terminal observation.')
    $null=$Text.AppendLine()
    $null=$Text.AppendLine('| Plattform / Platform | ID | Pfad / Path | Szenario / Scenario | Kontext / Context | Eingabe / Input | Fokus danach / Focus after |')
    $null=$Text.AppendLine('|---|---|---|---|---|---|---|')
    foreach($Cap in $Contract.capabilities) {
        if(-not $Cap.mandatory -or $Cap.status -notin @('Active','Deprecated')){continue}
        foreach($Path in $Cap.paths) {
            if(-not $Path.automatable){continue}
            foreach($Platform in @($Cap.platforms | Sort-Object)) {
                $Cells=@($Platform,$Cap.id,$Path.pathId,$Path.scenarioKind,$Path.context,$Path.input,$Path.focusAfter)
                $null=$Text.AppendLine('| '+(($Cells | ForEach-Object { Escape-Cell $_ }) -join ' | ')+' |')
            }
        }
    }
    return $Text.ToString().Replace("`r`n","`n")
}
