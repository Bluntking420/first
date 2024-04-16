using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Health : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private Image RedSplatterImage = null;
    
    
    private AudioClip HurtAudio=null;
    private AudioSource HealthAudioSource;
    public int RegenRate =1;
    private bool CanRegen=false;
    private float HealCooldown=3.0f;
    private float MaxHealCooldown = 3.0f;
    private bool StartCooldown=false;


    private void Start()
    {
        HealthAudioSource = GetComponent<AudioSource>();
    }


    void UpdateHealth()
    { 
    
     Color splatterAlpha=RedSplatterImage.color;
        splatterAlpha.a = 1 - (currentHealth / maxHealth);
        RedSplatterImage.color = splatterAlpha;
    }
    public void TakeDamage()
    {
        if (currentHealth >= 0)
        {
           CanRegen = false;
            UpdateHealth();
            HealCooldown = MaxHealCooldown;
            StartCooldown = true;
        
        }
    
    }
    private void Update()
    {
        if (StartCooldown)
        {
            HealCooldown -= Time.deltaTime;
            if (HealCooldown <= 0)
            {
                CanRegen = true;
                StartCooldown = false;
            } 
        }
        if (CanRegen)
        {
            if (currentHealth <= maxHealth - 0.01f)
            {
                currentHealth += Time.deltaTime * RegenRate;
                UpdateHealth();
            }
            else
            {
                currentHealth = maxHealth;
                HealCooldown = MaxHealCooldown;
                CanRegen=false;
            }
        }
    }








}
