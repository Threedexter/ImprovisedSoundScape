using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Camera playerCamera;

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        if (GetComponent<Camera>() == null)
        {
            GameObject.Find("Main Camera");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ControlCamera();
    }

    private void ControlCamera()
    {
        float MouseX = Input.GetAxisRaw("Mouse X");
        float MouseY = Input.GetAxisRaw("Mouse Y");

        MouseY = clampYAxis(MouseY);

        playerCamera.transform.eulerAngles += new Vector3(-MouseY, MouseX);
    }

    float clampYAxis(float mouseval)
    {
        if (playerCamera.transform.eulerAngles.x > 85 && playerCamera.transform.eulerAngles.x < 90)
        {
            playerCamera.transform.eulerAngles = new Vector3(85, playerCamera.transform.eulerAngles.y);
            mouseval = 0;
        }
        else if (playerCamera.transform.eulerAngles.x < 275 && playerCamera.transform.eulerAngles.x > 270)
        {
            playerCamera.transform.eulerAngles = new Vector3(275, playerCamera.transform.eulerAngles.y);
            mouseval = 0;
        }
        return mouseval;
    }
}
