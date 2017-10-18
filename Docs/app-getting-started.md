# Creating a Unity Project for HoloLens

- Open unity and choose "New" to create new unity project. Call the project "SampleProject".
- Make sure  **D3D** is chosen.
- Choose a location for the project. 

  **Suggestion** : choose the Desktop as destination for the project's folder.
- Choose create project and wait for Unity to complete the task. 

## Setting the scene
- Choose the **Main Camera** in the Hierarchy panel (left side of the Scene window).
- In the Inspector panel modify the camera's position into (0,0,0).

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704494-3e83ef4c-b414-11e7-9419-17c6c2e7e548.png" width="300">
</p>

- Find **Clear Flags** and change it's value from Skybox to Solid Color.
- Change the **Background** to black by clicking the box and change RGBA values to 0.
  Remember: black background will appear transparent in HoloLens.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704550-7a109ad8-b414-11e7-92a0-72667e2a5ed3.png" width="500">
</p>

- Finally save the scene in order to make changes permanent.

## Project Settings
- Open **Edit -> Project Settings -> Quality**

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704693-0225f5f8-b415-11e7-9125-d6646118f2c8.png" width="400">
</p>

- In the Inspector Panel go under **Window Store** icon. Click on the Default arrow and choose
  Fastest. You will see a green check right under Windows Store icon.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704713-2b6eec44-b415-11e7-8c2c-1e4a60ac3731.png" width="300">
</p>

- Find **'Other'** under the same panel and change 'V Sync Count' value to Don't Sync.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704714-2baad038-b415-11e7-9105-a2c2599b9ea9.png" width="300">
</p>

## Build Settings
- Open **File -> Build Settings -> Player Settings**.
- Click on **"Add Open Scene"** in order to add the scene created before. 
- With the chosen platform, change **Architecture** value in **x86_64**

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704715-2bdce140-b415-11e7-9ac4-5c123e01c84c.png" width="500">
</p>

- Click **'Player Settings'** and go to the inspector panel.
- In the Inspector Panel find **'Other Settings'** section, go to Optimization and change
  API Compatibility level to .NET 2.0

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704720-2cb324e4-b415-11e7-96b0-770ad3ff87d5.png" width="400">
</p>

- Re open Build Settings, choose Windows Store under Platform and click Switch Platform.
  (if done, the unity icon must be beside Windows Store)
  On the right side, do as follows:
  ```
  SDK -> Universal10
  Target device -> Hololens
  UWP Build Type -> D3D
  Check Unit C# Projects
  ```

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704721-2ce9d0ca-b415-11e7-96c2-9fbad4647235.png" width="500">
</p>

- Click on the **Player Settings -> Other Settings**.
  Check Virtual Reality Supported and Windows Holographic will appear as the default SDK.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704723-2d1cf680-b415-11e7-87d9-f22c69daa749.png" width="600">
</p>

- Go to **Publishing Settings -> Capabilities** and check the following:
  ```
  InternetClient
  InternetClientServer
  PrivateNetworkClientServer
  WebCam
  SpatialPerception
  ```

- All is set! click Build. In the project's folder create a folder
  that will contain the project's build and choose that folder. 
  Wait for the process to happen. 
  The created folder must be like in the picture below.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704785-692ecd60-b415-11e7-9d5c-2ae5e5de06c0.png" width="300">
</p>

## Build and Deploy
- Add a cube in the scene and place it where camera can capture
- Build the project
- Open the build folder 
- Find for the  Visual Studio Solution

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704797-79b70d32-b415-11e7-8e7f-81591ae8b433.png" width="500">
</p>

- In Visual Studio, in the upper panel do as follows: 
  ```
  Debug -> Release
  x64 -> x86 
  Local Macchine -> DevicE
  ```

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31704796-79885adc-b415-11e7-88fa-9f573ccac455.png" width="400">
</p>

- press **CTRL+F5** or press the icon near **Device**.
- In HoloLens, a cube will be seen and that is a small HoloLens
  application made with Unity,

It is also possible to have **Local Machine -> Remote Machine**.
but the Hololens' Ip address must be provided

The Hololens Ip address is in 
**Settings -> Network & Internet -> Advance option -> Ipv4 address**

In the next pages, we will integrate METoolKit and Unity Project.
