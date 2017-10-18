# Integrate Collaboration Module
**CollaborationManager** provides the following functions:
  - Group devices by rooms to let them collaborate with each other.
  - Let a wide range of devices communicate through the Workstation.
  - Wrap generic message format and communication channels to make
    collaborations easier. 

## Add Collaboration module
In order to make things work, be sure to be familiar with METoolKit
and previous steps of this tutorials were followed as they are bound to 
configure the Unity project wiht METoolkit.

- Open the project prevoiusly created. 
- If there is no object on the Scene, create one and place it where Camera 
  can capture.
- Open **Assets->Streming Assets**.
  Search for **MEConfigNetwork.ini** and open it.
  <p align="center">
  <img src="https://user-images.githubusercontent.com/7636848/31706017-106eb028-b41a-11e7-840e-f0463057b3e2.png" width="400">
  </p>

- Make sure that it contains the value provided below. 

```
##############################################
# config for network
###############################################

Server_Host = 192.168.2.31
Server_Port = 8848
```

- It is possible to use personal server IP.
>**Note:**
- If application is not running on Unity Editor or PC Standalone(Hololens,iOS,Android), app will load **config file** at **PersistentDataPath** and not on Streaming Assets. For more information, please refer to [Utility: Config Files](http://docs.datamesh.com/projects/me-live/en/latest/toolkit/toolkit-man-utility-config-file/)
- Having the wrong host IP address will cause the application to log a **Delay=0**. Notice the difference between the two pictures below.
      <p align="center">
      <img src="https://user-images.githubusercontent.com/7636848/31706018-109faa02-b41a-11e7-9fca-39d8f5ea3763.png" width="400">
      <img src="https://user-images.githubusercontent.com/7636848/31706016-10356aca-b41a-11e7-8abe-7a44c22c7587.png" width="400">
      </p>

- If server address is right, you will also see:
```
Enter Room Sucessfully
UnityEngine.Debug:Log(Object)
```

- Open the MyAppScript. Find **COLLABORATION** section and add pieces of code as below.

```c#
using System.Collections;
using UnityEngine;
using DataMesh.AR.Interactive;
using DataMesh.AR.Network;
using DataMesh.AR.UI;
using MEHoloClient.Entities;
using MEHoloClient.Proto;
using DataMesh.AR.Anchor;

namespace DataMesh.AR.Samples.Collaboration
{
     public enum ColorType
     {
         red = 0,
         blue = 1,
         green = 2,
     }
    public class MainApp : MonoBehaviour, IMessageHandler
    {
    	//modules
        private MultiInputManager inputManager;
        private CollaborationManager cm;
	private CursorController cursor;
	
	//Sync message variables
        private ColorType CurrentColor;
        private Vector3 Position;
        private ShowObject showObject;
        private SceneObject roomData;

        public GameObject cube;
        private int sum;
        private bool isMoved;

        void Start()
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

            cursor = UIManager.Instance.cursorController;


            // Todo: Begin your logic
            inputManager = MultiInputManager.Instance;
            inputManager.cbTap += OnTap;

	    //Initialize collaboration Module
            cm = CollaborationManager.Instance;
            cm.AddMessageHandler(this);
            cm.cbEnterRoom = cbEnterRoom;

	    //creation of a message for the message handler
            string showId = "showId001";
            string obj_type = "ColorType";

            MsgEntry msg = new MsgEntry();
            msg.ShowId = showId;

            ObjectInfo info = new ObjectInfo();
            info.ObjType = obj_type;
            msg.Info = info;

            msg.Vec.Add((long)CurrentColor);
            msg.Pr.Add((cube.transform.position.x));
            msg.Pr.Add((cube.transform.position.y));
            msg.Pr.Add((cube.transform.position.z));

            showObject = new ShowObject(msg);
            roomData = new SceneObject();
            roomData.ShowObjectDic.Add(showObject.ShowId, showObject);
			
            cm.roomInitData = roomData;
            cm.TurnOn();
        }

        private void OnTap(int count)
        {
            sum += count;
            if (cm.enterRoomResult == EnterRoomResult.EnterRoomSuccess)
            {
		//Manipulation trigger
                BindInputManager(true);
            }
            else
            {
                if (cm.enterRoomResult == EnterRoomResult.Waiting)
                {
                    cursor.ShowInfo("waiting....");
                }
                else
                {
                    cursor.ShowInfo("Error! " + cm.enterRoomResult);
                }
            }
        }
        
        /// <summary>
        /// Callback function of EnterRoom
        /// </summary>
        private void cbEnterRoom()
        {
            Debug.Log("Enter Room Sucessfully");
        }

        void IMessageHandler.DealMessage(SyncProto proto)
        {
            this.DealMessage(proto);
        }

	/// <summary>
        /// This part is very important as it what syncronizes
	/// the devices and the workstation.
        /// </summary>
        void DealMessage(SyncProto proto)
        {
            Google.Protobuf.Collections.RepeatedField<MsgEntry> messages = proto.SyncMsg.MsgEntry;
            //Debug.Log("deal message");
            if (messages == null)
                return;
            for (int i = 0; i < messages.Count; i++)
            {
                MsgEntry msgEntry = messages[i];
                if (msgEntry.ShowId == showObject.ShowId)
                {
                    Debug.Log("I am deal message.");
                    SyncPos(msgEntry);
                }
            }
        }

	//Handles manipulation related events
        public void BindInputManager(bool bind)
        {
            inputManager.ChangeToManipulationRecognizer();
            if (!bind)
            {
                Debug.Log("unbind gesture");
                inputManager.cbTap -= OnTap;
                inputManager.cbManipulationStart -= OnManipulationStart;
                inputManager.cbManipulationUpdate -= OnManipulationUpdate;
                inputManager.cbManipulationEnd -= OnManipulationEnd;
                return;
            }
            else
            {
                Debug.Log("bind gesture");
                inputManager.cbTap += OnTap;
                inputManager.cbManipulationStart += OnManipulationStart;
                inputManager.cbManipulationUpdate += OnManipulationUpdate;
                inputManager.cbManipulationEnd += OnManipulationEnd;
            }
        }

        private void OnManipulationEnd(Vector3 delta)
        {
            isMoved = true;
            ChangeCubePosition();
        }

        private void OnManipulationStart(Vector3 delta)
        {
            Debug.Log("Manipulation Start");
        }

	/// <summary>
        /// cube will move accordingly to the hand's movement
        /// </summary>
        private void OnManipulationUpdate(Vector3 delta)
        {
            cube.transform.position += new Vector3(delta.x, delta.y, delta.z);
        }

	/// <summary>
        /// called after the manipulation has ended
	/// modify the Sync message values with the cube's new position
        /// </summary>
        void ChangeCubePosition()
        {
            if (isMoved)            
			      {
                MsgEntry entry = new MsgEntry();
                entry.OpType = MsgEntry.Types.OP_TYPE.Upd;
                entry.ShowId = showObject.ShowId;
                entry.Pr.Add(cube.transform.position.x);
                entry.Pr.Add(cube.transform.position.y);
                entry.Pr.Add(cube.transform.position.z);

                SyncMsg msg = new SyncMsg();
                msg.MsgEntry.Add(entry);

                cm.SendMessage(msg);
            }
        }
		
	/// <summary>
        /// Syncronizes the cube position after manipulation
        /// </summary>
        public void SyncPos(MsgEntry info)
        {
            //Debug.Log(info);
            cube.transform.position = new Vector3(info.Pr[0], info.Pr[1], info.Pr[2]);
        }
    }
}

```
- Save the modified script.
- Don't forget to the drag the cube game object in the Inspector panel.
- Build project and deploy on Hololens.
- After deploying on Hololens, Play the Scene in Unity and see what happens.

If all is done correctly, you must see the cube moving both in Unity and in 
Hololens.
Try manipulating the Cube with hands gesture in Hololens and using 
Enter(to bind gesture) and Shift+(UIO / JKL) in Unity. 
Compare the **Outputs** from Unity and Hololens. If all is working well,
the Outputs must be the same.

<p align="center"> 
<img src="https://user-images.githubusercontent.com/26377727/31646556-2142368a-b335-11e7-8412-f3e72f114313.png" width="600">
<img src="https://user-images.githubusercontent.com/26377727/31646555-210f85be-b335-11e7-9ad5-faec3f773cd7.png" width="600">
</p>

