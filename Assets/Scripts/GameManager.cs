using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameOver _gameOver;
    CompleteLevel _completeLevel;
    PlayerController _playerController;

    void Start()
    {
        _completeLevel = FindObjectOfType<CompleteLevel>();
        _playerController = FindObjectOfType<PlayerController>();
        _gameOver = FindObjectOfType<GameOver>();
    }

    void Update()
    {
        if (AmmoController.Ammo <= 0 && !_completeLevel.wonLevel && _playerController.playerRigidbody2D.position == _playerController.playerStartPosition)
        {
            _gameOver.EndGame();
        }
        if (_gameOver.lossLevel || _completeLevel.wonLevel)
        {
            return;
        }
    }

}
