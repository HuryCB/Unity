using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackingState : PlayerBaseState
{
    public override void EnterState(Player player)
    {
        //Debug.Log("Attacking");
        this.player = player;
        player.npcAnimation.SetTrigger("Attacking");
        player.atk.SetTrigger("atk");
        player.atkRangeObject.SetActive(true);
       
    }

    public override void ExitState()
    {
        player.npcAnimation.ResetTrigger("Attacking");
        player.atkRangeObject.SetActive(false);
    }

    public override void FIxedUpdateState()
    {
        return;
    }

    public override void OnTriggerStayState(Collider2D collision)
    {
        return;
    }

    public override void UpdateState()
    {
        return;
    }
}
