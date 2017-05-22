using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceTravel : MonoBehaviour {

    public AnimationCurve curve_approach_position, curve_approach_scale, curve_approach_rotation, curve_leave_position, curve_leave_scale, curve_leave_rotation;
    public Transform player;
    public Transform target;
    public Transform rootGameObject;
    public float processTime;

    [HideInInspector]
    public float orbitHeight = 1;

    [HideInInspector]
    public bool switching,following;

    Dictionary<string, Transform> spaceMap;



    private Vector3 originPos, originScal;
    private Quaternion originRot;



    public void EnterOrbit()
    {

    }
    
    

    IEnumerator TargetFitToPlayer()
    {
        //场景根据目标适配到玩家视角，看起来像是玩家过去了，适用于摄像机不能移动的情况
        originPos = rootGameObject.position;
        originRot = rootGameObject.rotation;
        originScal = rootGameObject.localScale;
        Vector3 originTargetPos = target.position;

        //计算'最终'位置
        Vector3 finalPos = player.position + (player.forward * orbitHeight - target.position);
        //计算'最终'缩放
        Vector3 finalScal = 2 * originScal;
        //计算'最终'旋转
        Vector3 playerRotBackup = player.localEulerAngles;
        player.LookAt(target);
        Vector3 rotOffset = playerRotBackup - player.localEulerAngles;
        Debug.Log("rotOffset:" + rotOffset);
        player.localEulerAngles = playerRotBackup;
        Quaternion finalRot = Quaternion.Euler(rootGameObject.localEulerAngles + rotOffset);
        
        Debug.Log("originPos" + originPos);
        Debug.Log("originRot:" + originRot);
        Debug.Log("originScal:" + originScal);
        Debug.Log("targetPos" + finalPos);
        Debug.Log("targetRot:" + finalRot);
        Debug.Log("targetScal:" + finalScal);


        float timeStart = Time.time;
        float percentage = 0;
        while (percentage < 1)
        {
            yield return null;
            //修正最终位置
            finalPos += target.position - originTargetPos;
            originTargetPos = target.position;

            percentage = (Time.time - timeStart) / processTime;
            float scalMix = curve_approach_scale.Evaluate(percentage);
            float posMix = curve_approach_position.Evaluate(percentage);
            float rotMix = curve_approach_rotation.Evaluate(percentage);
            Debug.Log("posMix:" + posMix);
            rootGameObject.position = originPos * (1 - posMix) + finalPos * posMix;
            rootGameObject.rotation = Quaternion.Lerp(originRot, finalRot, rotMix);
            //rootGameObject.localScale = originScal * (1 - scalMix) + finalScal * scalMix;

            
        }
        StartCoroutine(TargetFollowPlayer());
    }

    IEnumerator TargetFollowPlayer()
    {
        following = true;
        while (following)
        {
            yield return null;
            Vector3 offset = player.position + player.forward * orbitHeight - target.position;

            rootGameObject.position += offset;

            
        }
    }

    
    

// Use this for initialization
void Start () {
		if(processTime<=0)
        {
            processTime = 2;
        }
        spaceMap = new Dictionary<string, Transform>();
        spaceMap.Add("Earth", GameObject.Find("Earth").transform);
        spaceMap.Add("Jupiter", GameObject.Find("Jupiter").transform);
        spaceMap.Add("Mars", GameObject.Find("Mars").transform);
        spaceMap.Add("Sun", GameObject.Find("Sun").transform);

        originPos = rootGameObject.position;
        originRot = rootGameObject.rotation;
        originScal = rootGameObject.localScale;

    }

    // Update is called once per frame
    void Update () {
		
	}


    void BackToGodView()
    {
        rootGameObject.position = originPos;
        rootGameObject.rotation = originRot;
        rootGameObject.localScale = originScal;
    }

    void OnGUI()
    {
        //开始按钮  
        if (GUI.Button(new Rect(0, 10, 100, 30), "Earth"))
        {
            BackToGodView();
            target = spaceMap["Earth"];
            StartCoroutine(TargetFitToPlayer());
        }
        //stop button  
        if (GUI.Button(new Rect(0, 60, 100, 30), "Mars"))
        {
            BackToGodView();
            target = spaceMap["Mars"];
            StartCoroutine(TargetFitToPlayer());
        }
        //重启开始    
        if (GUI.Button(new Rect(0, 110, 100, 30), "Jupiter"))
        {
            BackToGodView();
            target = spaceMap["Jupiter"];
            StartCoroutine(TargetFitToPlayer());
        }
        if (GUI.Button(new Rect(0, 160, 100, 30), "Sun"))
        {
            BackToGodView();
            target = spaceMap["Sun"];
            StartCoroutine(TargetFitToPlayer());
        }
        //if(tex!=null)  
        //GUI.DrawTexture(new Rect(200, 200, 200, 180), tex);    
    }
}
