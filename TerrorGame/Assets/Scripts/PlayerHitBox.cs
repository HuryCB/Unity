using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitBox : MonoBehaviour
{
    private bool canAttack = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AttackOneEnemy(collision);
        
    }

    private void AttackOneEnemy(Collider2D collision)
    {
        if (!canAttack)
        {
            return;
        }
    
        if (collision.tag == "enemy")
        {
            Enemy2 enemy = collision.gameObject.GetComponent<Enemy2>();
            enemy.TakeDamage(3);
            //Debug.Log("attacking!");
            //Cat cat = collision.gameObject.GetComponent<Cat>();
            //cat.ReceiveDamage();
        }
        
        canAttack = false;
    }

    public void setCanAttack(bool canAttack)
    {
        this.canAttack = canAttack;
    }
    void OnTriggerStay2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "enemy":
                if (Input.GetKey(KeyCode.F))
                {
                    Cat cat = col.gameObject.GetComponent<Cat>();
                    cat.ReceiveDamage();
                    Debug.Log("Gato do Rubens? Morto.");
                    //col.transform.gameObject
                    //Destroy(col.transform.gameObject);

                }
                break;
        }
        //if (col.tag == "door")
        //{
        //    if (Input.GetKey(KeyCode.E))
        //    {
        //        Debug.Log("Oi");
        //        Destroy(col.transform.parent.gameObject);

        //    }
        //}


    }
}
