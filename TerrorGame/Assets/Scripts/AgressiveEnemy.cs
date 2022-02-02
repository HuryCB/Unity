using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgressiveEnemy : Enemy
{
    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "activateBox")
        {
            following = true;
            Debug.Log("following");
        }
    }
}
