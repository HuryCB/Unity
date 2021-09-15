using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Bau : Interactable
{
    public Sprite emptyChest;
    public int coins = 10;
    public bool collected = false;

    public override void Start()
    {
        base.Start();
        objectName = "Chest";
    }


    public override void Interact()
    {
        base.Interact();
        collected = true;
        GetComponent<SpriteRenderer>().sprite = emptyChest;
    }

}
