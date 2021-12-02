using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //adiciona 2.5 ao vértice Y
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y +(float)2.5,player.transform.position.z);
        
    }
}
