using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public float startingHealth = 100;

    public Slider slider;
    
    private void Start()
    {
        currentHealth = startingHealth;
        slider.maxValue = startingHealth;
    }

    
    void Update()
    {
        // ReSharper disable once PossibleLossOfFraction
        UpdateCurrentHealth(0);
        slider.value = currentHealth / startingHealth * 100;
    }
    


    public void  UpdateCurrentHealth(float change)
    {
        currentHealth -= change;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }

        if (currentHealth > startingHealth)
            currentHealth = startingHealth;
    }


}