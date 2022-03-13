using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface  Hitable 
{

    

    float MaxHealth { get; set; }
    float CurrentHealth { get; set; }

    public void TakeDamage(float dmg);
}
