#!/bin/bash

#****************************************************************
#            Setup Script for the unity template
#****************************************************************

# Intro Setup
echo "Setting up the project..."
echo ""
echo "This script will setup the project for you."
echo ""
echo "Please enter the following information:"
echo "> Press enter to use the default value"
echo "> Use Ctrl+C to exit the script"
echo ""

# Exit function
function exit_script {
    echo ""
    echo "Setup aborted"
    echo ""
    exit
}

# Trap CTRL+C (SIGINT) to execute the exit function
trap exit_script SIGINT

# Set the name of the project (default is the name of the folder)
defaultProjectName=$(basename "$PWD")
defaultProjectName=${defaultProjectName//[^a-zA-Z0-9]/}
read -p "Projectname [$defaultProjectName]: " projectName
projectName=${projectName:-$defaultProjectName}
projectName=${projectName//[^a-zA-Z0-9]/}

# Set namespace for the project
defaultNamespace=$projectName
read -p "Namespace [$defaultNamespace]: " namespace
namespace=${namespace:-$defaultNamespace}
namespace=${namespace//[^a-zA-Z0-9.]/}

# Clean up Template files
read -p "Clean up template files (including this script) after setup? [y/N]: " cleanUp
cleanUp=${cleanUp:-N}

# Optional Setup Instructions
instructionDir="$PWD/.template"
declare -a instructions

for instructionPath in "$instructionDir"/*; do
    if [ -d "$instructionPath" ]; then
        instructionName=$(basename "$instructionPath")
        questionPath="$instructionPath/question.md"
        scriptPath="$instructionPath/setup.sh"
        if [ -f "$questionPath" ]; then
            question=$(<"$questionPath")
            instructions+=("$instructionName|$scriptPath|$question [y/N]|false")
        else
            instructions+=("$instructionName|$scriptPath|Do you want to setup $instructionName? [y/N]|false")
        fi
    fi
done

# Iterate over all instructions and ask the user if he wants to execute them
for i in "${!instructions[@]}"; do
    IFS='|' read -r -a instruction <<< "${instructions[$i]}"
    echo ""
    read -p "${instruction[2]} " instructionExecute
    instructionExecute=${instructionExecute:-N}
    if [[ $instructionExecute == "Y" || $instructionExecute == "y" ]]; then
        instructions[$i]="${instruction[0]}|${instruction[1]}|${instruction[2]}|true"
    fi
done

# Write Start Message
echo ""
echo "Starting setup..."
echo ""

# Replace placeholders in files
fileNames=(
    "Template_FMOD/Template_FMOD.fspro $projectName""_FMOD.fspro"
    "Template_Unity/Template_Unity.sln $projectName""_Unity.sln"
    "Template_Builds $projectName""_Builds"
    "Template_Unity $projectName""_Unity"
    "Template_FMOD $projectName""_FMOD"
)

# Iterate over all files and rename them
for item in "${fileNames[@]}"; do
    oldName=$(echo $item | cut -d' ' -f1)
    newName=$(echo $item | cut -d' ' -f2)
    if [ -e "$oldName" ]; then
        if [ -e "$newName" ]; then
            rm -rf "$newName"
        fi
        echo "Renaming $oldName to $newName"
        mv "$oldName" "$newName"
    else
        echo "[Skipped] File $oldName not found"
    fi
done

# Replace placeholders in files
dynamicFileNames=(
    "$projectName""_Unity/$projectName""_Unity.jsproj productName: Template_Unity productName: $projectName"
    "$projectName""_Unity/$projectName""_Unity.jsproj metroPackageName: Template_Unity metroPackageName: $projectName"
    "$projectName""_Unity/$projectName""_Unity.jsproj metroApplicationDescription: Template_Unity metroApplicationDescription: $projectName"
    "$projectName""_FMOD/Metadata/Workspace.xml ../Template_Unity ../$projectName""_Unity"
)

# Iterate over all files replace all placeholders
for item in "${dynamicFileNames[@]}"; do
    filePath=$(echo $item | cut -d' ' -f1)
    oldString=$(echo $item | cut -d' ' -f2)
    newString=$(echo $item | cut -d' ' -f3)
    if [ -e "$filePath" ]; then
        echo "Replaced $oldString with $newString in $filePath"
        sed -i '' "s/$oldString/$newString/g" "$filePath"
    else
        echo "[Skipped] File $filePath not found"
    fi
done

# Run optional setup instructions
for i in "${instructions[@]}"; do
    IFS='|' read -r -a instruction <<< "$i"
    if [[ ${instruction[3]} == "true" ]]; then
        echo "Executing ${instruction[0]} at ${instruction[1]}"
        bash "${instruction[1]}" "$PWD" "$projectName" "$namespace"
    fi
done

# Clean up template files
if [[ $cleanUp == "Y" || $cleanUp == "y" ]]; then
    cleanUpFiles=("setup.ps1" "setup.sh")
    for fileName in "${cleanUpFiles[@]}"; do
        if [ -e "$fileName" ]; then
            rm "$fileName"
        fi
    done
    echo ""
    echo "Cleaned up template files"
    echo ""
fi

# Write Finish Message
echo ""
echo "Setup finished, Happy coding!"
echo ""