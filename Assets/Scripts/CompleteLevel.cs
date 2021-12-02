using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CompleteLevel : MonoBehaviour
{
    GameObject _completedLevelOverlay, _playerGUI;
    SceneFader _sceneFader;
    Button _retryButton, _menuButton, _continueButton;
    string _mainMenu = "MainMenu";
    public string nextLevel;
    public int levelToUnlock;
    bool _wonLevel = false;

    void Awake()
    {
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
        _wonLevel = true;
        _completedLevelOverlay.SetActive(true);
        _playerGUI.SetActive(false);
    }
}
