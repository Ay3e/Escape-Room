using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    //reference to gunscript ()gunscript function

    [SerializeField] Rigidbody rb;
    [SerializeField] BoxCollider boxCollider;
    [SerializeField] Transform player, gunController, fpsCam;

    [SerializeField] float pickUpRange;
    //Might need to remove this below
    [SerializeField] float dropForwardForce, dropUpwardForce;

    private bool equipped;
    public static bool slotFull;

    private void Update()
    {
        //Check if player is in range nand 'E' is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped and 'Q' is pressed
        if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make Rigidbody kinematic and Box Collider a trigger
        rb.isKinematic = true;
        boxCollider.isTrigger = true;

        //enable Script
        //gunScript.enabled = true;
    }

    private void Drop()
    {
        equipped = false;
        slotFull = false;

        //Make Rigidbody not kinematic and Box Collider normal
        rb.isKinematic = false;
        boxCollider.isTrigger = false;
        
        //diable Script
        //gunScript.enabled = false;
    }
}
