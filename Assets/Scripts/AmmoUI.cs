using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    TextMeshProUGUI _ammoText;

    void Start()
    {
        _ammoText = FindObjectOfType<TextMeshProUGUI>();
    }

    void Update()
    {
        _ammoText.text = $"Ammo: {PlayerController.Ammo}";
    }
}
