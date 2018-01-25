# UI Operation Guide

## Overview

The control center of MeshExpert Live! is at the PC side. You can record MR videos or take photos from the PC app.

## Main Window

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35374873-b7be98a8-01df-11e8-9a59-7c87110f87af.png" width="700">
<p align="center"><em>Main Window</em></p>
</p>

The main windows is divided into four function groups:

* **Upper Left**: control panels. You can configure the app, adjust Anchor and view the connection status of the HoloLens on the Rig.
* **Upper Middle**: shooting panels. You can record videos and photos here.
* **Upper Right**: preview window. You can preview the real-time MR stream here.
* **Down Left**: information window. Debug info will be printed here. You can enable or disable this window in the **Set Up**.

### Control Panel

There are three icons here:

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35374976-2e620404-01e0-11e8-94f8-b1270ace7bb5.PNG" width="80">
<p align="center"><em>Control Panel</em></p>
</p>



#### "Set Up"

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35375076-9a9862c6-01e0-11e8-8e0e-8d6d99157677.png" width="400">
<p align="center"><em>Set Up</em></p>
</p>

You can adjust the Holographic effects at the "**Holographic**" tab:

* **Delay**: the delay of the video stream.
* **Anti Shake**: set the time window for software anti-shake algorithm. That is, the larger the window is, the smother the video will be. However, this will cause the increase of response time where the movements of the video view would seem to be a little slow even if the camera actually moves faster.
* **Alpha**: the alpha channel for images.
* **Filter**: 
* **Sound**: the sound volume.

At the "**Advanced**" tab, you can:

* **Media Folder**: change the output location for recorded videos and images.
* **Open Config Files**: open the config file of the app.
* **Open Application Logs**: for technical debugging purpose.
* **Clear Anchor Data**: clear the anchor data so that you can set or download again. This will be useful when the MR scenes disappears at nowhere.

The "**Social**" tab is for uploading videos and photos to [DataMesh Cloud Services(DCS)](https://dcs.datamesh.com) so that you can share it to the world. You need first create an DCS account to get started.

* **Album**: the album name to store your current videos and photos in DCS.
* **RecordTime**: set the maximum time duration in seconds for the video recordings.

At the "**HoloLensAgent**" tab, you can:

* **Download Anchor**: download anchor info from the MeshExpert Server. This is often used when you set up multiple Rigs in scenarios like TV shows where all cameras and HoloLens should share the same anchor.
* **Download Spatial Mapping**: download spatial data from the MeshExpert Server.





#### **"Move Anchor"**

You can **Move** or **Rotate** the virtual objects by clicking the icons or using their respective keyboard keys.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35375157-0167acdc-01e1-11e8-82db-3b3b0dcd4c82.png" width="300">
<p align="center"><em>Move Anchor</em></p>
</p>

You can  also reset anchor and camera by clicking **Anchor Reset** and **Camera Reset**.



#### **"HoloLens Status"**

There are three statues for connecting the HoloLens on the Rig:

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35375331-a00def86-01e1-11e8-9c23-95707b7c2830.png" width="300">
<p align="center"><em>HoloLens Status</em></p>
</p>

When the app started, it will automatically try to connect to the HoloLens on the Rig. The status icon will be the first icon.  And if connected, the status icon would change to the second one. You can click **Stop Follow** to manually disconnect. When disconnected, the status icon would turn into the third one, and you can click **Start Follow** to connect again.



### Shooting Panel

There are two operations here:

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35375396-d7123d0c-01e1-11e8-8f24-7869d4f9d24d.PNG" width="200">
<p align="center"><em>Shooting Panel</em></p>
</p>

If you checked the **Auto Upload** box, the videos and pictures will be automatically uploaded to DCS. Then you can check the videos and pictures at [DCS website](https://dcs.datamesh.com) and share them to the world.



### Preview Window

The upper right is the preview window showing the real-time MR video streams.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35375482-237f862c-01e2-11e8-88f0-f8580aae7cdd.PNG" width="400">
<p align="center"><em>Preview Window</em></p>
</p>

The default mode is a small  window. You can click the double-arrow icon to alternate among **Small Window**, **Full Window** and **Hide** modes.

### Information Window

The information window will print out debug information for technicians to analyze.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/35375541-60d4a192-01e2-11e8-9fc0-8e2d13b915e2.PNG" width="200">
<p align="center"><em>Information Window</em></p>
</p>
