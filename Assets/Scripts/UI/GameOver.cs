using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused;
    public GameObject GameOverUI;

    // Update is called once per frame
    private void Update()
    {
        if (GameWatcher.CurrentHealth <= 0)
        {
            Pause();
            if (Input.GetKeyDown(KeyCode.Space) )
            {
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
}