using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    Player player;
    public int attackDamage = 5;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Interact();
            
        }
    }
    public override void Interact()
    {
        base.Interact();
        player.Damage(attackDamage);
    }
}
