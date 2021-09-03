using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    Camera playerCam;

    public float ConcentrationAmount = 100f;
    float PovY;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void HeadDownEvent()
    {
        PovY = playerCam.transform.rotation.y;
        if (ConcentrationAmount <= 50)
        {
            PovY = playerCam.transform.rotation.y - 20;
            
        }

    }

    Vector3 LookDown()
    {
        Vector3 rot = Vector3.zero;
        rot.y -= 20;
        return rot;
    }
}
