using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWheelInspect : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private Camera inspectCamera;
    [SerializeField] private GameObject numberLockCameraUI;

    private bool isInTriggerArea = false;
    private bool isInspectCameraOn = false;

    private void Start()
    {
        numberLockCameraUI.SetActive(false);
    }

    private void Update()
    {
        if (isInTriggerArea && ChangeCursor.isInspectableCursorOn && Input.GetKeyDown(KeyCode.Mouse0))
        {
            TurnCameraToInspect();
            CanMoveCursorAnywhere();
            numberLockCameraUI.SetActive(true);
            isInspectCameraOn = true;
        }
        if (isInTriggerArea && isInspectCameraOn && Input.GetKeyDown(KeyCode.Mouse1))
        {
            TurnPlayerCameraOn();
            CanNotMoveCursorAnywhere();
            numberLockCameraUI.SetActive(false);
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
