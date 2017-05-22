using UnityEngine;
using System.Collections;

public class ImageSeqControl : MonoBehaviour
{
    public string folderName;
    public bool loop,lookAtCam=true;
    public int fps = 25;
    public int frameLoopFrom = 0;
    public float lastBreath = 0;


    private float _alpha;
    public float alpha
    {
        get
        {
            return _alpha;
        }
        set
        {
            _alpha = value;
            goMaterial.SetFloat("_SideAlpha", _alpha);
            goMaterial.SetFloat("_CenterAlpha", _alpha*_alpha-0.1f);
        }


    }



    public float uniScale = 1;
    private Vector3 originSize;
    float startTime;
    float frameDelay;
    bool isDying = false;
    //An array of Objects that stores the results of the Resources.LoadAll() method  
    private Object[] objects;
    //Each returned object is converted to a Texture and stored in this array  
    private Texture[] textures;
    //With this Material object, a reference to the game object Material can be stored  
    private Material goMaterial;
    //An integer to advance frames  
    private int frameCounter = 0;

    void Awake()
    {
        //Get a reference to the Material of the game object this script is attached to  
        if(fps<=0)
        {
            fps = 25;
        }
        frameDelay = 1 / (float)fps;
        if(uniScale<0)
        {
            uniScale = 1;
        }

    }

    public void Init()
    {
        //Load all textures found on the Sequence folder, that is placed inside the resources folder  
        objects = Resources.LoadAll(folderName, typeof(Texture));

        //Initialize the array of textures with the same size as the objects array  
        textures = new Texture[objects.Length];

        //Cast each Object to Texture and store the result inside the Textures array  
        for (int i = 0; i < objects.Length; i++)
        {
            textures[i] = (Texture)objects[i];
        }
        if (textures.Length - 1 < frameLoopFrom)
        {
            frameLoopFrom = 0;
        }


        originSize = new Vector3((float)textures[0].width / 1000, 1, (float)textures[0].height / 1000) * uniScale;
        this.goMaterial = GetComponent<Renderer>().material;
        this.goMaterial.mainTexture = textures[0];
        startTime = Time.time;
    }
    

    public void PlayOnce()
    {
        startTime = Time.time;
        gameObject.SetActive(true);
        isDying = false;
    }

    void Update()
    {


        transform.localScale = uniScale * Vector3.one;// * originSize;
        if (!isDying)
        {
            frameCounter = (int)((Time.time - startTime) * fps);
            goMaterial.mainTexture = textures[frameCounter];
            //frameCounter++;
        }
        

        if (frameCounter == textures.Length - 1)
        {
            if(loop)
            {
                startTime = Time.time - (float)frameLoopFrom / fps;
            }
            else
            {
                isDying = true;
                if(Time.time-startTime>lastBreath)
                {
                    gameObject.SetActive(false);
                    //Destroy(gameObject);
                }
                
            }
            
        }

        if(lookAtCam)
        {
            Vector3 cameraPos = new Vector3(0, 10, 100);
            if (Camera.main!=null)
            {
                cameraPos = Camera.main.transform.position;
            }
            gameObject.transform.LookAt(cameraPos);
            Vector3 rot = gameObject.transform.localEulerAngles;
            rot.x += 90;
            rot.x = (360 + rot.x) % 360;
            rot.x = (rot.x + 90) / 2;
            gameObject.transform.localEulerAngles = rot;
        }

    }
    
    //IEnumerator PlayLoop(float delay)
    //{
    //    yield return new WaitForSeconds(delay);

    //    //Advance one frame  
    //    //frameCounter = (++frameCounter) % textures.Length;
    //    frameCounter++;
    //    //Stop this coroutine  
    //    StopCoroutine("PlayLoop");
    //}

    ////A method to play the animation just once  
    //IEnumerator Play(float delay)
    //{
    //    //Wait for the time defined at the delay parameter  
    //    yield return new WaitForSeconds(delay);

    //    //If the frame counter isn't at the last frame  
    //    if (frameCounter < textures.Length - 1)
    //    {
    //        //Advance one frame  
    //        ++frameCounter;
    //    }

    //    //Stop this coroutine  
    //    StopCoroutine("PlayLoop");
    //}

}