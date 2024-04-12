using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TigerHealth : MonoBehaviour
{
    public float maxHealth = 100f;

    private float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        // Check if the tiger's health is below or equal to zero
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any death-related actions here
        Destroy(gameObject);
    }
}