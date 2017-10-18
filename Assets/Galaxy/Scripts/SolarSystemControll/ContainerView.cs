using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerView : MonoBehaviour {

    [HideInInspector]
    public ContainerObject co;

    //public Vector3 originLocalPos,targetLocalPos;
    public Quaternion lastLocalRot,targetLocalRot;
    public float lastLocalScal,targetLocalScal,originLocalScal;
    public bool extraOperation;

    private float lastFrameTime;
    public Vector3 originEulerAngles { get; private set; }
    public enum ContainerType
    {
        OriginContainer,
        SelectedContainer
    }

    [HideInInspector]
    public ContainerType containerType;

    // Use this for initialization
    void Awake () {

        co = gameObject.AddComponent<ContainerObject>();
        co.cv = this;
        co.Init();
        extraOperation = false;

        lastLocalRot = transform.localRotation;
        lastLocalScal = transform.localScale.x;
        originLocalScal = transform.localScale.x;
        originEulerAngles = transform.localEulerAngles;
        //StartCoroutine(TweenToTargetTransform());

    }
    private void Start()
    {
        //StartCoroutine(TweenToTargetTransform());

    }
    // Update is called once per frame
    void Update () {
        if (extraOperation)
        {
            float mixValue = (Time.time - lastFrameTime) / 0.2f;
            //Debug.Log("mixValue:" + mixValue);
            if (mixValue > 1)
            {
                extraOperation = false;
            }

            //transform.localPosition = mixValue * targetLocalPos + (1 - mixValue) * originLocalPos;
            //transform.localRotation = Quaternion.Lerp(lastLocalRot, targetLocalRot, mixValue);
            transform.localRotation = targetLocalRot;
            transform.localScale = (mixValue * targetLocalScal + (1 - mixValue) * lastLocalScal) * Vector3.one;

            SolarSystem.Instance.SetSlider(this);

        }
    }

    IEnumerator TweenToTargetTransform()
    {
        while(true)
        {
            Debug.Log("extraOperation" + extraOperation.ToString());
            if (extraOperation)
            {
                float mixValue = (Time.time - lastFrameTime) / 0.2f;
                Debug.Log("mixValue:" + mixValue);
                if (mixValue>1)
                {
                    extraOperation = false;
                    continue;
                }

                //transform.localPosition = mixValue * targetLocalPos + (1 - mixValue) * originLocalPos;
                //transform.localRotation = Quaternion.Lerp(lastLocalRot, targetLocalRot, mixValue);
                transform.localRotation = targetLocalRot;
                transform.localScale = (mixValue * targetLocalScal + (1 - mixValue) * lastLocalScal) * Vector3.one;

                SolarSystem.Instance.SetSlider(this);

            }
            yield return null;
        }
        
    }

    public void TransformToTarget(Vector3 pos, Quaternion rot, float scal)
    {
        extraOperation = true;
        Debug.LogError("!!!!");
        //targetLocalPos = pos;
        targetLocalRot = rot;
        targetLocalScal = scal;
        //originLocalPos = transform.localPosition;
        lastLocalRot = transform.localRotation;
        lastLocalScal = transform.localScale.x;
        lastFrameTime = Time.time;
    }

    public void TransformToTarget(float[] data)
    {
        //Debug.Log(data[8] + " and " + UniverseView.Instance.universeID);
        if (data[8]==UniverseView.Instance.universeID)
        {
            //Debug.LogError("123");
            return;
        }

        extraOperation = true;

        //targetLocalPos = new Vector3(data[0],data[1],data[2]);
        targetLocalRot = new Quaternion(data[3], data[4], data[5], data[6]);
        targetLocalScal = data[7];
        //originLocalPos = transform.localPosition;
        lastLocalRot = transform.localRotation;
        lastLocalScal = transform.localScale.x;
        lastFrameTime = Time.time;
        
    }
}
