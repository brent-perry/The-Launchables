using UnityEngine;
using UnityEngine.UI;
public class LevelSelector : MonoBehaviour
{
    SceneFader _sceneFader;
    public Button[] levelButtons;

    void Start()
    {
        _sceneFader = FindObjectOfType<SceneFader>();

        int levelReached = PlayerPrefs.GetInt("levelReached", 1);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i > levelReached)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Select(string levelName)
    {
        _sceneFader.FadeTo(levelName);
    }
}
