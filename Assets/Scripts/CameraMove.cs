using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Vector3 _offset;
    public GameObject player;

    private void Start()
    {
        _offset = transform.position - player.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + _offset;
    }
}