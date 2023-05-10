using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public float minY = -5f; // y����Сֵ
    public float maxY = 5f; // y�����ֵ
    public float moveSpeed = 5f;
    // ÿһ֡����һ�������λ��
    void Update()
    {
        // ��ȡ������x��y���ϵ��ƶ���
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // ���������ƶ������λ��
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0f);

        // ����λ���������ƶ���Χ��
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // �������ƶ�����λ��
        transform.position = newPosition;
    }
}
