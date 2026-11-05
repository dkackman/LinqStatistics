# Regenerates every T4 template (*.tt) in src/LinqStatistics and normalizes the
# output so it matches what Visual Studio's TextTemplatingFileGenerator produced:
#   - whitespace-only lines become empty lines
#   - trailing whitespace is removed
#   - files are written as UTF-8 with a BOM
#
# Usage: scripts/transform-t4.ps1
# Requires the .NET SDK; dotnet-t4 is pinned in the repo's dotnet-tools.json.
# Works with Windows PowerShell 5.1 and PowerShell 7+.
$ErrorActionPreference = 'Stop'

$repoRoot = Split-Path -Parent $PSScriptRoot
$templateDir = Join-Path $repoRoot 'src/LinqStatistics'

Push-Location $repoRoot
try {
    dotnet tool restore | Out-Null
    if ($LASTEXITCODE -ne 0) { throw 'dotnet tool restore failed' }

    $templates = @(Get-ChildItem -Path $templateDir -Filter '*.tt' -File)
    if ($templates.Count -eq 0) {
        throw "No .tt templates found in $templateDir"
    }

    $utf8Bom = New-Object System.Text.UTF8Encoding($true)
    $failed = $false
    foreach ($tt in $templates) {
        $out = [System.IO.Path]::ChangeExtension($tt.FullName, '.cs')
        dotnet t4 $tt.FullName -o $out
        if ($LASTEXITCODE -ne 0) {
            Write-Error "FAILED: $($tt.FullName)" -ErrorAction Continue
            $failed = $true
            continue
        }
        # ReadAllText drops any BOM; strip trailing whitespace (keeping the
        # existing line endings), then write back with a single BOM.
        $text = [System.IO.File]::ReadAllText($out)
        $text = [regex]::Replace($text, '(?m)[ \t]+(?=\r?$)', '')
        [System.IO.File]::WriteAllText($out, $text, $utf8Bom)
    }

    if ($failed) { exit 1 }
    Write-Host "Transformed $($templates.Count) templates."
}
finally {
    Pop-Location
}
