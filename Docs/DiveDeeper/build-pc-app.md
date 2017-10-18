# Build PC App

## PC Version
- Open **Edit->Project Settings->Quality**.
  In the Inspector panel, find **Quality Settings** and modify the values 
  as shown in the picture below.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698324-96877eea-b3ef-11e7-8e0d-cebad6a7f122.png" width="400">
  </p>
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698327-9b0652b6-b3ef-11e7-877b-d7fe5a2ada4d.png" width="400">
  </p>

- Open **File->Build Settings**
- If not selected, change selection to **PC, Mac & Linux Standalone**
  and press **Switch Platform**
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698334-a5ee3496-b3ef-11e7-8b73-1e5759d941c9.png" width="500">
  </p>

- Change **Architecture** value: **x86->x86_64**.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698348-b37f243a-b3ef-11e7-9062-05ea313f20ea.png" width="500">
  </p>

- Click on **Player Settings**. 
  In the Inspector panel, find **Scripting Define Symbols** and add
  **ME_LIVE_ACTIVE**.
  This makes your application ready for LIVE! We will discuss about it 
  later.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698352-b8ca474e-b3ef-11e7-82d7-8001244acc3c.png" width="600">
  </p>

- Press **Build**.
  Create a new folder for this build name it so that you can easily find it.
- Now you have a compiled PC version of solar System Explorer.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698701-6919eec8-b3f1-11e7-992f-af75fee978f6.png" width="400">
  </p>

- Open the **.exe** file of your Solar System and press Play!
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31698728-8bbdbbc6-b3f1-11e7-81f8-1e499a5c6fa3.png" width="400">
  </p>

<p align="center">
<img src="https://user-images.githubusercontent.com/26377727/31698735-910a0cec-b3f1-11e7-88af-088e9676820b.png" width="600">
</p>

- If your screen appears to be different from the picture above,
  Go to your Unity project and make sure you have the right project settings.

- Close the window for now as we will proceed to the creation of the
  compiled version for HoloLens. 
