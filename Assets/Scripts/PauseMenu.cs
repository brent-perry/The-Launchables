using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public string levelToLoad = "LevelSelect";
    public GameManager gameManager;
    public SceneFader sceneFader;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            PauseGame();
        }
    }

    public void PauseGame()
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

    

    public void Restart()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}
