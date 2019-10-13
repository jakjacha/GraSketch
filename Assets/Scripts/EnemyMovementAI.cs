using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    private EnemyMovementAI enemy;
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        float x_diff = player.transform.position.x - transform.position.x;
        float z_diff = player.transform.position.z - transform.position.z;
        Vector3 v = new Vector3(x_diff,0,z_diff);
        v = v.normalized;
        if (x_diff > 0)
        {
            transform.position = transform.position - v;
        }
        else
        {
            transform.position = transform.position + v;
        }
    }
}
