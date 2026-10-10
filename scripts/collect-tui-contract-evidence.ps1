#Requires -Version 7
<#
.SYNOPSIS
DE: Bindet einen vollständigen nativen Testprozess; führt selbst keine Tests aus und erteilt keine Gesamtfreigabe.
EN: Binds one complete native test process; never runs tests or grants full acceptance.
.PARAMETER Action
DE: Vor Testbeginn binden oder abgeschlossenen Lauf sammeln. EN: Capture before testing or collect the finished run.
.PARAMETER RepositoryRoot
DE: Explizite Vertrauenswurzel. EN: Explicit trust root.
.PARAMETER Runner
DE: Tatsächlicher Runner aus dem Workflow. EN: Actual workflow runner.
.PARAMETER Job
DE: Tatsächlicher Job aus dem Workflow. EN: Actual workflow job.
.PARAMETER Command
DE: Tatsächlich auszuführender Testbefehl, nur Metadaten. EN: Actual test command, metadata only.
#>
[CmdletBinding()]
param(
    [ValidateSet('Capture','Collect')][string]$Action='Collect',
    [string]$RepositoryRoot=(Join-Path $PSScriptRoot '..'),
    [string]$Runner=$env:RUNNER_OS,
    [string]$Job=$env:GITHUB_JOB,
    [string]$Command='dotnet test MicroCalc.sln --configuration Release --no-build --logger trx --results-directory tests/MicroCalc.Tui.Tests/TestResults/native-ci'
)
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
$Root=[IO.Path]::GetFullPath($RepositoryRoot)
foreach($Name in @('CanonicalJson','SafeInputs','Semantics','Execution')){. (Join-Path $PSScriptRoot "lib/tui-contract/$Name.ps1")}
$Platform=if($IsMacOS){'macos'}elseif($IsWindows){'windows'}else{'linux'}
$Output=Join-Path $Root 'tests/MicroCalc.Tui.Tests/TestResults/native-ci'
# DE: Nur der feste eigene TestResults-Bereich ist beschreibbar, niemals ein Evidence-gesteuerter Zielpfad.
# EN: Only this fixed owned TestResults area is writable, never an evidence-selected target.
for($Parent=[IO.DirectoryInfo]::new($Output);$null -ne $Parent;$Parent=$Parent.Parent){if($Parent.Exists -and $Parent.LinkTarget){throw 'UnsafePath'}}
$null=[IO.Directory]::CreateDirectory($Output)
$ContextPath=Join-Path $Output 'execution-context.json'
$Commit=@(& git -C $Root rev-parse HEAD)
if($LASTEXITCODE -ne 0 -or $Commit.Count -ne 1 -or $Commit[0] -cnotmatch '^[a-f0-9]{40}$'){throw 'InvalidRepository'}
$Contract=Read-TuiJsonInput (Join-Path $Root 'docs/contracts/tui/product-contract.json')
$Pin=Read-TuiJsonInput (Join-Path $Root 'specs/006-tui-functional-contract/evidence/pin-decision.json')
$Binding=@{commit=$Commit[0];workingTreeDigest=Get-TuiWorkingTreeDigest $Root
    contractDigest=Get-TuiCanonicalDigest ([IO.File]::ReadAllText((Join-Path $Root 'docs/contracts/tui/product-contract.json')))
    pinDecisionDigest=Get-TuiCanonicalDigest ([IO.File]::ReadAllText((Join-Path $Root 'specs/006-tui-functional-contract/evidence/pin-decision.json'))) -ExcludeRootProperty decisionDigest}
function Publish-Owned([string]$Path,$Value){
    $Temporary=$Path+'.'+[Guid]::NewGuid().ToString('N')+'.tmp'
    try{[IO.File]::WriteAllText($Temporary,($Value|ConvertTo-Json -Depth 80)+"`n",[Text.UTF8Encoding]::new($false));[IO.File]::Move($Temporary,$Path,$false)}
    finally{if(Test-Path -LiteralPath $Temporary){[IO.File]::Delete($Temporary)}}
}
if($Action -eq 'Capture'){
    foreach($Value in @($Runner,$Job,$Command)){if([string]::IsNullOrWhiteSpace($Value) -or $Value.Length -gt 1024 -or $Value -match '[\x00-\x1f]'){throw 'InvalidExecutionMetadata'}}
    if($Command -notmatch '^dotnet test MicroCalc\.sln ' -or $Command -match '--filter|--list-tests'){throw 'FilteredExecution'}
    $Context=@{binding=$Binding;platform=$Platform;runner=$Runner;job=$Job;command=$Command;startedAt=[DateTimeOffset]::UtcNow.ToString('O')
        toolVersions=@{powershell=$PSVersionTable.PSVersion.ToString();dotnet=(& dotnet --version);os=[Runtime.InteropServices.RuntimeInformation]::OSDescription}}
    if($LASTEXITCODE -ne 0){throw 'MissingToolVersion'}
    Publish-Owned $ContextPath $Context
    Write-Output 'EXECUTION_CAPTURED: native metadata only; no test or acceptance claimed.'
    exit 0
}
$Context=Read-TuiJsonInput (Resolve-TuiInputPath $ContextPath $Root)
foreach($Key in @('commit','workingTreeDigest','contractDigest','pinDecisionDigest')){if($Context.binding[$Key] -cne $Binding[$Key]){throw 'ExecutionBindingDrift'}}
if($Context.platform -cne $Platform){throw 'WrongNativePlatform'}
$TrxFiles=@(Get-ChildItem -LiteralPath $Output -File -Filter '*.trx')
$Executions=@();$Trx=$null
foreach($File in $TrxFiles){
    $Rows=@(Read-TuiTrxExecution (Resolve-TuiInputPath $File.FullName $Root))
    if(-not $Rows.Count -or @($Rows|Where-Object outcome -CNE Passed).Count){throw 'FailedOrMissingExecution'}
    if(@($Rows|Where-Object{$_.testName.StartsWith('MicroCalc.Tui.Tests.',[StringComparison]::Ordinal)}).Count){if($Trx){throw 'MixedExecution'};$Trx=$File;$Executions=$Rows}
}
if(-not $Trx -or @($Executions|Where-Object outcome -CNE Passed).Count){throw 'FailedOrMissingExecution'}
$Started=[DateTimeOffset]::Parse($Context.startedAt,[Globalization.CultureInfo]::InvariantCulture)
$RecordRoot=Join-Path $Root 'tests/MicroCalc.Tui.Tests/TestResults/contract-cases'
$Directories=@(Get-ChildItem -LiteralPath $RecordRoot -Directory|Where-Object{$_.CreationTimeUtc -ge $Started.UtcDateTime})
if($Directories.Count -ne 1){throw 'MixedOrMissingRecords'}
$Records=@(Get-ChildItem -LiteralPath $Directories[0].FullName -Recurse -File -Filter path-result.json|ForEach-Object{
    Read-TuiJsonInput (Resolve-TuiInputPath $_.FullName $Root) (Join-Path $Root 'docs/contracts/tui/path-result.schema.json')
})
foreach($Record in $Records){
    $Failure=Test-TuiExecutedResult $Record $Executions
    if($Failure){throw $Failure}
    if([DateTimeOffset]::Parse($Record.startedAt) -lt $Started){throw 'StaleExecution'}
    foreach($Ref in @($Record.assertionProofRef)+@($Record.artifactRefs|ForEach-Object{$_.path+'#sha256='+$_.sha256})){
        if($Ref -cnotmatch '^(.+)#sha256=([a-f0-9]{64})$'){throw 'InvalidArtifactReference'}
        $Path=Resolve-TuiInputPath $Matches[1] $Root -RelativeOnly
        if((Get-FileHash -LiteralPath $Path).Hash.ToLowerInvariant() -cne $Matches[2]){throw 'ArtifactDigestMismatch'}
        if($Ref -ceq $Record.assertionProofRef){
            $Proof=Read-TuiJsonInput $Path
            foreach($Key in @('capabilityId','pathId','scenarioKind','testRef','startedAt','finishedAt','assertions')){
                if(-not $Proof.Contains($Key) -or (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Proof[$Key] -Depth 40)) -cne
                    (Get-TuiCanonicalDigest (ConvertTo-Json -InputObject $Record[$Key] -Depth 40))){throw 'AssertionProofMismatch'}
            }
        }
    }
}
$Bundle=@{schemaVersion='1.0';runId=[Guid]::NewGuid().ToString();platform=$Platform;runner=$Context.runner;job=$Context.job;command=$Context.command
    toolVersions=$Context.toolVersions;startedAt=($Records.startedAt|Sort-Object|Select-Object -First 1);finishedAt=($Records.finishedAt|Sort-Object|Select-Object -Last 1)
    exitCode=0;results=$Records;executionProofRef=[IO.Path]::GetRelativePath($Root,$Trx.FullName).Replace('\','/')+'#sha256='+(Get-FileHash -LiteralPath $Trx.FullName).Hash.ToLowerInvariant()}
foreach($Key in $Binding.Keys){$Bundle[$Key]=$Binding[$Key]}
$Bundle.payloadDigest=Get-TuiCanonicalDigest ($Bundle|ConvertTo-Json -Depth 80) -ExcludeRootProperty payloadDigest
if(-not (Test-Json -Json ($Bundle|ConvertTo-Json -Depth 80) -SchemaFile (Join-Path $Root 'docs/contracts/tui/evidence-bundle.schema.json'))){throw 'InvalidSchema'}
$Baseline=Read-TuiJsonInput (Join-Path $Root 'docs/contracts/tui/baseline-inventory.json')
$Findings=@(Test-TuiEvidenceModel $Baseline $Contract @($Bundle) $Binding|Where-Object{$_.code -cne 'MissingResult' -or $_.sourceRef.Contains('|'+$Platform+'|',[StringComparison]::Ordinal)})
if($Findings.Count){throw 'IncompleteNativeContract'}
Publish-Owned (Join-Path $Output ($Platform+'.bundle.json')) $Bundle
Write-Output ('NATIVE_AUTOMATION_BOUND: '+$Platform+'; '+$Records.Count+' paths. Not full acceptance; other platforms/human/review gates remain separate.')
