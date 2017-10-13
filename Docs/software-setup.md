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

MeshExpert Live! contains two main parts: collaboration, and live streaming. The collaboration within multiple devices are coordinated by **MeshExpert Server** which broadcasts messages using a simple protocol. For live video streaming, the App running on the Workstation takes the real-time anchor from the **MeshExpert LiveAgent** running on HoloLens on the Rig, and synthesizes the holographic videos. The live video stream can output to screens through HDMI interface or be captured to video files.

## RIG Installation

The Rig is used for obtaining the real-world images and location information and further delivering them to the workstation in order to carry out real-time synthesis.

MeshExpert Live! Rig consists of the following **main components**:

* Digital camera/video camera
* HoloLens
* Tripod
* Accessories for fixing

> Note: HoloLens here is responsible for providing location information. You can replace it with other devices which also can provide position information. Besides, HoloLens can be removed if you don't need real-time synchronization of location information, such as fixing the camera stand.

### Rig Assembly

The purpose of the assembly is to securely secure the complete set of equipment together to minimize the effects of unstable factors such as shaking.
Depending on the requirements of the working site and the choice of equipment, the ways of assembly and connection may vary. If you want to use non-recommended equipment, please make sure that you know how to connect them together.
Below is a typical example of the assembly.

|         item          | Function                                 | specification                            |
| :-------------------: | :--------------------------------------- | :--------------------------------------- |
|  **HoloLens stand**   | Fix HoloLens firmly                      | Aluminium stand offered by DataMesh      |
|  **Digital camera**   | Hot shoe interface for the the convenience of connecting HoloLens | One possible choice is the Sony ICLE-6500 + EPZ 16-50 |
|    **Tripod/head**    | Support camera and HoloLens firmly       |                                          |
| **Other accessories** | Camera can connect to HoloLens through hot shoe interface | Screws for hot shoe switch               |


The assembly processes of Rig Suite depicted in the picture below, and the steps are as follows:

1. Fix HoloLens on the dedicated **Aluminum HoloLens Bracket**.
2. Add the **Hotshoe Adapter** to the HoloLens mount in Step 1 (to later in Step 5, connect the HoloLens mount to the camera).
3. Connect the **Camera** to the **Tripod**.
4. Fix the **Hotshoe Fastener** to the **Camera**.
5. Finally, connect the **HoloLens Mount** and the **Camera** by connecting the **Hotshoe Adapter** and the  **Hotshoe Fastener**.

<p align="center">
<img src="https://cloud.githubusercontent.com/assets/17921380/26623976/0ef5370a-4622-11e7-8cdd-0e59c8ceebee.png" width="160">
<p align="center"><em>RIG Assembly Diagram</em></p>
</p>

> If you are looking for a shopping list of the Rig parts, here is one possible choice in the [Rig Shopping List](#rig-shopping-list).


## Workstation Installation

### Hardware Requirements

The workstation requires a certain amount of computing power, which could be satisfied by hardware sets of the given specifications, to meet the demands of MeshExpert Live!. There would also be some restrictions regarding the hardware and software choices.
Below is a list of recommended requirements for the workstation:

|         Item         |              Specification               | Remark                                   |
| :------------------: | :--------------------------------------: | :--------------------------------------- |
|       **CPU**        | Intel Skylake 6700K or above OR AMD Ryzen 1700X or above |                                          |
|       **GPU**        |     NVIDIA GeForce GTX 1070 or above     | <ul><li>GPU needs to support NVENC (Hardware-Accelerated Video Encoding) encoding APIs for H.264.</li><li>AMD GPUs currently are not supported.</li></ul> |
|    **Mainboard**     |       Support M.2 SSD or PCI-E SSD       | <ul><li>Note that the mainboard **must have** one extra PCI-E x16 slot for capture card.</li></ul> |
|      **Memory**      |     16GB dual-channel DDR4 or above      |                                          |
| **Operating system** |              Windows 10 x64              | <ul><li>Only 64bit system is supported.</li><li>Windows 7/8 and Windows Server editions are not supported.</li><li>Windows 10 Pro version and above are required for development.</li></ul> |
|    **Hard disk**     |        500GB M.2 SSD or PCIE SSD         | <ul><li>Recommend SAMSUNG 850 EVO 500G M.2 SSD.</li><li>You can use SATA SSD if you don't need to record 4K videos.</li></ul> |
|   **Capture Card**   |         PCI-E Video Capture Card         | <ul><li>Recommend [Blackmagic Intensity Pro 4K](https://www.blackmagicdesign.com/products/intensitypro4k).</li><li>For other possible choices, see [SpectatorView](https://github.com/Microsoft/MixedRealityCompanionKit/tree/master/SpectatorView#tested-capture-cards).</li></ul> |

> Note 1: Visit [https://developer.nvidia.com/video-encode-decode-gpu-support-matrix#Encoder](https://developer.nvidia.com/video-encode-decode-gpu-support-matrix#Encoder) to see the NVIDIA GPU support matrix.

> Note 2: Single common GTX1070 card could accelerate the transcoding process up to 8x, which roughly means the system can process an 8-minutes recording in about 1 minute. The use of cards of lower GPU computation power is also possible but would result in slower video processing.

### Assembly Steps

Workstation access steps are as follows:

<p align="center">
<img src="https://cloud.githubusercontent.com/assets/17921380/26624534/bf87b4ac-4623-11e7-9001-07d93508f5bf.png" width="500">
<p align="center"><em>Workstation Connection Diagram</em></p>
</p>

1. Install the **Capture Card** to the PCIE slot of the Workstation.
2. Connect the camera's **HDMI Output Port** to the **Input Port** of the capture card of the workstation, with a **HDMI to Mini-HDMI cable**.
3. Connect the **Micro USB port** of HoloLens to one of the USB3.0 port on the workstation with a **Micro USB to USB cable**. (This is for the convenience of USB debugging and charging of HoloLens, and thus is optional) .
4. Connect the workstation to the **LAN Port** of the **Wireless Router** using a Lan cable.
5. Use an **HDMI to HDMI cable** to attach the **Output Port** of the capture card of the workstation to an external display or any other campatible screens.
6. Let the HoloLens join the local wireless network and make sure the HoloLens and the workstation are in the same vlan.

## Broadcasting-Grade Setup 

If you are looking for high-end professional hardware that could be used for scenarios like television production and filming, or if you have already got those equipment, please contact service@datamesh.com for help. MeshExpert Live! supports broadcasting-grade setups and has already been used for TV shows.

## Appendix

### Rig Shopping List

|        item        | Buy Link                                 | Comments                                 |
| :----------------: | :--------------------------------------- | :--------------------------------------- |
| **HoloLens stand** | [DataMesh Shop](https://shop.datamesh.com/) | Aluminium stand offered by DataMesh      |
| **Digital camera** | [Amazon Link](https://www.amazon.com/gp/product/B01M646CFU) for Sony ICLE-6500 + EPZ 16-50 | Extra Battery at [Amazon Link](https://www.amazon.com/gp/product/B01HFOJUCW/) |
|  **Tripod/head**   | [Amazon Link](https://www.amazon.com/dp/B00139W0XM) for Ravelli AVTP |                                          |
|  **Capture Card**  | [Amazon Link](https://www.amazon.com/Blackmagic-Design-Intensity-Capture-Playback/dp/B00U3QNP7Q/) for Blackmagic Design Intensity Pro 4K |                                          |

> For other possible hardware choices, see the [SpectatorView](https://github.com/Microsoft/MixedRealityCompanionKit/tree/master/SpectatorView) from Microsoft