using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject enemy;

    public int damageValue=10;

    public float attackRange=10;

    public float attackAngle=10;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 range1 = new Vector3(transform.position.x+attackRange,transform.position.y, transform.position.z+attackAngle);
        Vector3 range2 = new Vector3(transform.position.x+attackRange,transform.position.y, transform.position.z-attackAngle);
        Debug.DrawLine(transform.position,range1,Color.yellow);
        Debug.DrawLine(transform.position,range2,Color.yellow);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Attack();
        }
    }

    private void Attack()
    {
        EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent("EnemyHealth");
        enemyHealth.UpdateCurrentHealth(damageValue*(-1));
    }

    private void FindEnemy()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    //    foreach(GameObject)
    }
}
