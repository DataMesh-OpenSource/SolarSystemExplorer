using MEHoloClient.Entities;
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
        MsgEntry entry = new MsgEntry(OP_TYPE.UPD, id, true, info, null, null);
        entry.obj_type = GetObjectType();
        return entry;
    }

    public ShowObject CreateShowObject()
    {
        UpdateData();
        this.id = this.cv.containerType.ToString();
        ShowObject so = new ShowObject(this.cv.containerType.ToString(), true, info, info);
        so.obj_type = this.GetObjectType();
        return so;
    }
}
