using UnityEngine;

public class AmmoController : MonoBehaviour
{
    public static int Ammo;
    int startAmmo = 3;

    void Start()
    {
        Ammo = startAmmo;
    }
    
    public void AmmoCounter()
    {
        Ammo--;
    }
}
