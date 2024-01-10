# Unity Template
[![Generic badge](https://img.shields.io/badge/LTS%202022.3.16f1-Unity-141414.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/2.02.19%20%28Unity%20Verified%29-FMOD-6dd0f6.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/1.2.745-DoTween-94de59.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/0.0.5-SuperBehaviour-a46ac3.svg)](https://shields.io/)
[![Generic badge](https://img.shields.io/badge/1.7.0-Input%20System-0476b7.svg)](https://shields.io/)

*This is not an official product of Unity Technologies, please see the Unity Trademark Guidelines for more information.*

| Table of Contents |
|:----------------- |
| [Features](#features) |
| [Folder Structure](#folder-structure) |
| [Installation for experienced users](#installation-for-experienced-users) |
| [Detailed Installation `Windows`](#detailed-installation-windows) |
| [Detailed Installation `Mac`](#detailed-installation-mac) |

## Features
- Pre-Setup FMOD Project with a basic test event and a basic mixer setup
- Important base packages installed (DoTween, SuperBehaviour, new Input System, etc)
- Basic folder structure
- Removed default assets
- Imported TextMeshPro
- Clean .gitignore setup

## Folder Structure
` Template_Unity ` Folder contains the Unity Project itself.
```bash
├── Assets
│   ├── Animations
│   ├── Audio
│   │   └── Banks
│   ├── Fonts
│   ├── Gizmos
│   ├── Materials
│   ├── Models
│   ├── Prefabs
│   │   ├── Core
│   │   ├── Managers
│   │   └── UI
│   ├── Resources
│   ├── Scenes
│   ├── Scripts
│   │   ├── Core
│   │   ├── Enums
│   │   ├── Editor
│   │   ├── Extensions
│   │   ├── Helpers
│   │   ├── Interfaces
│   │   ├── Managers
│   │   ├── Structs
│   │   └── UI
│   ├── Settings
│   ├── Shaders
│   ├── Sprites
│   ├── Textures
│   ├── Plugins
│   └── VFX
├── Packages
└── ProjectSettings
```

` Template_FMOD ` Folder contains the FMOD Project already linked with the Unity Project.
```bash
├── Assets
│   ├── _Placeholder
│   ├── Ambience
│   ├── Music
│   ├── SFX
│   └── UI
├── Metadata
└── Template_Fmod.fspro
```

` Template_Builds ` This folder can be used to store the builds of the project. (All its content is ignored by git)

## Installation for experienced users
1. Create a repository by importing the [unity-template](https://gitlab.com/hostur2/unity-template) repository
2. Clone the repository to your local machine
3. `Optional` Run the setup.sh / setup.ps1 script in the root folder to setup the project with your own name
4. Open the Unity Project and start working on your game

## Detailed Installation `Windows`

### Create Repository
*Choose the Git-Provider of your choice.*
#### GitLab (Recommended)
1. Open the official GitLab website ([https://gitlab.com](https://gitlab.com))
2. Sign-In or create a new account
3. Create a new project by clicking on the <kbd>New Project</kbd> button
4. Select the <kbd>Import project</kbd> tab
5. Select <kbd>Repository by URL</kbd> and enter `https://gitlab.com/hostur2/unity-template.git`
6. Fill out the form and click on the <kbd>Create project</kbd> button (You dont have to fill out Username and Password)

#### GitHub
1. Open the official GitHub website ([https://github.com](https://github.com))
2. Sign-In or create a new account
3. Create a new repository by clicking on the <kbd>New</kbd> button
4. Select the tiny <kbd>Import a repository</kbd> link
5. Enter `https://gitlab.com/hostur2/unity-templat` into the <kbd>Your old repository’s clone URL</kbd> field
6. Enter your repository name and click <kbd>Begin import</kbd>

### Setup Git and clone the repository
*Git is a free and open source distributed version control system designed to handle everything from small to very large projects with speed and efficiency. It allows you to keep track of your code changes and revert them if needed. It's a very important tool for any developer especially if you are working in a team.*
1. Download the git scm from the official website ([https://git-scm.com](https://git-scm.com/download/win))
2. Execute the installer and skip through the installation process (You can leave everything as default)
3. After installing git locate the folder where you want to store your projects
4. Right click on the folder and select `Git Bash Here`
5. Enter the following command to clone the repository `git clone YOUR_REPOSITORY_URL`
(This will create a new folder called `unity-template` and download the repository into it)

> The repository URL can be found on the repository page under the <kbd>Clone</kbd> button and looks like this `https://gitlab.com/USERNAME/GROUP/REPONAME.git`

### Setup Project
1. Search for `PowerShell` in the windows search bar and open it
2. Navigate to the `unity-template` folder by using the `cd` command
   - For example `cd C:\Users\Steve\Documents\unity-template`
3. If you never used a PowerShell script before you need to allow the execution of scripts by entering `Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Scope CurrentUser`
4. Run the setup script by entering `.\setup.ps1`
5. Follow the instructions in the script (allways choose the default option by pressing enter)
6. After the script finished you can close the PowerShell window

### Setup Unity
1. Download Unity Hub from the official website ([https://unity3d.com/get-unity/download](https://unity3d.com/get-unity/download))
2. Execute the installer and skip through the installation process (You can leave everything as default)
3. After installing Unity Hub open it and go to the `Installs` tab
4. Select the `Unity 2020.3.16f1 (LTS)` version and install it
5. In the following dialog add all platforms you want to build for (You can add more later) and if you are using VSCode (Recommended) remove the "Microsoft Visual Studio Community" from the list

### Setup FMOD
1. Open the official FMOD Studio website ([https://www.fmod.com/download](https://www.fmod.com/download))
2. Sign-In or create a new account (It's free but you need to have an account to download FMOD)
3. Download the **FMOD Studio** Installer for <kbd>v2.02.19 (Unity Verified)</kbd>
4. Execute the installer and skip through the installation process (You can leave everything as default)
5. Open the Folder `Template_FMOD` in FMOD Studio

### Setup VSCode (Optional)
*VSCode is a free and open source code editor. It's a very powerful tool and has a lot of extensions to make your life easier. Compared to the legacy Visual Studio it's a lot faster and easier to use. It does need a bit of setup to work with Unity but it's worth it.*
1. Download VSCode from the official website ([https://code.visualstudio.com](https://code.visualstudio.com))
2. Execute the installer and skip through the installation process (You can leave everything as default)
3. After installing VSCode open it and go to the extensions tab <kbd>Ctrl+Shift+X</kbd>
4. Install following Extensions:
    - [SuperBehaviour](https://marketplace.visualstudio.com/items?itemName=lom.superbehaviour) (Recommended)
    - or
    - [Unity Tools](https://marketplace.visualstudio.com/items?itemName=Tobiah.unity-tools), [Unity Code Snippets](https://marketplace.visualstudio.com/items?itemName=kleber-swf.unity-code-snippets) and [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
5. After installing the extensions close VSCode download the `.NET Framework 4.7.1` (has to be this exact version) from the official website ([https://dotnet.microsoft.com/en-us/download/dotnet-framework/net471](hthttps://dotnet.microsoft.com/en-us/download/dotnet-framework/net471))
6. Restart your PC
7. Open the Unity Project and go to `Edit > Preferences > External Tools`
8. Set the "External Script Editor" to "Visual Studio Code"
9. Set the "External Script Editor Args" to `-n -g "$(File)":$(Line):$(Column)`
10. Press the <kbd>Regenerate Project Files</kbd> button
11. Open the VSCode project folder by going to `File > Open Folder` and selecting the `Template_Unity` folder

## Detailed Installation `Mac`

### Create Repository
*Choose the Git-Provider of your choice.*
#### GitLab (Recommended)
1. Open the official GitLab website ([https://gitlab.com](https://gitlab.com))
2. Sign-In or create a new account
3. Create a new project by clicking on the <kbd>New Project</kbd> button
4. Select the <kbd>Import project</kbd> tab
5. Select <kbd>Repository by URL</kbd> and enter `https://gitlab.com/hostur2/unity-template.git`
6. Fill out the form and click on the <kbd>Create project</kbd> button (You dont have to fill out Username and Password)

#### GitHub
1. Open the official GitHub website ([https://github.com](https://github.com))
2. Sign-In or create a new account
3. Create a new repository by clicking on the <kbd>New</kbd> button
4. Select the tiny <kbd>Import a repository</kbd> link
5. Enter `https://gitlab.com/hostur2/unity-templat` into the <kbd>Your old repository’s clone URL</kbd> field
6. Enter your repository name and click <kbd>Begin import</kbd>

### Setup Git and clone the repository
*Git is a free and open source distributed version control system designed to handle everything from small to very large projects with speed and efficiency. It allows you to keep track of your code changes and revert them if needed. It's a very important tool for any developer especially if you are working in a team.*
1. Download the git scm from the official website ([https://git-scm.com](https://git-scm.com/download/mac))
2. Execute the installer and skip through the installation process (You can leave everything as default)
3. After installing git locate the folder where you want to store your projects
4. Right click on the folder and select `New Terminal at Folder`
5. Enter the following command to clone the repository `git clone https://gitlab.com/hostur2/unity-template`

### Setup Project
1. Open the Terminal and navigate to the `unity-template` folder by using the `cd` command
   - For example `cd /Users/Steve/Documents/unity-template`
2. Run the setup script by entering `./setup.sh`
3. Follow the instructions in the script (allways choose the default option by pressing enter)
4. After the script finished you can close the Terminal window

### Setup Unity
1. Download Unity Hub from the official website ([https://unity3d.com/get-unity/download](https://unity3d.com/get-unity/download))
2. Run the downloaded file and move it to your Applications folder
3. Open Unity Hub and go to the `Installs` tab
4. Select the `Unity 2020.3.16f1 (LTS)` version and install it
5. In the following dialog add all platforms you want to build for (You can add more later) and if you are using VSCode (Recommended) remove the "Microsoft Visual Studio Community" from the list

### Setup FMOD
1. Open the official FMOD Studio website ([https://www.fmod.com/download](https://www.fmod.com/download))
2. Sign-In or create a new account (It's free but you need to have an account to download FMOD)
3. Download the **FMOD Studio** Installer for <kbd>v2.02.19 (Unity Verified)</kbd>
4. Execute the installer and skip through the installation process (You can leave everything as default)
5. Open the Folder `Template_FMOD` in FMOD Studio

### Setup VSCode (Optional)
*VSCode is a free and open source code editor. It's a very powerful tool and has a lot of extensions to make your life easier. Compared to the legacy Visual Studio it's a lot faster and easier to use. It does need a bit of setup to work with Unity but it's worth it.*
1. Download VSCode from the official website ([https://code.visualstudio.com](https://code.visualstudio.com))
2. Run the downloaded file and move it to your Applications folder
3. After installing VSCode open it and go to the extensions tab <kbd>Ctrl+Shift+X</kbd>
4. Install following Extensions:
    - [SuperBehaviour](https://marketplace.visualstudio.com/items?itemName=lom.superbehaviour) (Recommended)
    - or
    - [Unity Tools](https://marketplace.visualstudio.com/items?itemName=Tobiah.unity-tools), [Unity Code Snippets](https://marketplace.visualstudio.com/items?itemName=kleber-swf.unity-code-snippets) and [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
5. After installing the extensions close VSCode download the `.NET Framework 4.7.1` (has to be this exact version) from the official website ([https://dotnet.microsoft.com/en-us/download/dotnet-framework/net471](hthttps://dotnet.microsoft.com/en-us/download/dotnet-framework/net471))
6. Open the Unity Project and go to `Edit > Preferences > External Tools`
7. Set the "External Script Editor" to "Visual Studio Code"
8. Set the "External Script Editor Args" to `-n -g "$(File)":$(Line):$(Column)`
9. Press the <kbd>Regenerate Project Files</kbd> button
10. Open the VSCode project folder by going to `File > Open Folder` and selecting the `Template_Unity` folder