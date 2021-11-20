using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameManager gameManager;
    public SceneFader sceneFader;
    public string mainMenu = "MainMenu";
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        gameManager.pauseMenuUI.SetActive(!gameManager.pauseMenuUI.activeSelf);

        if (gameManager.pauseMenuUI.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }
    
    public void Retry()
    {
        TogglePause();
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void Menu()
    {
        TogglePause();
        sceneFader.FadeTo(mainMenu);
    }
}
