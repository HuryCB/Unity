using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    float horizontal;
    float vertical;
    public GameObject blood;
    Transform bulletPosition;
    Rigidbody2D rb;
    public float speed = 40f;
    public float lifeTime = 5f;
    public float damage = 5;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletPosition = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lifeTime > 0)
        {
            lifeTime -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "activateBox") return;
        
        if(hitInfo.tag == "enemy")
        {
           GameObject enemy = hitInfo.gameObject;
            Instantiate(blood, enemy.transform.position, enemy.transform.rotation);
            
        }

        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "activateBox") return;
        
        if(collision.gameObject.tag == "enemy")
        {
            GameObject enemy = collision.gameObject;
            GameObject bloodCopy = Instantiate(blood);
            bloodCopy.transform.position = enemy.transform.position;
        }
        
        Destroy(gameObject);
        
    }

}
