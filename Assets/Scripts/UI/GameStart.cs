using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused;
    public GameObject GameStartUI;

    // Update is called once per frame

    private void Start()
    {
        Pause();
    }

    private void Update()
    {

            if (Input.GetKeyDown(KeyCode.Space) )
            {
                GameStartUI.SetActive(false);
                Resume();
            }
    }

    private void Resume()
    {
        GameStartUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        GameStartUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
