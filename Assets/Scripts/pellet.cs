using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pellet : MonoBehaviour
{
    public AudioSource beep;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("PacMan"))
        {
            beep.Play();
            ScoreScript.scoreValue += 100;
            PacMan.gold += 1;
            Destroy(gameObject);
        }
    }
}
