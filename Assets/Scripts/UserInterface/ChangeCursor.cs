using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCursor : MonoBehaviour
{
    public Camera playerCamera;
    public float raycastDistance = 2f;
    public LayerMask interactableLayer; // Assign the interactable layer in the Inspector

    [SerializeField] private GameObject normalCursor;
    [SerializeField] private GameObject hoverCursor;

    private void Start()
    {
        normalCursor.SetActive(true);
        hoverCursor.SetActive(false);
    }
    void Update()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, raycastDistance, interactableLayer))
        {
            // Check if the object hit by the raycast is on the interactable layer
            //instead of destroy change the cursor
            //Destroy(hit.collider.gameObject);
            normalCursor.SetActive(false);
            hoverCursor.SetActive(true);

        }
        else
        {
            normalCursor.SetActive(true);
            hoverCursor.SetActive(false);
        }
    }
}
