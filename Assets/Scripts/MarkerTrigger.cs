using UnityEngine;

public class MarkerTrigger : MonoBehaviour
{
    public GameObject go;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("Activating: " + go.name);
            go.SetActive(true);
        }
    }
}