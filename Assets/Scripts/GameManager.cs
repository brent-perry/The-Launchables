using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool gameEnded = false;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        //if you run out of ammo for the birds then game over
        // if()
        // {
        //     EndGame();
        // }
    }

    void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
