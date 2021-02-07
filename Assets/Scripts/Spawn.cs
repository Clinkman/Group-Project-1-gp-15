using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Ghost;
    public GameObject Pacman;
    public GameObject spawnG;
    public GameObject spawnP;

    public Transform ghostSpawn;

    public float respTime = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        ghostSpawn = spawnG.GetComponent<Transform>();
        spawnGhost();
    }
        
    public void spawnGhost()
    {
        GameObject a = Instantiate(Ghost) as GameObject;

        a.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(8.6f, 3.4f, -2f));
    }
    public void spawnPacMan()
    {
        GameObject b = Instantiate(Pacman) as GameObject;
        b.transform.position = new Vector2(ghostSpawn.position.x, ghostSpawn.position.y);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}