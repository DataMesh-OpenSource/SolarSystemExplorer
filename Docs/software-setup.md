## Overview

MeshExpert Live! requires hardware drivers and MeshExpert software to be installed. This guide will show you step-by-step how to to this.

## Environment

Please make sure you have **Windows 10 pro** and above as operating system. The Windows 10 Home Edition is not suitable for developing purpose. 

>  For Windows 10 versions, we recommend the [Creators Update (ver.1703)](https://support.microsoft.com/en-us/help/4028685/windows-get-the-windows-10-creators-update) or above if you are planning to install Windows 10 or can upgrade it. 

Make sure you have properly set up your basic desktop environment like installing mainboard drivers.

## Hardware Drivers

For this guide, we use the **BlackMagic Capture Card** and **NVIDIA GeForce GTX 10 series video card**. For other cards, please install proper drivers yourself.

### Driver for BlackMagic Capture Card

Go to [BlackMagic Download Page](https://www.blackmagicdesign.com/support/family/capture-and-playback) to checkout the latest driver version for the capture card. The latest version is always preferred. If you have any trouble getting the video feed, one of the most important trouble shooting step is to update the driver to the newest.

> For now (10/13/2017), the newest version is 10.9.7 for Windows. Here is the direct [download link](https://meshexpert-us.s3.amazonaws.com/Blackmagic_Desktop_Video_Windows_10.9.7.zip).

### Driver for NVIDIA GeForce Video Card

Go to [NVIDIA Driver Search Page](http://www.nvidia.com/Download/index.aspx) to find the latest driver for your video card. The latest version is always preferred.

> For now (10/13/2017), the newest version for GeForce GTX cards is 387.92 for Windows 10 64-bit. Here is the direct [download link](http://us.download.nvidia.com/Windows/387.92/387.92-desktop-win10-64bit-international-whql.exe).

### Test Capture Card

To make sure the capture card and its drivers are properly installed, after restart you can use the **Blackmagic Media Express** software from the Windows Start Menu to test. If ok, there would be a live stream displayed under the "Log and Capture" tab.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31533366-68a86ee0-b024-11e7-8a9f-d99a283089c5.jpg" width="600">
<p align="center"><em>BlackMagic Media Express</em></p>
</p>

## Develop Environment

This step is optional if just want to try SolarSystemExplorer instead of compiling it or creating your own app. You can skip this step and download and install the compiled apps. However, we **do recommend you to install the Windows 10 SDK** (which can be selected to install during Visual Studio installation) to enable debugging by connecting to your HoloLens. If you only want to install Windows 10 SDK without installing Visual Studio, download and install from [here](https://developer.microsoft.com/en-us/windows/downloads/windows-10-sdk).

### Unity

Please use Unity 5.5 or later to develop your apps. (**Unity 5.5.1** is recommended. Unity 5.6.x and Unity 2017 may have some compatibility issues).

Download and run the *Unity Download Assistant* (For Unity 5.5.1, you can use [this link](https://download.unity3d.com/download_unity/88d00a7498cd/UnityDownloadAssistant-5.5.1f1.exe) to download). For UWP support, make sure you check the "Windows Store .NET Scripting Backend" entry during the installation (default is checked).

<p align="center">
<img src="https://user-images.githubusercontent.com/27760601/31529984-8f5a7e58-b00f-11e7-85b8-ce7e46b66fc1.png" width="400">
<p align="center"><em>Unity Installation</em></p>
</p>

> **Note:** You can search and download Unity Versions [here](https://unity3d.com/get-unity/download/archive). For detailed installation and usage of Unity, check out the [Unity Documentation](https://docs.unity3d.com/Manual/index.html).

### Visual Studio

What you need is Visual Studio 2015 Community V3 or later. Currently we recommend vs2015. For online installation of vs2015 V3, use [this installer](https://meshexpert-us.s3.amazonaws.com/en_visual_studio_community_2015_with_update_3_x86_x64_web_installer_8922963.exe).

> **Note 1:** For complete ISO installation file or other Visual Studio versions, go to [Visual Studio Site](https://my.visualstudio.com/Downloads). You can download community version with a free subscription.

> **Note 2:** Make sure you check the Windows 10 SDK during the installation, otherwise you can not connect to HoloLens to debug your applications.

## MeshExpert Software

To understand how the MeshExpert Live! works and what software to install, see the drawing below. There are essential three major software to install or run:

* **MeshExpert Installer:** It includes the **MeshExpert Server** and **MeshExpert Center**. The Center is for: 1) manage service status (e.g. start/restart server) and license, 2) add and manage HoloLens, 3) upload and install apps to HoloLens and app configuration management , 4) other extended functionalities like connecting to DataMesh cloud service. The Server is responsible to cross-device collaboration by broadcasting messages among PC, HoloLens, Surface, etc.
* **DataMesh LiveAgent:** It is running on HoloLens on the Rig. It is constantly sending anchor information to the App you are running (e.g. the SolarSystemExplorer PC app) for the holographic video synthesis.
* **Your App**: Take SolarSystemExplorer as an example. You can build your app in Unity and compile it against different platforms. Then you will get the PC version, HoloLens version, and the Surface version. Through collaboration mechanism provided by MeshExpert Server, they can share the same MR experience. For example, during MR video capturing, you can control the movements from a Surface or another HoloLens.



<p align="center">
<img src="https://user-images.githubusercontent.com/27760601/31540251-bec530b0-b03d-11e7-8018-8a0934bb4b5d.png" width="1024"><p align="center"><em>Software Stack</em></p>

</p>

### MeshExpert Installer

To install the MeshExpert Server and MeshExpert Center, download the [MeshExpert Installer](https://www.datamesh.com/downloaditem-melive) and double click to install. Note that you need Administrative privilege.

Upon finish, you will have **MeshExpert Center** icon on your desktop and start menu under DataMesh entry.

### DataMesh LiveAgent

Download the latest version from [here](https://www.datamesh.com/downloaditem-liveagent). To install it to the HoloLens on the Rig, you can either use the MeshExpert Center to do easy installation and configuration, or use the Windows Device Portal to do it manually.

### SolarSystemExplorer App

For demo, you can just download the [compiled apps](https://github.com/DataMesh-OpenSource/SolarSystemExplorer/releases) and move on to the next section to configure and run.

If you are a developer and dive deeper, you can get the source code from this [Github Repository](https://github.com/DataMesh-OpenSource/SolarSystemExplorer) and follow the step-by-step [tutorials](https://github.com/DataMesh-OpenSource/SolarSystemExplorer#make-your-own-app) to build your first app with MeshExpert and then move on to the full SolarSystemExplorer app.

#### Install HoloLens Version



#### Install PC Version

You can download and run PC version directly. No installation needed.

#### Install Surface Version (Optional)

This is optional if you do not need to use Surface to control the interactions.

<p align="center">
<img src="https://user-images.githubusercontent.com/27760601/31604249-51b0dd9e-b295-11e7-98e3-6d0fb4bccf0a.png" width="800">

<p align="center"><em>Install Surface Version</em></p>

</p>

Click to run the **Add-AppDevPackage.ps1** script. You will be prompted to confirm and continue.

<p align="center">
<img src="https://user-images.githubusercontent.com/27760601/31604419-cc97b438-b295-11e7-83a6-d8d5ff189101.png" width="600">

<p align="center"><em>Surface App Installation Process</em></p>

</p>