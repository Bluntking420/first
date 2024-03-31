using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   public float maxHealth;
        public float currentHealth;
    public ragdoll Ragdoll;
   
    void Start()
    {
        Ragdoll = GetComponent<ragdoll>();  
        currentHealth = maxHealth;
        var Rigidbodies=GetComponentsInChildren<Rigidbody>();
        foreach (var rigidbody in Rigidbodies)
        {
            Hitbox hitbox =rigidbody.gameObject.AddComponent<Hitbox>();
            hitbox.health = this;
        }
    }

    public void TakeDamage(float amount, Vector3 direction)
    { 
      currentHealth -= amount;
        if (currentHealth <= 0.0f)
        {
            Die();
        }
    }
    private void Die()
    { 
     Ragdoll.ActivateRagdoll();
    }

}


