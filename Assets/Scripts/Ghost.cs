using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] float speed;

    Vector2[] directions = { Vector2.up, Vector2.right, Vector2.down, Vector2.left };

    int directionIndex = 1;

    [SerializeField] Vector2 currentDir;

    [SerializeField] float rayDistance;

    [SerializeField] LayerMask rayLayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        currentDir = directions[directionIndex];
        GameObject GC = GameObject.Find("GameController");
        Gamecontroller gameController = GC.GetComponent<Gamecontroller>();
        Spawn sPawn = GameObject.Find("GameController").GetComponent<Spawn>();
        PacMan pacMan = GameObject.Find("Player").GetComponent<PacMan>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(transform.position, currentDir, rayDistance, rayLayer);
        Vector3 endpoint = currentDir * rayDistance;
        Debug.DrawLine(transform.position, transform.position + endpoint, Color.green);

        if (hit2D.collider != null)
        {
            if (hit2D.collider.gameObject.CompareTag("wall"))
            {
                ChangeDirection();
            }
            if (hit2D.collider.gameObject.CompareTag("PacMan"))
            {
                if(gameController.Life3 == true)
                {
                    sPawn.spawnPacMan();
                    gameController.lostLife3();

                }
                Gamecontroller.lives += -1;
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