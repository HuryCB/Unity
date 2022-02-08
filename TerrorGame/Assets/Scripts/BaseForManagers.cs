//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class BaseForManagers : MonoBehaviour
//{
//    public BaseForManagers Instance;
//    public void MakeSingleton()
//    {
//        if (Instance != null)
//        {
//            Destroy(gameObject);
//        }
//        else
//        {
//            Instance = this;
//        }
//    }

//    protected void Awake()
//    {
//        MakeSingleton();
//    }
//}
