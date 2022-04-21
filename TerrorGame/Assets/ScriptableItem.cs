using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableItem : ScriptableObject
{
    public ItemId id;
    public const int MAX_10 = 10;
    public ItemType itemType;
    public StackSize stackSize;
    public int currentQuantity = 1;
    public Sprite sprite;
    public abstract void OnUse(Npc2 npc);
}
