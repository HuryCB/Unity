using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonKill : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource killSound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Kill()
    {
        killSound.Play();
    }
}
