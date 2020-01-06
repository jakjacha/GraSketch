using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    CharacterController _playerMove;

    public float moveSpeed;
    public float rotationSpeed;

    void Start()
    {
        _playerMove = GetComponent<CharacterController>();
        if (moveSpeed < 5) moveSpeed = 5;
        if (rotationSpeed < 5) rotationSpeed = 5;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Vertical");
        float verticalInput = Input.GetAxis("Horizontal");

        Vector3 moveDirection = new Vector3(verticalInput, 0, horizontalInput);

        if (moveDirection.sqrMagnitude > 0.001f)
        {
            var desiredRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, Time.deltaTime * rotationSpeed);
            transform.position += transform.forward * Time.deltaTime * moveSpeed;
        }
    }
}