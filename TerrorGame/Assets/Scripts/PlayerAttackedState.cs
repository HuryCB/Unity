using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackedState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        this.player = player;
        //player.receiveDamageSound.Play();
        //player.npcAnimation.SetTrigger("Attacked");
        Debug.Log("Attacked");
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
        return;
    }
}
