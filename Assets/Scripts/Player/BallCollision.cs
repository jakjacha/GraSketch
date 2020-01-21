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
            //Debug.Log("Ball hit: " + col.gameObject.name);
        }

        if (col.gameObject.CompareTag("Wall")) Destroy(gameObject);

        if (col.gameObject.CompareTag("Ball")) Destroy(gameObject);
    }

    private void BallHitEnemy(GameObject enemy)
    {
        var enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.UpdateCurrentHealth(damageValue);
    }
}