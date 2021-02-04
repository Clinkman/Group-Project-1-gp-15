using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreScript.scoreValue += 100;
        Destroy(gameObject);
    }
}
