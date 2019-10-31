using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerFireAttack : MonoBehaviour
{
    public GameObject ball;

    public float ballSpeed;
    public float fireAttackCooldown;
    
    private float _ballLifeTime;
    private float _ballTime;
    void Start()
    {
        ballSpeed = GetComponent<PlayerMove>().moveSpeed;
        ball = Resources.Load("Ball") as GameObject;
        if (ballSpeed < 1) ballSpeed += 10;
        if (_ballLifeTime < 1) _ballLifeTime = 10;
        if (fireAttackCooldown < 1) fireAttackCooldown = 1;
    }

    void Update()
    {
        Vector3 playerPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Space) && Time.time > _ballTime)
        {
            Shoot(playerPos);
            _ballTime = Time.time + fireAttackCooldown;
        }
        
        //DEBUG
        Debug.DrawRay(playerPos, new Vector3(50,0,0), Color.red );
        
        Debug.DrawRay(playerPos, new Vector3(-50,0,0), Color.red );
        
        Debug.DrawRay(playerPos, new Vector3(0,0,50), Color.blue);
        
        Debug.DrawRay(playerPos, new Vector3(0,0,-50), Color.blue );
    }

    private void Shoot(Vector3 pPos)
    {
        if (!ball) {Debug.Log("Brak obiektu");return;}
        GameObject ballCpy = Instantiate(ball) as GameObject;
        ballCpy.transform.position = pPos + transform.forward;
        Rigidbody rb = ballCpy.GetComponent<Rigidbody>();
        rb.velocity = transform.forward * ballSpeed;
        Destroy(ballCpy, _ballLifeTime);
    }
    
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy")) Destroy(gameObject);
        
        if(col.gameObject.CompareTag("Wall")) Destroy(gameObject);
        
        Debug.Log(col.gameObject.name);
    }
}
