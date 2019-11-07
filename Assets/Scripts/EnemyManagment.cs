using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManagment : MonoBehaviour
{
    public int enemyCount;

    public int enemySpawnPosX;

    public int enemySpawnPosZ;

    public GameObject enemy;
    private int _cnt;

    // Start is called before the first frame update
    void Start()
    {
        _cnt = 0;
        StartCoroutine(EnemySpawn());
    }

    IEnumerator EnemySpawn()
    {
        while (_cnt < enemyCount)
        {
            enemySpawnPosX = Random.Range(-45, 45);
            enemySpawnPosZ = Random.Range(30, 120);
            Instantiate(enemy, new Vector3(enemySpawnPosX, 2, enemySpawnPosZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            _cnt ++;
        }
    }
}