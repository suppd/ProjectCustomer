using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering.Universal;

public class BlinkScript : MonoBehaviour
{

    public GameObject topLid;
    public GameObject botLid;
    public ConcentrationBar concentrationBar;
    public UnityEngine.Rendering.VolumeProfile volumeprofile;
    UnityEngine.Rendering.Universal.Vignette vignette;
    public float smoothness;
    public float intensity;
    

    float timer = 0f;
    bool canBlink = false;

    private void Update()
    {
        Debug.Log(timer);
        if (canBlink)
        {
            Debug.Log(canBlink);
        }
      
        
        if (canBlink == false)
        {
            timer += Time.deltaTime;
        }
        if (timer >= 6)
        {
            canBlink = true;
            

        }
        if (concentrationBar.healthAmount >= 10 && canBlink)
        {
            Blink();

        }
        if (concentrationBar.healthAmount <= 10)
        {
            volumeprofile.TryGet(out vignette);
            vignette.intensity.Override(1);
            vignette.smoothness.Override(1);
        }
        
        //if (concentrationBar.healthAmount <= 10 && canBlink)
        //{
        //    blink();
            
        //}

    }



    void Blink()
    {

        topLid.GetComponent<Animator>().Play("BlinkTopEye");
        botLid.GetComponent<Animator>().Play("BlinkBottomEye");
        canBlink = false;
        timer = 0f;
      
    }
}
