using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController _playerMove;

    public float speed;
   // public float rotationSpeed;
   private Vector3 _dir = Vector3.zero;
    void Start()
    {
        _playerMove = GetComponent<CharacterController>();
        if (speed < 15) speed = 15;
    }

    void Update()
    {
        _dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        _dir *= speed;
        transform.position += _dir * Time.deltaTime;
    }
}