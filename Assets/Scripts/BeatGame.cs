using UnityEngine;
using UnityEngine.UI;

public class BeatGame : MonoBehaviour
{
    SceneFader _sceneFader;
    Button _quitButton, _menuButton;
    public GameObject beatGameOverlay;
    string _mainMenu = "MainMenu";

    void Awake()
    {
        _sceneFader = FindObjectOfType<SceneFader>();

        beatGameOverlay = GameObject.FindGameObjectWithTag("BeatGameOverlay");

        _quitButton = GameObject.FindGameObjectWithTag("BGQuitButton").GetComponent<Button>();
        _menuButton = GameObject.FindGameObjectWithTag("BGMenuButton").GetComponent<Button>();
    }

    void Start()
    {
        beatGameOverlay.SetActive(false);

        _quitButton.onClick.AddListener(Quit);
        _menuButton.onClick.AddListener(Menu);
    }

    void Quit()
    {
        Debug.Log("Exciting");
        Application.Quit();
    }

    void Menu()
    {
        _sceneFader.FadeTo(_mainMenu);
    }
}
