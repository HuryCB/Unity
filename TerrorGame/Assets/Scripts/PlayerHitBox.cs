using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    public bool canAttack = true;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackOneEnemy(collision);
    }

    private void AttackOneEnemy(Collider2D collision)
    {
        if (!canAttack)
        {
            return;
        }
        if(!collision.tag.Equals("enemy"))
        {
            return;
        }

        Debug.Log("trying");
        Debug.Log(collision.tag);
        if (collision.tag == "enemy")
        {
            Debug.Log("attacking!");
            Enemy2 enemy = collision.gameObject.GetComponent<Enemy2>();
            enemy.TakeDamage(3);
   
        }
        
        canAttack = false;
    }

    public void setCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        AttackOneEnemy(col);
    }
}
