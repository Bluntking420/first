using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    private float currHealth, maxHealth;
    [SerializeField] private Image fill;
    [SerializeField] private TMP_Text amount;

    public void SetValues(float maxHealth)
    {
        this.maxHealth = maxHealth;

        currHealth = maxHealth;

        UpdateHealth(currHealth);
    }

    public void UpdateHealth(float _health)
    {
        var health = _health / maxHealth;

        fill.fillAmount = health;
        amount.text = _health.ToString();
    }
}
