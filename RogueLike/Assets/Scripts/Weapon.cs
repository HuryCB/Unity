using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Player owner;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public override void UseItem()
    {
        //base.UseItem();
        anim.SetTrigger("Swing");
       
    }

    private void Update()
    {
        transform.localPosition = new Vector3(0,0,0);
    }
}
