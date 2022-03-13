using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    public AudioSource catDeathSound;
    public AudioSource backgroundSound;
    public AudioSource tree_falling;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
           Debug.Log("Multiple instances of AudioManager");
           Destroy(this);
        }
      
        backgroundSound.Play();
    }

    public void CatDeathSound()
    {
        catDeathSound.Play();
    }
    public void TreeFalling()
    {
        tree_falling.Play();
    }
}
