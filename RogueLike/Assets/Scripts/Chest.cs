using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public Sprite emptyChest;
    public int coins = 10;
    //public GameObject floatingText;
   // public float lastShown = 0;
    protected override void OnCollect()
    {
        if (!collected)
        {
            // if(lastShown < Time.time)

            // GameManager.instance.ShowText("E", transform.position);
           // GameObject texto = Instantiate(floatingText, transform.position, Quaternion.identity);
            //  
            
            if (Input.GetKeyDown(KeyCode.E))
            {
                OpenChest();
            }
               
            
        }else if (collected)
        {
            GetComponent<SpriteRenderer>().sprite = emptyChest;
        }
        
        
    }
    
    protected void OpenChest()
    {
        collected = true;
    }
}
