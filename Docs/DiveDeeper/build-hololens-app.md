# Compiling Versions

## HoloLens Build
- In Unity open **File->Build Settings**
- In the Platform list, select **Windows Store** and press Switch Platform. Wait for Unity to finish task. Once the task is over, the Unity icon will move next to Windows Store. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700047-4a8d63a6-b3f9-11e7-984c-497c2fb20d08.png" width="600">
  </p>

- On the right side, make the following changes: 

  ```
  SDK =  Universal 10
  Target device = Hololens
  UWP Build Type = D3D

  Check Unity C# Projects
  ```
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700057-541c8190-b3f9-11e7-9c69-8bb6a0e9ce48.png" width="400">
  </p>

- Press **Player Settings**
- In the Inspector panel, fine **Other Settings** and 
  check **Virtual Reality Supported** box. 
  You will notice the **Windows Holographic** will appear 
  by default.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700062-5eb7772c-b3f9-11e7-928f-fcd72703d231.png" width="700">
  </p>

- Go to **Publishing Settings->Capabilities** and  check the 
  following boxes:

  ```
  InternetClient
  InternetClientServer
  VideosLibrary
  WebCam
  SpatialPerception  
  ```

- Press Build. Create you folder to contain the VisualSolution of your
  project and all realted information.   
- Open your Build folder and find the VisualStudio Solution of 
  your project.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700069-6b7e9c7e-b3f9-11e7-8df2-c53fd7d1984f.png" width="400">
  </p>
- In VisualStudio change the following values: 

  ```
  Debug->Release
  ARM->x86
  LocalMachine->Device or RemoteMachine
  ```

  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700076-7b94f6b2-b3f9-11e7-8c31-69ecfa2cd969.png" width="400">
  </p>
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700081-837d6760-b3f9-11e7-9096-36e7011681ab.png" width="400">
  </p>

> **Note:** if you choose RemoteMachine, you will be deploying your app to your HoloLens via Wi-Fi so you will need to provide your HoloLens IP address. You will find your HoloLens IP address in **Settings-> Network&Internet->Advanced options**.

<p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700091-88f4936c-b3f9-11e7-8cb4-36199a00c281.png" width="600">
  </p>

- Press the **Play** icon to start deploying you app on your Hololens. 
  If you chose Device, make sure your Hololens is connected through USB cable.
