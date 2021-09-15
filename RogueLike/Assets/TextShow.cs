using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextShow : MonoBehaviour
{
    private TextMeshPro text;
    
    private void Start()
    {
        text = GetComponent<TextMeshPro>();
        
    }

    private void Update()
    {
        transform.localScale = transform.localScale;
    }

}
