using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private Player player;
    public bool canAttack = true;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackOneEnemy(collision);
    }

    private void AttackOneEnemy(Collider2D collision)
    {

        if (!canAttack)
        {
            Debug.Log("Cant attack");
            return;
        }
        //if(!collision.tag.Equals("enemy"))
        //{
        //    return;
        //}

        //Debug.Log("trying");
        //Debug.Log(collision.tag);
        if (collision.tag == "enemy")
        {
            Debug.Log("attacking enemy!");
            Enemy2 enemy = collision.gameObject.GetComponent<Enemy2>();
            enemy.TakeDamage(player.damage);
            canAttack = false;
        }
        
        
    }

    public void setCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
   
}
