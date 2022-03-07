using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public float horizontal;
    public float vertical;
    public override void EnterState(Player player)
    {
        this.player = player;
        horizontal = player.horizontal;
        vertical = player.vertical;
       
        player.npcAnimation.SetTrigger("Running");
        //Debug.Log("Running");
        //Debug.Log(horizontal);
        //Debug.Log(player.horizontal);
    }

    public override void ExitState()
    {
        if (!player.stepSound.isPlaying)
        {
            return;
        }
            player.stepSound.Stop();

        player.rb.velocity = new Vector2(0,0);
    }

    public override void FIxedUpdateState()
    {
        Move();
        PlayWalkingSound();
        
    }

    public override void UpdateState()
    {
        //player.npcAnimation.SetTrigger("Running");
        
        //Debug.Log("Update Running");
        checkForKeybordInput();
        checkRun();
        checkMouseInput();
    }

    private void checkIfIdle()
    {
        if (horizontal == 0 && vertical == 0)
        {
            player.SwitchState(player.IdleState);
        }
    }

    public void checkForKeybordInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        checkIfIdle();

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

    private void PlayWalkingSound()
    {
        if (!player.stepSound.isPlaying)
        {
            player.stepSound.Play();
        }
    }

    private void Move()
    {
        // /raiz de 2?
        player.rb.velocity = new Vector2(horizontal * player.speed, vertical * player.speed);
    }

    private void checkRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.speed = player.runSpeed;
            player.stepSound.pitch = player.runSpeed / player.walkSpeed;
        }
        else
        {
            player.speed = player.walkSpeed;
            player.stepSound.pitch = player.walkSpeed / player.walkSpeed;
        }
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
