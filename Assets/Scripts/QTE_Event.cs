using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Event : MonoBehaviour
{
    public float fillAmount = 0f;
    public float timeThreshold = 0f;
    public string eventSucces = "n";
    // w = wait, n = no, y = yes
   

    public Image RingBackground;
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
    }

    IEnumerator ResetSucces()
    {
        yield return  new WaitForSeconds(3f);
        eventSucces = "w";
        fillAmount = 0;
    }
}
