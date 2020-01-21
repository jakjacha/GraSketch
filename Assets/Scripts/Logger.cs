using TMPro;
using UnityEngine;

public class Logger : MonoBehaviour
{
    // Start is called before the first frame update
    private TextMeshProUGUI _display;

    private void Start()
    {
        _display = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _display.text = "Enemies: " + GameWatcher.CurrentEnemiesCount + "\n" 
                        + "Kills: " + GameWatcher.CurrentEnemiesKilled;
    }
}