using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Score;
    public int startScore = 0;
    public static int Ammo;
    public int startAmmo = 3;

    void Start()
    {
        Score = startScore;
        Ammo = startAmmo;
    }

    public void ScoreCounter()
    {
        Score++;
    }
    public void AmmoCounter()
    {
        Ammo--;
    }
}
