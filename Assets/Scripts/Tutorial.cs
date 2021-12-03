using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    Button _helpButton, _closeTutorialButton;
    GameObject _tutorialOverlay;

    void Awake()
    {
        _tutorialOverlay = GameObject.FindGameObjectWithTag("TutorialOverlayCanvas");

        _closeTutorialButton = GameObject.FindGameObjectWithTag("CloseTutorialButton").GetComponent<Button>();
        _helpButton = GameObject.FindGameObjectWithTag("HelpButton").GetComponent<Button>();
    }

    void Start()
    {
        _tutorialOverlay.SetActive(false);

        _helpButton.onClick.AddListener(ToggleTutorial);
        _closeTutorialButton.onClick.AddListener(ToggleTutorial);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            ToggleTutorial();
        }
    }

    void ToggleTutorial()
    {
        _tutorialOverlay.SetActive(!_tutorialOverlay.activeSelf);

        if (_tutorialOverlay.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    
}
