using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2ChasingState : Enemy2BaseState
{

    public override void EnterState(Enemy2 enemy)
    {
        this.enemy = enemy;
        //Debug.Log("Chase State");
        enemy.lookAtPlayer.setLookAtPlayer(true);
        enemy.npcAnimation.SetTrigger("Chasing");
    }

    public override void ExitState()
    {
        return;
    }

    public override void UpdateState()
    {
        FollowPlayer();

        TryAttack();
    }

    private void TryAttack()
    {
        float distance = Vector2.Distance(enemy.player.transform.position, enemy.transform.position);

        if((distance < 1 && (Time.time >= enemy.lastAttack + enemy.attackCoolDown))){
            //return;
            enemy.SwitchState(enemy.AttackingState);
        }
        
         
        
        //Debug.Log(distance);
    }

    private void FollowPlayer()
    {
        enemy.transform.position =
            Vector2.MoveTowards(enemy.transform.position,
            enemy.player.transform.position,
            enemy.speed * Time.deltaTime);
    }
}
