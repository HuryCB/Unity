using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public TreeLeaf treeLeaf;
    public TreeRoot treeRoot;


    private void Update()
    {
        if (treeRoot == null)
        {
            Destroy(gameObject);
            return;
        }
        if(treeLeaf == null)
        {
            treeRoot.gameObject.tag = "hitable";
        }
    }
}
