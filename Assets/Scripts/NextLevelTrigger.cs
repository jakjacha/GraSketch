using System;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{
    public GameObject go;

    private void Start()
    {
        GameWatcher.EnemiesLevel++;
        go = Resources.Load("Level1") as GameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameWatcher.NextLevelFlag = false;
        if (other.CompareTag("Player"))
        {
            if (GameWatcher.CurrentEnemiesCount <= 0 && GameWatcher.CurrentEnemiesKilled > 0)
            {
                Instantiate(go,
                        transform.position + new Vector3(0, 0, 25),
                        Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}