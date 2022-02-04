using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeStateAfterAnimation : MonoBehaviour
{
    public Enemy2 enemy;

    public void ChangeToChasing()
    {
        //Debug.Log("Changing...");
        enemy.SwitchState(enemy.ChasingState);
        
    }
}
