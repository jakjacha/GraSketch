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
    public float cooldownTime = 1;
    
    private float _nextAttack;
    private Vector3 _rangeWing1; 
    private Vector3 _rangeWing2;
    private float _attackAngleBetween = 0;
    private float _attackAngleSize = 0;
    
    

    private Vector3 _playerPos;

    // Update is called once per frame
    void Update()
    {
        _playerPos = transform.position;
        _rangeWing1 = new Vector3(_playerPos.x+attackAngle, _playerPos.y, _playerPos.z+attackRange);
        _rangeWing2 = new Vector3(_playerPos.x-attackAngle,_playerPos.y, _playerPos.z+attackRange);
        
        if (Input.GetKeyUp(KeyCode.Space) && Time.time > _nextAttack)
        {
            _nextAttack = Time.time + cooldownTime; 
            if (enemy)
                Attack();
        }
        //FindEnemy();
        FindTarget();
 
        //DEBUG
        Debug.DrawLine(_playerPos,_rangeWing1,Color.green);
        Debug.DrawLine(_playerPos,_rangeWing2,Color.green);
        Debug.DrawLine(_rangeWing1,_rangeWing2, Color.green);
    }

    private void Attack()
    {
        EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.UpdateCurrentHealth(change: damageValue);
    }

    private void FindEnemy()
    {
        GameObject enFind = GameObject.FindGameObjectWithTag("Enemy");
        Vector3 enFindPos = enFind.transform.position;
        float distance = Vector3.Distance(_playerPos,enFindPos);
        _attackAngleBetween = Vector3.Angle(enFindPos, _rangeWing1) + Vector3.Angle(enFindPos, _rangeWing2);
        _attackAngleSize = Vector3.Angle(_rangeWing1, _rangeWing2);
        if (distance < attackRange && _attackAngleBetween>_attackAngleSize)
        {
            enemy = enFind;
        }
        else
        {
            enemy = null;
        }
    }

    void FindTarget()
    {
        GameObject enFound = FindClosestEnemy(0f, attackRange);
        if (!enFound)
        {
            enemy = null;
            return;
        }
        Vector3 enFoundPos = enFound.transform.position;
        _attackAngleBetween = Vector3.Angle(enFoundPos, _rangeWing1) + Vector3.Angle(enFoundPos, _rangeWing2);
        _attackAngleSize = Vector3.Angle(_rangeWing1, _rangeWing2);
        enemy = _attackAngleBetween > _attackAngleSize ? enFound : null;
    }

    private GameObject FindClosestEnemy(float min, float max) 
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
     
        // calculate squared distances
        min = min * min;
        max = max * max;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance >= min && curDistance <= max)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}
