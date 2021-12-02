using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Npc
{
    AudioSource basicSound;
    public GameObject blood;
    private GameObject Player;
    
    public float speed = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        basicSound = GetComponent<AudioSource>();
        Player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);
        healthControl();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "activateBox")
        {
            if (!basicSound.isPlaying)
            {
                basicSound.Play();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>();
            takeDamage(bullet.damage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "bullet")
        {
            Debug.Log("trigger");
        
        }
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
