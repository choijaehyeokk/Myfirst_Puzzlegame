using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerPF : MonoBehaviour
{
    public AudioClip soundExplosion;
    AudioSource myAudio;

    public static SoundManagerPF instance;
    // Use this for initialization
    void Awake()
    {
        if (SoundManagerPF.instance == null)
        {
            SoundManagerPF.instance = this;
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
