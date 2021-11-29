using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
    public GameObject[] characters;
    static int selectedCharacter = 0;
    SceneFader _sceneFader;

    void Start()
    {
         _sceneFader = FindObjectOfType<SceneFader>();
    }

    public void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    public void SelectCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        _sceneFader.FadeTo("LevelSelect");
    }
}
