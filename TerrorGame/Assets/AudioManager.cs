using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;
    public AudioSource catDeathSound;
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
        catDeathSound = GetComponent<AudioSource>();
    }

    public void CatDeathSound()
    {
        catDeathSound.Play();
    }
}
