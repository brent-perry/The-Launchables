using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public static int Score;
    public int startScore = 0;

    void Start()
    {
        Score = startScore;
    }

    public void ScoreCounter()
    {
        Score++;
    }
}

