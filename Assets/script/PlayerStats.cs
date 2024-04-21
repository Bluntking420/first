using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    [SerializeField] HealthBar healthBar;
    private void Start()
    {
        InitVariables(100); 
    }
   
    public override void CheckHealth()
    {
        base.CheckHealth();
        healthBar.UpdateHealth(health);
    }
}

