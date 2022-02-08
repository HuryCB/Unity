using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Npc2
{
    public float maxHunger = 150;
    public float currentHunger = 150;
    public float defaultHungerConsumption = 9;
    public float hungerConsumptionRate = 1;
    public float maxSanity = 200;
    public float currentSanity = 200;
    public float sanityConsumptionRate = 1;
    public float defaultSanityConsumption = 1;
    public Rigidbody2D rb;
    public AudioSource stepSound;
    private bool isLightned = false;
    public Animator atk;
    public float lastAttack = 0;
    public float attackCoolDown = 1.5f;
    
    //public bool idle;

    public GameObject atkRangeObject;

    public float walkSpeed = 2.0f;
    public float runSpeed = 3.0f;

    public float horizontal;
    public float vertical;
    public int numberOfTargetsAffectedPerAttack = 1;
    public float timeInDarkness = 0;

    //public Image healthStatus;
    
    public PlayerBaseState currentState;
    public PlayerIdleState IdleState = new PlayerIdleState();
    public PlayerAttackedState AttackedState = new PlayerAttackedState();
    public PlayerAttackingState AttackingState = new PlayerAttackingState();
    public PlayerRunningState RunningState = new PlayerRunningState();

    public bool getIsLightned()
    {
        return isLightned;
    }

    public void setIsLightned(bool isLightned)
    {
        this.isLightned = isLightned;
        if (isLightned)
        {
            timeInDarkness = 0;
        }
    }
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

    private void hungerControl()
    {
        currentHunger -= defaultHungerConsumption * hungerConsumptionRate * Time.deltaTime / 60;
    }

    private void sanityControl()
    {
        //throw new NotImplementedException();
    }

    private void checkForDarknessDamage()
    {
        
        if (this.getIsLightned())
        {
            return;
        }

        this.timeInDarkness += Time.deltaTime;

        if (this.timeInDarkness > GameManager.Instance.timeToDarknessAtk)
        {
            getHitByDarknessDamage();
        }
    }

    private void getHitByDarknessDamage()
    {
        TakeDamage(GameManager.Instance.darknessDamage);
        timeInDarkness = 0;
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
        sanityControl();
        hungerControl();
        checkForDarknessDamage();
        currentState.FIxedUpdateState();
        //Move();
    }

    public override void TakeDamage(float dmg)
    {
        base.TakeDamage(dmg);
        SwitchState(AttackedState);
    }
}
