#Requires -Version 7
Set-StrictMode -Version Latest

# DE: Ein gemeinsamer Bytevertrag verhindert scheinbare Drift durch Einrückung oder Feldreihenfolge.
# EN: One shared byte contract avoids false drift from indentation or property order.
function ConvertTo-TuiCanonicalJson {
    [CmdletBinding()]
    param([Parameter(Mandatory)][System.Text.Json.JsonElement]$Element)

    $Encoder = [System.Text.Encodings.Web.JavaScriptEncoder]::UnsafeRelaxedJsonEscaping
    switch ($Element.ValueKind.ToString()) {
        'Object' {
            $Properties = [System.Collections.Generic.SortedDictionary[string,System.Text.Json.JsonElement]]::new([StringComparer]::Ordinal)
            foreach ($Property in $Element.EnumerateObject()) {
                if ($Properties.ContainsKey($Property.Name)) { throw 'Duplicate JSON property / Doppeltes JSON-Feld' }
                $Properties.Add($Property.Name, $Property.Value)
            }
            $Parts = foreach ($Pair in $Properties.GetEnumerator()) {
                $Name = [System.Text.Json.JsonEncodedText]::Encode($Pair.Key, $Encoder).ToString()
                '"' + $Name + '":' + (ConvertTo-TuiCanonicalJson -Element $Pair.Value)
            }
            return '{' + ($Parts -join ',') + '}'
        }
        'Array' {
            $Parts = foreach ($Item in $Element.EnumerateArray()) { ConvertTo-TuiCanonicalJson -Element $Item }
            return '[' + ($Parts -join ',') + ']'
        }
        'String' { return '"' + [System.Text.Json.JsonEncodedText]::Encode($Element.GetString(), $Encoder).ToString() + '"' }
        'Number' { return $Element.GetRawText() }
        'True' { return 'true' }
        'False' { return 'false' }
        'Null' { return 'null' }
        default { throw 'Unsupported JSON kind / Nicht unterstützter JSON-Typ' }
    }
}

function Get-TuiCanonicalDigest {
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)][string]$Json,
        [string]$ExcludeRootProperty = ''
    )

    $Document = [System.Text.Json.JsonDocument]::Parse($Json)
    try {
        # DE: Erst vollständig prüfen: auch doppelte Felder dürfen nicht durch den Digest-Ausschluss verschwinden.
        # EN: Validate first so excluding a digest cannot hide duplicate properties.
        $Canonical = ConvertTo-TuiCanonicalJson -Element $Document.RootElement
        if ($ExcludeRootProperty) {
            if ($Document.RootElement.ValueKind -ne [System.Text.Json.JsonValueKind]::Object) {
                throw 'Digest root must be an object / Digest-Wurzel muss ein Objekt sein'
            }
            $Parts = foreach ($Property in $Document.RootElement.EnumerateObject()) {
                if ($Property.Name -cne $ExcludeRootProperty) {
                    $Name = [System.Text.Json.JsonEncodedText]::Encode($Property.Name, [System.Text.Encodings.Web.JavaScriptEncoder]::UnsafeRelaxedJsonEscaping).ToString()
                    '"' + $Name + '":' + (ConvertTo-TuiCanonicalJson -Element $Property.Value)
                }
            }
            $WithoutDigest = [System.Text.Json.JsonDocument]::Parse('{' + ($Parts -join ',') + '}')
            try { $Canonical = ConvertTo-TuiCanonicalJson -Element $WithoutDigest.RootElement }
            finally { $WithoutDigest.Dispose() }
        }
        $Bytes = [Text.UTF8Encoding]::new($false, $true).GetBytes($Canonical + "`n")
        return [Convert]::ToHexString([Security.Cryptography.SHA256]::HashData($Bytes)).ToLowerInvariant()
    }
    finally { $Document.Dispose() }
}
