using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventHandler : MonoBehaviour
{
    float concentrationBarAmount;

    //public variables
    public bool nowIsEvent = false;
    public Image qte_SpaceBar;
    public Image qte_Z;
    public Image qte_F;
    public Image qte_R;
    public Image qte_Ring;
    public Image qte_Win;
    public Image qte_Fail;
    public Image qte_FailSlider;
    public QTE_Event qte_Event;
    public ConcentrationBar concentrationBar;
    public CarTransition carScript;
    public PathCreation.Examples.PathFollower pathFollower;
    public Text failText;
    public float showTimer = 0f;

    void Start()
    {
        qte_SpaceBar.enabled = false;
        qte_Event.enabled = false;
        qte_Ring.enabled = false;
        qte_Win.enabled = false;
        qte_Fail.enabled = false;
        qte_FailSlider.enabled = false;
        
    }

    void Update()
    {
        concentrationBarAmount = concentrationBar.healthAmount;

        if (nowIsEvent == false && qte_SpaceBar.enabled == false && qte_Event.enabled == false && qte_Ring.enabled == false && carScript.playerIn && qte_Event.fillAmount <= 0.00f)
        {
            StartCoroutine(WaitForEvent());

        }

        if (qte_Ring.enabled == true && qte_SpaceBar.enabled == true && qte_Event.enabled == true)
        {
            nowIsEvent = true;
        }
        showTimer += Time.deltaTime;

        CheckEventStates();
        HandleLoss();


        //Debug.Log(nowIsEvent);

        //Debug.Log(qte_Event.eventSucces);
    }
    void QuickEvent()
    {
        qte_SpaceBar.enabled = false;
        qte_R.enabled = false;
        qte_F.enabled = false;
        qte_Z.enabled = false;
        qte_Ring.enabled = false;
        qte_FailSlider.enabled = false;

        if (qte_Event.fillAmount == 0)
        {
            
            qte_Event.enabled = true;
            qte_Ring.enabled = true;
            qte_FailSlider.enabled = true;
            qte_FailSlider.fillAmount = 1f;
            if (qte_Event.qteKey == 1)
            {
                qte_SpaceBar.enabled = true;
            }
            if (qte_Event.qteKey == 2)
            {
                qte_R.enabled = true;
            }
            if (qte_Event.qteKey == 3)
            {
                qte_F.enabled = true;
            }
            if (qte_Event.qteKey == 4)
            {
                qte_Z.enabled = true;
            }
        }
    }

    void CheckEventStates()
    {
        if (qte_Event.eventSucces == "y")
        {
            nowIsEvent = false;
            qte_SpaceBar.enabled = false;
            qte_F.enabled = false;
            qte_R.enabled = false;
            qte_Z.enabled = false;
            qte_Event.enabled = false;
            qte_Ring.enabled = false;
            qte_Win.enabled = true;
            qte_Fail.enabled = false;
            qte_FailSlider.enabled = false;
            showTimer = 0f;
            qte_Event.keypicked = false;

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
            qte_SpaceBar.enabled = false;
            qte_Event.enabled = false;
            qte_Ring.enabled = false;
            qte_Win.enabled = false;
            qte_FailSlider.enabled = false;
            showTimer = 0f;
            qte_Event.keypicked = false;

            if (showTimer >= 1f)
            {
                qte_Fail.enabled = false;
                qte_Win.enabled = false;
                qte_FailSlider.enabled = false;
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

        //Debug.Log(qte_Event.eventSucces);
    }

    void HandleLoss()
    {
        if (concentrationBar.healthAmount <= 0)
        {
            failText.enabled = true;
            pathFollower.speed = 0;
            DisableAllButtons();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void DisableAllButtons()
    {
        qte_Ring.enabled = false;
        qte_Event.enabled = false;
        qte_Fail.enabled = false;
        qte_SpaceBar.enabled = false;
        qte_Win.enabled = false;
        qte_FailSlider.enabled = false;
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
