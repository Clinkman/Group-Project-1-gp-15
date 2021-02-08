﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;

    // movement speed
    [SerializeField] float speed;

    // possible movent directions
    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    int directionIndex = 1;

    // doesn't have to be serialized
    [SerializeField] Vector2 currentDir;

    // how far to look ahead
    [SerializeField] float rayDistance;

    // which layers to raycast for
    [SerializeField] LayerMask rayLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        // start moving in a directions
        currentDir = directions[directionIndex];
    }

    // Update is called once per frame
    void Update()
    {
        // raycast
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        Vector3 endpoint = currentDir * rayDistance;
        // visably debug the ray
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);

        // if walls and pacman layer are selected, will return true for either
        if (hit2D.collider != null)
        {
            // check if wall ahead
            if (hit2D.collider.gameObject.CompareTag("wall"))
            {
                ChangeDirection();
            }

            // check if pacman ahead
            if (hit2D.collider.gameObject.CompareTag("PacMan"))
            {
                // deal damage;
                print("pacman ahead!");
            }
        }
      
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("PacMan"))
        {
            if (PacMan.mode >= 1)
            {
                Destroy(gameObject);
            }
        }
    }


    void ChangeDirection()
    {
        // randomly select between -1 and 1;
        directionIndex += Random.Range(0, 2) * 2 - 1;

        // keeps index from exceeding 3
        int clampedIndex = directionIndex % directions.Length;

        // keep index positive
        if (clampedIndex < 0)
        {
            clampedIndex = directions.Length + clampedIndex;
        }

        // temporary freeze movement before set the new direction
        rb.velocity = Vector2.zero;

        // set the current direction from the directions array
        currentDir = directions[clampedIndex];
    }

    void FixedUpdate()
    {
        // move in current direction
        rb.AddForce(currentDir * speed);
    }
}