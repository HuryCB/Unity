using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Npc : MonoBehaviour
{
    public float health = 100f;
    public float maxHealth = 100f;
    public float speed = 1;
    public HealthBar healthBar;
    public TextMeshPro text;
    // Start is called before the first frame update
    public virtual void Start()
    {
        healthBar = GetComponentInChildren<HealthBar>();
        text = GetComponentInChildren<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Heal(float healAmount)
    {
        if (health + healAmount > maxHealth)
        {
            health = maxHealth;
        }
        else
        {
            health += healAmount;
        }
        CorrectHealthBar();
    }

    public void Damage(float damage)
    {
        if (health - damage > 0)
        {
            health -= damage;
        }
        else
        {
            Destroy(gameObject);
        }
        CorrectHealthBar();
        //Debug.Log("Recebeu dano");
    }

    public void CorrectHealthBar()
    {
        float xScale = health / maxHealth;
        healthBar.transform.localScale = new Vector3(Mathf.Abs(xScale), 1, 0);
        text.text = health.ToString();
    }
}
