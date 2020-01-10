using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBallCollision : MonoBehaviour
{
    public float damageValue = 50;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            BallHitEnemy(col.gameObject);
        }

        if (col.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }
        
        if(col.gameObject.CompareTag("Ball"))
        {
            Destroy(gameObject);
        }
    }

    private void BallHitEnemy(GameObject player)
    {
        PlayerHealthBar playerHealth = player.GetComponent<PlayerHealthBar>();
        playerHealth.UpdateCurrentHealth(change: damageValue);
    }
}
