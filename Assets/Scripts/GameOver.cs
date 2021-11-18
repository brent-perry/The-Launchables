using UnityEngine;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;
    public string levelToLoad = "LevelSelect";

    public void Restart()
    {
        sceneFader.FadeTo(levelToLoad);
    }

    public void Menu()
    {
        Debug.Log("Go To Menu");
    }
}
