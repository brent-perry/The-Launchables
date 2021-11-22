using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    string levelToLoad = "CharacterSelect";

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
