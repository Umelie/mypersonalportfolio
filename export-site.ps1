param([string]$Url = "http://localhost:5000/")

# 1. start with a clean docs folder
if (Test-Path docs) { Remove-Item docs -Recurse -Force }
New-Item -ItemType Directory -Force docs\css, docs\js | Out-Null

# 2. download the rendered page from the running app
curl.exe -s -o docs\index.html $Url
if ($LASTEXITCODE -ne 0) { throw "Could not reach $Url. Is the app running (dotnet run)?" }

# 3. copy only the files the page uses
Copy-Item wwwroot\css\portfolio.css docs\css\
Copy-Item wwwroot\js\slider.js docs\js\
Copy-Item wwwroot\img docs\img -Recurse

# 4. make links relative and remove the random fingerprints .NET adds
$html = Get-Content docs\index.html -Raw -Encoding UTF8
$html = $html -replace '(href|src)="/', '$1="'
$html = $html -replace '\.[a-z0-9]{10}\.(css|js|jpg|jpeg|png|gif|webp|svg)\b', '.$1'
Set-Content docs\index.html $html -Encoding UTF8

# 5. check every local file the page links to exists (case-sensitive, like GitHub)
$missing = 0
[regex]::Matches($html, '(?:src|href)="((?:css|js|img)/[^"]+)"') | ForEach-Object {
    $rel  = $_.Groups[1].Value
    $dir  = Join-Path docs (Split-Path $rel -Parent)
    $name = Split-Path $rel -Leaf
    if (-not ((Get-ChildItem $dir -Name) -ccontains $name)) {
        Write-Host "MISSING (check spelling and upper/lower case): $rel" -ForegroundColor Red
        $missing++
    }
}
if ($missing -eq 0) { Write-Host "All CSS, JS and image files found." -ForegroundColor Green }