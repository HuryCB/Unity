using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc2
{
    Rigidbody2D rb;
    
    AudioSource stepSound;
   //new private  HealthBar healthBar;
    float horizontal;
    float vertical;
    public Animator atk;
    public GameObject atkRangeObject;

    public float walkSpeed = 2.0f;
    public float runSpeed = 3.0f;
    //public float speed = 0;
    bool idle = true;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stepSound = GetComponent<AudioSource>();
       // healthBar.transform.localScale = new Vector3(0.1f, (currentLife / maxLife), 1);

    }

    // Update is called once per frame
     new void Update()
    {
        base.Update();
        checkForMove();
       
        checkRun();

        checkMouseInput();
        //healthControl();
    }

    private void checkMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            atk.SetTrigger("atk");
            atkRangeObject.SetActive(true);
            
        }
    }

    private void checkForMove()
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
        Move();
    }

    private void Move()
    {
        // /raiz de 2?
        rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    }

    public void ReceiveDamage(float dmg)
    {
        this.currentLife -= dmg;
       // healthBar.transform.localScale = new Vector3(0.1f, (currentLife / maxLife), 1);

    }
    void OnTriggerStay2D(Collider2D col)
    {
        switch (col.tag)
        {
            case "enemy":
                if (Input.GetKey(KeyCode.F))
                {

                    Cat cat = col.gameObject.GetComponent<Cat>();
                    //cat.ReceiveDamage();
                    Debug.Log("Gato do Rubens? Morto.");
                    //col.transform.gameObject
                    //Destroy(col.transform.gameObject);

                }
                break;
        }
        if (col.tag == "door")
        {
            if (Input.GetKey(KeyCode.E)){
                Debug.Log("Oi");
                Destroy(col.transform.parent.gameObject);
                
            }
        }
    
    }
}
