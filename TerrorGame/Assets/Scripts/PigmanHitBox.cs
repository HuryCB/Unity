using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigmanHitBox : MonoBehaviour
{
    private bool canAttack = true;
    public Pigman pig;
    public Animator pigAttack;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //AttackOneEnemy(collision);
        AttackPlayer(collision);
    }

    private void AttackPlayer(Collider2D collision)
    {
        if (!canAttack)
        {
            return;
        }

        if(collision.tag == "Player")
        {
            pigAttack.SetTrigger("Attack");
            Player player = collision.gameObject.GetComponent<Player>();

            player.ReceiveDamage(pig.damage);
            //Debug.Log("machucando");
        }

        canAttack = false;
    }
    public void setCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
}
