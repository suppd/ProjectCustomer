using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventHandler : MonoBehaviour
{
    float concentrationBarAmount;

    //public variables
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

        if (nowIsEvent == false && qte_Img.enabled == false && qte_Event.enabled == false && qte_BgImg.enabled == false && carScript.playerIn && qte_Event.fillAmount <= 0.00f)
        {
            StartCoroutine(WaitForEvent());

        }

        if (qte_BgImg.enabled == true && qte_Img.enabled == true && qte_Event.enabled == true)
        {
            nowIsEvent = true;
        }
        if (qte_Event.eventSucces == "y" || qte_Event.fillAmount >= 1)
        {
            nowIsEvent = false;
            qte_Img.enabled = false;
            qte_Event.enabled = false;
            qte_BgImg.enabled = false;
        }

        Debug.Log(nowIsEvent);

    }
    void QuickEvent()
    {
        if (qte_Event.fillAmount == 0)
        {
            qte_Img.enabled = true;
            qte_Event.enabled = true;
            qte_BgImg.enabled = true;
        }
    }

    IEnumerator WaitForEvent()
    {
        if (nowIsEvent != true)
        {
           // Debug.Log("starting to wait");
            yield return new WaitForSeconds(5);
           // Debug.Log("waited for 5 seconds");
            QuickEvent();
            CooldownEvent();
        }
    }

    IEnumerator CooldownEvent()
    {
        yield return new WaitForSeconds(2);
    }
}
