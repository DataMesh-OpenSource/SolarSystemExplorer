using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitTrailController : MonoBehaviour {

    public static OrbitTrailController Instance;

    public Material mat_orbitTrail;
    [Serializable]
    public struct OrbitTrail
    {
        public PlanetObject planetOjbect;
        public MeshRenderer orbitTrailRender;
        public float radianOffset;
    }


    public List<OrbitTrail> trails;



    private void Awake()
    {
        
        if(trails.Count==0)
        {
            Destroy(GetComponent<OrbitTrailController>());
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
		for(int i =0;i<trails.Count;i++)
        {
            trails[i].orbitTrailRender.material = mat_orbitTrail;
            trails[i].orbitTrailRender.material.SetFloat("_Radius", trails[i].planetOjbect.radius_revol);
        }
        StartCoroutine(AlphaRamp());
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < trails.Count; i++)
        {
            trails[i].orbitTrailRender.material.SetFloat("_CurrentRadian", trails[i].planetOjbect.currentRadian+trails[i].radianOffset);
        }
    }

    void SetTotalAlpha(float alphaValue)
    {
        for(int i =0;i<trails.Count;i++)
        {
            trails[i].orbitTrailRender.material.SetFloat("_TotalAlpha", alphaValue);
        }
    }

    float currentAlpha = 1, originAlpha = 1,aimedAlpha = 1;
    float fadingSpeed = 0;
    IEnumerator AlphaRamp()
    {
        while(true)
        {
            if(fadingSpeed!=0)
            {

                currentAlpha += fadingSpeed;
                if(currentAlpha>1)
                {
                    currentAlpha = 1;
                    fadingSpeed = 0;
                }
                else if(currentAlpha<0)
                {
                    currentAlpha = 0;
                    fadingSpeed = 0;
                }
                SetTotalAlpha(currentAlpha);

            }
            yield return new WaitForSecondsRealtime(0.2f);
        }
    }

    public void FadeOut()
    {
        fadingSpeed = -0.2f;
        aimedAlpha = 0;
    }

    public void FadeIn()
    {
        fadingSpeed = 0.2f;
        aimedAlpha = 1;

    }

}
