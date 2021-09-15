using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image healthBar;
   // public float currentHealth;
   // private float maxHealth = 100f;
    Player player;

    private void Start()
    {
        healthBar = GetComponent<Image>();
        player = FindObjectOfType<Player>();

    }

    private void Update()
    { 
        healthBar.fillAmount = player.health / player.maxHealth;
        
    }
}
