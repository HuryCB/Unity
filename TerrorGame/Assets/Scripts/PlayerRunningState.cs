using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunningState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        this.player = player;
        Debug.Log("Running");
    }

    public override void ExitState()
    {
        return;
    }

    public override void FIxedUpdateState()
    {
        Move();
        return;
    }

    public override void UpdateState()
    {
        
        PlayWalkingSound();
        checkRun();
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
        player.rb.velocity = new Vector2(player.horizontal * player.speed, player.vertical * player.speed);
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
}
