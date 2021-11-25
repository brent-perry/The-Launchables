using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public static int Ammo;
    public int startAmmo = 3;

    void Start()
    {
        Ammo = startAmmo;
    }
    
    public void AmmoCounter()
    {
        Ammo--;
    }
}
