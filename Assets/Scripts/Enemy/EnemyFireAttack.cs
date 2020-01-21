using UnityEngine;

public class EnemyFireAttack : MonoBehaviour
{
    private float _ballLifeTime;
    private float _fireAttackCooldownTime;
    private GameObject _target;
    public GameObject ball;

    public float ballSpeed;
    public float damageValue;
    public float fireAttackCooldown;
    public static float DamageValue { get; set; }

    private void Start()
    {
        DamageValue = damageValue;
        ballSpeed = 10;
        ball = Resources.Load("EnemyBall") as GameObject;
        if (ballSpeed < 1) ballSpeed = 10;
        if (_ballLifeTime < 1) _ballLifeTime = 10;
        if (fireAttackCooldown < 2) fireAttackCooldown = 2;

        _target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        var pos = transform.position;
        if (Time.time > _fireAttackCooldownTime)
        {
            var dir = pos - _target.transform.position;
            //Debug.Log(name + " " + dir);
            if (dir.x > dir.z)
            {
                if (dir.x > 0)
                    //Debug.Log("prawo");
                    Shoot(pos, transform.right, -1);

                else if (dir.z < 0)
                    // Debug.Log("tyl");
                    Shoot(pos, transform.forward);
            }
            else if (dir.x < dir.z)
            {
                if (dir.z > 0)
                    //Debug.Log("przod");
                    Shoot(pos, transform.forward, -1);

                else if (dir.x < 0)
                    //Debug.Log("lewo");
                    Shoot(pos, transform.right);
            }

            _fireAttackCooldownTime = Time.time + fireAttackCooldown;
        }
    }

    private void Shoot(Vector3 pPos, Vector3 tsf, float dir = 1)
    {
        if (!ball)
        {
            Debug.Log("Brak obiektu");
            return;
        }

        var ballCpy = Instantiate(ball);
        ballCpy.transform.position = pPos + dir * tsf;
        var rb = ballCpy.GetComponent<Rigidbody>();
        rb.velocity = dir * tsf * ballSpeed;
        Destroy(ballCpy, _ballLifeTime);
    }
}