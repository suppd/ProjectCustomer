using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventHandler : MonoBehaviour
{
    private float concentrationBarAmount;
    Camera playerCam;

    void Start()
    {
        concentrationBarAmount = GetComponent<ConcentrationBar>().healthAmount;
    }

    void Update()
    {
        if (concentrationBarAmount <= 90)
        {

        }
    }
}
