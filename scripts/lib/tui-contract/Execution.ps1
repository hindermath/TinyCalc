#Requires -Version 7
Set-StrictMode -Version Latest

# DE: Ausführungsdateien sind untrusted Daten; keine DTD, Resolver oder Befehlsausführung.
# EN: Execution files are untrusted data; never allow DTDs, resolvers or command execution.
function Read-TuiTrxExecution {
    param([string]$Path)
    if ((Get-Item -LiteralPath $Path).Length -gt 20971520) { throw 'InvalidInputSize' }
    $Settings = [Xml.XmlReaderSettings]::new()
    $Settings.DtdProcessing = [Xml.DtdProcessing]::Prohibit
    $Settings.XmlResolver = $null
    $Reader = [Xml.XmlReader]::Create($Path, $Settings)
    try {
        $Document = [Xml.XmlDocument]::new()
        $Document.XmlResolver = $null
        $Document.Load($Reader)
    }
    finally { $Reader.Dispose() }
    return @($Document.SelectNodes("//*[local-name()='UnitTestResult']"))
}

function Test-TuiExecutedResult {
    param($Record, $Executions)
    $Prefix = 'MicroCalc.Tui.Tests.' + [IO.Path]::GetFileNameWithoutExtension(($Record.testRef -split '#',2)[0]) + '.'
    $Matches = @($Executions | Where-Object { $_.testName.StartsWith($Prefix,[StringComparison]::Ordinal) -and
        $_.testName.Contains(('id: "' + $Record.pathId + '"'),[StringComparison]::Ordinal) })
    if($Matches.Count -ne 1 -or $Matches[0].outcome -cne 'Passed'){return 'MissingPassedExecution'}
    $Start=[DateTimeOffset]::Parse($Record.startedAt,[Globalization.CultureInfo]::InvariantCulture)
    $End=[DateTimeOffset]::Parse($Record.finishedAt,[Globalization.CultureInfo]::InvariantCulture)
    if($Start -lt [DateTimeOffset]::Parse($Matches[0].startTime,[Globalization.CultureInfo]::InvariantCulture) -or
        $End -gt [DateTimeOffset]::Parse($Matches[0].endTime,[Globalization.CultureInfo]::InvariantCulture) -or
        $End -lt $Start -or ($End-$Start).TotalSeconds -gt 30){return 'ExecutionTimingMismatch'}
    return ''
}

function Test-TuiAdditionExecutionProof {
    param([string]$RepositoryRoot,[string]$BaselineCommit,$Addition,[string]$RedPath,[string]$TestSourcePath)
    # DE: Syntaktisch gültiges Rot genügt nicht: Quelle/Resultat müssen vor Produktänderung in Git gebunden sein.
    # EN: Syntactically valid red is insufficient: source/result must be bound in Git before the product change.
    $Rows=@(Read-TuiTrxExecution $RedPath|Where-Object{$_.testName -ceq $Addition.testName})
    $Valid=$Rows.Count -eq 1 -and $Rows[0].outcome -ceq 'Failed' -and $Addition.redCommit -cne $Addition.implementationCommit
    $RedRelative=[IO.Path]::GetRelativePath($RepositoryRoot,$RedPath).Replace('\','/')
    $TestRelative=[IO.Path]::GetRelativePath($RepositoryRoot,$TestSourcePath).Replace('\','/')
    $Valid=$Valid -and (Test-TuiHistoricalArtifact $RepositoryRoot $Addition.redCommit $RedRelative) -and
        (Test-TuiHistoricalArtifact $RepositoryRoot $Addition.redCommit $TestRelative)
    $TestClass=[IO.Path]::GetFileNameWithoutExtension($TestSourcePath)
    $Valid=$Valid -and $Addition.testName -cmatch ('^MicroCalc\.(?:Core|Tui)\.Tests\.'+[regex]::Escape($TestClass)+'\.')
    & git -C $RepositoryRoot diff --quiet $BaselineCommit $Addition.redCommit -- $TestRelative
    $Valid=$Valid -and $LASTEXITCODE -eq 1
    & git -C $RepositoryRoot merge-base --is-ancestor $Addition.redCommit $Addition.implementationCommit 2>$null
    $Valid=$Valid -and $LASTEXITCODE -eq 0
    & git -C $RepositoryRoot merge-base --is-ancestor $Addition.implementationCommit HEAD 2>$null
    $Valid=$Valid -and $LASTEXITCODE -eq 0
    foreach($ProductPath in $Addition.productPaths){
        if($ProductPath -cnotmatch '^src/[A-Za-z0-9_./-]+$' -or '..' -in ($ProductPath -split '/')){return $false}
        & git -C $RepositoryRoot diff --quiet $BaselineCommit $Addition.redCommit -- $ProductPath
        $Valid=$Valid -and $LASTEXITCODE -eq 0
    }
    $Changed=@(& git -C $RepositoryRoot diff --name-only $Addition.redCommit $Addition.implementationCommit -- @($Addition.productPaths) 2>$null)
    return $Valid -and $LASTEXITCODE -eq 0 -and $Changed.Count -gt 0
}
