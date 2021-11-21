using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText = FindObjectOfType<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
        // StartCoroutine(AnimateText());
    }

//     IEnumerator AnimateText()
//     {
//         _scoreText.text = "0";
//         int score = 0;

//         yield return new WaitForSeconds(.7f);

//         while (score < PlayerController.Score)
//         {
//             score++;
//             _scoreText.text = PlayerController.Score.ToString();
//             yield return new WaitForSeconds(.05f);
//         }
//     }
}
