using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementAI : MonoBehaviour
{
    public Transform target;
    public int speed;
    public int rotationSpeed;

    public GameObject player;

    private Transform _enemyPos;

    void Awake()
    {
        _enemyPos = transform;
    }

    void Start()
    {
        target = player.transform;
    }
    
    void Update()
    {
        //linie laczace enemy i target
        Debug.DrawLine(target.position, _enemyPos.position, Color.blue); 
        //obrot w strone target
        _enemyPos.rotation = Quaternion.Slerp(_enemyPos.rotation, Quaternion.LookRotation(target.position - _enemyPos.position), rotationSpeed * Time.deltaTime );
        //ruch do przodu
        _enemyPos.position += _enemyPos.forward * speed * Time.deltaTime;
    }
}
