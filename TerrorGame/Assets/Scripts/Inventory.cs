using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isFull=false;
    public MouseController mouseController;
    public Item[] slots;
    public Image[] hotbar;
    public Sprite defaultInventorySprite;
    private Player player;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<Player>();
        mouseController = GameObject.Find("###MouseController###").GetComponent<MouseController>();
    }

    public void AddItemInPos(Item item, int i)
    {
        slots[i] = item;
        hotbar[i].sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
        
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
                hotbar[i].sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
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

    public void OnLeftClick(int pos)
    {
        //if (slots[pos] == null)
        //{
        //    return;
        //}
        mouseController.OnLeftClick(slots[pos], pos, this);
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

    public void removeItem(int i)
    {
        slots[i] = null;
        hotbar[i].sprite = defaultInventorySprite;
        if (isFull)
        {
            isFull = false;
        }
    }
    private void Update()
    {
        useHootBarItem();
    }
    private void useHootBarItem()
    {
        if (Input.GetKeyDown("1"))
        {
            useItem(0);
        }
        if (Input.GetKeyDown("2"))
        {
            useItem(1);
        }
        if (Input.GetKeyDown("3"))
        {
            useItem(2);
        }
        if (Input.GetKeyDown("4"))
        {
            useItem(3);
        }
        if (Input.GetKeyDown("5"))
        {
            useItem(4);
        }
        if (Input.GetKeyDown("6"))
        {
            useItem(5);
        }
        if (Input.GetKeyDown("7"))
        {
            useItem(6);
        }
        if (Input.GetKeyDown("8"))
        {
            useItem(7);
        }
        if (Input.GetKeyDown("9"))
        {
            useItem(8);
        }
        if (Input.GetKeyDown("0"))
        {
            useItem(9);
        }
    }
}
