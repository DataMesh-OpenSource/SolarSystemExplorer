# Trouble Shooting Guide

## Unity-related

### Unity Application Release

Q: **Released application didn't work properly**

The Scene selected at the time of publication may not right.

Q: **There are no compilation errors in Unity, but there are compilation errors when publishing it as an application which can run on HoloLens.**

It is usually because the codes or libraries used are not supported by UWP. Please remove these kind of things and then recompile it.

Q: **Application debugging fails when installing it from Visual Studio to HoloLens.**

The possible solutions are:

Check build parameters of Visual Studio. Platform must be and Target must be x86 and Device respectively.

Check whether HoloLens is closed or in hiberation state. If yes, please open it or wake it up.

Try to delete Application on HoloLens.

Try to start it again. If there are still some problems, try to delete Visual Studio Project and release it again from Unity.

## METoolkit-related

### Anchor Module

Q: **When the SceneAnchorController module is enabled, the border and the crystal appear two sets of ghosting**

Check whether MEHolo/AnchorManager/AnchorCamera Object in the scene is active. Other cameras which need to follow the main camera must remain active at startup and can not be hidden, otherwise the cameras' position will never be synchronized to the position of the main camera.

Q: **Fail to upload anchor**

Check whether the address settings for the Share Anchor Server is correct.

If the space information is too large, it may lead to upload failure. In this circumstance, please clear the space information in HoloLens, re-scan and then try to upload again.

Q: **The anchor object was not positioned correctly after you download it successfully.**

It's usually because the downloaded spatial information and current spatial information identified by the HoloLens do not match, so the space anchor can not locate properly. (If you use the Download Anchor function on ME-Live!, there will be special hints in this state). Please try moving HoloLens around, and when the spatial information matches, the anchor object will return to the correct position.

### Input Module

Q: **Gaze at the clickable object but air-tap does not respond.**

The possible solutions are:

Confirm MultiInputManager has been started.

Check whether layer setting in MultiInputManager covers whole layer of the clickable object.

If you use the callback mode operation of MultiInputManager, check whether the corresponding callback function is properly bound, making sure that all places use **+=** to add a callback instead of using **=** to override the callback.

If you are using the click-to-object response function mode operation, check whether the collider of the clickable object and the component on which the response function resides are on the same object.

You can test in the Unity environment, turn on the **Simulate Gaze** option on the InputManager component, then adjust the camera, place the line of sight on the target object, press "Enter" to simulate air-tap.

Q: **Manipulation or Navigation is invalid.**

Confirm MultiInputManager is enabled.

Make sure that MultiInputManager has switched to the appropriate recognition mode. Use the ChangeToManipulationRecognizer() and ChangeToNavigationRecognizer() methods to switch accordingly.

### Collaboration Module

Q: **Collaboration module can not collaborate.**

Check whether all devices are under the same network segment.

Check all device settings to see if the server IP is correct.

Q: **Signal delay exists in collaboration**

Signal sending interval of Collaboration Server is 100 ms, thus delay within about 100 ms is quite reasonable.

If the delay is too large, check whether the network environment is stable, and the server's loading.

### Live Module

Q: **Stuck shortly after the start**

Please check the Quality setting and whether the vertical sync has been turned off in all operating modes. When you turn on vertical sync, starting the Live module will cause stuck at startup, in both the Editor environment and the Standalone environment.

Q: **MeshExpert Live! cannot connect to DataMesh Live Agent which runs on HoloLens**

The possible solutions are:

Check whether HoloLens and Live Workstation are in the same network segment.

Check whether the MeshExpertLiveAgent application is started on HoloLens and restart the application if necessary.

Check whether the DataMesh Live Agent listening port set in the Live program in Live Workstation is consistent with the port set in the DataMesh Live Agent application in HoloLens.

## Project Environment

Q: **Stuck when starting program inside Unity**

If it is Windows 10 environment, please check whether the **Developer Mode** is enabled. if it's not in the **Developer Mode**, the project contains HoloLensInputModule components, it will result in getting stuck when starting it in Editor environment.

Q: **The position of the object in HoloLens is not consistent with the expected position.**

Check if the main camera's position is (0,0,0). If the initial position of the main camera is not (0,0,0), it may cause the object position in HoloLens to shift.

## Deployment Environment

Q: **No signal on screen**

Make sure that the monitor cable is connected properly

If you have hot-swapped the cables, please try restarting the host

Q: **Cannot collect video signal**

Make sure that the video cable is connected properly and try reconnecting the video cable if necessary

Check the BlackMagic driver's info, if you cannot get its information, try to restart the host

Make sure the camera's output resolution is set correctly (currently 1080)