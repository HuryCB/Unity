using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2AttackedState : Enemy2BaseState
{
    public override void EnterState(Enemy2 enemy)
    {
        this.enemy = enemy;

        enemy.receiveDamageSound.Play();    
        //Debug.Log("Attacked State");
        enemy.npcAnimation.SetTrigger("Attacked");
        
    }

    public override void ExitState()
    {
        return;
    }

    public override void UpdateState()
    {
        return;
    }
}
