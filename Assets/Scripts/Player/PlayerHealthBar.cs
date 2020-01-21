using TMPro;
using UnityEngine;

public class PlayerHealthBar : MonoBehaviour
{
    private TextMeshProUGUI _displayHealth;
    private float _hp;
    public static float startingHealth { get; set; }

    private void Start()
    {
        if (startingHealth < 100) startingHealth = 100;
        _displayHealth = GetComponent<TextMeshProUGUI>();
        GameWatcher.CurrentHealth = startingHealth;
    }

    private void Update()
    {
        _displayHealth.text = "HP: " + GameWatcher.CurrentHealth;
    }
}