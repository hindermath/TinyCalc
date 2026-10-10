#Requires -Version 7
<#
.SYNOPSIS
DE: Vereinigt vorhandene Cobertura-Treffer für geänderte ausführbare Produktzeilen; startet keine Tests.
EN: Unions existing Cobertura hits for changed executable product lines; never starts tests.
#>
[CmdletBinding()]
param(
    [string]$RepositoryRoot=(Join-Path $PSScriptRoot '..'),
    [ValidatePattern('^[a-f0-9]{40}$')][string]$BaselineCommit='ffc3d56a8975341a686ff6985570369abefcfd2a',
    [string]$CoverageDirectory='tests/MicroCalc.Tui.Tests/TestResults/native-ci',
    [switch]$Json
)
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $PSScriptRoot 'lib/tui-contract/SafeInputs.ps1')
$Directory=Resolve-TuiInputPath $CoverageDirectory $Root
$Covered=@{};$Reports=@()
foreach($File in Get-ChildItem -LiteralPath $Directory -Recurse -File -Filter coverage.cobertura.xml){
    $Path=Resolve-TuiInputPath $File.FullName $Root
    $Settings=[Xml.XmlReaderSettings]::new();$Settings.DtdProcessing=[Xml.DtdProcessing]::Prohibit
    $Settings.XmlResolver=$null;$Settings.MaxCharactersInDocument=20971520
    $Reader=[Xml.XmlReader]::Create($Path,$Settings)
    try{$Xml=[Xml.XmlDocument]::new();$Xml.XmlResolver=$null;$Xml.Load($Reader)}finally{$Reader.Dispose()}
    foreach($Class in $Xml.SelectNodes('/coverage/packages/package/classes/class')){
        $Source='src/'+$Class.filename.Replace('\','/')
        foreach($Line in $Class.SelectNodes('lines/line')){
            $Key=$Source+':'+$Line.number
            if(-not $Covered.ContainsKey($Key)){$Covered[$Key]=0}
            # DE: Mehrere Projekte können dieselbe Datei messen; Zeilen zählen nur einmal, nicht pro Report.
            # EN: Several projects may measure the same file; count each line once, not once per report.
            $Covered[$Key]=[Math]::Max($Covered[$Key],[int]$Line.hits)
        }
    }
    $Reports+=@{path=[IO.Path]::GetRelativePath($Root,$Path).Replace('\','/');sha256=(Get-FileHash -LiteralPath $Path).Hash.ToLowerInvariant()}
}
if(-not $Reports.Count){throw 'MissingCoverage'}
$Changed=[Collections.Generic.HashSet[string]]::new([StringComparer]::Ordinal);$Source=''
$Diff=@(& git -C $Root diff --unified=0 $BaselineCommit -- src)
if($LASTEXITCODE -ne 0){throw 'InvalidBaseline'}
foreach($Line in $Diff){
    if($Line.StartsWith('+++ ',[StringComparison]::Ordinal)){
        $Source=if($Line -cmatch '^\+\+\+ b/(.+\.cs)$'){$Matches[1]}else{''}
    }elseif($Source -and $Line -cmatch '^@@ -[0-9]+(?:,[0-9]+)? \+([0-9]+)(?:,([0-9]+))? @@'){
        $Start=[int]$Matches[1];$Count=if($Matches[2]){[int]$Matches[2]}else{1}
        for($Index=0;$Index -lt $Count;$Index++){$null=$Changed.Add($Source+':'+($Start+$Index))}
    }
}
$Untracked=@(& git -C $Root ls-files --others --exclude-standard -- 'src/*.cs')
if($LASTEXITCODE -ne 0){throw 'InvalidRepository'}
foreach($Source in $Untracked){
    $Path=Resolve-TuiInputPath $Source $Root -RelativeOnly
    $Count=@(Get-Content -LiteralPath $Path).Count
    for($Index=1;$Index -le $Count;$Index++){$null=$Changed.Add($Source+':'+$Index)}
}
$Executable=@($Changed|Where-Object{$Covered.ContainsKey($_)})
if(-not $Executable.Count){throw 'MissingChangedExecutableLines'}
$Hit=@($Executable|Where-Object{$Covered[$_] -gt 0})
$Files=@(foreach($Group in $Executable|Group-Object {$_ -replace ':[0-9]+$',''}){
    @{path=$Group.Name;covered=@($Group.Group|Where-Object{$Covered[$_] -gt 0}).Count;executable=$Group.Count}
})
$Result=[ordered]@{baselineCommit=$BaselineCommit;covered=$Hit.Count;executable=$Executable.Count
    percent=[Math]::Round(100.0*$Hit.Count/$Executable.Count,2);requiredPercent=70;targetPercent=80;reports=$Reports;files=$Files}
if($Json){$Result|ConvertTo-Json -Depth 8}else{
    Write-Output ('Geänderte ausführbare Zeilen / Changed executable lines: {0}/{1} = {2}%' -f $Hit.Count,$Executable.Count,$Result.percent)
}
if($Result.percent -lt 70){exit 1}
