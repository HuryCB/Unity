using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public float darknessDamage = 100;
    public float darknessSanityPenalty = 20;
    public float timeToDarknessAtk = 6;
    public DayManager dayManager;


    private void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Awake()
    {
        MakeSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    public bool sorteiaPorcentagem(float n)
    {

        return true;
    }

    
}
