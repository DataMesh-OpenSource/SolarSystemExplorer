using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MEHoloClient.Core.Entities;
using MEHoloClient.Proto;

public class DefaultObjectObserver : MonoBehaviour
{
    [HideInInspector]
    public string id;

    public string type { get { return GetObjectType(); } }
    protected virtual string GetObjectType() { return DefaultObject.OBJECT_TYPE; }

    /// <summary>
    /// 为传输准备的数据，float数组，所有对象都要生成此数组
    /// 因为不同对象的序列化方式不同，float数量也不同，因此这里不创建，在init中再创建，由子类实现
    /// </summary>
    protected float[] info;
    protected int infoLength = 6;

    protected Transform trans;


    protected void Awake()
    {
        trans = transform;
    }

    protected void Update()
    {
        MakeInfoForMessage();
    }

    /// <summary>
    /// 初始化方法
    /// 注意此方法中需要初始化float数组，因此需要子类分别实现自己的内容
    /// </summary>
    /// <param name="id"></param>
    /// <param name="isSelf"></param>
    public virtual void Init(string id)
    {
        this.id = id;

        // 基础类型传输6个float，前三个是位置，后三个是旋转
        info = new float[infoLength];
    }


    /// <summary>
    /// 用数据内容填写消息对象
    /// </summary>
    public virtual void MakeInfoForMessage()
    {
        //float[] rs = new float[6];
        Vector3 pos = trans.localPosition;
        Vector3 rot = trans.localEulerAngles;

        info[0] = pos.x;
        info[1] = pos.y;
        info[2] = pos.z;

        info[3] = rot.x;
        info[4] = rot.y;
        info[5] = rot.z;

        //return rs;
    }


    public ShowObject CreateShowObjectForMessage()
    {
        //ShowObject obj = new ShowObject(id, true, info, null);
        ShowObject obj = new ShowObject();
        obj.ShowId = id;
        obj.Pr = info;
        obj.ObjInfo.ObjType = type;
        return obj;
    }

    public virtual MsgEntry CreateMsgEntry()
    {
        //MsgEntry entry = new MsgEntry(OP_TYPE.UPD, id, true, info, null, null);
        MsgEntry entry = new MsgEntry();
        entry.ShowId = id;
        entry.OpType = MsgEntry.Types.OP_TYPE.Upd;
        entry.Pr.Add(info);
        entry.Info.ObjType = type;
        return entry;
    }

}
