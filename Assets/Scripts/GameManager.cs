using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool lossLevel = false;
    bool wonLevel = false;
    public SceneFader sceneFader;
    public string levelSelect = "LevelSelect";
    public GameObject gameOverUI;
    public GameObject nextLevelUI;
    public GameObject pauseMenuUI;
    public Enemy[] enemies;

    void Update()
    {
        if (PlayerController.Ammo <= 0 && !wonLevel)
        {
            EndGame();
        }
        if (lossLevel || wonLevel)
        {
            return;
        }
    }

    public void EndGame()
    {
        gameOverUI.SetActive(true);
        lossLevel = true;
    }

    public void NextLevelOverlay()
    {
        Debug.Log("meow");
        wonLevel = true;
        nextLevelUI.SetActive(true);
    }

    public void NextLevel()
    {
        sceneFader.FadeTo(levelSelect);
    }
}
