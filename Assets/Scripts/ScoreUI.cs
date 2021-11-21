using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    TextMeshProUGUI _scoreValueText;

    void Start()
    {
        _scoreValueText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        _scoreValueText.text = $"{PlayerStats.Score}";
    }
}
