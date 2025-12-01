param(
    [Parameter(Mandatory=$true)]
    [int]$day
)

$folder = "Day{0:D2}" -f $day
$projectFile = "$folder/$folder.csproj"

Write-Host "Creating $folder..."

# Create folder
New-Item -ItemType Directory -Force -Path $folder | Out-Null

# Create console project
dotnet new console -n $folder -o $folder

# Add to solution
dotnet sln add $projectFile

Write-Host "Day $day created and added to solution."
