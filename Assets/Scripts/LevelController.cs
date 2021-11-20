using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    GameManager gameManager;
    Enemy[] _enemies;

    void Start() 
    {
        gameManager = GetComponent<GameManager>();
    }
    void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        if (EnemiesAreAllDead())
        {
            gameManager.NextLevelOverlay();
        }
    }

    bool EnemiesAreAllDead()
    {
        foreach (var enemy in _enemies)
        {
            //checks if all enemies are dead and returns if they are still there (null means all enemies are no longer in the level)
            if (enemy.gameObject.activeSelf)
            {
                return false;
            }
        }
        return true;

    }



}
