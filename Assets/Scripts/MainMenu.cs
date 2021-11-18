using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string levelToLoad = "LevelSelect";

    public void Play()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Quit()
    {
        Debug.Log("Exciting");
        Application.Quit();
    }

    public void Restart()
    {
        sceneFader.FadeTo(levelToLoad);
    }
}
