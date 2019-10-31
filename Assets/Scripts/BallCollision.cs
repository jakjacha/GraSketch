using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Enemy") || col.gameObject.CompareTag(("Wall")))
        {
            Destroy(gameObject);
        }
        Debug.Log(col.gameObject.name);
    }
}