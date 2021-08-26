using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Mover
{
    // experience
    public int xpValue = 1;

    //logic
    public float triggerLenght = 1;
    public float chaseLenght = 5;
    private bool chasing;
    private bool collindingWithPlayer;
    private Transform playerTransform;
    private Vector3 startingPosition;

    // Hitbox
    private BoxCollider2D hitbox;
    private Collider2D[] hits = new Collider2D[10];
}
