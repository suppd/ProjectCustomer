using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConcentrationBar : MonoBehaviour
{
    public float healthAmount = 100f;
    public CarTransition carScript;
    private float maxHealth = 100f;
    private float decreaseAmount = 1f;

    private Image healthBar;
    void Start()
    {
        healthBar = GetComponent<Image>();
    }
    private void Update()
    {
        if (carScript.playerIn == true)
        {
            healthAmount -= decreaseAmount * Time.deltaTime;
            healthBar.fillAmount = healthAmount / maxHealth;
        }
    }
}
