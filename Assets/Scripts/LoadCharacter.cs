using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    public GameObject[] characterPrefabs;
    public Transform spawnPoint;
    GameObject _selectedCharacterPrefab;


    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("selectedCharacter");
        _selectedCharacterPrefab = characterPrefabs[selectedCharacter];
        Instantiate(_selectedCharacterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
