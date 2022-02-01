using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkController : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerHitBox atkRange;
    public Animator handMovement;
    public bool canAttack = true;
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {
        EndAttack();

    }

    private void EndAttack()
    {
        if (this.handMovement.GetCurrentAnimatorStateInfo(0).IsName("Hand_Idle"))
        {
            //Debug.Log("idle");
            atkRange.setCanAttack(true);
            atkRange.gameObject.SetActive(false);
        }
    }
}
