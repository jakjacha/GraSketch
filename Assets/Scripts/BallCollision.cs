using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    public float damageValue = 50;
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            BallHitEnemy(col.gameObject);
            Debug.Log("Ball hit: " + col.gameObject.name);
        }

//        if (col.gameObject.CompareTag("Wall"))
//        {
//            Destroy(gameObject);
//        }
    }

    private void BallHitEnemy(GameObject enemy)
    { 
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
       enemyHealth.UpdateCurrentHealth(change: damageValue);
    }
}