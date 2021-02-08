using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellet : MonoBehaviour
{
    public int SVFill;
    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreScript.scoreValue += SVFill;
        Gamecontroller.winLevel += 1;
        Destroy(gameObject);
    }
}
