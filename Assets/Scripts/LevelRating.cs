using UnityEngine;
using TMPro;

public class LevelRating : MonoBehaviour
{
   public TextMeshProUGUI _scoreText;

   void Start() 
   {
        _scoreText = FindObjectOfType<TextMeshProUGUI>();
   }
}
