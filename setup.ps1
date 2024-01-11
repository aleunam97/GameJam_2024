#****************************************************************
#            Setup Script for the unity template
#****************************************************************

# Intro Setup
Write-Host "Setting up the project..."
Write-Host ""
Write-Host "This script will setup the project for you."
Write-Host ""
Write-Host "Please enter the following information:"
Write-Host "> Press enter to use the default value" -ForegroundColor DarkGray
Write-Host "> Use Ctrl+C to exit the script" -ForegroundColor DarkGray
Write-Host ""

# Exit function
function Exit-Script {
    Write-Host ""
    Write-Host "Setup aborted" -ForegroundColor Red
    Write-Host ""
    exit
}

# Set the name of the project (default is the name of the folder)
$LASTEXITCODE = 1
$defaultProjectName = (Get-Item $PSScriptRoot).Name
$defaultProjectName = $defaultProjectName -replace '[^a-zA-Z0-9]', ''
$projectName = Read-Host "Projectname [$defaultProjectName]"
if ($LASTEXITCODE -eq 0) { Exit-Script }
if ($projectName -eq "")  { $projectName = $defaultProjectName }
$projectName = $projectName -replace '[^a-zA-Z0-9]', ''

# Set namespace for the project
$LASTEXITCODE = 1
$defaultNamespace = $projectName
$namespace = Read-Host "Namespace [$defaultNamespace]"
if ($LASTEXITCODE -eq 0) { Exit-Script }
if ($namespace -eq "")  { $namespace = $defaultNamespace }
$namespace = $namespace -replace '[^a-zA-Z0-9.]', ''

# Clean up Template files
$LASTEXITCODE = 1
Write-Host ""
$cleanUp = Read-Host "Clean up template files (including this script) after setup? [y/N]"
if ($LASTEXITCODE -eq 0) { Exit-Script }
if ($cleanUp -eq "")  { $cleanUp = "N" }
if ($cleanUp -ne "Y" -and $cleanUp -ne "y" -and $cleanUp -ne "N" -and $cleanUp -ne "n") { Exit-Script }

# Write Start Message
Write-Host ""
Write-Host "Starting setup..." -ForegroundColor Green
Write-Host ""

# Replace placeholders in files
$fileNames = @(
    @("Template_FMOD/Template_FMOD.fspro", "${projectName}_FMOD.fspro"),
    @("Template_Unity/Template_Unity.sln", "${projectName}_Unity.sln"),
    @("Template_Builds", "${projectName}_Builds"),
    @("Template_Unity", "${projectName}_Unity"),
    @("Template_FMOD", "${projectName}_FMOD")
);

# Iterate over all files and rename them
foreach ($fileName in $fileNames) {
    $oldName = $fileName[0]
    $newName = $fileName[1]
    if (Test-Path $oldName) 
    {
        if (Test-Path $newName) 
        {
            Remove-Item $newName -Recurse -Force
        }
        Write-Host "Renaming $oldName to $newName"
        Rename-Item -Path $oldName -NewName $newName
    }
    else {
        Write-Host "[Skipped] File $oldName not found" -ForegroundColor DarkGray
    }
}

# Replace placeholders in files
$dynamicFileNames = @(
    @("${projectName}_Unity/${projectName}_Unity.jsproj", "productName: Template_Unity", "productName: ${projectName}"),
    @("${projectName}_Unity/${projectName}_Unity.jsproj", "metroPackageName: Template_Unity", "metroPackageName: ${projectName}"),
    @("${projectName}_Unity/${projectName}_Unity.jsproj", "metroApplicationDescription: Template_Unity", "metroApplicationDescription: ${projectName}"),
    @("${projectName}_FMOD/Metadata/Workspace.xml", "../Template_Unity", "../${projectName}_Unity")
);

# Iterate over all files replace all placeholders
foreach ($fileName in $dynamicFileNames) {
    $filePath = $fileName[0]
    $oldString = $fileName[1]
    $newString = $fileName[2]
    if (Test-Path $filePath) 
    {
        Write-Host "Replaced $oldString with $newString in $filePath"
        (Get-Content $filePath) | Foreach-Object { $_ -replace $oldString, $newString } | Set-Content $filePath
    }
    else {
        Write-Host "[Skipped] File $filePath not found" -ForegroundColor DarkGray
    }
}

# Clean up template files
if ($cleanUp -eq "Y" -or $cleanUp -eq "y") {
    $cleamUpFiles = @("setup.ps1", "setup.sh");
    foreach ($fileName in $cleamUpFiles) {
        if (Test-Path $fileName) 
        {
            Remove-Item $fileName -Force
        }
    }
    Write-Host ""
    Write-Host "Cleaned up template files"
    Write-Host ""
}

# Write Finish Message
Write-Host ""
Write-Host "Setup finished, Happy coding!" -ForegroundColor Green
Write-Host ""