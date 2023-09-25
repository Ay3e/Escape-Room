using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomOne : MonoBehaviour
{

    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera inspectCamera;

    private bool isInTriggerArea = false;
    private bool isInspectCameraOn =false;
    

    private void Update()
    {
        if (isInTriggerArea && ChangeCursor.isInspectableCursorOn && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TurnCameraToInspect();
            CanMoveCursorAnywhere();
            isInspectCameraOn = true;
        }
        if(isInTriggerArea && isInspectCameraOn && Input.GetKeyDown(KeyCode.Mouse1))
        {
            TurnPlayerCameraOn();
            CanNotMoveCursorAnywhere();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        isInTriggerArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isInTriggerArea = false;
    }

    private void TurnCameraToInspect()
    {
        playerCamera.enabled = false;
        inspectCamera.enabled = true;
    }

    private void TurnPlayerCameraOn()
    {
        playerCamera.enabled = true;
        inspectCamera.enabled = false;
    }

    private void CanMoveCursorAnywhere()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void CanNotMoveCursorAnywhere()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
