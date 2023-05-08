using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drug : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 mouseOffset;
    private float zCoord;

    private void OnMouseDown()
    {
        // ���������ת��Ϊ3D��������
        zCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mouseOffset = gameObject.transform.position - GetMouseWorldPos();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + mouseOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = zCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
