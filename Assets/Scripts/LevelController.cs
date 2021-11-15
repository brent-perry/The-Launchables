using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;
    Enemy[] _enemies;
    void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>();
    }

    void Update()
    {
        if (EnemiesAreAllDead())
        {
            GoToNextLevel();
        }
    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(_nextLevelName);
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
