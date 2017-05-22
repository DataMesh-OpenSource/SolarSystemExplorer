using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultObject : MonoBehaviour
{
    public const string OBJECT_TYPE = "Default";

    [HideInInspector]
    public string id;

    public string type { get { return GetObjectType(); } }
    protected virtual string GetObjectType() { return DefaultObject.OBJECT_TYPE; }

    protected Transform trans;

    protected int infoLength = 6;

    protected Vector3 targetPos = new Vector3();
    protected Vector3 targetRot = new Vector3();

    public float moveSpeed = 5f;


    protected void Awake()
    {
        trans = transform;
    }

    /// <summary>
    /// 将物体跟随目标的方法
    /// 此处是默认物体的行为
    /// 此方法也可以被重写，以便子类实现自己的行为
    /// </summary>
    /// <param name="immediate"></param>
    protected virtual void FollowTarget(bool immediate)
    {
        if (immediate)
        {
            trans.localPosition = targetPos;
            trans.localEulerAngles = targetRot;
        }
        else
        {
            if (trans.localPosition != targetPos)
            {
                trans.localPosition = Vector3.Lerp(trans.localPosition, targetPos, Time.deltaTime * moveSpeed);
            }

            /*
            if (trans.localEulerAngles != targetRot)
            {
                trans.localEulerAngles = Vector3.LerpUnclamped(trans.localEulerAngles, targetRot, Time.deltaTime);
            }
            */

            // 角度无法用差值显示，因为无法确定旋转方向，所以直接设置 
            trans.localEulerAngles = targetRot;
        }
    }

    /// <summary>
    /// Update周期函数，可被重写
    /// </summary>
    protected virtual void Update()
    {
        FollowTarget(false);
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

    }

    /// <summary>
    /// 用消息数据填写对象内容
    /// </summary>
    /// <param name="info"></param>
    /// <param name="immediately"></param>
    public virtual void FillObjectByInfo(float[] info, bool immediately = false)
    {
        if (info.Length != infoLength)
            return;

        targetPos = new Vector3(info[0], info[1], info[2]);
        targetRot = new Vector3(info[3], info[4], info[5]);

        if (immediately)
        {
            FollowTarget(true);
        }
    }



    public virtual void Destory()
    {
        GameObject.Destroy(gameObject);
    }

}
