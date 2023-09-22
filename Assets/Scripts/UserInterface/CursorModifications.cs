using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorModifications : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;

    private void FixedUpdate()
    {
        //Cursor.SetCursor(cursorTexture, cursorHotspot, CursorMode.Auto);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
}
