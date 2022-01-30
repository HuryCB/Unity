using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    AudioSource shotSound;
    Transform shotPoint;
    public GameObject bulletPrefab;
    public float reloadTime = 0.5f;
    public float lastTimeShot = 0f;

    //public float bulletForce = 20f;
    //public float bulletSpeed = 10f;
    // public Rigidbody bullet;
    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
        shotPoint = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastTimeShot < reloadTime)
        {
            lastTimeShot += Time.deltaTime;
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                fire();
            }
        }
        
        
    }

    private void fire()
    {
        shotSound.Play();
        Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
        lastTimeShot = 0;

    }
}
