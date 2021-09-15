using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockState : MonoBehaviour
{
    private void Start()
    {
        
    }
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
