using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalScale : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 startScale;
    private void Start()
    {
        startScale = transform.localScale;
    }
    void LateUpdate()
    {
        float parentX = transform.parent.localScale.x;
        if (parentX < 1)
        {
            transform.localScale = new Vector3(startScale.x*-1, startScale.y, startScale.z);
        }
        else
        {
            transform.localScale = new Vector3(startScale.x, startScale.y, startScale.z);
        }

        //Debug.Log(parentX.ToString());
    }
}
