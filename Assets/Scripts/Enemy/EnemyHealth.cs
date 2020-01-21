using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currentHealth = 100;
    public float killPoints = 100;
    public Slider slider;
    public float startingHealth = 100;

    private void Start()
    {
        currentHealth = startingHealth;
        slider.maxValue = startingHealth;
    }


    private void Update()
    {
        // ReSharper disable once PossibleLossOfFraction
        //UpdateCurrentHealth(0);
        slider.value = currentHealth / startingHealth * 100;
    }


    public void UpdateCurrentHealth(float change)
    {
        currentHealth -= change;
        if (currentHealth > startingHealth)
            currentHealth = startingHealth;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameWatcher.CurrentPoints += killPoints;
            GameWatcher.CurrentEnemiesKilled++;
            Destroy(gameObject);
            GameWatcher.CurrentEnemiesCount--;
        }
    }
}