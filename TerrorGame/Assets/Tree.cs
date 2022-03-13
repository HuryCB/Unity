using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour, Hitable
{
    public float _maxHealth;
    public float _currentHealth;
    public Animator choppingAnimation;
    public AudioSource choppingSound;
    public float MaxHealth { get { return _maxHealth; } set { _maxHealth = value; } }
    public float CurrentHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }
    public void TakeDamage(float dmg)
    {
        //if (!choppingSound.isPlaying)
        //{
        choppingSound.Play();
        //}
        choppingAnimation.SetTrigger("Chopped");
        _currentHealth -= dmg;
        if(_currentHealth < 0)
        {
            AudioManager.Instance.TreeFalling();
            choppingAnimation.SetTrigger("Falling");
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
