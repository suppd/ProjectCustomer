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

    public bool nowIsEvent;
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
        Debug.Log(nowIsEvent);
        //if (concentrationBarAmount <= 90 && canChange == true && carScript.playerIn == true)
        //{
            
        //    canChange = false;
        //    eventPlayed = true;

          
        //}
        //if (qte_Event.eventSucces.Contains("y") || qte_Event.eventSucces.Contains("n"))
        //{
        //    eventPlayed = true;
        //    RepeatQTE();
        //}
        
        if (nowIsEvent == false && qte_Img.enabled == false && qte_Event.enabled == false)
        {
            StartCoroutine(WaitForEvent());
        } 
        if (nowIsEvent == true && qte_Img.enabled == false && qte_Event.enabled == false)
        {
            QuickEvent();
        }

    }

    void RepeatQTE()
    {
        if (canChange == false && eventPlayed == true)
        {
            StartCoroutine(Change());
            eventPlayed = false;
        }
    }

    void QuickEvent()
    {
        qte_Img.enabled = true;
        qte_Event.enabled = true;
        nowIsEvent = false;
        //StartCoroutine(WaitForEvent());
    }

    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(5f);
        nowIsEvent = true;
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(10);
        canChange = true;
        yield return null;
    }
}
