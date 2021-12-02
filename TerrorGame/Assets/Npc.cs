using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public HealthBar healthBar;
    public float currentLife = 100;
    public float maxLife = 100;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthControl();
    }

     public virtual void healthControl()
    {
        healthBar.transform.localScale = new Vector3(currentLife / maxLife, 1, 1);
    }
}
