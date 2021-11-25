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
    public GameObject completedLevelUI;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (AmmoController.Ammo <= 0 && !wonLevel)
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

    public void WinLevel()
    {
        wonLevel = true;
        completedLevelUI.SetActive(true);
    }
}
