using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PlayerHUD : MonoBehaviour
{
  [SerializeField]  private HealthBar healthBar;
   

    public void UpdateHealth(int currentHealth,int maxHealth)
    { 
      healthBar.SetValues(currentHealth,maxHealth);
    }


}
