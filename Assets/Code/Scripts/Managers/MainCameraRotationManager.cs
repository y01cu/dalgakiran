using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraRotationManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;

    private void Update()
    {
        RotateCameraBasedOnInput();
    }

    // TODO: Add remaining inputs.

    private void RotateCameraBasedOnInput()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateCameraLeft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            RotateCameraRight();
        }
    }

    private void RotateCameraLeft()
    {
        float rotationSpeed = 70f;
        mainCamera.transform.Rotate(0, -rotationSpeed * Time.deltaTime, 0);
    }

    private void RotateCameraRight()
    {
        float rotationSpeed = 70f;
        mainCamera.transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }

}
