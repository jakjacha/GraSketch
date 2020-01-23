using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [FormerlySerializedAs("_currentHealth")] public float currentHealth;
    private float _killPoints;
    public Slider slider;
    private float _startingHealth = 20;
    private float _maxHealth;
    private void Start()
    {
        _maxHealth = _startingHealth*GameWatcher.EnemiesLevel;
        currentHealth = _maxHealth;
        slider.maxValue = currentHealth;
        _killPoints = 25*GameWatcher.EnemiesLevel;
    }


    private void Update()
    {
        // ReSharper disable once PossibleLossOfFraction
        //UpdateCurrentHealth(0);
        slider.value = currentHealth / _maxHealth * 100;
    }


    public void UpdateCurrentHealth(float change)
    {
        currentHealth -= change;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            GameWatcher.CurrentPoints += _killPoints;
            GameWatcher.CurrentEnemiesKilled++;
            Destroy(gameObject);
            GameWatcher.CurrentEnemiesCount--;
        }
    }
}