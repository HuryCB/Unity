using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite openChest;
    public Sprite emptyChest;
    public int pesosAmount = 10;
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = openChest;
        }

        if (collected)
        {
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
    
 
    }
}