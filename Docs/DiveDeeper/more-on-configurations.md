# Configuration: MeshExpertCenter

- Download MeshExpert Center and install it. 
  Once installed, a short cut will be created on Desktop.
  MeshExpert Center turns your computer into server that will let 
  devices "talk" to each other. 

- Open MeshExpert Center. 
  If this is your first time, sign-in is required. You will also 
  need licence(trial or offline) provided by DataMesh.
  If you don't have an account, create one and you will be give a 
  trial license that will let you try MeshExpert Live! free as a
  standalone minimal installation for 30 days.
  For more information visit [https://license.datamesh.com/](https://license.datamesh.com/ "License")
  where you can choose a plan that suits you most. We offere several
  online subscription plans with different deployment count and
  collaboration device account. 

  If you need enterprise version or a customized solution instead of 
  the online subscription plans, you can contact us by email
  **service@datamesh.com**.
   <p align="center">
   <img src="https://user-images.githubusercontent.com/26377727/31697686-c2bc7fb4-b3eb-11e7-9a55-31c93c86ad5b.png" width ="600">
   </p>

- To upload your licence, click **Upload license**
- Find the file containing the license and press Open.
  You will obtain a panel similar to the one below. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31697691-c75448b8-b3eb-11e7-9471-bf217e49a47f.png" width ="600">
  </p>

- You now have an active workstation with its own IP address.
- Leave this window open as we will need it later. 

## Configuration: Files
- Go to Unity. 
- Find **Assets->Streaming Assets**.
- Open **MEConfigNetwork.ini** file. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31697695-cf6729c6-b3eb-11e7-9730-5416773c6dbd.png" width ="400">
  </p>

- Edit file and make sure that **Server_Host** value is the same as the **Service IP** provided by MeshExpert Center.
- Add **Server_Port = 8848** if your file doesn't have it. This will explicitly set the server port. The default port is 8848. If your server uses a customized port, you should add this entry and change the port correspondingly.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31697727-f56ad690-b3eb-11e7-9b9e-31e5343321eb.png" width ="600">
  </p>

- Save the changes and close file.
  The file you've just modified is very important as it will
  determine the the success of communication between devices
  and server.

- If you want proof that your server is working and that your
  MEConfigNetwork.ini contains the right information, Play your 
  scene in Unity. 
  Focus on the **Console** and its data. 
- If config file is right, **Delay** value is not zero and additional
  information as the picture shown below. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700699-badde2bc-b3fd-11e7-87d5-22a41623f5c2.png" width="600">
  </p>

- If config file is not right, you will only see **Delay=0** as 
  shown in the picture below. 
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31700702-be224c74-b3fd-11e7-8e87-c4fba0d3e12a.png" width="400">
  </p>

**Config file needs to contain the right Server Host address. As
mentioned before, it will determine the success of the communication
between devices. Have in mind that config file will be the same for 
every device so you don't have to configure every time you make a 
compiled version for a specific device.**

**Remember:** 
If app is running on Unity Editor or PC Standalone, you can modify config file directly in **StreamingAssets** folder. Otherwise, you need to find it in the **PersistentDataPath** because if the application is **not** running on UnityEditor or PCStandalone, when the app starts for the first time, the config file is automatically copied to PersistentDataPAth directory and later on, the app will load the configurations from that directory. For more information about **PersistentDataPath**, please refer to Unity document: [Application.persistentDataPath](https://docs.unity3d.com/ScriptReference/Application-persistentDataPath.html)



