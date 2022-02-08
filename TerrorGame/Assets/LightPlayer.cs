using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlayer : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<Player>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Player"))
        {
            return;
        }

        if (!player.getIsLightned())
        {
            player.setIsLightned(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.tag.Equals("Player"))
        {
            return;
        }

        player.setIsLightned(false);
    }
}
