using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ham : Food
{
    //new public float healthAmount = 2;
    //new public float hungerAmount = 20;
    //new public float sanityAmount = 5;
    public override void onUse(Npc2 npc)
    {
        Debug.Log("usando");
        npc.eat(this);
        Destroy(gameObject);
    }
}
