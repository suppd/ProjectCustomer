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
    public Image qte_Win;
    public Image qte_Fail;
    public QTE_Event qte_Event;
    public ConcentrationBar concentrationBar;
    public CarTransition carScript;
    public PathCreation.Examples.PathFollower pathFollower;
    public Text failText;
    public float showTimer = 0f;

    void Start()
    {
        qte_Img.enabled = false;
        qte_Event.enabled = false;
        qte_BgImg.enabled = false;
        qte_Win.enabled = false;
        qte_Fail.enabled = false;
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
        showTimer += Time.deltaTime;

        CheckEventStates();
        HandleLoss();


        //Debug.Log(nowIsEvent);

        Debug.Log(qte_Event.eventSucces);
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

    void CheckEventStates()
    {
        if (qte_Event.eventSucces == "y")
        {
            nowIsEvent = false;
            qte_Img.enabled = false;
            qte_Event.enabled = false;
            qte_BgImg.enabled = false;
            qte_Win.enabled = true;
            qte_Fail.enabled = false;
            showTimer = 0f;

            if (showTimer >= 1f)
            {
                qte_Fail.enabled = false;
                qte_Win.enabled = false;
                showTimer = 0f;
                qte_Event.eventSucces = "";
            }
        }
        if (qte_Event.eventSucces == "n")
        {
            nowIsEvent = false;
            qte_Fail.enabled = true;
            qte_Img.enabled = false;
            qte_Event.enabled = false;
            qte_BgImg.enabled = false;
            qte_Win.enabled = false;
            showTimer = 0f;

            if (showTimer >= 1f)
            {
                qte_Fail.enabled = false;
                qte_Win.enabled = false;
                showTimer = 0f;
                qte_Event.eventSucces = "";
            }
        }
        if (qte_Event.eventSucces == "")
        {

            qte_Fail.enabled = false;
            qte_Win.enabled = false;
            showTimer = 0;
        }

        //Debug.Log(nowIsEvent);

        Debug.Log(qte_Event.eventSucces);
    }


    void HandleLoss()
    {
        if (concentrationBar.healthAmount <= 0)
        {
            failText.enabled = true;
            pathFollower.speed = 0;
            DisableAllButtons();
        }
    }

    void DisableAllButtons()
    {
        qte_BgImg.enabled = false;
        qte_Event.enabled = false;
        qte_Fail.enabled = false;
        qte_Img.enabled = false;
        qte_Win.enabled = false;
    }

    IEnumerator WaitForEvent()
    {
        if (nowIsEvent != true)
        {
            // Debug.Log("starting to wait");
            yield return new WaitForSeconds(6);
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
