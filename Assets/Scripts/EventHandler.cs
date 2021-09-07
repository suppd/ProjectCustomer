using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    float concentrationBarAmount;
    Camera playerCam;
    bool canChange = true;
    bool eventPlayed = false;

    public Image qte_Img;
    public QTE_Event qte_Event;
    public ConcentrationBar concentrationBar;
    public CarTransition carScript;

    void Start()
    {
        qte_Img.enabled = false;
        qte_Event.enabled = false;
    }

    void Update()
    {
        concentrationBarAmount = concentrationBar.healthAmount;
        Debug.Log(concentrationBarAmount);
        if (concentrationBarAmount <= 90 && canChange == true && carScript.playerIn == true)
        {
            qte_Img.enabled = true;
            qte_Event.enabled = true;
            canChange = false;
            eventPlayed = true;

          
        }
        RepeatQTE();

    }

    void RepeatQTE()
    {
        if (canChange == false && eventPlayed == true)
        {
            StartCoroutine(Change());
        }
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(10);
        canChange = true;
        eventPlayed = false;
    }
}
