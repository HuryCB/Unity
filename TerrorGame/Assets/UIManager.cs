using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Player player;
    public static UIManager Instance;
    public Image healthStatus;
    public Image sanityStatus;
    public Image hungerStatus;
    public Sprite health100;
    public Sprite health75;
    public Sprite health50;
    public Sprite health25;
    public Sprite health0;
    public Sprite hunger100;
    public Sprite hunger75;
    public Sprite hunger50;
    public Sprite hunger25;
    public Sprite hunger0;
    public Sprite sanity100;
    public Sprite sanity75;
    public Sprite sanity50;
    public Sprite sanity25;
    public Sprite sanity0;

    public float lifePerCent;
    public float sanityPerCent;
    public float hungerPerCent;

    private void Update()
    {
        correctStatusSprites();
    }

    private void correctStatusSprites()
    {
        correctLifeSprites();
        correctHungerSprites();
        correctSanitySprites();
    }

    private void correctSanitySprites()
    {
        sanityPerCent = player.currentSanity / player.maxSanity;
        if (sanityPerCent == 1)
        {
            sanityStatus.sprite = sanity100;
            return;
        }
        if (sanityPerCent >= 0.75)
        {
            sanityStatus.sprite = sanity75;
            return;
        }
        if (sanityPerCent >= 0.5)
        {
            sanityStatus.sprite = sanity50;
            return;
        }
        if (sanityPerCent >= 0.25)
        {
            sanityStatus.sprite = sanity25;
            return;
        }
        if (sanityPerCent == 0)
        {
            sanityStatus.sprite = sanity0;
            return;
        }
    }

    private void correctHungerSprites()
    {
        hungerPerCent = player.currentHunger / player.maxHunger;
        if (hungerPerCent == 1)
        {
            hungerStatus.sprite = hunger100;
            return;
        }
        if (hungerPerCent >= 0.75)
        {
            hungerStatus.sprite = hunger75;
            return;
        }
        if (hungerPerCent >= 0.5)
        {
            hungerStatus.sprite = hunger50;
            return;
        }
        if (hungerPerCent >= 0.25)
        {
            hungerStatus.sprite = hunger25;
            return;
        }
        if (hungerPerCent == 0)
        {
            hungerStatus.sprite = hunger0;
            return;
        }
    }

    private void correctLifeSprites()
    {
        lifePerCent = player.currentLife / player.maxLife;
        if(lifePerCent == 1)
        {
            healthStatus.sprite = health100;
            return;
        }
        if(lifePerCent >= 0.75)
        {
            healthStatus.sprite = health75;
            return;
        }
        if(lifePerCent >= 0.5)
        {
            healthStatus.sprite = health50;
            return;
        }
        if (lifePerCent >= 0.25)
        {
            healthStatus.sprite = health25;
            return;
        }
        if (lifePerCent == 0)
        {
            healthStatus.sprite = health0;
            return;
        }

    }

    private void MakeSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Awake()
    {
        MakeSingleton();
    }

    private void Start()
    {
        player = GameObject.Find("PlayerBody").GetComponent<Player>();
    }

}
