using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour {
    public List<GameObject> planets;
    [HideInInspector]
    public List<MeshRenderer> mats_exp;
    public AnimationCurve ac_exp;
    //public AnimationCurve ac_melt, ac_disappear;
    public ImageSeqControl shockWave;
    public float maxRadius = 100;

    [HideInInspector]
    //public Transform showBall;



    // Use this for initialization
    private float startTime;
    private Vector3 expCenter;
    private bool animating = false;
    public float processTime = 2;
	
    public void Init()
    {
        shockWave.Init();
        if (planets == null)
        {

            Debug.Log("there is no material attached, exit");
        }
        if (shockWave == null)
        {
            Debug.LogError("Image sequence lost");
        }
        mats_exp = new List<MeshRenderer>();
        foreach (GameObject go in planets)
        {
            MeshRenderer[] mrs = go.GetComponentsInChildren<MeshRenderer>();
            if (mrs == null)
            {
                continue;
            }
            foreach (MeshRenderer mr in mrs)
            {
                mats_exp.Add(mr);
            }
            go.SetActive(false);
        }

        //showBall = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;
        //showBall.gameObject.SetActive(false);

        //expCenter = new Vector3(1, 0, 0);
        //processTime = ac_exp.keys[ac_exp.length - 1].value;

        //DoExplosion(new Vector3(0, 0, 0));

        shockWave.uniScale = 0;
    }

	// Update is called once per frame
	void Update () {
        
		if(animating)
        {
            float percent = (Time.time - startTime) / processTime;
            shockWave.alpha = 1 - percent;
            //Debug.Log(shockWave.alpha);
            float currentExpRadius = ac_exp.Evaluate(percent) * maxRadius;
            //float currentMeltRadius = ac_melt.Evaluate(percent) * maxRadius;
            //float currentDisappearRadius = ac_disappear.Evaluate(percent) * maxRadius;
            foreach(MeshRenderer m in mats_exp)
            {
                m.material.SetFloat("_ExpandRadius", currentExpRadius);
                //m.SetFloat("_MeltRadius", currentMeltRadius);
                //m.SetFloat("_DisappearPercent", currentDisappearRadius);
            }
            shockWave.uniScale = currentExpRadius*currentExpRadius;

            //showBall.localScale = currentExpRadius*Vector3.one;


            if(percent>=1)
            {
                animating = false;
                foreach (GameObject go in planets)
                {
                    go.SetActive(false);
                }
                //showBall.gameObject.SetActive(false);
            }
            
        }



	}

    public void DoExplosion(Vector3 solarSystemPostion,float currentScale)
    {
        shockWave.gameObject.SetActive(true);
        
        shockWave.transform.position = solarSystemPostion;
        shockWave.PlayOnce();
        //showBall.position = solarSystemPostion;
        startTime = Time.time;
        animating = true;
        //currentExpRadius = 0;
        for(int i=0;i<mats_exp.Count;i++)
        {
            
            Vector3 direct = solarSystemPostion - mats_exp[i].transform.position;
            mats_exp[i].material.SetVector("_ExpandCenter", direct);
            //Debug.Log(solarSystemPostion);
            if(direct.magnitude> maxRadius)
            {
                maxRadius = direct.magnitude;
            }

            
        }
        maxRadius *= currentScale;
        foreach(GameObject go in planets)
        {
            if((go.transform.localPosition-solarSystemPostion).magnitude>0.3f)
            {
                go.SetActive(true);
            }
        }

        //maxRadius *= 1.2f;
        //showBall.gameObject.SetActive(true);
    } 







}
