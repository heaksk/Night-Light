using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class test : MonoBehaviour
{
    [Header("UI ietem")]
    public Text textLabel;
    public Image faceImage;

    [Header("Test folder")]
    public TextAsset textFile;
    public int index;

    List<string> textList = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        GetTextFromFile(textFile);
        index = 0;
        //this.GetComponent<KeyCode.W>.enabled= false
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && index == textList.Count)
        {
            gameObject.SetActive(false);
            return;
        }
            if (Input.GetKeyDown(KeyCode.Space))
        {
            textLabel.text = textList[index];
            index++;
        }
    }
    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }
}
