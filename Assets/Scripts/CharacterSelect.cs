using UnityEngine;
using UnityEngine.UI;

public class CharacterSelect : MonoBehaviour
{
    SceneFader _sceneFader;
    Button _nextCharacter, _previousCharacter, _selectCharacter;
    public GameObject[] characters;
    public static int selectedCharacter = 0;

    void Awake()
    {
        _sceneFader = FindObjectOfType<SceneFader>();

        _nextCharacter = GameObject.FindGameObjectWithTag("NextCharacterButton").GetComponent<Button>();
        _previousCharacter = GameObject.FindGameObjectWithTag("PreviousCharacterButton").GetComponent<Button>();
        _selectCharacter = GameObject.FindGameObjectWithTag("SelectCharacterButton").GetComponent<Button>();
    }

    void Start()
    {
        _nextCharacter.onClick.AddListener(NextCharacter);
        _previousCharacter.onClick.AddListener(PreviousCharacter);
        _selectCharacter.onClick.AddListener(SelectCharacter);
    }

    void NextCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    void PreviousCharacter()
    {
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        if (selectedCharacter < 0)
        {
            selectedCharacter += characters.Length;
        }
        characters[selectedCharacter].SetActive(true);
    }

    void SelectCharacter()
    {
        PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
        _sceneFader.FadeTo("LevelSelect");
    }
}
