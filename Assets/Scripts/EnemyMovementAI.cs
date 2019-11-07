using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    private Transform _target;
    public int speed;
    public int rotationSpeed;

    public GameObject _player;

    //private Transform _enemyPos;

    void Start()
    {
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
        transform.position += transform.forward * speed * Time.deltaTime;
    }
}
