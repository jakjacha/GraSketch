using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController _playerMove;

    public float speed;
    void Start()
    {
        _playerMove = GetComponent<CharacterController>();
    }

    void Update()
    {
        Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal")*Time.deltaTime*speed, 0f, Input.GetAxisRaw("Vertical")*Time.deltaTime*speed);
        transform.Translate(input);
    }
}