using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpGun : MonoBehaviour
{
    [SerializeField] private GameObject gunInHand;
    [SerializeField] private GameObject gun;

    public static bool _isGunPickedUp;
    private bool _isIntriggerArea = false;
    void Start()
    {
        gunInHand.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_isIntriggerArea && ChangeCursor.isInteractableCursorOn && Input.GetKeyDown(KeyCode.Mouse0))
        {
            _isGunPickedUp = true;
            gunInHand.SetActive(true); 
            gun.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isIntriggerArea = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _isIntriggerArea = false;
    }
}
