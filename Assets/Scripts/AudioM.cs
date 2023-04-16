using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioM : MonoBehaviour
{
    // Start is called before the first frame update
    static AudioM current;

    [Header("Touch voice")]
    public AudioClip bed;
    public AudioClip wall;

    [Header("Footstep")]
    public AudioClip footstep;

    AudioSource bedSource;
    AudioSource wallSource;
    AudioSource footstepSource;
    private void Awake()
    {
        current = this;
        //DontDestroyOnLoad(gameObject);

        bedSource = gameObject.AddComponent<AudioSource>();
        wallSource = gameObject.AddComponent<AudioSource>();
        footstepSource = gameObject.AddComponent<AudioSource>();
    }

    public static void PlayFootsetpAudio()
    {
        current.footstepSource.Play();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
