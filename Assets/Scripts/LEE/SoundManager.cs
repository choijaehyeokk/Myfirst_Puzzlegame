using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip soundExplosion;
    AudioSource myAudio;

    public static SoundManager instance;
	// Use this for initialization
    void Awake()
    {
        if(SoundManager.instance == null)
        {
            SoundManager.instance = this;
        }
    }
	void Start ()
    {
        //DontDestroyOnLoad(transform.gameObject);
        myAudio = GetComponent<AudioSource>();
	}
	public void PlaySound()
    {
       
        myAudio.PlayOneShot(soundExplosion);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
