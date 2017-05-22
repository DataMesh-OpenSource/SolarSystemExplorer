using DataMesh.AR.Interactive;
using MEHoloClient.Entities;
using MEHoloClient.Sync.Time;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataMesh.AR.Network;
public class SolarSystem : MonoBehaviour ,IMessageHandler{

    public Transform selectedContainer;
    public Transform originContainer;
    public Transform realSun,fakeSun;
    public UniverseView universeView;

    public List<GameObject> planetObjects;

    public AnimationCurve curve_come, curve_leave;

    public PlanetObject planetObject_notSelected;

    public CardControl control;
    public ExplosionController expControl;

    Dictionary<string, PlanetObject> planetMap;
    

    //public float 

    public bool selected = false;
    public float selectedScaleFactor = 5;
    public static SolarSystem Instance { get; private set;}

    public bool connectToServer = true;
    public bool useIOSMaterial = false;
    private float originRotY;
    private float messageId;
    private bool initComplete = false;
    private bool extraOperating;

    private bool isPlayback;

    private enum ExtraOperationType
    {
        Rotate,
        Scale,
        Unknown
    }

    private ExtraOperationType currentOperationType = ExtraOperationType.Unknown;
    private MultiInputManager gazeManager;

    private PlanetObject selectedPlanet;
    private string focusedPlanetName;
    ContainerView cv_selected, cv_originContainer;

    private float timeDelay;
    
    private bool animationInterrupt = false;

    private CollaborationManager cm;

    protected void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        if(!connectToServer)
        {
            Init();
            TurnOn();
        }
    }

    // Update is called once per frame
    protected void Update()
    {
        if (initComplete)
        {
            universeView.UpdateUniverseTime();
            //DoRevolution();
        }
        else
        {
            if (cm.hasEnterRoom)
            {
                initComplete = true;
                CursorController.Instance.isBusy = false;
            }
        }
    }
  
    public void TurnOn()
    {
        BindGazeManager(true);
        selectedContainer.gameObject.SetActive(true);
        originContainer.gameObject.SetActive(true);
        //selected = false;
        universeView.universeTime = 0;
        planetMap = new Dictionary<string, PlanetObject>();
        foreach (GameObject p in planetObjects)
        {
            string name = p.name;
            PlanetObject po = p.GetComponent<PlanetObject>();
            po.planetType = (PlanetObject.PlanetType)Enum.Parse(typeof(PlanetObject.PlanetType), name);
            //Debug.Log("addPlanetView:" + pv.planetType);
            planetMap.Add(name, po);
        }

        if (connectToServer)
        {
            SceneObjects roomInitData = new SceneObjects();
            //roomInitData.ShowObjectDic.Add(UniverseObject.OBJECT_TYPE, universeView.uo.CreateShowObject());
            roomInitData.ShowObjectDic.Add(cv_selected.containerType.ToString(), cv_selected.co.CreateShowObject());
            roomInitData.ShowObjectDic.Add(cv_originContainer.containerType.ToString(), cv_originContainer.co.CreateShowObject());
            roomInitData.ShowObjectDic.Add(PlanetObject.OBJECT_TYPE, selectedPlanet.CreateShowObject());
            cm.roomInitData = roomInitData;
            cm.TurnOn();
            
            //讲师端发送同步信息
            StartCoroutine(UpdateContainerData());
            Debug.Log(cm.GetSyncDelay());
        }

    }

    public void TurnOff()
    {
        selectedContainer.gameObject.SetActive(false);
        originContainer.gameObject.SetActive(false);

        BindGazeManager(false);
    }

    public void BindGazeManager(bool bind)
    {
        //CardControl control = CardControl.Instance;

        if (bind)
        {
                gazeManager.layerMask = LayerMask.GetMask("Default") + LayerMask.GetMask("UI");

                gazeManager.ChangeToNavigationRecognizer();

                gazeManager.cbTap += OnTap;

                if (gazeManager.InteractiveType == MultiInputManager.InputType.Touch
                    || gazeManager.InteractiveType == MultiInputManager.InputType.KeybordAndMouse
                    )
                {
                    control.controlPanel.SetActive(true);
                    control.sliderRotate.onValueChanged.AddListener(OnSliderRotate);
                    control.sliderScale.onValueChanged.AddListener(OnSliderScale);
                }
                else
                {
                    gazeManager.cbNavigationStart += OnNavigationStart;
                    gazeManager.cbNavigationUpdate += OnNavigationUpdate;
                    gazeManager.cbNavigationEnd += OnNavigationEnd;
                }
        }
        else
        {

                gazeManager.cbTap -= OnTap;

                if (gazeManager.InteractiveType == MultiInputManager.InputType.Touch
                    || gazeManager.InteractiveType == MultiInputManager.InputType.KeybordAndMouse
                    )
                {
                    control.controlPanel.SetActive(false);
                    control.sliderRotate.onValueChanged.RemoveListener(OnSliderRotate);
                    control.sliderScale.onValueChanged.RemoveListener(OnSliderScale);
                }
                else
                {
                    gazeManager.cbNavigationStart -= OnNavigationStart;
                    gazeManager.cbNavigationUpdate -= OnNavigationUpdate;
                    gazeManager.cbNavigationEnd -= OnNavigationEnd;
                }
            
            control.controlPanel.SetActive(false);
            gazeManager.layerMask = LayerMask.GetMask("UI");
        }

    }

    public void SetIgnoreSliderChangedEvent(bool value)
    {
        //Debug.Log("set");
        ignoreSliderChangedEvent = value;
    }

    private bool ignoreSliderChangedEvent = false;
    private float extraOperatingEndTime;
    private void OnSliderRotate(float value)
    {
        //Debug.Log("拖动进度条:" + value);
        if(!ignoreSliderChangedEvent)
        {
            //Debug.Log("来发送");
            extraOperating = true;
        }
        

        currentOperationType = ExtraOperationType.Rotate;

        SetRotation(new Vector3(0, value * 180, 0));

        extraOperatingEndTime = Time.realtimeSinceStartup + 0.2f;
    }

    private void OnSliderScale(float value)
    {
        //Debug.Log("Scale:" + value);
        if (!ignoreSliderChangedEvent)
        {
            //Debug.Log("来发送");
            extraOperating = true;
        }

        currentOperationType = ExtraOperationType.Scale;

        DoSetScale(value);

        extraOperatingEndTime = Time.realtimeSinceStartup + 0.2f;
    }
    
    public void SetSlider(ContainerView view)
    {
        //Debug.Log("接到消息，设定滑条位置");
        SetIgnoreSliderChangedEvent(true);
        float y = view.transform.localEulerAngles.y;
        if (y > 180) y -= 360;
        if (y < -180) y += 360;

        control.sliderRotate.value = y / 180;

        float originScale = view.originLocalScal;
        currentScaleFactor = view.transform.localScale.x / originScale;

        if (currentScaleFactor > 100)
            currentScaleFactor = 100;
        if (currentScaleFactor < 0.02)
            currentScaleFactor = 0.02f;

        //currentScaleFactor *= currentScaleFactor;
        control.sliderScale.value = Mathf.Sqrt( currentScaleFactor);
    }

    void OnNavigationStart(Vector3 delta)
    {
        currentOperationType = ExtraOperationType.Unknown;
        extraOperating = true;
        Debug.Log("navigation start");
    }

    void OnNavigationUpdate(Vector3 delta)
    {
        if(currentOperationType == ExtraOperationType.Rotate)
        {
            //DoExtraRotation(new Vector3(0, delta.x * 2, 0));
            DoExtraRotation(delta.x * -2f);
        }
        else if (currentOperationType == ExtraOperationType.Scale)
        {
            DoExtraScale(delta.y*0.03f);
        }
        else
        {
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                currentOperationType = ExtraOperationType.Rotate;
                //currentRorateFactorDelta = currentRotateFactor;
            }
            else
            {
                currentOperationType = ExtraOperationType.Scale;
            }
        }


    }

    void OnNavigationEnd(Vector3 delta)
    {
        Debug.Log("navigation end");
        extraOperating = false;
        currentOperationType = ExtraOperationType.Unknown;
    }

    float lastTime = 0;
    void OnTap(int tapCount)
    {
        if (focusedPlanetName != null && !selected)
        {
            //Debug.Log("--------> Tap to select! [" + selectedPlanet.animating + "] " + selectedPlanet + (Time.realtimeSinceStartup - lastTime));
            lastTime = Time.realtimeSinceStartup;
            SelectOnePlanet(focusedPlanetName);
        }
        else if (selected)
        {
            //Debug.Log("--------> Tap to Back! [" + selectedPlanet.animating + "]" + selectedPlanet + (Time.realtimeSinceStartup - lastTime));
            lastTime = Time.realtimeSinceStartup;
            PutBackPlanet();
        }
    }

    void SetSunLightDirection(PlanetObject planet,Transform t)
    {
        SunLightReceiver[] slrs = planet.gameObject.GetComponentsInChildren<SunLightReceiver>();
        if(slrs==null)
        {
            return;
        }
        foreach(SunLightReceiver slr in slrs)
        {
            slr.Sun = t;
        }
    }

    public void SelectOnePlanet(string name, System.Action cb = null, bool sendMsg = true,bool animating = true,float animationStartUniverseTime = -1)
    {
        if(selected)
        {
            //Debug.Log("Select Blocked!!!!!!!!!!!");
            return;
        }

        if (planetMap.ContainsKey(name))
        {
            PlanetObject sel = planetMap[name];
            if (sendMsg && connectToServer)
            {
                MsgEntry me_toSend = sel.CreateMsgEntry();
                Debug.Log("Send select plaent![" + name + "]");
                cm.SendMessage(new MsgEntry[1] { me_toSend });
            }
        }
    }

    public IEnumerator PlanetTransformAnimation(PlanetObject planet, Vector3 originPos, Vector3 finalPos, float originScal, float finalScal, AnimationCurve ac, float startTime, System.Action cbFinish = null)
    {
        //Debug.Log("<<<<<<<<<<<<<<<  Animation start!");
        planet.animating = true;
        Transform transform = planet.gameObject.transform;
        if(ac.length<=0)
        {
            transform.localScale = finalScal * Vector3.one;
            transform.localPosition = finalPos;
            yield break;
        }
        float processTime = ac.keys[ac.length - 1].time;
        while(universeView.universeTime - startTime<processTime)
        {
            if(animationInterrupt)
            {                
                animationInterrupt = false;

                //Debug.Log("]]]]]]]]]]]] Animation stop! 1");
                planet.animating = false;
                break;
            }

            float mix = ac.Evaluate(universeView.universeTime - startTime);

            transform.localPosition = originPos * (1 - mix) + finalPos * mix;
            transform.localScale = Vector3.one * (originScal * (1 - mix) + finalScal * mix);
            yield return null;
        }
        //Debug.Log("]]]]]]]]]]]] Animation stop! 2");
        planet.animating = false;

        if (cbFinish != null)
            cbFinish();
    }

    public void InterruptAllAnimation()
    {
        //StopCoroutine("PlanetTransformAnimation");
        animationInterrupt = true;
        cv_originContainer.extraOperation = false;
        cv_selected.extraOperation = false;
    }

    public void PutBackPlanet(bool animate = true)
    {
        if(!selected)
        {
            //Debug.Log("Back Blocked!!!!!!!!!!!!");
            return;
        }

        if (connectToServer )
        {
            //Debug.Log("Send back planet!!!");
            cm.SendMessage(new MsgEntry[1] { planetObject_notSelected.CreateMsgEntry() });
        }
        else
        {
            // 单机版再说吧！！ 
        }
    }

    private float currentScaleFactor = 1f;
    public void DoExtraScale(float scaleFactor)
    {
        currentScaleFactor += scaleFactor;
        SetScale();
    }

    private void DoSetScale(float scaleFactor)
    {
        currentScaleFactor = scaleFactor*scaleFactor;
        SetScale();
    }

    private void SetScale()
    { 
        if (currentScaleFactor > 100)
            currentScaleFactor = 100;
        if (currentScaleFactor < 0.02)
            currentScaleFactor = 0.02f;

        float originScale = cv_originContainer.originLocalScal;
        //currentScaleFactor *= currentScaleFactor;
        float newScale = currentScaleFactor * originScale;
        cv_originContainer.transform.localScale = Vector3.one * newScale;
    }

    private float currentRotateFactor = 0f;
    public void DoExtraRotation(float eulerAngleY)
    {
        currentRotateFactor += eulerAngleY;
        while (currentRotateFactor > 180)
            currentRotateFactor -= 360;
        while (currentRotateFactor < -180)
            currentRotateFactor += 360;
        SetRotation(new Vector3(0, currentRotateFactor, 0));
        //Debug.Log("我自己来转");
    }
    private void SetRotation(Vector3 eulerAngles)
    {
        if (false/*selected*/)
        {
            selectedContainer.localEulerAngles = cv_selected.originEulerAngles;
            selectedContainer.Rotate(eulerAngles);
        }
        else
        {
            originContainer.localEulerAngles = cv_originContainer.originEulerAngles;
            originContainer.Rotate(eulerAngles);
        }
    }

    void SetChildrenVisible(GameObject go,bool visible)
    {
        Renderer[] renders = go.GetComponentsInChildren<Renderer>();
        foreach(Renderer r in renders)
        {
            r.enabled = visible;            
        }
    }

    public Vector3 GetPlanetWorldPosition(string planetName)
    {
        return planetMap[planetName].transform.position;
    }

    public void SetFocusedPlanet(string name)
    {
        focusedPlanetName = name;
    }


    public void Init()
    {
        cv_selected = selectedContainer.gameObject.GetComponent<ContainerView>();
        cv_originContainer = originContainer.gameObject.GetComponent<ContainerView>();

        cv_selected.containerType = ContainerView.ContainerType.SelectedContainer;
        cv_originContainer.containerType = ContainerView.ContainerType.OriginContainer;


        //selectedPlanet = new PlanetObject();
        selectedPlanet = planetObject_notSelected;

        gazeManager = MultiInputManager.Instance;

        if(expControl!=null)
        {
            expControl.Init();
        }

        cm = CollaborationManager.Instance;
        cm.AddMessageHandler(this);
    }

    public void DealMsgEntries(MsgEntryLocal[] messages,bool is_full)
    {
        if (is_full&& connectToServer)
        {
            // 全场景同步！
            Debug.Log("全场景同步！roomInitTime:" + cm.roomInitTime);
            long timeCut = new DateTime(1970, 1, 1).Ticks;
            long timeNow = DateTime.UtcNow.Ticks;
            long universeTimeTicks = timeNow - timeCut - cm.roomInitTime;

            timeDelay = cm.GetSyncDelay() * 1.0f / 10000000;
            //Debug.Log("time delay:" + timeDelay);
            this.universeView.universeTime = timeDelay + universeTimeTicks * 1.0f / 10000000;
        }

        if (messages != null)
        {
            for(int i =0;i<messages.Length;i++)
            {
                MsgEntryLocal msgEntry = messages[i];
                switch (msgEntry.obj_type)
                {
                    case PlanetObject.OBJECT_TYPE:
                        {
                            //如果是行星的情况
                            //Debug.Log("get planet");
                            //PlanetView pv = msg
                            SetPlanetStatus(msgEntry);
                            break;
                        }
                    case ContainerObject.OBJECT_TYPE:
                        {
                            //如果是行星容器的情况
                            //Debug.Log("get container");
                            SetContainerStatus(msgEntry);
                            break;
                        }
                }
            }
        }
    }

    protected void DealMessage(SyncProto proto)
    {
        MsgEntry[] messages = proto.sync_msg.msg_entry;
        //Debug.Log("deal message");
        if (messages == null)
            return;
        
        MsgEntryLocal[] messages_local = new MsgEntryLocal[messages.Length];
        for(int i =0;i<messages.Length;i++)
        {
            messages_local[i] = new MsgEntryLocal(messages[i].show_id, messages[i].obj_type, messages[i].pr);
            
        }
        DealMsgEntries(messages_local, proto.sync_msg.is_full);
    }

    public void SetContainerStatus(MsgEntryLocal me)
    {
        //cv_originContainer.TransformToTarget(me.pr);
        if (me.show_id.Equals(ContainerView.ContainerType.OriginContainer.ToString()))
        {
            cv_originContainer.TransformToTarget(me.pr);
            //Debug.Log("origin set to:"+me.pr[7]);
        }
        else
        {
            cv_selected.TransformToTarget(me.pr);
            //Debug.Log("selected moved");
        }
    }

    private void RefreshPlanetStatus(PlanetObject po, float startTime)
    {
        if (po == null)
        {
            selected = false;
            SetChildrenVisible(originContainer.gameObject, true);
            //SetSunLightDirection(po, fakeSun);
        }
        else
        {
            selected = true;
            SetChildrenVisible(originContainer.gameObject, false);
            SetChildrenVisible(po.gameObject, true);
            if(expControl!=null)
            {
                expControl.DoExplosion(cv_originContainer.transform.position, currentScaleFactor);
            }
           
            //Debug.Log(transform.position);
        }

        foreach (PlanetObject obj in planetMap.Values)
        {
            if (obj == po)
            {
                obj.selected = true;
                obj.animationStartUniverseTime = startTime;
            }
            else
            {
                if (obj.selected)
                {
                    obj.animationStartUniverseTime = startTime;
                }
                obj.selected = false;
            }
        }
    }

    public void SetPlanetStatus(MsgEntryLocal me)
    {
        float[] data = me.pr;
        //Debug.Log("星球序号为:" + data[0] + ":" + (PlanetObject.PlanetType)(int)data[0]);
        //Debug.Log("切换动画开始时间为:" + data[1]);

        PlanetObject po = null;
        if (((int)data[0]) != (int)PlanetObject.PlanetType.NOTSELECTED)
        {
            //有星球被选择
            po = planetMap[Enum.GetName(typeof(PlanetObject.PlanetType), (PlanetObject.PlanetType)data[0])];
        }

        RefreshPlanetStatus(po, data[1]);
    }


    public IEnumerator UpdateContainerData()
    {
        if(!connectToServer)
        {
            yield break;
        }

        while (true)
        {
            if (extraOperating)
            {
                cm.SendMessage(new MsgEntry[1] { cv_originContainer.co.CreateMsgEntry() });
                if (Time.realtimeSinceStartup > extraOperatingEndTime)
                {
                    extraOperating = false;
                }
            }
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }

    void IMessageHandler.DealMessage(SyncProto proto)
    {

        this.DealMessage(proto);
    }

}
