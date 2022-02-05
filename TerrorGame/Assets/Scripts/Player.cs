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
    public float attackCoolDown = 10;
    //public Animator npcAnimation;
    public GameObject atkRangeObject;

    public float walkSpeed = 2.0f;
    public float runSpeed = 3.0f;

    public float horizontal;
    public void setHorizontal(float horizontal)
    {
        this.horizontal = horizontal;
    }
    public float vertical;
    public void setVertical(float vertical)
    {
        this.vertical = vertical;
    }

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
        currentState.UpdateState();
        checkForKeybordInput();

        //checkRun();

        checkMouseInput();
        //healthControl();
    }

    public void checkMouseInput()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            if (currentState == AttackedState)
            {
                return;
            }
            SwitchState(AttackingState);
            

        }
    }

    private void checkForKeybordInput()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        //Debug.Log(horizontal);
        //Debug.Log(vertical);
        //if (rb.velocity.x != 0 || rb.velocity.y != 0)
        //{
        //    idle = false;
        //}
        //else
        //{
        //    idle = true;
        //}

        //if (idle)
        //{
        //    stepSound.Stop();
        //}
        //else
        //{
        //    if (!stepSound.isPlaying)
        //    {
        //        stepSound.Play();
        //    }
        //}
    }

    public void SwitchState(PlayerBaseState state)
    {
        currentState.ExitState();
        currentState = state;
        currentState.EnterState(this);
    }
    //private void checkRun()
    //{
    //    if (Input.GetKey(KeyCode.LeftShift))
    //    {
    //        speed = runSpeed;
    //        stepSound.pitch = runSpeed / walkSpeed;
    //    }
    //    else
    //    {
    //        speed = walkSpeed;
    //        stepSound.pitch = walkSpeed / walkSpeed;
    //    }
    //}
    private void FixedUpdate()
    {
        currentState.FIxedUpdateState();
        //Move();
    }

    //private void Move()
    //{
    //    // /raiz de 2?
    //    rb.velocity = new Vector2(horizontal * speed, vertical * speed);
    //}

    //public void ReceiveDamage(float dmg)
    //{
    //    this.currentLife -= dmg;
    //    // healthBar.transform.localScale = new Vector3(0.1f, (currentLife / maxLife), 1);

    //}
    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        SwitchState(AttackedState);
    }
}
