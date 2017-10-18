
# Build Surface App

## Surface Build
With the introduction of **Universal Windows Platform(UWP)** any Windows-base device, such as PC, phone, tablet and HoloLens,
can run UWP application. This is why, we can also make a compiled version for Microsoft
Surface. 

The process is almost as the same as the Hololens build with
the smallest change on the settings. 

- Open **File->Build Settings**

> Note: If you compiled a HoloLens version before, the following two steps must already been made and when you open Build Settings the selection is already on Windows Store.

- Select **Windows Store** under Platform and press **Switch Platform**.

<p align="center">
<img src="https://user-images.githubusercontent.com/26377727/31700047-4a8d63a6-b3f9-11e7-984c-497c2fb20d08.png" width="600">
</p>

- On the right side, made the following changes:
```
SDK->Universal10
Target device-> Hololens
UWP Build Type -> D3D
Check Uity C# Project
```

<p align="center">
<img src="https://user-images.githubusercontent.com/26377727/31700057-541c8190-b3f9-11e7-9c69-8bb6a0e9ce48.png" width="400">
</p>

- Click on **Player Settings->Other Settings**

- **Uncheck** Virtual Reality Supported, if it is checked.
  Otherwise, leave it unchecked. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31703726-7bf2d036-b410-11e7-9cac-938f28bb67b6.png" width="600">
  </p>

- Press Build and go ahead on creating the build folder for your
  Surface version. 



Next to build the UWP application package, follow the steps below.

- Open you SolarSystem Explorer solution on VisualStudio. 
- In **Solution Explorer** find **SolarSystemExplorer (Universal Windows)**.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31704669-eb4c15ec-b414-11e7-8dd2-7d43ce88c000.png" width="400">
  </p>

- Right click on **SolarSystemExplorer->Store->Create App Packages**.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31705150-da545946-b416-11e7-8a53-7b724b0b7e9a.png" width="500">
  </p>
- In the next window, select **No** and press Next.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31705161-e15a17d0-b416-11e7-8bf9-03adb6089f21.png" width="600">
  </p>
- In **Select and Configure Packages** window, **uncheck** x64 and ARM.
  You can choose between two kinds of **Solution Configuration**. 
  Choose **Master** if you want to put your app on Windows Store and 
  **Release** if you it is only for your own use. In our case, we choose
  Release. 
  Press Create and let VisualStudio do the work. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31705168-e6de0e8c-b416-11e7-8df8-4c6fbbcc416d.png" width="600">
  </p>
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31705672-ef9ca8a6-b418-11e7-8fa0-adbd9c193035.png" width="600">
  </p>
- Once the package is created, open the folder containing the application
  package.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31705269-517e148a-b417-11e7-8061-32f4308ca5cb.png" width="600">
  </p>
- All you have to do is to copy **App Packages** on your Surface device.
  Thanks to UWP, you can use this package to install the same application
  on any Windows-based device. 

## Install Surface App

If you already have the **application package**, follow[ Installation on Surface](https://github.com/DataMesh-OpenSource/SolarSystemExplorer/blob/master/Docs/software-setup.md#install-surface-version-optional) to install an UWP app to your Surface. And then follow [these instructions](https://github.com/DataMesh-OpenSource/SolarSystemExplorer/blob/master/Docs/configurations.md#set-server-ip-for-surface-app-optional) to set the server IP for Surface app so that it can talk to MeshExpert Server.