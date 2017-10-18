# SolarSystemExplorer



SolarSystemExplorer, powered by [DataMesh](https://www.datamesh.com), is an amazing showcase of Mixed Reality experience with seamless integration of spectator view enabled by [MeshExpert Live!](https://www.datamesh.com/solution/meshexpert-live).



## Introduction

### Highlights and Features

SolarSystemExplorer is a demo app for MeshExpert Live! which comes with many highlighted features:

* **The World's First Commercialized 4K Mixed Reality Capture Solution**

  > The Mixed Reality capturing is made easy. From common hardware to broadcasting-grade equipment, MeshExpert Live! provides seamless integration. The produced video content is stable, editable, and of industrial quality.

* **Significantly Shorten the Development Cycle of Mixed Reality Applications**

  > With the support of opensource [METoolkit](https://github.com/DataMesh-OpenSource/METoolkit), creation of Mixed Reality apps becomes easy and fast.
  >

* **Better Collaboration and Shared Mixed Reality Experience**

  > Support up to 1000 users collaborate with different devices including HoloLens, PC, Surface, Smart Phones, and VR headsets etc. and to remotely watch the live show all sharing the same experience.

[Read More...](https://www.datamesh.com/solution/meshexpert-live)

### Gallery & Demo

####  On TV Show

[![SolarSystemExplorer On TV](https://user-images.githubusercontent.com/27760601/31527189-2a89026c-affe-11e7-8b93-5147817d8862.png)](https://www.youtube.com/watch?v=XJ16zSiWeKU  "SolarSystemExplorer On TV Show")
<p align="left"><em>SolarSystemExplorer On TV Show</em></p>

> In this episode of I'm Future (a popular TV show in China), we helped Microsoft China to create free movement HoloLens Spectator View using MeshExpert Live! and Steadicam. The system is integrated seamlessly with existing broadcasting hardware. It's a pity there's only a few mins left in the final cut. This might be the first in the world to use HoloLens in such way in real TV program.

####  Hardware Gallery

<p align="left">

<img src="https://user-images.githubusercontent.com/27760601/31645265-bc8b232a-b32d-11e7-9580-8ebc2893ab5a.png" width="600">
</p>

####  Collection of Soluations & Apps

[![Video Collection](https://user-images.githubusercontent.com/27760601/31645509-02c59f86-b32f-11e7-93e2-af0bfd13d31f.png)](https://www.youtube.com/watch?v=bdmRgSINeu8 "A collection of DataMesh Mixed Reality Solutions and Apps, Video Captured By MeshExpert Live!")
<p align="left"><em>Collections Captured by MeshExpert Live!</em></p>

> All these videos are recorded by our MeshExpert Live! 4K Moving-Camera Spectator View Capture Solution, a stable MR capture solution that you can easily set up in 10 minutes.

## Run SolarSystemExplorer 

### Hardware Setup

To set up hardware for MeshExpert Live! to run SolarSystemExplorer, please see the [Rig Assembly Guide](Docs/rig-assembly.md) for hardware specifications, hardware shopping list, and detailed assembly instructions.

Here is a video tutorial to help you set up Mixed Reality capture in 10 minutes:

[![DataMesh MeshExpert Live! Hardware Assembly Guide](https://user-images.githubusercontent.com/27760601/31527190-2abae458-affe-11e7-8044-227a1fecb06e.png)](https://www.youtube.com/watch?v=Yx6EKH_QjrU "DataMesh MeshExpert Live! Hardware Assembly Guide")


### Software Setup

Please see the [Software Setup Guide](Docs/software-setup.md) for detailed instructions.

### Configurations

See the [Configuration Guide](Docs/configurations.md) for configuring Network and IP addresses. 

### Run It!

Open the PC app and run!

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31645953-6a856122-b331-11e7-8f68-19f8359c13e6.jpg" width="700">
<p align="center"><em>Run SolarSystemExplorer</em></p>
</p>

> A preview window of the camera is on the right upper corner. You can preview the Mixed-Reality shooting at real-time. The control buttons are at the downer bar. You can take high-quality photos of the MR scenes. You can also record the whole scenes as videos with a resolution up to 4K. The recordings will be stored under **"C:/HologramCapture/SolarSystemExplorer/"**. There are also a vertical and a horizontal zoom-in and zoom-out bars for you to control your scenes. Other options are for you to explore.

To get started, click **"Connect HoloLens Spectator View"**. If the HoloLens on the Rig is connected to the PC app a green line of **HoloLens connected** will show up. Otherwise, **HoloLens offline** will show up indicating a failed network connection between the PC app on the Workstation and the LiveAgent on the HoloLens of the Rig. 

Then click **"Start Follow"** to collaborate with other devices like Surface and another HoloLens. The scene on HoloLens and Workstation (and other devices like a Surface if you have and configured to connect) will all be synchronized in real-time fashion, which enables multiple players to collaborate with multiple devices and share the same experience.

## Make Your Own App

We will show you here a step-by-step tutorial of how to create your own app with METoolkit and integrate with MeshExpert Live!.

### Getting Started

If you are new to Unity and HoloLens development, you may take the course at [HoloAcademy](https://developer.microsoft.com/en-us/windows/mixed-reality/academy) from Microsoft. For creating a Unity project, see [our tutorial](Docs/app-getting-started.md).

### Integrating METoolkit

It is easy to start using METoolkit. You can get the source code from [DataMesh-OpenSource](https://github.com/DataMesh-OpenSource/METoolkit). See the tutorial [Integrating METoolkit with Unity Project](Docs/app-integrate-metoolkit.md) for detailed instructions.

> For complete documentation for METoolkit, see [here](http://docs.datamesh.com/projects/me-live/en/latest/METoolkit-overview/).

### First App

Now let's create a simple app with METoolkit using only the **Anchor Module**. See [here](Docs/app-first-app.md).

### Add Collaboration

Follow [this tutorial](Docs/app-add-collaboration.md) to add collaboration capability to your app so that different people and devices can interact with each other. The core idea for collaboration is exchanging messages among devices through MeshExpert Server. The server defines a simple protocol for message exchange and the METoolkit provides a message wrapper for use.

### Run Your App

Now you have built your own app with collaboration capability. Let's compile and run it with MeshExpert Live! to see the results. See the tutorial [Run with Live!](Docs/app-run-your-app.md) for detailed instructions. If everything works ok, you will see a cube. And if you move the cube in HoloLens, you will also see the same movement in your PC app, which means the two devices are synching.

## Dive into SolarSystemExplorer

The SolarSystemExplorer is essentially the same idea of the first app we just made. However, it comes with more features and involves more work. Check [this doc](Docs/dive-into-solar-system-explorer) to learn more about SolarSystemExplorer.

## Trouble Shooting

If have any trouble making things work, see the [Trouble Shooting Guide](Docs/trouble-shooting.md) to see if you can find a solution. If no luck, you can always contact us at service@datamesh.com for support. We will try our best to help.





------------------------------------------------------------------------------------------------------------------------------------------------------------

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31425588-7eaa51c4-ae92-11e7-82c5-e352b9767328.png" width="400">
</p>

  Visit us at [www.datamesh.com](http://www.datamesh.com "DataMesh Home")