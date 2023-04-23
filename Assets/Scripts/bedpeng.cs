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
    public AudioClip cabinet;
    public AudioClip shelf;
    public AudioClip book;
    public AudioClip table;
    public AudioClip chair;
    public AudioClip door;
    public AudioClip key;

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
            case "cabinet":
                audioSource.clip = cabinet;
                break;
            case "shelf":
                audioSource.clip = shelf;
                break;
            case "book":
                audioSource.clip = book;
                break;
            case "table":
                audioSource.clip = table;
                break;
            case "chair":
                audioSource.clip = chair;
                break;
            case "door":
                audioSource.clip = door;
                break;
            case "key":
                audioSource.clip = key;
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
