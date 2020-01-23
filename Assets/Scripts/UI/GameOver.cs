using System;
using UnityEngine;
using System.IO;
using System.IO.IsolatedStorage;
using TMPro;
public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused;
    public GameObject GameOverUI;

    public TextMeshProUGUI displayHighscore;
    public TextMeshProUGUI displayCurrentHighscore;
    private float _currentHighscore;

    private float _highscore;
    // Update is called once per frame

    private void Start()
    {
        _highscore = loadHighscore();
    }

    private void Update()
    {
        if (GameWatcher.CurrentHealth <= 0)
        {
            Pause();
            _currentHighscore = GameWatcher.CurrentPoints;
            displayCurrentHighscore.text = "Twój wynik: " + _currentHighscore;
            displayHighscore.text = "Highscore: " + _highscore;
            if (Input.GetKeyDown(KeyCode.Space) )
            {
//                if (_currentHighscore > _highscore)
//                {
//                    saveHighscore(_currentHighscore);
//                }
                Resume();
                Application.LoadLevel(0);
            }
        }
    }

    private void Resume()
    {
        GameOverUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    private void saveHighscore(float hs)
    {
        string path = "Assets/Resources/test.txt";

        //Write some text to the test.txt file
        File.WriteAllText(@path, string.Empty);
        StreamWriter writer = new StreamWriter(path, false);
        //StreamWriter writer = new StreamWriter(new IsolatedStorageFileStream(path, FileMode.Truncate));
        Debug.Log(hs);
        writer.WriteLine(hs);
        writer.Close();
    }
    private float loadHighscore()
    {
        string path = "Assets/Resources/highscore.txt";
        StreamReader reader = new StreamReader(@path);
        float x = float.Parse(reader.ReadToEnd());
        reader.Close();
        Debug.Log("load: " + x);
        return x;
    }
}