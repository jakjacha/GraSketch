using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float _attackAngleBetween;
    private float _attackAngleSize;

    private float _nextAttack;

    private Vector3 _playerPos;
    private Vector3 _rangeWing1;
    private Vector3 _rangeWing2;
    public float attackAngle = 10;
    public float attackRange = 10;
    public float cooldownTime = 1;

    public int damageValue = 10;
    public GameObject enemy;

    // Update is called once per frame
    private void Update()
    {
        _playerPos = transform.position;
        _rangeWing1 = new Vector3(_playerPos.x + attackAngle, _playerPos.y, _playerPos.z + attackRange);
        _rangeWing2 = new Vector3(_playerPos.x - attackAngle, _playerPos.y, _playerPos.z + attackRange);

        if (Input.GetKeyUp(KeyCode.Space) && Time.time > _nextAttack)
        {
            _nextAttack = Time.time + cooldownTime;
            if (enemy)
                Attack();
        }

        //FindEnemy();
        FindTarget();

        //DEBUG
        Debug.DrawLine(_playerPos, _rangeWing1, Color.green);
        Debug.DrawLine(_playerPos, _rangeWing2, Color.green);
        Debug.DrawLine(_rangeWing1, _rangeWing2, Color.green);
    }

    private void Attack()
    {
        var enemyHealth = enemy.GetComponent<EnemyHealth>();
        enemyHealth.UpdateCurrentHealth(damageValue);
    }

    private void FindEnemy()
    {
        var enFind = GameObject.FindGameObjectWithTag("Enemy");
        var enFindPos = enFind.transform.position;
        var distance = Vector3.Distance(_playerPos, enFindPos);
        _attackAngleBetween = Vector3.Angle(enFindPos, _rangeWing1) + Vector3.Angle(enFindPos, _rangeWing2);
        _attackAngleSize = Vector3.Angle(_rangeWing1, _rangeWing2);
        if (distance < attackRange && _attackAngleBetween > _attackAngleSize)
            enemy = enFind;
        else
            enemy = null;
    }

    private void FindTarget()
    {
        var enFound = FindClosestEnemy(0f, attackRange);
        if (!enFound)
        {
            enemy = null;
            return;
        }

        var enFoundPos = enFound.transform.position;
        _attackAngleBetween = Vector3.Angle(enFoundPos, _rangeWing1) + Vector3.Angle(enFoundPos, _rangeWing2);
        _attackAngleSize = Vector3.Angle(_rangeWing1, _rangeWing2);
        enemy = _attackAngleBetween > _attackAngleSize ? enFound : null;
    }

    private GameObject FindClosestEnemy(float min, float max)
    {
        var gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        var distance = Mathf.Infinity;
        var position = transform.position;

        // calculate squared distances
        min = min * min;
        max = max * max;


        foreach (var go in gos)
        {
            var diff = go.transform.position - position;
            var curDistance = diff.sqrMagnitude;
            if (curDistance < distance && curDistance >= min && curDistance <= max)
            {
                closest = go;
                distance = curDistance;
            }
        }

        return closest;
    }
}