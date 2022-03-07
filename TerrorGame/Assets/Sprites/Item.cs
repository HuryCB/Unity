using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int id;
    public abstract void onUse(Npc2 npc);
    //public string name;

}
