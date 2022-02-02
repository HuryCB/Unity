using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcHitBox : MonoBehaviour
{
    //private bool canAttack = true;
    public Npc npc;
    public Animator npcAttack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackPlayer(collision);
    }

    private void AttackPlayer(Collider2D collision)
    {
        if (!npc.canAttack)
        {
            return;
        }

        if (collision.tag == "Player")
        {
            npcAttack.SetTrigger("Attack");
            npc.isAttacking = true;
            Player player = collision.gameObject.GetComponent<Player>();

            player.ReceiveDamage(npc.damage);
            //Debug.Log("machucando");
        }

        npc.canAttack = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
    }
    //public void setCanAttack(bool canAttack)
    //{
    //    this.canAttack = canAttack;
    //}
}
