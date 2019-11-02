using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth = 100;
    private int _healthBarSize;
    //public int _healthBarHeight = 20;
    void Update()
    {
       // _healthBarSize = Screen.width / 2 / (startingHealth / currentHealth);
        UpdateCurrentHealth(0);
        new Rect(transform.position.x, 2,   10, 10);
    }

    public void UpdateCurrentHealth(int change)
    {
        currentHealth += change;
        if (currentHealth < 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
        }

        if (currentHealth > startingHealth)
            currentHealth = startingHealth;
        
        
    }
}