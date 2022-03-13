using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    public int id;
    public Item hootbar_item;
    public const int MAX_10 = 10;
    public abstract void onUse(Npc2 npc);
    //public abstract Item item();
    //public string name;

}
