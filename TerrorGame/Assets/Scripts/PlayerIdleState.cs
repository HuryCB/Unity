using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public float horizontal;
    public float vertical;
    //bool idle = true;
    public override void EnterState(Player player)
    {
        this.player = player;
        player.npcAnimation.SetTrigger("Idle");
        //Debug.Log("Idle");
    }

    public override void ExitState()
    {
        player.npcAnimation.ResetTrigger("Idle");
    }

    public override void FIxedUpdateState()
    {
        return;
    }

    public override void UpdateState()
    {
        //Debug.Log("Update Idle");
        checkForKeybordInput();
        checkMouseInput();
    }

    private void checkForMove()
    {

        if (horizontal != 0 || vertical != 0)
        {
            player.SwitchState(player.RunningState);
        }
    }

    public void checkForKeybordInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        player.horizontal = horizontal;
        player.vertical = vertical;
        checkForMove();
        //if (horizontal != 0 || vertical != 0)
        //{
        //    idle = false;
        //    SwitchState(RunningState);
        //}
        //else
        //{
        //    idle = true;
        //    SwitchState(IdleState);
        //}
    }

    public void checkMouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //if (currentState == AttackedState)
            //{
            //    return;
            //}
            player.SwitchState(player.AttackingState);
        }
    }

    public override void OnTriggerStayState(Collider2D collision)
    {
        //player.pickItem(collision);
        return;
    }
}
