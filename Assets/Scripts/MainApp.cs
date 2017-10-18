using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataMesh.AR.Utility;
using System.IO;
using MEHoloClient.Entities;
using DataMesh.AR.Anchor;
using DataMesh.AR.Interactive;
using DataMesh.AR.SpectatorView;
using DataMesh.AR.UI;
using DataMesh.AR;
using DataMesh.AR.Network;
using HoloLensXboxController;

public class MainApp : MonoBehaviour
{
    public static MainApp Instance { get; private set; }
    public GameObject sceneRoot;
    private bool isBusy = false;
    private SceneAnchorController anchorController;
    private LiveController bevController;
    private CursorController cursorController;
    private MultiInputManager inputManager;
    private SolarSystem solarSystem;
    private SpeechManager speechManager;
    private BlockMenuManager menuManager;
    private BlockMenu mainMenu;
    private bool isBev = false;

    void Awake()
    {
        Instance = this;

        isBusy = true;

    }

    public bool IsBusy
    {
        get
        {
            return isBusy;
        }
        set
        {
            isBusy = value;
        }
    }

    // Use this for initialization
    void Start()
    {
        anchorController = SceneAnchorController.Instance;
        //anchorShared = AnchorShared.Instance;
        bevController = LiveController.Instance;
        solarSystem = SolarSystem.Instance;
        cursorController = UIManager.Instance.cursorController;
        inputManager = MultiInputManager.Instance;
        speechManager = SpeechManager.Instance;
        menuManager = UIManager.Instance.menuManager;
        /////////////// 各种初始化 /////////////////////
        StartCoroutine(WaitForInit());
    }

    private IEnumerator WaitForInit()
    {
        MEHoloEntrance entrance = MEHoloEntrance.Instance;
        while (!entrance.HasInit)
        {
            yield return null;
        }
        solarSystem.Init();
        // 主菜单
        mainMenu = menuManager.GetMenu("MainMenu");
        mainMenu.RegistButtonClick("ChangeAnchor", SpatialFit);
        mainMenu.RegistButtonClick("UploadAnchor", UploadAnchor);
        mainMenu.RegistButtonClick("DownloadAnchor", DownloadAnchor);

        // 语音设置
        speechManager.AddKeywords("OpenMenu", OpenMenu);
        speechManager.StartRecognize();

        /////////////// 启动流程 /////////////////////
        cursorController.isBusy = true;
        solarSystem.TurnOn();
        cursorController.TurnOn();
        isBusy = false;
    }

    // Update is called once per frame
    void Update ()
    {
        if ((Input.GetKeyDown(KeyCode.K) && (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)))
            || inputManager.controllerInput.GetButton(ControllerButton.Menu))
        {
            OpenMenu();
        }

    }

    private bool beginAdjustAnchor = false;
    private void OpenMenu()
    {
        Debug.Log("turn off solar system....");
        solarSystem.BindGazeManager(false);
        Vector3 headPosition = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;
        Vector3 pos = headPosition + gazeDirection * 2;
        menuManager.ShowMenu(mainMenu, pos, gazeDirection);
        menuManager.cbMenuHide = OnMenuHide;
        inputManager.layerMask = LayerMask.GetMask("UI");
    }

    private void OnMenuHide()
    {
        StartCoroutine(RebindSolarSystemInput());
    }

    private IEnumerator RebindSolarSystemInput()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        if (!beginAdjustAnchor)
        {
            Debug.Log("Rebind Solar system by close menu!!");
            solarSystem.BindGazeManager(true);
        }
    }

    private void SpatialFit()
    {
        Debug.Log("Start fit!");
        //BindInput(false);
        anchorController.AddCallbackFinish(AnchorMoveFinish) ;
        anchorController.TurnOn();
        beginAdjustAnchor = true;
    }

    private void AnchorMoveFinish()
    {
        anchorController.TurnOff();
        //BindInput(true);
        Debug.Log("Rebind Soler system by Move Anchor Finish!!");
        solarSystem.BindGazeManager(true);
        beginAdjustAnchor = false;
    }

    private void OnTap(int n)
    {
        if (inputManager.FocusedObject == null)
        {
            OpenMenu();
        }
    }

    private void UploadAnchor()
    {
        isBusy = true;
        anchorController.UploadAnchor((bool success, string error) =>
        {
            isBusy = false;
            if (success)
            {
                cursorController.ShowInfo("Upload Anchor Success!");
            }
            else
            {
                cursorController.ShowInfo(error);
            }
        });
    }

    private void DownloadAnchor()
    {
        isBusy = true;
        anchorController.DownloadAnchor((bool success, string error) =>
        {
            isBusy = false;
            if (success)
            {
                cursorController.ShowInfo("Download Anchor Success!");
            }
            else
            {
                cursorController.ShowInfo(error);
            }
        });
    }
}
