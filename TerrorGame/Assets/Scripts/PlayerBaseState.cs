using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{
    protected Player player;

    public abstract void OnTriggerStayState(Collider2D collision);
    public abstract void EnterState(Player player);

    public abstract void UpdateState();

    public abstract void ExitState();

    public abstract void FIxedUpdateState();
}
