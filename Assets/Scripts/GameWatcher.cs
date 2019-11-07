using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWatcher : MonoBehaviour
{
    public int enemiesCount;
    public GameObject enemySpawn;
    void Update()
    {
        enemiesCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if(enemiesCount<=0)enemySpawn.SetActive(false);
    }
}
