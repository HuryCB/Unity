using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    public Player owner;
    private Animator anim;
    private BoxCollider2D boxCollider;
    public float damage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        damage = 5;
        //owner = GetComponentInParent<Player>();
    }

    public override void UseItem()
    {
        //base.UseItem();
        anim.SetTrigger("Swing");
    }

    private void LateUpdate()
    {
        if (owner != null)
        {
            Vector3 ownerPos = owner.transform.position;
            
           // transform.localPosition = new Vector3 (ownerPos.x * owner.transform.localScale.x, ownerPos.y, ownerPos.z);
            //transform.localScale.x = owner.transform.localScale.x;
            //Debug.Log(owner.transform.localScale.x.ToString());
            //Debug.Log(ownerPos.x.ToString());
            //Debug.Log(ownerPos.x * owner.transform.localScale.x.ToString());
            Debug.Log(transform.position.ToString());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("colliding");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("triggering");
    }
}
