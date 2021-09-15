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
    }

    public override void UseItem()
    {
        //base.UseItem();
        anim.SetTrigger("Swing");
    }

    private void Update()
    {
        if (owner != null)
        {
            transform.localPosition = owner.transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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
