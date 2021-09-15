using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManageFade : MonoBehaviour
{
    public Image blackImg;

    float timer = 0f;
    void Start()
    {
        
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            blackImg.enabled = false;
        }   
    }
}
