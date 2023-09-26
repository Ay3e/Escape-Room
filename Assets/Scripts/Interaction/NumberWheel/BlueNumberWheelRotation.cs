using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueNumberWheelRotation : MonoBehaviour
{
    [SerializeField] private GameObject numberWheel;

    public static int blueNumberOnWheel;

    private float _rotationIncrement = 37.0f;

    private void Start()
    {
        blueNumberOnWheel = 0;
    }
    public void OnButtonPress()
    {
        Vector3 currentRotation = numberWheel.transform.rotation.eulerAngles;
        blueNumberOnWheel++;
        if (blueNumberOnWheel > 9)
        {
            blueNumberOnWheel = 0;
            currentRotation.z = -10.0f;
        }

        // Increment the z rotation by rotationIncrement
        currentRotation.z += _rotationIncrement;


        // Apply the new rotation to the numberWheel
        numberWheel.transform.rotation = Quaternion.Euler(currentRotation);
    }
}
