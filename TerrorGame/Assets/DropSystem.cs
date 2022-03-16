using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSystem : MonoBehaviour
{
    public Loot[] lootList;
    public void DropLoot()
    {
        foreach (Loot item in lootList)
        {
            if (!item.willDrop)
            {
                return;
            }

            for (int i = 0; i < item.quantity; i++)
            {
                var _x = UnityEngine.Random.Range(-0.15f, 0.15f);
                var _y = UnityEngine.Random.Range(-0.15f, 0.15f);
                Instantiate(item.item, new Vector3(transform.position.x + (_x), transform.position.y + (_y), transform.position.z), Quaternion.identity);

            }
        }
    }
}
