using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public TextMeshPro text;
    public string objectName;
    public virtual void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Input.GetKey("e"))
            {
                Interact();
            }
            text.SetText("E");
        };
    }

    public virtual void OnCollisionExit2D(Collision2D collision)
    {
        text.SetText(objectName);
    }

    public virtual void Start()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }
    public virtual void Interact()
    {

    }
}
