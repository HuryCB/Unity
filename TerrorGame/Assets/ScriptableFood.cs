using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Food", menuName ="Food")]
public class ScriptableFood : ScriptableItem
{
    public float healthAmount;
    public float sanityAmount;
    public float hungerAmount;


    public override void OnUse(Npc2 npc)
    {
        throw new System.NotImplementedException();
    }

    public void teste()
    {
        Debug.Log("scriptable current quantity: "+currentQuantity);
    }
}
