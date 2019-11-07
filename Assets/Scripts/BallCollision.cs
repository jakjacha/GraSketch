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
            
        }

//        if (col.gameObject.CompareTag("Wall"))
//        {
//            Destroy(gameObject);
//        }
        Debug.Log("Ball hit: " + col.gameObject.name);
        
    }

    private void BallHitEnemy(GameObject enemy)
    {
        EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent("EnemyHealth");
        enemyHealth.UpdateCurrentHealth(damageValue);
    }
}