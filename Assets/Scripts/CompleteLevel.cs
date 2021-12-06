using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    GameObject _completedLevelOverlay, _playerGUI;
    SceneFader _sceneFader;
    BeatGame _beatGame;
    Button _retryButton, _menuButton, _continueButton;
    string _mainMenu = "MainMenu";
    public string nextLevel;
    public int levelToUnlock;
    public bool wonLevel = false;

    void Awake()
    {
        _beatGame = FindObjectOfType<BeatGame>();
        _sceneFader = FindObjectOfType<SceneFader>();

        _playerGUI = GameObject.FindGameObjectWithTag("PlayerGameOverlay");
        _completedLevelOverlay = GameObject.FindGameObjectWithTag("CompletedLevelOverlay");

        _retryButton = _retryButton = GameObject.FindGameObjectWithTag("CLRetryButton").GetComponent<Button>();
        _menuButton = GameObject.FindGameObjectWithTag("CLMenuButton").GetComponent<Button>();
        _continueButton = GameObject.FindGameObjectWithTag("CLContinueButton").GetComponent<Button>();
    }

    void Start()
    {
        _completedLevelOverlay.SetActive(false);
        _playerGUI.SetActive(true);

        _retryButton.onClick.AddListener(Retry);
        _menuButton.onClick.AddListener(Menu);
        _continueButton.onClick.AddListener(Continue);
    }

    void Continue()
    {
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        _sceneFader.FadeTo(nextLevel);
    }

    void Menu()
    {
        _sceneFader.FadeTo(_mainMenu);
    }

    void Retry()
    {
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    public void WinLevel()
    {
        wonLevel = true;
        _playerGUI.SetActive(false);
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Level12"))
        {
            _beatGame.beatGameOverlay.SetActive(true);
        }
        else
        {
            _completedLevelOverlay.SetActive(true);
        }
    }
}
