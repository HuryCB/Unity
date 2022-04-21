using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isFull=false;
    public MouseController mouseController;
    public GameObject[] slots;
    public Image[] hotbar;
    public TMP_Text[] quantityTexts;
    public Sprite defaultInventorySprite;
    private Player player;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<Player>();
        mouseController = GameObject.Find("###MouseController###").GetComponent<MouseController>();
    }


    public void AddItemInPos(GameObject item, int i)
    {
        slots[i] = item;
        hotbar[i].sprite = item.gameObject.GetComponent<Item>().sprite;
        quantityTexts[i].text = slots[i].GetComponent<Item>().currentQuantity.ToString();
    }
    public void addItem(GameObject item)
    {
        //Debug.Log(item.currentQuantity);
        //Debug.Log("id do item novo:" + item.id);
        
        var _hasSameType = verifySameObject(item);

        if (_hasSameType)
        {
            //Debug.Log("Mesmo tipo encontrado");
            return;
        }

        if (isFull)
        {
            return;
        }
        var _hasAddedItem = addFirstExemplarOfItem(item);

        if (!_hasAddedItem)
        {
            isFull = true;
        }
        
    }

    private bool addFirstExemplarOfItem(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                slots[i] = item;
                quantityTexts[i].text = slots[i].GetComponent<Item>().currentQuantity.ToString();
                hotbar[i].sprite = item.gameObject.GetComponent<Item>().sprite;
                return true;
            }
        }
        return false;
    }

    private bool verifySameObject(GameObject item)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i] == null)
            {
                continue;
            }
            if (slots[i].GetComponent<Item>().id == item.GetComponent<Item>().id)
            {
                //if(slots[i] == item)
                //{
                //    Debug.Log("o item é o mesmo");
                //}
                //Debug.Log("Encontrou item igual");
                //Debug.Log("id do item atual:"+slots[i].id);
                //Debug.Log("id do item novo:"+item.id);
                slots[i].GetComponent<Item>().addItemQuantityInInventory(item);
                //slots[i].GetComponent<Item>().currentQuantity+= item.GetComponent<Item>().currentQuantity;
                //Debug.Log("Chegou aq");
                //Debug.Log("current " + item.scriptableItem.currentQuantity);
                //slots[i].currentQuantity+= item.scriptableItem.currentQuantity;
                quantityTexts[i].text = slots[i].GetComponent<Item>().currentQuantity.ToString();
                
                return true;
            }
        }
        return false;
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
        Debug.Log("Slot clicado");
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
        slots[i].GetComponent<Item>().onUse(player);
        if(slots[i].GetComponent<Item>().currentQuantity == 0)
        {
            removeItem(i);
            return;
        }
        //slots[i].GetComponent<Item>().currentQuantity--;
        quantityTexts[i].text = slots[i].GetComponent<Item>().currentQuantity.ToString();

    }

    public void removeItem(int i)
    {
        slots[i] = null;
        hotbar[i].sprite = defaultInventorySprite;
        quantityTexts[i].text = "";
        if (isFull)
        {
            isFull = false;
        }
    }
    private void Update()
    {
        
    }
    
}
