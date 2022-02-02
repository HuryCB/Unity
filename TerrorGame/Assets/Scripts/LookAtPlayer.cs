using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public bool lookAtPlayer = false;
    private GameObject player;
    private Vector3 object_pos;
    private Vector3 player_pos;
    private float angle;
    void Start()
    {
        player = GameObject.Find("PlayerBody");
    }

    public void setLookAtPlayer(bool state)
    {
        lookAtPlayer = state;
    }
    // Update is called once per frame
    void Update()
    {
        if (!lookAtPlayer)
        {
            return;
        }
        player_pos = player.transform.position;
        player_pos.z = 5.23F; //The distance between the camera and object
        //object_pos = Camera.main.WorldToScreenPoint(transform.position);
        object_pos = (transform.position);
        player_pos.x = player_pos.x - object_pos.x;
        player_pos.y = player_pos.y - object_pos.y;
        angle = Mathf.Atan2(player_pos.y, player_pos.x) * Mathf.Rad2Deg;
        angle = angle + 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

    }
}
