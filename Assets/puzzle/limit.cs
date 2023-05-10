using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class limit : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 5.0f;
    public float minX = -5.0f;
    public float maxX = 5.0f;
    public float minY = -3.0f;
    public float maxY = 3.0f;

    private void Update()
    {
        // ��ȡ��ǰ�����λ��
        Vector3 pos = transform.position;

        // �����������λ��
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // ���������λ����ָ����Χ��
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // ���������λ��
        transform.position = pos;
    }
}
