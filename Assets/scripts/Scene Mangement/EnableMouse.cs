using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMouse : MonoBehaviour
{
    void Update()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

 
}
