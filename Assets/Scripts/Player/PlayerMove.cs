using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // public float rotationSpeed;
    private Vector3 _dir = Vector3.zero;
    private CharacterController _playerMove;
    public float speed;

    private void Start()
    {
        _playerMove = GetComponent<CharacterController>();
        if (speed < 15) speed = 15;
    }

    private void Update()
    {
        _dir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
        _dir *= speed;
        transform.position += _dir * Time.deltaTime;
    }
}