using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{
    public float ballLife;
    private float _ballLifeTime;
    private void Start()
    {
        _ballLifeTime = Time.time;
        if (ballLife < 1) ballLife = 50;
    }

    private void Update()
    {
        if(_ballLifeTime+ballLife > Time.time)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
        Debug.Log(col.gameObject.name);
    }
}
