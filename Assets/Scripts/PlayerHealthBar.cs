using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth = 100;
    private int _healthBarSize;
    public int healthBarHeight = 20;
    void Update()
    {
        _healthBarSize = Screen.width / 2 / (startingHealth / currentHealth);
        UpdateCurrentHealth(0);
    }
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/4, Screen.height-healthBarHeight, _healthBarSize, healthBarHeight),"test");
    }

    public void UpdateCurrentHealth(int change)
    {
        currentHealth += change;
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > startingHealth)
            currentHealth = startingHealth;
    }
}
