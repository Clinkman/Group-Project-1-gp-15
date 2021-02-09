using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gems : MonoBehaviour
{
    public float timeLeft = 10f;
    public GameObject dimond;
    public AudioSource pick;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft -= Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("PacMan"))
        {
            pick.Play();
            ScoreScript.scoreValue += 1000;
            Destroy(gameObject);
        }
    }
}
