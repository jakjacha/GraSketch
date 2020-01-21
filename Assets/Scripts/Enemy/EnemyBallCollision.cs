using UnityEngine;

public class EnemyBallCollision : MonoBehaviour
{
    public float damageValue = 10;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            GameWatcher.CurrentHealth -= EnemyFireAttack.DamageValue;
        }

        if (col.gameObject.CompareTag("Wall")) Destroy(gameObject);

        if (col.gameObject.CompareTag("Ball")) Destroy(gameObject);
    }
}