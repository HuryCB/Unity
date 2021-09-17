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
       // anim.SetBool("WillSwing", false);
    }

    private void LateUpdate()
    {
        if (owner != null)
        {
            //PointToMouse();
            Vector3 ownerPos = owner.transform.position;
           // transform.position = ownerPos;
            transform.parent.localScale = new Vector3 (transform.parent.localScale.x , owner.transform.localScale.x, transform.parent.localScale.z);
            
            //transform.parent.localScale = owner.transform.localScale;
            //transform.parent.localPosition.z =
            //Debug.Log(owner.transform.localScale.x.ToString());
            //Debug.Log(ownerPos.x.ToString());
            //Debug.Log(ownerPos.x * owner.transform.localScale.x.ToString());
            //anim.Set

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("colliding");
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Enemy>().Damage(damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("triggering");
    }

    //private void PointToMouse()
    //{
    //    var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
    //    var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    //    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    //}
}
