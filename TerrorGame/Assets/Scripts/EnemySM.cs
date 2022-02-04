//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class EnemySM : StateMachine
//{
//    [HideInInspector]
//    public EnemyIdle idleState;
//    [HideInInspector] 
//    public EnemyMoving movingState;

//    private void Awake()
//    {
//        idleState = new EnemyIdle(this);
//        movingState = new EnemyMoving(this);
//    }

//    protected override BaseState GetInitialState()
//    {
//        return idleState;
//    }
//}