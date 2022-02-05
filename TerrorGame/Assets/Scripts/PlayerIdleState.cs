using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    
    //bool idle = true;
    public override void EnterState(Player player)
    {
        this.player = player;
        Debug.Log("Idle");
    }

    public override void ExitState()
    {
        return;
    }

    public override void FIxedUpdateState()
    {
        return;
    }

    public override void UpdateState()
    {
        checkForMove();
    }

    private void checkForMove()
    {

        if (player.horizontal != 0 || player.vertical != 0)
        {
            player.SwitchState(player.RunningState);
        }
    }
    //private void checkForMove()
    //{
    //    player.horizontal = Input.GetAxisRaw("Horizontal");
    //    player.vertical = Input.GetAxisRaw("Vertical");

    //    if (player.horizontal != 0 || player.vertical != 0)
    //    {
    //        player.SwitchState(player.RunningState);
    //    }
    //    else
    //    {
    //        idle = true;
    //    }

    //    if (idle)
    //    {
    //        player.stepSound.Stop();
    //    }
    //    else
    //    {

    //    }
    //}
}
