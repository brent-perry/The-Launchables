using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    SceneFader _sceneFader;
    string _levelToLoad = "CharacterSelect";
    Button _playButton, _quitButton;

    void Start()
    {
        _sceneFader = FindObjectOfType<SceneFader>();
        
        _playButton = GameObject.FindGameObjectWithTag("PlayButton").GetComponent<Button>();
        _quitButton = GameObject.FindGameObjectWithTag("QuitButton").GetComponent<Button>();

        _playButton.onClick.AddListener(Play);
        _quitButton.onClick.AddListener(Quit);
    }

    void Play()
    {
        _sceneFader.FadeTo(_levelToLoad);
    }

    void Quit()
    {
        Debug.Log("Exciting");
        Application.Quit();
    }
}
