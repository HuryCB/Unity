using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    public AudioSource basicSound;
    //public GameObject blood;
    protected GameObject Player;
    protected bool following;
    

   
    // Start is called before the first frame update
     protected void Start()
    {
        //basicSound = GetComponent<AudioSource>();
        Player = GameObject.Find("PlayerBody");
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
        FollowPlayer();
        //healthControl();
    }

    private void FollowPlayer()
    {
        if (!following)
        {
            return;
        }

        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
    }

    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "activateBox")
        {
            if (!basicSound.isPlaying)
            {
                basicSound.Play();
                Debug.Log("tocando");
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
     
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        
    }

    private void takeDamage(float damage)
    {
        currentLife -= damage;
    }

    public override void healthControl()
    {
        base.healthControl();
        if(currentLife <= 0)
        {
            Destroy(gameObject);
        }
    }
}
