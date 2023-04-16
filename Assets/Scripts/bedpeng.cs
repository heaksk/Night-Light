using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedpeng : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip bed;
    public AudioClip wall;
    public AudioClip clock;
    public AudioClip sofa;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        switch(collision.gameObject.tag)
        {
            case "wall":
            audioSource.clip = wall;
                break;
            case "bed":
                audioSource.clip = bed;
                break;
            case "clock":
                audioSource.clip = clock;
                break;
            case "sofa":
                audioSource.clip = sofa;
                break;
        }
        audioSource.Play();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
