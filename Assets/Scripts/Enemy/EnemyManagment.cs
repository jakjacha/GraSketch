using System.Collections;
using UnityEngine;

public class EnemyManagment : MonoBehaviour
{
    private int _cnt;
    //public GameObject Srodek;
    public GameObject enemy;
    public int enemyCount;

    public int enemySpawnPosX;

    public int enemySpawnPosZ;

    // Start is called before the first frame update
    private void Start()
    {
        _cnt = 0;
        StartCoroutine(EnemySpawn());
        GameWatcher.CurrentEnemiesCount += enemyCount;
        //if(GameWatcher.CurrentEnemiesCount <=0)Destroy(gameObject);
    }

    private IEnumerator EnemySpawn()
    {
        Vector3 pos = transform.position + new Vector3(0,0,45);
        while (_cnt < enemyCount)
        {
            enemySpawnPosX = (int) Random.Range(pos.x-35, pos.x+35);
            enemySpawnPosZ = (int) Random.Range(pos.z-30, pos.z+30);
            Instantiate(enemy, new Vector3(enemySpawnPosX, 2, enemySpawnPosZ), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            _cnt++;
        }
    }
}