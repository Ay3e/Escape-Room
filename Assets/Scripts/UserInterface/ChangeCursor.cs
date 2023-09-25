using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Camera playerCamera;
    public float raycastDistance = 2f;
    public LayerMask interactableLayer; // Assign the interactable layer in the Inspector
    public LayerMask inspectLayer;

    public static bool isInspectableCursorOn = false;

    [SerializeField] private GameObject normalCursor;
    [SerializeField] private GameObject hoverInteractableLayerCursor;
    [SerializeField] private GameObject hoverInspectLayerCursor;

    private void Start()
    {
        // Initialize the cursor states
        SetCursorState(false, false, false);
    }

    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        bool interactableHit = Physics.Raycast(ray, out hit, raycastDistance, interactableLayer);
        bool inspectableHit = Physics.Raycast(ray, out hit, raycastDistance, inspectLayer);

        // Determine which cursor should be active based on the raycast results
        if (interactableHit)
        {
            SetCursorState(true, false, false); // Interactable cursor
            isInspectableCursorOn = false;
        }
        else if (inspectableHit)
        {
            SetCursorState(false, true, false); // Inspectable cursor
            isInspectableCursorOn = true;
        }
        else
        {
            SetCursorState(false, false, true); // Normal cursor
            isInspectableCursorOn = false;
        }
    }

    // Helper method to set cursor states
    private void SetCursorState(bool interactableActive, bool inspectableActive, bool normalActive)
    {
        normalCursor.SetActive(normalActive);
        hoverInteractableLayerCursor.SetActive(interactableActive);
        hoverInspectLayerCursor.SetActive(inspectableActive);
    }
}