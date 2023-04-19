using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{

    public float sensitivity = 120f;

    public Transform orientation;

    float mouseX;
    float mouseY;
    float xRotation;
    float yRotation;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        
        mouseX = Input.GetAxisRaw("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxisRaw("Mouse Y") * sensitivity * Time.deltaTime;

        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
        orientation.localRotation = Quaternion.Euler(0,yRotation, 0f);
    }
}