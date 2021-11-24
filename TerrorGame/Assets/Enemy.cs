using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    AudioSource basicSound;
    // Start is called before the first frame update
    void Start()
    {
        basicSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
