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
    public BoxCollider2D boxCollider2D;
    private bool isLightned = false;
    public Animator atk;
    public float lastAttack = 0;
    public float attackCoolDown = 1.5f;
    public GameObject closestItem;
    public Inventory inventory;
    
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

    private void OnTriggerStay2D(Collider2D collision)
    {
        currentState.OnTriggerStayState(collision);
        if (collision.CompareTag("item"))
        {
            if (closestItem == null)
            {
                closestItem = collision.gameObject;
            }
        }
    }

    

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        
        //checkForKeybordInput();

        //checkRun();

        //checkMouseInput();
        currentState.UpdateState();
        pickItem();
        useHootBarItem();

        //healthControl();
    }

    private void useHootBarItem()
    {
        if (Input.GetKeyDown("1"))
        {
            inventory.useItem(0);
        }
        if (Input.GetKeyDown("2"))
        {
            inventory.useItem(1);
        }
        if (Input.GetKeyDown("3"))
        {
            inventory.useItem(2);
        }
        if (Input.GetKeyDown("4"))
        {
            inventory.useItem(3);
        }
        if (Input.GetKeyDown("5"))
        {
            inventory.useItem(4);
        }
        if (Input.GetKeyDown("6"))
        {
            inventory.useItem(5);
        }
        if (Input.GetKeyDown("7"))
        {
            inventory.useItem(6);
        }
        if (Input.GetKeyDown("8"))
        {
            inventory.useItem(7);
        }
        if (Input.GetKeyDown("9"))
        {
            inventory.useItem(8);
        }
        if (Input.GetKeyDown("0"))
        {
            inventory.useItem(9);
        }
    }

    //private void useItem(int i)
    //{
    //    if(inventory.slots[i] == null)
    //    {
    //        return;
    //    }
    //    inventory.slots[i].onUse(this);
    //    inventory.re
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("item"))
        {
            if (closestItem == collision.gameObject)
            {
                closestItem = null;
            }
        }
    }
    
    private void pickItem()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (closestItem == null)
            {
                return;
            }
            //Debug.Log("Quantidade do item: " + closestItem.currentQuantity);
            //Debug.Log("Quantidade do prefab: " + closestItem.hootbar_item.currentQuantity);

            inventory.addItem(Instantiate(closestItem.GetComponent<Item>().hootbar_item));
            Destroy(closestItem.gameObject);
            closestItem = null;
        }
    }

    public override void eat(Food food)
    {
        this.currentHunger += food.hungerAmount;
        this.currentLife += food.healthAmount;
        this.currentSanity += food.sanityAmount;
        if (this.currentHunger + food.hungerAmount > maxHunger)
        {
            this.currentHunger = maxHunger;
        }
        if (this.currentLife + food.healthAmount > maxLife)
        {
            this.currentLife = maxLife;
        }
        if (this.currentSanity + food.sanityAmount > maxSanity)
        {
            this.currentSanity = maxSanity;
        }

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
        //return se tiver sendo iluminado
        if (this.getIsLightned())
        {
            return;
        }

        //retorna se n for de noite
        if (!GameManager.Instance.dayManager.isNight)
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
        loseSanity(GameManager.Instance.darknessSanityPenalty);
        timeInDarkness = 0;
    }

    private void loseSanity(float darknessSanityPenalty)
    {
        this.currentSanity -= darknessSanityPenalty;
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
