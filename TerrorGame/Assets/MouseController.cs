using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public Item holdedItem;
    
    public SpriteRenderer spriteRenderer;
    public int oldPosition;
    public int newPosition;
    public Inventory oldInventory;
    public Inventory newInventory;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    private void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + new Vector3(0f, 0f, 1f);
    }
    public void OnLeftClick(Item item, int position, Inventory inventory)
    {
        if(holdedItem == null)
        {
            if(item == null)
            {
                return;
            }
            inventory.removeItem(position);
            oldInventory = inventory;
            oldPosition = position;
            holdedItem = item;
            this.spriteRenderer.sprite = item.gameObject.GetComponent<SpriteRenderer>().sprite;
            
            return;
        }
        
        if(inventory.slots[position] == null)
        {
            inventory.AddItemInPos(holdedItem, position);
            holdedItem = null;
            spriteRenderer.sprite = null;
            oldInventory = null;
        }

    }
    //public void holdItem(Item item)
    //{
    //    holdedItem = item;
    //}
}
