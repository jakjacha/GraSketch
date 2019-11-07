using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // Start is called before the first frame update
    public Text txtOutput;
    private GameObject _txtOutputTemp;
    private float _timer;
    private GameObject _playerTemp;

    void Start()
    {
        _txtOutputTemp = GameObject.Find("Skill1");
        txtOutput = _txtOutputTemp.GetComponent<Text>();
        PlayerFireAttack playerFireAttack = _playerTemp.GetComponent<PlayerFireAttack>();
        _timer = playerFireAttack.specialAttackCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        txtOutput.text = _timer.ToString();
    }
}
