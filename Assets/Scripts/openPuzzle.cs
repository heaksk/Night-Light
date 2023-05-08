using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Key.KeyType keyType;

    public Player player;

    public int KeysNeeded;


    private void Start()
    {
        gameObject.SetActive(false);
    }
    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        if (player.GetKeys() >= KeysNeeded)
        {
            for (int i = 0; i < KeysNeeded; i++)
            {
                player.RemoveKey(GetKeyType());
            }
            gameObject.SetActive(true);
            //Instantiate(gameObject, transform.position, transform.rotation);
        }
    }
    private void Update()
    {
        OpenDoor();
    }
}
