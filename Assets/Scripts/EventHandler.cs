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

    public bool nowIsEvent = false;
    public Image qte_Img;
    public Image qte_BgImg;
    public QTE_Event qte_Event;
    public ConcentrationBar concentrationBar;
    public CarTransition carScript;

    void Start()
    {
        qte_Img.enabled = false;
        qte_Event.enabled = false;
        qte_BgImg.enabled = false;
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
        
        if (nowIsEvent == false && qte_Img.enabled == false && qte_Event.enabled == false && carScript.playerIn && qte_Event.fillAmount <= 0.1f)
        {
            StartCoroutine(WaitForEvent());

        } 
        //if (nowIsEvent == true && carScript.playerIn)
        //{
        //    QuickEvent();
        //}


    }
    void QuickEvent()
    {
        qte_Img.enabled = true;
        qte_Event.enabled = true;
        qte_BgImg.enabled = true;
        nowIsEvent = false;
    }

    IEnumerator WaitForEvent()
    {
        if (nowIsEvent == false && carScript.playerIn)
        {
            yield return new WaitForSeconds(5);
            nowIsEvent = true;
            QuickEvent();
            //qte_Img.enabled = false;
            //qte_Event.enabled = false;
            //qte_BgImg.enabled = false;

        }

    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(10);
        canChange = true;
        yield return null;
    }
}
