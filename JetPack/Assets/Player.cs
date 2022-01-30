using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float jumpHigh = 200f;

    Rigidbody2D rb;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (grounded)
            {
                jump();
            }
           
        }
        
        
    }

    private void jump()
    {
         rb.AddForce(new Vector2(0, jumpHigh), ForceMode2D.Force);
        //rb.velocity = new Vector2(rb.velocity.x, 10);
        Debug.Log("Jump");
    }

    private void FixedUpdate()
    {
         rb.AddForce(transform.right*speed);
        //rb.velocity = new Vector2(speed, 0);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground")
        {
            grounded = true;
        }
        
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            grounded = false;
        }
    }
}
