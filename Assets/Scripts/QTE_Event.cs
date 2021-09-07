using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Event : MonoBehaviour
{
    public float fillAmount = 0f;
    public float timeThreshold = 0f;
    public string eventSucces = "n";
   

    public Image RingBackground;
    Image Ring;
    
    void Start()
    {
        Ring = GetComponent<Image>();
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && this != null)
        {
            fillAmount += 0.2f;
        }

        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.2f && this != null)
        {
            timeThreshold = 0f;
            fillAmount -= 0.06f;
        }

        if (fillAmount < 0 && this != null)
        {
            fillAmount = 0f;
        }

        if (fillAmount >= 1 && this != null && Ring != null && RingBackground.sprite != null)
        {
            Ring.enabled = false;
            RingBackground.enabled = false;
            //this.enabled = false;
            //Destroy(Ring);
            //Destroy(RingBackground);
            //Destroy(this);
            eventSucces = "y";
            Debug.Log(eventSucces);
            fillAmount = 0;
            this.enabled = false;
        }

        Ring.fillAmount = fillAmount;
    }

    public void Reset()
    {
        
    }
}
