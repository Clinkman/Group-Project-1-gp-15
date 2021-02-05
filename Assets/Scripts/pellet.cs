using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pellet : MonoBehaviour
{
    public Text Stext;
    public int ScoreValue;
    private void ScoreUpdate()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ScoreScript.scoreValue += 100;
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        Stext = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Stext.text = "Score: " + ScoreValue;
    }
}
