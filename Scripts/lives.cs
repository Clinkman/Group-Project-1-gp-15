using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class lives : MonoBehaviour
{
    public static int Number = 0;
    Text Lives;
    // Start is called before the first frame update
    void Start()
    {
        Lives = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        Lives.text = "Lives: " + Number;
    }
}
