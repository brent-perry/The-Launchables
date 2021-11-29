using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    bool lossLevel = false;
    bool wonLevel = false;
    GameOver _gameOver;

    void Start()
    {
       _gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (AmmoController.Ammo <= 0 && !wonLevel)
        {
            _gameOver.EndGame();
        }
        if (lossLevel || wonLevel)
        {
            return;
        }
    }

    
}
