using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2IdleState : Enemy2BaseState
{
    
    public override void EnterState(Enemy2 enemy)
    {
        this.enemy = enemy;
        //Debug.Log("Idle state");
         
    }

    public override void ExitState( )
    {
        return;
    }

    public override void UpdateState( )
    {
        return;
    }
}
