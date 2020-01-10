using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWatcher : MonoBehaviour
{
    public float currentPoints=0;

    private void Start()
    {
        currentPoints = 0;
    }

    private void Update()
    {
        //currentScore.score = currentPoints;
    }

    public void UpdatePoints(float pts)
    {
        currentPoints += pts;
    }
}
