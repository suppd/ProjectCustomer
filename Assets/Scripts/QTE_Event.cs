using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTE_Event : MonoBehaviour
{
    public float fillAmount = 0f;
    public float timeThreshold = 0f;

    Image Ring;
    Image RingBackground;
    void Start()
    {
        Ring = GetComponent<Image>();
        RingBackground = GetComponentInParent<Image>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fillAmount += 0.2f;
        }

        timeThreshold += Time.deltaTime;

        if (timeThreshold > 0.2f)
        {
            timeThreshold = 0f;
            fillAmount -= 0.06f;
        }

        if (fillAmount < 0)
        {
            fillAmount = 0f;
        }

        if (fillAmount > 1 && this != null)
        {

            DestroyImmediate(Ring);
            DestroyImmediate(RingBackground.sprite);
            DestroyImmediate(this);
            //play "Sucess" animation
        }

        Ring.fillAmount = fillAmount;
    }
}
