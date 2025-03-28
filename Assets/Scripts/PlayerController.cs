using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform cameraHolder;
    [SerializeField] private float mouseSensitivity = 1f;

    private float verticalLookRotation;

    private void Start()
    {
        LockCursor();
    }

    private void Update()
    {
        if (Timer.GameEnded)
            return;

        HandleMouseLook();
    }

    private void HandleMouseLook()
    {
        RotatePlayer();
        RotateCamera();
    }

    private void RotatePlayer()
    {
        float mouseX = Input.GetAxisRaw("Mouse X");
        transform.Rotate(Vector3.up * mouseX * mouseSensitivity);
    }

    private void RotateCamera()
    {
        float mouseY = Input.GetAxisRaw("Mouse Y");
        verticalLookRotation -= mouseY * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);
        cameraHolder.localEulerAngles = new Vector3(verticalLookRotation, 0f, 0f);
    }

    private void LockCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
