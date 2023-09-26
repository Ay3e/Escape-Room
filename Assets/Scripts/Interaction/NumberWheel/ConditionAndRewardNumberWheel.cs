using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConditionAndRewardNumberWheel : MonoBehaviour
{
    [SerializeField] private GameObject gun;
    [SerializeField] private Animator animateOpenCrate;

    void Start()
    {
        gun.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GreenNumberWheelRotation.greenNumberOnWheel == 4 && BlueNumberWheelRotation.blueNumberOnWheel == 1 &&WhiteNumberWheelRotation.whiteNumberOnWheel == 6 && PinkNumberWheelRotation.pinkNumberOnWheel == 4)
        {
            //Unlock and Drop Lock

            //Open crate
            animateOpenCrate.SetBool("OpenCrateLong", true);
            //Set gun active
            if (PickUpGun._isGunPickedUp == false)
            {
                gun.SetActive(true);
            }
        }
    }
}
