#Requires -Version 7
Set-StrictMode -Version Latest

function Test-TuiWorkflowContract {
    param([string]$Text)
    $Failures=[Collections.Generic.List[string]]::new()
    if($Text -notmatch '(?m)^  push:\r?\n  pull_request:\s*$'){$Failures.Add('FilteredPush')}
    if($Text -notmatch 'ubuntu-latest' -or $Text -notmatch 'windows-latest'){$Failures.Add('MissingNativePlatform')}
    $Test=[regex]::Match($Text,'(?m)^        run: (dotnet test MicroCalc\.sln[^\r\n]*)$')
    if(-not $Test.Success -or $Test.Groups[1].Value -match '--filter|--list-tests|--no-build.*--no-build' -or
        $Test.Groups[1].Value -notmatch '--logger' -or $Test.Groups[1].Value -notmatch '--results-directory'){$Failures.Add('MissingFullExecution')}
    $Collector=[regex]::Match($Text,'(?ms)^      - name: Bind full native TUI contract\r?\n(?<body>.*?)(?=^      - |\z)')
    if(-not $Collector.Success -or $Collector.Groups['body'].Value -match '(?m)^        (if|continue-on-error):' -or
        $Collector.Groups['body'].Value -notmatch 'collect-tui-contract-evidence\.ps1'){$Failures.Add('MissingUnconditionalBinding')}
    if($Text -notmatch 'actions/upload-artifact@' -or $Text -notmatch 'if-no-files-found: error'){$Failures.Add('MissingProofUpload')}
    return @($Failures)
}
