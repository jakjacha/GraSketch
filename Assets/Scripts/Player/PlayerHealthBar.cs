using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    public float startingHealth = 100;
    public float currentHealth = 100;
    private float _healthBarSize;
    private float _healthBarHeight = 20;
    void Update()
    {
        _healthBarSize = Screen.width / 2 / (startingHealth / currentHealth);
        UpdateCurrentHealth(0);
    }
    void OnGUI()
    {
        GUI.Box(new Rect(Screen.width/4, Screen.height-_healthBarHeight, _healthBarSize, _healthBarHeight), currentHealth.ToString());
    }

    public void UpdateCurrentHealth(float change)
    {
        currentHealth += change;
        if (currentHealth < 0)
            currentHealth = 0;

        if (currentHealth > startingHealth)
            currentHealth = startingHealth;
    }
}
