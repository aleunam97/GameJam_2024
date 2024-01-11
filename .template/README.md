# Optional Setup Instructions
All content of the custom setup instruction should be placed in a own folder in the .template folder. The name of the folder defines the name displayed in the setup script. The setup scripts should be named setup.sh and setup.ps1 (Having both is a MUST).

## Parameters
Following parameters will be passed to the setup scripts:
- $1: The path to the root folder of the project
- $2: Name of the project
- $3: Namespace of the project

## Questions
Place a question.md file if you want to define the question displayed to the user when starting the setup script. (Otherwise the name of the folder will be used as question)