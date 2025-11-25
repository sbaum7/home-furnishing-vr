# Home-Furnishing-VR
UNO Computer Science Capstone Project collaboration with QLI Omaha 

Home Furnishing VR is a VR application designed to help with rehabilitation in physical therapy clients through an interactive gameplay. The VR application will allow the player (client) to drag and drop pieces of furniture into their corresponding locations. Player have the option of choosing different settings, ranging from the diffulty and room types, to enabling hints.

# Installation and Setup 
To run Home Furnishing VR, you'll need a VR-ready PC and a Meta Quest 2 headset, as well as link cable or USB-C connection. The game can be launched directly from Unity or as a standalone build

## Unity Installation 
MacOS/Windows/Linux

Install the latest Unity LTS version (2022.3 or newer) with:

Android Build Support

OpenXR Plugin

Windows Build Support

## Launching game as standalone (not finalized yet)
Enable developer mode in Meta Quest mobile app

Connect headset to PC

Install the APK similar to adb install home-furnishing-vr.apk

# Milestone 1 Release Notes 

 

Menu 

	- Menu features difficulties 

	- Checkbox for hints added 

	- Start game button added 

 

Grabbable Objects 

	- The objects in our living room scene are grabbable in a VR environment 

	- utilizing XR Interaction Toolkit 

 

Movement 

	- Movement around scene 

	- Gravity implemented 

 

Consistency with Milestone 1 

Done: M1 - Planning, Project scope, GitHub setup, Unity initialized 

Features not yet implemented: Logic for hint and quit button not implemented yet. The script InGameMenuManager.cs in menu-v1 is not yet working. This menu will be for pausing and playing the game within the different room scenes. 

# Milestone 2 Release Notes 

Features implemented separately but not yet integrated
	- Furniture Tabs 
	- Snap Hooks
	- Movement and Grabbable Objects


# Milestone 3 Release Notes 

Features implemented separately but not yet integrated
	- Pause Menu
	- Modified snap turning and teleportation for movement
	- Starting scene logic and initial item placement logic within room

The above features can be found in these branches: living-room-matching-v1, pause-menu, snap-hooks













