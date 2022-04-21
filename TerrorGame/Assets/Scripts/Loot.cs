using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public GameObject item;
    public int chance;
    public bool willDrop = false;
    //public int minQuantity;
    //public int maxQuantity;
    public int quantity;

    private void Start()
    {
        WillDrop();
    }
    public void WillDrop()
    {
        if (Random.Range(1, 101) <= chance)
        {
            willDrop = true;
            //Debug.Log("entrou");
        }
    }
}
