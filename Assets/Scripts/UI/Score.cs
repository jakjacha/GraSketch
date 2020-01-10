using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Experimental.PlayerLoop;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _scoreOutput;
    public float score;

    private void Start()
    {
        _scoreOutput = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //GameWatcher currentScore = GetComponent<GameWatcher>();
       // _score = currentScore.currentPoints;
       _scoreOutput.text = ("Punkty " + score.ToString());
    }
}
