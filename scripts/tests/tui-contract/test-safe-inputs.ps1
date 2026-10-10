#Requires -Version 7
[CmdletBinding()]
param([string]$RepositoryRoot = (Join-Path $PSScriptRoot '../../..'))
Set-StrictMode -Version Latest
$ErrorActionPreference = 'Stop'
$Root = [IO.Path]::GetFullPath($RepositoryRoot)
. (Join-Path $Root 'scripts/lib/tui-contract/SafeInputs.ps1')
$Owned = [IO.Directory]::CreateTempSubdirectory('tinycalc-path-fixtures-').FullName
$Failures = [Collections.Generic.List[string]]::new()
try {
    $Inside = Join-Path $Owned 'inside'; $Outside = Join-Path $Owned 'outside'
    $null = [IO.Directory]::CreateDirectory($Inside); $null = [IO.Directory]::CreateDirectory($Outside)
    [IO.File]::WriteAllText((Join-Path $Inside 'valid.json'), '{}')
    [IO.File]::WriteAllText((Join-Path $Outside 'private.json'), '{}')
    $null = [IO.File]::CreateSymbolicLink((Join-Path $Inside 'escaping.json'), (Join-Path $Outside 'private.json'))
    $null = [IO.Directory]::CreateSymbolicLink((Join-Path $Inside 'escaping-dir'), $Outside)
    $Cases = @(
        @{ name = 'parent'; path = '../outside/private.json'; relative = $true },
        @{ name = 'absolute-outside'; path = (Join-Path $Outside 'private.json'); relative = $false },
        @{ name = 'absolute-json-ref'; path = (Join-Path $Inside 'valid.json'); relative = $true },
        @{ name = 'leaf-symlink'; path = 'escaping.json'; relative = $true },
        @{ name = 'ancestor-symlink'; path = 'escaping-dir/private.json'; relative = $true },
        @{ name = 'url'; path = 'https://invalid.example/evidence.json'; relative = $true },
        @{ name = 'missing'; path = 'absent.json'; relative = $true }
    )
    $Resolved = Resolve-TuiInputPath -Path valid.json -RepositoryRoot $Inside -RelativeOnly
    if ($Resolved -cne (Join-Path $Inside 'valid.json')) { $Failures.Add('positive-path') }
    foreach ($Case in $Cases) {
        $Rejected = $false
        try { $null = Resolve-TuiInputPath -Path $Case.path -RepositoryRoot $Inside -RelativeOnly:$Case.relative }
        catch { $Rejected = $true }
        if (-not $Rejected) { $Failures.Add($Case.name) }
    }
    foreach ($Failure in $Failures) { Write-Output ('SAFETY_FAIL: ' + $Failure) }
    Write-Output "SAFETY: 8 cases; $($Failures.Count) failed."
    if ($Failures.Count) { exit 1 }
}
finally { [IO.Directory]::Delete($Owned, $true) }
