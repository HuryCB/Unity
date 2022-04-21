using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Food : Item
{
    public float healthAmount;
    public float sanityAmount;
    public float hungerAmount;
    public float minuteToSpoil;

    public override void addItemQuantityInInventory(GameObject newItem)
    {
        Food itemCP = newItem.GetComponent<Food>();
        this.currentQuantity += itemCP.currentQuantity;
        this.minuteToSpoil = (minuteToSpoil + itemCP.minuteToSpoil) / currentQuantity;
        Destroy(newItem);
    }

    private void Update()
    {
        minuteToSpoil -= Time.deltaTime / 60;
    }
}
