using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Structure : MonoBehaviour, Hitable
{
    public DropSystem dropSystem;

    public float maxHealth;
    public float currentHealth;
    public virtual void Die()
    {
        dropSystem.DropLoot();
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
        if (currentHealth <= 0)
        {
            Die();
        }
    }
}
