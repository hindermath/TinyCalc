#Requires -Version 7
Set-StrictMode -Version Latest

# DE: Auch bestehende Elternverzeichnisse prüfen: ein sicherer Dateiname kann durch Symlinks ausbrechen.
# EN: Check existing ancestors too: a safe file name can still escape through symbolic links.
function Resolve-TuiInputPath {
    param([string]$Path, [string]$RepositoryRoot, [string]$EvidenceRoot = '', [switch]$RelativeOnly)
    if ([string]::IsNullOrWhiteSpace($Path) -or $Path -match '[\x00-\x1f]' -or $Path -match '^[a-zA-Z][a-zA-Z0-9+.-]*://') {
        throw 'UnsafePath'
    }
    if ($RelativeOnly -and ([IO.Path]::IsPathRooted($Path) -or '..' -in ($Path -split '[/\\]'))) { throw 'UnsafePath' }
    $Roots = @([IO.Path]::GetFullPath($RepositoryRoot))
    if ($EvidenceRoot) { $Roots += [IO.Path]::GetFullPath($EvidenceRoot) }
    $Comparison = if ($IsWindows) { [StringComparison]::OrdinalIgnoreCase } else { [StringComparison]::Ordinal }
    function Get-PhysicalPath([string]$Value) {
        $Physical = [IO.Path]::GetPathRoot($Value)
        foreach ($Part in ($Value.Substring($Physical.Length) -split '[/\\]')) {
            if (-not $Part) { continue }
            $Physical = Join-Path $Physical $Part
            $Info = Get-Item -LiteralPath $Physical -Force
            if ($Info.LinkType) {
                $Target = $Info.ResolveLinkTarget($true)
                if ($null -eq $Target) { throw 'UnsafePath' }
                $Physical = $Target.FullName
            }
        }
        return $Physical
    }
    function Is-Contained([string]$Candidate) {
        foreach ($Allowed in $Roots) {
            if ($Candidate.Equals($Allowed, $Comparison) -or $Candidate.StartsWith($Allowed.TrimEnd([IO.Path]::DirectorySeparatorChar) + [IO.Path]::DirectorySeparatorChar, $Comparison)) { return $true }
        }
        return $false
    }
    $Full = [IO.Path]::GetFullPath($Path, $Roots[0])
    if (-not (Test-Path -LiteralPath $Full) -and $EvidenceRoot -and -not [IO.Path]::IsPathRooted($Path)) {
        $Full = [IO.Path]::GetFullPath($Path, $Roots[1])
    }
    if (-not (Is-Contained $Full) -or -not (Test-Path -LiteralPath $Full)) { throw 'UnsafePath' }
    $Physical = Get-PhysicalPath $Full
    $Roots = @($Roots | ForEach-Object { Get-PhysicalPath $_ })
    if (-not (Is-Contained $Physical)) { throw 'UnsafePath' }
    return $Full
}

function Read-TuiJsonInput {
    param([string]$Path, [string]$SchemaPath = '')
    if ((Get-Item -LiteralPath $Path -Force).Length -gt 20971520) { throw 'InvalidInputSize' }
    $Json = [IO.File]::ReadAllText($Path, [Text.UTF8Encoding]::new($false, $true))
    # DE: Kanonisierung verwirft doppelte Schlüssel vor dem PowerShell-Deserialisieren.
    # EN: Canonical validation rejects duplicate keys before PowerShell deserialization.
    $null = Get-TuiCanonicalDigest $Json
    if ($SchemaPath -and -not (Test-Json -Json $Json -SchemaFile $SchemaPath -ErrorAction SilentlyContinue)) { throw 'InvalidSchema' }
    # DE: Neuere PowerShell-Versionen wandeln ISO-Zeiten sonst kulturabhängig in DateTime um.
    # EN: Recent PowerShell versions otherwise coerce ISO timestamps into culture-dependent DateTime values.
    $Parameters = @{ InputObject=$Json; AsHashtable=$true; Depth=80 }
    if ((Get-Command ConvertFrom-Json).Parameters.ContainsKey('DateKind')) { $Parameters.DateKind = 'String' }
    return ConvertFrom-Json @Parameters
}

function Test-TuiHistoricalArtifact {
    param([string]$RepositoryRoot,[string]$Commit,[string]$RelativePath)
    if($Commit -cnotmatch '^[a-f0-9]{40}$' -or $RelativePath -cnotmatch '^[A-Za-z0-9_./-]+$' -or
        [IO.Path]::IsPathRooted($RelativePath) -or '..' -in ($RelativePath -split '/')){return $false}
    try{$Path=Resolve-TuiInputPath $RelativePath $RepositoryRoot -RelativeOnly}catch{return $false}
    # DE: Git-Blob-Identität bindet die bereits SHA-256-geprüften Bytes an den historischen Commit, ohne Checkout.
    # EN: Git blob identity binds the SHA-256-checked bytes to the historical commit without checking it out.
    $Previous=@(& git -C $RepositoryRoot rev-parse ($Commit+':'+$RelativePath) 2>$null)
    if($LASTEXITCODE -ne 0 -or $Previous.Count -ne 1 -or $Previous[0] -cnotmatch '^[a-f0-9]{40}$'){return $false}
    $Current=@(& git -C $RepositoryRoot hash-object -- $Path 2>$null)
    return $LASTEXITCODE -eq 0 -and $Current.Count -eq 1 -and $Current[0] -ceq $Previous[0]
}

function Get-TuiWorkingTreeDigest {
    param([string]$RepositoryRoot)
    $Files = @(& git -C $RepositoryRoot -c core.quotepath=false ls-files --cached --others --exclude-standard)
    if ($LASTEXITCODE -ne 0) { throw 'InvalidRepository' }
    $Rows = foreach ($File in @($Files | Sort-Object -Unique -CaseSensitive)) {
        $Path = Resolve-TuiInputPath -Path $File -RepositoryRoot $RepositoryRoot -RelativeOnly
        if ((Get-Item -LiteralPath $Path -Force).PSIsContainer) { throw 'InvalidRepository' }
        [ordered]@{ path = $File; sha256 = (Get-FileHash -LiteralPath $Path -Algorithm SHA256).Hash.ToLowerInvariant() }
    }
    return Get-TuiCanonicalDigest (ConvertTo-Json -InputObject @($Rows) -Depth 8 -Compress)
}
