using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc
{
    Rigidbody2D rb;
    
    AudioSource stepSound;
    float horizontal;
    float vertical;

    public float walkSpeed = 2.0f;
    public float runSpeed = 3.0f;
    public float speed = 0;
    bool idle = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stepSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        move();
       
        checkRun();

       
    }

   

    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        if (rb.velocity.x != 0 || rb.velocity.y != 0) 
        {
            idle = false;
        }
        else
        {
            idle = true;
        }

        if (idle)
        {
            stepSound.Stop();
        }
        else
        {
            if (!stepSound.isPlaying)
            {
                stepSound.Play();
            }
        }
    }

    private void checkRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
            stepSound.pitch = runSpeed / walkSpeed;
        }
        else
        {
            speed = walkSpeed;
            stepSound.pitch = walkSpeed / walkSpeed;
        }
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "door")
        {
            if (Input.GetKey(KeyCode.E)){
                Debug.Log("Oi");
                Destroy(col.transform.parent.gameObject);
                
            }
        }
    }
}
