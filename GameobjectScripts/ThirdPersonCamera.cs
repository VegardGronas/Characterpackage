using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ThirdPersonCamera : RegisterInputs
{
    private Vector3 rot;
    public Vector3 sensitivity;
    public Vector2 clamp;
    public float zoomSpeed;

    public Transform cam;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        RotateAroundSelf();
        CameraZoom();
    }

    private void RotateAroundSelf()
    {
        rot.x += sensitivity.x * GetMousePos.y * Time.deltaTime;
        rot.y += sensitivity.y * GetMousePos.x * Time.deltaTime;

        float x = Mathf.Clamp(rot.x, clamp.x, clamp.y);

        rot.x = x;

        transform.rotation = Quaternion.Euler(rot);
    }

    private void CameraZoom()
    {
        float step = Mathf.Clamp(GetScroll, -1, 1) * zoomSpeed * Time.deltaTime;
        cam.position = Vector3.MoveTowards(cam.position, transform.position, step);
    }
}
