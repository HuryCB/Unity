using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc2 : MonoBehaviour
{
    public HealthBar healthBar;
    public float currentLife = 100;
    public float maxLife = 100;
    public float damage = 0;
    public float speed = 1.5f;
    public bool isFollowing = false; 
    public bool canAttack = false;
    public bool wasAttacked;
    public float timeToNormalizeBehaviour;
    public Animator npcAnimation;
    public AudioSource receiveDamageSound;

    //public virtual void setWasAttacked(bool wasAttacked)
    //{
    //    wasAttacked = true;
    //}
    void Start()
    {
        healthControl();
    }


    //public void Update()
    //{
    //    healthControl();
    //}

    public virtual void TakeDamage(float dmg)
    {
        //npcAnimation.SetTrigger("TakeDamage");
        this.currentLife -= dmg;
        //setWasAttacked(true);
        healthControl();
    }

    public void Heal(float healAmount)
    {
        if(this.currentLife + healAmount > maxLife)
        {
            this.currentLife = maxLife;
        }
        else
        {
            this.currentLife += healAmount;
        }
    }
    private void healthControl()
    {
        if(this.currentLife < 0)
        {
            Die();
        }
        healthBar.transform.localScale = new Vector3(0.1f, currentLife / maxLife, 1);
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
