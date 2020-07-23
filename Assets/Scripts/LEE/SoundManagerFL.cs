using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerFL : MonoBehaviour
{
    public AudioClip soundExplosion;
    AudioSource myAudio;

    public static SoundManagerFL instance;
    // Use this for initialization
    void Awake()
    {
        if (SoundManagerFL.instance == null)
        {
            SoundManagerFL.instance = this;
        }
    }
    void Start()
    {
        //DontDestroyOnLoad(transform.gameObject);
        myAudio = GetComponent<AudioSource>();
    }
    public void PlaySound()
    {

        myAudio.PlayOneShot(soundExplosion);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
