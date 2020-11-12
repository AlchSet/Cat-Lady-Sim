using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class LogoScene : MonoBehaviour {


    public VideoPlayer vid;
	// Use this for initialization
	void Start () {
        vid = GetComponent<VideoPlayer>();
        vid.loopPointReached += CheckOver;
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
        Debug.Log("VIDEO HAS ENDED");

        SceneManager.LoadScene(1);
    }

    
}
