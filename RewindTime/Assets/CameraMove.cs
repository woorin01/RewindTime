using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Vector3 gap = Vector3.zero;

    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RotateCamera();
        MoveCamera();
    }

    private void MoveCamera()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 temp = (transform.right * x) + (transform.forward * y);

        transform.position += temp * Time.deltaTime * 10f;
    }

    private void RotateCamera()
    {
        float x = Input.GetAxisRaw("Mouse Y") * -1;
        float y = Input.GetAxisRaw("Mouse X");

        Vector3 temp = new Vector3(x, y) * 1.5f;

        gap += temp;

        gap.x = Mathf.Clamp(gap.x, -90f, 90f);
        transform.rotation = Quaternion.Euler(gap);
    }
}
