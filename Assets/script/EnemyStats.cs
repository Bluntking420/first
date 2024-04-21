using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    [SerializeField] public int Damage;
    [SerializeField] public float AttackSpeed;
    [SerializeField] private bool canAttack;




    // Start is called before the first frame update
    void Start()
    {
        InitVariables(40);
        Damage = 10;
        AttackSpeed = 2;
        canAttack = true;
    }
    public void TakeEnemyDamage(int damage)
    {
        health -= damage;
        SetHealthTo(health);
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
    // Update is called once per frame

}
