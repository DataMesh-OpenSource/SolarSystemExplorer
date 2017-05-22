using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformFollow : MonoBehaviour {

    public Transform target;
    public bool rotationFollow = true;
    public bool lookAt = false;
    public Transform transform_lookAt;
	// Use this for initialization
	void Start () {
		if(target==null)
        {
            Destroy(GetComponent<TransformFollow>());
        }
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = target.position;
        if(rotationFollow)
        {
            transform.rotation = target.rotation;
        }
        if(lookAt)
        {
            transform.LookAt(transform_lookAt);
        }
	}

    public void DoFollow()
    {
        if(rotationFollow)
        {
            transform.rotation = target.rotation;
        }
        transform.position = target.position;
        if (lookAt)
        {
            //transform.LookAt(transform_lookAt);
        }
    }
}
