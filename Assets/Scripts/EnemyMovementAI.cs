using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    private Transform _target;
    public int speed;
    public int rotationSpeed;
    public float enemyAttackRange;
    private GameObject _player;

    //private Transform _enemyPos;

    void Start()
    {
        enemyAttackRange = 4;
        _player = GameObject.FindGameObjectWithTag("Player");
        _target = _player.transform;
    }
    
    void Update()
    {
        //linie laczace enemy i target
        Debug.DrawLine(_target.position, transform.position, Color.blue); 
        //obrot w strone target
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.position - transform.position), rotationSpeed * Time.deltaTime );
        //ruch do przodu
        if (Vector3.Distance(_target.position, transform.position) > enemyAttackRange)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else
        {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }
        //za blisko

        if (transform.position.x <= -45f) {
            transform.position = new Vector3(-45f,transform.position.y, transform.position.y);
        } else if (transform.position.x >= 45f) {
            transform.position = new Vector3(45f,transform.position.y, transform.position.y);
        }
 
        // Y axis
        if (transform.position.z <= 30f) {
            transform.position = new Vector3(transform.position.x,transform.position.y, 30f);
        } else if (transform.position.y >= 120f) {
            transform.position = new Vector3(transform.position.x,transform.position.y, 120f);
        }
    }

    private void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.CompareTag("Wall"))
        {
            transform.position = Vector3.zero;
            
        }
        Debug.Log(col.gameObject.name);
    }
}
