using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private PlayerHUD hud;

    private void Start()
    {
        hud = GetComponent<PlayerHUD>();
        InitVariables();
        GetReferences();    
    }
    private void GetReferences()
    { 
      hud= GetComponent<PlayerHUD>();
    }
    public override void CheckHealth()
    {
        base.CheckHealth();
        hud.UpdateHealth(health,maxHealth);
    }

}

