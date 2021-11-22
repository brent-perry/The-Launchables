using UnityEngine;

public class CharacterSelect : MonoBehaviour
{
   public GameObject[] characters;
   public static int selectedCharacter = 0;
   public SceneFader sceneFader;

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
       if(selectedCharacter < 0)
       {
           selectedCharacter += characters.Length;
       }
       characters[selectedCharacter].SetActive(true);
   }

   public void SelectCharacter()
   {
       PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
       sceneFader.FadeTo("LevelSelect");
   }
}
