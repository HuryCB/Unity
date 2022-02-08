using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkController : MonoBehaviour
{
    // Start is called before the first frame update
    public Player player;
    public PlayerHitBox atkRange;
    public Animator handMovement;
    //public bool canAttack = true;
    
    public void EndAttackAnimation()
    {
        //Debug.Log("Funcionou");
        
        EndAttack();
        player.SwitchState(player.IdleState);
    }
    private void EndAttack()
    {
        //if (this.handMovement.GetCurrentAnimatorStateInfo(0).IsName("Hand_Idle"))
        //{
        //Debug.Log("finalizadno atk");
            atkRange.setCanAttack(true);
            atkRange.gameObject.SetActive(false);
        //}
    }

    
}
