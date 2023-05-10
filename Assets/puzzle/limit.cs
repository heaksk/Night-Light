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
        // 获取当前物体的位置
        Vector3 pos = transform.position;

        // 计算物体的新位置
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // 限制物体的位置在指定范围内
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        // 更新物体的位置
        transform.position = pos;
    }
}
