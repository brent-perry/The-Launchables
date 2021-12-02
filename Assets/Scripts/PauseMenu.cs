using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    SceneFader _sceneFader;
    string mainMenu = "MainMenu";
    Button _resumeButton, _retryButton, _menuButton;
    GameObject _pauseOverlay;
    AudioSource _audioSource;

    void Awake()
    {
        _sceneFader = FindObjectOfType<SceneFader>();

        _audioSource = GameObject.FindGameObjectWithTag("MusicController").GetComponent<AudioSource>();
        
        _pauseOverlay = GameObject.FindGameObjectWithTag("PauseOverlay");

        _resumeButton = GameObject.FindGameObjectWithTag("PauseResumeButton").GetComponent<Button>();
        _retryButton = GameObject.FindGameObjectWithTag("PauseRetryButton").GetComponent<Button>();
        _menuButton = GameObject.FindGameObjectWithTag("PauseMenuButton").GetComponent<Button>();
    }

    void Start()
    {
        _pauseOverlay.SetActive(false);

        _resumeButton.onClick.AddListener(TogglePause);
        _retryButton.onClick.AddListener(Retry);
        _menuButton.onClick.AddListener(Menu);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        _pauseOverlay.SetActive(!_pauseOverlay.activeSelf);

        if (_pauseOverlay.activeSelf)
        {
            Time.timeScale = 0f;
            _audioSource.Pause();
        }
        else
        {
            Time.timeScale = 1f;
            _audioSource.Play();
        }
    }

    void Retry()
    {
        TogglePause();
        _sceneFader.FadeTo(SceneManager.GetActiveScene().name);
    }

    void Menu()
    {
        TogglePause();
        _sceneFader.FadeTo(mainMenu);
    }
}
