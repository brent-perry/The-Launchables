using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    CompleteLevel _completeLevel;
    Enemy[] _enemies;

    void Start()
    {
       _completeLevel = FindObjectOfType<CompleteLevel>();
    }

    void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        if (EnemiesAreAllDead())
        {
            _completeLevel.WinLevel();
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
