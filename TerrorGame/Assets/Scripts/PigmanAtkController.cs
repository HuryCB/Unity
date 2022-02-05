//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class PigmanAtkController : MonoBehaviour
//{
//    public PigmanHitBox atkRange;
//    public Animator pigAtkMovement;
//    public bool canAttack = true;
//    // Start is called before the first frame update
//    void Start()
//    {
        
//    }

//    // Update is called once per frame
//    void LateUpdate()
//    {
//        EndAttack();
//    }

//    private void EndAttack()
//    {
//        if (this.pigAtkMovement.GetCurrentAnimatorStateInfo(0).IsName("pigman_idle"))
//        {
//            //Debug.Log("idle");
//            atkRange.setCanAttack(true);
//            //atkRange.gameObject.SetActive(false);
//        }
//    }
//}
