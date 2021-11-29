using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    TextMeshProUGUI _ammoText;

    void Start()
    {
        _ammoText = GameObject.FindGameObjectWithTag("AmmoText").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        _ammoText.text = $"Ammo: {AmmoController.Ammo}";
    }
}
