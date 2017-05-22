using MEHoloClient.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseObject : DefaultObjectObserver {


    public const string OBJECT_TYPE = "Universe";

    public UniverseView uv;

    protected override string GetObjectType() { return UniverseObject.OBJECT_TYPE; }

    public virtual void Init()
    {
        //this.id = bv.info.id.ToString();
        // localPosition，localRotation，localScaleFactor
        info = new float[2];

    }

    private void Awake()
    {
        Init();
    }


    // Use this for initialization
    void Start()
    {
        
        //info[0] = bv.info.GetCompressedInt();
        //UpdateData();
    }

    // Update is called once per frame
    void Update()
    {
        //do nothing
    }


    public void UpdateData()
    {
        info[0] = uv.universeTime;
        //info[1] = DateTime.UtcNow.Ticks / 1000000;
        long timeCache = DateTime.UtcNow.Ticks / 100000;

    }

    public MsgEntry CreateMsgEntry()
    {
        UpdateData();
        this.id = this.GetObjectType();
        MsgEntry entry = new MsgEntry(OP_TYPE.UPD, id, true, info, null, null);
        entry.obj_type = GetObjectType();
        return entry;
    }

    public ShowObject CreateShowObject()
    {
        UpdateData();
        ShowObject so = new ShowObject(this.GetObjectType(), true, info, info);
        so.obj_type = this.GetObjectType();
        return so;
    }
}
