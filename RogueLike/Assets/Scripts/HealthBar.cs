using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    Player player;

    // Start is called before the first frame update
    void Start()
    {
       // player = GameObject.Find("Player").GetComponent<Player>();
    }

    private void Update()
    {
        //float xScale = player.health / player.maxHealth;
       // transform.localScale = new Vector3(Mathf.Abs(xScale), 1,0);
    }
    // Update is called once per frame

}
