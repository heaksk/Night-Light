using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkUI : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Button;
    public GameObject taklUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Button.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Button.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if(Button.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            taklUI.SetActive(true);
        }
    }
}
