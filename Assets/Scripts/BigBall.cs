using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("PacMan"))
        {
            PacMan.mode += 1;
            Destroy(gameObject);
        }
    }

}
