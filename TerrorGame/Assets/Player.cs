using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;

    public float walkSpeed = 2.0f;
    public float runSpeed = 4.0f;
    public float speed = 0;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        checkRun();
       
    }

    private void checkRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }
    }
    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * speed, vertical * speed);
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
