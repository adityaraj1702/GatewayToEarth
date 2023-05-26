using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;
    private float xRotation = 0f;
    public float xSensitivity = 30f;
    public float ySensitivity = 30f;

    public void ProcessLook(Vector2 input)
    {
        float mouseX = input.x * xSensitivity * Time.deltaTime;
        float mouseY = input.y * ySensitivity * Time.deltaTime;
        //calculate camera rotaion for looking up and down
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f);
        //applying this to camera transform
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        //rotate player to look left and right
        transform.Rotate(Vector3.up * mouseX);
    }

    private void Start() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
