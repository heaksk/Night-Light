using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bedpeng : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip bed;
    public AudioClip wall;

    public void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
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
