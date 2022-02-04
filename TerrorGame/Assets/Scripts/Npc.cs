//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Npc : MonoBehaviour
//{
//    public HealthBar healthBar;
//    public float currentLife = 100;
//    public float maxLife = 100;
//    public float damage = 0;
//    public float speed = 1.5f;
//    public bool canAttack { get; set; }
//    public bool isAttacking { get; set; }




//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    protected void Update()
//    {
//        healthControl();
//    }

//     public virtual void healthControl()
//    {
//        healthBar.transform.localScale = new Vector3(0.1f, currentLife / maxLife, 1);
//    }
//}
