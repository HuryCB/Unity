using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Vector3 moveDelta;
    public Item holding;
    private Rigidbody2D rigidBody;
    public float health = 100f;
    public float maxHealth = 100f;
    public float speed = 1;
    public HealthBar healthBar;
    public TextMeshPro text;
    

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        healthBar = GetComponentInChildren<HealthBar>();
        text = GetComponentInChildren<TextMeshPro>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
    }
 
    private void Update()
    {
        if(holding != null)
        {
            holding.transform.localPosition = new Vector3(0.16f, 0, 0);
            if (Input.GetMouseButtonDown(0))
            {
                holding.UseItem();

            }
        }
       
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveDelta = new Vector3(x, y, 0);

        if (moveDelta.x > 0)
        {
            transform.localScale = Vector3.one;
        }
        else if (moveDelta.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        {
            //transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            rigidBody.MovePosition(transform.position + moveDelta * Time.deltaTime * speed);
        }
        {
            //transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

    }

   public void Heal(int healAmount)
    {
        if(health + healAmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmount;
        }
        CorrectHealthBar();
    }

    public void Damage(int damage)
    {
        if(health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
        CorrectHealthBar();
    }

    public void CorrectHealthBar()
    {
        float xScale = health / maxHealth;
        healthBar.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, 0);
        text.text = health.ToString();
    }
}
