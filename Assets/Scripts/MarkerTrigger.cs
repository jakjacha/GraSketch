using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerTrigger : MonoBehaviour
{
    public GameObject go;
    // Start is called before the first frame update
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Activating: " + go.name);
        go.SetActive(true);
    }
}
