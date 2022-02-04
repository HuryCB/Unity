using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigman : Enemy2
{
    // Start is called before the first frame update
    
    new void Start()
    {
        base.Start();
        damage = 13;
    }

    // Update is called once per frame
    new protected void Update()
    {
        base.Update();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //if(collision.tag == "activateBox")
        //{
        //    float distance = Vector3.Distance(Player.transform.position, this.transform.position);
        //    if(distance < 10)
        //    {
        //        Debug.Log("perto");
        //    }
        //}
        
    }
}
