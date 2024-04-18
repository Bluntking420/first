using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField]public int Damage;
    [SerializeField]public float AttackSpeed;
    [SerializeField] private bool canAttack;

  


    // Start is called before the first frame update
    void Start()
    {
        InitVariables();
    }
    public void DealDamage(CharacterStats statsToDamage)
    {
        statsToDamage.TakeDamage(Damage);
    }
    public override void Die()
    {
        Destroy(gameObject);
        base.Die();
    }
    public override void InitVariables()
    {
        maxHealth = 40;
        SetHealthTo(maxHealth);
        isDead = false;
        Damage = 10;
        AttackSpeed = 2;
        canAttack = true;
    }
    // Update is called once per frame
  
}
