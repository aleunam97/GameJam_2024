#****************************************************************
#           Custom Setup Script - Initialize Assembies
#****************************************************************

# Parameters 
$rootPath = $args[0]
$projectName = $args[1]
$namespace = $args[2]

# Cancel if no project name, namespace, or root path
if (!$projectName) { return }
if (!$namespace) { return }
if (!$rootPath) { return }

# Definition
$assemblyDefinitions = @(
    @{ 
        Path = "Scripts/$projectName.asmdef"; 
        Name = $projectName; 
        RootNamespace = $namespace; 
        References = @(
            "LoM.Super",
            "DOTween.Modules",
            "FMODUnity",
            "Unity.InputSystem",
            "Unity.TextMeshPro",
            "UnityEngine.UI"
        );
        EditorOnly = $false;
    },
    @{ 
        Path = "Scripts/Editor/$projectName.Editor.asmdef";
        Name = "$projectName.Editor";
        RootNamespace = "$namespace.Editor";
        References = @(
            "LoM.Super",
            "LoM.Super.Editor",
            "$projectName",
            "FMODUnityEditor"
        );
        EditorOnly = $true;
    },
    @{ 
        Path = "Plugins/LoM/Super/LoM.Super.asmdef";
        Name = "LoM.Super";
    },
    @{ 
        Path = "Plugins/LoM/Super/Editor/LoM.Super.Editor.asmdef";
        Name = "LoM.Super.Editor";
        References = @(
            "LoM.Super"
        );
        EditorOnly = $true;
    },
    @{
        Path = "Plugins/Demigiant/DOTween/Modules/DOTween.Modules.asmdef";
        Name = "DOTween.Modules";
    }
)

# Start 
Write-Host ""
Write-Host "Initializing Assemblies..."
Write-Host ""

# Create Assemblies
foreach ($assemblyDefinition in $assemblyDefinitions) {
    $unityPath = Join-Path $rootPath "\${projectName}_Unity\Assets\"
    $assemblyPath = Join-Path $unityPath $assemblyDefinition.Path
    $assemblyName = $assemblyDefinition.Name
    $assemblyRootNamespace = $assemblyDefinition.RootNamespace
    $assemblyReferences = $assemblyDefinition.References
    $assemblyEditorOnly = $assemblyDefinition.EditorOnly
    
    Write-Host "Creating Assembly: ${assemblyName}"
    
    # Create Assembly
    $assemblyJson = "{`n"
    $assemblyJson += "	`"name`": `"$assemblyName`",`n"
    if ($assemblyRootNamespace) {
        $assemblyJson += "	`"rootNamespace`": `"$assemblyRootNamespace`",`n"
    }
    if ($assemblyReferences) {
        $assemblyJson += "	`"references`": [`n"
        foreach ($reference in $assemblyReferences) {
            $assemblyJson += "		`"${reference}`",`n"
        }
        $assemblyJson = $assemblyJson.TrimEnd(",`n")
        $assemblyJson += "`n	],`n"
    }
    if ($assemblyEditorOnly) {
        $assemblyJson += "	`"includePlatforms`": [`n"
        $assemblyJson += "		`"Editor`"`n"
        $assemblyJson += "	],`n"
    }
    $assemblyJson = $assemblyJson.TrimEnd(",`n")
    $assemblyJson += "`n}"
    if (Test-Path $assemblyPath) { Remove-Item $assemblyPath -Force }
    New-Item -Path $assemblyPath -ItemType File -Force | Out-Null
    $assemblyJson | Out-File $assemblyPath -Encoding utf8
    
    # Generate GUID
    $guid = [guid]::NewGuid().ToString("N")
    
    # Create Assembly Definition
    $assemblyMeta = "fileFormatVersion: 2`n"
    $assemblyMeta += "guid: $guid`n"
    $assemblyMeta += "AssemblyDefinitionImporter:`n"
    $assemblyMeta += "  externalObjects: {}`n"
    $assemblyMeta += "  userData: `n"
    $assemblyMeta += "  assetBundleName: `n"
    $assemblyMeta += "  assetBundleVariant: "
    if (Test-Path "$assemblyPath.meta") { Remove-Item "$assemblyPath.meta" -Force }
    New-Item -Path "$assemblyPath.meta" -ItemType File -Force | Out-Null
    $assemblyMeta | Out-File "$assemblyPath.meta" -Encoding utf8
}

# Fix DOTween Settings
$dotweenSettingsPath = Join-Path $rootPath "\${projectName}_Unity\Assets\Resources\DOTweenSettings.asset"
$dotweenSettings = Get-Content $dotweenSettingsPath
$dotweenSettings = $dotweenSettings -replace "createASMDEF: 0", "createASMDEF: 1"
$dotweenSettings | Out-File $dotweenSettingsPath -Encoding utf8