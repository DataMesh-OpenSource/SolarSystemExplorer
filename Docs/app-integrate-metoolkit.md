# Integrating METoolkit with Unity Project

First download [**METookit**](https://github.com/DataMesh-OpenSource/METoolkit "METoolkit Source").

Find the METoolkit folder. Inside this folder find **Assets** folder. 
Open it and select the following folders:
```
DataMesh
Resources
Streaming Assets
```
Drag them under **Assets** in Unity.

> **Note:** You can also open Unity and instead of creating a new project, open the METoolkit folder after unzipping it.

<p align="center">
<img src="https://user-images.githubusercontent.com/26377727/31647482-0e29c814-b33b-11e7-9ec5-29ddc034c72c.png" width="500">
<img src="https://user-images.githubusercontent.com/26377727/31647481-0dd78bb2-b33b-11e7-8d48-64405052088c.png" width="600">
</p>

## Get Started
- In the Project panel search for the **MEHoloEntrance** prefab.
  Drag it into the scene panel or just drag it into the scene window.
   <p align="center">
   <img src="https://user-images.githubusercontent.com/26377727/31648589-255d847a-b341-11e7-95fa-41bffcd22afe.png" width="600">
   </p> 

- In the **Scene** panel, select the MeHoloEntrance
- In the **Inspector** panel, find MEHoloEntance component and click on **Create All MEHolo Module**
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31648587-24f9075c-b341-11e7-9126-98a92975a7fc.png" width="300">
  </p>

- MEHolo object will be automatically generated in the scene, which includes all the module in METoolKit
  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31648590-2590ecf2-b341-11e7-91c0-e8f323812e66.png" width="250">
  </p>

- Set the App ID in the inspector panel. For instance, set "Sample" as **App ID**
  and click **Set App ID**.

  > **Note:** A different APP Name must given to every app because many of ME functions, such as collaboration and storage, will depend on this name.

  <p align="center">
  <img src="https://user-images.githubusercontent.com/26377727/31648585-24c4b8c6-b341-11e7-8881-0a511cc3d66e.png" width="250">
  </p>

- Under the App Name are checkboxes representing the modules that are in METoolKit.
  Here, it is possible to enable modules according to the project's needs.

  > **Note:** There are module dependencies. Some modules demand some other modules to be present. For example, when Live module is enabled Anchor and Input modules will be checked automatically and cannot be unchecked. Detailed usage of modules will be discussed later.

- Create an empty object and name it "MainApp".
- In the Project panel, under Assets, creae a folder and name it "Scripts".
  It will contain all the scripts of the project.
- Inside Scripts folder, create a new C# script and call it MainAppScript
- Copy and paste the following code.

  ```c#
    using System.Collections;
    using UnityEngine;
    using DataMesh.AR;
    public class MainApp : MonoBehaviour
    {
      {
        StartCoroutine(WaitForInit());
      }

      private IEnumerator WaitForInit()
      {
        MEHoloEntrance entrance = MEHoloEntrance.Instance;
        while (!entrance.HasInit)
        {
          yield return null;
        }
        // Todo: Initialize modules and variables.
      }
    }
  ```

> **Note:** MEHoloEntrance will automatically run and initialize after the app started but before initialization, the system is not ready for use. Therefore, **HasInit** property must be checked and must return **true** before any other operations.

- Find the **MainAppScript** and drag it on **MainApp** gameobject in the Hierarchy to 
  add it as its component.
