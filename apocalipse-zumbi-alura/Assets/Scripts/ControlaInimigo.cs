using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject player;
    public float speed = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
       
        float distancia = Vector3.Distance(transform.position, player.transform.position);

        if(distancia > 2.5){
            Vector3 direcao = player.transform.position - transform.position;
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + direcao.normalized * speed * Time.deltaTime);

            //look at player
            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
    }
}
