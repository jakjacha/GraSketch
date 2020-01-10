using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using TMPro;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class EnemyMovementAI : MonoBehaviour
{
    public int speed = 3;
    public int rotationSpeed;
    public float enemyAttackRange;
    public float moveCooldown;
    private GameObject _player;
    private bool flag = true;
    private float _cooldownTime;

    void Start()
    {
        enemyAttackRange = 4;
        _player = GameObject.FindGameObjectWithTag("Player");
        moveCooldown = 1.0f;
        float cooldownTime = Time.time + moveCooldown;
    }

    void Update()
    {
        Vector3 target = _player.transform.position;
        Vector3 pos = transform.position;
        //linie laczace enemy i target
        Debug.DrawLine(target, pos, Color.blue);

        //Debug.Log(pos.z + " " + target.z);
        if (Vector3.Distance(target, pos) > enemyAttackRange)
        {
            if (pos.z > target.z && flag)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
            }
            else if (pos.z < target.z && flag)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
            }

            if (pos.x > target.x && !flag)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
            }
            else if (pos.x < target.x && !flag)
            {
                transform.position += transform.right * speed * Time.deltaTime;
            }
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