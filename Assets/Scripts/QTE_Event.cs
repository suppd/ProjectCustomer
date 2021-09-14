using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Event : MonoBehaviour
{
    public bool isFailTimer;
    public bool keypicked;
    public float fillAmount = 0f;
    public float failFillAmount = 0f;
    public float timeThreshold = 0f;
    public float anotherTimeThreshold = 0f;
    public float failTimer = 0f;
    public string eventSucces = "";
    // w = wait, n = no, y = yes
    public int qteKey;
    //key 1 = spc ,2 = r, 3 = f, 4 = z
    public int correctKey;
    //correct = 1 not correct = 2
    public EventHandler eventHandler;
    public Image RingBackground;
    public Image FailTimerImg;
    public ConcentrationBar concentrationBar;
    Image Ring;

    void Start()
    {
        Ring = GetComponent<Image>();
        failFillAmount = 1f;
    }
    void Update()
    {
        SuccesRing();
        FailTimer();
        if (keypicked == false)
        {
            PickKey();
        }
    }

    void PickKey()
    {
        qteKey = Random.Range(1, 2);
        keypicked = true;
    }
    void SuccesRing()
    {
        if (isFailTimer == false)
        {
            
            //Debug.Log(qteKey);
            if (qteKey == 1)
            {
                
                if (Input.GetKeyDown(KeyCode.Space) && this != null)
                {
                    fillAmount += 0.08f;
                }
            }
            if (qteKey == 2)
            {
                
                if (Input.GetKeyDown(KeyCode.R) && this != null)
                {
                    fillAmount += 0.08f;
                }  
            }
            if (qteKey == 3)
            {
                
                if (Input.GetKeyDown(KeyCode.F) && this != null)
                {
                    fillAmount += 0.08f;
                }
            }
            if (qteKey == 4)
            {
                
                if (Input.GetKeyDown(KeyCode.Z) && this != null)
                {
                    fillAmount += 0.08f;
                }
            }



            timeThreshold += Time.deltaTime;

            if (timeThreshold > 0.2f && this != null)
            {
                timeThreshold = 0f;
                fillAmount -= 0.03f;
            }

            if (fillAmount < 0 && this != null)
            {
                fillAmount = 0f;
            }

            if (fillAmount >= 1.0f)
            {
                eventSucces = "y";
                Debug.Log(eventSucces);
                StartCoroutine(ResetSucces());
            }

            Ring.fillAmount = fillAmount;
        }
    }
    
    void FailTimer()
    {
     
            if (eventHandler.nowIsEvent)
            {
                FailTimerImg.fillAmount = failFillAmount;

                failTimer += Time.deltaTime;
                anotherTimeThreshold += Time.deltaTime;
                //Debug.Log(failTimer);
                if (anotherTimeThreshold >= 0.99f)
                {
                    failFillAmount -= 0.20f;
                    anotherTimeThreshold = 0f;

                }
                if (failFillAmount <= 0)
                {
                    //failFillAmount = 1;
                }

                if (failTimer >= 5f)
                {
                    failTimer = 0f;
                    eventSucces = "n";
                    concentrationBar.healthAmount -= 5;
                    StartCoroutine(ResetFail());

                }
            
        }
        
    }
    IEnumerator ResetSucces()
    {
        yield return  new WaitForSeconds(3f);
        eventSucces = "";
        fillAmount = 0;
    }

    IEnumerator ResetFail()
    {
        yield return new WaitForSeconds(3f);
        eventSucces = "";
        fillAmount = 0;
    }

}
