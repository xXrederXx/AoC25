param(
    [Parameter(Mandatory=$true)]
    [int]$day
)

$folder = "Day{0:D2}" -f $day
$projectFile = "$folder/$folder.csproj"

if (-Not (Test-Path $projectFile)) {
    Write-Host "Error: Project for day $day does not exist. Did you generate it?" -ForegroundColor Red
    exit 1
}

Write-Host "Running Advent of Code Day $day..." -ForegroundColor Cyan

Push-Location $folder
dotnet run
Pop-Location
