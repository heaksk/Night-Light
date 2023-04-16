using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    static AudioManager current;

    public AudioClip wall;
    public AudioClip bed;

    AudioSource wallSource;
    AudioSource bedSource;

    private void Awake()
    {
        current = this;

        wallSource = gameObject.AddComponent<AudioSource>();
        bedSource = gameObject.AddComponent<AudioSource>();
    }
    // Start is called before the first frame update
   public static void PlayBedAudio()
    {
        //current.bedSource.clip = current.bedClip;
        current.bedSource.Play();
    }
}
