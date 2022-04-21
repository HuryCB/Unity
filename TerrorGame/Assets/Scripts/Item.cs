using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    //public ScriptableItem scriptableItem;
    public ItemId id;
    public GameObject hootbar_item;
    //public GameObject itemButton;
    //public const int MAX_10 = 10;
    public ItemType itemType;
    public StackSize stackSize;
    public int currentQuantity = 1;
    public abstract void onUse(Npc2 npc);
    public Sprite sprite;

    public virtual void addItemQuantityInInventory(GameObject newItem)
    {
        this.currentQuantity += newItem.GetComponent<Item>().currentQuantity;
    }
    //public abstract Item item();
    //public string name;

}
