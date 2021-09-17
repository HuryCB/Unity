using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : Npc
{

    private Vector3 moveDelta;
    public Item holding;
    private Rigidbody2D rigidBody;
    //private GameObject parent;
    
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        rigidBody = GetComponent<Rigidbody2D>();
        //parent = GetComponentInParent<>
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.tag == "Enemy")
        {
            
        }
    }
 
    private void Update()
    {
        if(holding != null)
        {
            holding.transform.localPosition = new Vector3(0.16f, 0, 0);
            if (Input.GetMouseButtonDown(0))
            {
                holding.UseItem();
               // Atack();
            }
            
        }
       
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
            //transform.parent.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            //transform.parent.localScale = new Vector3(-1, 1, 1);
        }
        {
           // transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            rigidBody.MovePosition(transform.position + moveDelta * Time.deltaTime * speed);
        }
        {
            //transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }

   

    
}
