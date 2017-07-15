using MEHoloClient.Entities;
using MEHoloClient.Proto;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerObject : DefaultObjectObserver
{
    public const string OBJECT_TYPE = "Container";

    public ContainerView cv;

    protected override string GetObjectType() { return ContainerObject.OBJECT_TYPE; }

    public virtual void Init()
    {
        //this.id = bv.info.id.ToString();
        // localPosition，localRotation，localScaleFactor
        info = new float[9];

    }



    // Use this for initialization
    void Start()
    {
        Init();
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
        info[0] = cv.transform.localPosition.x;
        info[1] = cv.transform.localPosition.y;
        info[2] = cv.transform.localPosition.z;

        info[3] = cv.transform.localRotation.x;
        info[4] = cv.transform.localRotation.y;
        info[5] = cv.transform.localRotation.z;
        info[6] = cv.transform.localRotation.w;

        info[7] = cv.transform.localScale.x;
        info[8] = UniverseView.Instance.universeID;
    }

    public override MsgEntry CreateMsgEntry()
    {
        UpdateData();
        this.id = this.cv.containerType.ToString();
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
        this.id = this.cv.containerType.ToString();
        //ShowObject so = new ShowObject(this.cv.containerType.ToString(), true, info, info);
        ShowObject so = new ShowObject();
        so.ShowId = this.cv.containerType.ToString();
        so.Pr = info;
        so.ObjInfo = new ObjectInfo();
        so.ObjInfo.ObjType = this.GetObjectType();
        return so;
    }
}
