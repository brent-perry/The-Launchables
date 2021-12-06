using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    GameObject _gameOverOverlay, _playerGUI;
    SceneFader _sceneFader;
    Button _retryButton, _menuButton;
    AudioSource _audioSource;
    public bool lossLevel = false;
    string _mainMenu = "MainMenu";

    void Awake()
    {
        _sceneFader = FindObjectOfType<SceneFader>();

        _audioSource = GameObject.FindGameObjectWithTag("MusicController").GetComponent<AudioSource>();

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
        _audioSource.Stop();
        _gameOverOverlay.SetActive(true);
        _playerGUI.SetActive(false);
        lossLevel = true;
    }


}
