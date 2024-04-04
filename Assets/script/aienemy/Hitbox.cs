using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Health health;


    public void OnRaycastHit(Gunshoot weapon,Vector3 direction)
    {
        health.TakeDamage(weapon.Damage,direction);
    }
}
