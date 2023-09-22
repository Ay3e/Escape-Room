using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouching : MonoBehaviour
{
    [SerializeField] CapsuleCollider playerHeight;
    [SerializeField] Transform playerTransform;
    [SerializeField] float normalHeight, crouchHeight;
    [SerializeField] float crouchYPosition; // Adjust this value to set the Y position when crouching.
    private float normalYPosition;

    private bool isCrouching = false;

    private void Start()
    {
        // Store the initial Y position.
        normalYPosition = playerTransform.position.y;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (!isCrouching)
            {
                // Instantly drop the collider to crouch height.
                playerHeight.height = crouchHeight;

                // Adjust the player's Y position when crouching.
                Vector3 newPosition = playerTransform.position;
                newPosition.y = crouchYPosition;
                playerTransform.position = newPosition;

                isCrouching = true;
            }
            else
            {
                // Uncrouch the collider to normal height.
                playerHeight.height = normalHeight;

                // Restore the player's Y position to normal.
                Vector3 newPosition = playerTransform.position;
                newPosition.y = normalYPosition;
                playerTransform.position = newPosition;

                isCrouching = false;
            }
        }
    }
}
