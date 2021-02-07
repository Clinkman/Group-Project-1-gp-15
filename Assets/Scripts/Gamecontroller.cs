using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gamecontroller : MonoBehaviour
{
    public GameObject gameover;
    public GameObject win;
    public GameObject level1;
    public GameObject level2;
    public GameObject live1;
    public GameObject live2;
    public GameObject live3;

    public static int winLevel = 0;
    public static int lives = 3;
    public Text live;
    public Text wL;


    // Start is called before the first frame update
    void Start()
    {
        gameover.SetActive(false);
        win.SetActive(false);
        level1.SetActive(true);
        level2.SetActive(false);
        live1.SetActive(true);
        live2.SetActive(true);
        live3.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        LifeCounter();
        Levelchg();
        live.text = "" + lives;
        wL.text = "" + winLevel;
    }
    void Levelchg()
    {
        if(winLevel >= 306 && winLevel <= 306)
        {
            level1.SetActive(false);
            level2.SetActive(true);
        }
        else if(winLevel >= 612 && winLevel <= 612)
        {
            win.SetActive(true);
        }
    }
    void LifeCounter()
    {
        if(lives >= 3)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(true);
        }
        else if(lives > 1 && lives < 3)
        {
            live1.SetActive(true);
            live2.SetActive(true);
            live3.SetActive(false);
        }
        else if(lives > 0 && lives < 2)
        {
            live1.SetActive(true);
            live2.SetActive(false);
            live3.SetActive(false);
        }
        else if(lives <= 0)
        {
            live1.SetActive(false);
            live2.SetActive(false);
            live3.SetActive(false);
            gameover.SetActive(true);
        }
    }
}
