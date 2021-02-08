using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PacMan : MonoBehaviour {

	public float speed = 4.0f;

	private Vector2 direction = Vector2.zero;

	public int liveNumber = 3;

	public GameObject Player;

	public static int gold = 0;

	public static int mode = 0;

	public float timeLeft = 10f;

	public AudioSource Boom;

	// Use this for initialization
	void Start () 
	{
		lives.Number = liveNumber;
	}
	
	// Update is called once per frame
	void Update () {

		CheckInput ();

		Move ();

		UpdateOrientation ();

		if(gold >= 52)
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
		}

		if(mode >= 1)
        {
			timeLeft -= Time.deltaTime;
        }
		if(timeLeft <= 0)
        {
			mode = 0;
			timeLeft = 10f;
        }
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.tag.Equals("Enemy"))
		{
			if (mode >= 1)
			{
				
			}
			else
			{
				if (liveNumber <= 1)
				{
					Boom.Play();
					Destroy(gameObject);
					SceneManager.LoadScene(3);
				}
				Boom.Play();
				Player.transform.position = new Vector3(-8, 0, -1);
				liveNumber -= 1;
				lives.Number = liveNumber;
			}
		}
	}

	void CheckInput () {

		if (Input.GetKeyDown (KeyCode.LeftArrow)) {

			direction = Vector2.left;

		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {

			direction = Vector2.right;

		} else if (Input.GetKeyDown (KeyCode.UpArrow)) {

			direction = Vector2.up;

		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {

			direction = Vector2.down;
		}
	}

	void Move () {

		transform.localPosition += (Vector3)(direction * speed) * Time.deltaTime;
	}

	void UpdateOrientation () {

		if (direction == Vector2.left) {

			transform.localScale = new Vector3 (-1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.right) {

			transform.localScale = new Vector3 (1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 0);

		} else if (direction == Vector2.up) {

			transform.localScale = new Vector3 (1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 90);

		} else if (direction == Vector2.down) {

			transform.localScale = new Vector3 (1, 1, 1);
			transform.localRotation = Quaternion.Euler (0, 0, 270);
		}
	}
}
