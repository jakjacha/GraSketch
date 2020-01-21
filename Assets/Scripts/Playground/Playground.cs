using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playground : MonoBehaviour
{
    public GameObject Brama;
    public GameObject Marker;

    private void Update()
    {
        if (GameWatcher.CurrentEnemiesCount <= 0 && GameWatcher.NextLevelFlag && GameWatcher.NewEnemiesKilled)
        {
            Brama.SetActive(false);
            if (Marker != null) Marker.SetActive(true);
            //Debug.Log("here");
        }
            
    }
}
