using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Player owner;
    private Animator anim;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    public override void UseItem()
    {
        //base.UseItem();
        anim.SetTrigger("Swing");    
    }

    private void Update()
    {
        if(owner != null)
        {
            transform.localPosition = owner.transform.position;
        }       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            
            //Destroy(collision.gameObject);
        }
    }
}
