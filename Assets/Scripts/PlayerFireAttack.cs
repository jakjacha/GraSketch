using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerFireAttack : MonoBehaviour
{
    public GameObject ball;

    public float speed;

    void Start()
    {
        ball = Resources.Load("Ball") as GameObject;
        if (speed < 1) speed = 1;
    }

    void Update()
    {
        Vector3 playerPos = transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot(playerPos);
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
        rb.velocity = transform.forward * speed;
        
    }
}
