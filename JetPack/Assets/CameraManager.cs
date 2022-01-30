using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Player player;
    public float fieldView = 100;

    //public float offset = -50f;
    // Use this for initialization

    private void Update()
    {
        Camera.main.fieldOfView = fieldView;
    }
    private void LateUpdate()
    {
        transform.position =  new Vector3(player.transform.position.x, player.transform.position.y,-100);
       
    }

}