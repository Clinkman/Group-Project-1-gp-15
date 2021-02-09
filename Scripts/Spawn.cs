using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static GameObject Ghost;
    public static GameObject Pacman;
    public GameObject spawnG;
    public GameObject spawnP;

    public Transform ghostSpawn;
    public static Transform playerSpawn;

    public float respTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    { 
        ghostSpawn = spawnG.GetComponent<Transform>();
        playerSpawn = spawnP.GetComponent<Transform>();
        spawnGhost();
    }
        
    public void spawnGhost()
    {
        GameObject a = Instantiate(Ghost) as GameObject;
        a.transform.position = new Vector3(ghostSpawn.position.x, ghostSpawn.position.y, -2f);
    }
    public static void spawnPacMan()
    {
        GameObject b = Instantiate(Pacman) as GameObject;
        b.transform.position = new Vector3(playerSpawn.position.x, playerSpawn.position.y, -2);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}