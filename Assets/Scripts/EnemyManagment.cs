using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagment : MonoBehaviour
{
    public int enemyCount;

    public int enemySpawnPosX;

    public int enemySpawnPosZ;

    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (enemyCount < 5)
        {
            enemySpawnPosX = Random.Range(1, 50);
            enemySpawnPosZ = Random.Range(1, 50);
            Instantiate(enemy, new Vector3(enemySpawnPosX, 2, enemySpawnPosZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}