using UnityEngine;

public class UIHandler : MonoBehaviour
{
    public GameObject GameOverMenu;
    public GameObject GameUI;
    public GameObject PauseMenu;

    private void Update()
    {
        if (PauseMenu.activeSelf || GameOverMenu.activeSelf)
            GameUI.SetActive(false);
        else
            GameUI.SetActive(true);
    }
}