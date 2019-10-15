using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject enemy;

    public int damageValue=10;

    public float attackRange=10;

    public float attackAngle=10;

    private Vector3 rangeWing1;

    private Vector3 rangeWing2;

    private float attackAngleBetween = 0;
    
    private float attackAngleSize = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rangeWing1 = new Vector3(transform.position.x+attackAngle,transform.position.y, transform.position.z+attackRange);
        rangeWing2 = new Vector3(transform.position.x-attackAngle,transform.position.y, transform.position.z+attackRange);
        Debug.DrawLine(transform.position,rangeWing1,Color.green);
        Debug.DrawLine(transform.position,rangeWing2,Color.yellow);
        
        //Handles.DrawSolidArc(transform.position, ,rangeWing2);
        if (Input.GetKeyUp(KeyCode.Space))
        {
            if (enemy != null)
                Attack();
        }
        FindEnemy();
    }

    private void Attack()
    {
        EnemyHealth enemyHealth = (EnemyHealth) enemy.GetComponent("EnemyHealth");
        enemyHealth.UpdateCurrentHealth(damageValue*(-1));
    }

    private void FindEnemy()
    {
        GameObject enFind = GameObject.FindGameObjectWithTag("Enemy");
        float distance = Vector3.Distance(transform.position,enFind.transform.position);
        attackAngleBetween = Vector3.Angle(enFind.transform.position, rangeWing1) + Vector3.Angle(enFind.transform.position, rangeWing2);
        attackAngleSize = Vector3.Angle(rangeWing1, rangeWing2);
        if (distance < attackRange && attackAngleBetween>attackAngleSize)
        {
            enemy = enFind;
        }
        else
        {
            enemy = null;
        }
    }
}
