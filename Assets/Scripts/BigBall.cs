using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBall : MonoBehaviour
{
    public AudioSource Power;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("PacMan"))
        {
            Power.Play();
            PacMan.mode += 1;
            Destroy(gameObject);
        }
    }

}
