using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham : Food
{
    public ScriptableFood scriptableFood;
    private void Start()
    {
        id = ItemId.Ham;
    }
    //new public float healthAmount = 2;
    //new public float hungerAmount = 20;
    //new public float sanityAmount = 5;
    public override void onUse(Npc2 npc)
    {
        currentQuantity--;
        Debug.Log("usando");
        npc.eat(this);
        scriptableFood.teste();
        //Destroy(this.gameObject);
    }

    //public override Item item()
    //{
    //    return new Ham();
    //    this.remove
    //}
    //public void playerEat()
    //{
    //    Player player = GameObject.Find("PlayerBody").GetComponent<Player>();
    //    player.eat(this);
    //    Destroy(this.gameObject);
    //}
}
