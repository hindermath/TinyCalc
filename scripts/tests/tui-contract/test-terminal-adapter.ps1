#Requires -Version 7
<#
.SYNOPSIS
DE: Prüft fehlgeschlagenen Start und Timeout im eigenen macOS-PTY; keine Produktabnahme.
EN: Tests failed startup and timeout in an owned macOS PTY; not product acceptance.
#>
[CmdletBinding()]
param([string]$RepositoryRoot=(Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference='Stop'
if(-not $IsMacOS){throw 'This adapter test requires native macOS; no substituted proof.'}
$Owned=[IO.Directory]::CreateTempSubdirectory('tinycalc pty fixtures ').FullName
try {
    foreach($Case in @(@{name='early-exit';command='/usr/bin/false';argument='unused';error='EarlyExit'},@{name='timeout';command='/bin/sleep';argument='60';error='QuitTimeout'})){
        $Directory=Join-Path $Owned $Case.name
        $null=[IO.Directory]::CreateDirectory($Directory)
        $Start=[Diagnostics.ProcessStartInfo]::new('/usr/bin/expect')
        $Start.UseShellExecute=$false;$Start.RedirectStandardOutput=$true;$Start.RedirectStandardError=$true
        foreach($Argument in @((Join-Path $RepositoryRoot 'scripts/tests/tui-contract/capture-terminal.exp'),$Case.argument,$Directory,'80','24',$Case.command)){$Start.ArgumentList.Add($Argument)}
        $Watch=[Diagnostics.Stopwatch]::StartNew()
        $Process=[Diagnostics.Process]::Start($Start)
        try {
            $Out=$Process.StandardOutput.ReadToEndAsync();$Err=$Process.StandardError.ReadToEndAsync()
            if(-not $Process.WaitForExit(20000)){$Process.Kill($true);$null=$Process.WaitForExit(5000);throw 'Adapter cleanup deadline exceeded.'}
            if($Process.ExitCode -ne 1 -or $Err.GetAwaiter().GetResult() -notmatch ('PTY_CAPTURE_FAIL:'+$Case.error) -or $Out.GetAwaiter().GetResult()) {throw ('Adapter failure was not bounded: '+$Case.name)}
            if($Watch.Elapsed.TotalSeconds -gt 20){throw 'Adapter exceeded deadline.'}
            Write-Output ('PTY_NEGATIVE_PASS: '+$Case.name+'; bounded owned-process failure, not product proof.')
        }
        finally{$Process.Dispose()}
    }
}
finally{[IO.Directory]::Delete($Owned,$true)}
