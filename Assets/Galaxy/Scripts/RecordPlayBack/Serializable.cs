using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class RecordArr
{
    public int StartId;
    public int StopId;
    public float Startut;
    public float Stoput;
    public OneRecord[] data;
}


[Serializable]
public class OneRecord
{
    public float ut;
    public MsgEntryLocal[] me;
}

[Serializable]
public class ToServerInfo
{
    public string name;
    public string lecturerId;
    public string description;
    public string clientName;
    public int appId;
    public string bevName;
    public OneContent[] content;
}
[Serializable]
public class OneContent
{
    public string videoName;
    public int duration;
    public string modelName;
    public int modelOffset;
}


[Serializable]
public class MsgEntryLocal
{
    public string show_id;
    public string obj_type;
    public float[] pr;
    public MsgEntryLocal()
    {
    }
    public MsgEntryLocal(string show_id ,string type,float[] pr)
    {
        this.pr = pr;
        this.obj_type = type;
        this.show_id = show_id;
    }



}