using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniverseView : MonoBehaviour {
    public static UniverseView Instance;
    private float _universeTime;
    public float universeTime
    {
        get
        {
            return _universeTime;
        }
        set
        {
            _universeTime = value;
            startRealTicks = DateTime.UtcNow.Ticks;
            startUniverseTime = _universeTime;
        }
    }
    [HideInInspector]
    public UniverseObject uo;
    public float universeID;
    private float startUniverseTime;
    private long startRealTicks;
    // Use this for initialization
    void Awake()
    {
        Instance = this;
        uo = new UniverseObject();
        uo.Init();
        uo.uv = this;
        universeID = UnityEngine.Random.value;//不知道传输精度会不会导致问题
        long idTemp = (long)(universeID * 10000000.0f);
        universeID = (float)(idTemp % 10000000);
        universeID /= 1000.0f;
        //Debug.Log("uo ini232323234234234t");
    }

    void Start () {
		
	}

    public void UpdateUniverseTime()
    {
        universeTime = (DateTime.UtcNow.Ticks - startRealTicks) * 1.0f / 10000000 + startUniverseTime;
        //lastFrameTime = Time.time;
    }

    public void SetUniverseTime(float nTime)
    {
        universeTime = nTime;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
