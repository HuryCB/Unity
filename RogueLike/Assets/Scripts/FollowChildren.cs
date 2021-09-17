using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowChildren : MonoBehaviour
{
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponentInChildren<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position;
        player.transform.localPosition = Vector3.zero;
        //
       // transform.localScale = player.transform.localScale;

    }
}
