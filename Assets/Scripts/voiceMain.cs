using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voiceMain : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource audioSource;

    public AudioClip book;
    public AudioClip door;
    public AudioClip key;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        switch (collision.gameObject.tag)
        {
            case "book":
                audioSource.clip = book;
                break;
            case "door":
                audioSource.clip = door;
                break;
            case "key":
                audioSource.clip = key;
                break;
            default:
                audioSource.clip = null;
                break;
        }
        audioSource.Play();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
