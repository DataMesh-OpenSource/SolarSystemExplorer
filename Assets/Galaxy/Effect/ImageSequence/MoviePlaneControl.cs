using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(AudioSource))]

public class MoviePlaneControl : MonoBehaviour {

    public MovieTexture movieTexture;
    //AudioSource audio;
	// Use this for initialization
	void Start () {
        GetComponent<Renderer>().material.mainTexture = movieTexture as MovieTexture;
        
        //audio = GetComponent<AudioSource>();
        //audio.clip = movieTexture.audioClip;
        movieTexture.Play();
        //audio.Play();
        movieTexture.loop = true;
        //audio.loop = true;
        transform.localScale = new Vector3((float)movieTexture.width/1000, 1, (float)movieTexture.height/1000);
        
	}


    
	
	// Update is called once per frame
	void Update () {
	}
}
