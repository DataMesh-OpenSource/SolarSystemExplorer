# LIVE!

METoolKit has Live module that provides the following functions:
- Communicate wiht **DataMeshLiveAgent** of the Hololens to synchronize spatial anchors in real-time.
- Use of keyboards to adjust the position and angle of the Anchor,if the automatical synchronization failed.
- Control the upload and download World Anchor from live Agent via the Workstation. 
- Compose the images captured by the camera with virtual scenes and cast it out.
- Record the composed video stream as MPEG-4 file with a maximum resolution of 4K.

Take the Sample project and follow the instructions below. 
- Open the Sample project. 
- Open  Build Settings.
- Select **PC,Mac & Linux Standalone** and click Switch Platform. 
- Open Player Settings -> Other Settings -> Configuration.
- Under **Scripting Define Symnols** add **ME_LIVE_ACTION**.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/7636848/31706532-e40a6e3a-b41b-11e7-9e07-a8db78817cdc.png" width="600">
  </p>

- Press Build. Save the file in the same folder as your project. 
  You've just created a .exe of your simple project. 
- Open the file .exe and press **Play!**.
  You will see a screen with the Sample project on it.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706533-e440815a-b41b-11e7-86ca-023dd899d943.png" width="400">
<img src="https://user-images.githubusercontent.com/7636848/31706534-e4780df0-b41b-11e7-97c7-8d9a9705a87d.png" width="600">
</p>

- Below is a panel where Live functions are listed. 

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706535-e4adccc4-b41b-11e7-9dc9-e56de1c9d6cb.png" width="600">
</p>

- Try connecting your Hololens. Don't worry if it won't connect.
  We will provide you a step by step solution. 
  As for now it is normal to see what is shown below. 

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706536-e4e12ed4-b41b-11e7-877f-30a2cfcf5e37.png" width="400">
<img src="https://user-images.githubusercontent.com/7636848/31706537-e514d720-b41b-11e7-877c-cc2cc85becf8.png" width="400">
</p>

## Connect your HoloLens
- With your browser, write your HoloLens' IP address and go to HoloLens portal. Leave it there as we will need it later. 
- Connect your HoloLens to the computer and turn it on. Notice the changes on your screen. 

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706540-e544abf8-b41b-11e7-8e19-225a4e338f60.png" width="400">
</p>

- On the panel with **HoloLens status**, make sure that HoloLens and computer are on the same connection(same router).

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706542-e5e8df7a-b41b-11e7-90cd-189fe3bca749.png" width="400">
<img src="https://user-images.githubusercontent.com/7636848/31706541-e5b6fb9a-b41b-11e7-82b5-07a2edb506f5.png" width="400">
</p>

- Go to the HoloLens portal you opened before and find **File Explore**.
- Select **Local App Data**->**DataMeshLiveAgent**->**LocalState**

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706543-e61c4c84-b41b-11e7-8d7b-6d4b9b12f247.png" width="600">
</p>

- Download the **MEConfigLiveAgent.ini** by clicking **Save** icon. 
- Open it and make sire that **Live_IP** address matches your computer's IP address.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706545-e65ae75a-b41b-11e7-8bd3-8ac2bc346fe4.png" width="600">
</p>

- If the information don't match, modify **MEConfigLiveAgent.ini**
- Delete from the device portal the old file and upload the new file with the correct IP address.

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706546-e68db70c-b41b-11e7-99a0-2727195e3d6c.png" width="600">
</p>

- Turn on device, from the Device Portal go to **Apps** and 
  Start **DataMeshLiveAgent**

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706547-e6c13d0c-b41b-11e7-9990-5f1e0b3b1457.png" width="600">
</p>

- Go to your running SampleProject and try connecting you Hololens again.
- See the difference. 

<p align="center">
<img src="https://user-images.githubusercontent.com/7636848/31706653-3fee4d34-b41c-11e7-90f0-6935eb98cd2e.png" width="500">

<img src="https://user-images.githubusercontent.com/7636848/31706655-4075fc20-b41c-11e7-881c-d1896df2f03a.png" width="400">
</p>

- Now that Hololens is connected, move your head and see what happens. 

