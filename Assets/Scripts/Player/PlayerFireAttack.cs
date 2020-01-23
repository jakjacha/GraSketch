using UnityEngine;

public class PlayerFireAttack : MonoBehaviour
{
    private float _ballLifeTime;
    private float _fireAttackCooldownTime;


    private Vector3 _playerPos;
    public GameObject ball;

    public float ballSpeed;
    public float fireAttackCooldown;
    public float specialAttackCooldown;

    private void Start()
    {
        ballSpeed = GetComponent<PlayerMove>().speed + 10;
        ball = Resources.Load("Ball") as GameObject;
        if (ballSpeed < 1) ballSpeed = 10;
        if (_ballLifeTime < 1) _ballLifeTime = 10;
        if (fireAttackCooldown <= 0) fireAttackCooldown = 0.2f;
    }

    private void Update()
    {
        _playerPos = transform.position;
        //attack FWD
        if (Input.GetKeyDown(KeyCode.I) && Time.time > _fireAttackCooldownTime)
        {
            Shoot(_playerPos, transform.forward);
            _fireAttackCooldownTime = Time.time + fireAttackCooldown;
        }

        //attack BWD
        if (Input.GetKeyDown(KeyCode.K) && Time.time > _fireAttackCooldownTime)
        {
            Shoot(_playerPos, transform.forward, -1);
            _fireAttackCooldownTime = Time.time + fireAttackCooldown;
        }

        //attack Right
        if (Input.GetKeyDown(KeyCode.L) && Time.time > _fireAttackCooldownTime)
        {
            Shoot(_playerPos, transform.right);
            _fireAttackCooldownTime = Time.time + fireAttackCooldown;
        }

        //attack Left
        if (Input.GetKeyDown(KeyCode.J) && Time.time > _fireAttackCooldownTime)
        {
            Shoot(_playerPos, transform.right, -1);
            _fireAttackCooldownTime = Time.time + fireAttackCooldown;
        }

        //attack ALL
       // if (Input.GetKeyDown(KeyCode.U)) ShootAll();
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

    private void ShootAll()
    {
        Shoot(_playerPos, transform.forward);
        Shoot(_playerPos, transform.forward, -1);
        Shoot(_playerPos, transform.right);
        Shoot(_playerPos, transform.right, -1);
    }
}