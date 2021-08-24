
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float ForwardForce = 2000f;
    public float SideWayForce = 500f;
    // Start is called before the first frame update
    

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.AddForce(0, 0, ForwardForce * Time.deltaTime);

        if (Input.GetKey("d"))
        {
            rb.AddForce(SideWayForce * Time.deltaTime,0,0);
        }
        if (Input.GetKey("a"))
        {
            rb.AddForce(-SideWayForce * Time.deltaTime, 0, 0);
        }
        if(rb.position.y < -1f)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
