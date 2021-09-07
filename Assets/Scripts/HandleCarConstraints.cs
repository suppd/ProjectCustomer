using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class HandleCarConstraints : MonoBehaviour
{
    public PositionConstraint positionCon;
    public CarTransition carScript;

    void Start()
    {
        positionCon = GetComponentInParent<PositionConstraint>();
    }

    void Update()
    {
        if (carScript.playerIn == true)
        {
            positionCon.constraintActive = false;
        }
    }
}
