using System;
using UnityEngine;

public class GameWatcher : MonoBehaviour
{
    public static float CurrentPoints { get; set; }
    public static float CurrentHealth { get; set; }
    public static float CurrentEnemiesCount { get; set; }
    public static bool NextLevelFlag { get; set; }
    public static bool NewEnemiesKilled { get; set; }
    public static float CurrentEnemiesKilled { get; set; }

    private void Start()
    {
        NextLevelFlag = false;
        CurrentPoints = 0;
        CurrentEnemiesCount = 0;
        CurrentEnemiesKilled = 0;
        CurrentHealth = PlayerHealthBar.startingHealth;
    }

    private void Update()
    {
        if (CurrentEnemiesKilled > 0 && CurrentEnemiesCount <= 0 && !NewEnemiesKilled)
        {
            NextLevelFlag = true;
            NewEnemiesKilled = true;
        }
    }

    public void NowaGra()
    {
        //Debug.Log("klik");
        Application.LoadLevel(0);
    }
}