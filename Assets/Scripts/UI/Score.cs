using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TextMeshProUGUI _displayScore;
    private float _score;

    private void Start()
    {
        _displayScore = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _displayScore.text = "PTS: " + GameWatcher.CurrentPoints;
    }
    
}