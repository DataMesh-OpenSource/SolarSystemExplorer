## Overview

MeshExpert Live! includes a complete set of hardware, support software, and application software. This guide will first provide you the detailed information of MeshExpert Live! system structures and how it works. Then the complete hardware specifications are given along with where to buy them. And Finally this guide will show you to assemble them together.

## System Structure

MeshExpert Live! is made up of two parts:

* **Live Rig**: a set of movable video device with the function of getting video and location information of the real world.
* **Live WorkStation**: a high performance graphics workstation used for running *MeshExpert Server* and synthesizing real-time holographic video.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/26872303-9d9425d0-4ba8-11e7-8e90-80e7389a41e2.png" width="500">
<p align="center"><em>System Structure</em></p>
</p>

## How It Works

<p align="center">
<img src="https://cloud.githubusercontent.com/assets/17921380/26623110/4165487c-461f-11e7-8182-a06471b19726.png" width="500">
</p>

MeshExpert Live! contains two main parts: collaboration, and live streaming. The collaboration within multiple devices are coordinated by **MeshExpert Server** which broadcasts messages through a simple protocol. For live video streaming, the App running on the Workstation takes the real-time anchor from the **MeshExpert LiveAgent** running on HoloLens on the Rig, and synthesizes the holographic videos. The live video stream can output to screens through HDMI interface or be captured to video files.

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
|   **Capture Card**   |         PCI-E Video Capture Card         | <ul><li>Recommend [Blackmagic Intensity Pro 4K](https://www.blackmagicdesign.com/products/intensitypro4k).</li><li>For other possible choices, see [SpectatorView](https://github.com/Microsoft/MixedRealityCompanionKit/tree/master/SpectatorView#tested-capture-cards).</li><li>Note that only Blackmagic Intensity Pro 4K card is heavily tested and fully compatible. You may encounter problems using other capture cards.</li></ul> |

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
| **Digital camera** | Sony ICLE-6500 + EPZ 16-50 | You may also buy an extra battery for backup |
|  **Tripod/head**   | For instance, Ravelli AVTP |                                          |
|  **Capture Card**  | [Blackmagic Design Intensity Pro 4K](https://www.blackmagicdesign.com/products/intensitypro4k) | Other tested cards include: [Blackmagic UltraStudio for Thunderbolt Card](https://www.blackmagicdesign.com/products/ultrastudio) and [Blackmagic Intensity Shuttle Card](https://www.blackmagicdesign.com/products/intensity)|

> For other possible hardware choices, see the [SpectatorView](https://github.com/Microsoft/MixedRealityCompanionKit/tree/master/SpectatorView) from Microsoft.

> Note: if you want to use external capture card instead of integrated capture card, you can use [Blackmagic Design Intensity Shuttle](https://www.blackmagicdesign.com/products/intensity) which is also supported by MeshExpert Live! with up to 30fps. Note that the integrated card [Blackmagic Design Intensity Pro 4K](https://www.blackmagicdesign.com/products/intensitypro4k) comes with better stablility and performance (up to 60fps). 
