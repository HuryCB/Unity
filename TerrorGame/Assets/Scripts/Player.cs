using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Npc2
{
    public Rigidbody2D rb;
    public AudioSource stepSound;
    
    public Animator atk;
    public float lastAttack = 0;
    public float attackCoolDown = 1.5f;

    public bool idle;
    public bool getIdle()
    {
        return this.idle;
    }

    //public Animator npcAnimation;
    public GameObject atkRangeObject;

    public float walkSpeed = 2.0f;
    public float runSpeed = 3.0f;

    public float horizontal;
    public float vertical;
    public int numberOfTargetsAffectedPerAttack = 1;
    
    public PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerAttackedState AttackedState = new PlayerAttackedState();
    public PlayerAttackingState AttackingState = new PlayerAttackingState();
    public PlayerRunningState RunningState = new PlayerRunningState();

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stepSound = GetComponent<AudioSource>();
        currentState = IdleState;
        currentState.EnterState(this);
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        //checkForKeybordInput();

        //checkRun();

        //checkMouseInput();
        currentState.UpdateState();
        
        //healthControl();
    }

    public void checkMouseInput()
    {     
        if (Input.GetMouseButtonDown(0))
        {
            //if (currentState == AttackedState)
            //{
            //    return;
            //}
            SwitchState(AttackingState);
        }
    }

    public void AfterAttacked()
    {
        this.SwitchState(this.IdleState);
    }

    //public void checkForKeybordInput()
    //{
    //    horizontal = Input.GetAxisRaw("Horizontal");
    //    vertical = Input.GetAxisRaw("Vertical");

    //    if (horizontal != 0 || vertical != 0)
    //    {
    //        idle = false;
    //        SwitchState(RunningState);
    //    }
    //    else
    //    {
    //        idle = true;
    //        SwitchState(IdleState);
    //    }
    //}

    public void SwitchState(PlayerBaseState state)
    {
        currentState.ExitState();
        state.EnterState(this);
        currentState = state;
       
    }
  
    private void FixedUpdate()
    {
        currentState.FIxedUpdateState();
        //Move();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        SwitchState(AttackedState);
    }
}
