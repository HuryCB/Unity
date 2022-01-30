using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private Vector3 mouse_pos;
    private Vector3 object_pos;
    private float angle;

    //var mouse_pos : Vector3;
    // var target : Transform; //Assign to the object you want to rotate
    //var object_pos : Vector3;
    //var angle : float;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //var dir = Input.mousePosition - Camera.main.WorldToScreenPoint(player.transform.position);
        //var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        // transform.LookAt(Input.mousePosition, Vector3.up);

        mouse_pos = Input.mousePosition;
        mouse_pos.z = 5.23F; //The distance between the camera and object
        object_pos = Camera.main.WorldToScreenPoint(transform.position);
        mouse_pos.x = mouse_pos.x - object_pos.x;
        mouse_pos.y = mouse_pos.y - object_pos.y;
        angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
        angle = angle - 90;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    
}
