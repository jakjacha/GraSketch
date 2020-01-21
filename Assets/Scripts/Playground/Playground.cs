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
        if (GameWatcher.CurrentEnemiesCount <= 0 && GameWatcher.NextLevelFlag)
        {
            Brama.SetActive(false);
            Marker.SetActive(true);
            GameWatcher.NextLevelFlag = false;
        }
            
    }
}
