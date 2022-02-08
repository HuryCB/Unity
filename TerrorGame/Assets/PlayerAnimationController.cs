using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public Player player;

    //public void SwitchToIdle()
    //{
    //    player.SwitchState(player.IdleState);
    //}
    public void AfterAttacked()
    {
        player.AfterAttacked();
    }
}
