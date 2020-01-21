using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    private float _cooldownTime;
    private GameObject _player;
    public float enemyAttackRange;
    private bool flag = true;
    public float moveCooldown;
    public int speed = 3;

    private void Start()
    {
        enemyAttackRange = 4;
        _player = GameObject.FindGameObjectWithTag("Player");
        moveCooldown = 1.0f;
        var cooldownTime = Time.time + moveCooldown;
    }

    private void Update()
    {
        var target = _player.transform.position;
        var pos = transform.position;
        //linie laczace enemy i target
        Debug.DrawLine(target, pos, Color.blue);

        //Debug.Log(pos.z + " " + target.z);
        if (Vector3.Distance(target, pos) > enemyAttackRange)
        {
            if (pos.z > target.z && flag)
                transform.position -= transform.forward * speed * Time.deltaTime;
            else if (pos.z < target.z && flag) transform.position += transform.forward * speed * Time.deltaTime;

            if (pos.x > target.x && !flag)
                transform.position -= transform.right * speed * Time.deltaTime;
            else if (pos.x < target.x && !flag) transform.position += transform.right * speed * Time.deltaTime;
        }

        //Debug.Log(_cooldownTime + " " + Time.time);
        if (Time.time > _cooldownTime)
        {
            flag = !flag;
            // Debug.Log(flag);
            _cooldownTime = Time.time + moveCooldown;
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            //transform.position = Vector3.zero;
        }

        //Debug.Log(col.gameObject.name);
    }

    /*private void oldMove(Vector3 target)
    {
        //obrot w strone target
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target - transform.position), rotationSpeed * Time.deltaTime );
        //ruch do przodu
        if (Vector3.Distance(target, transform.position) > enemyAttackRange)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
    }*/
}