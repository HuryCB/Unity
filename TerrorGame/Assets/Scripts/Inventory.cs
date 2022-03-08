using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isFull=false;
    public Item[] slots;
    public Image[] hotbar;
    public Sprite defaultInventorySprite;
    private Player player;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<Player>();
    }

    public void addItem(Item item)
    {
        if (isFull)
        {
            return;
        }
        for(int i = 0; i < slots.Length; i++)
        {
            if(slots[i] == null)
            {
                slots[i] = item;
                hotbar[i].sprite = item.gameObject.GetComponent<Image>().sprite;
                return;
            }
        }
        isFull = true;
    }

    public void dropItem(int slotPos)
    {
        Debug.Log("dropping");
        slots[slotPos] = null;
        hotbar[slotPos].sprite = defaultInventorySprite;
        if (isFull)
        {
            isFull = false;
        }
    }

    public void useItem(int i)
    {
        if(slots[i] == null)
        {
            return;
        }
        slots[i].onUse(player);
        removeItem(i);
    }

    private void removeItem(int i)
    {
        slots[i] = null;
        hotbar[i].sprite = defaultInventorySprite;
        if (isFull)
        {
            isFull = false;
        }
    }
}
