using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreValueText;

    void Start()
    {
        scoreValueText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreValueText.text = $"{ScoreController.Score}";
    }
}
