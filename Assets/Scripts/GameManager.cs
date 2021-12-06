using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool lossLevel = false;
    bool wonLevel = false;
    GameOver _gameOver;
    PlayerController _playerController;

    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
        _gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (AmmoController.Ammo <= 0 && !wonLevel && _playerController.playerRigidbody2D.position == _playerController.playerStartPosition)
        {
            _gameOver.EndGame();
        }
        if (lossLevel || wonLevel)
        {
            return;
        }
    }

}
