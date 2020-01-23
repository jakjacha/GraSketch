using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject GameUI;
    public GameObject PauseMenu;
    public GameObject GameStart;

    private void Update()
    {
        if (PauseMenu.activeSelf || GameOverMenu.activeSelf || GameStart.activeSelf)
            GameUI.SetActive(false);
        else
            GameUI.SetActive(true);
    }
}