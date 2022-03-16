using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeLeaf : Structure
{
    public Animator choppingAnimation;
    public AudioSource choppingSound;
    //public Item[] drops;


    public override void TakeDamage(float dmg)
    {
        if(currentHealth <= 0)
        {
            return;
        }
        //if (!choppingSound.isPlaying)
        //{
        choppingSound.Play();
        //}
        choppingAnimation.SetTrigger("Chopped");
        currentHealth -= dmg;
        if (currentHealth < 0)
        {
            AudioManager.Instance.TreeFalling();
            choppingAnimation.SetTrigger("Falling");
        }
    }
}
