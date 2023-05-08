using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifhtOnOff : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject camera;
    public double distance;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(light1.transform.position, camera.transform.position);
        print(distance);//���ƺ�����ľ����ӡ����
        if (distance < 2)//�����ж�����
        {
            light1.SetActive(true);
            light2.SetActive(true);
            light3.SetActive(true);
        }
        else
        {
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
        }
    }
}
