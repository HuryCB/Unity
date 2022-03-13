using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterAttacking : MonoBehaviour
{
    // Start is called before the first frame update
    public Enemy2 enemy;
    
    public void AfterAttack()
    {
        //enemy.lastAttack = Time.time ;
        //+ enemy.attackCoolDown

        //Debug.Log("Last Attack:"+enemy.lastAttack);
        //Debug.Log("Current time:"+Time.time);
        //Debug.Log("Recarga"+enemy.attackCoolDown);
        //enemy.SwitchState(enemy.ChasingState);
        enemy.AfterAttack();
    }
}
