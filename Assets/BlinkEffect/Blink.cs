using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Blink : MonoBehaviour
{

    public GameObject topLid;
    public GameObject botLid;
    public ConcentrationBar concentrationBar;

    float timer = 0f;
    bool canBlink;

    private void Update()
    {
        Debug.Log(timer);
        Debug.Log(canBlink);
        
        if (canBlink == false)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 6)
        {
            canBlink = true;
            

        }
        if (concentrationBar.healthAmount >= 10 && timer >=6)
        {
            blink();
        }
        //if (concentrationBar.healthAmount <= 10 && canBlink)
        //{
        //    blink();
            
        //}

    }

    void blink()
    {

        topLid.GetComponent<Animator>().Play("BlinkTopEye");
        botLid.GetComponent<Animator>().Play("BlinkBottomEye");
        canBlink = false;
      
    }
}
