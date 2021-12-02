using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject _gameOverOverlay, _playerGUI;
    SceneFader _sceneFader;
    Button _retryButton, _menuButton;
    bool _lossLevel = false;
    string _mainMenu = "MainMenu";

    void Awake()
    {
        _sceneFader = FindObjectOfType<SceneFader>();

        _playerGUI = GameObject.FindGameObjectWithTag("PlayerGameOverlay");
        _gameOverOverlay = GameObject.FindGameObjectWithTag("GameOverOverlay");

        _retryButton = GameObject.FindGameObjectWithTag("GORetryButton").GetComponent<Button>();
        _menuButton = GameObject.FindGameObjectWithTag("GOMenuButton").GetComponent<Button>();
    }
    void Start()
    {
        _playerGUI.SetActive(true);
        _gameOverOverlay.SetActive(false);

        _retryButton.onClick.AddListener(Retry);
        _menuButton.onClick.AddListener(Menu);
    }

    void Retry()
    {
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    void Menu()
    {
        _sceneFader.FadeTo(_mainMenu);
    }

    public void EndGame()
    {
        _gameOverOverlay.SetActive(true);
        _playerGUI.SetActive(false);
        _lossLevel = true;
    }


}
