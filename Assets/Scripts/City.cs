using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class City : DestroyableProps
{
    private TextMeshProUGUI[] healthText;
    void Start()
    {
        healthText = GetComponentsInChildren<TextMeshProUGUI>();
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
        foreach(TextMeshProUGUI text in healthText)
        {
            text.text = health.ToString();
        }
    }
}
