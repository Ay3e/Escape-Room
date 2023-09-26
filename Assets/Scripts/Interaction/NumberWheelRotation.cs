using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NumberWheelRotation : MonoBehaviour
{
    [SerializeField] private GameObject numberWheel;

    public static int numberOnWheel;

    private float _rotationIncrement = 37.0f;

    private void Start()
    {
        numberOnWheel = 0;
    }
    public void OnButtonPress()
    {
        Vector3 currentRotation = numberWheel.transform.rotation.eulerAngles;
        numberOnWheel++;
        if (numberOnWheel > 9)
        {
            numberOnWheel = 0;
            currentRotation.z = -10.0f;
        }

        // Increment the z rotation by rotationIncrement
        currentRotation.z += _rotationIncrement;


        // Apply the new rotation to the numberWheel
        numberWheel.transform.rotation = Quaternion.Euler(currentRotation);
    }
}
