using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    public TextMeshProUGUI ammoText;

    void Start()
    {
        ammoText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        ammoText.text = $"Ammo: {AmmoController.Ammo}";
    }
}
