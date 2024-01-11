#!/bin/bash

#****************************************************************
#           Custom Setup Script - Initialize Assemblies
#****************************************************************

# Parameters
rootPath=$1
projectName=$2
namespace=$3

# Cancel if no project name, namespace, or root path
if [ -z "$projectName" ]; then exit 0; fi
if [ -z "$namespace" ]; then exit 0; fi
if [ -z "$rootPath" ]; then exit 0; fi

# Definition
assemblyDefinitions=(
    "Scripts/$projectName.asmdef|$projectName|$namespace|LoM.Super,DOTween.Modules,FMODUnity,Unity.InputSystem,Unity.TextMeshPro,UnityEngine.UI|false"
    "Scripts/Editor/$projectName.Editor.asmdef|$projectName.Editor|$namespace.Editor|LoM.Super,LoM.Super.Editor,$projectName,FMODUnityEditor|true"
    "Plugins/LoM/Super/LoM.Super.asmdef|LoM.Super"
    "Plugins/LoM/Super/Editor/LoM.Super.Editor.asmdef|LoM.Super.Editor|LoM.Super|true"
    "Plugins/Demigiant/DOTween/Modules/DOTween.Modules.asmdef|DOTween.Modules"
)

# Start
echo ""
echo "Initializing Assemblies..."
echo ""

# Create Assemblies
for assemblyDefinition in "${assemblyDefinitions[@]}"; do
    IFS='|' read -ra ADDR <<< "$assemblyDefinition"
    unityPath="$rootPath/${projectName}_Unity/Assets/"
    assemblyPath="${unityPath}${ADDR[0]}"
    assemblyName=${ADDR[1]}
    assemblyRootNamespace=${ADDR[2]}
    assemblyReferences=(${ADDR[3]//,/ })
    assemblyEditorOnly=${ADDR[4]}
    
    echo "Creating Assembly: ${assemblyName}"
    
    # Create Assembly
    assemblyJson="{\n"
    assemblyJson+="	\"name\": \"$assemblyName\",\n"
    if [ ! -z "$assemblyRootNamespace" ]; then
        assemblyJson+="	\"rootNamespace\": \"$assemblyRootNamespace\",\n"
    fi
    if [ ! -z "$assemblyReferences" ]; then
        assemblyJson+="	\"references\": [\n"
        for reference in "${assemblyReferences[@]}"; do
            assemblyJson+="		\"$reference\",\n"
        done
        assemblyJson=$(echo -e "$assemblyJson" | sed '$ s/,$//')
        assemblyJson+="\n	],\n"
    fi
    if [ "$assemblyEditorOnly" = "true" ]; then
        assemblyJson+="	\"includePlatforms\": [\n"
        assemblyJson+="		\"Editor\"\n"
        assemblyJson+="	],\n"
    fi
    assemblyJson=$(echo -e "$assemblyJson" | sed '$ s/,$//')
    assemblyJson+="\n}"
    if [ -f "$assemblyPath" ]; then rm "$assemblyPath"; fi
    echo -e "$assemblyJson" > "$assemblyPath"
    
    # Generate GUID
    guid=$(uuidgen | tr '[:upper:]' '[:lower:]')
    
    # Create Assembly Definition
    assemblyMeta="fileFormatVersion: 2\n"
    assemblyMeta+="guid: $guid\n"
    assemblyMeta+="AssemblyDefinitionImporter:\n"
    assemblyMeta+="  externalObjects: {}\n"
    assemblyMeta+="  userData: \n"
    assemblyMeta+="  assetBundleName: \n"
    assemblyMeta+="  assetBundleVariant: "
    if [ -f "$assemblyPath.meta" ]; then rm "$assemblyPath.meta"; fi
    echo -e "$assemblyMeta" > "$assemblyPath.meta"
done

# Fix DOTween Settings
dotweenSettingsPath="$rootPath/${projectName}_Unity/Assets/Resources/DOTweenSettings.asset"
sed -i '' 's/createASMDEF: 0/createASMDEF: 1/' "$dotweenSettingsPath"