using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos = mainCamera.ScreenToWorldPoint(mousePos);
        mousePos.z = transform.position.z;
        Vector3 direction = mousePos - transform.position;
        float angle = Vector3.Angle(transform.up, direction);
        Vector3 cross = Vector3.Cross(transform.up, direction);
        if (cross.z < 0) {
            angle = -angle;
        }
        transform.Rotate(0, 0, angle);
    }
}

