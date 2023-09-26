using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenNumberWheelRotation : MonoBehaviour
{
    [SerializeField] private GameObject numberWheel;

    public static int greenNumberOnWheel;

    private float _rotationIncrement = 37.0f;

    private void Start()
    {
        greenNumberOnWheel = 0;
    }
    public void OnButtonPress()
    {
        Vector3 currentRotation = numberWheel.transform.rotation.eulerAngles;
        greenNumberOnWheel++;
        if (greenNumberOnWheel > 9)
        {
            greenNumberOnWheel = 0;
            currentRotation.z = -10.0f;
        }

        // Increment the z rotation by rotationIncrement
        currentRotation.z += _rotationIncrement;


        // Apply the new rotation to the numberWheel
        numberWheel.transform.rotation = Quaternion.Euler(currentRotation);
    }
}
