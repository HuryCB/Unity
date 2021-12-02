using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;

    public AudioSource stepSound;
    public AudioSource killSound;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        checkKill();

        move();
       
        checkRun();
    }

    private void checkKill()
    {
        if (Input.GetKeyDown("k"))
        {
            killSound.Play();
        }
    }

    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (rb.velocity.x != 0 || rb.velocity.y != 0) 
        {
            idle = false;
            if(rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }
            else{
                transform.localScale = new Vector3(-1,1,1);
            }
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
