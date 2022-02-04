
using UnityEngine;

public abstract class Enemy2BaseState
{
    protected Enemy2 enemy;

    public abstract void EnterState(Enemy2 enemy);
 
    public abstract void UpdateState( );
    public abstract void ExitState( );
   
}
