using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Npc2
{
    public GameObject player;
    public GameObject atkRange;
    public LookAtPlayer lookAtPlayer;
    public bool isAttacking = false;
    public float lastAttack = 0;
    public float attackCoolDown = 10;

    public Enemy2BaseState currentState;
    public Enemy2ChasingState ChasingState = new Enemy2ChasingState();
    public Enemy2IdleState IdleState = new Enemy2IdleState();
    public Enemy2AttackingState AttackingState = new Enemy2AttackingState();
    public Enemy2AttackedState AttackedState = new Enemy2AttackedState();
    protected void Start()
    {
        player = GameObject.Find("PlayerBody");
        currentState = IdleState;
       

        currentState.EnterState(this);
    }

    protected void Update()
    {
        //base.Update();
        currentState.UpdateState();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        SwitchState(AttackedState);
    }
    public void SwitchState(Enemy2BaseState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState(this);
    }

    //public void ChangeToChasing()
    //{
    //    SwitchState(ChasingState);
    //}

    
    //private void FollowPlayer()
    //{
    //    if (!isFollowing)
    //    {
    //        return;
    //    }
    //    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    //}

    //public override void setWasAttacked(bool wasAttacked)
    //{
    //    wasAttacked = true;
    //    AttackBehaviour();
    //}

    //private void AttackBehaviour()
    //{
    //    isFollowing = true;
    //    lookAtPlayer.setLookAtPlayer(true);
    //}
}
