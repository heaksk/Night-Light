using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraLimit : MonoBehaviour
{
    // Start is called before the first frame update
    public float minY = -5f; // y轴最小值
    public float maxY = 5f; // y轴最大值
    public float moveSpeed = 5f;
    // 每一帧更新一次物体的位置
    void Update()
    {
        // 获取物体在x和y轴上的移动量
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float moveY = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // 计算物体移动后的新位置
        Vector3 newPosition = transform.position + new Vector3(moveX, moveY, 0f);

        // 将新位置限制在移动范围内
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        // 将物体移动到新位置
        transform.position = newPosition;
    }
}
