using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class City : DestroyableProps
{
    private TextMeshProUGUI healthText;
    void Start()
    {
        healthText = GetComponentInChildren<TextMeshProUGUI>();
        UpdateUI();
    }

    private void OnEnable()
    {
        OnDamageTaken.AddListener(UpdateUI);
    }

    private void OnDisable()
    {
        OnDamageTaken.RemoveListener(UpdateUI);
    }

    void UpdateUI()
    {
        healthText.text = health.ToString();
    }
}
