using MEHoloClient.Core.Entities;
using MEHoloClient.Proto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetObject : DefaultObjectObserver {

    public const string OBJECT_TYPE = "Planet";

    //public PlanetView pv;

    private bool _selected = false;
    public bool selected
    {
        get { return _selected; }
        set
        {
            _selected = value;
            if (_selected)
            {
                targetPos = Vector3.zero;
                targetScale = scaleSelect;
                SetSunLightDirection(SolarSystem.Instance.fakeSun);
                //transform.localScale = Vector3.one * originLocalScale * SolarSystem.Instance.selectedScaleFactor;
            }
            else
            {
                SetSunLightDirection(SolarSystem.Instance.realSun);
                targetPos = GetPlanetPosition();
                targetScale = scaleNormal;
            }
        }
    }
    public bool animating = false;

    public PlanetType planetType;

    private float scaleFactor = 12;

    public enum PlanetType
    {
        NOTSELECTED,
        Mercury,
        Venus,
        Earth,
        Mars,
        Jupiter,
        Saturn,
        Uranus,
        Neptune,
        Pluto
    }

    public float planetScaleFactor;

    public float moveSpeed = 3;

    [HideInInspector]
    public float radius_revol;
    [HideInInspector]
    public float radianSpeed_revel;
    [HideInInspector]
    public float rotationSpeed_Y;
    [HideInInspector]
    public float startRadian;
    [HideInInspector]
    public float originLocalScale;
    [HideInInspector]
    public float animationStartUniverseTime;

    public float currentRadian;

    protected override string GetObjectType() { return PlanetObject.OBJECT_TYPE; }

    private Vector3 scaleSelect;
    private Vector3 scaleNormal;

    public void Init()
    {
        info = new float[2];

        OrbitUpdater ou = GetComponent<OrbitUpdater>();
        if(ou==null)
        {
            return;
        }
        Vector3 v3 = transform.localPosition;
        radius_revol = v3.magnitude;

        startRadian = Mathf.Acos(v3.x / v3.magnitude);
        if (v3.z < 0)
        {
            startRadian *= -1;
        }
        //planet.startRadian = 0;

        radianSpeed_revel = Mathf.PI / ou.Period * scaleFactor;
        originLocalScale = transform.localScale.x;
        Destroy(ou);

        scaleSelect = Vector3.one * originLocalScale * SolarSystem.Instance.selectedScaleFactor * this.planetScaleFactor;
        scaleNormal = Vector3.one * originLocalScale;

        selected = false;

    }

    void SetSunLightDirection(Transform t)
    {
        SunLightReceiver[] slrs = GetComponentsInChildren<SunLightReceiver>();
        if (slrs == null)
        {
            return;
        }
        foreach (SunLightReceiver slr in slrs)
        {
            slr.Sun = t;
        }
    }

    private void Awake()
    {
        Init();
    }

    // Use this for initialization
    void Start()
    {
        

    }

    private Vector3 targetPos;
    private Vector3 targetScale;

    // Update is called once per frame
    void Update()
    {
        //do nothing
        currentRadian = startRadian + radianSpeed_revel * UniverseView.Instance.universeTime;

        if (!selected)
            targetPos = GetPlanetPosition();

        if (transform.localPosition != targetPos)
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, targetPos, Time.deltaTime * moveSpeed);
        }
        if (transform.localScale != targetScale)
        {
            transform.localScale = Vector3.Slerp(transform.localScale, targetScale, Time.deltaTime * moveSpeed);
        }
    }

    public Vector3 GetPlanetPosition(float timeOffset = 0)
    {
        float radian = currentRadian + timeOffset * radianSpeed_revel;
        return new Vector3(Mathf.Cos(startRadian + radian), 0, Mathf.Sin(startRadian + radian)) * radius_revol;

    }


    public void UpdateData()
    {
        info[0] = (int)this.planetType;
        //info[1] = pv.selected ? 1 : 0;
        //info[2] = pv.animating ? 1 : 0;
        info[1] = animationStartUniverseTime;
    }

    public MsgEntry CreateMsgEntry()
    {
        UpdateData();
        //Debug.Log("animationstarttime:" + info[3]);
        this.id = this.GetObjectType();
        // MsgEntry entry = new MsgEntry(OP_TYPE.UPD, id, true, info, null, null);

        MsgEntry entry = new MsgEntry();
        entry.OpType = MsgEntry.Types.OP_TYPE.Upd;
        entry.ShowId = id;
        entry.Pr.Add(info);
        entry.Info = new ObjectInfo();
        entry.Info.ObjType = GetObjectType();
        return entry;
    }

    public ShowObject CreateShowObject()
    {
        UpdateData();
        //ShowObject so = new ShowObject(this.GetObjectType(), true, info, info);
        ShowObject so = new ShowObject();
        so.ShowId = this.GetObjectType();
        so.Pr = info;
        so.ObjInfo = new ObjectInfo();
        so.ObjInfo.ObjType = this.GetObjectType();
        return so;
    }
}
