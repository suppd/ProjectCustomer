using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Event : MonoBehaviour
{
    public float fillAmount = 0f;
    public float timeThreshold = 0f;
    public float failTimer = 0f;
    public string eventSucces = "";
    // w = wait, n = no, y = yes
    public EventHandler eventHandler;
    public Image RingBackground;
    public ConcentrationBar concentrationBar;
    Image Ring;
    
    void Start()
    {
        Ring = GetComponent<Image>();
        
    }
    void  Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this != null)
        {
            fillAmount += 0.08f;
        }

        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.2f && this != null)
        {
            timeThreshold = 0f;
            fillAmount -= 0.02f;
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

        if (eventHandler.nowIsEvent)
        {
            failTimer += Time.deltaTime;
            if (failTimer >= 5f)
            {
                failTimer = 0f;
                eventSucces = "n";
                concentrationBar.healthAmount -= 10;
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
