using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Enemy : Npc
{
    Player player;
    public int attackDamage = 5;
    
    public string objectName = "Enemy";
  

    public override void Start()
    {
        base.Start();
        objectName = "Enemy";
        player = GameObject.Find("Player").GetComponent<Player>();
        text.SetText(objectName);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Interact();
            HitPlayer();
        }
    }
   

    public void HitPlayer()
    {
        player.Damage(attackDamage);
    }
}
