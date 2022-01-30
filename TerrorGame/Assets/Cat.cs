using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    private AudioSource deathSound;
    public GameObject meat;
    // Start is called before the first frame update
    void Start()
    {
        deathSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void ReceiveDamage()
    {
        //AudioSource(deathSound, transform.position);
        //Invoke("Destroy(this)", 0.5f);
        AudioManager.Instance.CatDeathSound();
        Instantiate(meat, transform.position, transform.rotation);
        Destroy(gameObject);
    }
  

}
