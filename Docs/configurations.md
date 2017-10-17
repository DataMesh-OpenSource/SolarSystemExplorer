# Configuration Guide

## Overview

After you set up the Rig and install all the drivers and software, you can now move on to the configurations. The configurations can be done manually by a series of steps. However, with the help of MeshExpert Center, this process is made easy. You can now configure and run with a few clicks.

## Network Environment

### WiFi Router

Network is the most error-prone part, and most of the problems we encountered are originated from network issues.

Therefore, we recommend you to use a dedicate Wi-Fi router for MeshExpert Live! If you do, you can isolate the network and avoid potential problems caused by firewalls and rules especially in Corporate network:

* MeshExpert Server uses TCP port 8848 and SolarSystemExplorer uses TCP port 8099 and UDP port 8098. Some corp network may intercept the traffic or block the ports.
* If you are using a separate WiFi, 5G is preferred over 2.4G band frequency. We encountered serious signal interference using 2.4G WiFi at Expos.

### Firewalls

We have already added several Firewall exceptions for MeshExpert Server and SolarSystemExplorer during the installation of MeshExpert Installer. In case you want to customize the ports. Use the following CMD commands (requires a little bit modification) as Administrator to add your own Windows firewall exceptions on the Workstation. Or you can choose to shutdown the firewall completely for testing.

```
netsh advfirewall firewall add rule name="MeshExpert: meshexpert-server incoming" dir=in action=allow program="C:\Program Files\MeshExpert\server\MeshExpert-Server.exe" enable=yes
netsh advfirewall firewall add rule name="MeshExpert: meshexpert-server outgoing" dir=out action=allow program="C:\Program Files\MeshExpert\server\MeshExpert-Server.exe" enable=yes
netsh advfirewall firewall add rule name="MeshExpert: Allow TCP 8848 for meshexpert-server" protocol=TCP dir=in localport=8848 action=allow
netsh advfirewall firewall add rule name="MeshExpert: Allow TCP 8099 for PC App" protocol=TCP dir=in localport=8099 action=allow
netsh advfirewall firewall add rule name="MeshExpert: Allow UDP 8098 for PC App" protocol=UDP dir=in localport=8098 action=allow
```

## Server IP Settings

The default MeshExpert Server IP shipped with LiveAgent and SolarSystemExplorer is **192.168.8.250**. If possible, you can set your Workstation's IP to **192.168.8.250** which will save you some time setting server IP for the LiveAgent and the Apps.

Before you start, please read the [MeshExpert Center User Guide](Docs/center-user-guide.md) to be familiar with the main features and operations.

#### Set Server IP for DataMesh LiveAgent

If you used MeshExpert Center to install the LiveAgent to the HoloLens on the Rig, it will automatically set the server IP to the Workstation's IP for you. You can check the server IP at the **Dashboard**. See below.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31602835-bb3e4616-b290-11e7-8887-5d94f9ce59d6.png" width="800">
<p align="center"><em>Check the Server IP</em></p>
</p>

Note that if the Workstation joint multiple networks, it will list all possible IPs, but only the default one displayed here will be used. If it is clearly not your IP for the Workstation, you can follow the steps below to reset the server IP for LiveAgent. (Once you added your HoloLens to MeshExpert Center and installed the LiveAgent, you can now choose and modify the server IP for LiveAgent in MeshExpert Center.)

> You have to install the Windows 10 SDK to make this work. If you have not done this, see [here](https://github.com/DataMesh-OpenSource/SolarSystemExplorer/blob/master/Docs/software-setup.md#develop-environment).

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31602234-f7d3ebf0-b28e-11e7-8e7c-74ae56426b68.png" width="800">
<p align="center"><em>Set Server IP for LiveAgent</em></p>
</p>

Click the **Device** tab, and choose your HoloLens from the list. Then select the **DataMeshLiveAgent**, and click **CONFIG**. You will be prompted to choose and set server IP. Note that only the Workstation IP addresses are listed and make sure you choose the correct IP if your Workstation joint multiple networks.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31602233-f791b334-b28e-11e7-8895-df9a4c1a39c2.png" width="800">
<p align="center"><em>Choose IP to Set</em></p>
</p>

Manual setting server IP for LiveAgent is also possible. It involves using Windows Device Portal. You can either connect your HoloLens to PC USB port or access HoloLens using WiFi.

If you use USB connection, visit http://127.0.0.1:10080 at your Edge Browser or Chrome (Ignore Certificate Error if needed). If you use WiFi connection, visit http://your_hololens_ip instead. See [Using the Windows Device Portal](https://developer.microsoft.com/en-us/windows/mixed-reality/using_the_windows_device_portal).

Follow the steps below to manually do the setting.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31606237-1c45dd34-b29b-11e7-814c-7fde3b94f322.png" width="1024">
<p align="center"><em>Manually Change Server IP for LiveAgent</em></p>
</p>

#### Set Server IP for PC App

For PC app, go to **SolarSystemExplorer_Data\StreamingAssets**, and change **Server_Host** entry to your IP. See below.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31603326-5e62fbf6-b292-11e7-8752-618667285ce2.jpg" width="800">
<p align="center"><em>Change Server IP for PC App</em></p>
</p>

#### Set Server IP for HoloLens App (Optional)

This is optional if you do not need to use a separate HoloLens (other than the one on the Rig) to interact. The configuration steps are the same as setting Server IP for LiveAgent. Essentially, they are all HoloLens Apps, and can be managed by MeshExpert Center.

#### Set Server IP for Surface App (Optional)

This is optional if you do not need to use Surface to control the interactions.

Go to **AppData\Local\Packages\SolarSystemExplorer_xxx\LocalState** under your User Directory, and change **Server_Host** entry to your IP. See below.

<p align="center">

<img src="https://user-images.githubusercontent.com/27760601/31604584-5ac6f138-b296-11e7-8f98-e1a5d4e3d57f.png" width="800">
<p align="center"><em>Change Server IP for Surface App</em></p>
</p>