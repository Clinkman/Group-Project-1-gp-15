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

    public bool Life1 =true;
	public bool Life2 =true;
	public bool Life3 =true;
    
    public bool Gameover = false;

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
    public void GameoverTrue()
    {
        Gameover = true;
    }
    public void lostLife3()
    {
        Life3 = false;
        live3.SetActive(false);
    }
    public void lostLife2()
    {
        Life2 = false;
    }
    public void lostLife1()
    {
        Life1 = false;
    }
}
