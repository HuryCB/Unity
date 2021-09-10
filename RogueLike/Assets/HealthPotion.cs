using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Item
{
    private int heal;

    private void Start()
    {
        transform.localPosition = new Vector3(0.16f, 0, 0);
    }
    public override void UseItem()
    {
        base.UseItem();

    }

    private void Update()
    {
        
    }
}
