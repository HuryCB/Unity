using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : Npc2
{
    protected GameObject player;
    public GameObject atkRange;
    public LookAtPlayer lookAtPlayer;
    public bool isAttacking = false;
    public float lastAttack;
    public float attackCoolDown;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerBody");
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        if (!isFollowing)
        {
            return;
        }
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

    }

    public override void setWasAttacked(bool wasAttacked)
    {
        wasAttacked = true;
        AttackBehaviour();
    }

    private void AttackBehaviour()
    {
        isFollowing = true;
        lookAtPlayer.setLookAtPlayer(true);
    }
}
