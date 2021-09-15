using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Interactable
{
    private int heal = 10;
    Player player;
    // public Player owner;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        // player = gameObject.GetComponent<Player>();
    }
    public override void Interact()
    {
        base.Interact();
        player.Heal(heal);
        Destroy(gameObject);
        Debug.Log("funciona");
    }
}
